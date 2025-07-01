// LoginEventArgs.cs

using System;

namespace IssuanceApp.UI.Controls
{
    public class LoginEventArgs : EventArgs
    {
        public bool IsAuthenticated { get; }
        public string Role { get; }
        public string UserName { get; }

        public LoginEventArgs(bool isAuthenticated, string role, string userName)
        {
            IsAuthenticated = isAuthenticated;
            Role = role;
            UserName = userName;
        }
    }
}