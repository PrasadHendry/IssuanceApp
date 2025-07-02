// PasswordInputDialog.cs

using System;
using System.Windows.Forms;

// Correct namespace to match where the form is created (UsersControl.cs)
namespace IssuanceApp.UI.Controls
{
    public partial class PasswordInputDialog : Form
    {
        /// <summary>
        /// Gets the new password entered by the user.
        /// Only valid if DialogResult is OK.
        /// </summary>
        public string NewPassword { get; private set; }

        // Default constructor needed for the designer
        public PasswordInputDialog()
        {
            InitializeComponent();
            // Apply styling using the centralized ThemeManager
            ThemeManager.StyleSuccessButton(btnOk);
            ThemeManager.StyleSecondaryButton(btnCancel);
        }

        /// <summary>
        /// Initializes a new instance of the PasswordInputDialog form.
        /// </summary>
        /// <param name="roleName">The name of the role for which the password is being reset.</param>
        public PasswordInputDialog(string roleName) : this() // Call the default constructor
        {
            // Customize the form title based on the role name
            this.Text = $"Reset Password for '{roleName}'";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("New Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Confirm Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus(); // Focus confirm password field
                txtConfirmPassword.SelectAll(); // Select text for easy correction
                return;
            }

            // If validation passes, set the public property and DialogResult
            this.NewPassword = txtNewPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close(); // Close the dialog
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Set DialogResult to Cancel and close the form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}