// Generated with a robust Font-based scaling approach.
// The form's AutoScaleMode is set to Font, and a base font is set on the main form.
// All child controls are configured to inherit this font, allowing the .NET Framework
// to automatically scale the entire UI based on the system's DPI and font settings.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IssuanceApp.Data;


namespace DocumentIssuanceApp
{

    public partial class MainForm : Form
    {
        private Timer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null; // Store actual username after login

        private BindingSource userRolesBindingSource;

        // --- New controls for dynamic UI ---
        private List<TabPage> allTabPages;
        private ToolStripDropDownButton toolStripDropDownButtonUserActions;
        private ToolStripMenuItem signOutToolStripMenuItem;


        public MainForm()
        {
            InitializeComponent();
            InitializeDynamicControls(); // Initialize programmatically added controls

            SetupStatusBar();

            InitializeLoginTab();

            InitializeDocumentIssuanceTab();
            LoadInitialDocumentIssuanceData();

            InitializeGmOperationsTab();

            InitializeQaTab();

            InitializeAuditTrailTab();
            InitializeUsersTab();

            SetupTabs();

            // NOTE: Scaling is now handled by AutoScaleMode=Font.
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeDynamicControls()
        {
            // 1. Cache all TabPage controls for dynamic showing/hiding
            allTabPages = new List<TabPage>();
            foreach (TabPage tp in tabControlMain.TabPages)
            {
                allTabPages.Add(tp);
            }

            // 2. Create and configure the Sign Out button
            this.toolStripDropDownButtonUserActions = new ToolStripDropDownButton();
            this.signOutToolStripMenuItem = new ToolStripMenuItem();

            // -- Sign Out Menu Item --
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += SignOutToolStripMenuItem_Click;

            // -- User Actions DropDown Button --
            this.toolStripDropDownButtonUserActions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonUserActions.DropDownItems.AddRange(new ToolStripItem[] {
            this.signOutToolStripMenuItem});
            this.toolStripDropDownButtonUserActions.Name = "toolStripDropDownButtonUserActions";
            this.toolStripDropDownButtonUserActions.Size = new System.Drawing.Size(90, 24);
            this.toolStripDropDownButtonUserActions.Text = "User Actions";
            this.toolStripDropDownButtonUserActions.Visible = false; // Initially hidden

            // Add the new button to the status strip
            // Insert it right after the user status label for a clean look
            this.statusStripMain.Items.Insert(1, this.toolStripDropDownButtonUserActions);
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to sign out and exit the application?",
                                             "Confirm Sign Out",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Document Issuance System";
            statusTimer = new Timer();
            statusTimer.Interval = 1000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
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
                    // Extract username after the backslash, or use the full name if no backslash
                    osUserDisplay = fullUserName.Split('\\').LastOrDefault();
                    if (string.IsNullOrEmpty(osUserDisplay))
                    {
                        osUserDisplay = fullUserName;
                    }
                }
            }
            catch (System.Security.SecurityException secEx)
            {
                Console.WriteLine("Security error getting OS username: " + secEx.Message);
                osUserDisplay = "N/A (Permissions)";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting OS username: " + ex.Message);
                osUserDisplay = "N/A (Error)";
            }
            this.loggedInUserName = osUserDisplay; // Store the extracted OS username for later use
            toolStripStatusLabelUser.Text = $"User: {osUserDisplay} (Not Logged In)";
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

