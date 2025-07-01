// IssuanceApp.UI/Controls/UsersControl.cs

using DocumentIssuanceApp.Controls;
using IssuanceApp.Data;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net; // This is the correct using statement for BCrypt.Net-Next

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
            SetupUserRolesColumns();
            dgvUserRoles.DataSource = _userRolesBindingSource;
            dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            btnRefreshUserRoles.Click += async (s, e) => await LoadUserRolesAsync();
            btnResetPassword.Click += BtnResetPassword_Click;
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
            btnResetPassword.Enabled = isRowSelected;

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
            if (dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role from the list.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string roleName = txtRoleNameManage.Text;
            if (MessageBox.Show($"Are you sure you want to reset the password for the '{roleName}' role?", "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newPassword = "Password123";
                // This is the correct call syntax for the library
                string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

                btnResetPassword.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (await _repository.ResetUserPasswordAsync(roleName, newPasswordHash))
                    {
                        MessageBox.Show($"Password for role '{roleName}' has been reset to:\n\n{newPassword}\n\nPlease inform the user.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
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