using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssuanceApp.Data
{

    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        // Add PasswordHash if needed here, or manage separately
    }

    public class AuditTrailEntry
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNumbers { get; set; } // Comma-separated doc numbers
        public string DerivedStatus { get; set; } // e.g., "Pending GM", "Approved"
        public string PreparedBy { get; set; }
        public DateTime? RequestedAt { get; set; }
        public string GmOperationsAction { get; set; } // "Authorized", "Rejected"
        public string AuthorizedBy { get; set; } // GM User
        public DateTime? GmOperationsAt { get; set; }
        public string GmOperationsComment { get; set; }
        public string QAAction { get; set; } // "Approved", "Rejected"
        public string ApprovedBy { get; set; } // QA User
        public DateTime? QAAt { get; set; }
        public string QAComment { get; set; }
        // ... add other fields from Doc_Issuance as needed for audit ...
        public string FromDepartment { get; set; }
        public string ParentBatchNumber { get; set; }
        public string ParentBatchSize { get; set; }
        public string ParentMfgDate { get; set; }
        public string ParentExpDate { get; set; }
        public string BatchNo { get; set; }
        public string BatchSize { get; set; }
        public string ItemMfgDate { get; set; }
        public string ItemExpDate { get; set; }
        public string Market { get; set; }
        public string PackSize { get; set; }
        public string ExportOrderNo { get; set; }

    }
}
