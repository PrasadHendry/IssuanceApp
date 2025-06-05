// MainForm.cs (Code-behind with Enhanced Font Scaling & Document Issuance Logic)
using System;
using System.Collections.Generic; // Required for List<string>
using System.Drawing;
using System.IO; // New: For file operations (CSV export)
using System.Security.Principal; // Required for WindowsIdentity
using System.Text;
using System.Windows.Forms;
using IssuanceApp.Data; //  AuditTrailEntry and UserRole 
using System.Threading.Tasks; // Required for Task.Run() in async methods
using System.Globalization; // Required for CultureInfo.InvariantCulture
using System.Collections; // Required for ArrayList
using System.ComponentModel; // Required for BindingSource
using System.Linq; // Required for .Cast<T>()


namespace DocumentIssuanceApp
{

    public partial class MainForm : Form
    {
        private Timer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null; // Store actual username after login

        // Fields for font and control scaling (primarily for one-time scaling on initial maximize)
        private SizeF _originalFormClientSize;
        private Font _originalFormFont;
        private Size _originalPanelLoginContainerSize;
        private Font _originalPanelLoginContainerFont;
        private Font _originalTabControlFont;

        private bool _initialScalingPerformed = false;

        // Constants for scaling limits
        private const float MinFontSize = 8f;
        private const float MaxFontSize = 18f;
        private const int MinPanelLoginWidth = 300;
        private const int MinPanelLoginHeight = 200;

        private BindingSource userRolesBindingSource;

        // --- START: User Management Mode Fields ---
        private enum UserManagementMode { None, Adding, Editing }
        private UserManagementMode _currentUsersTabMode = UserManagementMode.None;
        private UserRole _roleBeingEdited = null; // To store the role object during an edit operation
        // --- END: User Management Mode Fields ---


        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();

            SetupStatusBar();

            InitializeLoginTab();

            InitializeDocumentIssuanceTab();
            LoadInitialDocumentIssuanceData();

            InitializeGmOperationsTab();

            InitializeQaTab();
            SetupTlpQaRequestDetailsRowStyles(); // Call after InitializeQaTab if it relies on QA tab controls

            InitializeAuditTrailTab();
            InitializeUsersTab(); // Initialize Users tab

            SetupTabs(); // General tab setup (permissions etc.) - called after individual inits

            this.Load += MainForm_Load_ForScalingSetup;
            this.Resize += MainForm_Resize_Handler;
        }

        private void MainForm_Load_ForScalingSetup(object sender, EventArgs e)
        {
            _originalFormClientSize = this.ClientSize;
            _originalFormFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style);

            if (tabControlMain != null)
            {
                _originalTabControlFont = new Font(tabControlMain.Font.FontFamily, tabControlMain.Font.Size, tabControlMain.Font.Style);
            }

            if (panelLoginContainer != null)
            {
                _originalPanelLoginContainerSize = panelLoginContainer.Size;
                _originalPanelLoginContainerFont = new Font(panelLoginContainer.Font.FontFamily, panelLoginContainer.Font.Size, panelLoginContainer.Font.Style);
            }

            CenterLoginPanel();

