// MainForm.cs (Code-behind with Enhanced Font Scaling & Document Issuance Logic)
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal; // Required for WindowsIdentity
using System.Collections.Generic; // Required for List<string>

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

            // Initialize Document Issuance Tab specific logic
            InitializeDocumentIssuanceTab();
            LoadInitialDocumentIssuanceData(); // Load initial data like tracker/request no.

            InitializeGmOperationsTab(); // <-- Added call for GM Operations Tab

            SetupTabs();                  // General tab setup (permissions etc.)

            // Subscribe to events for scaling and layout adjustments
            this.Load += MainForm_Load_ForScalingSetup;
            this.Resize += MainForm_Resize_Handler; // Handles general resize events (like re-centering login panel)

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
            this.tlpQaRequestDetails.RowStyles.Clear();

            // Define the height for the first (RowCount - 2) rows
            float standardRowHeight = 30F;
            // Define the height for the last two special rows
            float specialRowHeight = 60F;

            if (this.tlpQaRequestDetails.RowCount >= 2) // Ensure RowCount is at least 2
            {
                // Add styles for the standard rows
                for (int i = 0; i < this.tlpQaRequestDetails.RowCount - 2; i++)
                {
                    this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
                }

                // Add styles for the last two special rows
                // Assuming RowCount is 9, this will be for row index 7 and 8
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight)); // For Requester Comments
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight)); // For GM Comments
            }
            else
            {
                // Handle cases where RowCount is less than 2, if necessary,
                // or ensure RowCount is always appropriately set before this method is called.
                // For simplicity, if RowCount is small, you might just add all rows with a default height.
                for (int i = 0; i < this.tlpQaRequestDetails.RowCount; i++)
                {
                    this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
                }
            }
            // Ensure the number of RowStyles added matches tlpQaRequestDetails.RowCount
            // If RowCount is 9, you should have 9 RowStyles.Add calls in total from the logic above.
        }


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
