// DataAccessModels.cs

using System;

namespace IssuanceApp.Data
{
    /// <summary>
    /// This file contains the Plain Old C# Objects (POCOs) or Data Transfer Objects (DTOs).
    /// Their purpose is to define a clear, strongly-typed structure for data that is passed
    /// between the UI layer and the Data layer.
    /// They do not contain any logic, only properties.
    /// </summary>

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

        // REMOVED: The PrintCount property has been deleted from this model.
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

    /// <summary>
    /// DTO for the items displayed in the GM Operations Queue.
    /// Contains all necessary details to avoid follow-up database calls.
    /// </summary>
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
    }

    /// <summary>
    /// DTO for the items displayed in the QA Approval Queue.
    /// Contains all necessary details to avoid follow-up database calls.
    /// </summary>
    public class QaQueueItemDto
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNo { get; set; }
        public string PreparedBy { get; set; }
        public DateTime RequestedAt { get; set; }
        public string AuthorizedBy { get; set; }
        public DateTime GmActionAt { get; set; }
        public string FromDepartment { get; set; }
        public string BatchNo { get; set; }
        public string ItemMfgDate { get; set; }
        public string ItemExpDate { get; set; }
        public string Market { get; set; }
        public string PackSize { get; set; }
        public string RequestComment { get; set; }
        public string GmOperationsComment { get; set; }
    }
}