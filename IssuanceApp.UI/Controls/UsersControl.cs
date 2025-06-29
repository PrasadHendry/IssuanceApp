// IssuanceApp.UI/Controls/UsersControl.cs

using DocumentIssuanceApp; // Add this using statement
using IssuanceApp.Data;
using System;
using System.Data;
using System.Threading.Tasks; // Add this for Task
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
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
            dgvUserRoles.AutoGenerateColumns = false;
            dgvUserRoles.Columns["colUserRoleId"].DataPropertyName = "RoleID";
            dgvUserRoles.Columns["colUserRoleName"].DataPropertyName = "RoleName";
            dgvUserRoles.DataSource = _userRolesBindingSource;
            dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            btnRefreshUserRoles.Click += async (s, e) => await LoadUserRolesAsync();
            btnResetPassword.Click += BtnResetPassword_Click;
        }

        // CORRECTED: Changed from async void to async Task
        public async Task LoadUserRolesAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            btnRefreshUserRoles.Enabled = false;
            try
            {
                _userRolesBindingSource.DataSource = await _repository.GetUserRolesForGridAsync();
                dgvUserRoles.ClearSelection();
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
            btnResetPassword.Enabled = isRowSelected;
            txtRoleNameManage.Text = isRowSelected
                ? Convert.ToString((dgvUserRoles.SelectedRows[0].DataBoundItem as DataRowView)?["RoleName"])
                : string.Empty;
        }

        private async void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role from the list.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string roleName = txtRoleNameManage.Text;
            if (MessageBox.Show($"Are you sure you want to reset the password for the '{roleName}' role?", "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newPassword = "Password123";
                string newPasswordHash = newPassword; // Replace with: BCrypt.Net.BCrypt.HashPassword(newPassword);

                btnResetPassword.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (await _repository.ResetUserPasswordAsync(roleName, newPasswordHash))
                    {
                        MessageBox.Show($"Password for role '{roleName}' has been reset.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvUserRoles.ClearSelection();
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
                }
            }
        }
    }
}