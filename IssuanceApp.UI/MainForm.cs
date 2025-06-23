using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using System.Configuration; // Required for App.config
using IssuanceApp.Data;     // Required to reference the Data project

namespace DocumentIssuanceApp
{
    public partial class MainForm : Form
    {
        private readonly IssuanceRepository _repository; // The single instance of our data repository
        private Timer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null;

        private BindingSource userRolesBindingSource;

        private List<TabPage> allTabPages;
        private ToolStripDropDownButton toolStripDropDownButtonUserActions;
        private ToolStripMenuItem signOutToolStripMenuItem;

        // Flags for lazy loading tab data
        private bool _gmDataLoaded = false;
        private bool _qaDataLoaded = false;
        private bool _auditDataLoaded = false;
        private bool _usersDataLoaded = false;

        // --- LOW MEMORY VIRTUAL MODE ---
        private List<int> _auditTrailKeyCache;
        private AuditTrailEntry _currentAuditRowCache;
        private int _currentAuditRowCacheIndex = -1;
        private SortOrder _auditSortOrder = SortOrder.None;
        private string _auditSortColumn = string.Empty;


        public MainForm()
        {
            InitializeComponent();

            // Read connection string from App.config and create the repository
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["IssuanceAppDB"].ConnectionString;
                _repository = new IssuanceRepository(connStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read database configuration. The application will now close.\n\nError: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Load += (s, e) => Close(); // Schedule form to close after it's shown
                return;
            }

            // Enable Double Buffering for smoother rendering
            EnableDoubleBuffering();

            InitializeDynamicControls();

            // Set up form properties and timers
            this.Text = "Document Issuance System";
            statusTimer = new Timer { Interval = 1000 };
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            this.tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            // Initialize all UI components and states
            SetupStatusBar();
            InitializeLoginTab();
            InitializeDocumentIssuanceTab();
            InitializeGmOperationsTab();
            InitializeQaTab();
            InitializeAuditTrailTab();
            InitializeUsersTab();

            SetupTabs(); // Hides all tabs initially

            this.WindowState = FormWindowState.Maximized;
        }

