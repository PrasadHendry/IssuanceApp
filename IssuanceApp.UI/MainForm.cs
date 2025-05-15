// MainForm.cs (Code-behind with Enhanced Font Scaling - Reviewed)
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

        // Fields for font and control scaling (primarily for one-time scaling on initial maximize)
        private SizeF _originalFormClientSize; // Stores the form's client size before initial maximization
        private Font _originalFormFont;       // Stores the form's original font
        private Size _originalPanelLoginContainerSize; // Stores the panel's original size
        private Font _originalPanelLoginContainerFont; // Stores the panel's original font
        private Font _originalTabControlFont; // Stores the TabControl's original font (for tab headers)

        private bool _initialScalingPerformed = false; // Flag to ensure scaling logic runs only once on initial maximize

        // Constants for scaling limits
        private const float MinFontSize = 8f;    // Minimum allowable font size after scaling
        private const float MaxFontSize = 18f;   // Maximum allowable font size after scaling
        private const int MinPanelLoginWidth = 300;   // Minimum width for the login panel after scaling
        private const int MinPanelLoginHeight = 200;  // Minimum height for the login panel after scaling


        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents(); // General UI setup
            SetupStatusBar();             // Status bar setup
            InitializeLoginTab();         // Login tab specific setup
            SetupTabs();                  // General tab setup (permissions etc.)

            // Subscribe to events for scaling and layout adjustments
            this.Load += MainForm_Load_ForScalingSetup;
            this.Resize += MainForm_Resize_Handler; // Handles general resize events (like re-centering login panel)
            
            // AutoScaleMode.Font is set in the designer and is crucial for controls to adapt to font changes.
        }

        private void MainForm_Load_ForScalingSetup(object sender, EventArgs e)
        {
            // Store initial sizes and fonts BEFORE any programmatic maximization.
            // These serve as the baseline for the one-time scaling operation.
            _originalFormClientSize = this.ClientSize;
            _originalFormFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style); // Clone to ensure it's the true original

            if (tabControlMain != null)
            {
                _originalTabControlFont = new Font(tabControlMain.Font.FontFamily, tabControlMain.Font.Size, tabControlMain.Font.Style);
            }

            if (panelLoginContainer != null)
            {
                _originalPanelLoginContainerSize = panelLoginContainer.Size;
                _originalPanelLoginContainerFont = new Font(panelLoginContainer.Font.FontFamily, panelLoginContainer.Font.Size, panelLoginContainer.Font.Style);
            }

            CenterLoginPanel(); // Perform initial centering based on design-time sizes

            // Maximize the window on load. This will trigger MainForm_Resize_Handler,
            // which in turn can call the one-time scaling logic.
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Document Issuance System";
            statusTimer = new Timer();
            statusTimer.Interval = 1000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            // Subscribe to tabPageLogin's Resize event to keep its content (panelLoginContainer) centered
            if (this.tabPageLogin != null) // Ensure tabPageLogin is not null
            {
                this.tabPageLogin.Resize += TabPageLogin_Resize;
            }
        }

        private void SetupStatusBar()
        {
            string userName = "Unknown User";
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                if (currentUser != null && !string.IsNullOrEmpty(currentUser.Name))
                {
                    userName = currentUser.Name;
                }
            }
            catch (System.Security.SecurityException secEx)
            {
                Console.WriteLine("Security error getting username: " + secEx.Message);
                userName = "N/A (Permissions)";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting username: " + ex.Message);
                userName = "N/A (Error)";
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
            if (cmbRole == null || txtPassword == null || btnLogin == null) return; // Defensive check

            cmbRole.Items.AddRange(new object[] { "Requester", "GM_Operations", "QA", "Admin" });
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            txtPassword.PasswordChar = '*';
            btnLogin.Click += BtnLogin_Click;
            EnableTabsBasedOnRole(null); 
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // (Your existing login logic - seems fine for its purpose)
            // ...
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
                txtPassword.Clear(); 
                EnableTabsBasedOnRole(loggedInRole);
                SwitchToDefaultTabForRole(loggedInRole);
            }
            else
            {
                lblLoginStatus.Text = "Invalid role or password.";
                lblLoginStatus.ForeColor = Color.Red;
                loggedInRole = null;
                EnableTabsBasedOnRole(null); 
            }
        }

        private bool AuthenticateUser(string roleName, string password)
        {
            // IMPORTANT: Replace with a secure authentication mechanism!
            if (roleName == "Requester" && password == "test") return true;
            if (roleName == "GM_Operations" && password == "test1") return true;
            if (roleName == "QA" && password == "test2") return true;
            if (roleName == "Admin" && password == "adminpass") return true;
            return false;
        }

        private void EnableTabsBasedOnRole(string role)
        {
            // (Your existing tab enabling/disabling logic - seems fine)
            // ...
            bool isAdmin = (role == "Admin");
            bool isRequester = (role == "Requester");
            bool isGm = (role == "GM_Operations");
            bool isQa = (role == "QA");

            tabPageDocumentIssuance.Enabled = isRequester || isAdmin;
            tabPageGmOperations.Enabled = isGm || isAdmin;
            tabPageQa.Enabled = isQa || isAdmin;
            tabPageUsers.Enabled = isAdmin;
            tabPageAuditTrail.Enabled = !string.IsNullOrEmpty(role); // Enabled if any role is logged in

            if (string.IsNullOrEmpty(role) && tabControlMain != null)
            {
                tabControlMain.SelectedTab = tabPageLogin;
            }
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            // (Your existing tab switching logic - seems fine)
            // ...
             if (tabControlMain == null) return;
            switch (role)
            {
                case "Requester": tabControlMain.SelectedTab = tabPageDocumentIssuance; break;
                case "GM_Operations": tabControlMain.SelectedTab = tabPageGmOperations; break;
                case "QA": tabControlMain.SelectedTab = tabPageQa; break;
                case "Admin": tabControlMain.SelectedTab = tabPageUsers; break;
                default: tabControlMain.SelectedTab = tabPageLogin; break; 
            }
        }

        private void SetupTabs()
        {
            // Any general tab setup not related to roles.
            // Role-based enabling is handled in EnableTabsBasedOnRole.
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

        // --- Layout and Scaling Logic ---

        private void TabPageLogin_Resize(object sender, EventArgs e)
        {
            // This event ensures the login panel is re-centered if the login tab itself resizes
            // (e.g., if the TabControl's font changes, affecting tab page client areas).
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            if (panelLoginContainer != null && tabPageLogin != null && panelLoginContainer.Parent == tabPageLogin)
            {
                int panelX = (tabPageLogin.ClientSize.Width - panelLoginContainer.Width) / 2;
                int panelY = (tabPageLogin.ClientSize.Height - panelLoginContainer.Height) / 2;
                panelLoginContainer.Location = new Point(Math.Max(0, panelX), Math.Max(0, panelY));
            }
        }
        
        private void MainForm_Resize_Handler(object sender, EventArgs e)
        {
            // This handler is called on every form resize.
            // It triggers the one-time scaling logic if conditions are met.
            // It also ensures the login panel is re-centered.

            if (!_initialScalingPerformed && this.WindowState == FormWindowState.Maximized)
            {
                PerformInitialScaling();
                _initialScalingPerformed = true; // Mark that initial scaling is complete
            }

            // Always re-center the login panel on any form resize,
            // using its current (possibly scaled once) size.
            CenterLoginPanel();
        }

        private void PerformInitialScaling()
        {
            // This method performs the one-time scaling when the form is first maximized.
            // It scales fonts for the form, tab control, and login panel, and resizes the login panel.
            // It relies on AutoScaleMode.Font for other controls to adapt.

            if (_originalFormClientSize.Width == 0 || _originalFormClientSize.Height == 0)
            {
                Console.WriteLine("Original form client size not captured, skipping initial scaling.");
                return; // Cannot scale if original size is unknown
            }

            SizeF currentMaximizedFormClientSize = this.ClientSize;

            float scaleFactorX = (currentMaximizedFormClientSize.Width / _originalFormClientSize.Width);
            float scaleFactorY = (currentMaximizedFormClientSize.Height / _originalFormClientSize.Height);
            // Use the smaller scale factor to maintain aspect ratio for font scaling and prevent excessive stretching
            float scaleFactor = Math.Min(scaleFactorX, scaleFactorY);

            if (scaleFactor <= 0.1f) // Prevent extreme downscaling or issues with zero/negative factors
            {
                Console.WriteLine($"Invalid scale factor {scaleFactor}, defaulting to 1.0 for initial scaling.");
                scaleFactor = 1.0f; 
            }

            // 1. Scale Form's base font
            if (_originalFormFont != null)
            {
                float newFormFontSize = _originalFormFont.Size * scaleFactor;
                newFormFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newFormFontSize));
                this.Font = new Font(_originalFormFont.FontFamily, newFormFontSize, _originalFormFont.Style);
            }

            // 2. Scale TabControl's font (primarily for tab headers)
            if (tabControlMain != null && _originalTabControlFont != null)
            {
                float newTabControlFontSize = _originalTabControlFont.Size * scaleFactor;
                newTabControlFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newTabControlFontSize));
                tabControlMain.Font = new Font(_originalTabControlFont.FontFamily, newTabControlFontSize, _originalTabControlFont.Style);
            }

            // 3. Scale PanelLoginContainer's font and size
            if (panelLoginContainer != null)
            {
                if (_originalPanelLoginContainerFont != null)
                {
                    float newPanelFontSize = _originalPanelLoginContainerFont.Size * scaleFactor;
                    newPanelFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newPanelFontSize));
                    panelLoginContainer.Font = new Font(_originalPanelLoginContainerFont.FontFamily, newPanelFontSize, _originalPanelLoginContainerFont.Style);
                }

                if (!_originalPanelLoginContainerSize.IsEmpty && _originalPanelLoginContainerSize.Width > 0)
                {
                    int newPanelWidth = (int)(_originalPanelLoginContainerSize.Width * scaleFactorX); // Scale width more directly with form width
                    int newPanelHeight = (int)(_originalPanelLoginContainerSize.Height * scaleFactorY); // Scale height more directly with form height

                    newPanelWidth = Math.Max(MinPanelLoginWidth, newPanelWidth);
                    newPanelHeight = Math.Max(MinPanelLoginHeight, newPanelHeight);

                    if (tabPageLogin != null) // Ensure panel doesn't exceed tab page
                    {
                        newPanelWidth = Math.Min(newPanelWidth, tabPageLogin.ClientSize.Width - panelLoginContainer.Margin.Horizontal);
                        newPanelHeight = Math.Min(newPanelHeight, tabPageLogin.ClientSize.Height - panelLoginContainer.Margin.Vertical);
                    }
                    panelLoginContainer.Size = new Size(Math.Max(10, newPanelWidth), Math.Max(10, newPanelHeight)); // Ensure minimum dimensions
                }
            }
            // Note: After this one-time scaling, AutoScaleMode.Font is responsible for ongoing adjustments
            // of individual controls if the form's font is changed again.
            // The layout of complex tabs like "Document Issuance" primarily depends on Anchor/Dock properties
            // set in the designer, or the use of layout panels (e.g., TableLayoutPanel).
        }

        private void lblParentExpDateDI_Click(object sender, EventArgs e)
        {

        }

        private void dtpParentExpDateDI_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
