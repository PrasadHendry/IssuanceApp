// IssuanceRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
// REFINEMENT: Added using static directive to simplify access to AppConstants members.
using static IssuanceApp.Data.AppConstants;

namespace IssuanceApp.Data
{
    public class IssuanceRepository
    {
        private readonly string _connectionString;

        public IssuanceRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        #region Login and User Management
        public async Task<List<string>> GetRoleNamesAsync()
        {
            string sql = "SELECT RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            using (var conn = new SqlConnection(_connectionString))
            {
                var roles = await conn.QueryAsync<string>(sql);
                return roles.ToList();
            }
        }

        public async Task<bool> AuthenticateUserAsync(string roleName, string password)
        {
            string sql = "SELECT PasswordHash FROM dbo.User_Roles WHERE RoleName = @roleName;";
            using (var conn = new SqlConnection(_connectionString))
            {
                string storedPassword = await conn.ExecuteScalarAsync<string>(sql, new { roleName });
                if (!string.IsNullOrEmpty(storedPassword))
                {
                    return password == storedPassword;
                }
                return false;
            }
        }

        public async Task<List<UserRole>> GetUserRolesForGridAsync()
        {
            string sql = "SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleID;";
            using (var conn = new SqlConnection(_connectionString))
            {
                var roles = await conn.QueryAsync<UserRole>(sql);
                return roles.ToList();
            }
        }

        public async Task<bool> ResetUserPasswordAsync(string roleName, string newPassword)
        {
            string sql = "UPDATE dbo.User_Roles SET PasswordHash = @NewPassword WHERE RoleName = @RoleName;";
            using (var conn = new SqlConnection(_connectionString))
            {
                var parameters = new { NewPassword = newPassword, RoleName = roleName };
                int affectedRows = await conn.ExecuteAsync(sql, parameters);
                return affectedRows > 0;
            }
        }
        #endregion

        #region Document Issuance
        public async Task<string> GenerateNewRequestNumberAsync()
        {
            string prefix = $"REQ-{DateTime.Now:yyyyMMdd}-";
            using (var conn = new SqlConnection(_connectionString))
            {
                int nextId = await conn.ExecuteScalarAsync<int>("dbo.sp_GetNextRequestNumber", commandType: CommandType.StoredProcedure);
                return $"{prefix}{nextId:D3}";
            }
        }

        public async Task CreateIssuanceRequestAsync(IssuanceRequestData data)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.ExecuteAsync("dbo.sp_CreateIssuanceRequest", data, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        #region GM & QA Operations
        public async Task<List<GmQueueItemDto>> GetGmPendingQueueAsync()
        {
            string sql = @"
                SELECT 
                    i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt,
                    i.FromDepartment, i.BatchNo, i.ItemMfgDate, i.ItemExpDate, i.Market, i.PackSize,
                    t.RequestComment,
                    -- ADDED --
                    i.ParentBatchNumber, i.ParentBatchSize, i.ParentMfgDate, i.ParentExpDate
                FROM dbo.Doc_Issuance AS i 
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction IS NULL ORDER BY i.RequestNo DESC;";
            using (var conn = new SqlConnection(_connectionString))
            {
                var queue = await conn.QueryAsync<GmQueueItemDto>(sql);
                return queue.ToList();
            }
        }

        public async Task<List<QaQueueItemDto>> GetQaPendingQueueAsync()
        {
            string sql = @"
                SELECT 
                    i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt, 
                    t.AuthorizedBy, t.GmOperationsAt, i.FromDepartment, i.BatchNo, i.ItemMfgDate, 
                    i.ItemExpDate, i.Market, i.PackSize, t.RequestComment, t.GmOperationsComment,
                    -- ADDED --
                    i.ParentBatchNumber, i.ParentBatchSize, i.ParentMfgDate, i.ParentExpDate
                FROM dbo.Doc_Issuance AS i 
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction = @Action AND t.QAAction IS NULL ORDER BY i.RequestNo DESC;";
            using (var conn = new SqlConnection(_connectionString))
            {
                var queue = await conn.QueryAsync<QaQueueItemDto>(sql, new { Action = ActionAuthorized });
                return queue.ToList();
            }
        }

        public async Task<bool> UpdateGmActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    GmOperationsAction = @Action, AuthorizedBy = @User, GmOperationsAt = GETDATE(), GmOperationsComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            using (var conn = new SqlConnection(_connectionString))
            {
                var parameters = new { Action = action, User = userName, Comment = comment, RequestNo = requestNo };
                int affectedRows = await conn.ExecuteAsync(sql, parameters);
                return affectedRows > 0;
            }
        }

        public async Task<bool> UpdateQaActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    QAAction = @Action, 
                    ApprovedBy = @User, 
                    QAAt = GETDATE(), 
                    QAComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            using (var conn = new SqlConnection(_connectionString))
            {
                var parameters = new
                {
                    Action = action,
                    User = userName,
                    Comment = comment,
                    RequestNo = requestNo
                };
                int affectedRows = await conn.ExecuteAsync(sql, parameters);
                return affectedRows > 0;
            }
        }
        #endregion

