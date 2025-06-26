using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // Required for App.config
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks; // Required for async
using System.Windows.Forms;
using IssuanceApp.Data;     // Required to reference the Data project

namespace DocumentIssuanceApp
{
    public partial class MainForm : Form
    {
        #region Fields
        // A single, private instance of the repository for the entire form's lifetime.
        private readonly IssuanceRepository _repository;
        private Timer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null;

        private BindingSource userRolesBindingSource;

        // --- UI State Management ---
        private List<TabPage> allTabPages;

        // Flags for lazy loading tab data to improve performance.
        private bool _auditDataLoaded = false;
        private bool _usersDataLoaded = false;

        // --- Fields for HIGH-PERFORMANCE Audit Trail Virtual Mode ---
        private List<int> _auditTrailKeyCache; // The master list of all primary keys for the current filter
        private Dictionary<int, AuditTrailEntry> _auditTrailPageCache; // Caches pages of full AuditTrailEntry objects
        private HashSet<int> _pagesBeingFetched; // Tracks which pages are currently being fetched to prevent duplicate calls
        private const int AuditPageSize = 50; // How many rows to fetch in a single background database call
        private SortOrder _auditSortOrder = SortOrder.None;
        private string _auditSortColumn = string.Empty;
        #endregion

        #region Constructor and Form Load
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["IssuanceAppDB"].ConnectionString;
                _repository = new IssuanceRepository(connStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read database configuration. The application will now close.\n\nError: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Load += (s, e) => Close();
                return;
            }

            EnableDoubleBuffering();
            InitializeDynamicControls();
            ApplyPharmaTheme();

            this.Text = "Document Issuance System";
            statusTimer = new Timer { Interval = 1000 };
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            this.tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            SetupStatusBar();
            InitializeLoginTab();
            InitializeDocumentIssuanceTab();
            InitializeGmOperationsTab();
            InitializeQaTab();
            InitializeAuditTrailTab();
            InitializeUsersTab();

            SetupTabs();

            btnSignOut.Click += BtnSignOut_Click;
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

        private async void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == null) return;
            string selectedTabName = tabControlMain.SelectedTab.Name;

