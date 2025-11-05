// HodControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
{
    // RENAMED CLASS NAME
    public partial class HodControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _loggedInUserName;

        public HodControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnHodRefreshList); // RENAMED
            ThemeManager.StyleSuccessButton(btnHodAuthorize); // RENAMED
            ThemeManager.StyleDangerButton(btnHodReject); // RENAMED
            ThemeManager.StyleDataGridView(dgvHodQueue); // RENAMED
        }

        public void InitializeControl(IssuanceRepository repository, string loggedInUserName)
        {
            _repository = repository;
            _loggedInUserName = loggedInUserName;
            SetupHodQueueColumns(); // RENAMED

            // CORRECTED: Unsubscribe from events before subscribing to prevent duplicates.
            dgvHodQueue.SelectionChanged -= DgvHodQueue_SelectionChanged; // RENAMED
            dgvHodQueue.SelectionChanged += DgvHodQueue_SelectionChanged; // RENAMED

            btnHodRefreshList.Click -= async (s, e) => await LoadPendingQueueAsync(); // RENAMED
            btnHodRefreshList.Click += async (s, e) => await LoadPendingQueueAsync(); // RENAMED

            btnHodAuthorize.Click -= BtnHodAuthorize_Click; // RENAMED
            btnHodAuthorize.Click += BtnHodAuthorize_Click; // RENAMED

            btnHodReject.Click -= BtnHodReject_Click; // RENAMED
            btnHodReject.Click += BtnHodReject_Click; // RENAMED

            ClearHodSelectedRequestDetails(); // RENAMED
            lblHodQueueTitle.Text = "Pending HOD Approval Queue (0)"; // UPDATED TEXT
        }

        private void SetupHodQueueColumns()
        {
            dgvHodQueue.AutoGenerateColumns = false;
            dgvHodQueue.Columns.Clear();
            dgvHodQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // UPDATED DTO NAME
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodRequestNo", DataPropertyName = nameof(HodQueueItemDto.RequestNo), HeaderText = "Request No.", FillWeight = 15 });
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodRequestDate", DataPropertyName = nameof(HodQueueItemDto.RequestDate), HeaderText = "Request Date", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, FillWeight = 12 });
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodProduct", DataPropertyName = nameof(HodQueueItemDto.Product), HeaderText = "Product", FillWeight = 28 });
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodDocTypes", DataPropertyName = nameof(HodQueueItemDto.DocumentNo), HeaderText = "Document No(s).", FillWeight = 20 });
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodPreparedBy", DataPropertyName = nameof(HodQueueItemDto.PreparedBy), HeaderText = "Prepared By", FillWeight = 10 });
            dgvHodQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHodRequestedAt", DataPropertyName = nameof(HodQueueItemDto.RequestedAt), HeaderText = "Requested At", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, FillWeight = 15 });
        }

        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnHodRefreshList.Enabled = false;
            try
            {
                // UPDATED REPOSITORY METHOD NAME AND DTO
                var data = await _repository.GetHodPendingQueueAsync();
                dgvHodQueue.DataSource = data;
                lblHodQueueTitle.Text = $"Pending HOD Approval Queue ({dgvHodQueue.Rows.Count})";
                if (dgvHodQueue.Rows.Count == 0)
                {
                    ClearHodSelectedRequestDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load HOD queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnHodRefreshList.Enabled = true;
            }
        }

        private void DgvHodQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHodQueue.SelectedRows.Count > 0)
            {
                DisplaySelectedRequestDetails(dgvHodQueue.SelectedRows[0]);
                grpHodAction.Enabled = true; // RENAMED
            }
            else
            {
                ClearHodSelectedRequestDetails();
            }
        }

        private void DisplaySelectedRequestDetails(DataGridViewRow selectedRow)
        {
            // UPDATED DTO NAME
            if (!(selectedRow.DataBoundItem is HodQueueItemDto request))
            {
                ClearHodSelectedRequestDetails();
                return;
            }

            // UPDATED CONTROL NAMES
            txtHodDetailRequestNo.Text = request.RequestNo;
            txtHodDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtHodDetailProduct.Text = request.Product;
            txtHodDetailDocTypes.Text = request.DocumentNo;
            txtHodDetailPreparedBy.Text = request.PreparedBy;
            txtHodDetailRequestedAt.Text = request.RequestedAt.ToString("dd-MMM-yyyy HH:mm");
            txtHodDetailFromDept.Text = request.FromDepartment;
            txtHodDetailBatchNo.Text = request.BatchNo;
            txtHodDetailMfgDate.Text = request.ItemMfgDate;
            txtHodDetailExpDate.Text = request.ItemExpDate;
            txtHodDetailMarket.Text = request.Market;
            txtHodDetailPackSize.Text = request.PackSize;
            txtHodDetailRequesterComments.Text = request.RequestComment;

            // UPDATED CONTROL NAMES
            txtHodParentBatchNo.Text = request.ParentBatchNumber;
            txtHodParentBatchSize.Text = request.ParentBatchSize;
            txtHodParentMfgDate.Text = request.ParentMfgDate;
            txtHodParentExpDate.Text = request.ParentExpDate;
            grpHodParentBatchInfo.Visible = !string.IsNullOrEmpty(request.ParentBatchNumber); // RENAMED
        }

        private void ClearHodSelectedRequestDetails()
        {
            // UPDATED CONTROL NAMES
            foreach (Control c in tlpHodRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtHodComment.Clear();

            // UPDATED CONTROL NAMES
            foreach (Control c in tlpHodParentBatchInfo.Controls)
                if (c is TextBox tb) tb.Clear();
            grpHodParentBatchInfo.Visible = false;

            grpHodAction.Enabled = false;
        }

        private void BtnHodAuthorize_Click(object sender, EventArgs e) => ProcessHodActionAsync(AppConstants.ActionAuthorized, false); // RENAMED
        private void BtnHodReject_Click(object sender, EventArgs e) => ProcessHodActionAsync(AppConstants.ActionRejected, true); // RENAMED

        private async void ProcessHodActionAsync(string action, bool commentsMandatory)
        {
            if (dgvHodQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtHodDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (commentsMandatory && string.IsNullOrWhiteSpace(txtHodComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHodComment.Focus();
                return;
            }
            string requestNo = txtHodDetailRequestNo.Text;
            if (MessageBox.Show($"Are you sure you want to {action.ToLower()} request '{requestNo}'?", $"Confirm {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnHodAuthorize.Enabled = btnHodReject.Enabled = false; // RENAMED
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // UPDATED REPOSITORY METHOD NAME
                    bool success = await _repository.UpdateHodActionAsync(requestNo, action, txtHodComment.Text, _loggedInUserName);
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
                    btnHodAuthorize.Enabled = btnHodReject.Enabled = true; // RENAMED
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}