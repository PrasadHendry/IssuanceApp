﻿// --- Place this class in a new file "AppConstants.cs" inside the IssuanceApp.Data project ---
namespace IssuanceApp.Data
{
    /// <summary>
    /// Centralizes application-wide business logic constants.
    /// </summary>
    public static class AppConstants
    {
        // User Roles
        public const string RoleRequester = "Requester";
        public const string RoleGmOperations = "GM_Operations";
        public const string RoleQA = "QA";
        public const string RoleAdmin = "Admin";

        // Workflow Actions
        public const string ActionAuthorized = "Authorized";
        public const string ActionRejected = "Rejected";
        public const string ActionApproved = "Approved";
    }
}