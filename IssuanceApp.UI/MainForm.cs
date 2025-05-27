// MainForm.cs (Code-behind with Enhanced Font Scaling & Document Issuance Logic)
using IssuanceApp.Data; // Assuming AuditTrailEntry is here
using System;
using System.Collections.Generic; // Required for List<string>
using System.Drawing;
using System.IO; // New: For file operations (CSV export)
using System.Security.Principal; // Required for WindowsIdentity
using System.Text;
using System.Windows.Forms;
using System.Linq; // Required for .Cast<T>()

// using System.Xml.Serialization; // This was likely for StringBuilder, but StringBuilder is in System.Text

namespace DocumentIssuanceApp
{

    public partial class MainForm : Form
    {
        private Timer statusTimer;
        private string loggedInRole = null;

        // Fields for font and control scaling (primarily for one-time scaling on initial maximize)
        private SizeF _originalFormClientSize; // Corrected name
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

            InitializeAuditTrailTab();

            SetupTabs();                  // General tab setup (permissions etc.)

            SetupTabs();

            this.Load += MainForm_Load_ForScalingSetup;
            this.Resize += MainForm_Resize_Handler; // Handles general resize events (like re-centering login panel)

            SetupTlpQaRequestDetailsRowStyles();
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

            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Document Issuance System";
            statusTimer = new Timer();
            statusTimer.Interval = 1000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            if (this.tabPageLogin != null)
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
            if (cmbRole == null || txtPassword == null || btnLogin == null) return;

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
                    if (tabPageUsers != null) tabControlMain.SelectedTab = tabPageUsers;
                    break;
                default:
                    if (tabPageLogin != null) tabControlMain.SelectedTab = tabPageLogin;
                    break;
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
                Console.WriteLine("Original form client size not captured, skipping initial scaling.");
                return;
            }

            SizeF currentMaximizedFormClientSize = this.ClientSize;
            float scaleFactorX = (currentMaximizedFormClientSize.Width / _originalFormClientSize.Width);
            float scaleFactorY = (currentMaximizedFormClientSize.Height / _originalFormClientSize.Height);
            float scaleFactor = Math.Min(scaleFactorX, scaleFactorY);

            if (scaleFactor <= 0.1f)
            {
                Console.WriteLine($"Invalid scale factor {scaleFactor}, defaulting to 1.0 for initial scaling.");
                scaleFactor = 1.0f;
            }

