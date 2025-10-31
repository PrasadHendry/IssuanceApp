// DataAccessModels.cs

using System;

namespace IssuanceApp.Data
{
    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class AuditTrailEntry
    {
        public int IssuanceID { get; set; }
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNo { get; set; }
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
        // --- ADDED ---
        public string ParentBatchNumber { get; set; }
        public string ParentBatchSize { get; set; }
        public string ParentMfgDate { get; set; }
        public string ParentExpDate { get; set; }
        public string FromDepartment { get; set; }
    }

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

    public class GmQueueItemDto
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNo { get; set; }
        public string PreparedBy { get; set; }
        public DateTime RequestedAt { get; set; }
        public string FromDepartment { get; set; }
        public string BatchNo { get; set; }
        public string ItemMfgDate { get; set; }
        public string ItemExpDate { get; set; }
        public string Market { get; set; }
        public string PackSize { get; set; }
        public string RequestComment { get; set; }
        // --- ADDED ---
        public string ParentBatchNumber { get; set; }
        public string ParentBatchSize { get; set; }
        public string ParentMfgDate { get; set; }
        public string ParentExpDate { get; set; }
    }

    public class QaQueueItemDto
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNo { get; set; }
        public string PreparedBy { get; set; }
        public DateTime RequestedAt { get; set; }
        public string AuthorizedBy { get; set; }
        public DateTime GmOperationsAt { get; set; }
        public string GmOperationsComment { get; set; }
        public string FromDepartment { get; set; }
        public string BatchNo { get; set; }
        public string ItemMfgDate { get; set; }
        public string ItemExpDate { get; set; }
        public string Market { get; set; }
        public string PackSize { get; set; }
        public string RequestComment { get; set; }
        // --- ADDED FOR STAMPING CONTEXT ---
        public string GmOperationsAction { get; set; } // Needed for worker to derive status if needed
        public string QAAction { get; set; } // Set by QaControl before serialization
        public string ApprovedBy { get; set; } // Set by QaControl before serialization
        // --- END ADDED FOR STAMPING CONTEXT ---
        // --- ADDED ---
        public string ParentBatchNumber { get; set; }
        public string ParentBatchSize { get; set; }
        public string ParentMfgDate { get; set; }
        public string ParentExpDate { get; set; }
    }
}