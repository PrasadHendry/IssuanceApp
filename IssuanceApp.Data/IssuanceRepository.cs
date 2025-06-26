using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace IssuanceApp.Data
{
    public class IssuanceRepository
    {
        // ... (All existing code from the previous async version remains the same up to the Audit Trail region) ...
        #region Previous Async Code
        private readonly string _connectionString;

        public IssuanceRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Database connection string cannot be null or empty.");

            _connectionString = connectionString;
        }

        private async Task<DataTable> GetDataTableAsync(string sql, List<SqlParameter> parameters = null)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (var reader = await cmd.ExecuteReaderAsync())
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
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
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
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    return await cmd.ExecuteScalarAsync();
                }
            }
        }

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
                return password == result.ToString();
            }
            return false;
        }

        public Task<DataTable> GetUserRolesForGridAsync()
        {
            string sql = "SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            return GetDataTableAsync(sql);
        }

        public async Task<bool> ResetUserPasswordAsync(string roleName, string newPasswordHash)
        {
            string sql = "UPDATE dbo.User_Roles SET PasswordHash = @NewPasswordHash WHERE RoleName = @RoleName;";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@NewPasswordHash", newPasswordHash),
                new SqlParameter("@RoleName", roleName)
            };
            int rowsAffected = await ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected > 0;
        }

        public async Task<string> GenerateNewRequestNumberAsync()
        {
            string prefix = $"REQ-{DateTime.Now:yyyyMMdd}-";
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(RequestNo, 14, 3) AS INT)), 0) FROM dbo.Doc_Issuance WHERE RequestNo LIKE @prefix + '%';";
            var parameters = new List<SqlParameter> { new SqlParameter("@prefix", prefix) };
            object result = await ExecuteScalarAsync(sql, parameters);
            int nextSequence = 1;
            if (result != null && result != DBNull.Value)
            {
                nextSequence = Convert.ToInt32(result) + 1;
            }
            return $"{prefix}{nextSequence:D3}";
        }

        public async Task CreateIssuanceRequestAsync(IssuanceRequestData data)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
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

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<DataTable> GetGmPendingQueueAsync()
        {
            string sql = @"
                SELECT i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction IS NULL
                ORDER BY t.RequestedAt ASC;";
            return GetDataTableAsync(sql);
        }

        public Task<DataTable> GetQaPendingQueueAsync()
        {
            string sql = @"
                SELECT i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.AuthorizedBy, t.GmOperationsAt AS GmActionAt
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction = 'Authorized' AND t.QAAction IS NULL
                ORDER BY t.GmOperationsAt ASC;";
            return GetDataTableAsync(sql);
        }

        public Task<DataTable> GetFullRequestDetailsAsync(string requestNo)
        {
            string sql = @"
                SELECT i.*, t.RequestComment, t.GmOperationsComment
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE i.RequestNo = @RequestNo;";
            return GetDataTableAsync(sql, new List<SqlParameter> { new SqlParameter("@RequestNo", requestNo) });
        }

        public async Task<bool> UpdateGmActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    GmOperationsAction = @Action, AuthorizedBy = @User, GmOperationsAt = GETDATE(), GmOperationsComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Action", action),
                new SqlParameter("@User", userName),
                new SqlParameter("@Comment", (object)comment ?? DBNull.Value),
                new SqlParameter("@RequestNo", requestNo)
            };
            int rowsAffected = await ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateQaActionAsync(string requestNo, string action, string comment, string userName)
        {
            string sql = @"
                UPDATE dbo.Issuance_Tracker SET
                    QAAction = @Action, ApprovedBy = @User, QAAt = GETDATE(), QAComment = @Comment
                WHERE IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Action", action),
                new SqlParameter("@User", userName),
                new SqlParameter("@Comment", (object)comment ?? DBNull.Value),
                new SqlParameter("@RequestNo", requestNo)
            };
            int rowsAffected = await ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected > 0;
        }
        #endregion

        #region Audit Trail
        public async Task<List<int>> GetAuditTrailKeysAsync(DateTime from, DateTime to, string status, string requestNo, string product, string sortColumn, System.Windows.Forms.SortOrder sortOrder)
        {
            // ... (This method remains unchanged) ...
            var sqlBuilder = new StringBuilder(@"
                WITH AuditData AS (
                    SELECT i.IssuanceID, i.RequestNo, i.RequestDate, i.Product, t.PreparedBy, t.RequestedAt,
                        CASE
                            WHEN t.QAAction = 'Rejected' THEN 'Rejected by QA'
                            WHEN t.GmOperationsAction = 'Rejected' THEN 'Rejected by GM'
                            WHEN t.QAAction = 'Approved' THEN 'Approved (Issued)'
                            WHEN t.GmOperationsAction = 'Authorized' THEN 'Pending QA Approval'
                            ELSE 'Pending GM Approval'
                        END AS DerivedStatus
                    FROM dbo.Doc_Issuance i
                    JOIN dbo.Issuance_Tracker t ON i.IssuanceID = t.IssuanceID
                    WHERE i.RequestDate BETWEEN @FromDate AND @ToDate
                )
                SELECT IssuanceID FROM AuditData
                WHERE 1=1 ");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", from.Date),
                new SqlParameter("@ToDate", to.Date)
            };

            if (status != "All")
            {
                sqlBuilder.Append("AND DerivedStatus = @Status ");
                parameters.Add(new SqlParameter("@Status", status));
            }
            if (!string.IsNullOrWhiteSpace(requestNo))
            {
                sqlBuilder.Append("AND RequestNo LIKE @RequestNo ");
                parameters.Add(new SqlParameter("@RequestNo", $"%{requestNo.Trim()}%"));
            }
            if (!string.IsNullOrWhiteSpace(product))
            {
                sqlBuilder.Append("AND Product LIKE @Product ");
                parameters.Add(new SqlParameter("@Product", $"%{product.Trim()}%"));
            }

            string safeSortColumn = "RequestDate";
            var validSortColumns = new List<string> { "RequestNo", "RequestDate", "Product", "DerivedStatus", "PreparedBy", "RequestedAt" };
            if (!string.IsNullOrEmpty(sortColumn) && validSortColumns.Contains(sortColumn))
            {
                safeSortColumn = sortColumn;
            }

            string sortDirection = (sortOrder == System.Windows.Forms.SortOrder.Ascending) ? "ASC" : "DESC";
            sqlBuilder.Append($" ORDER BY {safeSortColumn} {sortDirection}");

            DataTable keysTable = await GetDataTableAsync(sqlBuilder.ToString(), parameters);
            return keysTable.AsEnumerable().Select(row => row.Field<int>("IssuanceID")).ToList();
        }

        // --- NEW METHOD FOR EFFICIENT PAGE FETCHING ---
        public async Task<List<AuditTrailEntry>> GetAuditTrailEntriesAsync(List<int> keys)
        {
            if (keys == null || !keys.Any())
            {
                return new List<AuditTrailEntry>();
            }

            var results = new List<AuditTrailEntry>();
            var sqlBuilder = new StringBuilder(@"
                SELECT i.IssuanceID, i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt, t.RequestComment,
                       t.GmOperationsAction, t.AuthorizedBy, t.GmOperationsAt, t.GmOperationsComment,
                       t.QAAction, t.ApprovedBy, t.QAAt, t.QAComment,
                    CASE 
                        WHEN t.QAAction = 'Rejected' THEN 'Rejected by QA'
                        WHEN t.GmOperationsAction = 'Rejected' THEN 'Rejected by GM'
                        WHEN t.QAAction = 'Approved' THEN 'Approved (Issued)'
                        WHEN t.GmOperationsAction = 'Authorized' THEN 'Pending QA Approval'
                        ELSE 'Pending GM Approval'
                    END AS DerivedStatus
                FROM dbo.Doc_Issuance i
                JOIN dbo.Issuance_Tracker t ON i.IssuanceID = t.IssuanceID
                WHERE i.IssuanceID IN (");

            var parameters = new List<SqlParameter>();
            for (int i = 0; i < keys.Count; i++)
            {
                string paramName = $"@key{i}";
                sqlBuilder.Append(paramName);
                if (i < keys.Count - 1)
                {
                    sqlBuilder.Append(", ");
                }
                parameters.Add(new SqlParameter(paramName, keys[i]));
            }
            sqlBuilder.Append(");");

            DataTable dt = await GetDataTableAsync(sqlBuilder.ToString(), parameters);

            foreach (DataRow row in dt.Rows)
            {
                results.Add(new AuditTrailEntry
                {
                    IssuanceID = (int)row["IssuanceID"], // Add IssuanceID to the DTO
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