        #region Audit Trail
        public async Task<List<int>> GetAuditTrailKeysAsync(DateTime from, DateTime to, string status, string requestNo, string product, string sortColumn, System.Windows.Forms.SortOrder sortOrder, CancellationToken token)
        {
            var sqlBuilder = new StringBuilder(@"
                WITH AuditData AS (
                    SELECT i.IssuanceID, i.RequestNo, i.RequestDate, i.Product, t.PreparedBy, t.RequestedAt,
                        CASE
                            WHEN t.QAAction = @ActionRejected THEN 'Rejected by QA'
                            WHEN t.GmOperationsAction = @ActionRejected THEN 'Rejected by GM'
                            WHEN t.QAAction = @ActionApproved THEN 'Approved (Issued)'
                            WHEN t.GmOperationsAction = @ActionAuthorized THEN 'Pending QA Approval'
                            ELSE 'Pending GM Approval'
                        END AS DerivedStatus
                    FROM dbo.Doc_Issuance i JOIN dbo.Issuance_Tracker t ON i.IssuanceID = t.IssuanceID
                    WHERE i.RequestDate BETWEEN @FromDate AND @ToDate
                )
                SELECT IssuanceID FROM AuditData
                WHERE 1=1 ");

            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", from.Date);
            parameters.Add("@ToDate", to.Date);
            parameters.Add("@ActionRejected", ActionRejected);
            parameters.Add("@ActionApproved", ActionApproved);
            parameters.Add("@ActionAuthorized", ActionAuthorized);

            if (status != "All") { sqlBuilder.Append("AND DerivedStatus = @Status "); parameters.Add("@Status", status); }
            if (!string.IsNullOrWhiteSpace(requestNo)) { sqlBuilder.Append("AND RequestNo LIKE @RequestNo "); parameters.Add("@RequestNo", $"%{requestNo.Trim()}%"); }
            if (!string.IsNullOrWhiteSpace(product)) { sqlBuilder.Append("AND Product LIKE @Product "); parameters.Add("@Product", $"%{product.Trim()}%"); }

            string safeSortColumn = "RequestNo";
            var validSortColumns = new List<string> { "RequestNo", "RequestDate", "Product", "DerivedStatus", "PreparedBy", "RequestedAt" };
            if (!string.IsNullOrEmpty(sortColumn) && validSortColumns.Contains(sortColumn)) { safeSortColumn = sortColumn; }
            string sortDirection = (sortOrder == System.Windows.Forms.SortOrder.Ascending) ? "ASC" : "DESC";
            sqlBuilder.Append($" ORDER BY {safeSortColumn} {sortDirection}");

            using (var conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(sqlBuilder.ToString(), parameters, cancellationToken: token);
                var keys = await conn.QueryAsync<int>(command);
                return keys.ToList();
            }
        }

        public async Task<List<AuditTrailEntry>> GetAuditTrailEntriesAsync(List<int> keys, CancellationToken token)
        {
            if (keys == null || !keys.Any()) { return new List<AuditTrailEntry>(); }

            string sql = @"
                SELECT i.IssuanceID, i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, i.FromDepartment, t.RequestedAt, t.RequestComment,
                       t.GmOperationsAction, t.AuthorizedBy, t.GmOperationsAt, t.GmOperationsComment,
                       t.QAAction, t.ApprovedBy, t.QAAt, t.QAComment,
                       i.ParentBatchNumber, i.ParentBatchSize, i.ParentMfgDate, i.ParentExpDate,
                    CASE 
                        WHEN t.QAAction = @ActionRejected THEN 'Rejected by QA'
                        WHEN t.GmOperationsAction = @ActionRejected THEN 'Rejected by GM'
                        WHEN t.QAAction = @ActionApproved THEN 'Approved (Issued)'
                        WHEN t.GmOperationsAction = @ActionAuthorized THEN 'Pending QA Approval'
                        ELSE 'Pending GM Approval'
                    END AS DerivedStatus
                FROM dbo.Doc_Issuance i JOIN dbo.Issuance_Tracker t ON i.IssuanceID = t.IssuanceID
                WHERE i.IssuanceID IN @keys;";

            using (var conn = new SqlConnection(_connectionString))
            {
                // REFINEMENT: AppConstants prefix is no longer needed due to the 'using static' directive.
                var parameters = new
                {
                    keys,
                    ActionRejected,
                    ActionApproved,
                    ActionAuthorized
                };
                var command = new CommandDefinition(sql, parameters, cancellationToken: token);
                var results = await conn.QueryAsync<AuditTrailEntry>(command);
                return results.ToList();
            }
        }
        #endregion
    }
}