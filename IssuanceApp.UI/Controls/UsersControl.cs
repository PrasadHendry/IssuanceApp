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
            dgvUserRoles.DataSource = _userRolesBindingSource;
            dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            btnRefreshUserRoles.Click += async (s, e) => await LoadUserRolesAsync();
            btnResetPassword.Click += BtnResetPassword_Click;

            grpManageRole.Enabled = false;
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
        }

        private async void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles.SelectedRows.Count == 0) return;

            string roleName = txtRoleNameManage.Text;

            using (var passwordDialog = new PasswordInputDialog(roleName))
            {
                if (passwordDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string newPassword = passwordDialog.NewPassword;
                    string newPasswordForDb = newPassword;

                    if (MessageBox.Show($"Are you sure you want to reset the password for the '{roleName}' role?", "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnResetPassword.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            if (await _repository.ResetUserPasswordAsync(roleName, newPasswordForDb))
                            {
                                MessageBox.Show($"Password for role '{roleName}' has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            DgvUserRoles_SelectionChanged(null, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }
}