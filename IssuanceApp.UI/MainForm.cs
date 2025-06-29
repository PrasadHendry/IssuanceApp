// IssuanceApp.UI/MainForm.cs

using DocumentIssuanceApp.Controls; // THIS IS THE FIX FOR MAINFORM
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
            this.loginControl1.LoginAttemptCompleted += LoginControl_LoginAttemptCompleted;
            this.loginControl1.InitializeControl(_repository);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _dataLoadCts.Cancel();
            auditTrailControl1.CancelAllOperations();
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
                await usersControl1.LoadUserRolesAsync();
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
            EnableTabsBasedOnRole(null);
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

                toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";
                lblCurrentUserHeader.Text = $"Logged in as: {loggedInUserName} ({loggedInRole})";
                lblCurrentUserHeader.ForeColor = ThemeManager.HeaderTextColor;
                pnlAppHeader.Visible = true;

                documentIssuanceControl1.InitializeControl(_repository, loggedInUserName);
                gmOperationsControl1.InitializeControl(_repository, loggedInUserName);
                qaControl1.InitializeControl(_repository, loggedInUserName);
                auditTrailControl1.InitializeControl(_repository);
                usersControl1.InitializeControl(_repository);

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
                    (tab.Name == ControlNames.TabPageAuditTrail);

                if (shouldShowTab)
                {
                    tabControlMain.TabPages.Add(tab);
                }
            }
        }
        #endregion

        #region UI Theming and Styling
        private void ApplyPharmaTheme()
        {
            pnlAppHeader.BackColor = ThemeManager.AppHeaderColor;
            pnlAppHeader.Visible = false;
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                tab.BackColor = ThemeManager.FormBackColor;
            }

            ThemeManager.StyleDangerButton(btnSignOut);
        }
        #endregion
    }
}