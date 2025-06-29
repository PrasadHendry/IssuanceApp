using System;

namespace IssuanceApp.Data
{
    /// <summary>
    /// This file contains the Plain Old C# Objects (POCOs) or Data Transfer Objects (DTOs).
    /// Their purpose is to define a clear, strongly-typed structure for data that is passed
    /// between the UI layer (MainForm.cs) and the Data layer (IssuanceRepository.cs).
    /// They do not contain any logic, only properties.
    /// </summary>

    // Represents a user role from the database.
    // Used by IssuanceRepository to fetch roles and by MainForm to display them in the Users tab grid.
    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    // Represents a single, complete record for the Audit Trail.
    // This class combines data from both the Doc_Issuance and Issuance_Tracker tables.
    // It's used by the Virtual Mode of the Audit Trail grid in MainForm.
    // The IssuanceRepository populates this object, and the MainForm's CellValueNeeded event reads from it.
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
    }

    // A Data Transfer Object (DTO) used to pass all the necessary information
    // for creating a new issuance request from the UI (MainForm) to the Data Layer (IssuanceRepository).
    // This avoids having a method with a very long list of parameters.
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
    public class PendingRequestSummary
    {
        public string RequestNo { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product { get; set; }
        public string DocumentNo { get; set; }
        public string PreparedBy { get; set; }
        public DateTime RequestedAt { get; set; }

        // QA-specific fields (will be null for GM queue)
        public string AuthorizedBy { get; set; }
        public DateTime? GmActionAt { get; set; }
    }
}