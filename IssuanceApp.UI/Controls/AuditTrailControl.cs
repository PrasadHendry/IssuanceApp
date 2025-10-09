﻿// AuditTrailControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    public partial class AuditTrailControl : UserControl
    {
        private IssuanceRepository _repository;
        private List<int> _auditTrailKeyCache;
        private Dictionary<int, AuditTrailEntry> _auditTrailDataCache;
        private HashSet<int> _pagesBeingFetched;
        private const int AuditPageSize = 50;
        private SortOrder _auditSortOrder = SortOrder.Descending;
        private string _auditSortColumn = nameof(AuditTrailEntry.RequestNo);

        private CancellationTokenSource _dataLoadCts = new CancellationTokenSource();

        // --- ADDED FIELD ---
        private string _loggedInUserName;

        public AuditTrailControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnApplyAuditFilter);
            ThemeManager.StylePrimaryButton(btnRefreshAuditList);
            ThemeManager.StyleSecondaryButton(btnClearAuditFilters);
            ThemeManager.StyleSecondaryButton(btnExportToCsv);
            ThemeManager.StyleSecondaryButton(btnExportToExcel);
            ThemeManager.StyleDataGridView(dgvAuditTrail);
        }

        // --- UPDATED SIGNATURE ---
        public void InitializeControl(IssuanceRepository repository, string loggedInUserName)
        {
            _repository = repository;
            _loggedInUserName = loggedInUserName; // Store the logged-in user name
            _auditTrailDataCache = new Dictionary<int, AuditTrailEntry>();
            _pagesBeingFetched = new HashSet<int>();

            cmbAuditStatus.Items.Clear();
            cmbAuditStatus.Items.AddRange(new object[] { "All", "Pending GM Approval", "Pending QA Approval", "Approved (Issued)", "Rejected by GM", "Rejected by QA" });
            cmbAuditStatus.SelectedIndex = 0;
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;

            dgvAuditTrail.AutoGenerateColumns = false;
            dgvAuditTrail.VirtualMode = true;
            SetupAuditTrailColumns();

            // --- ADDED EVENT HANDLERS FOR NEW CHECKBOXES ---
            chkIgnoreDateFilter.CheckedChanged += async (s, e) => await LoadAuditTrailDataAsync();
            chkFilterByCurrentUser.CheckedChanged += async (s, e) => await LoadAuditTrailDataAsync();
            // --- END ADDED EVENT HANDLERS ---

            dgvAuditTrail.CellValueNeeded += DgvAuditTrail_CellValueNeeded;
            dgvAuditTrail.ColumnHeaderMouseClick += DgvAuditTrail_ColumnHeaderMouseClick;
            btnApplyAuditFilter.Click += async (s, e) => await LoadAuditTrailDataAsync();
            btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            btnRefreshAuditList.Click += async (s, e) => await LoadAuditTrailDataAsync();
            btnExportToCsv.Click += (s, e) => MessageBox.Show("CSV export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExportToExcel.Click += (s, e) => MessageBox.Show("Excel export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CancelAllOperations()
        {
            _dataLoadCts?.Cancel();
        }

        private void SetupAuditTrailColumns()
        {
            dgvAuditTrail.Columns.Clear();
            var wrapTextStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True, Alignment = DataGridViewContentAlignment.TopLeft };
            var noWrapStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.False, Alignment = DataGridViewContentAlignment.MiddleLeft };

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = nameof(AuditTrailEntry.RequestNo), Width = 140, Frozen = true });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = nameof(AuditTrailEntry.RequestDate), DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = nameof(AuditTrailEntry.Product), Width = 200 });

            // --- FIX IS HERE ---
            // Changed AutoSizeMode to None and set a generous initial width.
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocumentNumbers", HeaderText = "Document No(s).", DataPropertyName = nameof(AuditTrailEntry.DocumentNo), AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 250, DefaultCellStyle = noWrapStyle });

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditStatusDerived", HeaderText = "Status", DataPropertyName = nameof(AuditTrailEntry.DerivedStatus), Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditPreparedBy", HeaderText = "Prepared By", DataPropertyName = nameof(AuditTrailEntry.PreparedBy), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditFromDept", HeaderText = "From Department", DataPropertyName = nameof(AuditTrailEntry.FromDepartment), Width = 180 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestedAt", HeaderText = "Requested At", DataPropertyName = nameof(AuditTrailEntry.RequestedAt), DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmAction", HeaderText = "GM Action", DataPropertyName = nameof(AuditTrailEntry.GmOperationsAction), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditAuthorizedBy", HeaderText = "GM User", DataPropertyName = nameof(AuditTrailEntry.AuthorizedBy), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmActionAt", HeaderText = "GM Action At", DataPropertyName = nameof(AuditTrailEntry.GmOperationsAt), DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditGmComment", HeaderText = "GM Comment", DataPropertyName = nameof(AuditTrailEntry.GmOperationsComment), Width = 250, DefaultCellStyle = wrapTextStyle });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaAction", HeaderText = "QA Action", DataPropertyName = nameof(AuditTrailEntry.QAAction), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditApprovedBy", HeaderText = "QA User", DataPropertyName = nameof(AuditTrailEntry.ApprovedBy), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaActionAt", HeaderText = "QA Action At", DataPropertyName = nameof(AuditTrailEntry.QAAt), DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditQaComment", HeaderText = "QA Comment", DataPropertyName = nameof(AuditTrailEntry.QAComment), Width = 250, DefaultCellStyle = wrapTextStyle });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditParentBatchNo", HeaderText = "Parent Batch No.", DataPropertyName = nameof(AuditTrailEntry.ParentBatchNumber), Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditParentBatchSize", HeaderText = "Parent Batch Size", DataPropertyName = nameof(AuditTrailEntry.ParentBatchSize), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditParentMfgDate", HeaderText = "Parent Mfg. Date", DataPropertyName = nameof(AuditTrailEntry.ParentMfgDate), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditParentExpDate", HeaderText = "Parent Exp. Date", DataPropertyName = nameof(AuditTrailEntry.ParentExpDate), AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        public async Task LoadAuditTrailDataAsync()
        {
            if (_repository == null) return;

            _dataLoadCts.Cancel();
            _dataLoadCts = new CancellationTokenSource();
            var token = _dataLoadCts.Token;

            this.Cursor = Cursors.WaitCursor;
            btnApplyAuditFilter.Enabled = btnClearAuditFilters.Enabled = btnRefreshAuditList.Enabled = false;
            try
            {
                _auditTrailKeyCache = null;
                _auditTrailDataCache.Clear();
                dgvAuditTrail.RowCount = 0;
                dgvAuditTrail.Refresh();

                string dbSortColumn = _auditSortColumn;

                // Determine filter parameters
                bool ignoreDate = chkIgnoreDateFilter.Checked;
                string userFilter = chkFilterByCurrentUser.Checked ? _loggedInUserName : null;

                // --- UPDATED CALL TO REPOSITORY WITH NEW PARAMETERS ---
                _auditTrailKeyCache = await _repository.GetAuditTrailKeysAsync(
                    dtpAuditFrom.Value,
                    dtpAuditTo.Value,
                    cmbAuditStatus.SelectedItem.ToString(),
                    txtAuditRequestNo.Text,
                    txtAuditProduct.Text,
                    dbSortColumn,
                    _auditSortOrder,
                    ignoreDate, // New parameter
                    userFilter, // New parameter
                    token);
                // --- END UPDATED CALL ---

                token.ThrowIfCancellationRequested();

                dgvAuditTrail.RowCount = _auditTrailKeyCache.Count;

                if (dgvAuditTrail.RowCount > 0)
                {
                    dgvAuditTrail.Invalidate();
                }
            }
            catch (OperationCanceledException) { /* Expected, ignore */ }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                    MessageBox.Show("Failed to load audit trail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!token.IsCancellationRequested)
                {
                    this.Cursor = Cursors.Default;
                    btnApplyAuditFilter.Enabled = btnClearAuditFilters.Enabled = btnRefreshAuditList.Enabled = true;

                    foreach (DataGridViewColumn col in dgvAuditTrail.Columns)
                        col.HeaderCell.SortGlyphDirection = SortOrder.None;

                    var sortCol = dgvAuditTrail.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.DataPropertyName == _auditSortColumn);
                    if (sortCol != null) sortCol.HeaderCell.SortGlyphDirection = _auditSortOrder;
                }
            }
        }

        private void DgvAuditTrail_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_auditTrailKeyCache == null || e.RowIndex < 0 || e.RowIndex >= _auditTrailKeyCache.Count) return;

            if (_auditTrailDataCache.TryGetValue(e.RowIndex, out AuditTrailEntry entry))
            {
                string colPropName = dgvAuditTrail.Columns[e.ColumnIndex].DataPropertyName;
                if (!string.IsNullOrEmpty(colPropName))
                {
                    e.Value = typeof(AuditTrailEntry).GetProperty(colPropName)?.GetValue(entry);
                }
            }
            else
            {
                e.Value = "Loading...";
                int pageNumber = e.RowIndex / AuditPageSize;
                FetchAuditPage(pageNumber, _dataLoadCts.Token);
            }
        }

        private async void FetchAuditPage(int pageNumber, CancellationToken token)
        {
            if (token.IsCancellationRequested || _pagesBeingFetched.Contains(pageNumber)) return;

            try
            {
                _pagesBeingFetched.Add(pageNumber);
                int start = pageNumber * AuditPageSize;
                var keysToFetch = _auditTrailKeyCache.Skip(start).Take(AuditPageSize).ToList();
                if (!keysToFetch.Any()) return;

                var entries = await _repository.GetAuditTrailEntriesAsync(keysToFetch, token);
                var entryDict = entries.ToDictionary(en => en.IssuanceID);

                if (this.IsDisposed || token.IsCancellationRequested) return;

                this.BeginInvoke(new Action(() =>
                {
                    if (token.IsCancellationRequested) return;

                    int endRange = Math.Min(start + AuditPageSize, _auditTrailKeyCache.Count);
                    for (int i = start; i < endRange; i++)
                    {
                        var key = _auditTrailKeyCache[i];
                        if (_auditTrailKeyCache.Count > i && entryDict.TryGetValue(key, out AuditTrailEntry fetchedEntry))
                        {
                            _auditTrailDataCache[i] = fetchedEntry;
                        }
                    }

                    if (keysToFetch.Count > 0)
                    {
                        dgvAuditTrail.Invalidate();
                    }
                }));
            }
            catch (OperationCanceledException) { /* Ignored */ }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                    Console.WriteLine($"Error fetching audit page {pageNumber}: {ex.Message}");
            }
            finally
            {
                _pagesBeingFetched.Remove(pageNumber);
            }
        }

        private async void DgvAuditTrail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string newSortColumnName = dgvAuditTrail.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(newSortColumnName)) return;

            if (_auditSortColumn == newSortColumnName)
                _auditSortOrder = (_auditSortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            else
                _auditSortOrder = SortOrder.Ascending;

            _auditSortColumn = newSortColumnName;

            foreach (DataGridViewColumn col in dgvAuditTrail.Columns)
                col.HeaderCell.SortGlyphDirection = SortOrder.None;

            await LoadAuditTrailDataAsync();
        }

        private async void BtnClearAuditFilters_Click(object sender, EventArgs e)
        {
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;
            cmbAuditStatus.SelectedIndex = 0;
            txtAuditRequestNo.Clear();
            txtAuditProduct.Clear();

            // --- ADDED: Clear new filters ---
            chkIgnoreDateFilter.Checked = false;
            chkFilterByCurrentUser.Checked = false;
            // --- END ADDED ---

            _auditSortColumn = nameof(AuditTrailEntry.RequestNo);
            _auditSortOrder = SortOrder.Descending;

            foreach (DataGridViewColumn col in dgvAuditTrail.Columns)
                col.HeaderCell.SortGlyphDirection = SortOrder.None;

            await LoadAuditTrailDataAsync();
        }
    }
}