        private void EnableDoubleBuffering()
        {
            if (dgvGmQueue != null)
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, dgvGmQueue, new object[] { true });
            if (dgvQaQueue != null)
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, dgvQaQueue, new object[] { true });
            if (dgvAuditTrail != null)
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, dgvAuditTrail, new object[] { true });
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == null) return;
            string selectedTabName = tabControlMain.SelectedTab.Name;

            if (selectedTabName == nameof(tabPageGmOperations) && !_gmDataLoaded)
            {
                LoadGmPendingQueue();
                _gmDataLoaded = true;
            }
            else if (selectedTabName == nameof(tabPageQa) && !_qaDataLoaded)
            {
                LoadQaPendingQueue();
                _qaDataLoaded = true;
            }
            else if (selectedTabName == nameof(tabPageAuditTrail) && !_auditDataLoaded)
            {
                LoadAuditTrailData();
                _auditDataLoaded = true;
            }
            else if (selectedTabName == nameof(tabPageUsers) && !_usersDataLoaded)
            {
                LoadUserRoles();
                _usersDataLoaded = true;
            }
        }

        private void InitializeDynamicControls()
        {
            allTabPages = new List<TabPage>();
            foreach (TabPage tp in tabControlMain.TabPages)
            {
                allTabPages.Add(tp);
            }

            this.toolStripDropDownButtonUserActions = new ToolStripDropDownButton();
            this.signOutToolStripMenuItem = new ToolStripMenuItem();

            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += SignOutToolStripMenuItem_Click;

            this.toolStripDropDownButtonUserActions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonUserActions.DropDownItems.AddRange(new ToolStripItem[] { this.signOutToolStripMenuItem });
            this.toolStripDropDownButtonUserActions.Name = "toolStripDropDownButtonUserActions";
            this.toolStripDropDownButtonUserActions.Size = new System.Drawing.Size(90, 24);
            this.toolStripDropDownButtonUserActions.Text = "User Actions";
            this.toolStripDropDownButtonUserActions.Visible = false;

            this.statusStripMain.Items.Insert(1, this.toolStripDropDownButtonUserActions);
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out and exit the application?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SetupStatusBar()
        {
            string osUserDisplay = "Unknown User";
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                if (currentUser != null && !string.IsNullOrEmpty(currentUser.Name))
                {
                    string fullUserName = currentUser.Name;
                    osUserDisplay = fullUserName.Split('\\').LastOrDefault() ?? fullUserName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting OS username: " + ex.Message);
                osUserDisplay = "N/A (Error)";
            }
            this.loggedInUserName = osUserDisplay;
            toolStripStatusLabelUser.Text = $"User: {osUserDisplay} (Not Logged In)";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        #region Login and Role Management
        private void InitializeLoginTab()
        {
            if (cmbRole == null || txtPassword == null || btnLogin == null) return;

            cmbRole.Items.Clear();
            try
            {
                List<string> roleNames = _repository.GetRoleNames();
                cmbRole.Items.AddRange(roleNames.ToArray());
                if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load user roles from the database. Please check the connection.\n" + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnLogin.Enabled = false;
            }

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

            try
            {
                bool isAuthenticated = _repository.AuthenticateUser(selectedRole, password);
                if (isAuthenticated)
                {
                    loggedInRole = selectedRole;
                    toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";
                    lblLoginStatus.Text = $"Login successful as {loggedInRole}.";
                    lblLoginStatus.ForeColor = Color.Green;
                    txtPassword.Clear();

                    _gmDataLoaded = _qaDataLoaded = _auditDataLoaded = _usersDataLoaded = false;

                    EnableTabsBasedOnRole(loggedInRole);
                    SwitchToDefaultTabForRole(loggedInRole);
                }
                else
                {
                    lblLoginStatus.Text = "Invalid role or password.";
                    lblLoginStatus.ForeColor = Color.Red;
                    loggedInRole = null;
                    SetupStatusBar();
                    EnableTabsBasedOnRole(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableTabsBasedOnRole(string role)
        {
            bool isLoggedIn = !string.IsNullOrEmpty(role);
            if (toolStripDropDownButtonUserActions != null)
                toolStripDropDownButtonUserActions.Visible = isLoggedIn;

            tabControlMain.TabPages.Clear();

            if (!isLoggedIn)
            {
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin));
                if (loginTab != null) tabControlMain.TabPages.Add(loginTab);
                return;
            }

            bool isAdmin = (role == "Admin");
            bool isRequester = (role == "Requester");
            bool isGm = (role == "GM_Operations");
            bool isQa = (role == "QA");

            foreach (var tab in allTabPages)
            {
                bool shouldShowTab =
                    (tab.Name == nameof(tabPageDocumentIssuance) && (isRequester || isAdmin)) ||
                    (tab.Name == nameof(tabPageGmOperations) && (isGm || isAdmin)) ||
                    (tab.Name == nameof(tabPageQa) && (isQa || isAdmin)) ||
                    (tab.Name == nameof(tabPageUsers) && isAdmin) ||
                    (tab.Name == nameof(tabPageAuditTrail)); // Always show audit for any logged-in user

                if (shouldShowTab)
                {
                    tabControlMain.TabPages.Add(tab);
                }
            }
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            TabPage targetTab = null;
            switch (role)
            {
                case "Requester": targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageDocumentIssuance)); break;
                case "GM_Operations": targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageGmOperations)); break;
                case "QA": targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageQa)); break;
                case "Admin": targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageUsers)); break;
                default: targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin)); break;
            }

            if (targetTab != null && tabControlMain.TabPages.Contains(targetTab))
                tabControlMain.SelectedTab = targetTab;
            else if (tabControlMain.TabPages.Count > 0)
                tabControlMain.SelectedIndex = 0;
        }

        private void SetupTabs()
        {
            // Initially, only the login tab should be visible.
            EnableTabsBasedOnRole(null);
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
        #endregion

        #region Document Issuance Tab Logic
        private void InitializeDocumentIssuanceTab()
        {
            chkDocTypeBMRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeBPRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeAppendixDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeAddendumDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            UpdateDocumentNumberFieldsVisibility();

            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray();
            int currentYear = DateTime.Now.Year;
            List<string> years = Enumerable.Range(currentYear - 10, 21).Select(y => y.ToString()).ToList();
            PopulateMonthYearComboBox(cmbParentMfgMonthDI, cmbParentMfgYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbParentExpMonthDI, cmbParentExpYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbItemMfgMonthDI, cmbItemMfgYearDI, monthNames, years, false);
            PopulateMonthYearComboBox(cmbItemExpMonthDI, cmbItemExpYearDI, monthNames, years, false);

            string[] batchUnits = { "KGS", "TAB", "ML", "GM", "LTR", "MG", "CAPS", "VIALS", "AMPOULES", "BTL" };
            PopulateUnitComboBox(cmbParentBatchSizeUnitDI, batchUnits, true);
            PopulateUnitComboBox(cmbItemBatchSizeUnitDI, batchUnits, false);

            txtParentBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;
            txtItemBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;

            cmbFromDepartmentDI.Items.Clear();
            cmbFromDepartmentDI.Items.AddRange(new string[] { "Production Department", "Quality Assurance", "Research & Development", "Regulatory Affairs", "Manufacturing", "Packaging Department" });
            if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;

            dtpRequestDateDI.Value = DateTime.Now;
            lblStatusValueDI.Text = "Ready to create a new request.";
            btnSubmitRequestDI.Click += BtnSubmitRequestDI_Click;
            btnClearFormDI.Click += BtnClearFormDI_Click;

            LoadInitialDocumentIssuanceData();
        }

        private void DocTypeCheckbox_CheckedChanged(object sender, EventArgs e) => UpdateDocumentNumberFieldsVisibility();
        private void UpdateDocumentNumberFieldsVisibility()
        {
            lblBmrDocNo.Visible = txtBmrDocNoDI.Visible = chkDocTypeBMRDI.Checked;
            if (!chkDocTypeBMRDI.Checked) txtBmrDocNoDI.Clear();

            lblBprDocNo.Visible = txtBprDocNoDI.Visible = chkDocTypeBPRDI.Checked;
            if (!chkDocTypeBPRDI.Checked) txtBprDocNoDI.Clear();

            lblAppendixDocNo.Visible = txtAppendixDocNoDI.Visible = chkDocTypeAppendixDI.Checked;
            if (!chkDocTypeAppendixDI.Checked) txtAppendixDocNoDI.Clear();

            lblAddendumDocNo.Visible = txtAddendumDocNoDI.Visible = chkDocTypeAddendumDI.Checked;
            if (!chkDocTypeAddendumDI.Checked) txtAddendumDocNoDI.Clear();
        }

        private void PopulateMonthYearComboBox(ComboBox cmbMonth, ComboBox cmbYear, string[] months, List<string> years, bool allowNotApplicable)
        {
            cmbMonth.Items.Clear();
            if (allowNotApplicable) cmbMonth.Items.Add("N/A");
            cmbMonth.Items.AddRange(months);
            cmbMonth.SelectedIndex = allowNotApplicable ? 0 : (DateTime.Now.Month - 1);

            cmbYear.Items.Clear();
            if (allowNotApplicable) cmbYear.Items.Add("N/A");
            cmbYear.Items.AddRange(years.ToArray());
            cmbYear.SelectedItem = allowNotApplicable ? "N/A" : DateTime.Now.Year.ToString();
        }

        private void PopulateUnitComboBox(ComboBox cmbUnit, string[] units, bool allowNotApplicable)
        {
            cmbUnit.Items.Clear();
            if (allowNotApplicable) cmbUnit.Items.Add("N/A");
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void LoadInitialDocumentIssuanceData()
        {
            try
            {
                txtRequestNoValueDI.Text = _repository.GenerateNewRequestNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating new request number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequestNoValueDI.Text = "ERROR";
            }
        }

        private void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            if (cmbFromDepartmentDI.SelectedItem == null || string.IsNullOrWhiteSpace(cmbFromDepartmentDI.SelectedItem.ToString()))
            { MessageBox.Show("Please select a 'From Department'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbFromDepartmentDI.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtProductDI.Text))
            { MessageBox.Show("Please enter the 'Product'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtProductDI.Focus(); return; }

            var docNumbersList = new List<string>();
            if (chkDocTypeBMRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { MessageBox.Show("BMR is checked, please enter BMR Document No.", "Validation Error"); txtBmrDocNoDI.Focus(); return; } docNumbersList.Add(txtBmrDocNoDI.Text.Trim()); }
            if (chkDocTypeBPRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { MessageBox.Show("BPR is checked, please enter BPR Document No.", "Validation Error"); txtBprDocNoDI.Focus(); return; } docNumbersList.Add(txtBprDocNoDI.Text.Trim()); }
            if (chkDocTypeAppendixDI.Checked) { if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { MessageBox.Show("Appendix is checked, please enter Appendix Document No.", "Validation Error"); txtAppendixDocNoDI.Focus(); return; } docNumbersList.Add(txtAppendixDocNoDI.Text.Trim()); }
            if (chkDocTypeAddendumDI.Checked) { if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { MessageBox.Show("Addendum is checked, please enter Addendum Document No.", "Validation Error"); txtAddendumDocNoDI.Focus(); return; } docNumbersList.Add(txtAddendumDocNoDI.Text.Trim()); }
            if (!docNumbersList.Any()) { MessageBox.Show("Please select at least one 'Document Type' and provide its number.", "Validation Error"); grpDocTypeDI.Focus(); return; }

            // --- Batch Size Validation ---
            string parentBatchSizeStr = null;
            if (!string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI.Text))
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _)) { MessageBox.Show("Parent Batch Size must be a valid number.", "Validation Error"); txtParentBatchSizeValueDI.Focus(); return; }
                if (cmbParentBatchSizeUnitDI.SelectedItem == null || cmbParentBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { MessageBox.Show("Please select a Unit for the Parent Batch Size.", "Validation Error"); cmbParentBatchSizeUnitDI.Focus(); return; }
                parentBatchSizeStr = $"{txtParentBatchSizeValueDI.Text.Trim()} {cmbParentBatchSizeUnitDI.SelectedItem}";
            }

            if (string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI.Text)) { MessageBox.Show("Item Batch Size value is required.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _)) { MessageBox.Show("Item Batch Size must be a valid number.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (cmbItemBatchSizeUnitDI.SelectedItem == null || cmbItemBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { MessageBox.Show("Please select a Unit for the Item Batch Size.", "Validation Error"); cmbItemBatchSizeUnitDI.Focus(); return; }

            // --- Data Collection into DTO ---
            var issuanceData = new IssuanceRequestData
            {
                RequestNo = txtRequestNoValueDI.Text,
                RequestDate = dtpRequestDateDI.Value.Date,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentNo = string.Join(",", docNumbersList),
                ParentBatchNumber = string.IsNullOrWhiteSpace(txtParentBatchNoDI.Text) ? null : txtParentBatchNoDI.Text.Trim(),
                ParentBatchSize = parentBatchSizeStr,
                ParentMfgDate = GetDateStringFromComboBoxes(cmbParentMfgMonthDI, cmbParentMfgYearDI),
                ParentExpDate = GetDateStringFromComboBoxes(cmbParentExpMonthDI, cmbParentExpYearDI),
                Product = txtProductDI.Text.Trim(),
                BatchNo = string.IsNullOrWhiteSpace(txtBatchNoDI.Text) ? null : txtBatchNoDI.Text.Trim(),
                BatchSize = $"{txtItemBatchSizeValueDI.Text.Trim()} {cmbItemBatchSizeUnitDI.SelectedItem}",
                ItemMfgDate = GetDateStringFromComboBoxes(cmbItemMfgMonthDI, cmbItemMfgYearDI),
                ItemExpDate = GetDateStringFromComboBoxes(cmbItemExpMonthDI, cmbItemExpYearDI),
                Market = string.IsNullOrWhiteSpace(txtMarketDI.Text) ? null : txtMarketDI.Text.Trim(),
                PackSize = string.IsNullOrWhiteSpace(txtPackSizeDI.Text) ? null : txtPackSizeDI.Text.Trim(),
                ExportOrderNo = string.IsNullOrWhiteSpace(txtExportOrderNoDI.Text) ? null : txtExportOrderNoDI.Text.Trim(),
                RequestComment = txtRemarksDI.Text.Trim(),
                PreparedBy = loggedInUserName
            };

            try
            {
                _repository.CreateIssuanceRequest(issuanceData);
                lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                lblStatusValueDI.ForeColor = Color.Green;
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDocumentIssuanceForm();
                LoadInitialDocumentIssuanceData();
            }
            catch (Exception ex)
            {
                lblStatusValueDI.Text = "Error submitting request.";
                lblStatusValueDI.ForeColor = Color.Red;
                MessageBox.Show($"Error submitting request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearFormDI_Click(object sender, EventArgs e)
        {
            ClearDocumentIssuanceForm();
            lblStatusValueDI.Text = "Form cleared. Ready for new request.";
            lblStatusValueDI.ForeColor = SystemColors.ControlText;
            LoadInitialDocumentIssuanceData();
        }

        private void ClearDocumentIssuanceForm()
        {
            chkDocTypeBMRDI.Checked = chkDocTypeBPRDI.Checked = chkDocTypeAppendixDI.Checked = chkDocTypeAddendumDI.Checked = false;
            dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
            txtParentBatchNoDI.Clear();
            txtParentBatchSizeValueDI.Clear();
            if (cmbParentBatchSizeUnitDI.Items.Count > 0) cmbParentBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbParentMfgMonthDI.Items.Count > 0) cmbParentMfgMonthDI.SelectedIndex = 0;
            if (cmbParentMfgYearDI.Items.Count > 0) cmbParentMfgYearDI.SelectedIndex = 0;
            if (cmbParentExpMonthDI.Items.Count > 0) cmbParentExpMonthDI.SelectedIndex = 0;
            if (cmbParentExpYearDI.Items.Count > 0) cmbParentExpYearDI.SelectedIndex = 0;
            txtProductDI.Clear();
            txtBatchNoDI.Clear();
            txtItemBatchSizeValueDI.Clear();
            if (cmbItemBatchSizeUnitDI.Items.Count > 0) cmbItemBatchSizeUnitDI.SelectedIndex = 0;
            cmbItemMfgMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            cmbItemMfgYearDI.SelectedItem = DateTime.Now.Year.ToString();
            cmbItemExpMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            cmbItemExpYearDI.SelectedItem = DateTime.Now.Year.ToString();
            txtMarketDI.Clear();
            txtPackSizeDI.Clear();
            txtExportOrderNoDI.Clear();
            txtRemarksDI.Clear();
            lblStatusValueDI.Text = "Form cleared.";
        }

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox)
        {
            string month = monthComboBox?.SelectedItem?.ToString();
            string year = yearComboBox?.SelectedItem?.ToString();
            return (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(year) || month == "N/A" || year == "N/A") ? null : $"{month}/{year}";
        }
        #endregion

        #region GM Operations Tab Logic
        private void InitializeGmOperationsTab()
        {
            dgvGmQueue.AutoGenerateColumns = false;
            dgvGmQueue.Columns["colGmRequestNo"].DataPropertyName = "RequestNo";
            dgvGmQueue.Columns["colGmRequestDate"].DataPropertyName = "RequestDate";
            dgvGmQueue.Columns["colGmProduct"].DataPropertyName = "Product";
            dgvGmQueue.Columns["colGmDocTypes"].DataPropertyName = "DocumentNo";
            dgvGmQueue.Columns["colGmPreparedBy"].DataPropertyName = "PreparedBy";
            dgvGmQueue.Columns["colGmRequestedAt"].DataPropertyName = "RequestedAt";

            dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            btnGmRefreshList.Click += (s, e) => LoadGmPendingQueue();
            btnGmAuthorize.Click += BtnGmAuthorize_Click;
            btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        private void LoadGmPendingQueue()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvGmQueue.DataSource = null;
                dgvGmQueue.DataSource = _repository.GetGmPendingQueue();
                lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue.Rows.Count})";
                ClearGmSelectedRequestDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load GM queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue.SelectedRows.Count > 0)
                DisplayGmSelectedRequestDetails(dgvGmQueue.SelectedRows[0]);
            else
                ClearGmSelectedRequestDetails();
        }

        private void DisplayGmSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (!(selectedRow.DataBoundItem is DataRowView rowView))
            {
                ClearGmSelectedRequestDetails();
                return;
            }
            string requestNo = rowView["RequestNo"].ToString();
            txtGmDetailRequestNo.Text = requestNo;
            txtGmDetailRequestDate.Text = ((DateTime)rowView["RequestDate"]).ToString("dd-MMM-yyyy");
            txtGmDetailProduct.Text = rowView["Product"].ToString();
            txtGmDetailDocTypes.Text = rowView["DocumentNo"].ToString();
            txtGmDetailPreparedBy.Text = rowView["PreparedBy"].ToString();
            txtGmDetailRequestedAt.Text = ((DateTime)rowView["RequestedAt"]).ToString("dd-MMM-yyyy HH:mm");

            try
            {
                DataTable dt = _repository.GetFullRequestDetails(requestNo);
                if (dt.Rows.Count > 0)
                {
                    DataRow detailRow = dt.Rows[0];
                    txtGmDetailFromDept.Text = detailRow["FromDepartment"].ToString();
                    txtGmDetailBatchNo.Text = detailRow["BatchNo"].ToString();
                    txtGmDetailMfgDate.Text = detailRow["ItemMfgDate"].ToString();
                    txtGmDetailExpDate.Text = detailRow["ItemExpDate"].ToString();
                    txtGmDetailMarket.Text = detailRow["Market"].ToString();
                    txtGmDetailPackSize.Text = detailRow["PackSize"].ToString();
                    txtGmDetailRequesterComments.Text = detailRow["RequestComment"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load full details for request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGmSelectedRequestDetails()
        {
            foreach (Control c in tlpGmRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtGmComment.Clear();
        }

        private void BtnGmAuthorize_Click(object sender, EventArgs e) => ProcessGmAction("Authorized", false);
        private void BtnGmReject_Click(object sender, EventArgs e) => ProcessGmAction("Rejected", true);

        private void ProcessGmAction(string action, bool commentsMandatory)
        {
            if (dgvGmQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtGmDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request from the queue to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (commentsMandatory && string.IsNullOrWhiteSpace(txtGmComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGmComment.Focus();
                return;
            }
            string requestNo = txtGmDetailRequestNo.Text;
            if (MessageBox.Show($"Are you sure you want to {action.ToLower()} request '{requestNo}'?", $"Confirm {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool success = _repository.UpdateGmAction(requestNo, action, txtGmComment.Text, loggedInUserName);
                    if (success)
                    {
                        MessageBox.Show($"Request '{requestNo}' has been {action.ToLower()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGmPendingQueue();
                    }
                    else
                    {
                        MessageBox.Show("Could not update the request. It may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadGmPendingQueue();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region QA Tab Logic
        private void InitializeQaTab()
        {
            dgvQaQueue.AutoGenerateColumns = false;
            dgvQaQueue.Columns["colQaRequestNo"].DataPropertyName = "RequestNo";
            dgvQaQueue.Columns["colQaRequestDate"].DataPropertyName = "RequestDate";
            dgvQaQueue.Columns["colQaProduct"].DataPropertyName = "Product";
            dgvQaQueue.Columns["colQaDocTypes"].DataPropertyName = "DocumentNo";
            dgvQaQueue.Columns["colQaPreparedBy"].DataPropertyName = "PreparedBy";
            dgvQaQueue.Columns["colQaAuthorizedBy"].DataPropertyName = "AuthorizedBy";
            dgvQaQueue.Columns["colQaGmActionAt"].DataPropertyName = "GmActionAt";

            dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;
            btnQaRefreshList.Click += (s, e) => LoadQaPendingQueue();
            btnQaApprove.Click += BtnQaApprove_Click;
            btnQaReject.Click += BtnQaReject_Click;
            btnQaBrowseSelectDocument.Click += (s, e) => MessageBox.Show("Functionality to open document location is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearQaSelectedRequestDetails();
            lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }

        private void LoadQaPendingQueue()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvQaQueue.DataSource = null;
                dgvQaQueue.DataSource = _repository.GetQaPendingQueue();
                lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue.Rows.Count})";
                ClearQaSelectedRequestDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load QA queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue.SelectedRows.Count > 0)
                DisplayQaSelectedRequestDetails(dgvQaQueue.SelectedRows[0]);
            else
                ClearQaSelectedRequestDetails();
        }

        private void DisplayQaSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (!(selectedRow.DataBoundItem is DataRowView rowView))
            {
                ClearQaSelectedRequestDetails();
                return;
            }
            string requestNo = rowView["RequestNo"].ToString();
            txtQaDetailRequestNo.Text = requestNo;
            txtQaDetailRequestDate.Text = ((DateTime)rowView["RequestDate"]).ToString("dd-MMM-yyyy");
            txtQaDetailProduct.Text = rowView["Product"].ToString();
            txtQaDetailDocTypes.Text = rowView["DocumentNo"].ToString();
            txtQaDetailPreparedBy.Text = rowView["PreparedBy"].ToString();
            if (rowView["GmActionAt"] != DBNull.Value)
                txtQaDetailGmActionTime.Text = ((DateTime)rowView["GmActionAt"]).ToString("dd-MMM-yyyy HH:mm");

            try
            {
                DataTable dt = _repository.GetFullRequestDetails(requestNo);
                if (dt.Rows.Count > 0)
                {
                    DataRow detailRow = dt.Rows[0];
                    txtQaDetailFromDept.Text = detailRow["FromDepartment"].ToString();
                    txtQaDetailBatchNo.Text = detailRow["BatchNo"].ToString();
                    txtQaDetailMfgDate.Text = detailRow["ItemMfgDate"].ToString();
                    txtQaDetailExpDate.Text = detailRow["ItemExpDate"].ToString();
                    txtQaDetailMarket.Text = detailRow["Market"].ToString();
                    txtQaDetailPackSize.Text = detailRow["PackSize"].ToString();
                    txtQaDetailRequesterComments.Text = detailRow["RequestComment"].ToString();
                    txtQaDetailGmComment.Text = detailRow["GmOperationsComment"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load full details for request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearQaSelectedRequestDetails()
        {
            foreach (Control c in tlpQaRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtQaComment.Clear();
            numQaPrintCount.Value = 1;
        }

        private void BtnQaApprove_Click(object sender, EventArgs e) => ProcessQaAction("Approved", false);
        private void BtnQaReject_Click(object sender, EventArgs e) => ProcessQaAction("Rejected", true);

        private void ProcessQaAction(string action, bool commentsMandatory)
        {
            if (dgvQaQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtQaDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request from the queue to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (commentsMandatory && string.IsNullOrWhiteSpace(txtQaComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQaComment.Focus();
                return;
            }
            string requestNo = txtQaDetailRequestNo.Text;
            int printCount = (int)numQaPrintCount.Value;
            string message = action == "Approved"
                ? $"Are you sure you want to approve request '{requestNo}'?\nPrint Count: {printCount}"
                : $"Are you sure you want to reject request '{requestNo}'?";

            if (MessageBox.Show(message, $"Confirm {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool success = _repository.UpdateQaAction(requestNo, action, txtQaComment.Text, loggedInUserName);
                    if (success)
                    {
                        string successMessage = action == "Approved"
                            ? $"Request '{requestNo}' approved successfully. Printed {printCount} copies."
                            : $"Request '{requestNo}' rejected successfully.";
                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadQaPendingQueue();
                    }
                    else
                    {
                        MessageBox.Show("Could not update the request. It may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadQaPendingQueue();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Audit Trail Tab Logic
        private void InitializeAuditTrailTab()
        {
            cmbAuditStatus.Items.Clear();
            cmbAuditStatus.Items.AddRange(new object[] { "All", "Pending GM Approval", "Pending QA Approval", "Approved (Issued)", "Rejected by GM", "Rejected by QA" });
            cmbAuditStatus.SelectedIndex = 0;
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;

            dgvAuditTrail.AutoGenerateColumns = false;
            dgvAuditTrail.VirtualMode = true;
            SetupAuditTrailColumns();
            dgvAuditTrail.CellValueNeeded += DgvAuditTrail_CellValueNeeded;
            dgvAuditTrail.ColumnHeaderMouseClick += DgvAuditTrail_ColumnHeaderMouseClick;

            btnApplyAuditFilter.Click += (s, e) => LoadAuditTrailData();
            btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            btnRefreshAuditList.Click += (s, e) => LoadAuditTrailData();
            btnExportToCsv.Click += (s, e) => MessageBox.Show("CSV export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExportToExcel.Click += (s, e) => MessageBox.Show("Excel export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupAuditTrailColumns()
        {
            dgvAuditTrail.Columns.Clear();
            var wrapTextStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True, Alignment = DataGridViewContentAlignment.TopLeft };
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120, Frozen = true });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = "Product", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocumentNumbers", HeaderText = "Document No(s).", DataPropertyName = "DocumentNumbers", Width = 180, DefaultCellStyle = wrapTextStyle });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditStatusDerived", HeaderText = "Status", DataPropertyName = "DerivedStatus", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditPreparedBy", HeaderText = "Prepared By", DataPropertyName = "PreparedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestedAt", HeaderText = "Requested At", DataPropertyName = "RequestedAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmAction", HeaderText = "GM Action", DataPropertyName = "GmOperationsAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditAuthorizedBy", HeaderText = "GM User", DataPropertyName = "AuthorizedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmActionAt", HeaderText = "GM Action At", DataPropertyName = "GmOperationsAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmComment", HeaderText = "GM Comment", DataPropertyName = "GmOperationsComment", Width = 200, DefaultCellStyle = wrapTextStyle });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaAction", HeaderText = "QA Action", DataPropertyName = "QAAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditApprovedBy", HeaderText = "QA User", DataPropertyName = "ApprovedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaActionAt", HeaderText = "QA Action At", DataPropertyName = "QAAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaComment", HeaderText = "QA Comment", DataPropertyName = "QAComment", Width = 200, DefaultCellStyle = wrapTextStyle });
        }

        private void LoadAuditTrailData()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var columnMap = new Dictionary<string, string>
                {
                    { "colAuditRequestNo", "RequestNo" }, { "colAuditRequestDate", "RequestDate" },
                    { "colAuditProduct", "Product" }, { "colAuditStatusDerived", "DerivedStatus" },
                    { "colAuditPreparedBy", "PreparedBy" }, { "colAuditRequestedAt", "RequestedAt" }
                };
                columnMap.TryGetValue(_auditSortColumn, out string dbSortColumn);

                _auditTrailKeyCache = _repository.GetAuditTrailKeys(
                    dtpAuditFrom.Value, dtpAuditTo.Value, cmbAuditStatus.SelectedItem.ToString(),
                    txtAuditRequestNo.Text, txtAuditProduct.Text, dbSortColumn, _auditSortOrder);

                _currentAuditRowCacheIndex = -1;
                dgvAuditTrail.RowCount = 0;
                dgvAuditTrail.RowCount = _auditTrailKeyCache.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load audit trail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void DgvAuditTrail_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_auditTrailKeyCache == null || e.RowIndex >= _auditTrailKeyCache.Count) return;

            if (e.RowIndex != _currentAuditRowCacheIndex)
            {
                int recordKey = _auditTrailKeyCache[e.RowIndex];
                _currentAuditRowCache = _repository.GetAuditTrailEntry(recordKey);
                _currentAuditRowCacheIndex = e.RowIndex;
            }

            if (_currentAuditRowCache == null) return;
            string colName = dgvAuditTrail.Columns[e.ColumnIndex].Name;
            switch (colName)
            {
                case "colAuditRequestNo": e.Value = _currentAuditRowCache.RequestNo; break;
                case "colAuditRequestDate": e.Value = _currentAuditRowCache.RequestDate; break;
                case "colAuditProduct": e.Value = _currentAuditRowCache.Product; break;
                case "colAuditDocumentNumbers": e.Value = _currentAuditRowCache.DocumentNumbers; break;
                case "colAuditStatusDerived": e.Value = _currentAuditRowCache.DerivedStatus; break;
                case "colAuditPreparedBy": e.Value = _currentAuditRowCache.PreparedBy; break;
                case "colAuditRequestedAt": e.Value = _currentAuditRowCache.RequestedAt; break;
                case "colAuditGmAction": e.Value = _currentAuditRowCache.GmOperationsAction; break;
                case "colAuditAuthorizedBy": e.Value = _currentAuditRowCache.AuthorizedBy; break;
                case "colAuditGmActionAt": e.Value = _currentAuditRowCache.GmOperationsAt; break;
                case "colAuditGmComment": e.Value = _currentAuditRowCache.GmOperationsComment; break;
                case "colAuditQaAction": e.Value = _currentAuditRowCache.QAAction; break;
                case "colAuditApprovedBy": e.Value = _currentAuditRowCache.ApprovedBy; break;
                case "colAuditQaActionAt": e.Value = _currentAuditRowCache.QAAt; break;
                case "colAuditQaComment": e.Value = _currentAuditRowCache.QAComment; break;
            }
        }

        private void DgvAuditTrail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string newSortColumn = dgvAuditTrail.Columns[e.ColumnIndex].Name;
            _auditSortOrder = (_auditSortColumn == newSortColumn && _auditSortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            _auditSortColumn = newSortColumn;
            LoadAuditTrailData();
        }

        private void DgvAuditTrail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"DataGridView DataError: Row {e.RowIndex}, Column {e.ColumnIndex} ('{dgvAuditTrail.Columns[e.ColumnIndex].Name}'). Exception: {e.Exception.Message}");
            e.ThrowException = false;
        }

        private void DgvAuditTrail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuditTrail.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvAuditTrail.SelectedRows[0].Index;
                if (_auditTrailKeyCache != null && selectedIndex < _auditTrailKeyCache.Count)
                {
                    int selectedKey = _auditTrailKeyCache[selectedIndex];
                    Console.WriteLine($"Selected audit trail record key: {selectedKey}");
                }
            }
        }

        private void BtnApplyAuditFilter_Click(object sender, EventArgs e) { LoadAuditTrailData(); }
        private void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;
            cmbAuditStatus.SelectedIndex = 0;
            txtAuditRequestNo.Clear();
            txtAuditProduct.Clear();
            _auditSortColumn = string.Empty;
            _auditSortOrder = SortOrder.None;
            LoadAuditTrailData();
        }
        private void BtnRefreshAuditList_Click(object sender, EventArgs e)
        {
            LoadAuditTrailData();
        }
        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export in Virtual Mode requires fetching all data from the database. This can be slow and memory-intensive and should be implemented as a background task.", "Export Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel export functionality is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Users Tab Logic
        private void InitializeUsersTab()
        {
            this.userRolesBindingSource = new BindingSource();
            dgvUserRoles.AutoGenerateColumns = false;
            dgvUserRoles.Columns["colUserRoleId"].DataPropertyName = "RoleID";
            dgvUserRoles.Columns["colUserRoleName"].DataPropertyName = "RoleName";
            dgvUserRoles.DataSource = this.userRolesBindingSource;
            dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;

            btnRefreshUserRoles.Click += (s, e) => LoadUserRoles();
            btnResetPassword.Click += BtnResetPassword_Click;
        }

        private void LoadUserRoles()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.userRolesBindingSource.DataSource = _repository.GetUserRolesForGrid();
                dgvUserRoles.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void DgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
            bool isRowSelected = dgvUserRoles.SelectedRows.Count > 0;
            btnResetPassword.Enabled = isRowSelected;
            txtRoleNameManage.Text = isRowSelected ? (dgvUserRoles.SelectedRows[0].DataBoundItem as DataRowView)?["RoleName"].ToString() : string.Empty;
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
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
                // In production, prompt for a new password and hash it securely.
                string newPasswordHash = newPassword;
                try
                {
                    if (_repository.ResetUserPassword(roleName, newPasswordHash))
                        MessageBox.Show($"Password for role '{roleName}' has been reset to '{newPassword}'.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to reset password. The role may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while resetting the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}