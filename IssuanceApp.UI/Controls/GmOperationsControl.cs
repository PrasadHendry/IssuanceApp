// IssuanceApp.UI/Controls/GmOperationsControl.cs

using IssuanceApp.Data;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
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

            // Setup DataGridView
            dgvGmQueue.Columns["colGmRequestNo"].DataPropertyName = nameof(PendingRequestSummary.RequestNo);
            dgvGmQueue.Columns["colGmRequestDate"].DataPropertyName = nameof(PendingRequestSummary.RequestDate);
            dgvGmQueue.Columns["colGmProduct"].DataPropertyName = nameof(PendingRequestSummary.Product);
            dgvGmQueue.Columns["colGmDocTypes"].DataPropertyName = nameof(PendingRequestSummary.DocumentNo);
            dgvGmQueue.Columns["colGmPreparedBy"].DataPropertyName = nameof(PendingRequestSummary.PreparedBy);
            dgvGmQueue.Columns["colGmRequestedAt"].DataPropertyName = nameof(PendingRequestSummary.RequestedAt);

            // Wire up events
            dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            btnGmRefreshList.Click += async (s, e) => await LoadPendingQueueAsync();
            btnGmAuthorize.Click += BtnGmAuthorize_Click;
            btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        // Public method for MainForm to call when the tab is selected
        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            btnGmRefreshList.Enabled = false;
            try
            {
                dgvGmQueue.DataSource = null;
                var data = await _repository.GetGmPendingQueueAsync();
                dgvGmQueue.DataSource = data;
                lblGmQueueTitle.Text = $"Pending GM Approval Queue ({dgvGmQueue.Rows.Count})";
                ClearGmSelectedRequestDetails();

                if (dgvGmQueue.Rows.Count > 0)
                {
                    dgvGmQueue.Rows[0].Selected = true;
                    // *** THIS IS THE FIX: Explicitly call the detail display method ***
                    await DisplaySelectedRequestDetailsAsync(dgvGmQueue.Rows[0]);
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
                await DisplaySelectedRequestDetailsAsync(dgvGmQueue.SelectedRows[0]);
            else
                ClearGmSelectedRequestDetails();
        }

        private async Task DisplaySelectedRequestDetailsAsync(DataGridViewRow selectedRow)
        {
            // BEFORE: if (!(selectedRow.DataBoundItem is DataRowView rowView))
            // AFTER: Cast to our new DTO
            if (!(selectedRow.DataBoundItem is PendingRequestSummary request))
            {
                ClearGmSelectedRequestDetails();
                return;
            }

            // Access data via properties (compile-time safe) instead of strings
            string requestNo = request.RequestNo;
            txtGmDetailRequestNo.Text = request.RequestNo;
            txtGmDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtGmDetailProduct.Text = request.Product;
            txtGmDetailDocTypes.Text = request.DocumentNo;
            txtGmDetailPreparedBy.Text = request.PreparedBy;
            txtGmDetailRequestedAt.Text = request.RequestedAt.ToString("dd-MMM-yyyy HH:mm");

            this.Cursor = Cursors.WaitCursor;
            try
            {
                // The rest of this method (fetching full details) remains the same
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
                        MessageBox.Show($"Request '{requestNo}' has been {action.ToLower()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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