// MainForm.cs (Code-behind with Enhanced Font Scaling)
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal; // Required for WindowsIdentity

namespace DocumentIssuanceApp
{
    public partial class MainForm : Form
    {
        private Timer statusTimer;
        private string loggedInRole = null;

        // Fields for font and control scaling
        private SizeF _originalFormSize; // Stores the form's client size before initial maximization
        private Font _originalFormFont; // Stores the form's original font
        private Size _originalPanelLoginContainerSize; // Stores the panel's original size
        private Font _originalPanelLoginContainerFont; // Stores the panel's original font
        private Font _originalTabControlFont; // Stores the TabControl's original font (for tab headers)

        private bool _initialScalingDone = false; // Flag to ensure scaling happens only once on initial maximize

        // Constants for scaling limits
        private const float MinFontSize = 8f;    // Minimum allowable font size after scaling
        private const float MaxFontSize = 18f;   // Maximum allowable font size after scaling
        private const int MinPanelWidth = 200;   // Minimum width for the login panel
        private const int MinPanelHeight = 150;  // Minimum height for the login panel


        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            SetupStatusBar();
            InitializeLoginTab();
            SetupTabs();

            this.Load += MainForm_Load_ForScaling;
            // Setting AutoScaleMode to Font helps in automatic scaling of controls based on font changes.
            // However, explicit font settings in the designer can override this for specific controls.
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Resize += MainForm_Resize_ForScaling;
        }

        private void MainForm_Load_ForScaling(object sender, EventArgs e)
        {
            // Store initial sizes and fonts BEFORE maximizing. These are the "base" values.
            _originalFormSize = this.ClientSize;
            _originalFormFont = this.Font; // Store the entire Font object for the form

            if (tabControlMain != null)
            {
                _originalTabControlFont = tabControlMain.Font; // Store TabControl's font
            }

            if (panelLoginContainer != null)
            {
                _originalPanelLoginContainerSize = panelLoginContainer.Size;
                _originalPanelLoginContainerFont = panelLoginContainer.Font; // Store Panel's font
            }

            CenterLoginPanel(); // Initial centering based on design-time sizes

            // Maximize the window on load. This will trigger the initial scaling logic
            // in the MainForm_Resize_ForScaling event if the WindowState changes to Maximized.
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Document Issuance System";
            statusTimer = new Timer();
            statusTimer.Interval = 1000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
            this.tabPageLogin.Resize += TabPageLogin_Resize; // For re-centering login panel
        }

        private void SetupStatusBar()
        {
            string userName = "Unknown User";
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                if (currentUser != null && currentUser.Name != null)
                {
                    userName = currentUser.Name;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting username: " + ex.Message);
                // Handle appropriately, e.g., log the error
            }
            toolStripStatusLabelUser.Text = $"User: {userName}";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void InitializeLoginTab()
        {
            cmbRole.Items.AddRange(new object[] { "Requester", "GM_Operations", "QA", "Admin" });
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            txtPassword.PasswordChar = '*';
            btnLogin.Click += BtnLogin_Click;
            EnableTabsBasedOnRole(null); // Initial state: only login tab enabled
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem?.ToString();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(selectedRole) || string.IsNullOrEmpty(password))
            {
                lblLoginStatus.Text = "Please select a role and enter the password.";
                lblLoginStatus.ForeColor = Color.Red;
                return;
            }

            bool isAuthenticated = AuthenticateUser(selectedRole, password);

            if (isAuthenticated)
            {
                loggedInRole = selectedRole;
                lblLoginStatus.Text = $"Login successful as {loggedInRole}.";
                lblLoginStatus.ForeColor = Color.Green;
                txtPassword.Clear(); // Clear password after successful login
                EnableTabsBasedOnRole(loggedInRole);
                SwitchToDefaultTabForRole(loggedInRole);
            }
            else
            {
                lblLoginStatus.Text = "Invalid role or password.";
                lblLoginStatus.ForeColor = Color.Red;
                loggedInRole = null;
                EnableTabsBasedOnRole(null); // Revert to login tab if authentication fails
            }
        }

