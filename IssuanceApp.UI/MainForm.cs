// MainForm.cs (Code-behind with Enhanced Font Scaling & Document Issuance Logic)
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal; // Required for WindowsIdentity
using System.Collections.Generic; // Required for List<string>
using System.IO; // New: For file operations (CSV export)
using System.Text;
using IssuanceApp.Data; // Assuming AuditTrailEntry is here
using System.Xml.Serialization; // This was likely for StringBuilder, but StringBuilder is in System.Text

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

        private BindingSource userRolesBindingSource;


        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents(); // General UI setup
            SetupStatusBar();             // Status bar setup
            InitializeLoginTab();         // Login tab specific setup

            // Initialize Document Issuance Tab specific logic
            InitializeDocumentIssuanceTab();
            LoadInitialDocumentIssuanceData(); // Load initial data like tracker/request no.

            InitializeGmOperationsTab(); // <-- Added call for GM Operations Tab

            InitializeQaTab(); // <-- Added call for QA Operations Tab

            InitializeAuditTrailTab(); // <-- Added call for Audit Trail Operations Tab

            InitializeUsersTab(); // <-- Added call for Users Tab

            SetupTabs();                  // General tab setup (permissions etc.)

            // Subscribe to events for scaling and layout adjustments
            this.Load += MainForm_Load_ForScalingSetup;
            this.Resize += MainForm_Resize_Handler; // Handles general resize events (like re-centering login panel)
            this.tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;

            // AutoScaleMode.Font is set in the designer and is crucial for controls to adapt to font changes.
            // Call a method to set up tlpQaRequestDetails RowStyles
            SetupTlpQaRequestDetailsRowStyles();
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

       	private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e) //Loading data grid view data 
        { 
			if (tabControlMain.SelectedTab == tabPageUsers)
			{
				LoadUserRoles();
			}
			else if (tabControlMain.SelectedTab == tabPageGmOperations)
			{
				LoadGmPendingQueue();
			}
			else if (tabControlMain.SelectedTab == tabPageQa)
			{
				LoadQaPendingQueue();
			}
			else if (tabControlMain.SelectedTab == tabPageAuditTrail)
			{
				LoadAuditTrailData();
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
            toolStripStatusLabelUser.Text = $"User: {userName}"; // Keep "User: " prefix for clarity
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
            // This is a placeholder and highly insecure for production.
            if (roleName == "Requester" && password == "test") return true;
            if (roleName == "GM_Operations" && password == "test1") return true;
            if (roleName == "QA" && password == "test2") return true;
            if (roleName == "Admin" && password == "adminpass") return true;
            return false;
        }

        private void EnableTabsBasedOnRole(string role)
        {
            bool isAdmin = (role == "Admin");
            bool isRequester = (role == "Requester");
            bool isGm = (role == "GM_Operations");
            bool isQa = (role == "QA");

            // Ensure tabControlMain and its pages are not null before accessing them
            if (tabControlMain == null) return;

            if (tabPageDocumentIssuance != null) tabPageDocumentIssuance.Enabled = isRequester || isAdmin;
            if (tabPageGmOperations != null) tabPageGmOperations.Enabled = isGm || isAdmin;
            if (tabPageQa != null) tabPageQa.Enabled = isQa || isAdmin;
            if (tabPageUsers != null) tabPageUsers.Enabled = isAdmin;
            if (tabPageAuditTrail != null) tabPageAuditTrail.Enabled = !string.IsNullOrEmpty(role); // Enabled if any role is logged in

            if (string.IsNullOrEmpty(role) && tabPageLogin != null)
            {
                tabControlMain.SelectedTab = tabPageLogin;
            }
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            if (tabControlMain == null) return;
            switch (role)
            {
                case "Requester":
                    if (tabPageDocumentIssuance != null) tabControlMain.SelectedTab = tabPageDocumentIssuance;
                    break;
                case "GM_Operations":
                    if (tabPageGmOperations != null) tabControlMain.SelectedTab = tabPageGmOperations;
                    break;
                case "QA":
                    if (tabPageQa != null) tabControlMain.SelectedTab = tabPageQa;
                    break;
                case "Admin":
                    if (tabPageUsers != null) tabControlMain.SelectedTab = tabPageUsers; // Or any other default for Admin
                    break;
                default:
                    if (tabPageLogin != null) tabControlMain.SelectedTab = tabPageLogin;
                    break;
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
            if (!_initialScalingPerformed && this.WindowState == FormWindowState.Maximized)
            {
                PerformInitialScaling();
                _initialScalingPerformed = true;
            }
            CenterLoginPanel(); // Recenter login panel on any resize, including after initial scaling
        }

        private void PerformInitialScaling()
        {
            if (_originalFormClientSize.Width == 0 || _originalFormClientSize.Height == 0)
            {
                Console.WriteLine("Original form client size not captured, skipping initial scaling.");
                return;
            }

            SizeF currentMaximizedFormClientSize = this.ClientSize;

            // Calculate scale factors based on the change from original design-time client size to current maximized client size
            float scaleFactorX = (currentMaximizedFormClientSize.Width / _originalFormClientSize.Width);
            float scaleFactorY = (currentMaximizedFormClientSize.Height / _originalFormClientSize.Height);
            float scaleFactor = Math.Min(scaleFactorX, scaleFactorY); // Use the smaller factor to maintain aspect ratio for fonts

            if (scaleFactor <= 0.1f) // Prevent excessively small or zero scale factors
            {
                Console.WriteLine($"Invalid scale factor {scaleFactor}, defaulting to 1.0 for initial scaling.");
                scaleFactor = 1.0f;
            }

            // Scale the main form's font
            if (_originalFormFont != null)
            {
                float newFormFontSize = _originalFormFont.Size * scaleFactor;
                newFormFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newFormFontSize)); // Clamp font size
                this.Font = new Font(_originalFormFont.FontFamily, newFormFontSize, _originalFormFont.Style);
            }

            // Scale the TabControl's font (for tab headers)
            if (tabControlMain != null && _originalTabControlFont != null)
            {
                float newTabControlFontSize = _originalTabControlFont.Size * scaleFactor;
                newTabControlFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newTabControlFontSize)); // Clamp font size
                tabControlMain.Font = new Font(_originalTabControlFont.FontFamily, newTabControlFontSize, _originalTabControlFont.Style);
            }

            // Scale the login panel's font and size
            if (panelLoginContainer != null)
            {
                if (_originalPanelLoginContainerFont != null)
                {
                    float newPanelFontSize = _originalPanelLoginContainerFont.Size * scaleFactor;
                    newPanelFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newPanelFontSize)); // Clamp font size
                    panelLoginContainer.Font = new Font(_originalPanelLoginContainerFont.FontFamily, newPanelFontSize, _originalPanelLoginContainerFont.Style);
                }

                if (!_originalPanelLoginContainerSize.IsEmpty && _originalPanelLoginContainerSize.Width > 0) // Check if original size was captured
                {
                    // Scale panel size based on respective X and Y scale factors
                    int newPanelWidth = (int)(_originalPanelLoginContainerSize.Width * scaleFactorX);
                    int newPanelHeight = (int)(_originalPanelLoginContainerSize.Height * scaleFactorY);

                    // Apply min/max constraints to panel size
                    newPanelWidth = Math.Max(MinPanelLoginWidth, newPanelWidth);
                    newPanelHeight = Math.Max(MinPanelLoginHeight, newPanelHeight);

                    // Ensure panel does not exceed its parent's client area (tabPageLogin)
                    if (tabPageLogin != null)
                    {
                        newPanelWidth = Math.Min(newPanelWidth, tabPageLogin.ClientSize.Width - panelLoginContainer.Margin.Horizontal);
                        newPanelHeight = Math.Min(newPanelHeight, tabPageLogin.ClientSize.Height - panelLoginContainer.Margin.Vertical);
                    }
                    panelLoginContainer.Size = new Size(Math.Max(10, newPanelWidth), Math.Max(10, newPanelHeight)); // Prevent zero or negative size
                }
            }
            // Note: Child controls within panelLoginContainer and other tabs will scale their fonts
            // automatically if their Font property is inherited or not explicitly set differently,
            // and if their AutoScaleMode is Font (which is typical for WinForms).
            // Explicit size scaling for other deeply nested controls might be needed if AutoScale doesn't suffice.
        }


        // --- Document Issuance Tab Logic ---
        #region Document Issuance Tab Logic

        private void InitializeDocumentIssuanceTab()
        {
            // Ensure controls are not null before accessing them
            if (dtpRequestDateDI != null)
            {
                dtpRequestDateDI.Value = DateTime.Now;
            }

            if (cmbFromDepartmentDI != null && cmbFromDepartmentDI.Items.Count > 0)
            {
                cmbFromDepartmentDI.SelectedIndex = 0;
            }

            if (lblStatusValueDI != null)
            {
                lblStatusValueDI.Text = "Ready to create a new request.";
            }

            if (btnSubmitRequestDI != null)
            {
                btnSubmitRequestDI.Click += BtnSubmitRequestDI_Click;
            }

            if (btnClearFormDI != null)
            {
                btnClearFormDI.Click += BtnClearFormDI_Click;
            }
        }

        private void LoadInitialDocumentIssuanceData()
        {
            if (lblTrackerNoValueDI != null)
            {
                lblTrackerNoValueDI.Text = GenerateNewTrackerNumber();
            }
            if (txtRequestNoValueDI != null)
            {
                txtRequestNoValueDI.Text = GenerateNewRequestNumber();
            }
        }

        private string GenerateNewTrackerNumber()
        {
            // Simple random number generation for tracker. Consider a more robust sequential or DB-driven approach for production.
            Random rnd = new Random();
            return $"TRK-{DateTime.Now.Year}{DateTime.Now.Month:D2}-{rnd.Next(1000, 9999)}";
        }

        private string GenerateNewRequestNumber()
        {
            // Simple random number generation for request. Consider a more robust sequential or DB-driven approach for production.
            Random rnd = new Random();
            return $"REQ-{DateTime.Now.ToString("yyyyMMdd")}-{rnd.Next(100, 999)}";
        }

        private void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            if (cmbFromDepartmentDI == null || cmbFromDepartmentDI.SelectedItem == null)
            {
                MessageBox.Show("Please select a 'From Department'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromDepartmentDI?.Focus();
                return;
            }
            if (txtProductDI == null || string.IsNullOrWhiteSpace(txtProductDI.Text))
            {
                MessageBox.Show("Please enter the 'Product'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductDI?.Focus();
                return;
            }

            string selectedDocTypes = GetSelectedDocumentTypes();
            if (string.IsNullOrEmpty(selectedDocTypes))
            {
                MessageBox.Show("Please select at least one 'Document Type'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grpDocTypeDI?.Focus(); // Focus the group box containing the checkboxes
                return;
            }

            // --- Data Collection ---
            // Ensure all controls are not null before accessing their properties
            var issuanceData = new
            {
                TrackerNo = lblTrackerNoValueDI?.Text ?? "N/A",
                RequestNo = txtRequestNoValueDI?.Text ?? "N/A",
                RequestDate = dtpRequestDateDI?.Value ?? DateTime.MinValue,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(), // Already checked for null
                DocumentTypes = selectedDocTypes,
                ParentBatchNumber = txtParentBatchNoDI?.Text,
                ParentBatchSize = numParentBatchSizeDI?.Value ?? 0,
                ParentMfgDate = (dtpParentMfgDateDI != null && dtpParentMfgDateDI.Checked) ? (DateTime?)dtpParentMfgDateDI.Value : null,
                ParentExpDate = (dtpParentExpDateDI != null && dtpParentExpDateDI.Checked) ? (DateTime?)dtpParentExpDateDI.Value : null,
                Product = txtProductDI.Text, // Already checked for null/whitespace
                DocumentNo = txtDocumentNoDI?.Text,
                BatchNo = txtBatchNoDI?.Text,
                BatchSize = txtBatchSizeDI?.Text, // Assuming this is a string; parse if it should be numeric
                ItemMfgDate = (dtpItemMfgDateDI != null && dtpItemMfgDateDI.Checked) ? (DateTime?)dtpItemMfgDateDI.Value : null,
                ItemExpDate = (dtpItemExpDateDI != null && dtpItemExpDateDI.Checked) ? (DateTime?)dtpItemExpDateDI.Value : null,
                Market = txtMarketDI?.Text,
                PackSize = txtPackSizeDI?.Text,
                ExportOrderNo = txtExportOrderNoDI?.Text,
                Remarks = txtRemarksDI?.Text,
                RequestedBy = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "Unknown" // Extract actual username
            };

            // --- Data Processing/Saving ---
            try
            {
                // TODO: Implement your data saving logic here (e.g., save to database, file, etc.)
                // This would involve creating an instance of a data model class and passing it to a data access layer.
                // Example:
                // var newIssuance = new DocIssuanceEntity { /* map properties from issuanceData */ };
                // YourDataAccessLayer.SaveIssuanceRequest(newIssuance);

                Console.WriteLine("--- Document Issuance Request Submitted ---");
                Console.WriteLine($"Tracker No: {issuanceData.TrackerNo}");
                Console.WriteLine($"Request No: {issuanceData.RequestNo}");
                Console.WriteLine($"Request Date: {issuanceData.RequestDate:dd-MMM-yyyy}");
                Console.WriteLine($"From Department: {issuanceData.FromDepartment}");
                Console.WriteLine($"Document Types: {issuanceData.DocumentTypes}");
                Console.WriteLine($"Product: {issuanceData.Product}");
                // Add more console logs for other fields as needed for debugging/logging

                if (lblStatusValueDI != null)
                {
                    lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                    lblStatusValueDI.ForeColor = Color.Green;
                }
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!\nTracker No: {issuanceData.TrackerNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearDocumentIssuanceForm();
                LoadInitialDocumentIssuanceData(); // Generate new numbers for the next request
            }
            catch (Exception ex)
            {
                if (lblStatusValueDI != null)
                {
                    lblStatusValueDI.Text = "Error submitting request.";
                    lblStatusValueDI.ForeColor = Color.Red;
                }
                MessageBox.Show($"Error submitting request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedDocumentTypes()
        {
            var selectedTypes = new List<string>(); // Using System.Collections.Generic
            if (chkDocTypeBMRDI != null && chkDocTypeBMRDI.Checked) selectedTypes.Add("BMR");
            if (chkDocTypeBPRDI != null && chkDocTypeBPRDI.Checked) selectedTypes.Add("BPR");
            if (chkDocTypeAppendixDI != null && chkDocTypeAppendixDI.Checked) selectedTypes.Add("APPENDIX");
            if (chkDocTypeAddendumDI != null && chkDocTypeAddendumDI.Checked) selectedTypes.Add("ADDENDUM");
            return string.Join(",", selectedTypes);
        }

        private void BtnClearFormDI_Click(object sender, EventArgs e)
        {
            ClearDocumentIssuanceForm();
            if (lblStatusValueDI != null)
            {
                lblStatusValueDI.Text = "Form cleared. Ready for new request.";
                lblStatusValueDI.ForeColor = SystemColors.ControlText; // Reset color
            }
            LoadInitialDocumentIssuanceData(); // Also reload new tracker/request numbers on clear
        }

        private void ClearDocumentIssuanceForm()
        {
            // Uncheck all document type checkboxes
            if (chkDocTypeBMRDI != null) chkDocTypeBMRDI.Checked = false;
            if (chkDocTypeBPRDI != null) chkDocTypeBPRDI.Checked = false;
            if (chkDocTypeAppendixDI != null) chkDocTypeAppendixDI.Checked = false;
            if (chkDocTypeAddendumDI != null) chkDocTypeAddendumDI.Checked = false;

            // Reset request date and department
            if (dtpRequestDateDI != null) dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI != null)
            {
                if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
                else cmbFromDepartmentDI.SelectedItem = null; // Or Set to -1 if appropriate
            }

            // Clear Parent Batch Information
            if (txtParentBatchNoDI != null) txtParentBatchNoDI.Clear();
            if (numParentBatchSizeDI != null) numParentBatchSizeDI.Value = 0;
            if (dtpParentMfgDateDI != null) { dtpParentMfgDateDI.Value = DateTime.Now; dtpParentMfgDateDI.Checked = false; } // Reset value before unchecking
            if (dtpParentExpDateDI != null) { dtpParentExpDateDI.Value = DateTime.Now; dtpParentExpDateDI.Checked = false; } // Reset value before unchecking

            // Clear Item/Product Details
            if (txtProductDI != null) txtProductDI.Clear();
            if (txtDocumentNoDI != null) txtDocumentNoDI.Clear();
            if (txtBatchNoDI != null) txtBatchNoDI.Clear();
            if (txtBatchSizeDI != null) txtBatchSizeDI.Clear();
            if (dtpItemMfgDateDI != null) { dtpItemMfgDateDI.Value = DateTime.Now; dtpItemMfgDateDI.Checked = false; } // Reset value before unchecking
            if (dtpItemExpDateDI != null) { dtpItemExpDateDI.Value = DateTime.Now; dtpItemExpDateDI.Checked = false; } // Reset value before unchecking
            if (txtMarketDI != null) txtMarketDI.Clear();
            if (txtPackSizeDI != null) txtPackSizeDI.Clear();
            if (txtExportOrderNoDI != null) txtExportOrderNoDI.Clear();

            // Clear Remarks
            if (txtRemarksDI != null) txtRemarksDI.Clear();

            // Update status label (optional, can be more specific if needed)
            if (lblStatusValueDI != null)
            {
                lblStatusValueDI.Text = "Form cleared.";
            }
        }
        #endregion Document Issuance Tab Logic

        // --- GM Operations Tab Logic ---
        #region GM Operations Tab Logic

        private void InitializeGmOperationsTab()
        {
            // Configure DataGridView
            if (dgvGmQueue != null) // Ensure dgvGmQueue is not null
            {
                dgvGmQueue.AutoGenerateColumns = false; // Important if columns are defined in designer
                // Example: Map to data source property (ensure your data source object has these properties)
                // dgvGmQueue.Columns["colGmRequestNo"].DataPropertyName = "RequestNo";
                // dgvGmQueue.Columns["colGmRequestDate"].DataPropertyName = "RequestDate";
                // dgvGmQueue.Columns["colGmProduct"].DataPropertyName = "Product";
                // dgvGmQueue.Columns["colGmDocTypes"].DataPropertyName = "DocumentTypes";
                // dgvGmQueue.Columns["colGmPreparedBy"].DataPropertyName = "PreparedBy";
                // dgvGmQueue.Columns["colGmRequestedAt"].DataPropertyName = "RequestedAt";
                dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            }

            // Set initial states or attach event handlers
            if (btnGmRefreshList != null)
            {
                btnGmRefreshList.Click += BtnGmRefreshList_Click;
            }
            if (btnGmAuthorize != null)
            {
                btnGmAuthorize.Click += BtnGmAuthorize_Click;
            }
            if (btnGmReject != null)
            {
                btnGmReject.Click += BtnGmReject_Click;
            }

            // Clear details fields initially
            ClearGmSelectedRequestDetails();
            if (txtGmComment != null) txtGmComment.Clear();

            // Load the initial queue if the user is GM or Admin and the tab is visible/enabled
            if ((loggedInRole == "GM_Operations" || loggedInRole == "Admin") && tabPageGmOperations != null && tabPageGmOperations.Enabled)
            {
                LoadGmPendingQueue();
            }
            else if (lblGmQueueTitle != null)
            {
                lblGmQueueTitle.Text = "Pending GM Approval Queue (0)"; // Default if not loaded
            }
        }

        private void LoadGmPendingQueue()
        {
            // TODO: Implement logic to fetch pending requests for GM from the database
            // and populate dgvGmQueue.
            // This method should query your database for records where GM action is pending.
            // Example:
            // var pendingRequests = YourDataAccessLayer.GetPendingGmRequests();
            // dgvGmQueue.DataSource = pendingRequests;

            if (dgvGmQueue != null)
            {
                // Placeholder data for demonstration - REMOVE FOR PRODUCTION
                var placeholderData = new List<object>(); // Use List<object> for dynamic objects
                placeholderData.Add(new { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-5), Product = "Product A (Pharma)", DocumentTypes = "BMR,APPENDIX", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-5).AddHours(2) });
                placeholderData.Add(new { RequestNo = "REQ-20240102-002", RequestDate = DateTime.Now.AddDays(-4), Product = "Product B (Vaccine)", DocumentTypes = "BPR", PreparedBy = "another.requester", RequestedAt = DateTime.Now.AddDays(-4).AddHours(3) });
                placeholderData.Add(new { RequestNo = "REQ-20240103-003", RequestDate = DateTime.Now.AddDays(-3), Product = "Product C (Tablet)", DocumentTypes = "ADDENDUM", PreparedBy = "test.user", RequestedAt = DateTime.Now.AddDays(-3).AddHours(1) });

                dgvGmQueue.DataSource = placeholderData;
            }
            if (lblGmQueueTitle != null) // Ensure lblGmQueueTitle is not null
            {
                lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue?.Rows.Count ?? 0})";
            }
        }

        private void ClearGmSelectedRequestDetails()
        {
            // Clear all textboxes in the "Selected Request Details" group
            if (txtGmDetailRequestNo != null) txtGmDetailRequestNo.Clear();
            if (txtGmDetailRequestDate != null) txtGmDetailRequestDate.Clear();
            if (txtGmDetailFromDept != null) txtGmDetailFromDept.Clear();
            if (txtGmDetailDocTypes != null) txtGmDetailDocTypes.Clear();
            if (txtGmDetailProduct != null) txtGmDetailProduct.Clear();
            if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Clear();
            if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Clear();
            if (txtGmDetailExpDate != null) txtGmDetailExpDate.Clear();
            if (txtGmDetailMarket != null) txtGmDetailMarket.Clear();
            if (txtGmDetailPackSize != null) txtGmDetailPackSize.Clear();
            if (txtGmDetailPreparedBy != null) txtGmDetailPreparedBy.Clear();
            if (txtGmDetailRequestedAt != null) txtGmDetailRequestedAt.Clear();
            if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Clear();
        }

        private void DisplayGmSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow == null || selectedRow.IsNewRow)
            {
                ClearGmSelectedRequestDetails();
                return;
            }

            // TODO: Fetch full details for the selected request from your data source.
            // The IssuanceID or RequestNo from the selectedRow should be used to query the database
            // for all fields in Doc_Issuance and relevant fields from Issuance_Tracker.

            // For now, we'll use the data available in the DataGridView row as an example.
            // You'll need to map these to your actual data object properties if using direct data binding.
            // If using placeholder data or manual population:
            if (txtGmDetailRequestNo != null) txtGmDetailRequestNo.Text = selectedRow.Cells["colGmRequestNo"]?.Value?.ToString() ?? "";
            if (txtGmDetailRequestDate != null) txtGmDetailRequestDate.Text = selectedRow.Cells["colGmRequestDate"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colGmRequestDate"].Value).ToString("dd-MMM-yyyy") : "";
            if (txtGmDetailProduct != null) txtGmDetailProduct.Text = selectedRow.Cells["colGmProduct"]?.Value?.ToString() ?? "";
            if (txtGmDetailDocTypes != null) txtGmDetailDocTypes.Text = selectedRow.Cells["colGmDocTypes"]?.Value?.ToString() ?? "";
            if (txtGmDetailPreparedBy != null) txtGmDetailPreparedBy.Text = selectedRow.Cells["colGmPreparedBy"]?.Value?.ToString() ?? "";
            if (txtGmDetailRequestedAt != null) txtGmDetailRequestedAt.Text = selectedRow.Cells["colGmRequestedAt"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colGmRequestedAt"].Value).ToString("dd-MMM-yyyy HH:mm") : "";

            // --- TODO: Populate these fields from your actual detailed data source ---
            // These fields are NOT in the dgvGmQueue by default from the requirements, so they need to be fetched.
            // Example of how you might fetch and populate if you had a full data object:
            // var requestDetails = YourDataAccessLayer.GetRequestDetails(selectedRow.Cells["colGmRequestNo"].Value.ToString());
            // if (requestDetails != null) {
            //    if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = requestDetails.FromDepartment;
            //    if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = requestDetails.BatchNo;
            //    if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = requestDetails.ItemMfgDate?.ToString("dd-MMM-yyyy") ?? "";
            //    if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = requestDetails.ItemExpDate?.ToString("dd-MMM-yyyy") ?? "";
            //    if (txtGmDetailMarket != null) txtGmDetailMarket.Text = requestDetails.Market;
            //    if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = requestDetails.PackSize;
            //    if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = requestDetails.RequestComment; // Assuming RequestComment is from Issuance_Tracker
            // }

            // For demonstration with placeholder, let's simulate some additional details:
            if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Production Department (Simulated)";
            if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = $"B{DateTime.Now.Millisecond}";
            if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy");
            if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = DateTime.Now.AddYears(1).ToString("dd-MMM-yyyy");
            if (txtGmDetailMarket != null) txtGmDetailMarket.Text = "Domestic (Simulated)";
            if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = "10x10 (Simulated)";
            if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = "This is a critical request, please expedite. (Simulated Requester Comment)";
        }

        // --- Event Handlers for GM Operations Tab ---
        private void BtnGmRefreshList_Click(object sender, EventArgs e)
        {
            LoadGmPendingQueue();
            if (txtGmComment != null) txtGmComment.Clear();
            // Optionally clear selection or details if desired after refresh
            // if (dgvGmQueue != null) dgvGmQueue.ClearSelection();
            // ClearGmSelectedRequestDetails();
        }

        private void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue != null && dgvGmQueue.SelectedRows.Count > 0)
            {
                DisplayGmSelectedRequestDetails(dgvGmQueue.SelectedRows[0]);
                if (txtGmComment != null) txtGmComment.Clear(); // Clear previous GM comments when selection changes
            }
            else
            {
                ClearGmSelectedRequestDetails();
                if (txtGmComment != null) txtGmComment.Clear();
            }
        }

        private void BtnGmAuthorize_Click(object sender, EventArgs e)
        {
            if (dgvGmQueue == null || dgvGmQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to authorize.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Get IssuanceID or the actual RequestNo from the selected row's data-bound item or a hidden column for DB operations.
            string requestNoForDisplay = txtGmDetailRequestNo?.Text ?? "N/A"; // For display in messages
            string gmComments = txtGmComment?.Text ?? "";
            string gmUser = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "GM_User_Unknown"; // Get logged-in GM username

            // Confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to AUTHORIZE request '{requestNoForDisplay}'?", "Confirm Authorization", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // TODO: Implement database update logic to:
                // 1. Find the Issuance_Tracker record associated with the IssuanceID of the selected request.
                // 2. Update GmOperationsAction = "Authorized", AuthorizedBy = gmUser, GmOperationsAt = DateTime.Now, GmOperationsComment = gmComments.
                // Example: YourDataAccessLayer.AuthorizeRequestByGm(issuanceId, gmUser, gmComments);

                MessageBox.Show($"Request '{requestNoForDisplay}' authorized successfully (Simulated).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGmPendingQueue(); // Refresh the list
                ClearGmSelectedRequestDetails();
                if (txtGmComment != null) txtGmComment.Clear();
            }
        }

        private void BtnGmReject_Click(object sender, EventArgs e)
        {
            if (dgvGmQueue == null || dgvGmQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to reject.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGmComment != null && string.IsNullOrWhiteSpace(txtGmComment.Text))
            {
                MessageBox.Show("GM comments are required for rejection.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGmComment.Focus();
                return;
            }

            // TODO: Get IssuanceID or the actual RequestNo for DB operations.
            string requestNoForDisplay = txtGmDetailRequestNo?.Text ?? "N/A"; // For display in messages
            string gmComments = txtGmComment?.Text ?? ""; // Already checked for null/whitespace
            string gmUser = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "GM_User_Unknown"; // Get logged-in GM username

            // Confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to REJECT request '{requestNoForDisplay}'?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // TODO: Implement database update logic to:
                // 1. Find the Issuance_Tracker record.
                // 2. Update GmOperationsAction = "Rejected", AuthorizedBy = gmUser (or RejectedBy), GmOperationsAt = DateTime.Now, GmOperationsComment = gmComments.
                // Example: YourDataAccessLayer.RejectRequestByGm(issuanceId, gmUser, gmComments);

                MessageBox.Show($"Request '{requestNoForDisplay}' rejected (Simulated).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGmPendingQueue(); // Refresh the list
                ClearGmSelectedRequestDetails();
                if (txtGmComment != null) txtGmComment.Clear();
            }
        }
        #endregion GM Operations Tab Logic

        private void SetupTlpQaRequestDetailsRowStyles()
        {
            // Clear any existing row styles that the designer might have added by default
            if (this.tlpQaRequestDetails == null) return; // Guard clause
            this.tlpQaRequestDetails.RowStyles.Clear();

            // Define the height for the first (RowCount - 2) rows
            float standardRowHeight = 30F; // Adjusted for potentially more rows
            // Define the height for the last two special rows (comments)
            float specialRowHeight = 60F;

            // Ensure RowCount is valid and sufficient for the logic
            if (this.tlpQaRequestDetails.RowCount >= 2)
            {
                // Add styles for the standard rows up to the last two
                for (int i = 0; i < this.tlpQaRequestDetails.RowCount - 2; i++)
                {
                    this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
                }

                // Add styles for the last two special rows (Requester Comments and GM Comments)
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight));
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight));
            }
            else // Fallback for smaller RowCount (e.g., if RowCount is 0 or 1)
            {
                for (int i = 0; i < this.tlpQaRequestDetails.RowCount; i++)
                {
                    this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
                }
            }
        }

        #region QA Tab Logic

        private void InitializeQaTab()
        {
            // Configure DataGridView for QA Queue
            if (dgvQaQueue != null)
            {
                dgvQaQueue.AutoGenerateColumns = false; // Assuming columns are defined in the designer
                                                        // If you need to set DataPropertyName for columns (if not already done in designer):
                                                        // dgvQaQueue.Columns["colQaRequestNo"].DataPropertyName = "RequestNo";
                                                        // dgvQaQueue.Columns["colQaRequestDate"].DataPropertyName = "RequestDate";
                                                        // ... and so on for other columns ...
                dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;
            }

            // Attach event handlers for buttons
            if (btnQaRefreshList != null)
            {
                btnQaRefreshList.Click += BtnQaRefreshList_Click;
            }
            if (btnQaApprove != null)
            {
                btnQaApprove.Click += BtnQaApprove_Click;
            }
            if (btnQaReject != null)
            {
                btnQaReject.Click += BtnQaReject_Click;
            }
            if (btnQaBrowseSelectDocument != null)
            {
                // TODO: Implement document browsing logic if needed
                // btnQaBrowseSelectDocument.Click += BtnQaBrowseSelectDocument_Click;
            }


            // Clear details fields and comments initially
            ClearQaSelectedRequestDetails();
            if (txtQaComment != null) txtQaComment.Clear();
            if (numQaPrintCount != null) numQaPrintCount.Value = 1; // Default print count

            // Load the initial queue if the user role is appropriate
            if ((loggedInRole == "QA" || loggedInRole == "Admin") && tabPageQa != null && tabPageQa.Enabled)
            {
                LoadQaPendingQueue();
            }
            else if (lblQaQueueTitle != null)
            {
                lblQaQueueTitle.Text = "Pending QA Approval Queue (0)"; // Default title
            }
        }

        private void LoadQaPendingQueue()
        {
            // TODO: Implement logic to fetch requests approved by GM and pending QA action from the database.
            // Query should look for records where:
            // Issuance_Tracker.GmOperationsAction = "Authorized" AND Issuance_Tracker.QAAction IS NULL.
            // Example:
            // var pendingQaRequests = YourDataAccessLayer.GetPendingQaRequests();
            // dgvQaQueue.DataSource = pendingQaRequests;

            if (dgvQaQueue != null)
            {
                // Placeholder data for demonstration - REMOVE FOR PRODUCTION
                var placeholderQaData = new List<object>();
                placeholderQaData.Add(new
                {
                    RequestNo = "REQ-20240101-001",
                    RequestDate = DateTime.Now.AddDays(-5),
                    Product = "Product A (Pharma)",
                    DocumentTypes = "BMR,APPENDIX",
                    PreparedBy = "user.requester",
                    AuthorizedBy = "gm.user",
                    GmActionAt = DateTime.Now.AddDays(-2) // GM's authorization details
                });
                placeholderQaData.Add(new
                {
                    RequestNo = "REQ-20240104-004",
                    RequestDate = DateTime.Now.AddDays(-2),
                    Product = "Product D (Syrup)",
                    DocumentTypes = "BPR,ADDENDUM",
                    PreparedBy = "another.user",
                    AuthorizedBy = "gm.user",
                    GmActionAt = DateTime.Now.AddDays(-1)
                });
                dgvQaQueue.DataSource = placeholderQaData;
            }

            if (lblQaQueueTitle != null)
            {
                lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue?.Rows.Count ?? 0})";
            }
            ClearQaSelectedRequestDetails(); // Clear details when queue is reloaded
            if (txtQaComment != null) txtQaComment.Clear();
        }

        private void ClearQaSelectedRequestDetails()
        {
            // Clear all textboxes in the "Selected Request Details" group for QA tab
            if (txtQaDetailRequestNo != null) txtQaDetailRequestNo.Clear();
            if (txtQaDetailRequestDate != null) txtQaDetailRequestDate.Clear();
            if (txtQaDetailFromDept != null) txtQaDetailFromDept.Clear();
            if (txtQaDetailDocTypes != null) txtQaDetailDocTypes.Clear();
            if (txtQaDetailProduct != null) txtQaDetailProduct.Clear();
            if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Clear();
            if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Clear();
            if (txtQaDetailExpDate != null) txtQaDetailExpDate.Clear();
            if (txtQaDetailMarket != null) txtQaDetailMarket.Clear();
            if (txtQaDetailPackSize != null) txtQaDetailPackSize.Clear();
            if (txtQaDetailPreparedBy != null) txtQaDetailPreparedBy.Clear();
            if (txtQaDetailRequestedAt != null) txtQaDetailRequestedAt.Clear();
            if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Clear();
            if (txtQaDetailGmComment != null) txtQaDetailGmComment.Clear(); // GM's comments
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Clear(); // GM's action time
        }

        private void DisplayQaSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow == null || selectedRow.IsNewRow)
            {
                ClearQaSelectedRequestDetails();
                return;
            }

            // TODO: Fetch full details for the selected request from your data source (Doc_Issuance and Issuance_Tracker tables).
            // The IssuanceID or RequestNo from the selectedRow should be used.
            // This should include all details from the original request, plus GM's action details.

            // Example using DataGridView cell values (ensure your DataGridView columns are correctly named or use DataPropertyName)
            // You'll need to adapt this to your actual data source object or how you populate the DataGridView.
            if (txtQaDetailRequestNo != null) txtQaDetailRequestNo.Text = selectedRow.Cells["colQaRequestNo"]?.Value?.ToString() ?? "";
            if (txtQaDetailRequestDate != null) txtQaDetailRequestDate.Text = selectedRow.Cells["colQaRequestDate"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colQaRequestDate"].Value).ToString("dd-MMM-yyyy") : "";
            if (txtQaDetailProduct != null) txtQaDetailProduct.Text = selectedRow.Cells["colQaProduct"]?.Value?.ToString() ?? "";
            if (txtQaDetailDocTypes != null) txtQaDetailDocTypes.Text = selectedRow.Cells["colQaDocTypes"]?.Value?.ToString() ?? "";
            if (txtQaDetailPreparedBy != null) txtQaDetailPreparedBy.Text = selectedRow.Cells["colQaPreparedBy"]?.Value?.ToString() ?? "";

            // Fields related to GM's action (assuming these columns exist in dgvQaQueue or are fetched)
            // if (txtQaDetailGmAuthorizedBy != null) txtQaDetailGmAuthorizedBy.Text = selectedRow.Cells["colQaAuthorizedBy"]?.Value?.ToString() ?? ""; // You might need a textbox for this
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Text = selectedRow.Cells["colQaGmActionAt"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colQaGmActionAt"].Value).ToString("dd-MMM-yyyy HH:mm") : "";

            // --- TODO: Populate these fields from your actual detailed data source (Doc_Issuance and Issuance_Tracker) ---
            // Example:
            // var requestDetails = YourDataAccessLayer.GetFullRequestDetailsForQa(selectedRow.Cells["colQaRequestNo"].Value.ToString());
            // if (requestDetails != null) {
            //    if (txtQaDetailFromDept != null) txtQaDetailFromDept.Text = requestDetails.FromDepartment;
            //    if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Text = requestDetails.BatchNo;
            //    if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = requestDetails.ItemMfgDate?.ToString("dd-MMM-yyyy") ?? "";
            //    if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = requestDetails.ItemExpDate?.ToString("dd-MMM-yyyy") ?? "";
            //    if (txtQaDetailMarket != null) txtQaDetailMarket.Text = requestDetails.Market;
            //    if (txtQaDetailPackSize != null) txtQaDetailPackSize.Text = requestDetails.PackSize;
            //    if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Text = requestDetails.RequestComment;
            //    if (txtQaDetailGmComment != null) txtQaDetailGmComment.Text = requestDetails.GmOperationsComment;
            //    // txtQaDetailGmActionTime is already populated above if data is in dgv
            // }

            // For demonstration with placeholder, simulating some additional details:
            if (txtQaDetailFromDept != null) txtQaDetailFromDept.Text = "Production (Simulated for QA)";
            if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Text = $"B{DateTime.Now.Second}";
            if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = DateTime.Now.AddDays(-30).ToString("dd-MMM-yyyy");
            if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = DateTime.Now.AddYears(2).ToString("dd-MMM-yyyy");
            if (txtQaDetailMarket != null) txtQaDetailMarket.Text = "Export (Simulated for QA)";
            if (txtQaDetailPackSize != null) txtQaDetailPackSize.Text = "20x5 (Simulated for QA)";
            if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Text = "Urgent request, please process. (Simulated Req Comment)";
            if (txtQaDetailGmComment != null) txtQaDetailGmComment.Text = "Looks good from operations side. (Simulated GM Comment)";
        }

        // --- Event Handlers for QA Operations Tab ---
        private void BtnQaRefreshList_Click(object sender, EventArgs e)
        {
            LoadQaPendingQueue();
            if (txtQaComment != null) txtQaComment.Clear();
            if (numQaPrintCount != null) numQaPrintCount.Value = 1;
        }

        private void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue != null && dgvQaQueue.SelectedRows.Count > 0)
            {
                DisplayQaSelectedRequestDetails(dgvQaQueue.SelectedRows[0]);
                if (txtQaComment != null) txtQaComment.Clear(); // Clear previous QA comments
                if (numQaPrintCount != null) numQaPrintCount.Value = 1; // Reset print count
            }
            else
            {
                ClearQaSelectedRequestDetails();
                if (txtQaComment != null) txtQaComment.Clear();
                if (numQaPrintCount != null) numQaPrintCount.Value = 1;
            }
        }

        private void BtnQaApprove_Click(object sender, EventArgs e)
        {
            if (dgvQaQueue == null || dgvQaQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to approve.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Get IssuanceID or the actual RequestNo from the selected row's data-bound item for DB operations.
            string requestNoForDisplay = txtQaDetailRequestNo?.Text ?? "N/A"; // For display in messages
            string qaComments = txtQaComment?.Text ?? "";
            int printCount = (int)(numQaPrintCount?.Value ?? 1);
            string qaUser = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "QA_User_Unknown";

            // Confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to APPROVE and ISSUE request '{requestNoForDisplay}'?\nPrint Count: {printCount}", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // TODO: Implement database update logic:
                // 1. Find the Issuance_Tracker record associated with the IssuanceID.
                // 2. Update QAAction = "Approved", ApprovedBy = qaUser, QAAt = DateTime.Now, QAComment = qaComments.
                // 3. Optionally, log the printCount if you have a field for it.
                // Example: YourDataAccessLayer.ApproveRequestByQa(issuanceId, qaUser, qaComments, printCount);

                // TODO: Implement actual printing logic here if required by QA role.
                // For example: PrintDocument(requestDetails, printCount);

                MessageBox.Show($"Request '{requestNoForDisplay}' approved and issued (Simulated).\nPrinted {printCount} copies.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQaPendingQueue(); // Refresh the list
                ClearQaSelectedRequestDetails();
                if (txtQaComment != null) txtQaComment.Clear();
                if (numQaPrintCount != null) numQaPrintCount.Value = 1;
            }
        }

        private void BtnQaReject_Click(object sender, EventArgs e)
        {
            if (dgvQaQueue == null || dgvQaQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to reject.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtQaComment != null && string.IsNullOrWhiteSpace(txtQaComment.Text))
            {
                MessageBox.Show("QA comments are required for rejection.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQaComment.Focus();
                return;
            }

            // TODO: Get IssuanceID or the actual RequestNo for DB operations.
            string requestNoForDisplay = txtQaDetailRequestNo?.Text ?? "N/A";
            string qaComments = txtQaComment?.Text ?? ""; // Already checked for null/whitespace
            string qaUser = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "QA_User_Unknown";

            // Confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to REJECT request '{requestNoForDisplay}'?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // TODO: Implement database update logic:
                // 1. Find the Issuance_Tracker record.
                // 2. Update QAAction = "Rejected", ApprovedBy = qaUser (or RejectedBy), QAAt = DateTime.Now, QAComment = qaComments.
                // Example: YourDataAccessLayer.RejectRequestByQa(issuanceId, qaUser, qaComments);

                MessageBox.Show($"Request '{requestNoForDisplay}' rejected (Simulated).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQaPendingQueue(); // Refresh the list
                ClearQaSelectedRequestDetails();
                if (txtQaComment != null) txtQaComment.Clear();
                if (numQaPrintCount != null) numQaPrintCount.Value = 1;
            }
        }

        #endregion QA Tab Logic

        #region Audit Trail Tab Logic

        private void InitializeAuditTrailTab()
        {
            // Populate Status ComboBox
            if (cmbAuditStatus != null)
            {
                cmbAuditStatus.Items.Clear(); // Clear existing items first
                cmbAuditStatus.Items.Add("All");
                cmbAuditStatus.Items.Add("Pending GM Approval");
                cmbAuditStatus.Items.Add("Pending QA Approval");
                cmbAuditStatus.Items.Add("Approved (Issued)");
                cmbAuditStatus.Items.Add("Rejected by GM");
                cmbAuditStatus.Items.Add("Rejected by QA");
                if (cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            }

            // Set default dates
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.AddDays(-7);
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now;

            // Configure DataGridView
            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.AutoGenerateColumns = false;
                dgvAuditTrail.ReadOnly = true;
                dgvAuditTrail.AllowUserToAddRows = false;
                dgvAuditTrail.AllowUserToDeleteRows = false;
                dgvAuditTrail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // This is important
                dgvAuditTrail.ScrollBars = ScrollBars.Both; // Explicitly ensure scrollbars
                // Crucial for text wrapping to work with varying row heights:
                dgvAuditTrail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                SetupAuditTrailColumns(); // Call this to define columns
            }

            // Attach event handlers
            if (btnApplyAuditFilter != null)
            {
                btnApplyAuditFilter.Click += BtnApplyAuditFilter_Click;
            }
            if (btnClearAuditFilters != null)
            {
                btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            }
            if (btnRefreshAuditList != null)
            {
                btnRefreshAuditList.Click += BtnRefreshAuditList_Click;
            }
            if (btnExportToCsv != null)
            {
                btnExportToCsv.Click += BtnExportToCsv_Click;
            }
            if (btnExportToExcel != null)
            {
                btnExportToExcel.Click += BtnExportToExcel_Click;
            }

            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.DataError += DgvAuditTrail_DataError;
            }

            LoadAuditTrailData();
        }

        private void DgvAuditTrail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Log the error or display a less intrusive message
            Console.WriteLine($"DataGridView DataError: Row {e.RowIndex}, Column {e.ColumnIndex} ({dgvAuditTrail.Columns[e.ColumnIndex].Name}). Exception: {e.Exception.Message}");
            // Optionally, to prevent the default error dialog:
            // e.ThrowException = false;
            // e.Cancel = true; // Or e.Cancel = true if you want to revert the change
            MessageBox.Show($"Error displaying data in the grid at row {e.RowIndex + 1}, column '{dgvAuditTrail.Columns[e.ColumnIndex].HeaderText}'.\nDetails: {e.Exception.Message}",
                            "Data Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void SetupAuditTrailColumns()
        {
            if (dgvAuditTrail == null) return;

            dgvAuditTrail.Columns.Clear();

            // Define columns for dgvAuditTrail.
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = "Product", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocTypes", HeaderText = "Doc Types", DataPropertyName = "DocumentTypes", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditStatusDerived", HeaderText = "Status", DataPropertyName = "DerivedStatus", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditPreparedBy", HeaderText = "Prepared By", DataPropertyName = "PreparedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestedAt", HeaderText = "Requested At", DataPropertyName = "RequestedAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmAction", HeaderText = "GM Action", DataPropertyName = "GmOperationsAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditAuthorizedBy", HeaderText = "GM User", DataPropertyName = "AuthorizedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmActionAt", HeaderText = "GM Action At", DataPropertyName = "GmOperationsAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });

            // GM Comment Column with Text Wrapping
            DataGridViewTextBoxColumn colGmComment = new DataGridViewTextBoxColumn
            {
                Name = "colAuditGmComment",
                HeaderText = "GM Comment",
                DataPropertyName = "GmOperationsComment",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } // Enable text wrapping
            };
            dgvAuditTrail.Columns.Add(colGmComment);

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaAction", HeaderText = "QA Action", DataPropertyName = "QAAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditApprovedBy", HeaderText = "QA User", DataPropertyName = "ApprovedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaActionAt", HeaderText = "QA Action At", DataPropertyName = "QAAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });

            // QA Comment Column with Text Wrapping
            DataGridViewTextBoxColumn colQaComment = new DataGridViewTextBoxColumn
            {
                Name = "colAuditQaComment",
                HeaderText = "QA Comment",
                DataPropertyName = "QAComment",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } // Enable text wrapping
            };
            dgvAuditTrail.Columns.Add(colQaComment);
        }


        private void LoadAuditTrailData()
        {
            DateTime fromDate = dtpAuditFrom?.Value.Date ?? DateTime.MinValue;
            DateTime toDate = dtpAuditTo?.Value.Date.AddDays(1).AddSeconds(-1) ?? DateTime.MaxValue;
            string statusFilter = cmbAuditStatus?.SelectedItem?.ToString() ?? "All";
            string requestNoFilter = txtAuditRequestNo?.Text.Trim() ?? "";
            string productFilter = txtAuditProduct?.Text.Trim() ?? "";

            // TODO: Replace placeholder data with actual database query
            // var auditDataFromDb = YourDataAccessLayer.GetAuditTrail(fromDate, toDate, statusFilter, requestNoFilter, productFilter);
            // dgvAuditTrail.DataSource = auditDataFromDb;

            // Using concrete class for placeholder data
            var placeholderAuditData = new List<AuditTrailEntry>();

            // Example Entry 1: Approved
            if (statusFilter == "All" || statusFilter == "Approved (Issued)")
            {
                placeholderAuditData.Add(new AuditTrailEntry
                {
                    RequestNo = "REQ-20240101-001",
                    RequestDate = DateTime.Now.AddDays(-10),
                    Product = "Product A (Pharma)",
                    DocumentTypes = "BMR,APPENDIX",
                    DerivedStatus = "Approved (Issued)",
                    PreparedBy = "user.requester",
                    RequestedAt = DateTime.Now.AddDays(-10).AddHours(1),
                    GmOperationsAction = "Authorized",
                    AuthorizedBy = "gm.user",
                    GmOperationsAt = DateTime.Now.AddDays(-9),
                    GmOperationsComment = "Looks good. This is a slightly longer comment for GM to test the wrapping behavior and ensure that it correctly displays across multiple lines if needed.",
                    QAAction = "Approved",
                    ApprovedBy = "qa.user",
                    QAAt = DateTime.Now.AddDays(-8),
                    QAComment = "Verified and issued. This is an even longer comment specifically for the QA column to thoroughly test the text wrapping functionality. It should span several lines within the cell to confirm that the AutoSizeRowsMode and WrapMode settings are working as expected."
                });
            }

            // Example Entry 2: Rejected by GM
            if (statusFilter == "All" || statusFilter == "Rejected by GM")
            {
                placeholderAuditData.Add(new AuditTrailEntry
                {
                    RequestNo = "REQ-20240102-002",
                    RequestDate = DateTime.Now.AddDays(-5),
                    Product = "Product B (Vaccine)",
                    DocumentTypes = "BPR",
                    DerivedStatus = "Rejected by GM",
                    PreparedBy = "another.requester",
                    RequestedAt = DateTime.Now.AddDays(-5).AddHours(2),
                    GmOperationsAction = "Rejected",
                    AuthorizedBy = "gm.user", // Or could be RejectedBy
                    GmOperationsAt = DateTime.Now.AddDays(-4),
                    GmOperationsComment = "Business case not valid. The provided documentation lacks sufficient detail for approval at this stage. Please revise and resubmit with more comprehensive information.",
                    QAAction = null, // Explicitly null
                    ApprovedBy = null,
                    QAAt = null,     // Explicitly null
                    QAComment = null
                });
            }

            // Example Entry 3: Pending QA Approval
            if (statusFilter == "All" || statusFilter == "Pending QA Approval")
            {
                placeholderAuditData.Add(new AuditTrailEntry
                {
                    RequestNo = "REQ-20240104-004",
                    RequestDate = DateTime.Now.AddDays(-2),
                    Product = "Product D (Syrup)",
                    DocumentTypes = "BPR,ADDENDUM",
                    DerivedStatus = "Pending QA Approval",
                    PreparedBy = "another.user",
                    RequestedAt = DateTime.Now.AddDays(-2).AddHours(1),
                    GmOperationsAction = "Authorized",
                    AuthorizedBy = "gm.user",
                    GmOperationsAt = DateTime.Now.AddDays(-1),
                    GmOperationsComment = "Approved by GM. All operational checks are complete.",
                    QAAction = null,
                    ApprovedBy = null,
                    QAAt = null,
                    QAComment = null
                });
            }
            // Example Entry 4: Short GM Comment, Long QA Comment
            if (statusFilter == "All" || statusFilter == "Approved (Issued)")
            {
                placeholderAuditData.Add(new AuditTrailEntry
                {
                    RequestNo = "REQ-20240105-005",
                    RequestDate = DateTime.Now.AddDays(-3),
                    Product = "Product E (Capsule)",
                    DocumentTypes = "BMR",
                    DerivedStatus = "Approved (Issued)",
                    PreparedBy = "user.requester",
                    RequestedAt = DateTime.Now.AddDays(-3).AddHours(2),
                    GmOperationsAction = "Authorized",
                    AuthorizedBy = "gm.user",
                    GmOperationsAt = DateTime.Now.AddDays(-2),
                    GmOperationsComment = "OK.",
                    QAAction = "Approved",
                    ApprovedBy = "qa.user",
                    QAAt = DateTime.Now.AddDays(-1),
                    QAComment = "All quality checks passed. The documentation is complete and accurate. The batch meets all specified release criteria. Ready for final issuance and distribution according to the plan."
                });
            }

            // ADDING MORE DATA FOR SCROLLING
            for (int i = 0; i < 20; i++) // Add 20 more entries
            {
                string status;
                string gmAction = null;
                string qaAction = null;
                string gmComment = null;
                string qaComment = null;
                DateTime? gmActionAt = null;
                DateTime? qaActionAt = null;
                string authorizedBy = null;
                string approvedBy = null;

                int statusType = i % 5;
                switch (statusType)
                {
                    case 0:
                        status = "Approved (Issued)";
                        gmAction = "Authorized";
                        qaAction = "Approved";
                        gmComment = $"GM Auto Comment {i}: Standard approval.";
                        qaComment = $"QA Auto Comment {i}: All checks green. This is a longer comment to ensure wrapping: Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                        gmActionAt = DateTime.Now.AddDays(-i - 2);
                        qaActionAt = DateTime.Now.AddDays(-i - 1);
                        authorizedBy = "gm.bot";
                        approvedBy = "qa.bot";
                        break;
                    case 1:
                        status = "Rejected by GM";
                        gmAction = "Rejected";
                        gmComment = $"GM Auto Reject {i}: Insufficient data. This is a longer comment to ensure wrapping: Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
                        gmActionAt = DateTime.Now.AddDays(-i - 2);
                        authorizedBy = "gm.bot";
                        break;
                    case 2:
                        status = "Rejected by QA";
                        gmAction = "Authorized";
                        qaAction = "Rejected";
                        gmComment = $"GM Auto Comment {i}: Seems fine from my end.";
                        qaComment = $"QA Auto Reject {i}: Discrepancy found in section 3. This is a longer comment to ensure wrapping: Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
                        gmActionAt = DateTime.Now.AddDays(-i - 2);
                        qaActionAt = DateTime.Now.AddDays(-i - 1);
                        authorizedBy = "gm.bot";
                        approvedBy = "qa.bot";
                        break;
                    case 3:
                        status = "Pending QA Approval";
                        gmAction = "Authorized";
                        gmComment = $"GM Auto Comment {i}: Forwarded for QA review.";
                        gmActionAt = DateTime.Now.AddDays(-i - 1);
                        authorizedBy = "gm.bot";
                        break;
                    default: // case 4
                        status = "Pending GM Approval";
                        break;
                }

                if (statusFilter == "All" || statusFilter == status)
                {
                    placeholderAuditData.Add(new AuditTrailEntry
                    {
                        RequestNo = $"REQ-AUTO-{DateTime.Now.Year}{(i + 6):D3}", // To make it somewhat unique
                        RequestDate = DateTime.Now.AddDays(-i - 15),
                        Product = $"Product {(char)('F' + (i % 20))} (Auto)", // Cycle through some product names
                        DocumentTypes = (i % 3 == 0) ? "BMR" : (i % 3 == 1) ? "BPR,APPENDIX" : "ADDENDUM",
                        DerivedStatus = status,
                        PreparedBy = "auto.requester",
                        RequestedAt = DateTime.Now.AddDays(-i - 15).AddHours(i % 5),
                        GmOperationsAction = gmAction,
                        AuthorizedBy = authorizedBy,
                        GmOperationsAt = gmActionAt,
                        GmOperationsComment = gmComment,
                        QAAction = qaAction,
                        ApprovedBy = approvedBy,
                        QAAt = qaActionAt,
                        QAComment = qaComment
                    });
                }
            }


            if (dgvAuditTrail != null)
            {
                // It's good practice to set DataSource to null before assigning a new list,
                // especially if the schema or type of items might change (though less critical with a concrete type).
                dgvAuditTrail.DataSource = null;
                dgvAuditTrail.DataSource = placeholderAuditData;
            }
        }

        private void BtnApplyAuditFilter_Click(object sender, EventArgs e)
        {
            LoadAuditTrailData();
        }

        private void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.AddDays(-7);
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now;
            if (cmbAuditStatus != null && cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            if (txtAuditRequestNo != null) txtAuditRequestNo.Clear();
            if (txtAuditProduct != null) txtAuditProduct.Clear();
            LoadAuditTrailData();
        }

        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail == null || dgvAuditTrail.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = "Save Audit Trail Data as CSV",
                FileName = $"AuditTrail_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csvContent = new StringBuilder();
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvAuditTrail.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{EscapeCsvField(column.HeaderText)}\"");
                        }
                    }
                    csvContent.AppendLine(string.Join(",", headers));

                    foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            List<string> cells = new List<string>();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (dgvAuditTrail.Columns[cell.ColumnIndex].Visible)
                                {
                                    string cellValue = cell.FormattedValue?.ToString() ?? "";
                                    cells.Add($"\"{EscapeCsvField(cellValue)}\"");
                                }
                            }
                            csvContent.AppendLine(string.Join(",", cells));
                        }
                    }

                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString(), Encoding.UTF8);
                    MessageBox.Show("Data exported successfully to CSV!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string EscapeCsvField(string field)
        {
            if (field == null) return "";
            // If the field contains a quote, escape it by doubling it.
            // Also, always enclose fields in quotes if they contain commas, newlines, or quotes.
            // For simplicity here, we'll always enclose and escape quotes.
            field = field.Replace("\"", "\"\"");
            return field;
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail == null || dgvAuditTrail.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                Title = "Save Audit Trail Data as Excel",
                FileName = $"AuditTrail_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Placeholder for actual Excel library implementation
                    // using OfficeOpenXml; // Example: EPPlus
                    // ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // For EPPlus
                    // using (var package = new ExcelPackage())
                    // {
                    //    var worksheet = package.Workbook.Worksheets.Add("AuditTrail");
                    //    // Populate worksheet from dgvAuditTrail (headers and data)
                    //    // Similar logic to CSV but using worksheet.Cells[row, col].Value
                    //    // Remember to handle data types for Excel cells.
                    //    package.SaveAs(new FileInfo(saveFileDialog.FileName));
                    // }
                    // MessageBox.Show("Data exported successfully to Excel!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show(
                        "Excel export functionality requires a dedicated library (e.g., EPPlus, ClosedXML).\n" +
                        "Please integrate one of these libraries to enable true .xlsx export.\n\n" +
                        $"(File would be saved to: {saveFileDialog.FileName})",
                        "Excel Export - TODO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NEW: Event Handler for the Refresh Audit List button
        private void BtnRefreshAuditList_Click(object sender, EventArgs e)
        {
            // 1. Reset column definitions and widths
            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.DataSource = null;
                // Temporarily suspend layout to avoid flicker during column setup
                dgvAuditTrail.SuspendLayout();
                SetupAuditTrailColumns();
                dgvAuditTrail.ResumeLayout(true); // Apply column layout changes
                LoadAuditTrailData();
                // 4. After data is loaded, explicitly tell the DataGridView to re-evaluate its column sizes
                //    based on their 'Width' property and update scrollbar information.
                dgvAuditTrail.PerformLayout(); // Force an additional layout calculation pass
            }

            // Optionally, provide user feedback
            // toolStripStatusLabelUser.Text = "Audit Trail refreshed."; // Or use a dedicated status label for the tab
        }

        #endregion Audit Trail Tab Logic

        #region Users Tab Logic

        private void InitializeUsersTab()
        {
            // Initialize the BindingSource
            this.userRolesBindingSource = new BindingSource();

            // Configure DataGridView for User Roles
            if (dgvUserRoles != null)
            {
                dgvUserRoles.AutoGenerateColumns = false; // Ensure this is false
                dgvUserRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUserRoles.MultiSelect = false;
                dgvUserRoles.AllowUserToAddRows = false;
                dgvUserRoles.AllowUserToDeleteRows = false;
                dgvUserRoles.ReadOnly = true;

                // Bind the DataGridView to the BindingSource
                dgvUserRoles.DataSource = this.userRolesBindingSource;

                // DataPropertyName for columns should be set in the designer, e.g.:
                // this.colUserRoleId.DataPropertyName = "RoleID";
                // this.colUserRoleName.DataPropertyName = "RoleName";
                // Double-check these in MainForm.Designer.cs to ensure they exactly match
                // the public property names in your UserRole class (case-sensitive).

                dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            }

            // Attach event handlers for buttons
            if (btnAddRole != null) btnAddRole.Click += BtnAddRole_Click;
            if (btnEditRole != null) btnEditRole.Click += BtnEditRole_Click;
            if (btnDeleteRole != null) btnDeleteRole.Click += BtnDeleteRole_Click;
            if (btnRefreshUserRoles != null)
            {
                btnRefreshUserRoles.Click += BtnRefreshUserRoles_Click;
            }

            // Initial state for buttons and textbox
            if (txtRoleNameManage != null) txtRoleNameManage.Clear();
            if (btnEditRole != null) btnEditRole.Enabled = false;
            if (btnDeleteRole != null) btnDeleteRole.Enabled = false;

            // Initial load if Admin
            if ((loggedInRole == "Admin") && tabPageUsers != null && tabPageUsers.Enabled)
            {
                LoadUserRoles();
            }
        }

        private void LoadUserRoles()
        {
            // --- Start Diagnostic ---
            // Uncomment the line below to verify this method is called
            // MessageBox.Show("LoadUserRoles called.", "Diagnostic - LoadUserRoles Start");
            // --- End Diagnostic ---

            var placeholderRoles = new List<UserRole>();
            try
            {
                // Ensure UserRole class has public properties: public int RoleID { get; set; } and public string RoleName { get; set; }
                placeholderRoles.Add(new UserRole { RoleID = 1, RoleName = "Requester" });
                placeholderRoles.Add(new UserRole { RoleID = 2, RoleName = "GM_Operations" });
                placeholderRoles.Add(new UserRole { RoleID = 3, RoleName = "QA" });
                placeholderRoles.Add(new UserRole { RoleID = 4, RoleName = "Admin_Test_Updated" }); // Changed for visibility
                placeholderRoles.Add(new UserRole { RoleID = 500 + DateTime.Now.Millisecond, RoleName = $"DynamicRole_{DateTime.Now.Millisecond}" }); // More dynamic for testing refresh

                // --- Start Diagnostic ---
                // Uncomment the lines below to check data creation
                // MessageBox.Show($"Placeholder list created. Count: {placeholderRoles.Count}", "Diagnostic - Data Created");
                // if (placeholderRoles.Count > 0)
                // {
                //     MessageBox.Show($"First role: ID={placeholderRoles[0].RoleID}, Name='{placeholderRoles[0].RoleName}'", "Diagnostic - First Item");
                // }
                // --- End Diagnostic ---

                if (this.userRolesBindingSource != null)
                {
                    // --- Start Diagnostic ---
                    // Uncomment to check BindingSource and DGV state before setting data
                    // MessageBox.Show("BindingSource is not null. Attempting to set its DataSource.", "Diagnostic - BindingSource Check");
                    // if (dgvUserRoles != null && dgvUserRoles.Columns.Count > 0)
                    // {
                    //     MessageBox.Show($"dgvUserRoles Column 0 Name: {dgvUserRoles.Columns[0].Name}, DataPropertyName: {dgvUserRoles.Columns[0].DataPropertyName}\n" +
                    //                     $"dgvUserRoles Column 1 Name: {dgvUserRoles.Columns[1].Name}, DataPropertyName: {dgvUserRoles.Columns[1].DataPropertyName}", "Diagnostic - Column Properties");
                    // } else if (dgvUserRoles != null) {
                    //     MessageBox.Show("dgvUserRoles has NO columns defined or accessible!", "Diagnostic - Column Error");
                    // } else {
                    //     MessageBox.Show("dgvUserRoles IS NULL here!", "Diagnostic - DGV Critical Error");
                    // }
                    // --- End Diagnostic ---

                    this.userRolesBindingSource.DataSource = null; // Clear previous data from BindingSource
                    this.userRolesBindingSource.DataSource = placeholderRoles; // Set new data

                    // The DataGridView should update automatically when its BindingSource's DataSource changes.
                    // dgvUserRoles.Refresh(); // Usually not needed with BindingSource but can be tried if issues persist.

                    // --- Start Diagnostic ---
                    // Uncomment to check DGV state after setting data
                    // if(dgvUserRoles != null) {
                    //    MessageBox.Show($"DataSource assigned to BindingSource. dgvUserRoles RowCount: {dgvUserRoles.Rows.Count}", "Diagnostic - DataSource Set");
                    //    if (dgvUserRoles.Rows.Count > 0 && dgvUserRoles.Columns.Count > 0 && dgvUserRoles.Rows[0].Cells.Count > 0)
                    //    {
                    //        MessageBox.Show($"First cell value after bind: {dgvUserRoles.Rows[0].Cells[0].Value}", "Diagnostic - First Cell Value");
                    //    }
                    // }
                    // --- End Diagnostic ---
                }
                else
                {
                    // --- Start Diagnostic ---
                    // MessageBox.Show("userRolesBindingSource IS NULL!", "Diagnostic - BindingSource Error");
                    // --- End Diagnostic ---
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in LoadUserRoles: {ex.Message}\n{ex.StackTrace}", "LoadUserRoles Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DgvUserRoles_SelectionChanged(null, null);
        }

        private void DgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUserRoles != null && dgvUserRoles.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvUserRoles.SelectedRows[0];

                // Attempt to get the bound UserRole object first
                UserRole selectedUserRole = selectedRow.DataBoundItem as UserRole;

                if (selectedUserRole != null)
                {
                    if (txtRoleNameManage != null)
                    {
                        txtRoleNameManage.Text = selectedUserRole.RoleName;
                    }
                }
                else // Fallback to cell value if DataBoundItem is not a UserRole (should not happen with BindingSource<UserRole>)
                {
                    if (txtRoleNameManage != null && selectedRow.Cells["colUserRoleName"] != null && selectedRow.Cells["colUserRoleName"].Value != null)
                    {
                        txtRoleNameManage.Text = selectedRow.Cells["colUserRoleName"].Value.ToString();
                    }
                    else if (txtRoleNameManage != null)
                    {
                        txtRoleNameManage.Text = "";
                    }
                }

                if (btnEditRole != null) btnEditRole.Enabled = true;
                if (btnDeleteRole != null) btnDeleteRole.Enabled = true;
            }
            else
            {
                if (txtRoleNameManage != null) txtRoleNameManage.Clear();
                if (btnEditRole != null) btnEditRole.Enabled = false;
                if (btnDeleteRole != null) btnDeleteRole.Enabled = false;
            }
        }

        private void BtnRefreshUserRoles_Click(object sender, EventArgs e)
        {
            // --- Start Diagnostic ---
            // MessageBox.Show("Refresh button clicked.", "Diagnostic - Refresh Button");
            // --- End Diagnostic ---
            LoadUserRoles();
        }

        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Role Dialog to be implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditRole_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role to edit.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dgvUserRoles.SelectedRows[0];
            UserRole selectedUserRole = selectedRow.DataBoundItem as UserRole;

            if (selectedUserRole != null)
            {
                MessageBox.Show($"Edit Role Dialog for '{selectedUserRole.RoleName}' (ID: {selectedUserRole.RoleID}) to be implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedRow.Cells["colUserRoleId"]?.Value != null && selectedRow.Cells["colUserRoleName"]?.Value != null) // Fallback
            {
                object roleIdObj = selectedRow.Cells["colUserRoleId"].Value;
                object roleNameObj = selectedRow.Cells["colUserRoleName"].Value;
                MessageBox.Show($"Edit Role Dialog for '{roleNameObj}' (ID: {roleIdObj}) to be implemented (fallback).", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selected role data is incomplete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role to delete.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dgvUserRoles.SelectedRows[0];
            UserRole selectedUserRole = selectedRow.DataBoundItem as UserRole;
            string roleNameToDelete = "the selected role";

            if (selectedUserRole != null)
            {
                roleNameToDelete = $"'{selectedUserRole.RoleName}' (ID: {selectedUserRole.RoleID})";
            }
            else if (selectedRow.Cells["colUserRoleName"]?.Value != null)
            { // Fallback
                roleNameToDelete = $"'{selectedRow.Cells["colUserRoleName"].Value}'";
            }


            DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete {roleNameToDelete}?",
                                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {
                MessageBox.Show($"{roleNameToDelete} deletion to be implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Users Tab Logic

        // --- Event Handlers for unused controls (can be removed if not needed) ---
        private void lblParentExpDateDI_Click(object sender, EventArgs e)
        {
            // This event handler might not be necessary if the label is purely informational.
            // If it's intended to toggle the DateTimePicker's Checked state, that logic would go here.
            // For example, if (dtpParentExpDateDI != null) dtpParentExpDateDI.Checked = !dtpParentExpDateDI.Checked;
        }

        private void dtpParentExpDateDI_ValueChanged(object sender, EventArgs e)
        {
            // This event handler is called when the date value changes OR when the checkbox state changes.
            // Add any specific logic needed when the parent expiry date is modified or its usage is toggled.
            // For example, you might want to validate that if checked, the date is in the future.
        }
    }

}
