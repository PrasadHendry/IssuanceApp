using DocumentIssuanceApp.Controls;
using IssuanceApp.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UiTimer = System.Windows.Forms.Timer;

namespace DocumentIssuanceApp
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly IssuanceRepository _repository;
        private readonly UiTimer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null;
        private List<TabPage> allTabPages;
        
        // Flags to prevent redundant data loading on tab switching
        private bool _gmDataLoaded = false;
        private bool _qaDataLoaded = false;
        private bool _auditDataLoaded = false;
        private bool _usersDataLoaded = false;
        
        // CancellationTokenSource for robust async operations
        private readonly CancellationTokenSource _dataLoadCts = new CancellationTokenSource();
        #endregion

        #region Constructor and Form Lifecycle
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

            InitializeDynamicControls();
            InitializeUserControls();
            ApplyPharmaTheme();

            this.Text = "Document Issuance System";
            statusTimer = new UiTimer { Interval = 1000 };
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            this.tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            btnSignOut.Click += BtnSignOut_Click;
            
            SetupTabs();
            this.WindowState = FormWindowState.Maximized;
        }
        
        private void InitializeUserControls()
        {
            // --- Login Control ---
            this.loginControl1.LoginAttemptCompleted += LoginControl_LoginAttemptCompleted;
            this.loginControl1.InitializeControl(_repository);

            // The other controls will be initialized with their context (repository, username)
            // after a successful login event is received.
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _dataLoadCts.Cancel();
            auditTrailControl1.CancelAllOperations(); // Ensure audit trail tasks are stopped
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
            }
            base.OnFormClosing(e);
        }
        #endregion

        #region Tab and State Management
        private async void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == null || loggedInRole == null) return;

            string selectedTabName = tabControlMain.SelectedTab.Name;

            if (selectedTabName == ControlNames.TabPageDocumentIssuance)
            {
                // This tab loads its data every time it's shown to get a new request #
                await documentIssuanceControl1.LoadInitialDataAsync();
            }
            else if (selectedTabName == ControlNames.TabPageGmOperations && !_gmDataLoaded)
            {
                await gmOperationsControl1.LoadPendingQueueAsync();
                _gmDataLoaded = true;
            }
            else if (selectedTabName == ControlNames.TabPageQA && !_qaDataLoaded)
            {
                await qaControl1.LoadPendingQueueAsync();
                _qaDataLoaded = true;
            }
            else if (selectedTabName == ControlNames.TabPageAuditTrail && !_auditDataLoaded)
            {
                await auditTrailControl1.LoadAuditTrailDataAsync();
                _auditDataLoaded = true;
            }
            else if (selectedTabName == ControlNames.TabPageUsers && !_usersDataLoaded)
            {
                usersControl1.LoadUserRolesAsync();
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

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }
        
        private void SetupTabs()
        {
            EnableTabsBasedOnRole(null); // Start with only login tab visible
        }

        private void SwitchToDefaultTabForRole(string role)
        {
            TabPage targetTab = null;
            switch (role)
            {
                case AppConstants.RoleRequester: targetTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageDocumentIssuance); break;
                case AppConstants.RoleGmOperations: targetTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageGmOperations); break;
                case AppConstants.RoleQA: targetTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageQA); break;
                case AppConstants.RoleAdmin: targetTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageUsers); break;
                default: targetTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageLogin); break;
            }

            if (targetTab != null && tabControlMain.TabPages.Contains(targetTab))
                tabControlMain.SelectedTab = targetTab;
            else if (tabControlMain.TabPages.Count > 0)
                tabControlMain.SelectedIndex = 0;
        }
        #endregion

        #region Login and Role Management
        private void LoginControl_LoginAttemptCompleted(object sender, LoginEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                loggedInRole = e.Role;
                loggedInUserName = e.UserName;

                // Update UI with logged-in user info
                toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";
                lblCurrentUserHeader.Text = $"Logged in as: {loggedInUserName} ({loggedInRole})";
                lblCurrentUserHeader.ForeColor = _headerTextColor;
                pnlAppHeader.Visible = true;
                
                // Initialize all the other user controls now that we have a valid user context
                documentIssuanceControl1.InitializeControl(_repository, loggedInUserName);
                gmOperationsControl1.InitializeControl(_repository, loggedInUserName);
                qaControl1.InitializeControl(_repository, loggedInUserName);
                auditTrailControl1.InitializeControl(_repository);
                usersControl1.InitializeControl(_repository);

                // Reset flags and show appropriate tabs
                _gmDataLoaded = _qaDataLoaded = _auditDataLoaded = _usersDataLoaded = false;
                EnableTabsBasedOnRole(loggedInRole);
                SwitchToDefaultTabForRole(loggedInRole);
            }
            else
            {
                pnlAppHeader.Visible = false;
                loggedInRole = null;
                UpdateStatusBarForSignOut();
                EnableTabsBasedOnRole(null);
            }
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loggedInRole = null;
                loginControl1.Reset();
                pnlAppHeader.Visible = false;
                UpdateStatusBarForSignOut();
                _gmDataLoaded = _qaDataLoaded = _auditDataLoaded = _usersDataLoaded = false;

                EnableTabsBasedOnRole(null);
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageLogin);
                if (loginTab != null)
                {
                    tabControlMain.SelectedTab = loginTab;
                }
            }
        }

        private void UpdateStatusBarForSignOut()
        {
            // loggedInUserName is the OS user, which doesn't change on sign out
            toolStripStatusLabelUser.Text = $"User: {loggedInUserName} (Not Logged In)";
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }

        private void EnableTabsBasedOnRole(string role)
        {
            bool isLoggedIn = !string.IsNullOrEmpty(role);
            tabControlMain.TabPages.Clear();

            if (!isLoggedIn)
            {
                var loginTab = allTabPages.FirstOrDefault(t => t.Name == ControlNames.TabPageLogin);
                if (loginTab != null) tabControlMain.TabPages.Add(loginTab);
                return;
            }

            bool isRequester = (role == AppConstants.RoleRequester);
            bool isGm = (role == AppConstants.RoleGmOperations);
            bool isQa = (role == AppConstants.RoleQA);
            bool isAdmin = (role == AppConstants.RoleAdmin);

            foreach (var tab in allTabPages)
            {
                bool shouldShowTab =
                    (tab.Name == ControlNames.TabPageDocumentIssuance && (isRequester || isAdmin)) ||
                    (tab.Name == ControlNames.TabPageGmOperations && (isGm || isAdmin)) ||
                    (tab.Name == ControlNames.TabPageQA && (isQa || isAdmin)) ||
                    (tab.Name == ControlNames.TabPageUsers && isAdmin) ||
                    (tab.Name == ControlNames.TabPageAuditTrail); // Everyone can see Audit Trail

                if (shouldShowTab)
                {
                    tabControlMain.TabPages.Add(tab);
                }
            }
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

            // This is the correct way, using the pre-defined hover colors
            StyleDangerButton(btnSignOut);

            // Note: The styling for all buttons *inside* the UserControls should be handled
            // within those controls. The MainForm is only responsible for its own controls.
        }

        private void StyleButton(Button btn, Color backColor, Color hoverColor)
        {
            if (btn is RoundedButton roundedBtn)
            {
                roundedBtn.CornerRadius = 8;
            }
            btn.FlatStyle = FlatStyle.Popup;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = _headerTextColor;
            // CORRECTED: Use the passed-in hoverColor parameter
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

        // This method is now only needed if the MainForm directly styles any DataGridViews.
        // Since all grids are in UserControls, this can be moved or removed from MainForm.
        // For now, we will leave it in case it's needed for future MainForm elements.
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
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = _gridAltRowColor;
            dgv.AlternatingRowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dgv.RowsDefaultCellStyle.SelectionBackColor = _gridSelectionBackColor;
            dgv.RowsDefaultCellStyle.SelectionForeColor = _gridSelectionForeColor;
        }
        #endregion
    }
}