            // Maximize the form after capturing original sizes and setting up scaling variables
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Document Issuance System";
            statusTimer = new Timer();
            statusTimer.Interval = 1000; // 1 second
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            if (this.tabPageLogin != null)
            {
                this.tabPageLogin.Resize += TabPageLogin_Resize;
            }
        }

        private void SetupStatusBar()
        {
            string osUserName = "Unknown User"; // Default
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                if (currentUser != null && !string.IsNullOrEmpty(currentUser.Name))
                {
                    osUserName = currentUser.Name;
                }
            }
            catch (System.Security.SecurityException secEx)
            {
                Console.WriteLine("Security error getting OS username: " + secEx.Message);
                osUserName = "N/A (Permissions)";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting OS username: " + ex.Message);
                osUserName = "N/A (Error)";
            }
            // Initialize with OS user, update with app user after login
            toolStripStatusLabelUser.Text = $"User: {osUserName} (Not Logged In)";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (toolStripStatusLabelDateTime != null)
            {
                toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
            }
        }

        private void InitializeLoginTab()
        {
            if (cmbRole == null || txtPassword == null || btnLogin == null || lblLoginStatus == null) return;

            cmbRole.Items.Clear();
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
                loggedInUserName = selectedRole; // For simplicity, using role name as app username.
                                                 // In a real app, fetch actual username.
                toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";

                lblLoginStatus.Text = $"Login successful as {loggedInRole}.";
                lblLoginStatus.ForeColor = Color.Green;
                txtPassword.Clear();
                EnableTabsBasedOnRole(loggedInRole);
                SwitchToDefaultTabForRole(loggedInRole);

                if (loggedInRole == "GM_Operations" || loggedInRole == "Admin") LoadGmPendingQueue();
                if (loggedInRole == "QA" || loggedInRole == "Admin") LoadQaPendingQueue();
                if (loggedInRole == "Admin") LoadUserRoles();
                if (!string.IsNullOrEmpty(loggedInRole)) LoadAuditTrailData();
            }
            else
            {
                lblLoginStatus.Text = "Invalid role or password.";
                lblLoginStatus.ForeColor = Color.Red;
                loggedInRole = null;
                loggedInUserName = null;
                SetupStatusBar(); // Reset to OS user, "Not Logged In"
                EnableTabsBasedOnRole(null);
            }
        }

        private bool AuthenticateUser(string roleName, string password)
        {
            // IMPORTANT: Placeholder authentication.
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

            if (tabControlMain == null) return;

            if (tabPageDocumentIssuance != null) tabPageDocumentIssuance.Enabled = isRequester || isAdmin;
            if (tabPageGmOperations != null) tabPageGmOperations.Enabled = isGm || isAdmin;
            if (tabPageQa != null) tabPageQa.Enabled = isQa || isAdmin;
            if (tabPageUsers != null) tabPageUsers.Enabled = isAdmin;
            if (tabPageAuditTrail != null) tabPageAuditTrail.Enabled = !string.IsNullOrEmpty(role);

            if (string.IsNullOrEmpty(role) && tabPageLogin != null)
            {
                if (tabControlMain.TabPages.Contains(tabPageLogin))
                {
                    tabControlMain.SelectedTab = tabPageLogin;
                }
            }
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            if (tabControlMain == null) return;
            TabPage targetTab = null;
            switch (role)
            {
                case "Requester":
                    targetTab = tabPageDocumentIssuance;
                    break;
                case "GM_Operations":
                    targetTab = tabPageGmOperations;
                    break;
                case "QA":
                    targetTab = tabPageQa;
                    break;
                case "Admin":
                    targetTab = tabPageUsers; // Default to Users tab for Admin
                    break;
                default:
                    targetTab = tabPageLogin;
                    break;
            }

            if (targetTab != null && tabControlMain.TabPages.Contains(targetTab) && targetTab.Enabled)
            {
                tabControlMain.SelectedTab = targetTab;
            }
            else if (tabPageLogin != null && tabControlMain.TabPages.Contains(tabPageLogin))
            {
                tabControlMain.SelectedTab = tabPageLogin;
            }
        }

        private void SetupTabs()
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
                statusTimer = null;
            }
            base.OnFormClosing(e);
        }

        private void TabPageLogin_Resize(object sender, EventArgs e)
        {
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            if (panelLoginContainer != null && tabPageLogin != null && panelLoginContainer.Parent == tabPageLogin)
            {
                if (panelLoginContainer.Width > tabPageLogin.ClientSize.Width)
                {
                    panelLoginContainer.Width = Math.Max(MinPanelLoginWidth, tabPageLogin.ClientSize.Width - 20);
                }
                if (panelLoginContainer.Height > tabPageLogin.ClientSize.Height)
                {
                    panelLoginContainer.Height = Math.Max(MinPanelLoginHeight, tabPageLogin.ClientSize.Height - 20);
                }

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
            CenterLoginPanel();
        }

        private void PerformInitialScaling()
        {
            if (_originalFormClientSize.Width == 0 || _originalFormClientSize.Height == 0)
            {
                Console.WriteLine("Original form client size not captured or invalid, skipping initial scaling.");
                return;
            }

            SizeF currentMaximizedFormClientSize = this.ClientSize;
            float scaleFactorX = (currentMaximizedFormClientSize.Width / _originalFormClientSize.Width);
            float scaleFactorY = (currentMaximizedFormClientSize.Height / _originalFormClientSize.Height);

            float fontScaleFactor = Math.Min(scaleFactorX, scaleFactorY);

            if (fontScaleFactor <= 0.1f)
            {
                Console.WriteLine($"Invalid font scale factor {fontScaleFactor}, defaulting to 1.0 for initial scaling.");
                fontScaleFactor = 1.0f;
            }
            if (scaleFactorX <= 0.1f) scaleFactorX = 1.0f;
            if (scaleFactorY <= 0.1f) scaleFactorY = 1.0f;


            if (_originalFormFont != null)
            {
                float newFormFontSize = _originalFormFont.Size * fontScaleFactor;
                newFormFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newFormFontSize));
                this.Font = new Font(_originalFormFont.FontFamily, newFormFontSize, _originalFormFont.Style);
            }

            if (tabControlMain != null && _originalTabControlFont != null)
            {
                float newTabControlFontSize = _originalTabControlFont.Size * fontScaleFactor;
                newTabControlFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newTabControlFontSize));
                tabControlMain.Font = new Font(_originalTabControlFont.FontFamily, newTabControlFontSize, _originalTabControlFont.Style);
            }

            if (panelLoginContainer != null)
            {
                if (_originalPanelLoginContainerFont != null)
                {
                    float newPanelFontSize = _originalPanelLoginContainerFont.Size * fontScaleFactor;
                    newPanelFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newPanelFontSize));
                    panelLoginContainer.Font = new Font(_originalPanelLoginContainerFont.FontFamily, newPanelFontSize, _originalPanelLoginContainerFont.Style);
                }

                if (!_originalPanelLoginContainerSize.IsEmpty && _originalPanelLoginContainerSize.Width > 0)
                {
                    int newPanelWidth = (int)(_originalPanelLoginContainerSize.Width * scaleFactorX);
                    int newPanelHeight = (int)(_originalPanelLoginContainerSize.Height * scaleFactorY);

                    newPanelWidth = Math.Max(MinPanelLoginWidth, newPanelWidth);
                    newPanelHeight = Math.Max(MinPanelLoginHeight, newPanelHeight);

                    if (tabPageLogin != null)
                    {
                        newPanelWidth = Math.Min(newPanelWidth, tabPageLogin.ClientSize.Width - panelLoginContainer.Margin.Horizontal);
                        newPanelHeight = Math.Min(newPanelHeight, tabPageLogin.ClientSize.Height - panelLoginContainer.Margin.Vertical);
                    }
                    panelLoginContainer.Size = new Size(Math.Max(10, newPanelWidth), Math.Max(10, newPanelHeight));
                }
            }
            CenterLoginPanel();
        }

        #region Document Issuance Tab Logic

        private void InitializeDocumentIssuanceTab()
        {
            if (dtpRequestDateDI != null) dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI != null && cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
            if (lblStatusValueDI != null) lblStatusValueDI.Text = "Ready to create a new request.";
            if (btnSubmitRequestDI != null) btnSubmitRequestDI.Click += BtnSubmitRequestDI_Click;
            if (btnClearFormDI != null) btnClearFormDI.Click += BtnClearFormDI_Click;

            PopulateYearComboBoxes(cmbParentMfgYearDI, cmbParentExpYearDI, cmbItemMfgYearDI, cmbItemExpYearDI);
            PopulateMonthComboBoxes(cmbParentMfgMonthDI, cmbParentExpMonthDI, cmbItemMfgMonthDI, cmbItemExpMonthDI);
            PopulateUnitComboBoxes(cmbParentBatchSizeUnitDI, cmbItemBatchSizeUnitDI);

            if (chkDocTypeBMRDI != null) chkDocTypeBMRDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            if (chkDocTypeBPRDI != null) chkDocTypeBPRDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            if (chkDocTypeAppendixDI != null) chkDocTypeAppendixDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            if (chkDocTypeAddendumDI != null) chkDocTypeAddendumDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;

            DocTypeCheckBox_CheckedChanged(null, null);
        }

        private void PopulateYearComboBoxes(params ComboBox[] comboBoxes)
        {
            int currentYear = DateTime.Now.Year;
            foreach (var cb in comboBoxes)
            {
                if (cb == null) continue;
                cb.Items.Clear();
                cb.Items.Add("");
                for (int i = currentYear - 10; i <= currentYear + 10; i++)
                {
                    cb.Items.Add(i.ToString());
                }
                cb.SelectedIndex = 0;
            }
        }

        private void PopulateMonthComboBoxes(params ComboBox[] comboBoxes)
        {
            string[] monthAbbr = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            foreach (var cb in comboBoxes)
            {
                if (cb == null) continue;
                cb.Items.Clear();
                cb.Items.Add("");
                cb.Items.AddRange(monthAbbr);
                cb.SelectedIndex = 0;
            }
        }

        private void PopulateUnitComboBoxes(params ComboBox[] comboBoxes)
        {
            string[] units = { "KGS", "TAB", "L", "Units", "g", "mg", "mL", "CAP" };
            foreach (var cb in comboBoxes)
            {
                if (cb == null) continue;
                cb.Items.Clear();
                cb.Items.AddRange(units);
                if (cb.Items.Count > 0) cb.SelectedIndex = 0;
            }
        }

        private void DocTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool bmrChecked = chkDocTypeBMRDI?.Checked ?? false;
            if (lblBmrDocNo != null) lblBmrDocNo.Visible = bmrChecked;
            if (txtBmrDocNoDI != null)
            {
                txtBmrDocNoDI.Visible = bmrChecked;
                if (!bmrChecked) txtBmrDocNoDI.Clear();
            }

            bool bprChecked = chkDocTypeBPRDI?.Checked ?? false;
            if (lblBprDocNo != null) lblBprDocNo.Visible = bprChecked;
            if (txtBprDocNoDI != null)
            {
                txtBprDocNoDI.Visible = bprChecked;
                if (!bprChecked) txtBprDocNoDI.Clear();
            }

            bool appendixChecked = chkDocTypeAppendixDI?.Checked ?? false;
            if (lblAppendixDocNo != null) lblAppendixDocNo.Visible = appendixChecked;
            if (txtAppendixDocNoDI != null)
            {
                txtAppendixDocNoDI.Visible = appendixChecked;
                if (!appendixChecked) txtAppendixDocNoDI.Clear();
            }

            bool addendumChecked = chkDocTypeAddendumDI?.Checked ?? false;
            if (lblAddendumDocNo != null) lblAddendumDocNo.Visible = addendumChecked;
            if (txtAddendumDocNoDI != null)
            {
                txtAddendumDocNoDI.Visible = addendumChecked;
                if (!addendumChecked) txtAddendumDocNoDI.Clear();
            }
        }

        private void LoadInitialDocumentIssuanceData()
        {
            if (lblTrackerNoValueDI != null) lblTrackerNoValueDI.Text = GenerateNewTrackerNumber();
            if (txtRequestNoValueDI != null) txtRequestNoValueDI.Text = GenerateNewRequestNumber();
        }

        private string GenerateNewTrackerNumber()
        {
            Random rnd = new Random();
            return $"TRK-{DateTime.Now.Year}{DateTime.Now.Month:D2}-{rnd.Next(1000, 9999)}";
        }

        private string GenerateNewRequestNumber()
        {
            Random rnd = new Random();
            return $"REQ-{DateTime.Now:yyyyMMdd}-{rnd.Next(100, 999):D3}";
        }

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox)
        {
            string month = monthComboBox?.SelectedItem?.ToString();
            string year = yearComboBox?.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(year))
            {
                return null;
            }
            return $"{month}/{year}";
        }


        private void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            if (cmbFromDepartmentDI == null || cmbFromDepartmentDI.SelectedItem == null || string.IsNullOrWhiteSpace(cmbFromDepartmentDI.SelectedItem.ToString()))
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
                grpDocTypeDI?.Focus();
                return;
            }

            List<string> specificDocNumbers = new List<string>();
            if (chkDocTypeBMRDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { MessageBox.Show("BMR is checked, please enter BMR Document No.", "Validation Error"); txtBmrDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtBmrDocNoDI.Text);
            }
            if (chkDocTypeBPRDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { MessageBox.Show("BPR is checked, please enter BPR Document No.", "Validation Error"); txtBprDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtBprDocNoDI.Text);
            }
            if (chkDocTypeAppendixDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { MessageBox.Show("Appendix is checked, please enter Appendix Document No.", "Validation Error"); txtAppendixDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtAppendixDocNoDI.Text);
            }
            if (chkDocTypeAddendumDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { MessageBox.Show("Addendum is checked, please enter Addendum Document No.", "Validation Error"); txtAddendumDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtAddendumDocNoDI.Text);
            }
            string combinedDocumentNumbers = string.Join(",", specificDocNumbers);

            string parentBatchSizeString = null;
            if (txtParentBatchSizeValueDI != null && !string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI.Text))
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _))
                {
                    MessageBox.Show("Invalid Parent Batch Size value. Please enter a numeric value.", "Validation Error"); txtParentBatchSizeValueDI.Focus(); return;
                }
                if (cmbParentBatchSizeUnitDI?.SelectedItem == null || string.IsNullOrWhiteSpace(cmbParentBatchSizeUnitDI.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please select a unit for Parent Batch Size.", "Validation Error"); cmbParentBatchSizeUnitDI.Focus(); return;
                }
                parentBatchSizeString = $"{txtParentBatchSizeValueDI.Text} {cmbParentBatchSizeUnitDI.SelectedItem.ToString()}";
            }

            string itemBatchSizeString = null;
            if (txtItemBatchSizeValueDI != null && !string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI.Text))
            {
                if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _))
                {
                    MessageBox.Show("Invalid Item Batch Size value. Please enter a numeric value.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return;
                }
                if (cmbItemBatchSizeUnitDI?.SelectedItem == null || string.IsNullOrWhiteSpace(cmbItemBatchSizeUnitDI.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please select a unit for Item Batch Size.", "Validation Error"); cmbItemBatchSizeUnitDI.Focus(); return;
                }
                itemBatchSizeString = $"{txtItemBatchSizeValueDI.Text} {cmbItemBatchSizeUnitDI.SelectedItem.ToString()}";
            }

            var issuanceData = new
            {
                TrackerNo = lblTrackerNoValueDI?.Text ?? "N/A",
                RequestNo = txtRequestNoValueDI?.Text ?? "N/A",
                RequestDate = dtpRequestDateDI?.Value.Date ?? DateTime.MinValue.Date,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentTypes = selectedDocTypes,
                DocumentNo = combinedDocumentNumbers,
                ParentBatchNumber = txtParentBatchNoDI?.Text,
                ParentBatchSize = parentBatchSizeString,
                ParentMfgDate = GetDateStringFromComboBoxes(cmbParentMfgMonthDI, cmbParentMfgYearDI),
                ParentExpDate = GetDateStringFromComboBoxes(cmbParentExpMonthDI, cmbParentExpYearDI),
                Product = txtProductDI.Text,
                BatchNo = txtBatchNoDI?.Text,
                BatchSize = itemBatchSizeString,
                ItemMfgDate = GetDateStringFromComboBoxes(cmbItemMfgMonthDI, cmbItemMfgYearDI),
                ItemExpDate = GetDateStringFromComboBoxes(cmbItemExpMonthDI, cmbItemExpYearDI),
                Market = txtMarketDI?.Text,
                PackSize = txtPackSizeDI?.Text,
                ExportOrderNo = txtExportOrderNoDI?.Text,
                Remarks = txtRemarksDI?.Text,
                RequestedBy = loggedInUserName ?? (toolStripStatusLabelUser?.Text.Replace("User: ", "").Split('(')[0].Trim() ?? "Unknown")
            };

            try
            {
                Console.WriteLine("--- Document Issuance Request Submitted (Simulated) ---");
                Console.WriteLine($"Tracker No: {issuanceData.TrackerNo}");
                Console.WriteLine($"Request No: {issuanceData.RequestNo}");
                Console.WriteLine($"Request Date: {issuanceData.RequestDate:yyyy-MM-dd}");
                Console.WriteLine($"From Department: {issuanceData.FromDepartment}");
                Console.WriteLine($"Document Types Selected: {issuanceData.DocumentTypes}");
                Console.WriteLine($"Specific Document Nos: {issuanceData.DocumentNo}");
                Console.WriteLine($"Product: {issuanceData.Product}");
                Console.WriteLine($"Batch No: {issuanceData.BatchNo}");
                Console.WriteLine($"Batch Size: {issuanceData.BatchSize}");
                Console.WriteLine($"Item Mfg Date: {issuanceData.ItemMfgDate}");
                Console.WriteLine($"Item Exp Date: {issuanceData.ItemExpDate}");
                Console.WriteLine($"Requested By: {issuanceData.RequestedBy}");


                if (lblStatusValueDI != null)
                {
                    lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                    lblStatusValueDI.ForeColor = Color.Green;
                }
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!\nTracker No: {issuanceData.TrackerNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearDocumentIssuanceForm();
                LoadInitialDocumentIssuanceData();
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
            var selectedTypes = new List<string>();
            if (chkDocTypeBMRDI?.Checked == true) selectedTypes.Add("BMR");
            if (chkDocTypeBPRDI?.Checked == true) selectedTypes.Add("BPR");
            if (chkDocTypeAppendixDI?.Checked == true) selectedTypes.Add("APPENDIX");
            if (chkDocTypeAddendumDI?.Checked == true) selectedTypes.Add("ADDENDUM");
            return string.Join(",", selectedTypes);
        }

        private void BtnClearFormDI_Click(object sender, EventArgs e)
        {
            ClearDocumentIssuanceForm();
            if (lblStatusValueDI != null)
            {
                lblStatusValueDI.Text = "Form cleared. Ready for new request.";
                lblStatusValueDI.ForeColor = SystemColors.ControlText;
            }
            LoadInitialDocumentIssuanceData();
        }

        private void ClearDocumentIssuanceForm()
        {
            if (chkDocTypeBMRDI != null) chkDocTypeBMRDI.Checked = false;
            if (chkDocTypeBPRDI != null) chkDocTypeBPRDI.Checked = false;
            if (chkDocTypeAppendixDI != null) chkDocTypeAppendixDI.Checked = false;
            if (chkDocTypeAddendumDI != null) chkDocTypeAddendumDI.Checked = false;

            if (dtpRequestDateDI != null) dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI != null)
            {
                if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
                else cmbFromDepartmentDI.SelectedItem = null;
            }

            if (txtParentBatchNoDI != null) txtParentBatchNoDI.Clear();
            if (txtParentBatchSizeValueDI != null) txtParentBatchSizeValueDI.Clear();
            if (cmbParentBatchSizeUnitDI != null && cmbParentBatchSizeUnitDI.Items.Count > 0) cmbParentBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbParentMfgMonthDI != null && cmbParentMfgMonthDI.Items.Count > 0) cmbParentMfgMonthDI.SelectedIndex = 0;
            if (cmbParentMfgYearDI != null && cmbParentMfgYearDI.Items.Count > 0) cmbParentMfgYearDI.SelectedIndex = 0;
            if (cmbParentExpMonthDI != null && cmbParentExpMonthDI.Items.Count > 0) cmbParentExpMonthDI.SelectedIndex = 0;
            if (cmbParentExpYearDI != null && cmbParentExpYearDI.Items.Count > 0) cmbParentExpYearDI.SelectedIndex = 0;

            if (txtProductDI != null) txtProductDI.Clear();
            if (txtBatchNoDI != null) txtBatchNoDI.Clear();
            if (txtItemBatchSizeValueDI != null) txtItemBatchSizeValueDI.Clear();
            if (cmbItemBatchSizeUnitDI != null && cmbItemBatchSizeUnitDI.Items.Count > 0) cmbItemBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbItemMfgMonthDI != null && cmbItemMfgMonthDI.Items.Count > 0) cmbItemMfgMonthDI.SelectedIndex = 0;
            if (cmbItemMfgYearDI != null && cmbItemMfgYearDI.Items.Count > 0) cmbItemMfgYearDI.SelectedIndex = 0;
            if (cmbItemExpMonthDI != null && cmbItemExpMonthDI.Items.Count > 0) cmbItemExpMonthDI.SelectedIndex = 0;
            if (cmbItemExpYearDI != null && cmbItemExpYearDI.Items.Count > 0) cmbItemExpYearDI.SelectedIndex = 0;

            if (txtMarketDI != null) txtMarketDI.Clear();
            if (txtPackSizeDI != null) txtPackSizeDI.Clear();
            if (txtExportOrderNoDI != null) txtExportOrderNoDI.Clear();

            if (txtRemarksDI != null) txtRemarksDI.Clear();
            if (lblStatusValueDI != null) lblStatusValueDI.Text = "Form cleared.";
        }
        #endregion Document Issuance Tab Logic

        #region GM Operations Tab Logic

        private void InitializeGmOperationsTab()
        {
            if (dgvGmQueue != null)
            {
                dgvGmQueue.AutoGenerateColumns = false;
                if (dgvGmQueue.Columns["colGmRequestNo"] != null) dgvGmQueue.Columns["colGmRequestNo"].DataPropertyName = "RequestNo";
                if (dgvGmQueue.Columns["colGmRequestDate"] != null) dgvGmQueue.Columns["colGmRequestDate"].DataPropertyName = "RequestDate";
                if (dgvGmQueue.Columns["colGmProduct"] != null) dgvGmQueue.Columns["colGmProduct"].DataPropertyName = "Product";
                if (dgvGmQueue.Columns["colGmDocTypes"] != null)
                {
                    dgvGmQueue.Columns["colGmDocTypes"].DataPropertyName = "DocumentNo";
                    dgvGmQueue.Columns["colGmDocTypes"].HeaderText = "Document No(s).";
                }
                if (dgvGmQueue.Columns["colGmPreparedBy"] != null) dgvGmQueue.Columns["colGmPreparedBy"].DataPropertyName = "PreparedBy";
                if (dgvGmQueue.Columns["colGmRequestedAt"] != null) dgvGmQueue.Columns["colGmRequestedAt"].DataPropertyName = "RequestedAt";

                dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            }
            if (btnGmRefreshList != null) btnGmRefreshList.Click += BtnGmRefreshList_Click;
            if (btnGmAuthorize != null) btnGmAuthorize.Click += BtnGmAuthorize_Click;
            if (btnGmReject != null) btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            if (txtGmComment != null) txtGmComment.Clear();

            if (lblGmQueueTitle != null) lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        private void LoadGmPendingQueue()
        {
            if (dgvGmQueue == null) return;

            var placeholderData = new List<object>
            {
                new { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-5), Product = "Product A (Pharma)", DocumentNo = "BMR-001,APP-001A", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-5).AddHours(2) },
                new { RequestNo = "REQ-20240102-002", RequestDate = DateTime.Now.AddDays(-4), Product = "Product B (Vaccine) - High Priority", DocumentNo = "BPR-002", PreparedBy = "another.requester", RequestedAt = DateTime.Now.AddDays(-4).AddHours(3) },
                new { RequestNo = "REQ-20240103-003", RequestDate = DateTime.Now.AddDays(-3), Product = "Product C (Tablet)", DocumentNo = "ADD-003X,BMR-XYZ,APP-003C", PreparedBy = "test.user", RequestedAt = DateTime.Now.AddDays(-3).AddHours(1) },
                new { RequestNo = "REQ-20240104-005", RequestDate = DateTime.Now.AddDays(-2), Product = "Product D (Syrup)", DocumentNo = "BMR-D005", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-2).AddHours(5) },
                new { RequestNo = "REQ-20240105-006", RequestDate = DateTime.Now.AddDays(-1), Product = "Product E (Ointment)", DocumentNo = "BPR-E006,APP-E006A", PreparedBy = "new.dev", RequestedAt = DateTime.Now.AddDays(-1).AddHours(2) }
            };
            dgvGmQueue.DataSource = placeholderData;

            if (lblGmQueueTitle != null) lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue.Rows.Count})";
            ClearGmSelectedRequestDetails();
            if (txtGmComment != null) txtGmComment.Clear();
        }

        private void ClearGmSelectedRequestDetails()
        {
            Action<Control> clearText = ctrl => { if (ctrl is TextBox tb) tb.Clear(); };

            if (tlpGmRequestDetails != null)
            {
                foreach (Control c in tlpGmRequestDetails.Controls)
                {
                    if (c is TextBox) clearText(c);
                }
            }
        }

        private void DisplayGmSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow == null || selectedRow.IsNewRow)
            {
                ClearGmSelectedRequestDetails();
                return;
            }

            string docNoColumnNameInGrid = "colGmDocTypes";

            Func<string, string> GetValue = (colName) => selectedRow.Cells[colName]?.Value?.ToString() ?? "";
            Func<string, string, string> GetDateValue = (colName, format) =>
                selectedRow.Cells[colName]?.Value != null && selectedRow.Cells[colName].Value is DateTime dt ?
                dt.ToString(format) : (selectedRow.Cells[colName]?.Value?.ToString() ?? "");

            if (txtGmDetailRequestNo != null) txtGmDetailRequestNo.Text = GetValue("colGmRequestNo");
            if (txtGmDetailRequestDate != null) txtGmDetailRequestDate.Text = GetDateValue("colGmRequestDate", "dd-MMM-yyyy");
            if (txtGmDetailProduct != null) txtGmDetailProduct.Text = GetValue("colGmProduct");
            if (txtGmDetailDocTypes != null) txtGmDetailDocTypes.Text = GetValue(docNoColumnNameInGrid);
            if (txtGmDetailPreparedBy != null) txtGmDetailPreparedBy.Text = GetValue("colGmPreparedBy");
            if (txtGmDetailRequestedAt != null) txtGmDetailRequestedAt.Text = GetDateValue("colGmRequestedAt", "dd-MMM-yyyy HH:mm");
            // Populate other details based on the selected request (simulated for now)
            var requestNo = GetValue("colGmRequestNo");
            if (requestNo == "REQ-20240101-001")
            {
                if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Production Department";
                if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = "BATCH-A001";
                if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = "Dec/2023";
                if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = "Nov/2025";
                if (txtGmDetailMarket != null) txtGmDetailMarket.Text = "Domestic";
                if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = "10x10 Blister";
                if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = "Standard request for Product A.";
            }
            else if (requestNo == "REQ-20240102-002")
            {
                if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Packaging Department";
                if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = "BATCH-V002";
                if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = "Jan/2024";
                if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = "Dec/2024";
                if (txtGmDetailMarket != null) txtGmDetailMarket.Text = "Export - EU";
                if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = "1x1 Vial";
                if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = "Urgent: Vaccine shipment for EU market.";
            }
            else
            {
                // Default simulated data for other selections
                if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Production Department (Simulated)";
                if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = $"B{DateTime.Now.Millisecond:D3}";
                if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = DateTime.Now.AddMonths(-1).ToString("MMM/yyyy");
                if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = DateTime.Now.AddYears(1).ToString("MMM/yyyy");
                if (txtGmDetailMarket != null) txtGmDetailMarket.Text = "Domestic (Simulated)";
                if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = "10x10 (Simulated)";
                if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = "This is a critical request, please expedite. (Simulated Requester Comment)";
            }
        }

        private void BtnGmRefreshList_Click(object sender, EventArgs e)
        {
            LoadGmPendingQueue();
        }
        private void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue != null && dgvGmQueue.SelectedRows.Count > 0)
            {
                DisplayGmSelectedRequestDetails(dgvGmQueue.SelectedRows[0]);
                if (txtGmComment != null) txtGmComment.Clear();
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
                MessageBox.Show("Please select a request from the queue to authorize.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string requestNo = txtGmDetailRequestNo?.Text;
            if (string.IsNullOrEmpty(requestNo)) requestNo = "N/A";

            if (MessageBox.Show($"Are you sure you want to authorize request '{requestNo}'?", "Confirm Authorization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' authorized (Simulated).", "Authorization Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGmPendingQueue();
            }
        }
        private void BtnGmReject_Click(object sender, EventArgs e)
        {
            if (dgvGmQueue == null || dgvGmQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request from the queue to reject.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtGmComment != null && string.IsNullOrWhiteSpace(txtGmComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGmComment.Focus();
                return;
            }
            string requestNo = txtGmDetailRequestNo?.Text;
            if (string.IsNullOrEmpty(requestNo)) requestNo = "N/A";

            if (MessageBox.Show($"Are you sure you want to reject request '{requestNo}'?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' rejected (Simulated). Comment: {txtGmComment?.Text}", "Rejection Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGmPendingQueue();
            }
        }
        #endregion GM Operations Tab Logic

        #region QA Tab Logic

        private void SetupTlpQaRequestDetailsRowStyles()
        {
            if (this.tlpQaRequestDetails == null)
            {
                Console.WriteLine("tlpQaRequestDetails is null, cannot set row styles.");
                return;
            }
            if (this.tlpQaRequestDetails.RowCount != 9)
            {
                Console.WriteLine($"tlpQaRequestDetails.RowCount is {this.tlpQaRequestDetails.RowCount}, expected 9. Row styles might not apply correctly.");
            }

            this.tlpQaRequestDetails.RowStyles.Clear(); // Ensure clearing existing if any

            float standardRowHeight = 28F; // Example standard height
            float specialRowHeight = 50F;  // Example height for multi-line textboxes

            // Row 0 to 5 (standard)
            for (int i = 0; i < 6; i++)
            {
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
            }
            // Row 6 (Requester Comments - special)
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight));
            // Row 7 (GM Comments - special)
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight));
            // Row 8 (GM Action Time - standard)
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));

        }

        private void InitializeQaTab()
        {
            if (dgvQaQueue != null)
            {
                dgvQaQueue.AutoGenerateColumns = false;
                if (dgvQaQueue.Columns["colQaRequestNo"] != null) dgvQaQueue.Columns["colQaRequestNo"].DataPropertyName = "RequestNo";
                if (dgvQaQueue.Columns["colQaRequestDate"] != null) dgvQaQueue.Columns["colQaRequestDate"].DataPropertyName = "RequestDate";
                if (dgvQaQueue.Columns["colQaProduct"] != null) dgvQaQueue.Columns["colQaProduct"].DataPropertyName = "Product";
                if (dgvQaQueue.Columns["colQaDocTypes"] != null)
                {
                    dgvQaQueue.Columns["colQaDocTypes"].DataPropertyName = "DocumentNo";
                    dgvQaQueue.Columns["colQaDocTypes"].HeaderText = "Document No(s).";
                }
                if (dgvQaQueue.Columns["colQaPreparedBy"] != null) dgvQaQueue.Columns["colQaPreparedBy"].DataPropertyName = "PreparedBy";
                if (dgvQaQueue.Columns["colQaAuthorizedBy"] != null) dgvQaQueue.Columns["colQaAuthorizedBy"].DataPropertyName = "AuthorizedBy";
                if (dgvQaQueue.Columns["colQaGmActionAt"] != null) dgvQaQueue.Columns["colQaGmActionAt"].DataPropertyName = "GmActionAt";

                dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;
            }
            if (btnQaRefreshList != null) btnQaRefreshList.Click += BtnQaRefreshList_Click;
            if (btnQaApprove != null) btnQaApprove.Click += BtnQaApprove_Click;
            if (btnQaReject != null) btnQaReject.Click += BtnQaReject_Click;
            if (btnQaBrowseSelectDocument != null) btnQaBrowseSelectDocument.Click += BtnQaBrowseSelectDocument_Click;


            ClearQaSelectedRequestDetails();
            if (txtQaComment != null) txtQaComment.Clear();
            if (numQaPrintCount != null) numQaPrintCount.Value = 1;

            if (lblQaQueueTitle != null) lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }
        private void BtnQaBrowseSelectDocument_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Functionality to open document location or select a document to be implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadQaPendingQueue()
        {
            if (dgvQaQueue == null) return;

            var placeholderQaData = new List<object>
            {
                new { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-5), Product = "Product A (Pharma)", DocumentNo = "BMR-001,APP-001A", PreparedBy = "user.requester", AuthorizedBy = "gm.user", GmActionAt = DateTime.Now.AddDays(-2).AddHours(1) },
                new { RequestNo = "REQ-20240104-004", RequestDate = DateTime.Now.AddDays(-2), Product = "Product D (Syrup)", DocumentNo = "BPR-004,ADD-004Y", PreparedBy = "another.user", AuthorizedBy = "gm.user", GmActionAt = DateTime.Now.AddDays(-1).AddHours(4) },
                new { RequestNo = "REQ-20240106-007", RequestDate = DateTime.Now.AddDays(-3), Product = "Product F (Capsule)", DocumentNo = "BMR-F007,BPR-F007", PreparedBy = "test.user", AuthorizedBy = "another.gm", GmActionAt = DateTime.Now.AddDays(-2).AddHours(3) },
                new { RequestNo = "REQ-20240107-008", RequestDate = DateTime.Now.AddDays(-1), Product = "Product G (Cream)", DocumentNo = "BMR-G008", PreparedBy = "user.requester", AuthorizedBy = "gm.user", GmActionAt = DateTime.Now.AddHours(-5) }
            };
            dgvQaQueue.DataSource = placeholderQaData;

            if (lblQaQueueTitle != null) lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue.Rows.Count})";
            ClearQaSelectedRequestDetails();
            if (txtQaComment != null) txtQaComment.Clear();
            if (numQaPrintCount != null) numQaPrintCount.Value = 1;
        }

        private void ClearQaSelectedRequestDetails()
        {
            Action<Control> clearText = ctrl => { if (ctrl is TextBox tb) tb.Clear(); };

            if (tlpQaRequestDetails != null)
            {
                foreach (Control c in tlpQaRequestDetails.Controls)
                {
                    if (c is TextBox) clearText(c);
                }
            }
        }

        private void DisplayQaSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow == null || selectedRow.IsNewRow)
            {
                ClearQaSelectedRequestDetails();
                return;
            }

            string docNoColumnNameInGrid = "colQaDocTypes";

            Func<string, string> GetValue = (colName) => selectedRow.Cells[colName]?.Value?.ToString() ?? "";
            Func<string, string, string> GetDateValue = (colName, format) =>
                selectedRow.Cells[colName]?.Value != null && selectedRow.Cells[colName].Value is DateTime dt ?
                dt.ToString(format) : (selectedRow.Cells[colName]?.Value?.ToString() ?? "");

            if (txtQaDetailRequestNo != null) txtQaDetailRequestNo.Text = GetValue("colQaRequestNo");
            if (txtQaDetailRequestDate != null) txtQaDetailRequestDate.Text = GetDateValue("colQaRequestDate", "dd-MMM-yyyy");
            if (txtQaDetailProduct != null) txtQaDetailProduct.Text = GetValue("colQaProduct");
            if (txtQaDetailDocTypes != null) txtQaDetailDocTypes.Text = GetValue(docNoColumnNameInGrid);
            if (txtQaDetailPreparedBy != null) txtQaDetailPreparedBy.Text = GetValue("colQaPreparedBy");
            // GM User for QA details (assuming colQaAuthorizedBy has GM's name)
            // txtQaDetailAuthorizedByGM.Text = GetValue("colQaAuthorizedBy"); // Need a new TextBox if separate display for GM who authorized
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Text = GetDateValue("colQaGmActionAt", "dd-MMM-yyyy HH:mm");
            // Simulated data for other fields - you might want to fetch this from a related data source in a real app
            var requestNo = GetValue("colQaRequestNo");
            if (requestNo == "REQ-20240101-001")
            {
                if (txtQaDetailFromDept != null) txtQaDetailFromDept.Text = "Production";
                if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Text = "BATCH-A001";
                if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = "Dec/2023";
                if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = "Nov/2025";
                if (txtQaDetailMarket != null) txtQaDetailMarket.Text = "Domestic";
                if (txtQaDetailPackSize != null) txtQaDetailPackSize.Text = "10x10 Blister";
                if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Text = "Standard request.";
                if (txtQaDetailGmComment != null) txtQaDetailGmComment.Text = "Authorized by GM. Proceed.";
            }
            else
            {
                if (txtQaDetailFromDept != null) txtQaDetailFromDept.Text = "Packaging (Simulated)";
                if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Text = $"B-QA{DateTime.Now.Millisecond % 100:D2}";
                if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = DateTime.Now.AddDays(-45).ToString("MMM/yyyy");
                if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = DateTime.Now.AddYears(1).AddMonths(6).ToString("MMM/yyyy");
                if (txtQaDetailMarket != null) txtQaDetailMarket.Text = "Export - US (Simulated)";
                if (txtQaDetailPackSize != null) txtQaDetailPackSize.Text = "100 Count Bottle (Simulated)";
                if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Text = "Follow up on previous comments.";
                if (txtQaDetailGmComment != null) txtQaDetailGmComment.Text = "GM approved with minor note on urgency.";
            }
        }

        private void BtnQaRefreshList_Click(object sender, EventArgs e)
        {
            LoadQaPendingQueue();
        }
        private void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue != null && dgvQaQueue.SelectedRows.Count > 0)
            {
                DisplayQaSelectedRequestDetails(dgvQaQueue.SelectedRows[0]);
                if (txtQaComment != null) txtQaComment.Clear();
                if (numQaPrintCount != null) numQaPrintCount.Value = 1;
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
                MessageBox.Show("Please select a request from the queue to approve.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string requestNo = txtQaDetailRequestNo?.Text;
            if (string.IsNullOrEmpty(requestNo)) requestNo = "N/A";

            int printCount = 1;
            if (numQaPrintCount != null) printCount = (int)numQaPrintCount.Value;


            if (MessageBox.Show($"Are you sure you want to approve request '{requestNo}'?\nPrint Count: {printCount}", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' approved (Simulated). Printed {printCount} copies.", "Approval Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQaPendingQueue();
            }
        }
        private void BtnQaReject_Click(object sender, EventArgs e)
        {
            if (dgvQaQueue == null || dgvQaQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request from the queue to reject.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtQaComment != null && string.IsNullOrWhiteSpace(txtQaComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQaComment.Focus();
                return;
            }
            string requestNo = txtQaDetailRequestNo?.Text;
            if (string.IsNullOrEmpty(requestNo)) requestNo = "N/A";

            if (MessageBox.Show($"Are you sure you want to reject request '{requestNo}'?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' rejected (Simulated). Comment: {txtQaComment?.Text}", "Rejection Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQaPendingQueue();
            }
        }

        #endregion QA Tab Logic

        #region Audit Trail Tab Logic

        private void InitializeAuditTrailTab()
        {
            if (cmbAuditStatus != null)
            {
                cmbAuditStatus.Items.Clear();
                cmbAuditStatus.Items.AddRange(new object[] {
                    "All",
                    "Pending GM Approval",
                    "Pending QA Approval",
                    "Approved (Issued)",
                    "Rejected by GM",
                    "Rejected by QA"
                });
                if (cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            }
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30); // Wider default range
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now.Date;

            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.AutoGenerateColumns = false;
                dgvAuditTrail.ReadOnly = true;
                dgvAuditTrail.AllowUserToAddRows = false;
                dgvAuditTrail.AllowUserToDeleteRows = false;
                dgvAuditTrail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvAuditTrail.ScrollBars = ScrollBars.Both;
                dgvAuditTrail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                SetupAuditTrailColumns();
                dgvAuditTrail.DataError += DgvAuditTrail_DataError;
            }

            if (btnApplyAuditFilter != null) btnApplyAuditFilter.Click += BtnApplyAuditFilter_Click;
            if (btnClearAuditFilters != null) btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            if (btnRefreshAuditList != null) btnRefreshAuditList.Click += BtnRefreshAuditList_Click;
            if (btnExportToCsv != null) btnExportToCsv.Click += BtnExportToCsv_Click;
            if (btnExportToExcel != null) btnExportToExcel.Click += BtnExportToExcel_Click;

        }

        private void DgvAuditTrail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"DataGridView DataError: Row {e.RowIndex}, Column {e.ColumnIndex} ('{dgvAuditTrail.Columns[e.ColumnIndex].Name}'). Exception: {e.Exception.Message}");
            // Suppress the default error dialog if desired, or log more gracefully.
            // e.Cancel = true; // If you want to suppress the default DataGridView error dialog
            MessageBox.Show($"Error displaying data in the audit trail at row {e.RowIndex + 1}, column '{dgvAuditTrail.Columns[e.ColumnIndex].HeaderText}'.\nDetails: {e.Exception.Message}", "Data Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetupAuditTrailColumns()
        {
            if (dgvAuditTrail == null) return;
            dgvAuditTrail.Columns.Clear();

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120, Frozen = true });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = "Product", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocumentNumbers", HeaderText = "Document No(s).", DataPropertyName = "DocumentNumbers", Width = 180, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditStatusDerived", HeaderText = "Status", DataPropertyName = "DerivedStatus", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditPreparedBy", HeaderText = "Prepared By", DataPropertyName = "PreparedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestedAt", HeaderText = "Requested At", DataPropertyName = "RequestedAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmAction", HeaderText = "GM Action", DataPropertyName = "GmOperationsAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditAuthorizedBy", HeaderText = "GM User", DataPropertyName = "AuthorizedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmActionAt", HeaderText = "GM Action At", DataPropertyName = "GmOperationsAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmComment", HeaderText = "GM Comment", DataPropertyName = "GmOperationsComment", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaAction", HeaderText = "QA Action", DataPropertyName = "QAAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditApprovedBy", HeaderText = "QA User", DataPropertyName = "ApprovedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaActionAt", HeaderText = "QA Action At", DataPropertyName = "QAAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaComment", HeaderText = "QA Comment", DataPropertyName = "QAComment", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });
        }

        private void LoadAuditTrailData()
        {
            if (dgvAuditTrail == null) return;

            DateTime fromDate = dtpAuditFrom?.Value.Date ?? DateTime.MinValue;
            DateTime toDate = dtpAuditTo?.Value.Date.AddDays(1).AddTicks(-1) ?? DateTime.MaxValue;
            string statusFilter = cmbAuditStatus?.SelectedItem?.ToString() ?? "All";
            string requestNoFilter = txtAuditRequestNo?.Text.Trim() ?? "";
            string productFilter = txtAuditProduct?.Text.Trim() ?? "";

            var allPlaceholderAuditData = new List<AuditTrailEntry>
            {
                new AuditTrailEntry { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-10), Product = "Product A (Pharma)", DocumentNumbers = "BMR-001,APP-001A", DerivedStatus = "Approved (Issued)", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-10).AddHours(1), GmOperationsAction = "Authorized", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-9), GmOperationsComment = "Looks good. Standard procedure.", QAAction = "Approved", ApprovedBy = "qa.lead", QAAt = DateTime.Now.AddDays(-8), QAComment = "Verified and issued. All checks passed." },
                new AuditTrailEntry { RequestNo = "REQ-20240102-002", RequestDate = DateTime.Now.AddDays(-5), Product = "Product B (Vaccine)", DocumentNumbers = "BPR-002", DerivedStatus = "Rejected by GM", PreparedBy = "another.requester", RequestedAt = DateTime.Now.AddDays(-5).AddHours(2), GmOperationsAction = "Rejected", AuthorizedBy = "gm.head", GmOperationsAt = DateTime.Now.AddDays(-4), GmOperationsComment = "Business case not valid for this quarter. Re-evaluate next cycle." },
                new AuditTrailEntry { RequestNo = "REQ-20240104-004", RequestDate = DateTime.Now.AddDays(-2), Product = "Product D (Syrup)", DocumentNumbers = "BPR-004,ADD-004Y,APP-004S", DerivedStatus = "Pending QA Approval", PreparedBy = "another.user", RequestedAt = DateTime.Now.AddDays(-2).AddHours(1), GmOperationsAction = "Authorized", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-1), GmOperationsComment = "Approved by GM. Ensure all addendums are cross-checked by QA." },
                new AuditTrailEntry { RequestNo = "REQ-20240115-005", RequestDate = DateTime.Now.AddDays(-1), Product = "Product E (Injectable)", DocumentNumbers = "BMR-E05", DerivedStatus = "Pending GM Approval", PreparedBy = "new.user", RequestedAt = DateTime.Now.AddDays(-1).AddHours(3) },
                new AuditTrailEntry { RequestNo = "REQ-20231220-090", RequestDate = DateTime.Now.AddDays(-25), Product = "Product Z (Old Batch)", DocumentNumbers = "BMR-Z090,BPR-Z090", DerivedStatus = "Approved (Issued)", PreparedBy = "legacy.user", RequestedAt = DateTime.Now.AddDays(-25).AddHours(1), GmOperationsAction = "Authorized", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-24), GmOperationsComment = "Routine approval.", QAAction = "Approved", ApprovedBy = "qa.user", QAAt = DateTime.Now.AddDays(-23), QAComment = "Issued." },
                new AuditTrailEntry { RequestNo = "REQ-20240106-007", RequestDate = DateTime.Now.AddDays(-9), Product = "Product F (Capsule)", DocumentNumbers = "BMR-F007,BPR-F007", DerivedStatus = "Rejected by QA", PreparedBy = "test.user", RequestedAt = DateTime.Now.AddDays(-9).AddHours(2), GmOperationsAction = "Authorized", AuthorizedBy = "another.gm", GmOperationsAt = DateTime.Now.AddDays(-8).AddHours(1), GmOperationsComment = "GM authorized.", QAAction="Rejected", ApprovedBy="qa.lead", QAAt=DateTime.Now.AddDays(-7), QAComment="Discrepancy found in section 3.2 of BPR. Needs correction." },
                new AuditTrailEntry { RequestNo = "REQ-20240107-008", RequestDate = DateTime.Now.AddDays(-1), Product = "Product G (Cream)", DocumentNumbers = "BMR-G008", DerivedStatus = "Pending QA Approval", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-1).AddHours(6), GmOperationsAction="Authorized", AuthorizedBy="gm.user", GmOperationsAt=DateTime.Now.AddHours(-5), GmOperationsComment="Urgent request, approved." }
            };

            IEnumerable<AuditTrailEntry> filteredData = allPlaceholderAuditData;

            if (statusFilter != "All")
            {
                filteredData = filteredData.Where(entry => entry.DerivedStatus == statusFilter);
            }
            if (!string.IsNullOrEmpty(requestNoFilter))
            {
                filteredData = filteredData.Where(entry => entry.RequestNo.ToLower().Contains(requestNoFilter.ToLower()));
            }
            if (!string.IsNullOrEmpty(productFilter))
            {
                filteredData = filteredData.Where(entry => entry.Product.ToLower().Contains(productFilter.ToLower()));
            }
            filteredData = filteredData.Where(entry => entry.RequestDate >= fromDate && entry.RequestDate <= toDate);


            dgvAuditTrail.DataSource = null;
            dgvAuditTrail.DataSource = filteredData.ToList();
        }

        private void BtnApplyAuditFilter_Click(object sender, EventArgs e) { LoadAuditTrailData(); }
        private void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now.Date;
            if (cmbAuditStatus != null && cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            if (txtAuditRequestNo != null) txtAuditRequestNo.Clear();
            if (txtAuditProduct != null) txtAuditProduct.Clear();
            LoadAuditTrailData();
        }
        private void BtnRefreshAuditList_Click(object sender, EventArgs e)
        {
            LoadAuditTrailData();
        }
        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail == null || dgvAuditTrail.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = $"AuditTrail_{DateTime.Now:yyyyMMddHHmmss}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        var headers = dgvAuditTrail.Columns.Cast<DataGridViewColumn>()
                                         .Select(column => $"\"{EscapeCsvField(column.HeaderText)}\"");
                        sb.AppendLine(string.Join(",", headers));

                        foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = row.Cells.Cast<DataGridViewCell>()
                                         .Select(cell => $"\"{EscapeCsvField(cell.FormattedValue?.ToString())}\"");
                            sb.AppendLine(string.Join(",", cells));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Audit trail data exported successfully to CSV.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";
            return field.Replace("\"", "\"\"");
        }
        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel export functionality is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Audit Trail Tab Logic

        #region Users Tab Logic

        private void InitializeUsersTab()
        {
            this.userRolesBindingSource = new BindingSource();
            if (dgvUserRoles != null)
            {
                dgvUserRoles.AutoGenerateColumns = false;
                dgvUserRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUserRoles.MultiSelect = false;
                dgvUserRoles.AllowUserToAddRows = false;
                dgvUserRoles.AllowUserToDeleteRows = false;
                dgvUserRoles.ReadOnly = true; // Grid itself is read-only, editing happens in dedicated fields

                if (dgvUserRoles.Columns["colUserRoleId"] != null) dgvUserRoles.Columns["colUserRoleId"].DataPropertyName = "RoleID";
                if (dgvUserRoles.Columns["colUserRoleName"] != null) dgvUserRoles.Columns["colUserRoleName"].DataPropertyName = "RoleName";

                dgvUserRoles.DataSource = this.userRolesBindingSource;
                dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            }

            if (btnAddRole != null) btnAddRole.Click += BtnAddRole_Click;
            if (btnEditRole != null) btnEditRole.Click += BtnEditRole_Click;
            if (btnDeleteRole != null) btnDeleteRole.Click += BtnDeleteRole_Click;
            if (btnRefreshUserRoles != null) btnRefreshUserRoles.Click += BtnRefreshUserRoles_Click;

            if (txtRoleNameManage != null)
            {
                txtRoleNameManage.Clear();
                txtRoleNameManage.ReadOnly = true; // Ensure it's read-only initially
            }

            // Initial button states for "None" mode
            if (btnAddRole != null) btnAddRole.Enabled = true;
            if (btnEditRole != null) btnEditRole.Enabled = false;
            if (btnDeleteRole != null) btnDeleteRole.Enabled = false;

            _currentUsersTabMode = UserManagementMode.None; // Explicitly set mode
        }

        private void LoadUserRoles()
        {
            if (this.userRolesBindingSource == null) return;

            var placeholderRoles = new List<UserRole>
            {
                new UserRole { RoleID = 1, RoleName = "Requester" },
                new UserRole { RoleID = 2, RoleName = "GM_Operations" },
                new UserRole { RoleID = 3, RoleName = "QA" },
                new UserRole { RoleID = 4, RoleName = "Admin" },
                new UserRole { RoleID = 5, RoleName = "Supervisor" },
                new UserRole { RoleID = 6, RoleName = "Auditor" }
            };

            this.userRolesBindingSource.DataSource = null;
            this.userRolesBindingSource.DataSource = placeholderRoles;

            // Reset the mode and UI elements after loading/reloading data
            ResetUserManagementToNoneMode();
        }

        private void DgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (_currentUsersTabMode != UserManagementMode.None)
            {
                // If in Add/Edit mode, primary button enablement is handled by mode switching logic,
                // and text box content is managed separately.
                return;
            }

            bool roleSelected = dgvUserRoles != null && dgvUserRoles.SelectedRows.Count > 0;
            UserRole selectedUserRole = null;

            if (roleSelected)
            {
                selectedUserRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
            }

            if (txtRoleNameManage != null)
            {
                txtRoleNameManage.Text = selectedUserRole?.RoleName ?? "";
            }

            // Enable/disable Edit and Delete buttons based on selection in "None" mode
            if (btnEditRole != null) btnEditRole.Enabled = roleSelected;
            if (btnDeleteRole != null) btnDeleteRole.Enabled = roleSelected;
            // btnAddRole is always enabled in "None" mode (or handled by ResetUserManagementToNoneMode)
        }

        private void ResetUserManagementToNoneMode()
        {
            _currentUsersTabMode = UserManagementMode.None;
            _roleBeingEdited = null;

            if (txtRoleNameManage != null)
            {
                txtRoleNameManage.ReadOnly = true;
            }

            if (btnAddRole != null)
            {
                btnAddRole.Text = "Add Role";
                btnAddRole.Enabled = true;
            }
            if (btnEditRole != null)
            {
                btnEditRole.Text = "Edit Role";
                // Enablement handled by DgvUserRoles_SelectionChanged
            }

            if (dgvUserRoles != null)
            {
                dgvUserRoles.Enabled = true;
            }

            // Refresh text box and button states based on current grid selection
            DgvUserRoles_SelectionChanged(null, null);
        }

        private bool IsRoleNameUnique(string roleName, int currentRoleIdToExclude = -1)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return false;

            var rolesList = this.userRolesBindingSource.DataSource as List<UserRole>;
            if (rolesList == null) return true;

            return !rolesList.Any(r => r.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase) && r.RoleID != currentRoleIdToExclude);
        }

        private void BtnRefreshUserRoles_Click(object sender, EventArgs e) { LoadUserRoles(); }

        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            switch (_currentUsersTabMode)
            {
                case UserManagementMode.None: // User clicked "Add Role"
                    _currentUsersTabMode = UserManagementMode.Adding;
                    _roleBeingEdited = null;

                    if (txtRoleNameManage != null)
                    {
                        txtRoleNameManage.Clear();
                        txtRoleNameManage.ReadOnly = false;
                    }

                    if (btnAddRole != null) btnAddRole.Text = "Save New";
                    if (btnEditRole != null)
                    {
                        btnEditRole.Text = "Cancel Add";
                        btnEditRole.Enabled = true;
                    }
                    if (btnDeleteRole != null) btnDeleteRole.Enabled = false;
                    if (dgvUserRoles != null)
                    {
                        dgvUserRoles.Enabled = false;
                        dgvUserRoles.ClearSelection();
                    }
                    txtRoleNameManage?.Focus();
                    break;

                case UserManagementMode.Adding: // User clicked "Save New"
                    string newRoleName = txtRoleNameManage.Text.Trim();
                    if (string.IsNullOrWhiteSpace(newRoleName))
                    {
                        MessageBox.Show("Role name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRoleNameManage.Focus();
                        return;
                    }

                    if (!IsRoleNameUnique(newRoleName))
                    {
                        MessageBox.Show($"Role name '{newRoleName}' already exists. Please enter a unique name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRoleNameManage.Focus();
                        return;
                    }

                    var rolesListAdd = this.userRolesBindingSource.DataSource as List<UserRole>;
                    if (rolesListAdd != null)
                    {
                        int maxId = 0;
                        if (rolesListAdd.Any()) maxId = rolesListAdd.Max(r => r.RoleID);

                        var newRole = new UserRole { RoleID = maxId + 1, RoleName = newRoleName };
                        rolesListAdd.Add(newRole);
                        this.userRolesBindingSource.ResetBindings(false);

                        foreach (DataGridViewRow row in dgvUserRoles.Rows)
                        {
                            if (row.DataBoundItem is UserRole item && item.RoleID == newRole.RoleID)
                            {
                                row.Selected = true;
                                dgvUserRoles.CurrentCell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                                break;
                            }
                        }
                        MessageBox.Show($"Role '{newRoleName}' added successfully (Simulated).", "Role Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ResetUserManagementToNoneMode();
                    break;

                case UserManagementMode.Editing: // User clicked "Cancel Edit" (btnAddRole was repurposed)
                    ResetUserManagementToNoneMode();
                    break;
            }
        }

        private void BtnEditRole_Click(object sender, EventArgs e)
        {
            switch (_currentUsersTabMode)
            {
                case UserManagementMode.None: // User clicked "Edit Role"
                    if (dgvUserRoles.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select a role from the list to edit.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _roleBeingEdited = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
                    if (_roleBeingEdited == null)
                    {
                        MessageBox.Show("Selected role data is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _currentUsersTabMode = UserManagementMode.Editing;

                    if (txtRoleNameManage != null)
                    {
                        txtRoleNameManage.ReadOnly = false;
                    }

                    if (btnEditRole != null) btnEditRole.Text = "Save Changes";
                    if (btnAddRole != null)
                    {
                        btnAddRole.Text = "Cancel Edit";
                        btnAddRole.Enabled = true;
                    }
                    if (btnDeleteRole != null) btnDeleteRole.Enabled = false;
                    if (dgvUserRoles != null) dgvUserRoles.Enabled = false;

                    txtRoleNameManage?.Focus();
                    txtRoleNameManage?.SelectAll();
                    break;

                case UserManagementMode.Editing: // User clicked "Save Changes"
                    if (_roleBeingEdited == null)
                    {
                        MessageBox.Show("No role selected for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetUserManagementToNoneMode();
                        return;
                    }
                    string updatedRoleName = txtRoleNameManage.Text.Trim();
                    if (string.IsNullOrWhiteSpace(updatedRoleName))
                    {
                        MessageBox.Show("Role name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRoleNameManage.Focus();
                        return;
                    }
                    if (!IsRoleNameUnique(updatedRoleName, _roleBeingEdited.RoleID))
                    {
                        MessageBox.Show($"Role name '{updatedRoleName}' already exists. Please enter a unique name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRoleNameManage.Focus();
                        return;
                    }

                    _roleBeingEdited.RoleName = updatedRoleName;
                    this.userRolesBindingSource.ResetBindings(false);
                    MessageBox.Show($"Role '{updatedRoleName}' updated successfully (Simulated).", "Role Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int rowIndexToSelect = -1;
                    for (int i = 0; i < dgvUserRoles.Rows.Count; i++)
                    {
                        if (dgvUserRoles.Rows[i].DataBoundItem is UserRole item && item.RoleID == _roleBeingEdited.RoleID)
                        {
                            rowIndexToSelect = i;
                            break;
                        }
                    }

                    ResetUserManagementToNoneMode();

                    if (rowIndexToSelect != -1 && dgvUserRoles.Rows.Count > rowIndexToSelect)
                    {
                        dgvUserRoles.ClearSelection();
                        dgvUserRoles.Rows[rowIndexToSelect].Selected = true;
                        dgvUserRoles.CurrentCell = dgvUserRoles.Rows[rowIndexToSelect].Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                    }
                    break;

                case UserManagementMode.Adding: // User clicked "Cancel Add" (btnEditRole was repurposed)
                    ResetUserManagementToNoneMode();
                    break;
            }
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if (_currentUsersTabMode != UserManagementMode.None) return; // Do not allow delete during add/edit

            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role from the list to delete.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserRole selectedUserRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
            string roleNameToDelete = selectedUserRole != null ? $"'{selectedUserRole.RoleName}'" : "the selected role";

            if (MessageBox.Show($"Are you sure you want to delete {roleNameToDelete}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (selectedUserRole != null)
                {
                    // Simulate deletion from data source
                    var rolesListDelete = this.userRolesBindingSource.DataSource as List<UserRole>;
                    if (rolesListDelete != null)
                    {
                        rolesListDelete.Remove(selectedUserRole);
                        this.userRolesBindingSource.ResetBindings(false);
                        MessageBox.Show($"Role {roleNameToDelete} (ID: {selectedUserRole.RoleID}) deleted (Simulated).", "Role Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // LoadUserRoles(); // Or just ResetBindings if data source is directly manipulated.
                        // ResetUserManagementToNoneMode() will be called by LoadUserRoles or after ResetBindings
                        DgvUserRoles_SelectionChanged(null, null); // Update selection and button states
                    }
                }
                else
                {
                    MessageBox.Show("Could not delete role: selected role data is unavailable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion Users Tab Logic
    }
}