        private bool AuthenticateUser(string roleName, string password)
        {
            // IMPORTANT: Replace with a secure authentication mechanism (e.g., hashed passwords from a database)
            if (roleName == "Requester" && password == "test") return true;
            if (roleName == "GM_Operations" && password == "test1") return true;
            if (roleName == "QA" && password == "test2") return true;
            if (roleName == "Admin" && password == "adminpass") return true;
            return false;
        }

        private void EnableTabsBasedOnRole(string role)
        {
            // Disable all tabs except Login initially or if no role
            tabPageDocumentIssuance.Enabled = false;
            tabPageGmOperations.Enabled = false;
            tabPageQa.Enabled = false;
            tabPageAuditTrail.Enabled = false;
            tabPageUsers.Enabled = false;
            tabPageLogin.Enabled = true; // Login tab is always enabled conceptually

            if (string.IsNullOrEmpty(role))
            {
                tabControlMain.SelectedTab = tabPageLogin; // Default to login tab
                return;
            }

            // Enable tabs based on the logged-in role
            tabPageAuditTrail.Enabled = true; // Assuming Audit Trail is common for logged-in users

            switch (role)
            {
                case "Requester":
                    tabPageDocumentIssuance.Enabled = true;
                    break;
                case "GM_Operations":
                    tabPageGmOperations.Enabled = true;
                    break;
                case "QA":
                    tabPageQa.Enabled = true;
                    break;
                case "Admin":
                    tabPageDocumentIssuance.Enabled = true;
                    tabPageGmOperations.Enabled = true;
                    tabPageQa.Enabled = true;
                    tabPageUsers.Enabled = true;
                    break;
            }
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            switch (role)
            {
                case "Requester": tabControlMain.SelectedTab = tabPageDocumentIssuance; break;
                case "GM_Operations": tabControlMain.SelectedTab = tabPageGmOperations; break;
                case "QA": tabControlMain.SelectedTab = tabPageQa; break;
                case "Admin": tabControlMain.SelectedTab = tabPageUsers; break;
                default: tabControlMain.SelectedTab = tabPageLogin; break; // Fallback to login tab
            }
        }

        private void SetupTabs()
        {
            // Initial tab setup is handled by EnableTabsBasedOnRole(null) in InitializeLoginTab
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void TabPageLogin_Resize(object sender, EventArgs e)
        {
            // Re-center the login panel whenever the login tab page itself is resized.
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            if (panelLoginContainer != null && tabPageLogin != null && panelLoginContainer.Parent == tabPageLogin)
            {
                // Calculate coordinates to center the panel within the tab page's client area
                int panelX = (tabPageLogin.ClientSize.Width - panelLoginContainer.Width) / 2;
                int panelY = (tabPageLogin.ClientSize.Height - panelLoginContainer.Height) / 2;
                panelLoginContainer.Location = new Point(Math.Max(0, panelX), Math.Max(0, panelY)); // Ensure non-negative location
            }
        }

        private void MainForm_Resize_ForScaling(object sender, EventArgs e)
        {
            // This method performs scaling ONCE when the form is first maximized.
            // If continuous scaling on every resize is needed, the '_initialScalingDone' check
            // and possibly the 'WindowState' check would need to be adjusted.
            if (!_initialScalingDone && this.WindowState == FormWindowState.Maximized)
            {
                // Fallback: if original sizes/fonts weren't captured in Load (should not happen ideally)
                if (_originalFormSize.Width == 0 || _originalFormSize.Height == 0) _originalFormSize = this.ClientSize;
                if (_originalFormFont == null) _originalFormFont = this.Font;
                if (tabControlMain != null && _originalTabControlFont == null) _originalTabControlFont = tabControlMain.Font;
                if (panelLoginContainer != null && _originalPanelLoginContainerFont == null) _originalPanelLoginContainerFont = panelLoginContainer.Font;
                if (panelLoginContainer != null && _originalPanelLoginContainerSize.IsEmpty) _originalPanelLoginContainerSize = panelLoginContainer.Size;


                SizeF currentMaximizedFormSize = this.ClientSize;

                // Calculate scale factor based on the change in form dimensions
                // Use the smaller of the width/height scale factors to maintain aspect ratio for font scaling
                float scaleFactorX = (_originalFormSize.Width > 0) ? (currentMaximizedFormSize.Width / _originalFormSize.Width) : 1.0f;
                float scaleFactorY = (_originalFormSize.Height > 0) ? (currentMaximizedFormSize.Height / _originalFormSize.Height) : 1.0f;
                float scaleFactor = Math.Min(scaleFactorX, scaleFactorY);

                if (scaleFactor <= 0) scaleFactor = 1.0f; // Prevent issues, default to no scaling if factor is invalid

                // 1. Scale Form's base font
                if (_originalFormFont != null)
                {
                    float newFormFontSize = _originalFormFont.Size * scaleFactor;
                    newFormFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newFormFontSize)); // Clamp font size

                    // Apply new font if significantly different or properties changed
                    if (Math.Abs(this.Font.Size - newFormFontSize) > 0.1f ||
                        this.Font.FontFamily != _originalFormFont.FontFamily ||
                        this.Font.Style != _originalFormFont.Style)
                    {
                        this.Font = new Font(_originalFormFont.FontFamily, newFormFontSize, _originalFormFont.Style);
                    }
                }

                // 2. Scale TabControl's font (for tab headers)
                if (tabControlMain != null && _originalTabControlFont != null)
                {
                    float newTabControlFontSize = _originalTabControlFont.Size * scaleFactor;
                    newTabControlFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newTabControlFontSize)); // Clamp font size

