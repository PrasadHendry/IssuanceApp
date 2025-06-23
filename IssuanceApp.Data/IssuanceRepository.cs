using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms; // Required for the SortOrder enum used in a method signature.
using Microsoft.Data.SqlClient;

namespace IssuanceApp.Data
{
    /// <summary>
    /// This is the Repository class, which acts as the application's Data Access Layer (DAL).
    /// Its sole responsibility is to handle all communication with the SQL Server database.
    /// It encapsulates all SQL queries and commands.
    ///
    /// CORRELATION:
    /// - It is instantiated and used by the UI Layer (MainForm.cs).
    /// - It uses the classes defined in DataAccessModels.cs to return structured data.
    /// - It knows nothing about the UI (e.g., it never references a TextBox or a Button).
    /// </summary>
    public class IssuanceRepository
    {
        private readonly string _connectionString;

        // The constructor receives the database connection string.
        // This is passed from MainForm, which reads it from App.config.
        public IssuanceRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Database connection string cannot be null or empty.");

            _connectionString = connectionString;
        }

        #region Generic Data Access Helpers
        // These private methods are internal tools to avoid repeating code for database operations.
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
        // Called by MainForm to populate the login dropdown.
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

        // Called by MainForm when the user clicks the Login button.
        public bool AuthenticateUser(string roleName, string password)
        {
            string sql = "SELECT PasswordHash FROM dbo.User_Roles WHERE RoleName = @roleName;";
            var parameters = new List<SqlParameter> { new SqlParameter("@roleName", roleName) };
            object result = ExecuteScalar(sql, parameters);
            if (result != null)
            {
                // In production, this should use a secure hashing library like BCrypt.Net
                // e.g., return BCrypt.Net.BCrypt.Verify(password, result.ToString());
                return password == result.ToString();
            }
            return false;
        }

        // Called by MainForm to populate the grid in the Users tab.
        public DataTable GetUserRolesForGrid()
        {
            string sql = "SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleName;";
            return GetDataTable(sql);
        }

        // Called by MainForm when an admin resets a password.
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
        // Called by MainForm to get a new, unique request number when the form loads.
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

        // Called by MainForm when the "Submit Request" button is clicked.
        // It takes the DTO from DataAccessModels.cs as its parameter.
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
        // Called by MainForm to populate the grid on the GM Operations tab.
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

        // Called by MainForm to populate the grid on the QA tab.
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

        // Called by MainForm to populate the detailed view when a request is selected in a grid.
        public DataTable GetFullRequestDetails(string requestNo)
        {
            string sql = @"
                SELECT i.*, t.RequestComment, t.GmOperationsComment
                FROM dbo.Doc_Issuance AS i
                JOIN dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
                WHERE i.RequestNo = @RequestNo;";
            return GetDataTable(sql, new List<SqlParameter> { new SqlParameter("@RequestNo", requestNo) });
        }

        // Called by MainForm when the GM Authorize or Reject button is clicked.
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

        // Called by MainForm when the QA Approve or Reject button is clicked.
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
        // Called by MainForm to get a list of primary keys for the virtual grid.
        // This is the first step of the Virtual Mode process.
        public List<int> GetAuditTrailKeys(DateTime from, DateTime to, string status, string requestNo, string product, string sortColumn, System.Windows.Forms.SortOrder sortOrder)
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

            // ** SECURITY FIX: Whitelist validation for ORDER BY clause **
            // This prevents SQL injection by ensuring only valid, safe column names can be used for sorting.
            string safeSortColumn = "RequestDate"; // Default sort column
            var validSortColumns = new List<string> { "RequestNo", "RequestDate", "Product", "DerivedStatus", "PreparedBy", "RequestedAt" };
            if (!string.IsNullOrEmpty(sortColumn) && validSortColumns.Contains(sortColumn))
            {
                safeSortColumn = sortColumn;
            }

            string sortDirection = (sortOrder == System.Windows.Forms.SortOrder.Ascending) ? "ASC" : "DESC";
            sqlBuilder.Append($" ORDER BY {safeSortColumn} {sortDirection}");

            DataTable keysTable = GetDataTable(sqlBuilder.ToString(), parameters);
            return keysTable.AsEnumerable().Select(row => row.Field<int>("IssuanceID")).ToList();
        }

        // Called by MainForm's CellValueNeeded event to get the data for a single row.
        // This is the second step of the Virtual Mode process. It's called on-demand as the user scrolls.
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