            if (_originalFormFont != null)
            {
                float newFormFontSize = _originalFormFont.Size * scaleFactor;
                newFormFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newFormFontSize));
                this.Font = new Font(_originalFormFont.FontFamily, newFormFontSize, _originalFormFont.Style);
            }

            if (tabControlMain != null && _originalTabControlFont != null)
            {
                float newTabControlFontSize = _originalTabControlFont.Size * scaleFactor;
                newTabControlFontSize = Math.Max(MinFontSize, Math.Min(MaxFontSize, newTabControlFontSize));
                tabControlMain.Font = new Font(_originalTabControlFont.FontFamily, newTabControlFontSize, _originalTabControlFont.Style);
            }

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

            chkDocTypeBMRDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            chkDocTypeBPRDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            chkDocTypeAppendixDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;
            chkDocTypeAddendumDI.CheckedChanged += DocTypeCheckBox_CheckedChanged;

            DocTypeCheckBox_CheckedChanged(null, null);
        }

        private void PopulateYearComboBoxes(params ComboBox[] comboBoxes)
        {
            int currentYear = DateTime.Now.Year;
            foreach (var cb in comboBoxes)
            {
                if (cb == null) continue;
                cb.Items.Clear();
                cb.Items.Add(""); // Blank item first
                for (int i = currentYear - 10; i <= currentYear + 10; i++) // Adjusted range
                {
                    cb.Items.Add(i.ToString());
                }
                cb.SelectedIndex = 0; // Select the blank item
            }
        }

        private void PopulateMonthComboBoxes(params ComboBox[] comboBoxes)
        {
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            foreach (var cb in comboBoxes)
            {
                if (cb == null) continue;
                cb.Items.Clear();
                cb.Items.Add(""); // Blank item first
                cb.Items.AddRange(months);
                cb.SelectedIndex = 0; // Select the blank item
            }
        }

        private void PopulateUnitComboBoxes(params ComboBox[] comboBoxes)
        {
            string[] units = { "Kg", "L", "Units", "g", "mg", "mL" };
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
            if (lblBmrDocNo != null && txtBmrDocNoDI != null && chkDocTypeBMRDI != null)
            {
                lblBmrDocNo.Visible = chkDocTypeBMRDI.Checked;
                txtBmrDocNoDI.Visible = chkDocTypeBMRDI.Checked;
                if (!chkDocTypeBMRDI.Checked) txtBmrDocNoDI.Clear();
            }
            if (lblBprDocNo != null && txtBprDocNoDI != null && chkDocTypeBPRDI != null)
            {
                lblBprDocNo.Visible = chkDocTypeBPRDI.Checked;
                txtBprDocNoDI.Visible = chkDocTypeBPRDI.Checked;
                if (!chkDocTypeBPRDI.Checked) txtBprDocNoDI.Clear();
            }
            if (lblAppendixDocNo != null && txtAppendixDocNoDI != null && chkDocTypeAppendixDI != null)
            {
                lblAppendixDocNo.Visible = chkDocTypeAppendixDI.Checked;
                txtAppendixDocNoDI.Visible = chkDocTypeAppendixDI.Checked;
                if (!chkDocTypeAppendixDI.Checked) txtAppendixDocNoDI.Clear();
            }
            if (lblAddendumDocNo != null && txtAddendumDocNoDI != null && chkDocTypeAddendumDI != null)
            {
                lblAddendumDocNo.Visible = chkDocTypeAddendumDI.Checked;
                txtAddendumDocNoDI.Visible = chkDocTypeAddendumDI.Checked;
                if (!chkDocTypeAddendumDI.Checked) txtAddendumDocNoDI.Clear();
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
            return $"REQ-{DateTime.Now.ToString("yyyyMMdd")}-{rnd.Next(100, 999)}";
        }

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox) // Changed return type
        {
            if (monthComboBox?.SelectedItem == null || string.IsNullOrWhiteSpace(monthComboBox.SelectedItem.ToString()) ||
                yearComboBox?.SelectedItem == null || string.IsNullOrWhiteSpace(yearComboBox.SelectedItem.ToString()))
            {
                return null;
            }
            return $"{monthComboBox.SelectedItem}/{yearComboBox.SelectedItem}";
        }


        private void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
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
                grpDocTypeDI?.Focus();
                return;
            }

            List<string> specificDocNumbers = new List<string>();
            if (chkDocTypeBMRDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { MessageBox.Show("Please enter BMR Document No.", "Validation Error"); txtBmrDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtBmrDocNoDI.Text);
            }
            if (chkDocTypeBPRDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { MessageBox.Show("Please enter BPR Document No.", "Validation Error"); txtBprDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtBprDocNoDI.Text);
            }
            if (chkDocTypeAppendixDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { MessageBox.Show("Please enter Appendix Document No.", "Validation Error"); txtAppendixDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtAppendixDocNoDI.Text);
            }
            if (chkDocTypeAddendumDI.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { MessageBox.Show("Please enter Addendum Document No.", "Validation Error"); txtAddendumDocNoDI.Focus(); return; }
                specificDocNumbers.Add(txtAddendumDocNoDI.Text);
            }
            string combinedDocumentNumbers = string.Join(",", specificDocNumbers);


            string parentBatchSizeString = null;
            if (!string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI?.Text))
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _)) // Just validate, don't store parsed value here
                {
                    MessageBox.Show("Invalid Parent Batch Size value.", "Validation Error"); txtParentBatchSizeValueDI.Focus(); return;
                }
                parentBatchSizeString = $"{txtParentBatchSizeValueDI.Text} {cmbParentBatchSizeUnitDI?.SelectedItem?.ToString()}";
            }

            string itemBatchSizeString = null;
            if (!string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI?.Text))
            {
                if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _))
                {
                    MessageBox.Show("Invalid Item Batch Size value.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return;
                }
                itemBatchSizeString = $"{txtItemBatchSizeValueDI.Text} {cmbItemBatchSizeUnitDI?.SelectedItem?.ToString()}";
            }


            var issuanceData = new
            {
                TrackerNo = lblTrackerNoValueDI?.Text ?? "N/A",
                RequestNo = txtRequestNoValueDI?.Text ?? "N/A",
                RequestDate = dtpRequestDateDI?.Value ?? DateTime.MinValue,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentTypes = selectedDocTypes, // Keep this for overall types selected
                DocumentNo = combinedDocumentNumbers, // Store combined specific numbers
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
                RequestedBy = toolStripStatusLabelUser?.Text.Replace("User: ", "") ?? "Unknown"
            };

            try
            {
                Console.WriteLine("--- Document Issuance Request Submitted ---");
                Console.WriteLine($"Tracker No: {issuanceData.TrackerNo}");
                Console.WriteLine($"Request No: {issuanceData.RequestNo}");
                Console.WriteLine($"Specific Document Nos: {issuanceData.DocumentNo}");
                // ... other logs ...

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
                lblStatusValueDI.ForeColor = SystemColors.ControlText;
            }
            LoadInitialDocumentIssuanceData();
        }

        private void ClearDocumentIssuanceForm()
        {
            if (chkDocTypeBMRDI != null) chkDocTypeBMRDI.Checked = false; // This will trigger CheckedChanged
            if (chkDocTypeBPRDI != null) chkDocTypeBPRDI.Checked = false;
            if (chkDocTypeAppendixDI != null) chkDocTypeAppendixDI.Checked = false;
            if (chkDocTypeAddendumDI != null) chkDocTypeAddendumDI.Checked = false;
            // DocTypeCheckBox_CheckedChanged will hide and clear textboxes

            if (dtpRequestDateDI != null) dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI != null)
            {
                if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
                else cmbFromDepartmentDI.SelectedItem = null;
            }

            if (txtParentBatchNoDI != null) txtParentBatchNoDI.Clear();
            if (txtParentBatchSizeValueDI != null) txtParentBatchSizeValueDI.Clear();
            if (cmbParentBatchSizeUnitDI != null && cmbParentBatchSizeUnitDI.Items.Count > 0) cmbParentBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbParentMfgMonthDI != null) cmbParentMfgMonthDI.SelectedIndex = 0;
            if (cmbParentMfgYearDI != null) cmbParentMfgYearDI.SelectedIndex = 0;
            if (cmbParentExpMonthDI != null) cmbParentExpMonthDI.SelectedIndex = 0;
            if (cmbParentExpYearDI != null) cmbParentExpYearDI.SelectedIndex = 0;

            if (txtProductDI != null) txtProductDI.Clear();
            if (txtBatchNoDI != null) txtBatchNoDI.Clear();
            if (txtItemBatchSizeValueDI != null) txtItemBatchSizeValueDI.Clear();
            if (cmbItemBatchSizeUnitDI != null && cmbItemBatchSizeUnitDI.Items.Count > 0) cmbItemBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbItemMfgMonthDI != null) cmbItemMfgMonthDI.SelectedIndex = 0;
            if (cmbItemMfgYearDI != null) cmbItemMfgYearDI.SelectedIndex = 0;
            if (cmbItemExpMonthDI != null) cmbItemExpMonthDI.SelectedIndex = 0;
            if (cmbItemExpYearDI != null) cmbItemExpYearDI.SelectedIndex = 0;
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
                if (dgvGmQueue.Columns.Contains("colGmDocTypes"))
                {
                    dgvGmQueue.Columns["colGmDocTypes"].DataPropertyName = "DocumentNo";
                    dgvGmQueue.Columns["colGmDocTypes"].HeaderText = "Document No.";
                }
                else if (dgvGmQueue.Columns.Contains("colGmDocumentNo"))
                {
                    dgvGmQueue.Columns["colGmDocumentNo"].DataPropertyName = "DocumentNo";
                }
                dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            }
            if (btnGmRefreshList != null) btnGmRefreshList.Click += BtnGmRefreshList_Click;
            if (btnGmAuthorize != null) btnGmAuthorize.Click += BtnGmAuthorize_Click;
            if (btnGmReject != null) btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            if (txtGmComment != null) txtGmComment.Clear();

            if ((loggedInRole == "GM_Operations" || loggedInRole == "Admin") && tabPageGmOperations != null && tabPageGmOperations.Enabled) LoadGmPendingQueue();
            else if (lblGmQueueTitle != null) lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        private void LoadGmPendingQueue()
        {
            if (dgvGmQueue != null)
            {
                var placeholderData = new List<object>();
                placeholderData.Add(new { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-5), Product = "Product A (Pharma)", DocumentNo = "BMR: BMR-001, APP: APP-001A", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-5).AddHours(2) });
                placeholderData.Add(new { RequestNo = "REQ-20240102-002", RequestDate = DateTime.Now.AddDays(-4), Product = "Product B (Vaccine)", DocumentNo = "BPR: BPR-002", PreparedBy = "another.requester", RequestedAt = DateTime.Now.AddDays(-4).AddHours(3) });
                placeholderData.Add(new { RequestNo = "REQ-20240103-003", RequestDate = DateTime.Now.AddDays(-3), Product = "Product C (Tablet)", DocumentNo = "ADD: ADD-003X", PreparedBy = "test.user", RequestedAt = DateTime.Now.AddDays(-3).AddHours(1) });
                dgvGmQueue.DataSource = placeholderData;
            }
            if (lblGmQueueTitle != null) lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue?.Rows.Count ?? 0})";
        }

        private void ClearGmSelectedRequestDetails()
        {
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
            if (selectedRow == null || selectedRow.IsNewRow) { ClearGmSelectedRequestDetails(); return; }
            string docNoColumnName = dgvGmQueue.Columns.Contains("colGmDocumentNo") ? "colGmDocumentNo" : "colGmDocTypes";

            if (txtGmDetailRequestNo != null) txtGmDetailRequestNo.Text = selectedRow.Cells["colGmRequestNo"]?.Value?.ToString() ?? "";
            if (txtGmDetailRequestDate != null) txtGmDetailRequestDate.Text = selectedRow.Cells["colGmRequestDate"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colGmRequestDate"].Value).ToString("dd-MMM-yyyy") : "";
            if (txtGmDetailProduct != null) txtGmDetailProduct.Text = selectedRow.Cells["colGmProduct"]?.Value?.ToString() ?? "";
            if (txtGmDetailDocTypes != null) txtGmDetailDocTypes.Text = selectedRow.Cells[docNoColumnName]?.Value?.ToString() ?? "";
            if (txtGmDetailPreparedBy != null) txtGmDetailPreparedBy.Text = selectedRow.Cells["colGmPreparedBy"]?.Value?.ToString() ?? "";
            if (txtGmDetailRequestedAt != null) txtGmDetailRequestedAt.Text = selectedRow.Cells["colGmRequestedAt"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colGmRequestedAt"].Value).ToString("dd-MMM-yyyy HH:mm") : "";

            if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Production Department (Simulated)";
            if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = $"B{DateTime.Now.Millisecond}";
            if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = DateTime.Now.AddMonths(-1).ToString("MMM/yyyy"); // Use MMM/yyyy
            if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = DateTime.Now.AddYears(1).ToString("MMM/yyyy"); // Use MMM/yyyy
            if (txtGmDetailMarket != null) txtGmDetailMarket.Text = "Domestic (Simulated)";
            if (txtGmDetailPackSize != null) txtGmDetailPackSize.Text = "10x10 (Simulated)";
            if (txtGmDetailRequesterComments != null) txtGmDetailRequesterComments.Text = "This is a critical request, please expedite. (Simulated Requester Comment)";
        }

        private void BtnGmRefreshList_Click(object sender, EventArgs e) { LoadGmPendingQueue(); if (txtGmComment != null) txtGmComment.Clear(); }
        private void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue != null && dgvGmQueue.SelectedRows.Count > 0) { DisplayGmSelectedRequestDetails(dgvGmQueue.SelectedRows[0]); if (txtGmComment != null) txtGmComment.Clear(); }
            else { ClearGmSelectedRequestDetails(); if (txtGmComment != null) txtGmComment.Clear(); }
        }
        private void BtnGmAuthorize_Click(object sender, EventArgs e)
        {
            if (dgvGmQueue == null || dgvGmQueue.SelectedRows.Count == 0) { MessageBox.Show("Please select a request.", "No Request Selected"); return; }
            string requestNo = txtGmDetailRequestNo?.Text ?? "N/A";
            if (MessageBox.Show($"Authorize request '{requestNo}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' authorized (Simulated)."); LoadGmPendingQueue(); ClearGmSelectedRequestDetails(); if (txtGmComment != null) txtGmComment.Clear();
            }
        }
        private void BtnGmReject_Click(object sender, EventArgs e)
        {
            if (dgvGmQueue == null || dgvGmQueue.SelectedRows.Count == 0) { MessageBox.Show("Please select a request.", "No Request Selected"); return; }
            if (txtGmComment != null && string.IsNullOrWhiteSpace(txtGmComment.Text)) { MessageBox.Show("Comments required for rejection."); txtGmComment.Focus(); return; }
            string requestNo = txtGmDetailRequestNo?.Text ?? "N/A";
            if (MessageBox.Show($"Reject request '{requestNo}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' rejected (Simulated)."); LoadGmPendingQueue(); ClearGmSelectedRequestDetails(); if (txtGmComment != null) txtGmComment.Clear();
            }
        }
        #endregion GM Operations Tab Logic

        private void SetupTlpQaRequestDetailsRowStyles()
        {
            if (this.tlpQaRequestDetails == null) return;
            this.tlpQaRequestDetails.RowStyles.Clear();
            float standardRowHeight = 28F;
            float specialRowHeight = 50F;
            if (this.tlpQaRequestDetails.RowCount >= 3) // Ensure enough rows for this logic
            {
                for (int i = 0; i < this.tlpQaRequestDetails.RowCount - 3; i++)
                {
                    this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight));
                }
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight)); // Requester Comments
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, specialRowHeight)); // GM Comments
                this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight)); // GM Action Time
            }
            else { for (int i = 0; i < this.tlpQaRequestDetails.RowCount; i++) this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, standardRowHeight)); }
        }

        #region QA Tab Logic

        private void InitializeQaTab()
        {
            if (dgvQaQueue != null)
            {
                dgvQaQueue.AutoGenerateColumns = false;
                if (dgvQaQueue.Columns.Contains("colQaDocTypes"))
                {
                    dgvQaQueue.Columns["colQaDocTypes"].DataPropertyName = "DocumentNo";
                    dgvQaQueue.Columns["colQaDocTypes"].HeaderText = "Document No.";
                }
                else if (dgvQaQueue.Columns.Contains("colQaDocumentNo"))
                {
                    dgvQaQueue.Columns["colQaDocumentNo"].DataPropertyName = "DocumentNo";
                }
                dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;
            }
            if (btnQaRefreshList != null) btnQaRefreshList.Click += BtnQaRefreshList_Click;
            if (btnQaApprove != null) btnQaApprove.Click += BtnQaApprove_Click;
            if (btnQaReject != null) btnQaReject.Click += BtnQaReject_Click;

            ClearQaSelectedRequestDetails();
            if (txtQaComment != null) txtQaComment.Clear();
            if (numQaPrintCount != null) numQaPrintCount.Value = 1;

            if ((loggedInRole == "QA" || loggedInRole == "Admin") && tabPageQa != null && tabPageQa.Enabled) LoadQaPendingQueue();
            else if (lblQaQueueTitle != null) lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }

        private void LoadQaPendingQueue()
        {
            if (dgvQaQueue != null)
            {
                var placeholderQaData = new List<object>();
                placeholderQaData.Add(new { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-5), Product = "Product A (Pharma)", DocumentNo = "BMR: BMR-001, APP: APP-001A", PreparedBy = "user.requester", AuthorizedBy = "gm.user", GmActionAt = DateTime.Now.AddDays(-2) });
                placeholderQaData.Add(new { RequestNo = "REQ-20240104-004", RequestDate = DateTime.Now.AddDays(-2), Product = "Product D (Syrup)", DocumentNo = "BPR: BPR-004, ADD: ADD-004Y", PreparedBy = "another.user", AuthorizedBy = "gm.user", GmActionAt = DateTime.Now.AddDays(-1) });
                dgvQaQueue.DataSource = placeholderQaData;
            }
            if (lblQaQueueTitle != null) lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue?.Rows.Count ?? 0})";
            ClearQaSelectedRequestDetails();
            if (txtQaComment != null) txtQaComment.Clear();
        }

        private void ClearQaSelectedRequestDetails()
        {
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
            if (txtQaDetailGmComment != null) txtQaDetailGmComment.Clear();
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Clear();
        }

        private void DisplayQaSelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (selectedRow == null || selectedRow.IsNewRow) { ClearQaSelectedRequestDetails(); return; }
            string docNoColumnName = dgvQaQueue.Columns.Contains("colQaDocumentNo") ? "colQaDocumentNo" : "colQaDocTypes";

            if (txtQaDetailRequestNo != null) txtQaDetailRequestNo.Text = selectedRow.Cells["colQaRequestNo"]?.Value?.ToString() ?? "";
            if (txtQaDetailRequestDate != null) txtQaDetailRequestDate.Text = selectedRow.Cells["colQaRequestDate"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colQaRequestDate"].Value).ToString("dd-MMM-yyyy") : "";
            if (txtQaDetailProduct != null) txtQaDetailProduct.Text = selectedRow.Cells["colQaProduct"]?.Value?.ToString() ?? "";
            if (txtQaDetailDocTypes != null) txtQaDetailDocTypes.Text = selectedRow.Cells[docNoColumnName]?.Value?.ToString() ?? "";
            if (txtQaDetailPreparedBy != null) txtQaDetailPreparedBy.Text = selectedRow.Cells["colQaPreparedBy"]?.Value?.ToString() ?? "";
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Text = selectedRow.Cells["colQaGmActionAt"]?.Value != null ? Convert.ToDateTime(selectedRow.Cells["colQaGmActionAt"].Value).ToString("dd-MMM-yyyy HH:mm") : "";

            if (txtQaDetailFromDept != null) txtQaDetailFromDept.Text = "Production (Simulated for QA)";
            if (txtQaDetailBatchNo != null) txtQaDetailBatchNo.Text = $"B{DateTime.Now.Second}";
            if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = DateTime.Now.AddDays(-30).ToString("MMM/yyyy");
            if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = DateTime.Now.AddYears(2).ToString("MMM/yyyy");
            if (txtQaDetailMarket != null) txtQaDetailMarket.Text = "Export (Simulated for QA)";
            if (txtQaDetailPackSize != null) txtQaDetailPackSize.Text = "20x5 (Simulated for QA)";
            if (txtQaDetailRequesterComments != null) txtQaDetailRequesterComments.Text = "Urgent request, please process. (Simulated Req Comment)";
            if (txtQaDetailGmComment != null) txtQaDetailGmComment.Text = "Looks good from operations side. (Simulated GM Comment)";
        }

        private void BtnQaRefreshList_Click(object sender, EventArgs e) { LoadQaPendingQueue(); if (txtQaComment != null) txtQaComment.Clear(); if (numQaPrintCount != null) numQaPrintCount.Value = 1; }
        private void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue != null && dgvQaQueue.SelectedRows.Count > 0) { DisplayQaSelectedRequestDetails(dgvQaQueue.SelectedRows[0]); if (txtQaComment != null) txtQaComment.Clear(); if (numQaPrintCount != null) numQaPrintCount.Value = 1; }
            else { ClearQaSelectedRequestDetails(); if (txtQaComment != null) txtQaComment.Clear(); if (numQaPrintCount != null) numQaPrintCount.Value = 1; }
        }
        private void BtnQaApprove_Click(object sender, EventArgs e)
        {
            if (dgvQaQueue == null || dgvQaQueue.SelectedRows.Count == 0) { MessageBox.Show("Please select a request."); return; }
            string requestNo = txtQaDetailRequestNo?.Text ?? "N/A";
            int printCount = (int)(numQaPrintCount?.Value ?? 1);
            if (MessageBox.Show($"Approve request '{requestNo}'?\nPrint Count: {printCount}", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' approved (Simulated). Printed {printCount} copies."); LoadQaPendingQueue(); ClearQaSelectedRequestDetails(); if (txtQaComment != null) txtQaComment.Clear(); if (numQaPrintCount != null) numQaPrintCount.Value = 1;
            }
        }
        private void BtnQaReject_Click(object sender, EventArgs e)
        {
            if (dgvQaQueue == null || dgvQaQueue.SelectedRows.Count == 0) { MessageBox.Show("Please select a request."); return; }
            if (txtQaComment != null && string.IsNullOrWhiteSpace(txtQaComment.Text)) { MessageBox.Show("Comments required for rejection."); txtQaComment.Focus(); return; }
            string requestNo = txtQaDetailRequestNo?.Text ?? "N/A";
            if (MessageBox.Show($"Reject request '{requestNo}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show($"Request '{requestNo}' rejected (Simulated)."); LoadQaPendingQueue(); ClearQaSelectedRequestDetails(); if (txtQaComment != null) txtQaComment.Clear(); if (numQaPrintCount != null) numQaPrintCount.Value = 1;
            }
        }

        #endregion QA Tab Logic

        #region Audit Trail Tab Logic

        private void InitializeAuditTrailTab()
        {
            if (cmbAuditStatus != null)
            {
                cmbAuditStatus.Items.Clear();
                cmbAuditStatus.Items.Add("All");
                cmbAuditStatus.Items.Add("Pending GM Approval");
                cmbAuditStatus.Items.Add("Pending QA Approval");
                cmbAuditStatus.Items.Add("Approved (Issued)");
                cmbAuditStatus.Items.Add("Rejected by GM");
                cmbAuditStatus.Items.Add("Rejected by QA");
                if (cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            }
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.AddDays(-7);
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now;
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
            }
            if (btnApplyAuditFilter != null) btnApplyAuditFilter.Click += BtnApplyAuditFilter_Click;
            if (btnClearAuditFilters != null) btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            if (btnRefreshAuditList != null) btnRefreshAuditList.Click += BtnRefreshAuditList_Click;
            if (btnExportToCsv != null) btnExportToCsv.Click += BtnExportToCsv_Click;
            if (btnExportToExcel != null) btnExportToExcel.Click += BtnExportToExcel_Click;
            if (dgvAuditTrail != null) dgvAuditTrail.DataError += DgvAuditTrail_DataError;
            LoadAuditTrailData();
        }

        private void DgvAuditTrail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"DataGridView DataError: Row {e.RowIndex}, Column {e.ColumnIndex} ({dgvAuditTrail.Columns[e.ColumnIndex].Name}). Exception: {e.Exception.Message}");
            MessageBox.Show($"Error displaying data in the grid at row {e.RowIndex + 1}, column '{dgvAuditTrail.Columns[e.ColumnIndex].HeaderText}'.\nDetails: {e.Exception.Message}", "Data Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetupAuditTrailColumns()
        {
            if (dgvAuditTrail == null) return;
            dgvAuditTrail.Columns.Clear();

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = "Product", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocumentNumbers", HeaderText = "Document No(s).", DataPropertyName = "DocumentNumbers", Width = 180, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditStatusDerived", HeaderText = "Status", DataPropertyName = "DerivedStatus", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditPreparedBy", HeaderText = "Prepared By", DataPropertyName = "PreparedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestedAt", HeaderText = "Requested At", DataPropertyName = "RequestedAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmAction", HeaderText = "GM Action", DataPropertyName = "GmOperationsAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditAuthorizedBy", HeaderText = "GM User", DataPropertyName = "AuthorizedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmActionAt", HeaderText = "GM Action At", DataPropertyName = "GmOperationsAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            DataGridViewTextBoxColumn colGmComment = new DataGridViewTextBoxColumn { Name = "colAuditGmComment", HeaderText = "GM Comment", DataPropertyName = "GmOperationsComment", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } };
            dgvAuditTrail.Columns.Add(colGmComment);
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaAction", HeaderText = "QA Action", DataPropertyName = "QAAction", Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditApprovedBy", HeaderText = "QA User", DataPropertyName = "ApprovedBy", Width = 120 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaActionAt", HeaderText = "QA Action At", DataPropertyName = "QAAt", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, Width = 130 });
            DataGridViewTextBoxColumn colQaComment = new DataGridViewTextBoxColumn { Name = "colAuditQaComment", HeaderText = "QA Comment", DataPropertyName = "QAComment", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } };
            dgvAuditTrail.Columns.Add(colQaComment);
        }

        private void LoadAuditTrailData()
        {
            DateTime fromDate = dtpAuditFrom?.Value.Date ?? DateTime.MinValue;
            DateTime toDate = dtpAuditTo?.Value.Date.AddDays(1).AddSeconds(-1) ?? DateTime.MaxValue;
            string statusFilter = cmbAuditStatus?.SelectedItem?.ToString() ?? "All";
            string requestNoFilter = txtAuditRequestNo?.Text.Trim() ?? "";
            string productFilter = txtAuditProduct?.Text.Trim() ?? "";

            var placeholderAuditData = new List<AuditTrailEntry>();
            if (statusFilter == "All" || statusFilter == "Approved (Issued)")
            {
                placeholderAuditData.Add(new AuditTrailEntry { RequestNo = "REQ-20240101-001", RequestDate = DateTime.Now.AddDays(-10), Product = "Product A (Pharma)", DocumentNumbers = "BMR: BMR-001, APP: APP-001A", DerivedStatus = "Approved (Issued)", PreparedBy = "user.requester", RequestedAt = DateTime.Now.AddDays(-10).AddHours(1), GmOperationsAction = "Authorized", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-9), GmOperationsComment = "Looks good.", QAAction = "Approved", ApprovedBy = "qa.user", QAAt = DateTime.Now.AddDays(-8), QAComment = "Verified and issued." });
            }
            if (statusFilter == "All" || statusFilter == "Rejected by GM")
            {
                placeholderAuditData.Add(new AuditTrailEntry { RequestNo = "REQ-20240102-002", RequestDate = DateTime.Now.AddDays(-5), Product = "Product B (Vaccine)", DocumentNumbers = "BPR: BPR-002", DerivedStatus = "Rejected by GM", PreparedBy = "another.requester", RequestedAt = DateTime.Now.AddDays(-5).AddHours(2), GmOperationsAction = "Rejected", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-4), GmOperationsComment = "Business case not valid." });
            }
            if (statusFilter == "All" || statusFilter == "Pending QA Approval")
            {
                placeholderAuditData.Add(new AuditTrailEntry { RequestNo = "REQ-20240104-004", RequestDate = DateTime.Now.AddDays(-2), Product = "Product D (Syrup)", DocumentNumbers = "BPR: BPR-004", DerivedStatus = "Pending QA Approval", PreparedBy = "another.user", RequestedAt = DateTime.Now.AddDays(-2).AddHours(1), GmOperationsAction = "Authorized", AuthorizedBy = "gm.user", GmOperationsAt = DateTime.Now.AddDays(-1), GmOperationsComment = "Approved by GM." });
            }

            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.DataSource = null;
                dgvAuditTrail.DataSource = placeholderAuditData;
            }
        }

        private void BtnApplyAuditFilter_Click(object sender, EventArgs e) { LoadAuditTrailData(); }
        private void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.AddDays(-7);
            if (dtpAuditTo != null) dtpAuditTo.Value = DateTime.Now;
            if (cmbAuditStatus != null && cmbAuditStatus.Items.Count > 0) cmbAuditStatus.SelectedIndex = 0;
            if (txtAuditRequestNo != null) txtAuditRequestNo.Clear();
            if (txtAuditProduct != null) txtAuditProduct.Clear();
            LoadAuditTrailData();
        }
        private void BtnRefreshAuditList_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail != null)
            {
                dgvAuditTrail.SuspendLayout();
                SetupAuditTrailColumns();
                dgvAuditTrail.ResumeLayout(true);
                LoadAuditTrailData();
                dgvAuditTrail.PerformLayout();
            }
        }
        private void BtnExportToCsv_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail == null || dgvAuditTrail.Rows.Count == 0) { MessageBox.Show("No data to export.", "Export Error"); return; }
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = $"AuditTrail_{DateTime.Now:yyyyMMddHHmmss}.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();
                    var headers = dgvAuditTrail.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(column => $"\"{EscapeCsvField(column.HeaderText)}\"").ToArray()));
                    foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        sb.AppendLine(string.Join(",", cells.Select(cell => $"\"{EscapeCsvField(cell.FormattedValue?.ToString())}\"").ToArray()));
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private string EscapeCsvField(string field) { return field?.Replace("\"", "\"\"") ?? ""; }
        private void BtnExportToExcel_Click(object sender, EventArgs e) { MessageBox.Show("Excel export functionality to be implemented.", "TODO"); }

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
                dgvUserRoles.ReadOnly = true;
                dgvUserRoles.DataSource = this.userRolesBindingSource;
                dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            }
            if (btnAddRole != null) btnAddRole.Click += BtnAddRole_Click;
            if (btnEditRole != null) btnEditRole.Click += BtnEditRole_Click;
            if (btnDeleteRole != null) btnDeleteRole.Click += BtnDeleteRole_Click;
            if (btnRefreshUserRoles != null) btnRefreshUserRoles.Click += BtnRefreshUserRoles_Click;
            if (txtRoleNameManage != null) txtRoleNameManage.Clear();
            if (btnEditRole != null) btnEditRole.Enabled = false;
            if (btnDeleteRole != null) btnDeleteRole.Enabled = false;
            if ((loggedInRole == "Admin") && tabPageUsers != null && tabPageUsers.Enabled) LoadUserRoles();
        }

        private void LoadUserRoles()
        {
            var placeholderRoles = new List<UserRole>();
            try
            {
                placeholderRoles.Add(new UserRole { RoleID = 1, RoleName = "Requester" });
                placeholderRoles.Add(new UserRole { RoleID = 2, RoleName = "GM_Operations" });
                placeholderRoles.Add(new UserRole { RoleID = 3, RoleName = "QA" });
                placeholderRoles.Add(new UserRole { RoleID = 4, RoleName = "Admin_Test_Updated" });
                placeholderRoles.Add(new UserRole { RoleID = 500 + DateTime.Now.Millisecond, RoleName = $"DynamicRole_{DateTime.Now.Millisecond}" });
                if (this.userRolesBindingSource != null)
                {
                    this.userRolesBindingSource.DataSource = null;
                    this.userRolesBindingSource.DataSource = placeholderRoles;
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
                UserRole selectedUserRole = selectedRow.DataBoundItem as UserRole;
                if (selectedUserRole != null)
                {
                    if (txtRoleNameManage != null) txtRoleNameManage.Text = selectedUserRole.RoleName;
                }
                else
                {
                    if (txtRoleNameManage != null && selectedRow.Cells["colUserRoleName"] != null && selectedRow.Cells["colUserRoleName"].Value != null)
                    {
                        txtRoleNameManage.Text = selectedRow.Cells["colUserRoleName"].Value.ToString();
                    }
                    else if (txtRoleNameManage != null) txtRoleNameManage.Text = "";
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

        private void BtnRefreshUserRoles_Click(object sender, EventArgs e) { LoadUserRoles(); }
        private void BtnAddRole_Click(object sender, EventArgs e) { MessageBox.Show("Add Role Dialog to be implemented.", "TODO"); }
        private void BtnEditRole_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0) { MessageBox.Show("Please select a role to edit."); return; }
            UserRole selectedUserRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
            if (selectedUserRole != null) MessageBox.Show($"Edit Role for '{selectedUserRole.RoleName}' (ID: {selectedUserRole.RoleID}) to be implemented.", "TODO");
            else MessageBox.Show("Selected role data is incomplete.", "Error");
        }
        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0) { MessageBox.Show("Please select a role to delete."); return; }
            UserRole selectedUserRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
            string roleName = selectedUserRole != null ? $"'{selectedUserRole.RoleName}'" : "the selected role";
            if (MessageBox.Show($"Are you sure you want to delete {roleName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show($"{roleName} deletion to be implemented.", "TODO");
            }
        }

        #endregion Users Tab Logic
    }
}