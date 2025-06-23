using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuanceApp.Data
{
    // Represents a user role from the database
    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    // Represents a full audit trail record for the virtual grid
    public class AuditTrailEntry
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNumbers { get; set; }
        public string DerivedStatus { get; set; }
        public string PreparedBy { get; set; }
        public DateTime? RequestedAt { get; set; }
        public string GmOperationsAction { get; set; }
        public string AuthorizedBy { get; set; }
        public DateTime? GmOperationsAt { get; set; }
        public string GmOperationsComment { get; set; }
        public string QAAction { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? QAAt { get; set; }
        public string QAComment { get; set; }
    }

    // A Data Transfer Object (DTO) for creating a new issuance request
    public class IssuanceRequestData
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string FromDepartment { get; set; }
        public string DocumentNo { get; set; }
        public string Product { get; set; }
        public string BatchNo { get; set; }
        public string BatchSize { get; set; }
        public string PreparedBy { get; set; }
        public string ParentBatchNumber { get; set; }
        public string ParentBatchSize { get; set; }
        public string ParentMfgDate { get; set; }
        public string ParentExpDate { get; set; }
        public string ItemMfgDate { get; set; }
        public string ItemExpDate { get; set; }
        public string Market { get; set; }
        public string PackSize { get; set; }
        public string ExportOrderNo { get; set; }
        public string RequestComment { get; set; }
    }
}
