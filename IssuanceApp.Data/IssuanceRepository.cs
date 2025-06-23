using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace IssuanceApp.Data
{
    public class IssuanceRepository
    {
        private readonly string _connectionString;

        public IssuanceRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Database connection string cannot be null or empty.");

            _connectionString = connectionString;
        }

        #region Generic Data Access Helpers
        private DataTable GetDataTable(string sql, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private int ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            int rowsAffected;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        private object ExecuteScalar(string sql, List<SqlParameter> parameters = null)
        {
            object result;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
        #endregion

        #region Login and User Management
        public List<string> GetRoleNames()
        {
            var roles = new List<string>();
            string sql = "SELECT RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            DataTable dt = GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(row["RoleName"].ToString());
            }
            return roles;
        }

        public bool AuthenticateUser(string roleName, string password)
        {
            string sql = "SELECT PasswordHash FROM dbo.User_Roles WHERE RoleName = @roleName;";
            var parameters = new List<SqlParameter> { new SqlParameter("@roleName", roleName) };
            object result = ExecuteScalar(sql, parameters);
            if (result != null)
            {
                // In production, use a secure hashing library like BCrypt.Net
                // return BCrypt.Net.BCrypt.Verify(password, result.ToString());
                return password == result.ToString();
            }
            return false;
        }

        public DataTable GetUserRolesForGrid()
        {
            string sql = "SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            return GetDataTable(sql);
        }

        public bool ResetUserPassword(string roleName, string newPasswordHash)
        {
            string sql = "UPDATE dbo.User_Roles SET PasswordHash = @NewPasswordHash WHERE RoleName = @RoleName;";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@NewPasswordHash", newPasswordHash),
                new SqlParameter("@RoleName", roleName)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }
        #endregion

        #region Document Issuance
        public string GenerateNewRequestNumber()
        {
            string prefix = $"REQ-{DateTime.Now:yyyyMMdd}-";
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(RequestNo, 14, 3) AS INT)), 0) FROM dbo.Doc_Issuance WHERE RequestNo LIKE @prefix + '%';";
            var parameters = new List<SqlParameter> { new SqlParameter("@prefix", prefix) };
            object result = ExecuteScalar(sql, parameters);
            int nextSequence = 1;
            if (result != null && result != DBNull.Value)
            {
                nextSequence = Convert.ToInt32(result) + 1;
            }
            return $"{prefix}{nextSequence:D3}";
        }

        public void CreateIssuanceRequest(IssuanceRequestData data)
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
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region GM & QA Operations
        public DataTable GetGmPendingQueue()
        {
            string sql = @"
                SELECT i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction IS NULL
                ORDER BY t.RequestedAt ASC;";
            return GetDataTable(sql);
        }

        public DataTable GetQaPendingQueue()
        {
            string sql = @"
                SELECT i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.AuthorizedBy, t.GmOperationsAt AS GmActionAt
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE t.GmOperationsAction = 'Authorized' AND t.QAAction IS NULL
                ORDER BY t.GmOperationsAt ASC;";
            return GetDataTable(sql);
        }

        public DataTable GetFullRequestDetails(string requestNo)
        {
            string sql = @"
                SELECT i.*, t.RequestComment, t.GmOperationsComment
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE i.RequestNo = @RequestNo;";
            return GetDataTable(sql, new List<SqlParameter> { new SqlParameter("@RequestNo", requestNo) });
        }

        public bool UpdateGmAction(string requestNo, string action, string comment, string userName)
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
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateQaAction(string requestNo, string action, string comment, string userName)
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
            return ExecuteNonQuery(sql, parameters) > 0;
        }
        #endregion

        #region Audit Trail
        public List<int> GetAuditTrailKeys(DateTime from, DateTime to, string status, string requestNo, string product, string sortColumn, SortOrder sortOrder)
        {
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

            if (!string.IsNullOrEmpty(sortColumn))
            {
                sqlBuilder.Append($" ORDER BY {sortColumn} {(sortOrder == SortOrder.Ascending ? "ASC" : "DESC")}");
            }
            else
            {
                sqlBuilder.Append(" ORDER BY RequestDate DESC"); // Default sort
            }

            DataTable keysTable = GetDataTable(sqlBuilder.ToString(), parameters);
            return keysTable.AsEnumerable().Select(row => row.Field<int>("IssuanceID")).ToList();
        }

        public AuditTrailEntry GetAuditTrailEntry(int key)
        {
            string sql = @"
                SELECT i.RequestNo, i.RequestDate, i.Product, i.DocumentNo, t.PreparedBy, t.RequestedAt, t.RequestComment,
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
                WHERE i.IssuanceID = @Key";
            var parameters = new List<SqlParameter> { new SqlParameter("@Key", key) };
            DataTable dt = GetDataTable(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new AuditTrailEntry
                {
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
                };
            }
            return null;
        }
        #endregion
    }
}