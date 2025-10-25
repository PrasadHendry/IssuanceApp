// LoginControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    public partial class LoginControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _osUserName;

        public event EventHandler<LoginEventArgs> LoginAttemptCompleted;

        public LoginControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnLogin);
        }

        public async void InitializeControl(IssuanceRepository repository)
        {
            _repository = repository;
            _osUserName = GetOsUser();
            Reset();

            cmbRole.Items.Clear();
            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Await the task where the database call and detailed error handling occurs
                await LoadRolesFromDatabaseAsync();
            }
            catch (Exception)
            {
                // Catching the exception here but relying on LoadRolesFromDatabaseAsync
                // to have already shown the user a detailed error message.
            }
            finally
            {
                this.Cursor = Cursors.Default;
                // Only enable the button if roles were successfully loaded
                btnLogin.Enabled = cmbRole.Items.Count > 0;
            }
        }

        /// <summary>
        /// Loads user roles from the database asynchronously with explicit error reporting on the UI thread.
        /// </summary>
        private async Task LoadRolesFromDatabaseAsync()
        {
            try
            {
                List<string> roleNames = await _repository.GetRoleNamesAsync();

                if (this.IsDisposed) return; // Guard against control disposal

                cmbRole.Items.AddRange(roleNames.ToArray());
                SetDefaultRole(); // Set default selection if roles were loaded
            }
            catch (Exception ex)
            {
                if (this.IsDisposed) return;

                // CRITICAL ERROR: Database connection failed during role load.
                string errorMessage = "Could not load user roles from the database. Please check the connection string and database availability.\n\nDetails: " + ex.Message;

                // Use Invoke to ensure the MessageBox and UI updates happen safely on the UI thread
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(errorMessage, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    // Update UI state to reflect failure
                    btnLogin.Enabled = false;
                    lblLoginStatus.Text = "Database connection failed.";
                    lblLoginStatus.ForeColor = Color.Red;
                }));

                // Re-throw the exception to satisfy the outer try-catch for logging/tracing (optional but good practice)
                throw;
            }
        }

        // REFINEMENT: Switched to Environment.UserName for a more direct way to get the username without the domain.
        private string GetOsUser()
        {
            try
            {
                return Environment.UserName;
            }
            catch (Exception ex)
            {
                // It's good practice to log this, even if just to the console for debugging.
                Console.WriteLine("Error getting OS username: " + ex.Message);
                return "Unknown User";
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem?.ToString();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(selectedRole) || string.IsNullOrEmpty(password))
            {
                lblLoginStatus.Text = "Please select a role and enter the password.";
                lblLoginStatus.ForeColor = Color.Red;
                return;
            }

            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblLoginStatus.Text = "Authenticating...";
            lblLoginStatus.ForeColor = SystemColors.ControlText;

            bool isAuthenticated = false;
            try
            {
                isAuthenticated = await _repository.AuthenticateUserAsync(selectedRole, password);
                if (isAuthenticated)
                {
                    lblLoginStatus.Text = $"Login successful as {selectedRole}.";
                    lblLoginStatus.ForeColor = ThemeManager.SuccessColor;
                    txtPassword.Clear();
                }
                else
                {
                    lblLoginStatus.Text = "Invalid role or password.";
                    lblLoginStatus.ForeColor = ThemeManager.DangerColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLoginStatus.Text = "An authentication error occurred.";
                lblLoginStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnLogin.Enabled = true;
                this.Cursor = Cursors.Default;
                LoginAttemptCompleted?.Invoke(this, new LoginEventArgs(isAuthenticated, selectedRole, _osUserName));
            }
        }

        public void Reset()
        {
            lblLoginStatus.Text = "*Please login to continue.";
            lblLoginStatus.ForeColor = SystemColors.ControlText;
            txtPassword.Clear();
            SetDefaultRole(); // REFINEMENT: Call helper method to set default selection.
        }

        // REFINEMENT: New helper method to avoid duplicating this logic in InitializeControl and Reset.
        private void SetDefaultRole()
        {
            if (cmbRole.Items.Count > 0)
            {
                if (cmbRole.Items.Contains(AppConstants.RoleRequester))
                {
                    cmbRole.SelectedItem = AppConstants.RoleRequester;
                }
                else
                {
                    cmbRole.SelectedIndex = 0;
                }
            }
        }
    }
}