            // --- DB INTEGRATION POINT ---
            // Instead of hardcoding roles, they should be fetched from the database.
            // This makes the application more maintainable.
            //
            // SQL Statement:
            // SELECT RoleName FROM dbo.User_Roles ORDER BY RoleName;
            //
            // C# Logic:
            // 1. Execute the query.
            // 2. Loop through the results and add each RoleName to cmbRole.Items.
            // 3. Handle potential exceptions (e.g., DB connection failed).
            //
            // Example Placeholder:
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
                // The loggedInUserName field is already populated with the OS user from SetupStatusBar.
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
                // Do not null out the OS username. SetupStatusBar will reset the display text.
                SetupStatusBar();
                EnableTabsBasedOnRole(null);
            }
        }

        private bool AuthenticateUser(string roleName, string password)
        {
            // --- DB INTEGRATION POINT ---
            // This is a critical security point. The hardcoded passwords must be replaced
            // with a database check against the User_Roles table.
            // IMPORTANT: Passwords in the DB should be stored as salted hashes, not plain text.
            //
            // SQL Statement:
            // SELECT PasswordHash FROM dbo.User_Roles WHERE RoleName = @roleName;
            //
            // C# Logic:
            // 1. Execute the query using the provided 'roleName' as a parameter (@roleName).
            // 2. If a record is found, retrieve the 'PasswordHash' from the database.
            // 3. Use a secure hashing library (e.g., BCrypt.Net) to verify the user-provided 'password'
            //    against the database hash.
            // 4. Return true if they match, otherwise return false.
            //
            // Potential Issue: Case-sensitivity of RoleName depends on the database's collation.
            // For logins, a case-insensitive collation (default in SQL Server) is usually acceptable.
            //
            // Example Placeholder:
            if (roleName == "Requester" && password == "test") return true;
            if (roleName == "GM_Operations" && password == "test1") return true;
            if (roleName == "QA" && password == "test2") return true;
            if (roleName == "Admin" && password == "adminpass") return true; // Example Admin password
            return false;
        }

        private void EnableTabsBasedOnRole(string role)
        {
            bool isLoggedIn = !string.IsNullOrEmpty(role);

            // Show/hide the "User Actions" (Sign Out) button
            if (toolStripDropDownButtonUserActions != null)
            {
                toolStripDropDownButtonUserActions.Visible = isLoggedIn;
            }

            // Clear all tabs before adding back the accessible ones
            tabControlMain.TabPages.Clear();

            if (!isLoggedIn)
            {
                // If logged out, only show the Login tab
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin));
                if (loginTab != null)
                {
                    tabControlMain.TabPages.Add(loginTab);
                }
                return;
            }

            // If logged in, add tabs based on role, but never the Login tab
            bool isAdmin = (role == "Admin");
            bool isRequester = (role == "Requester");
            bool isGm = (role == "GM_Operations");
            bool isQa = (role == "QA");

            foreach (var tab in allTabPages)
            {
                bool shouldShowTab = false;
                switch (tab.Name)
                {
                    case nameof(tabPageLogin):
                        shouldShowTab = false; // Never show login tab when logged in
                        break;
                    case nameof(tabPageDocumentIssuance):
                        shouldShowTab = isRequester || isAdmin;
                        break;
                    case nameof(tabPageGmOperations):
                        shouldShowTab = isGm || isAdmin;
                        break;
                    case nameof(tabPageQa):
                        shouldShowTab = isQa || isAdmin;
                        break;
                    case nameof(tabPageUsers):
                        shouldShowTab = isAdmin;
                        break;
                    case nameof(tabPageAuditTrail):
                        shouldShowTab = true; // Always show for any logged-in user
                        break;
                }

                if (shouldShowTab)
                {
                    tabControlMain.TabPages.Add(tab);
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
                    targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageDocumentIssuance));
                    break;
                case "GM_Operations":
                    targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageGmOperations));
                    break;
                case "QA":
                    targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageQa));
                    break;
                case "Admin":
                    targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageUsers)); // Admin default to Users tab
                    break;
                default:
                    targetTab = allTabPages.FirstOrDefault(t => t.Name == nameof(tabPageLogin)); // Fallback to login tab
                    break;
            }

            if (targetTab != null && tabControlMain.TabPages.Contains(targetTab))
            {
                tabControlMain.SelectedTab = targetTab;
            }
            else if (tabControlMain.TabPages.Count > 0)
            {
                // Fallback if the intended tab is not available, select the first one
                tabControlMain.SelectedIndex = 0;
            }
        }

        private void SetupTabs()
        {
            // Any general tab setup logic can go here.
            // For now, most setup is role-dependent after login.
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

        #region Document Issuance Tab Logic

        private void InitializeDocumentIssuanceTab()
        {
            // 1. Document Type Checkboxes & Document Numbers
            if (chkDocTypeBMRDI != null) chkDocTypeBMRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            if (chkDocTypeBPRDI != null) chkDocTypeBPRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            if (chkDocTypeAppendixDI != null) chkDocTypeAppendixDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            if (chkDocTypeAddendumDI != null) chkDocTypeAddendumDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            UpdateDocumentNumberFieldsVisibility();

            // 2. Date Fields -> Month/Year Dropdowns
            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames
                                      .Where(m => !string.IsNullOrEmpty(m)).ToArray();
            int currentYear = DateTime.Now.Year;
            List<string> years = Enumerable.Range(currentYear - 10, 21).Select(y => y.ToString()).ToList();

            PopulateMonthYearComboBox(cmbParentMfgMonthDI, cmbParentMfgYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbParentExpMonthDI, cmbParentExpYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbItemMfgMonthDI, cmbItemMfgYearDI, monthNames, years, false);
            PopulateMonthYearComboBox(cmbItemExpMonthDI, cmbItemExpYearDI, monthNames, years, false);

            // 3. Batch Size Fields -> Value + Unit
            string[] batchUnits = { "KGS", "TAB", "ML", "GM", "LTR", "MG", "CAPS", "VIALS", "AMPOULES" };
            PopulateUnitComboBox(cmbParentBatchSizeUnitDI, batchUnits, true);
            PopulateUnitComboBox(cmbItemBatchSizeUnitDI, batchUnits, false);

            if (txtParentBatchSizeValueDI != null) txtParentBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;
            if (txtItemBatchSizeValueDI != null) txtItemBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;

            // 4. Department Dropdown Constraint
            if (cmbFromDepartmentDI != null)
            {
                cmbFromDepartmentDI.Items.Clear();
                cmbFromDepartmentDI.Items.AddRange(new string[] {
                    "Production Department",
                    "Quality Assurance",
                    "Research & Development",
                    "Regulatory Affairs",
                    "Manufacturing",
                    "Packaging Department"
                });
                if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
            }

            if (dtpRequestDateDI != null) dtpRequestDateDI.Value = DateTime.Now;
            if (lblStatusValueDI != null) lblStatusValueDI.Text = "Ready to create a new request.";
            if (btnSubmitRequestDI != null) btnSubmitRequestDI.Click += BtnSubmitRequestDI_Click;
            if (btnClearFormDI != null) btnClearFormDI.Click += BtnClearFormDI_Click;

            LoadInitialDocumentIssuanceData();
        }

        private void DocTypeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDocumentNumberFieldsVisibility();
        }

        private void UpdateDocumentNumberFieldsVisibility()
        {
            bool bmrChecked = chkDocTypeBMRDI?.Checked ?? false;
            if (lblBmrDocNo != null) lblBmrDocNo.Visible = bmrChecked;
            if (txtBmrDocNoDI != null) txtBmrDocNoDI.Visible = bmrChecked;
            if (!bmrChecked && txtBmrDocNoDI != null) txtBmrDocNoDI.Clear();

            bool bprChecked = chkDocTypeBPRDI?.Checked ?? false;
            if (lblBprDocNo != null) lblBprDocNo.Visible = bprChecked;
            if (txtBprDocNoDI != null) txtBprDocNoDI.Visible = bprChecked;
            if (!bprChecked && txtBprDocNoDI != null) txtBprDocNoDI.Clear();

            bool appendixChecked = chkDocTypeAppendixDI?.Checked ?? false;
            if (lblAppendixDocNo != null) lblAppendixDocNo.Visible = appendixChecked;
            if (txtAppendixDocNoDI != null) txtAppendixDocNoDI.Visible = appendixChecked;
            if (!appendixChecked && txtAppendixDocNoDI != null) txtAppendixDocNoDI.Clear();

            bool addendumChecked = chkDocTypeAddendumDI?.Checked ?? false;
            if (lblAddendumDocNo != null) lblAddendumDocNo.Visible = addendumChecked;
            if (txtAddendumDocNoDI != null) txtAddendumDocNoDI.Visible = addendumChecked;
            if (!addendumChecked && txtAddendumDocNoDI != null) txtAddendumDocNoDI.Clear();
        }

        private void PopulateMonthYearComboBox(ComboBox cmbMonth, ComboBox cmbYear, string[] months, List<string> years, bool allowNotApplicable)
        {
            if (cmbMonth != null)
            {
                cmbMonth.Items.Clear();
                if (allowNotApplicable) cmbMonth.Items.Add("N/A");
                cmbMonth.Items.AddRange(months);
                cmbMonth.SelectedIndex = allowNotApplicable ? 0 : (DateTime.Now.Month - 1);
            }
            if (cmbYear != null)
            {
                cmbYear.Items.Clear();
                if (allowNotApplicable) cmbYear.Items.Add("N/A");
                cmbYear.Items.AddRange(years.ToArray());
                cmbYear.SelectedItem = allowNotApplicable ? "N/A" : DateTime.Now.Year.ToString();
            }
        }

        private void PopulateUnitComboBox(ComboBox cmbUnit, string[] units, bool allowNotApplicable)
        {
            if (cmbUnit != null)
            {
                cmbUnit.Items.Clear();
                if (allowNotApplicable) cmbUnit.Items.Add("N/A");
                cmbUnit.Items.AddRange(units);
                cmbUnit.SelectedIndex = 0;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void LoadInitialDocumentIssuanceData()
        {
            if (lblTrackerNoValueDI != null) lblTrackerNoValueDI.Text = GenerateNewTrackerNumber();
            if (txtRequestNoValueDI != null) txtRequestNoValueDI.Text = GenerateNewRequestNumber();
        }

        private string GenerateNewTrackerNumber()
        {
            return $"TRK-{DateTime.Now:yyyyMMddHHmmssfff}";
        }

        private string GenerateNewRequestNumber()
        {
            // --- DB INTEGRATION POINT (CRITICAL) ---
            // The current random number generation is NOT safe for a multi-user environment.
            // It can create a "race condition" where two users get the same number.
            // The correct approach is to use a database SEQUENCE object.
            //
            // **Step 1: Create the SEQUENCE in SQL Server (one-time setup)**
            // CREATE SEQUENCE dbo.DailyRequestSequence AS INT START WITH 1 INCREMENT BY 1;
            //
            // **Step 2: Create a SQL Server Agent Job to reset the sequence daily at midnight.**
            // Job Step T-SQL: ALTER SEQUENCE dbo.DailyRequestSequence RESTART WITH 1;
            //
            // **Step 3: Replace the C# logic below with a database call.**
            //
            // New SQL Statement to execute here:
            // SELECT NEXT VALUE FOR dbo.DailyRequestSequence;
            //
            // New C# Logic:
            // 1. Execute the query above. It will return a single integer (e.g., 1, 2, 3...).
            // 2. Format that integer into the final request number string.
            //    Example: int nextVal = (int)command.ExecuteScalar();
            //             return $"REQ-{DateTime.Now:yyyyMMdd}-{nextVal:D3}";
            // This is guaranteed to be unique and avoids race conditions.
            //
            // Example Placeholder:
            Random rnd = new Random();
            string sequence = rnd.Next(1, 1000).ToString("D3");
            return $"REQ-{DateTime.Now:yyyyMMdd}-{sequence}";
        }

        private void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            if (cmbFromDepartmentDI?.SelectedItem == null || string.IsNullOrWhiteSpace(cmbFromDepartmentDI.SelectedItem.ToString()))
            { MessageBox.Show("Please select a 'From Department'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbFromDepartmentDI?.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtProductDI?.Text))
            { MessageBox.Show("Please enter the 'Product'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtProductDI?.Focus(); return; }

            // --- Collect and Validate Document Numbers ---
            var docNumbersList = new List<string>();
            if (chkDocTypeBMRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { MessageBox.Show("BMR is checked, please enter BMR Document No.", "Validation Error"); txtBmrDocNoDI.Focus(); return; } docNumbersList.Add(txtBmrDocNoDI.Text.Trim()); }
            if (chkDocTypeBPRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { MessageBox.Show("BPR is checked, please enter BPR Document No.", "Validation Error"); txtBprDocNoDI.Focus(); return; } docNumbersList.Add(txtBprDocNoDI.Text.Trim()); }
            if (chkDocTypeAppendixDI.Checked) { if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { MessageBox.Show("Appendix is checked, please enter Appendix Document No.", "Validation Error"); txtAppendixDocNoDI.Focus(); return; } docNumbersList.Add(txtAppendixDocNoDI.Text.Trim()); }
            if (chkDocTypeAddendumDI.Checked) { if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { MessageBox.Show("Addendum is checked, please enter Addendum Document No.", "Validation Error"); txtAddendumDocNoDI.Focus(); return; } docNumbersList.Add(txtAddendumDocNoDI.Text.Trim()); }

            if (!docNumbersList.Any())
            {
                MessageBox.Show("Please select at least one 'Document Type' and provide its number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grpDocTypeDI?.Focus();
                return;
            }
            string combinedDocumentNumbers = string.Join(",", docNumbersList);

            // --- Collect and Validate Batch Sizes ---
            string parentBatchSizeStr = null;
            bool parentBatchValueEntered = !string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI?.Text);
            bool parentBatchUnitSelected = cmbParentBatchSizeUnitDI?.SelectedItem != null && cmbParentBatchSizeUnitDI.SelectedItem.ToString() != "N/A";
            if (parentBatchValueEntered)
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _)) { MessageBox.Show("Parent Batch Size must be a valid number.", "Validation Error"); txtParentBatchSizeValueDI.Focus(); return; }
                if (!parentBatchUnitSelected) { MessageBox.Show("Please select a Unit for the Parent Batch Size.", "Validation Error"); cmbParentBatchSizeUnitDI.Focus(); return; }
                parentBatchSizeStr = $"{txtParentBatchSizeValueDI.Text.Trim()} {cmbParentBatchSizeUnitDI.SelectedItem}";
            }

            string itemBatchSizeStr;
            if (string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI?.Text)) { MessageBox.Show("Item Batch Size value is required.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _)) { MessageBox.Show("Item Batch Size must be a valid number.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (cmbItemBatchSizeUnitDI?.SelectedItem == null || cmbItemBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { MessageBox.Show("Please select a Unit for the Item Batch Size.", "Validation Error"); cmbItemBatchSizeUnitDI.Focus(); return; }
            itemBatchSizeStr = $"{txtItemBatchSizeValueDI.Text.Trim()} {cmbItemBatchSizeUnitDI.SelectedItem}";

            // --- Data Collection ---
            var issuanceData = new
            {
                RequestNo = txtRequestNoValueDI?.Text ?? "N/A",
                RequestDate = dtpRequestDateDI?.Value.Date ?? DateTime.MinValue.Date,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentNo = combinedDocumentNumbers,
                ParentBatchNumber = string.IsNullOrWhiteSpace(txtParentBatchNoDI?.Text) ? null : txtParentBatchNoDI.Text.Trim(),
                ParentBatchSize = parentBatchSizeStr,
                ParentMfgDate = GetDateStringFromComboBoxes(cmbParentMfgMonthDI, cmbParentMfgYearDI),
                ParentExpDate = GetDateStringFromComboBoxes(cmbParentExpMonthDI, cmbParentExpYearDI),
                Product = txtProductDI.Text.Trim(),
                BatchNo = string.IsNullOrWhiteSpace(txtBatchNoDI?.Text) ? null : txtBatchNoDI.Text.Trim(),
                BatchSize = itemBatchSizeStr,
                ItemMfgDate = GetDateStringFromComboBoxes(cmbItemMfgMonthDI, cmbItemMfgYearDI),
                ItemExpDate = GetDateStringFromComboBoxes(cmbItemExpMonthDI, cmbItemExpYearDI),
                Market = string.IsNullOrWhiteSpace(txtMarketDI?.Text) ? null : txtMarketDI.Text.Trim(),
                PackSize = string.IsNullOrWhiteSpace(txtPackSizeDI?.Text) ? null : txtPackSizeDI.Text.Trim(),
                ExportOrderNo = string.IsNullOrWhiteSpace(txtExportOrderNoDI?.Text) ? null : txtExportOrderNoDI.Text.Trim(),
                Remarks = txtRemarksDI?.Text.Trim(),
                RequestedBy = loggedInUserName ?? (toolStripStatusLabelUser?.Text.Replace("User: ", "").Split('(')[0].Trim() ?? "Unknown")
            };

            try
            {
                // --- DB INTEGRATION POINT ---
                // This is the core data insertion logic. The collected data in 'issuanceData'
                // needs to be saved to the database. This should be done within a transaction
                // to ensure both tables (Doc_Issuance and Issuance_Tracker) are updated correctly.
                //
                // **Best Practice: Add a UNIQUE constraint to the RequestNo column in the DB.**
                // ALTER TABLE dbo.Doc_Issuance ADD CONSTRAINT UQ_Doc_Issuance_RequestNo UNIQUE (RequestNo);
                // This provides a final layer of protection against duplicate request numbers.
                //
                // C# Logic:
                // 1. Begin a SQL transaction.
                // 2. Execute the first INSERT statement into Doc_Issuance.
                // 3. Get the ID of the newly inserted row using SCOPE_IDENTITY().
                // 4. Execute the second INSERT statement into Issuance_Tracker, using the new ID.
                // 5. If both succeed, commit the transaction.
                // 6. If either fails, roll back the transaction.
                //
                // SQL Statement 1 (Insert into main table and get ID):
                // DECLARE @NewIssuanceID INT;
                // INSERT INTO dbo.Doc_Issuance (RequestNo, RequestDate, FromDepartment, DocumentNo, ParentBatchNumber, ParentBatchSize, ParentMfgDate, ParentExpDate, Product, BatchNo, BatchSize, ItemMfgDate, ItemExpDate, Market, PackSize, ExportOrderNo)
                // VALUES (@RequestNo, @RequestDate, @FromDepartment, @DocumentNo, @ParentBatchNumber, @ParentBatchSize, @ParentMfgDate, @ParentExpDate, @Product, @BatchNo, @BatchSize, @ItemMfgDate, @ItemExpDate, @Market, @PackSize, @ExportOrderNo);
                // SET @NewIssuanceID = SCOPE_IDENTITY();
                // SELECT @NewIssuanceID;
                //
                // SQL Statement 2 (Insert into tracker table):
                // INSERT INTO dbo.Issuance_Tracker (IssuanceID, PreparedBy, RequestedAt, RequestComment)
                // VALUES (@IssuanceID, @PreparedBy, GETDATE(), @RequestComment);
                //
                // Note: All @variables should be passed as secure SQL parameters.
                //
                // Example Placeholder:
                Console.WriteLine("--- Document Issuance Request Submitted (Updated Formats) ---");

                lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                lblStatusValueDI.ForeColor = Color.Green;
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!\nTracker No: {lblTrackerNoValueDI?.Text ?? "N/A"}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearDocumentIssuanceForm();
                LoadInitialDocumentIssuanceData();
            }
            catch (Exception ex)
            {
                lblStatusValueDI.Text = "Error submitting request.";
                lblStatusValueDI.ForeColor = Color.Red;
                MessageBox.Show($"Error submitting request: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (cmbFromDepartmentDI != null && cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;

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
            if (cmbItemMfgMonthDI != null) cmbItemMfgMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            if (cmbItemMfgYearDI != null) cmbItemMfgYearDI.SelectedItem = DateTime.Now.Year.ToString();
            if (cmbItemExpMonthDI != null) cmbItemExpMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            if (cmbItemExpYearDI != null) cmbItemExpYearDI.SelectedItem = DateTime.Now.Year.ToString();

            if (txtMarketDI != null) txtMarketDI.Clear();
            if (txtPackSizeDI != null) txtPackSizeDI.Clear();
            if (txtExportOrderNoDI != null) txtExportOrderNoDI.Clear();
            if (txtRemarksDI != null) txtRemarksDI.Clear();

            if (lblStatusValueDI != null) lblStatusValueDI.Text = "Form cleared.";
        }

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox)
        {
            string month = monthComboBox?.SelectedItem?.ToString();
            string year = yearComboBox?.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(year) || month == "N/A" || year == "N/A")
            {
                return null;
            }
            return $"{month}/{year}";
        }

        #endregion Document Issuance Tab Logic

        #region GM Operations Tab Logic

        // --- DB PERFORMANCE BEST PRACTICE ---
        // For the GM, QA, and Audit Trail tabs to be performant as data grows,
        // it is CRITICAL to add indexes to the database tables. Without them,
        // the application will become very slow.
        //
        // Recommended Indexes (run these on your SQL Server database):
        //
        // -- Speeds up looking for a request by its unique number
        // CREATE UNIQUE INDEX IX_Doc_Issuance_RequestNo ON dbo.Doc_Issuance(RequestNo);
        //
        // -- Speeds up the JOIN between the two main tables
        // CREATE INDEX IX_Issuance_Tracker_IssuanceID ON dbo.Issuance_Tracker(IssuanceID);
        //
        // -- A "covering index" to make loading the GM and QA queues extremely fast
        // CREATE INDEX IX_Issuance_Tracker_WorkflowStatus
        // ON dbo.Issuance_Tracker(GmOperationsAction, QAAction)
        // INCLUDE (PreparedBy, AuthorizedBy, GmOperationsAt);
        //
        // -- Speeds up date range filtering in the Audit Trail
        // CREATE INDEX IX_Doc_Issuance_RequestDate ON dbo.Doc_Issuance(RequestDate);
        // -----------------------------------------------------------------

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

            // --- DB INTEGRATION POINT ---
            // The placeholder data should be replaced with a query that fetches all requests
            // awaiting GM action. These are requests where `GmOperationsAction` is NULL.
            //
            // SQL Statement:
            // SELECT
            //     i.RequestNo,
            //     i.RequestDate,
            //     i.Product,
            //     i.DocumentNo,
            //     t.PreparedBy,
            //     t.RequestedAt
            // FROM
            //     dbo.Doc_Issuance AS i
            // JOIN
            //     dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
            // WHERE
            //     t.GmOperationsAction IS NULL
            // ORDER BY
            //     t.RequestedAt ASC;
            //
            // C# Logic:
            // 1. Execute the query.
            // 2. Bind the resulting DataTable or List of objects to dgvGmQueue.DataSource.
            // 3. Update the queue count label.
            //
            // Example Placeholder:
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

            // --- DB INTEGRATION POINT ---
            // The hardcoded details based on RequestNo should be replaced by a single, detailed
            // database query when a user selects a row in the grid.
            //
            // SQL Statement:
            // SELECT
            //     i.*, -- Selects all columns from Doc_Issuance
            //     t.RequestComment
            // FROM
            //     dbo.Doc_Issuance AS i
            // JOIN
            //     dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
            // WHERE
            //     i.RequestNo = @RequestNo;
            //
            // C# Logic:
            // 1. Get the RequestNo from the selected grid row.
            // 2. Execute the query using the RequestNo as a parameter (@RequestNo).
            // 3. Populate all the textboxes in the 'grpGmSelectedRequest' groupbox with the data
            //    returned from the query.
            //
            // Example Placeholder:
            string docNoColumnNameInGridData = "DocumentNo";

            Func<string, string> GetValueFromCellByBoundName = (boundPropertyName) =>
            {
                var cell = selectedRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.OwningColumn.DataPropertyName == boundPropertyName);
                return cell?.Value?.ToString() ?? "";
            };
            Func<string, string, string> GetDateValueFromCellByBoundName = (boundPropertyName, format) =>
            {
                var cell = selectedRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.OwningColumn.DataPropertyName == boundPropertyName);
                return cell?.Value != null && cell.Value is DateTime dt ? dt.ToString(format, CultureInfo.InvariantCulture) : (cell?.Value?.ToString() ?? "");
            };


            if (txtGmDetailRequestNo != null) txtGmDetailRequestNo.Text = GetValueFromCellByBoundName("RequestNo");
            if (txtGmDetailRequestDate != null) txtGmDetailRequestDate.Text = GetDateValueFromCellByBoundName("RequestDate", "dd-MMM-yyyy");
            if (txtGmDetailProduct != null) txtGmDetailProduct.Text = GetValueFromCellByBoundName("Product");
            if (txtGmDetailDocTypes != null) txtGmDetailDocTypes.Text = GetValueFromCellByBoundName(docNoColumnNameInGridData);
            if (txtGmDetailPreparedBy != null) txtGmDetailPreparedBy.Text = GetValueFromCellByBoundName("PreparedBy");
            if (txtGmDetailRequestedAt != null) txtGmDetailRequestedAt.Text = GetDateValueFromCellByBoundName("RequestedAt", "dd-MMM-yyyy HH:mm");

            var requestNo = GetValueFromCellByBoundName("RequestNo");
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
                if (txtGmDetailFromDept != null) txtGmDetailFromDept.Text = "Production Department (Simulated)";
                if (txtGmDetailBatchNo != null) txtGmDetailBatchNo.Text = $"B{DateTime.Now.Millisecond:D3}";
                if (txtGmDetailMfgDate != null) txtGmDetailMfgDate.Text = DateTime.Now.AddMonths(-1).ToString("MMM/yyyy", CultureInfo.InvariantCulture);
                if (txtGmDetailExpDate != null) txtGmDetailExpDate.Text = DateTime.Now.AddYears(1).ToString("MMM/yyyy", CultureInfo.InvariantCulture);
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
                // --- DB INTEGRATION POINT (AUTHORIZE) ---
                // This action should update the Issuance_Tracker table for the selected request.
                //
                // SQL Statement:
                // UPDATE dbo.Issuance_Tracker
                // SET
                //     GmOperationsAction = 'Authorized',
                //     AuthorizedBy = @AuthorizedBy,
                //     GmOperationsAt = GETDATE(),
                //     GmOperationsComment = @GmOperationsComment
                // WHERE
                //     IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);
                //
                // **Best Practice: Check for stale data in a multi-user environment.**
                // The `ExecuteNonQuery()` method in C# returns the number of rows affected.
                // If it returns 0, it means another user already acted on this request.
                // You should inform the user and refresh the grid.
                //
                // C# Logic:
                // int rowsAffected = command.ExecuteNonQuery();
                // if (rowsAffected > 0) { // Success }
                // else { // Failure, data was stale }
                //
                // Example Placeholder:
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
                // --- DB INTEGRATION POINT (REJECT) ---
                // This is similar to Authorize but sets the action to 'Rejected'.
                //
                // SQL Statement:
                // UPDATE dbo.Issuance_Tracker
                // SET
                //     GmOperationsAction = 'Rejected',
                //     AuthorizedBy = @AuthorizedBy,
                //     GmOperationsAt = GETDATE(),
                //     GmOperationsComment = @GmOperationsComment
                // WHERE
                //     IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);
                //
                // **Best Practice: Also check rows affected here, just like in Authorize.**
                //
                // Example Placeholder:
                MessageBox.Show($"Request '{requestNo}' rejected (Simulated). Comment: {txtGmComment?.Text}", "Rejection Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGmPendingQueue();
            }
        }
        #endregion GM Operations Tab Logic

        #region QA Tab Logic

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
            // --- DB INTEGRATION POINT ---
            // This query should fetch requests that have been authorized by the GM but are
            // still awaiting final approval/rejection from QA.
            // Condition: GmOperationsAction = 'Authorized' AND QAAction IS NULL.
            //
            // SQL Statement:
            // SELECT
            //     i.RequestNo,
            //     i.RequestDate,
            //     i.Product,
            //     i.DocumentNo,
            //     t.PreparedBy,
            //     t.AuthorizedBy,
            //     t.GmOperationsAt AS GmActionAt
            // FROM
            //     dbo.Doc_Issuance AS i
            // JOIN
            //     dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
            // WHERE
            //     t.GmOperationsAction = 'Authorized' AND t.QAAction IS NULL
            // ORDER BY
            //     t.GmOperationsAt ASC;
            //
            // C# Logic:
            // 1. Execute the query.
            // 2. Bind the results to dgvQaQueue.DataSource.
            // 3. Update the queue count label.
            //
            // Example Placeholder:
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

            // --- DB INTEGRATION POINT ---
            // Similar to the GM details view, this should be a single database query to fetch
            // all details for the selected request, including comments from both the requester and the GM.
            //
            // SQL Statement:
            // SELECT
            //     i.*, -- Selects all columns from Doc_Issuance
            //     t.RequestComment,
            //     t.GmOperationsComment
            // FROM
            //     dbo.Doc_Issuance AS i
            // JOIN
            //     dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
            // WHERE
            //     i.RequestNo = @RequestNo;
            //
            // C# Logic:
            // 1. Get the RequestNo from the selected grid row.
            // 2. Execute the query with the RequestNo as a parameter.
            // 3. Populate all the textboxes in 'grpQaSelectedRequest' with the returned data.
            //
            // Example Placeholder:
            string docNoColumnNameInGridData = "DocumentNo";

            Func<string, string> GetValueFromCellByBoundName = (boundPropertyName) =>
            {
                var cell = selectedRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.OwningColumn.DataPropertyName == boundPropertyName);
                return cell?.Value?.ToString() ?? "";
            };
            Func<string, string, string> GetDateValueFromCellByBoundName = (boundPropertyName, format) =>
            {
                var cell = selectedRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.OwningColumn.DataPropertyName == boundPropertyName);
                return cell?.Value != null && cell.Value is DateTime dt ? dt.ToString(format, CultureInfo.InvariantCulture) : (cell?.Value?.ToString() ?? "");
            };


            if (txtQaDetailRequestNo != null) txtQaDetailRequestNo.Text = GetValueFromCellByBoundName("RequestNo");
            if (txtQaDetailRequestDate != null) txtQaDetailRequestDate.Text = GetDateValueFromCellByBoundName("RequestDate", "dd-MMM-yyyy");
            if (txtQaDetailProduct != null) txtQaDetailProduct.Text = GetValueFromCellByBoundName("Product");
            if (txtQaDetailDocTypes != null) txtQaDetailDocTypes.Text = GetValueFromCellByBoundName(docNoColumnNameInGridData);
            if (txtQaDetailPreparedBy != null) txtQaDetailPreparedBy.Text = GetValueFromCellByBoundName("PreparedBy");
            if (txtQaDetailGmActionTime != null) txtQaDetailGmActionTime.Text = GetDateValueFromCellByBoundName("GmActionAt", "dd-MMM-yyyy HH:mm");

            var requestNo = GetValueFromCellByBoundName("RequestNo");
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
                if (txtQaDetailMfgDate != null) txtQaDetailMfgDate.Text = DateTime.Now.AddDays(-45).ToString("MMM/yyyy", CultureInfo.InvariantCulture);
                if (txtQaDetailExpDate != null) txtQaDetailExpDate.Text = DateTime.Now.AddYears(1).AddMonths(6).ToString("MMM/yyyy", CultureInfo.InvariantCulture);
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
                // --- DB INTEGRATION POINT (APPROVE) ---
                // This is the final approval step. It updates the Issuance_Tracker table.
                //
                // SQL Statement:
                // UPDATE dbo.Issuance_Tracker
                // SET
                //     QAAction = 'Approved',
                //     ApprovedBy = @ApprovedBy,
                //     QAAt = GETDATE(),
                //     QAComment = @QAComment
                // WHERE
                //     IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);
                //
                // **Best Practice: Check rows affected here for stale data.**
                //
                // Example Placeholder:
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
                // --- DB INTEGRATION POINT (REJECT) ---
                // This is the final rejection step. It updates the Issuance_Tracker table.
                //
                // SQL Statement:
                // UPDATE dbo.Issuance_Tracker
                // SET
                //     QAAction = 'Rejected',
                //     ApprovedBy = @ApprovedBy, -- The user who performed the action
                //     QAAt = GETDATE(),
                //     QAComment = @QAComment
                // WHERE
                //     IssuanceID = (SELECT IssuanceID FROM dbo.Doc_Issuance WHERE RequestNo = @RequestNo);
                //
                // **Best Practice: Check rows affected here for stale data.**
                //
                // Example Placeholder:
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
            if (dtpAuditFrom != null) dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
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
            MessageBox.Show($"Error displaying data in the audit trail at row {e.RowIndex + 1}, column '{dgvAuditTrail.Columns[e.ColumnIndex].HeaderText}'.\nDetails: {e.Exception.Message}", "Data Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void SetupAuditTrailColumns()
        {
            if (dgvAuditTrail == null) return;
            dgvAuditTrail.Columns.Clear();

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }, Frozen = true });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100, });
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

            // --- DB INTEGRATION POINT ---
            // This is the most comprehensive query. It joins the two main tables and uses a CASE
            // statement to create the "DerivedStatus" column based on the workflow state.
            // The WHERE clause will be built dynamically based on the filter controls.
            //
            // SQL Statement (Base):
            // SELECT
            //     i.RequestNo, i.RequestDate, i.Product, i.DocumentNo AS DocumentNumbers,
            //     t.PreparedBy, t.RequestedAt,
            //     t.GmOperationsAction, t.AuthorizedBy, t.GmOperationsAt, t.GmOperationsComment,
            //     t.QAAction, t.ApprovedBy, t.QAAt, t.QAComment,
            //     CASE
            //         WHEN t.QAAction = 'Approved' THEN 'Approved (Issued)'
            //         WHEN t.QAAction = 'Rejected' THEN 'Rejected by QA'
            //         WHEN t.GmOperationsAction = 'Rejected' THEN 'Rejected by GM'
            //         WHEN t.GmOperationsAction = 'Authorized' AND t.QAAction IS NULL THEN 'Pending QA Approval'
            //         WHEN t.GmOperationsAction IS NULL THEN 'Pending GM Approval'
            //         ELSE 'Unknown'
            //     END AS DerivedStatus
            // FROM
            //     dbo.Doc_Issuance AS i
            // JOIN
            //     dbo.Issuance_Tracker AS t ON i.IssuanceID = t.IssuanceID
            //
            // C# Logic:
            // 1. Start with the base query string.
            // 2. Check each filter control (dates, status, request no, product).
            // 3. If a filter is active, append a corresponding WHERE clause (e.g., "WHERE i.RequestDate BETWEEN @FromDate AND @ToDate").
            //    Use a List<SqlParameter> to safely add parameter values.
            // 4. For the status filter, you'll need to add a HAVING clause on the derived status, or wrap the query:
            //    "SELECT * FROM (...) AS AuditQuery WHERE DerivedStatus = @Status"
            // 5. Execute the final, constructed query with its parameters.
            // 6. Bind the results to the dgvAuditTrail.DataSource.
            //
            // Example Placeholder:
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
                dgvUserRoles.ReadOnly = true;

                if (dgvUserRoles.Columns["colUserRoleId"] != null) dgvUserRoles.Columns["colUserRoleId"].DataPropertyName = "RoleID";
                if (dgvUserRoles.Columns["colUserRoleName"] != null) dgvUserRoles.Columns["colUserRoleName"].DataPropertyName = "RoleName";

                dgvUserRoles.DataSource = this.userRolesBindingSource;
                dgvUserRoles.SelectionChanged += DgvUserRoles_SelectionChanged;
            }

            if (btnRefreshUserRoles != null) btnRefreshUserRoles.Click += BtnRefreshUserRoles_Click;
            if (btnResetPassword != null) btnResetPassword.Click += BtnResetPassword_Click;

            if (txtRoleNameManage != null)
            {
                txtRoleNameManage.Clear();
                txtRoleNameManage.ReadOnly = true;
            }

            if (btnResetPassword != null) btnResetPassword.Enabled = false;
        }

        private void LoadUserRoles()
        {
            if (this.userRolesBindingSource == null) return;

            // --- DB INTEGRATION POINT ---
            // This method should populate the user roles grid from the database.
            //
            // SQL Statement:
            // SELECT RoleID, RoleName FROM dbo.User_Roles ORDER BY RoleName;
            //
            // C# Logic:
            // 1. Execute the query.
            // 2. Create a List<UserRole> from the results.
            // 3. Set the userRolesBindingSource.DataSource to this list.
            //
            // Example Placeholder:
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

            // Reset state after loading
            if (txtRoleNameManage != null) txtRoleNameManage.Clear();
            if (btnResetPassword != null) btnResetPassword.Enabled = false;
            if (dgvUserRoles != null) dgvUserRoles.ClearSelection();
        }

        private void DgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
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

            if (btnResetPassword != null) btnResetPassword.Enabled = roleSelected;
        }

        private void BtnRefreshUserRoles_Click(object sender, EventArgs e) { LoadUserRoles(); }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUserRoles == null || dgvUserRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role from the list to reset its password.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserRole selectedRole = dgvUserRoles.SelectedRows[0].DataBoundItem as UserRole;
            if (selectedRole == null)
            {
                MessageBox.Show("The selected role is invalid. Cannot proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string roleName = selectedRole.RoleName;

            if (MessageBox.Show($"Are you sure you want to reset the password for the '{roleName}' role?", "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // --- DB INTEGRATION POINT ---
                // This action should update the password hash in the database for the selected role.
                // A new password should be generated (or prompted for), securely hashed, and then stored.
                //
                // SQL Statement:
                // UPDATE dbo.User_Roles SET PasswordHash = @NewPasswordHash WHERE RoleName = @RoleName;
                //
                // C# Logic:
                // 1. Prompt the admin for a new password or generate a secure random one.
                // 2. Hash the new password using a secure library (e.g., BCrypt.Net).
                // 3. Execute the UPDATE statement, passing the new hash and the role name as parameters.
                // 4. Inform the user of the successful reset.
                //
                // Example Placeholder:
                MessageBox.Show($"Password for role '{roleName}' has been reset to the default (Simulated).", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Users Tab Logic

    }

}