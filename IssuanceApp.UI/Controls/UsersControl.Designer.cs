// UsersControl.Designer.cs

namespace IssuanceApp.UI.Controls
{
    partial class UsersControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvUserRoles = new System.Windows.Forms.DataGridView();
            this.colUserRoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpUserRolesHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblApplicationRoles = new System.Windows.Forms.Label();
            this.btnRefreshUserRoles = new IssuanceApp.UI.RoundedButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpManageRole = new System.Windows.Forms.GroupBox();
            this.tlpManageRole = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoleNameManage = new System.Windows.Forms.Label();
            this.txtRoleNameManage = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new IssuanceApp.UI.RoundedButton();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).BeginInit();
            this.tlpUserRolesHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpManageRole.SuspendLayout();
            this.tlpManageRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.dgvUserRoles);
            this.pnlLeft.Controls.Add(this.tlpUserRolesHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(10, 10);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLeft.Size = new System.Drawing.Size(450, 561);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvUserRoles
            // 
            this.dgvUserRoles.AllowUserToAddRows = false;
            this.dgvUserRoles.AllowUserToDeleteRows = false;
            this.dgvUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserRoleId,
            this.colUserRoleName});
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvUserRoles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserRoles.Location = new System.Drawing.Point(5, 40);
            this.dgvUserRoles.MultiSelect = false;
            this.dgvUserRoles.Name = "dgvUserRoles";
            this.dgvUserRoles.ReadOnly = true;
            this.dgvUserRoles.RowHeadersWidth = 51;
            this.dgvUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserRoles.Size = new System.Drawing.Size(440, 516);
            this.dgvUserRoles.TabIndex = 0;
            // 
            // colUserRoleId
            // 
            this.colUserRoleId.DataPropertyName = "RoleID";
            this.colUserRoleId.FillWeight = 50F;
            this.colUserRoleId.HeaderText = "Role ID";
            this.colUserRoleId.Name = "colUserRoleId";
            this.colUserRoleId.ReadOnly = true;
            // 
            // colUserRoleName
            // 
            this.colUserRoleName.DataPropertyName = "RoleName";
            this.colUserRoleName.FillWeight = 150F;
            this.colUserRoleName.HeaderText = "Role Name";
            this.colUserRoleName.Name = "colUserRoleName";
            this.colUserRoleName.ReadOnly = true;
            // 
            // tlpUserRolesHeader
            // 
            this.tlpUserRolesHeader.ColumnCount = 2;
            this.tlpUserRolesHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpUserRolesHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpUserRolesHeader.Controls.Add(this.lblApplicationRoles, 0, 0);
            this.tlpUserRolesHeader.Controls.Add(this.btnRefreshUserRoles, 1, 0);
            this.tlpUserRolesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpUserRolesHeader.Location = new System.Drawing.Point(5, 5);
            this.tlpUserRolesHeader.Name = "tlpUserRolesHeader";
            this.tlpUserRolesHeader.RowCount = 1;
            this.tlpUserRolesHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpUserRolesHeader.Size = new System.Drawing.Size(440, 35);
            this.tlpUserRolesHeader.TabIndex = 2;
            // 
            // lblApplicationRoles
            // 
            this.lblApplicationRoles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblApplicationRoles.AutoSize = true;
            this.lblApplicationRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblApplicationRoles.Location = new System.Drawing.Point(3, 8);
            this.lblApplicationRoles.Name = "lblApplicationRoles";
            this.lblApplicationRoles.Size = new System.Drawing.Size(119, 19);
            this.lblApplicationRoles.TabIndex = 0;
            this.lblApplicationRoles.Text = "Application Roles";
            // 
            // btnRefreshUserRoles
            // 
            this.btnRefreshUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshUserRoles.CornerRadius = 8;
            this.btnRefreshUserRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUserRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRefreshUserRoles.Location = new System.Drawing.Point(322, 3);
            this.btnRefreshUserRoles.Name = "btnRefreshUserRoles";
            this.btnRefreshUserRoles.Size = new System.Drawing.Size(115, 29);
            this.btnRefreshUserRoles.TabIndex = 1;
            this.btnRefreshUserRoles.Text = "Refresh List";
            this.btnRefreshUserRoles.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpManageRole);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(460, 10);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(843, 561);
            this.pnlRight.TabIndex = 1;
            // 
            // grpManageRole
            // 
            this.grpManageRole.Controls.Add(this.tlpManageRole);
            this.grpManageRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManageRole.Location = new System.Drawing.Point(5, 5);
            this.grpManageRole.Name = "grpManageRole";
            this.grpManageRole.Padding = new System.Windows.Forms.Padding(10);
            this.grpManageRole.Size = new System.Drawing.Size(833, 551);
            this.grpManageRole.TabIndex = 0;
            this.grpManageRole.TabStop = false;
            this.grpManageRole.Text = "Manage Role";
            // 
            // tlpManageRole
            // 
            this.tlpManageRole.ColumnCount = 2;
            this.tlpManageRole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpManageRole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpManageRole.Controls.Add(this.lblRoleNameManage, 0, 0);
            this.tlpManageRole.Controls.Add(this.txtRoleNameManage, 1, 0);
            this.tlpManageRole.Controls.Add(this.btnResetPassword, 0, 1);
            this.tlpManageRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpManageRole.Location = new System.Drawing.Point(10, 28);
            this.tlpManageRole.Name = "tlpManageRole";
            this.tlpManageRole.RowCount = 2;
            this.tlpManageRole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpManageRole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpManageRole.Size = new System.Drawing.Size(813, 80);
            this.tlpManageRole.TabIndex = 0;
            // 
            // lblRoleNameManage
            // 
            this.lblRoleNameManage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRoleNameManage.AutoSize = true;
            this.lblRoleNameManage.Location = new System.Drawing.Point(3, 9);
            this.lblRoleNameManage.Name = "lblRoleNameManage";
            this.lblRoleNameManage.Size = new System.Drawing.Size(77, 17);
            this.lblRoleNameManage.TabIndex = 0;
            this.lblRoleNameManage.Text = "Role Name:";
            // 
            // txtRoleNameManage
            // 
            this.txtRoleNameManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoleNameManage.Location = new System.Drawing.Point(86, 5);
            this.txtRoleNameManage.Name = "txtRoleNameManage";
            this.txtRoleNameManage.ReadOnly = true;
            this.txtRoleNameManage.Size = new System.Drawing.Size(724, 25);
            this.txtRoleNameManage.TabIndex = 1;
            // 
            // btnResetPassword
            // 
            this.tlpManageRole.SetColumnSpan(this.btnResetPassword, 2);
            this.btnResetPassword.CornerRadius = 8;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.Location = new System.Drawing.Point(3, 38);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(140, 35);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Name = "UsersControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1313, 581);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).EndInit();
            this.tlpUserRolesHeader.ResumeLayout(false);
            this.tlpUserRolesHeader.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grpManageRole.ResumeLayout(false);
            this.tlpManageRole.ResumeLayout(false);
            this.tlpManageRole.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRoleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRoleName;
        private System.Windows.Forms.TableLayoutPanel tlpUserRolesHeader;
        private System.Windows.Forms.Label lblApplicationRoles;
        private UI.RoundedButton btnRefreshUserRoles;
        private System.Windows.Forms.GroupBox grpManageRole;
        private System.Windows.Forms.TableLayoutPanel tlpManageRole;
        private System.Windows.Forms.Label lblRoleNameManage;
        private System.Windows.Forms.TextBox txtRoleNameManage;
        private UI.RoundedButton btnResetPassword;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
    }
}