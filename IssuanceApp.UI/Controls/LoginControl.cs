using IssuanceApp.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
{
    public partial class LoginControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _osUserName;

        // Event to notify MainForm about login completion
        public event EventHandler<LoginEventArgs> LoginAttemptCompleted;

        public LoginControl()
        {
            InitializeComponent();
        }

        public async void InitializeControl(IssuanceRepository repository)
        {
            _repository = repository;
            _osUserName = GetOsUser();

            // Set initial state
            Reset();

            // Load roles
            cmbRole.Items.Clear();
            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> roleNames = await _repository.GetRoleNamesAsync();
                cmbRole.Items.AddRange(roleNames.ToArray());
                if (cmbRole.Items.Contains(AppConstants.RoleRequester)) cmbRole.SelectedItem = AppConstants.RoleRequester;
                else if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load user roles from the database.\n" + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private string GetOsUser()
        {
            try
            {
                using (var currentUser = WindowsIdentity.GetCurrent())
                {
                    string fullUserName = currentUser.Name;
                    return fullUserName.Split('\\').LastOrDefault() ?? fullUserName;
                }
            }
            catch (Exception ex)
            {
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
                    lblLoginStatus.ForeColor = Color.FromArgb(28, 184, 65); // Success color
                    txtPassword.Clear();
                }
                else
                {
                    lblLoginStatus.Text = "Invalid role or password.";
                    lblLoginStatus.ForeColor = Color.FromArgb(220, 53, 69); // Danger color
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLoginStatus.Text = "An error occurred.";
                lblLoginStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnLogin.Enabled = true;
                this.Cursor = Cursors.Default;
                // Raise the event regardless of success or failure
                LoginAttemptCompleted?.Invoke(this, new LoginEventArgs(isAuthenticated, selectedRole, _osUserName));
            }
        }

        public void Reset()
        {
            lblLoginStatus.Text = "*Please login to continue.";
            lblLoginStatus.ForeColor = SystemColors.ControlText;
            txtPassword.Clear();
            if (cmbRole.Items.Contains(AppConstants.RoleRequester))
            {
                cmbRole.SelectedItem = AppConstants.RoleRequester;
            }
            else if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
        }
    }
}