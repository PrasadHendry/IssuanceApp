// PasswordInputDialog.cs

using System;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    public partial class PasswordInputDialog : Form
    {
        public string NewPassword { get; private set; }

        public PasswordInputDialog()
        {
            InitializeComponent();
            ThemeManager.StyleSuccessButton(btnOk);
            ThemeManager.StyleSecondaryButton(btnCancel);
        }

        public PasswordInputDialog(string roleName) : this()
        {
            this.Text = $"Reset Password for '{roleName}'";
            // --- FIX: This line connects the OK button to its click-handling code ---
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("New Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return;
            }

            this.NewPassword = txtNewPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // This handler is already correctly wired by the designer for the Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}