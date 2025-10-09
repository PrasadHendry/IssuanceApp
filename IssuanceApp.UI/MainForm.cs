// MainForm.cs
using IssuanceApp.Data;
using IssuanceApp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UiTimer = System.Windows.Forms.Timer;

namespace IssuanceApp.UI
{
    public partial class MainForm : Form
    {
        #region Fields
        private readonly IssuanceRepository _repository;
        private readonly UiTimer statusTimer;
        private string loggedInRole = null;
        private string loggedInUserName = null;
        private List<TabPage> allTabPages;
        private readonly HashSet<string> _loadedTabs = new HashSet<string>();
        #endregion

        #region Constructor and Form Lifecycle
        public MainForm(IssuanceRepository repository)
        {
            InitializeComponent();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            InitializeDynamicControls();
            InitializeUserControls(); // Call here to initialize controls before login
            ApplyPharmaTheme();

            this.Text = "Document Issuance System";
            statusTimer = new UiTimer { Interval = 1000 };
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            toolStripStatusLabelUser.Text = "User: Not Logged In";
            this.tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            btnSignOut.Click += BtnSignOut_Click;

            SetupTabs();
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeUserControls()
        {
            this.loginControl1.LoginAttemptCompleted += LoginControl_LoginAttemptCompleted;
            this.loginControl1.InitializeControl(_repository);

            // Initialize all controls with a placeholder null username
            documentIssuanceControl1.InitializeControl(_repository, null);
            gmOperationsControl1.InitializeControl(_repository, null);
            qaControl1.InitializeControl(_repository, null);
            // --- UPDATED CALL ---
            auditTrailControl1.InitializeControl(_repository, null);
            // --- END UPDATED CALL ---
            usersControl1.InitializeControl(_repository);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            auditTrailControl1?.CancelAllOperations();
            statusTimer?.Stop();
            statusTimer?.Dispose();
            base.OnFormClosing(e);
        }
        #endregion

        #region Tab and State Management
        private async void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataForSelectedTabAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading tab data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataForSelectedTabAsync()
        {
            if (tabControlMain.SelectedTab == null || loggedInRole == null) return;
            string selectedTabName = tabControlMain.SelectedTab.Name;

            // Note: We don't use _loadedTabs for AuditTrail anymore, as filters can change.
            // We only use it for controls that only need to load configuration data once.
            // The logic below ensures data is loaded on first access, but subsequent filter changes
            // trigger a reload via button clicks/checkbox changes within the control itself.

            bool isFirstLoad = _loadedTabs.Contains(selectedTabName);

            if (selectedTabName == ControlNames.TabPageDocumentIssuance)
            {
                if (!isFirstLoad) await documentIssuanceControl1.LoadInitialDataAsync();
            }
            else if (selectedTabName == ControlNames.TabPageGmOperations)
            {
                if (!isFirstLoad) await gmOperationsControl1.LoadPendingQueueAsync();
            }
            else if (selectedTabName == ControlNames.TabPageQA)
            {
                if (!isFirstLoad) await qaControl1.LoadPendingQueueAsync();
            }
            else if (selectedTabName == ControlNames.TabPageAuditTrail)
            {
                // The AuditTrail is designed to always load data when the tab is selected
                // to respect the current filter settings, so we force a reload.
                await auditTrailControl1.LoadAuditTrailDataAsync();
            }
            else if (selectedTabName == ControlNames.TabPageUsers)
            {
                if (!isFirstLoad) await usersControl1.LoadUserRolesAsync();
            }

            if (!isFirstLoad)
            {
                _loadedTabs.Add(selectedTabName);
            }
        }

        private void InitializeDynamicControls()
        {
            allTabPages = tabControlMain.TabPages.Cast<TabPage>().ToList();
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
        private async void LoginControl_LoginAttemptCompleted(object sender, LoginEventArgs e)
        {
            try
            {
                if (e.IsAuthenticated)
                {
                    loggedInRole = e.Role;
                    loggedInUserName = e.UserName;
                    toolStripStatusLabelUser.Text = $"User: {loggedInUserName} ({loggedInRole})";
                    lblCurrentUserHeader.Text = $"Logged in as: {loggedInUserName} ({loggedInRole})";
                    lblCurrentUserHeader.ForeColor = ThemeManager.HeaderTextColor;
                    pnlAppHeader.Visible = true;

                    // Re-initialize controls with the logged-in username
                    documentIssuanceControl1.InitializeControl(_repository, loggedInUserName);
                    gmOperationsControl1.InitializeControl(_repository, loggedInUserName);
                    qaControl1.InitializeControl(_repository, loggedInUserName);
                    // --- UPDATED CALL ---
                    auditTrailControl1.InitializeControl(_repository, loggedInUserName);
                    // --- END UPDATED CALL ---

                    _loadedTabs.Clear();
                    EnableTabsBasedOnRole(loggedInRole);

                    SwitchToDefaultTabForRole(loggedInRole);

                    // CORRECTED: Explicitly load data for the initial tab after login.
                    await LoadDataForSelectedTabAsync();
                }
                else
                {
                    pnlAppHeader.Visible = false;
                    loggedInRole = null;
                    UpdateStatusBarForSignOut();
                    EnableTabsBasedOnRole(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A critical error occurred after login: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loggedInRole = null;
                loggedInUserName = null; // Clear the username on sign out
                loginControl1.Reset();
                pnlAppHeader.Visible = false;
                UpdateStatusBarForSignOut();

                // Re-initialize controls with null username
                documentIssuanceControl1.InitializeControl(_repository, null);
                gmOperationsControl1.InitializeControl(_repository, null);
                qaControl1.InitializeControl(_repository, null);
                auditTrailControl1.InitializeControl(_repository, null);

                _loadedTabs.Clear();

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
            toolStripStatusLabelUser.Text = "User: Not Logged In";
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
                    (tab.Name == ControlNames.TabPageAuditTrail && isLoggedIn);

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