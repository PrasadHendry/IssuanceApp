// MainForm.cs
// This is the main code-behind file for your application's main window.

using System;
using System.Windows.Forms;
using System.Security.Principal; // Required for WindowsIdentity

namespace DocumentIssuanceApp
{
    public partial class MainForm : Form
    {
        // Timer for updating the status bar clock
        private Timer statusTimer;

        public MainForm()
        {
            InitializeComponent(); // This method is typically in MainForm.Designer.cs
            InitializeCustomComponents(); // Custom initializations
            SetupStatusBar();
            SetupTabs(); // Method to potentially customize tabs further if needed
        }

        private void InitializeCustomComponents()
        {
            // Set the main window title
            this.Text = "Document Issuance System";

            // Configure and start the timer for the status bar
            statusTimer = new Timer();
            statusTimer.Interval = 1000; // Update every second
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
        }

        private void SetupStatusBar()
        {
            // Get current Windows user
            string userName = "Unknown User";
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                if (currentUser != null && currentUser.Name != null)
                {
                    userName = currentUser.Name;
                }
            }
            catch (System.Security.SecurityException)
            {
                // Handle cases where user name cannot be retrieved (e.g., permissions)
                userName = "N/A (Permission Denied)";
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
                userName = $"Error: {ex.Message.Substring(0, Math.Min(ex.Message.Length, 20))}"; // Show a short error
            }


            // Set initial status bar text
            toolStripStatusLabelUser.Text = $"User: {userName}";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            // Ensure the DateTime label aligns to the right
            // This is often better handled by adding a Spring label before it,
            // or by setting the Alignment property if available directly.
            // For StatusStrip, a Spring ToolStripLabel can push subsequent items to the right.
            // This is typically done in the designer, but can be done in code:
            // toolStripStatusLabelSpring.Spring = true; // Assuming toolStripStatusLabelSpring is added before DateTime
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            // Update the date and time in the status bar
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void SetupTabs()
        {
            // You can add further tab customization here if needed,
            // for example, dynamically enabling/disabling tabs based on user roles.
            // For now, we assume all tabs are created in the designer.

            // Example: Conditionally hide the "Users" tab if the user is not an admin
            // This would require a proper role check mechanism.
            // bool isAdmin = CheckIfUserIsAdmin(); // Placeholder for admin check logic
            // if (!isAdmin)
            // {
            //     if (tabControlMain.TabPages.ContainsKey("tabPageUsers"))
            //     {
            //          // tabPageUsers.Enabled = false; // Disables the tab
            //          // OR to remove it:
            //          // tabControlMain.TabPages.RemoveByKey("tabPageUsers");
            //     }
            // }
        }

        // Placeholder for a method to check user roles (implement as needed)
        // private bool CheckIfUserIsAdmin()
        // {
        //     // Implement your logic to determine if the current user is an administrator
        //     // This might involve checking Windows groups, a database lookup, etc.
        //     // For example:
        //     // WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        //     // return principal.IsInRole(WindowsBuiltInRole.Administrator) || principal.IsInRole("Your_Admin_Group_Name");
        //     return true; // Default to true for now
        // }

        // Ensure the timer is disposed when the form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}