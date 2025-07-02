// UsersControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    public partial class UsersControl : UserControl
    {
        private IssuanceRepository _repository;
        private BindingSource _userRolesBindingSource;

        public UsersControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnRefreshUserRoles);
            ThemeManager.StylePrimaryButton(btnResetPassword);
            ThemeManager.StyleDataGridView(dgvUserRoles);
        }

        public void InitializeControl(IssuanceRepository repository)
        {
            _repository = repository;
            _userRolesBindingSource = new BindingSource();
            SetupUserRolesColumns();
            dgvUserRoles.DataSource = _userRolesBindingSource;
            dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            btnRefreshUserRoles.Click += async (s, e) => await LoadUserRolesAsync();
            btnResetPassword.Click += BtnResetPassword_Click;

            // Initial state: disable the manage role section
            grpManageRole.Enabled = false;
        }

        private void SetupUserRolesColumns()
        {
            dgvUserRoles.AutoGenerateColumns = false;
            dgvUserRoles.Columns.Clear();
            dgvUserRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUserRoles.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserRoleId", DataPropertyName = nameof(UserRole.RoleID), HeaderText = "Role ID", FillWeight = 25 });
            dgvUserRoles.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUserRoleName", DataPropertyName = nameof(UserRole.RoleName), HeaderText = "Role Name", FillWeight = 75 });
        }

        public async Task LoadUserRolesAsync()
        {
            if (_repository == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnRefreshUserRoles.Enabled = false;
            try
            {
                _userRolesBindingSource.DataSource = await _repository.GetUserRolesForGridAsync();
                dgvUserRoles.ClearSelection();
                // Trigger selection changed logic to update UI state
                DgvUserRoles_SelectionChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnRefreshUserRoles.Enabled = true;
            }
        }

        private void DgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
            bool isRowSelected = dgvUserRoles.SelectedRows.Count > 0;

            // UX IMPROVEMENT: Enable/disable the entire group box when a role is selected
            grpManageRole.Enabled = isRowSelected;

            if (isRowSelected)
            {
                var selectedRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
                txtRoleNameManage.Text = selectedRole?.RoleName ?? string.Empty;
            }
            else
            {
                txtRoleNameManage.Text = string.Empty;
            }

            // Reset password text when selection changes (not strictly necessary 
            // since it's in a dialog now, but good practice)
            // txtNewPassword.Clear(); // Removed as per dialog implementation
        }

        private async void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles.SelectedRows.Count == 0) return;

            string roleName = txtRoleNameManage.Text;

            // FEATURE IMPLEMENTATION: Use a dialog to get the new password
            using (var passwordDialog = new PasswordInputDialog(roleName))
            {
                // Show the dialog modally. Pass 'this' to center the dialog over the control.
                if (passwordDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string newPassword = passwordDialog.NewPassword;
                    // In a real application, you would hash the password here before sending it to the repository.
                    string newPasswordForDb = newPassword;

                    // Proceed with reset confirmation *after* getting the password
                    if (MessageBox.Show($"Are you sure you want to reset the password for the '{roleName}' role?", "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnResetPassword.Enabled = false; // Disable only the reset button during the async operation
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            if (await _repository.ResetUserPasswordAsync(roleName, newPasswordForDb))
                            {
                                MessageBox.Show($"Password for role '{roleName}' has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // No need to clear selection here, the UI updates when the grid is refreshed
                                // dgvUserRoles.ClearSelection(); // Removed
                            }
                            else
                                MessageBox.Show("Failed to reset password. The role may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while resetting the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            btnResetPassword.Enabled = true;
                            this.Cursor = Cursors.Default;
                            // Re-apply enabled state based on selection status after async op
                            DgvUserRoles_SelectionChanged(null, EventArgs.Empty);
                        }
                    }
                }
                // If DialogResult is not OK (e.g., Cancel), the code simply exits the 'if' block
            }
        }
    }
}