                    if (Math.Abs(tabControlMain.Font.Size - newTabControlFontSize) > 0.1f ||
                        tabControlMain.Font.FontFamily != _originalTabControlFont.FontFamily ||
                        tabControlMain.Font.Style != _originalTabControlFont.Style)
                    {
                        tabControlMain.Font = new Font(_originalTabControlFont.FontFamily, newTabControlFontSize, _originalTabControlFont.Style);
                    }
                }

                // 3. Scale PanelLoginContainer's font and size
                if (panelLoginContainer != null)
                {
                    // Scale panel's font
                    if (_originalPanelLoginContainerFont != null)
                    {
                        float newPanelFontSize = _originalPanelLoginContainerFont.Size * scaleFactor;
                        newPanelFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newPanelFontSize)); // Clamp font size

                        if (Math.Abs(panelLoginContainer.Font.Size - newPanelFontSize) > 0.1f ||
                            panelLoginContainer.Font.FontFamily != _originalPanelLoginContainerFont.FontFamily ||
                            panelLoginContainer.Font.Style != _originalPanelLoginContainerFont.Style)
                        {
                            panelLoginContainer.Font = new Font(_originalPanelLoginContainerFont.FontFamily, newPanelFontSize, _originalPanelLoginContainerFont.Style);
                        }
                    }

                    // Scale panel's size (your existing logic, slightly refined)
                    if (!_originalPanelLoginContainerSize.IsEmpty && _originalPanelLoginContainerSize.Width > 0 && _originalPanelLoginContainerSize.Height > 0)
                    {
                        int newPanelWidth = (int)(_originalPanelLoginContainerSize.Width * scaleFactor);
                        int newPanelHeight = (int)(_originalPanelLoginContainerSize.Height * scaleFactor);

                        // Apply min/max constraints for panel dimensions
                        newPanelWidth = Math.Max(MinPanelWidth, newPanelWidth);
                        newPanelHeight = Math.Max(MinPanelHeight, newPanelHeight);

                        // Ensure panel does not exceed its parent tab page's client area (minus margins)
                        if (tabPageLogin != null)
                        {
                            newPanelWidth = Math.Min(newPanelWidth, tabPageLogin.ClientSize.Width - (panelLoginContainer.Margin.Horizontal));
                            newPanelHeight = Math.Min(newPanelHeight, tabPageLogin.ClientSize.Height - (panelLoginContainer.Margin.Vertical));
                        }
                        panelLoginContainer.Size = new Size(Math.Max(0, newPanelWidth), Math.Max(0, newPanelHeight)); // Ensure non-negative
                    }
                }
                _initialScalingDone = true; // Mark that initial scaling is complete
            }

            // Always re-center the panelLoginContainer on any form resize,
            // using its current (possibly scaled once) size.
            CenterLoginPanel();
        }
    }
}