            if (selectedTabName == nameof(tabPageGmOperations))
            {
                await LoadGmPendingQueueAsync();
            }
            else if (selectedTabName == nameof(tabPageQa))
            {
                await LoadQaPendingQueueAsync();
            }
            else if (selectedTabName == nameof(tabPageAuditTrail) && !_auditDataLoaded)
            {
                await LoadAuditTrailDataAsync();
                _auditDataLoaded = true;
            }
            else if (selectedTabName == nameof(tabPageUsers) && !_usersDataLoaded)
            {
                await LoadUserRolesAsync();
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
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loggedInRole = null;
                lblLoginStatus.Text = "You have been signed out.";
                lblLoginStatus.ForeColor = SystemColors.ControlText;
                pnlAppHeader.Visible = false;
                SetupStatusBar();

                EnableTabsBasedOnRole(null);
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin));
                if (loginTab != null)
                {
                    tabControlMain.SelectedTab = loginTab;
                }
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
            }
            this.loggedInUserName = osUserDisplay;
            toolStripStatusLabelUser.Text = $"User: {osUserDisplay} (Not Logged In)";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
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

        #region Login and Role Management
        private async void InitializeLoginTab()
        {
            if (cmbRole == null || txtPassword == null || btnLogin == null) return;
            cmbRole.Items.Clear();
            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> roleNames = await _repository.GetRoleNamesAsync();
                cmbRole.Items.AddRange(roleNames.ToArray());
                if (cmbRole.Items.Contains("Requester")) cmbRole.SelectedItem = "Requester";
                else if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load user roles from the database.\n" + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            txtPassword.PasswordChar = '*';
            btnLogin.Click += BtnLogin_Click;
            EnableTabsBasedOnRole(null);
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem?.ToString();
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(selectedRole) || string.IsNullOrEmpty(password))
            {
                lblLoginStatus.Text = "Please select a role and enter the password.";
                lblLoginStatus.ForeColor = Color.Red;
                return;
            }

            btnLogin.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblLoginStatus.Text = "Authenticating...";
            lblLoginStatus.ForeColor = SystemColors.ControlText;

            try
            {
                bool isAuthenticated = await _repository.AuthenticateUserAsync(selectedRole, password);
                if (isAuthenticated)
                {
                    loggedInRole = selectedRole;
                    toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";
                    lblCurrentUserHeader.Text = $"Logged in as: {loggedInUserName} ({loggedInRole})";
                    lblCurrentUserHeader.ForeColor = _headerTextColor;
                    pnlAppHeader.Visible = true;
                    lblLoginStatus.Text = $"Login successful as {loggedInRole}.";
                    lblLoginStatus.ForeColor = _successColor;
                    txtPassword.Clear();
                    _auditDataLoaded = _usersDataLoaded = false;
                    EnableTabsBasedOnRole(loggedInRole);
                    SwitchToDefaultTabForRole(loggedInRole);
                }
                else
                {
                    pnlAppHeader.Visible = false;
                    lblLoginStatus.Text = "Invalid role or password.";
                    lblLoginStatus.ForeColor = _dangerColor;
                    loggedInRole = null;
                    SetupStatusBar();
                    EnableTabsBasedOnRole(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void EnableTabsBasedOnRole(string role)
        {
            bool isLoggedIn = !string.IsNullOrEmpty(role);
            tabControlMain.TabPages.Clear();

            if (!isLoggedIn)
            {
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin));
                if (loginTab != null) tabControlMain.TabPages.Add(loginTab);
                return;
            }

            bool isRequester = (role == "Requester");
            bool isGm = (role == "GM_Operations");
            bool isQa = (role == "QA");
            bool isAdmin = (role == "Admin");

            foreach (var tab in allTabPages)
            {
                bool shouldShowTab =
                    (tab.Name == nameof(tabPageDocumentIssuance) && (isRequester || isAdmin)) ||
                    (tab.Name == nameof(tabPageGmOperations) && (isGm || isAdmin)) ||
                    (tab.Name == nameof(tabPageQa) && (isQa || isAdmin)) ||
                    (tab.Name == nameof(tabPageUsers) && isAdmin) ||
                    (tab.Name == nameof(tabPageAuditTrail));

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
            EnableTabsBasedOnRole(null);
        }
        #endregion

        #region UI Theming and Styling
        private static readonly Color _successColor = Color.FromArgb(28, 184, 65);
        private static readonly Color _dangerColor = Color.FromArgb(220, 53, 69);
        private static readonly Color _primaryColor = Color.FromArgb(0, 123, 255);
        private static readonly Color _secondaryColor = Color.FromArgb(108, 117, 125);
        private static readonly Color _successHoverColor = Color.FromArgb(33, 205, 74);
        private static readonly Color _dangerHoverColor = Color.FromArgb(225, 66, 82);
        private static readonly Color _primaryHoverColor = Color.FromArgb(10, 136, 255);
        private static readonly Color _secondaryHoverColor = Color.FromArgb(124, 132, 140);
        private static readonly Color _headerTextColor = Color.White;
        private static readonly Color _formBackColor = Color.FromArgb(240, 242, 245);
        private static readonly Color _gridSelectionBackColor = Color.FromArgb(188, 220, 244);
        private static readonly Color _gridSelectionForeColor = Color.Black;
        private static readonly Color _appHeaderColor = Color.FromArgb(65, 84, 110);
        private static readonly Color _gridAltRowColor = Color.FromArgb(248, 249, 250);

        private void ApplyPharmaTheme()
        {
            pnlAppHeader.BackColor = _appHeaderColor;
            pnlAppHeader.Visible = false;
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                tab.BackColor = _formBackColor;
            }
            lblHeaderDI.ForeColor = _appHeaderColor;
            lblGmQueueTitle.ForeColor = _appHeaderColor;
            lblQaQueueTitle.ForeColor = _appHeaderColor;
            lblApplicationRoles.ForeColor = _appHeaderColor;
            var boldFont = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            foreach (var grp in this.pnlMainContainer.Controls.OfType<Control>().SelectMany(c => c.Controls.OfType<GroupBox>()))
            {
                grp.ForeColor = _appHeaderColor;
                grp.Font = boldFont;
            }
            StyleSuccessButton(btnSubmitRequestDI);
            StyleSuccessButton(btnGmAuthorize);
            StyleSuccessButton(btnQaApprove);
            StyleDangerButton(btnGmReject);
            StyleDangerButton(btnQaReject);
            StyleDangerButton(btnSignOut);
            StylePrimaryButton(btnLogin);
            StylePrimaryButton(btnApplyAuditFilter);
            StylePrimaryButton(btnResetPassword);
            StylePrimaryButton(btnGmRefreshList);
            StylePrimaryButton(btnQaRefreshList);
            StylePrimaryButton(btnRefreshAuditList);
            StylePrimaryButton(btnRefreshUserRoles);
            StyleSecondaryButton(btnClearFormDI);
            StyleSecondaryButton(btnClearAuditFilters);
            StyleSecondaryButton(btnQaBrowseSelectDocument);
            StyleSecondaryButton(btnExportToCsv);
            StyleSecondaryButton(btnExportToExcel);
            btnGmAuthorize.ImageList = imageList1;
            btnGmAuthorize.ImageKey = "Approve";
            btnGmReject.ImageList = imageList1;
            btnGmReject.ImageKey = "Reject";
            btnGmRefreshList.ImageList = imageList1;
            btnGmRefreshList.ImageKey = "Refresh";
            StyleDataGridView(dgvGmQueue);
            StyleDataGridView(dgvQaQueue);
            StyleDataGridView(dgvAuditTrail);
            StyleDataGridView(dgvUserRoles);
        }

        private void StyleButton(Button btn, Color backColor, Color hoverColor)
        {
            if (btn is RoundedButton roundedBtn)
            {
                roundedBtn.CornerRadius = 8;
            }
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = _headerTextColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Padding = new Padding(5, 0, 5, 0);
        }

        private void StyleSuccessButton(Button btn) { StyleButton(btn, _successColor, _successHoverColor); }
        private void StyleDangerButton(Button btn) { StyleButton(btn, _dangerColor, _dangerHoverColor); }
        private void StylePrimaryButton(Button btn) { StyleButton(btn, _primaryColor, _primaryHoverColor); }
        private void StyleSecondaryButton(Button btn) { StyleButton(btn, _secondaryColor, _secondaryHoverColor); }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = _formBackColor;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = _appHeaderColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = _headerTextColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = _gridAltRowColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor = _gridSelectionBackColor;
            dgv.RowsDefaultCellStyle.SelectionForeColor = _gridSelectionForeColor;
        }
        #endregion

        #region Document Issuance Tab Logic
        private async void InitializeDocumentIssuanceTab()
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
            await LoadInitialDocumentIssuanceDataAsync();
        }

        private void DocTypeCheckbox_CheckedChanged(object sender, EventArgs e) => UpdateDocumentNumberFieldsVisibility();
        private void UpdateDocumentNumberFieldsVisibility()
        {
            lblBmrDocNoDI.Visible = txtBmrDocNoDI.Visible = chkDocTypeBMRDI.Checked;
            if (!chkDocTypeBMRDI.Checked) txtBmrDocNoDI.Clear();
            lblBprDocNoDI.Visible = txtBprDocNoDI.Visible = chkDocTypeBPRDI.Checked;
            if (!chkDocTypeBPRDI.Checked) txtBprDocNoDI.Clear();
            lblAppendixDocNoDI.Visible = txtAppendixDocNoDI.Visible = chkDocTypeAppendixDI.Checked;
            if (!chkDocTypeAppendixDI.Checked) txtAppendixDocNoDI.Clear();
            lblAddendumDocNoDI.Visible = txtAddendumDocNoDI.Visible = chkDocTypeAddendumDI.Checked;
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

        private async Task LoadInitialDocumentIssuanceDataAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                txtRequestNoValueDI.Text = await _repository.GenerateNewRequestNumberAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating new request number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequestNoValueDI.Text = "ERROR";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
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

            btnSubmitRequestDI.Enabled = false;
            btnClearFormDI.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblStatusValueDI.Text = "Submitting request...";
            lblStatusValueDI.ForeColor = SystemColors.ControlText;

            try
            {
                await _repository.CreateIssuanceRequestAsync(issuanceData);
                lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                lblStatusValueDI.ForeColor = _successColor;
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDocumentIssuanceForm();
                await LoadInitialDocumentIssuanceDataAsync();
            }
            catch (Exception ex)
            {
                lblStatusValueDI.Text = "Error submitting request.";
                lblStatusValueDI.ForeColor = _dangerColor;
                MessageBox.Show($"Error submitting request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmitRequestDI.Enabled = true;
                btnClearFormDI.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async void BtnClearFormDI_Click(object sender, EventArgs e)
        {
            ClearDocumentIssuanceForm();
            lblStatusValueDI.Text = "Form cleared. Ready for new request.";
            lblStatusValueDI.ForeColor = SystemColors.ControlText;
            await LoadInitialDocumentIssuanceDataAsync();
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
            btnGmRefreshList.Click += async (s, e) => await LoadGmPendingQueueAsync();
            btnGmAuthorize.Click += BtnGmAuthorize_Click;
            btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        private async Task LoadGmPendingQueueAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            btnGmRefreshList.Enabled = false;
            try
            {
                dgvGmQueue.DataSource = null;
                dgvGmQueue.DataSource = await _repository.GetGmPendingQueueAsync();
                lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue.Rows.Count})";
                ClearGmSelectedRequestDetails();

                if (dgvGmQueue.Rows.Count > 0)
                {
                    dgvGmQueue.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load GM queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGmRefreshList.Enabled = true;
            }
        }

        private async void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue.SelectedRows.Count > 0)
                await DisplayGmSelectedRequestDetailsAsync(dgvGmQueue.SelectedRows[0]);
            else
                ClearGmSelectedRequestDetails();
        }

        private async Task DisplayGmSelectedRequestDetailsAsync(DataGridViewRow selectedRow)
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

            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = await _repository.GetFullRequestDetailsAsync(requestNo);
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ClearGmSelectedRequestDetails()
        {
            foreach (Control c in tlpGmRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtGmComment.Clear();
        }

        private void BtnGmAuthorize_Click(object sender, EventArgs e) => ProcessGmActionAsync("Authorized", false);
        private void BtnGmReject_Click(object sender, EventArgs e) => ProcessGmActionAsync("Rejected", true);

        private async void ProcessGmActionAsync(string action, bool commentsMandatory)
        {
            if (dgvGmQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtGmDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnGmAuthorize.Enabled = btnGmReject.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bool success = await _repository.UpdateGmActionAsync(requestNo, action, txtGmComment.Text, loggedInUserName);
                    if (success)
                    {
                        MessageBox.Show($"Request '{requestNo}' has been {action.ToLower()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadGmPendingQueueAsync();
                    }
                    else
                    {
                        MessageBox.Show("Could not update request. It may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadGmPendingQueueAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnGmAuthorize.Enabled = btnGmReject.Enabled = true;
                    this.Cursor = Cursors.Default;
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
            btnQaRefreshList.Click += async (s, e) => await LoadQaPendingQueueAsync();
            btnQaApprove.Click += BtnQaApprove_Click;
            btnQaReject.Click += BtnQaReject_Click;
            btnQaBrowseSelectDocument.Click += (s, e) => MessageBox.Show("Functionality to open document location is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearQaSelectedRequestDetails();
            lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }

        private async Task LoadQaPendingQueueAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            btnQaRefreshList.Enabled = false;
            try
            {
                dgvQaQueue.DataSource = null;
                dgvQaQueue.DataSource = await _repository.GetQaPendingQueueAsync();
                lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue.Rows.Count})";
                ClearQaSelectedRequestDetails();
                if (dgvQaQueue.Rows.Count > 0)
                {
                    dgvQaQueue.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load QA queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnQaRefreshList.Enabled = true;
            }
        }

        private async void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue.SelectedRows.Count > 0)
                await DisplayQaSelectedRequestDetailsAsync(dgvQaQueue.SelectedRows[0]);
            else
                ClearQaSelectedRequestDetails();
        }

        private async Task DisplayQaSelectedRequestDetailsAsync(DataGridViewRow selectedRow)
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

            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = await _repository.GetFullRequestDetailsAsync(requestNo);
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ClearQaSelectedRequestDetails()
        {
            foreach (Control c in tlpQaRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtQaComment.Clear();
            numQaPrintCount.Value = 1;
        }

        private void BtnQaApprove_Click(object sender, EventArgs e) => ProcessQaActionAsync("Approved", false);
        private void BtnQaReject_Click(object sender, EventArgs e) => ProcessQaActionAsync("Rejected", true);

        private async void ProcessQaActionAsync(string action, bool commentsMandatory)
        {
            if (dgvQaQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtQaDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnQaApprove.Enabled = btnQaReject.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bool success = await _repository.UpdateQaActionAsync(requestNo, action, txtQaComment.Text, loggedInUserName);
                    if (success)
                    {
                        string successMessage = action == "Approved"
                            ? $"Request '{requestNo}' approved successfully. Printed {printCount} copies."
                            : $"Request '{requestNo}' rejected successfully.";
                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadQaPendingQueueAsync();
                    }
                    else
                    {
                        MessageBox.Show("Could not update request. It may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadQaPendingQueueAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnQaApprove.Enabled = btnQaReject.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Audit Trail Tab Logic
        private void InitializeAuditTrailTab()
        {
            _auditTrailPageCache = new Dictionary<int, AuditTrailEntry>();
            _pagesBeingFetched = new HashSet<int>();

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
            btnApplyAuditFilter.Click += async (s, e) => await LoadAuditTrailDataAsync();
            btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            btnRefreshAuditList.Click += async (s, e) => await LoadAuditTrailDataAsync();
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

        private async Task LoadAuditTrailDataAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            btnApplyAuditFilter.Enabled = btnClearAuditFilters.Enabled = btnRefreshAuditList.Enabled = false;
            try
            {
                _auditTrailPageCache.Clear();
                _pagesBeingFetched.Clear();

                var columnMap = new Dictionary<string, string>
                {
                    { "colAuditRequestNo", "RequestNo" }, { "colAuditRequestDate", "RequestDate" },
                    { "colAuditProduct", "Product" }, { "colAuditStatusDerived", "DerivedStatus" },
                    { "colAuditPreparedBy", "PreparedBy" }, { "colAuditRequestedAt", "RequestedAt" }
                };
                columnMap.TryGetValue(_auditSortColumn, out string dbSortColumn);

                _auditTrailKeyCache = await _repository.GetAuditTrailKeysAsync(
                    dtpAuditFrom.Value, dtpAuditTo.Value, cmbAuditStatus.SelectedItem.ToString(),
                    txtAuditRequestNo.Text, txtAuditProduct.Text, dbSortColumn, _auditSortOrder);

                dgvAuditTrail.RowCount = 0;
                dgvAuditTrail.RowCount = _auditTrailKeyCache.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load audit trail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnApplyAuditFilter.Enabled = btnClearAuditFilters.Enabled = btnRefreshAuditList.Enabled = true;
            }
        }

        private void DgvAuditTrail_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || _auditTrailKeyCache == null || e.RowIndex >= _auditTrailKeyCache.Count) return;

            if (_auditTrailPageCache.ContainsKey(e.RowIndex))
            {
                var entry = _auditTrailPageCache[e.RowIndex];
                if (entry == null) return;

                string colName = dgvAuditTrail.Columns[e.ColumnIndex].Name;
                switch (colName)
                {
                    case "colAuditRequestNo": e.Value = entry.RequestNo; break;
                    case "colAuditRequestDate": e.Value = entry.RequestDate; break;
                    case "colAuditProduct": e.Value = entry.Product; break;
                    case "colAuditDocumentNumbers": e.Value = entry.DocumentNumbers; break;
                    case "colAuditStatusDerived": e.Value = entry.DerivedStatus; break;
                    case "colAuditPreparedBy": e.Value = entry.PreparedBy; break;
                    case "colAuditRequestedAt": e.Value = entry.RequestedAt; break;
                    case "colAuditGmAction": e.Value = entry.GmOperationsAction; break;
                    case "colAuditAuthorizedBy": e.Value = entry.AuthorizedBy; break;
                    case "colAuditGmActionAt": e.Value = entry.GmOperationsAt; break;
                    case "colAuditGmComment": e.Value = entry.GmOperationsComment; break;
                    case "colAuditQaAction": e.Value = entry.QAAction; break;
                    case "colAuditApprovedBy": e.Value = entry.ApprovedBy; break;
                    case "colAuditQaActionAt": e.Value = entry.QAAt; break;
                    case "colAuditQaComment": e.Value = entry.QAComment; break;
                }
            }
            else
            {
                e.Value = "Loading...";
                FetchAuditPage(e.RowIndex);
            }
        }

        private async void FetchAuditPage(int rowIndex)
        {
            int pageNumber = rowIndex / AuditPageSize;
            if (_pagesBeingFetched.Contains(pageNumber)) return;

            try
            {
                _pagesBeingFetched.Add(pageNumber);

                int start = pageNumber * AuditPageSize;
                int end = Math.Min(start + AuditPageSize, _auditTrailKeyCache.Count);
                if (start >= end) return;
                var keysToFetch = _auditTrailKeyCache.GetRange(start, end - start);

                var entries = await _repository.GetAuditTrailEntriesAsync(keysToFetch);
                var entryDict = entries.ToDictionary(entry => entry.IssuanceID);

                if (dgvAuditTrail.IsDisposed) return;
                dgvAuditTrail.BeginInvoke(new Action(() =>
                {
                    for (int i = start; i < end; i++)
                    {
                        var key = _auditTrailKeyCache[i];
                        if (entryDict.ContainsKey(key))
                        {
                            _auditTrailPageCache[i] = entryDict[key];
                        }
                    }
                    for (int i = start; i < end; i++)
                    {
                        if (i < dgvAuditTrail.RowCount) dgvAuditTrail.InvalidateRow(i);
                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching audit page {pageNumber}: {ex.Message}");
            }
            finally
            {
                _pagesBeingFetched.Remove(pageNumber);
            }
        }

        private async void DgvAuditTrail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string newSortColumn = dgvAuditTrail.Columns[e.ColumnIndex].Name;
            _auditSortOrder = (_auditSortColumn == newSortColumn && _auditSortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            _auditSortColumn = newSortColumn;
            await LoadAuditTrailDataAsync();
        }

        private async void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;
            cmbAuditStatus.SelectedIndex = 0;
            txtAuditRequestNo.Clear();
            txtAuditProduct.Clear();
            _auditSortColumn = string.Empty;
            _auditSortOrder = SortOrder.None;
            await LoadAuditTrailDataAsync();
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
            btnRefreshUserRoles.Click += async (s, e) => await LoadUserRolesAsync();
            btnResetPassword.Click += BtnResetPassword_Click;
        }

        private async Task LoadUserRolesAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            btnRefreshUserRoles.Enabled = false;
            try
            {
                this.userRolesBindingSource.DataSource = await _repository.GetUserRolesForGridAsync();
                dgvUserRoles.ClearSelection();
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
            txtRoleNameManage.Text = isRowSelected
                ? Convert.ToString((dgvUserRoles.SelectedRows[0].DataBoundItem as DataRowView)?["RoleName"])
                : string.Empty;
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
                string newPasswordHash = newPassword;

                btnResetPassword.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (await _repository.ResetUserPasswordAsync(roleName, newPasswordHash))
                        MessageBox.Show($"Password for role '{roleName}' has been reset to '{newPassword}'.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion
    }
}