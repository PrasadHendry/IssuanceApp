// IssuanceRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Data.SqlClient;

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

        #region Generic Helpers
        private async Task<DataTable> GetDataTableAsync(string sql, List<SqlParameter> parameters = null, CancellationToken token = default)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(token);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());
                    using (var reader = await cmd.ExecuteReaderAsync(token))
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private async Task<int> ExecuteNonQueryAsync(string sql, List<SqlParameter> parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task<object> ExecuteScalarAsync(string sql, List<SqlParameter> parameters = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters.ToArray());
                    return await cmd.ExecuteScalarAsync();
                }
            }
        }
        #endregion

        #region Login and User Management
        public async Task<List<string>> GetRoleNamesAsync()
        {
            var roles = new List<string>();
            string sql = "SELECT RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            DataTable dt = await GetDataTableAsync(sql);
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(row["RoleName"].ToString());
            }
            return roles;
        }

        public async Task<bool> AuthenticateUserAsync(string roleName, string password)
        {
            string sql = "SELECT PasswordHash FROM dbo.User_Roles WHERE RoleName = @roleName;";
            var parameters = new List<SqlParameter> { new SqlParameter("@roleName", roleName) };
            object result = await ExecuteScalarAsync(sql, parameters);
            if (result != null && result != DBNull.Value)
            {
                string storedHash = result.ToString();
                // This requires the BCrypt.Net-Next package
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            return false;
        }

        public async Task<List<UserRole>> GetUserRolesForGridAsync()
        {
            var roles = new List<UserRole>();
            string sql = "SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleID;";
            DataTable dt = await GetDataTableAsync(sql);
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new UserRole
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString()
                });
            }
            return roles;
        }

        public async Task<bool> ResetUserPasswordAsync(string roleName, string newPasswordHash)
        {
            string sql = "UPDATE dbo.User_Roles SET PasswordHash = @NewPasswordHash WHERE RoleName = @RoleName;";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@NewPasswordHash", newPasswordHash),
                new SqlParameter("@RoleName", roleName)
            };
            return await ExecuteNonQueryAsync(sql, parameters) > 0;
        }
        #endregion

        #region Document Issuance
        public async Task<string> GenerateNewRequestNumberAsync()
        {
            string prefix = $"REQ-{DateTime.Now:yyyyMMdd}-";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("dbo.sp_GetNextRequestNumber", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    object result = await cmd.ExecuteScalarAsync();
                    return $"{prefix}{(int)result:D3}";
                }
            }
        }

        public async Task CreateIssuanceRequestAsync(IssuanceRequestData data)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("dbo.sp_CreateIssuanceRequest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RequestNo", data.RequestNo);
                    cmd.Parameters.AddWithValue("@RequestDate", data.RequestDate);
                    cmd.Parameters.AddWithValue("@FromDepartment", data.FromDepartment);
                    cmd.Parameters.AddWithValue("@DocumentNo", data.DocumentNo);
                    cmd.Parameters.AddWithValue("@ParentBatchNumber", (object)data.ParentBatchNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentBatchSize", (object)data.ParentBatchSize ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentMfgDate", (object)data.ParentMfgDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentExpDate", (object)data.ParentExpDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Product", data.Product);
                    cmd.Parameters.AddWithValue("@BatchNo", (object)data.BatchNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchSize", data.BatchSize);
                    cmd.Parameters.AddWithValue("@ItemMfgDate", (object)data.ItemMfgDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemExpDate", (object)data.ItemExpDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Market", (object)data.Market ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PackSize", (object)data.PackSize ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ExportOrderNo", (object)data.ExportOrderNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PreparedBy", data.PreparedBy);
                    cmd.Parameters.AddWithValue("@RequestComment", (object)data.RequestComment ?? DBNull.Value);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        #region GM & QA Operations
        public async Task<List<GmQueueItemDto>> GetGmPendingQueueAsync()
        {
            var queue = new List<GmQueueItemDto>();
            string sql = @"
                SELECT 
                    i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt,
                    i.FromDepartment, i.BatchNo, i.ItemMfgDate, i.ItemExpDate, i.Market, i.PackSize,
                    t.RequestComment
                FROM dbo.Doc_Issuance AS i 
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction IS NULL ORDER BY i.RequestNo DESC;";
            DataTable dt = await GetDataTableAsync(sql);
            foreach (DataRow row in dt.Rows)
            {
                queue.Add(new GmQueueItemDto
                {
                    RequestNo = row["RequestNo"].ToString(),
                    RequestDate = (DateTime)row["RequestDate"],
                    Product = row["Product"].ToString(),
                    DocumentNo = row["DocumentNo"].ToString(),
                    PreparedBy = row["PreparedBy"].ToString(),
                    RequestedAt = (DateTime)row["RequestedAt"],
                    FromDepartment = row["FromDepartment"].ToString(),
                    BatchNo = row["BatchNo"].ToString(),
                    ItemMfgDate = row["ItemMfgDate"].ToString(),
                    ItemExpDate = row["ItemExpDate"].ToString(),
                    Market = row["Market"].ToString(),
                    PackSize = row["PackSize"].ToString(),
                    RequestComment = row["RequestComment"].ToString()
                });
            }
            return queue;
        }

        public async Task<List<QaQueueItemDto>> GetQaPendingQueueAsync()
        {
            var queue = new List<QaQueueItemDto>();
            string sql = @"
                SELECT 
                    i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt, 
                    t.AuthorizedBy, t.GmOperationsAt, i.FromDepartment, i.BatchNo, i.ItemMfgDate, 
                    i.ItemExpDate, i.Market, i.PackSize, t.RequestComment, t.GmOperationsComment
                FROM dbo.Doc_Issuance AS i 
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction = @Action AND t.QAAction IS NULL ORDER BY i.RequestNo DESC;";
            var parameters = new List<SqlParameter> { new SqlParameter("@Action", AppConstants.ActionAuthorized) };
            DataTable dt = await GetDataTableAsync(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                queue.Add(new QaQueueItemDto
                {
                    RequestNo = row["RequestNo"].ToString(),
                    RequestDate = (DateTime)row["RequestDate"],
                    Product = row["Product"].ToString(),
                    DocumentNo = row["DocumentNo"].ToString(),
                    PreparedBy = row["PreparedBy"].ToString(),
                    RequestedAt = (DateTime)row["RequestedAt"],
                    AuthorizedBy = row["AuthorizedBy"].ToString(),
                    GmActionAt = (DateTime)row["GmOperationsAt"],
                    FromDepartment = row["FromDepartment"].ToString(),
                    BatchNo = row["BatchNo"].ToString(),
                    ItemMfgDate = row["ItemMfgDate"].ToString(),
                    ItemExpDate = row["ItemExpDate"].ToString(),
                    Market = row["Market"].ToString(),
                    PackSize = row["PackSize"].ToString(),
                    RequestComment = row["RequestComment"].ToString(),
                    GmOperationsComment = row["GmOperationsComment"].ToString()
                });
            }
            return queue;
        }

        public async Task<bool> UpdateGmActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    GmOperationsAction = @Action, AuthorizedBy = @User, GmOperationsAt = GETDATE(), GmOperationsComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Action", action), new SqlParameter("@User", userName),
                new SqlParameter("@Comment", (object)comment ?? DBNull.Value), new SqlParameter("@RequestNo", requestNo)
            };
            return await ExecuteNonQueryAsync(sql, parameters) > 0;
        }

        public async Task<bool> UpdateQaActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    QAAction = @Action, ApprovedBy = @User, QAAt = GETDATE(), QAComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Action", action), new SqlParameter("@User", userName),
                new SqlParameter("@Comment", (object)comment ?? DBNull.Value), new SqlParameter("@RequestNo", requestNo)
            };
            return await ExecuteNonQueryAsync(sql, parameters) > 0;
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
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", from.Date), new SqlParameter("@ToDate", to.Date),
                new SqlParameter("@ActionRejected", AppConstants.ActionRejected),
                new SqlParameter("@ActionApproved", AppConstants.ActionApproved),
                new SqlParameter("@ActionAuthorized", AppConstants.ActionAuthorized)
            };

            if (status != "All") { sqlBuilder.Append("AND DerivedStatus = @Status "); parameters.Add(new SqlParameter("@Status", status)); }
            if (!string.IsNullOrWhiteSpace(requestNo)) { sqlBuilder.Append("AND RequestNo LIKE @RequestNo "); parameters.Add(new SqlParameter("@RequestNo", $"%{requestNo.Trim()}%")); }
            if (!string.IsNullOrWhiteSpace(product)) { sqlBuilder.Append("AND Product LIKE @Product "); parameters.Add(new SqlParameter("@Product", $"%{product.Trim()}%")); }

            string safeSortColumn = "RequestNo";
            var validSortColumns = new List<string> { "RequestNo", "RequestDate", "Product", "DerivedStatus", "PreparedBy", "RequestedAt" };
            if (!string.IsNullOrEmpty(sortColumn) && validSortColumns.Contains(sortColumn)) { safeSortColumn = sortColumn; }
            string sortDirection = (sortOrder == System.Windows.Forms.SortOrder.Ascending) ? "ASC" : "DESC";
            sqlBuilder.Append($" ORDER BY {safeSortColumn} {sortDirection}");

            DataTable keysTable = await GetDataTableAsync(sqlBuilder.ToString(), parameters, token);
            return keysTable.AsEnumerable().Select(row => row.Field<int>("IssuanceID")).ToList();
        }

        public async Task<List<AuditTrailEntry>> GetAuditTrailEntriesAsync(List<int> keys, CancellationToken token)
        {
            if (keys == null || !keys.Any()) { return new List<AuditTrailEntry>(); }

            var results = new List<AuditTrailEntry>();
            var sqlBuilder = new StringBuilder(@"
                SELECT i.IssuanceID, i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt, t.RequestComment,
                       t.GmOperationsAction, t.AuthorizedBy, t.GmOperationsAt, t.GmOperationsComment,
                       t.QAAction, t.ApprovedBy, t.QAAt, t.QAComment,
                    CASE 
                        WHEN t.QAAction = @ActionRejected THEN 'Rejected by QA'
                        WHEN t.GmOperationsAction = @ActionRejected THEN 'Rejected by GM'
                        WHEN t.QAAction = @ActionApproved THEN 'Approved (Issued)'
                        WHEN t.GmOperationsAction = @ActionAuthorized THEN 'Pending QA Approval'
                        ELSE 'Pending GM Approval'
                    END AS DerivedStatus
                FROM dbo.Doc_Issuance i JOIN dbo.Issuance_Tracker t ON i.IssuanceID = t.IssuanceID
                WHERE i.IssuanceID IN (");
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ActionRejected", AppConstants.ActionRejected), new SqlParameter("@ActionApproved", AppConstants.ActionApproved),
                new SqlParameter("@ActionAuthorized", AppConstants.ActionAuthorized)
            };

            for (int i = 0; i < keys.Count; i++)
            {
                string paramName = $"@key{i}";
                sqlBuilder.Append(paramName);
                if (i < keys.Count - 1) sqlBuilder.Append(", ");
                parameters.Add(new SqlParameter(paramName, keys[i]));
            }
            sqlBuilder.Append(");");

            DataTable dt = await GetDataTableAsync(sqlBuilder.ToString(), parameters, token);

            foreach (DataRow row in dt.Rows)
            {
                token.ThrowIfCancellationRequested();
                results.Add(new AuditTrailEntry
                {
                    IssuanceID = (int)row["IssuanceID"],
                    RequestNo = row["RequestNo"].ToString(),
                    RequestDate = (DateTime)row["RequestDate"],
                    Product = row["Product"].ToString(),
                    DocumentNumbers = row["DocumentNo"].ToString(),
                    DerivedStatus = row["DerivedStatus"].ToString(),
                    PreparedBy = row["PreparedBy"].ToString(),
                    RequestedAt = row["RequestedAt"] != DBNull.Value ? (DateTime?)row["RequestedAt"] : null,
                    GmOperationsAction = row["GmOperationsAction"].ToString(),
                    AuthorizedBy = row["AuthorizedBy"].ToString(),
                    GmOperationsAt = row["GmOperationsAt"] != DBNull.Value ? (DateTime?)row["GmOperationsAt"] : null,
                    GmOperationsComment = row["GmOperationsComment"].ToString(),
                    QAAction = row["QAAction"].ToString(),
                    ApprovedBy = row["ApprovedBy"].ToString(),
                    QAAt = row["QAAt"] != DBNull.Value ? (DateTime?)row["QAAt"] : null,
                    QAComment = row["QAComment"].ToString()
                });
            }
            return results;
        }
        #endregion
    }
}