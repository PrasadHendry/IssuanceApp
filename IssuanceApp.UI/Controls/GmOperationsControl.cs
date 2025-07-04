// GmOperationsControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    public partial class GmOperationsControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _loggedInUserName;

        public GmOperationsControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnGmRefreshList);
            ThemeManager.StyleSuccessButton(btnGmAuthorize);
            ThemeManager.StyleDangerButton(btnGmReject);
            ThemeManager.StyleDataGridView(dgvGmQueue);
        }

        public void InitializeControl(IssuanceRepository repository, string loggedInUserName)
        {
            _repository = repository;
            _loggedInUserName = loggedInUserName;
            SetupGmQueueColumns();

            // CORRECTED: Unsubscribe from events before subscribing to prevent duplicates.
            dgvGmQueue.SelectionChanged -= DgvGmQueue_SelectionChanged;
            dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;

            btnGmRefreshList.Click -= async (s, e) => await LoadPendingQueueAsync();
            btnGmRefreshList.Click += async (s, e) => await LoadPendingQueueAsync();

            btnGmAuthorize.Click -= BtnGmAuthorize_Click;
            btnGmAuthorize.Click += BtnGmAuthorize_Click;

            btnGmReject.Click -= BtnGmReject_Click;
            btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        private void SetupGmQueueColumns()
        {
            dgvGmQueue.AutoGenerateColumns = false;
            dgvGmQueue.Columns.Clear();
            dgvGmQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmRequestNo", DataPropertyName = nameof(GmQueueItemDto.RequestNo), HeaderText = "Request No.", FillWeight = 15 });
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmRequestDate", DataPropertyName = nameof(GmQueueItemDto.RequestDate), HeaderText = "Request Date", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, FillWeight = 12 });
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmProduct", DataPropertyName = nameof(GmQueueItemDto.Product), HeaderText = "Product", FillWeight = 28 });
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmDocTypes", DataPropertyName = nameof(GmQueueItemDto.DocumentNo), HeaderText = "Document No(s).", FillWeight = 20 });
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmPreparedBy", DataPropertyName = nameof(GmQueueItemDto.PreparedBy), HeaderText = "Prepared By", FillWeight = 10 });
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGmRequestedAt", DataPropertyName = nameof(GmQueueItemDto.RequestedAt), HeaderText = "Requested At", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, FillWeight = 15 });
        }

        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnGmRefreshList.Enabled = false;
            try
            {
                var data = await _repository.GetGmPendingQueueAsync();
                dgvGmQueue.DataSource = data;
                lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue.Rows.Count})";
                if (dgvGmQueue.Rows.Count == 0)
                {
                    ClearGmSelectedRequestDetails();
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

        private void DgvGmQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGmQueue.SelectedRows.Count > 0)
            {
                DisplaySelectedRequestDetails(dgvGmQueue.SelectedRows[0]);
                grpGmAction.Enabled = true;
            }
            else
            {
                ClearGmSelectedRequestDetails();
            }
        }

        private void DisplaySelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (!(selectedRow.DataBoundItem is GmQueueItemDto request))
            {
                ClearGmSelectedRequestDetails();
                return;
            }

            txtGmDetailRequestNo.Text = request.RequestNo;
            txtGmDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtGmDetailProduct.Text = request.Product;
            txtGmDetailDocTypes.Text = request.DocumentNo;
            txtGmDetailPreparedBy.Text = request.PreparedBy;
            txtGmDetailRequestedAt.Text = request.RequestedAt.ToString("dd-MMM-yyyy HH:mm");
            txtGmDetailFromDept.Text = request.FromDepartment;
            txtGmDetailBatchNo.Text = request.BatchNo;
            txtGmDetailMfgDate.Text = request.ItemMfgDate;
            txtGmDetailExpDate.Text = request.ItemExpDate;
            txtGmDetailMarket.Text = request.Market;
            txtGmDetailPackSize.Text = request.PackSize;
            txtGmDetailRequesterComments.Text = request.RequestComment;

            // --- ADDED ---
            txtGmParentBatchNo.Text = request.ParentBatchNumber;
            txtGmParentBatchSize.Text = request.ParentBatchSize;
            txtGmParentMfgDate.Text = request.ParentMfgDate;
            txtGmParentExpDate.Text = request.ParentExpDate;
            grpGmParentBatchInfo.Visible = !string.IsNullOrEmpty(request.ParentBatchNumber);
        }

        private void ClearGmSelectedRequestDetails()
        {
            foreach (Control c in tlpGmRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtGmComment.Clear();

            // --- ADDED ---
            foreach (Control c in tlpGmParentBatchInfo.Controls)
                if (c is TextBox tb) tb.Clear();
            grpGmParentBatchInfo.Visible = false;

            grpGmAction.Enabled = false;
        }

        private void BtnGmAuthorize_Click(object sender, EventArgs e) => ProcessGmActionAsync(AppConstants.ActionAuthorized, false);
        private void BtnGmReject_Click(object sender, EventArgs e) => ProcessGmActionAsync(AppConstants.ActionRejected, true);

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
                    bool success = await _repository.UpdateGmActionAsync(requestNo, action, txtGmComment.Text, _loggedInUserName);
                    if (success)
                    {
                        MessageBox.Show($"Request '{requestNo}' has been {action.ToLower()}ed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadPendingQueueAsync();
                    }
                    else
                    {
                        MessageBox.Show("Could not update request. It may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadPendingQueueAsync();
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
    }
}