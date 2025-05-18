using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IssuanceApp.Data
{
    public class Class1
    {
    }

    // Define a concrete class for Audit Trail entries
    public class AuditTrailEntry
    {
        public string RequestNo { get; set; }
        public DateTime? RequestDate { get; set; } // Use Nullable DateTime
        public string Product { get; set; }
        public string DocumentTypes { get; set; }
        public string DerivedStatus { get; set; }
        public string PreparedBy { get; set; }
        public DateTime? RequestedAt { get; set; } // Use Nullable DateTime
        public string GmOperationsAction { get; set; }
        public string AuthorizedBy { get; set; } // GM User
        public DateTime? GmOperationsAt { get; set; } // Use Nullable DateTime
        public string GmOperationsComment { get; set; }
        public string QAAction { get; set; }
        public string ApprovedBy { get; set; } // QA User
        public DateTime? QAAt { get; set; } // Use Nullable DateTime
        public string QAComment { get; set; }
        // Add any other properties from Doc_Issuance that you might want to display
        public string FromDepartment { get; set; }
        public string BatchNo { get; set; }
        // ... etc.
    }
}
