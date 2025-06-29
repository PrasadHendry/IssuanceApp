using IssuanceApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
{
    public partial class AuditTrailControl : UserControl
    {
        private IssuanceRepository _repository;

        // --- Fields for HIGH-PERFORMANCE Audit Trail Virtual Mode ---
        private List<int> _auditTrailKeyCache;
        private Dictionary<int, AuditTrailEntry> _auditTrailPageCache;
        private HashSet<int> _pagesBeingFetched;
        private const int AuditPageSize = 50;
        private SortOrder _auditSortOrder = SortOrder.None;
        private string _auditSortColumn = string.Empty;

        // --- CancellationTokenSource for robust async operations ---
        private CancellationTokenSource _dataLoadCts = new CancellationTokenSource();

        public AuditTrailControl()
        {
            InitializeComponent();
        }

        public void InitializeControl(IssuanceRepository repository)
        {
            _repository = repository;

            // --- Initialize Fields ---
            _auditTrailPageCache = new Dictionary<int, AuditTrailEntry>();
            _pagesBeingFetched = new HashSet<int>();

            // --- Configure Controls ---
            cmbAuditStatus.Items.Clear();
            cmbAuditStatus.Items.AddRange(new object[] { "All", "Pending GM Approval", "Pending QA Approval", "Approved (Issued)", "Rejected by GM", "Rejected by QA" });
            cmbAuditStatus.SelectedIndex = 0;
            dtpAuditFrom.Value = DateTime.Now.Date.AddDays(-30);
            dtpAuditTo.Value = DateTime.Now.Date;

            dgvAuditTrail.AutoGenerateColumns = false;
            dgvAuditTrail.VirtualMode = true;
            SetupAuditTrailColumns();

            // --- Wire up Events ---
            dgvAuditTrail.CellValueNeeded += DgvAuditTrail_CellValueNeeded;
            dgvAuditTrail.ColumnHeaderMouseClick += DgvAuditTrail_ColumnHeaderMouseClick;
            btnApplyAuditFilter.Click += async (s, e) => await LoadAuditTrailDataAsync();
            btnClearAuditFilters.Click += BtnClearAuditFilters_Click;
            btnRefreshAuditList.Click += async (s, e) => await LoadAuditTrailDataAsync();
            btnExportToCsv.Click += (s, e) => MessageBox.Show("CSV export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExportToExcel.Click += (s, e) => MessageBox.Show("Excel export not implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // This method should be called by MainForm when the control is no longer needed
        public void CancelAllOperations()
        {
            _dataLoadCts.Cancel();
        }

        private void SetupAuditTrailColumns()
        {
            dgvAuditTrail.Columns.Clear();

            var wrapTextStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True, Alignment = DataGridViewContentAlignment.TopLeft };
            var noWrapStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.False, Alignment = DataGridViewContentAlignment.TopLeft };

            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestNo", HeaderText = "Request No.", DataPropertyName = "RequestNo", Width = 120, Frozen = true });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditRequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, Width = 100 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditProduct", HeaderText = "Product", DataPropertyName = "Product", Width = 150 });
            dgvAuditTrail.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAuditDocumentNumbers", HeaderText = "Document No(s).", DataPropertyName = "DocumentNumbers", DefaultCellStyle = noWrapStyle, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
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
                _auditTrailPageCache.Clear();
                _pagesBeingFetched.Clear();
                dgvAuditTrail.RowCount = 0;

                var columnMap = new Dictionary<string, string>
                {
                    { "colAuditRequestNo", "RequestNo" }, { "colAuditRequestDate", "RequestDate" },
                    { "colAuditProduct", "Product" }, { "colAuditStatusDerived", "DerivedStatus" },
                    { "colAuditPreparedBy", "PreparedBy" }, { "colAuditRequestedAt", "RequestedAt" }
                };
                columnMap.TryGetValue(_auditSortColumn, out string dbSortColumn);

                _auditTrailKeyCache = await _repository.GetAuditTrailKeysAsync(
                    dtpAuditFrom.Value, dtpAuditTo.Value, cmbAuditStatus.SelectedItem.ToString(),
                    txtAuditRequestNo.Text, txtAuditProduct.Text, dbSortColumn, _auditSortOrder, token);

                token.ThrowIfCancellationRequested();

                if (_auditTrailKeyCache.Any())
                {
                    FetchAuditPage(0, token);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Audit trail load was cancelled by a new request.");
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    MessageBox.Show("Failed to load audit trail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!token.IsCancellationRequested)
                {
                    this.Cursor = Cursors.Default;
                    btnApplyAuditFilter.Enabled = btnClearAuditFilters.Enabled = btnRefreshAuditList.Enabled = true;
                }
            }
        }

        private void DgvAuditTrail_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || _auditTrailKeyCache == null) return;

            if (e.RowIndex >= dgvAuditTrail.RowCount - 5 && dgvAuditTrail.RowCount < _auditTrailKeyCache.Count)
            {
                FetchAuditPage(dgvAuditTrail.RowCount, _dataLoadCts.Token);
            }

            if (e.RowIndex >= _auditTrailKeyCache.Count) return;

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
            }
        }

        private async void FetchAuditPage(int rowIndex, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;

            int pageNumber = rowIndex / AuditPageSize;
            if (_pagesBeingFetched.Contains(pageNumber)) return;

            try
            {
                _pagesBeingFetched.Add(pageNumber);
                if (token.IsCancellationRequested) return;

                int start = pageNumber * AuditPageSize;
                int end = Math.Min(start + AuditPageSize, _auditTrailKeyCache.Count);
                if (start >= end) return;

                var keysToFetch = _auditTrailKeyCache.GetRange(start, end - start);
                var entries = await _repository.GetAuditTrailEntriesAsync(keysToFetch, token);
                token.ThrowIfCancellationRequested();

                var entryDict = entries.ToDictionary(entry => entry.IssuanceID);

                if (dgvAuditTrail.IsDisposed || token.IsCancellationRequested) return;

                dgvAuditTrail.BeginInvoke(new Action(() =>
                {
                    if (token.IsCancellationRequested) return;
                    for (int i = start; i < end; i++)
                    {
                        var key = _auditTrailKeyCache[i];
                        if (entryDict.ContainsKey(key))
                        {
                            _auditTrailPageCache[i] = entryDict[key];
                        }
                    }
                    dgvAuditTrail.RowCount += (end - start);
                    for (int i = start; i < end; i++)
                    {
                        dgvAuditTrail.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
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
    }
}