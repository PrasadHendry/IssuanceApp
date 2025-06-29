// IssuanceApp.UI/Controls/QaControl.cs

using IssuanceApp.Data;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
{
    public partial class QaControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _loggedInUserName;

        public QaControl()
        {
            InitializeComponent();
            ThemeManager.StylePrimaryButton(btnQaRefreshList);
            ThemeManager.StyleSuccessButton(btnQaApprove);
            ThemeManager.StyleDangerButton(btnQaReject);
            ThemeManager.StyleSecondaryButton(btnQaBrowseSelectDocument);
            ThemeManager.StyleDataGridView(dgvQaQueue);
        }

        public void InitializeControl(IssuanceRepository repository, string loggedInUserName)
        {
            _repository = repository;
            _loggedInUserName = loggedInUserName;

            // Setup DataGridView
            dgvQaQueue.Columns["colQaRequestNo"].DataPropertyName = nameof(PendingRequestSummary.RequestNo);
            dgvQaQueue.Columns["colQaRequestDate"].DataPropertyName = nameof(PendingRequestSummary.RequestDate);
            dgvQaQueue.Columns["colQaProduct"].DataPropertyName = nameof(PendingRequestSummary.Product);
            dgvQaQueue.Columns["colQaDocTypes"].DataPropertyName = nameof(PendingRequestSummary.DocumentNo);
            dgvQaQueue.Columns["colQaPreparedBy"].DataPropertyName = nameof(PendingRequestSummary.PreparedBy);
            dgvQaQueue.Columns["colQaAuthorizedBy"].DataPropertyName = nameof(PendingRequestSummary.AuthorizedBy);
            dgvQaQueue.Columns["colQaGmActionAt"].DataPropertyName = nameof(PendingRequestSummary.GmActionAt);

            // Wire up events
            dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;
            btnQaRefreshList.Click += async (s, e) => await LoadPendingQueueAsync();
            btnQaApprove.Click += BtnQaApprove_Click;
            btnQaReject.Click += BtnQaReject_Click;
            btnQaBrowseSelectDocument.Click += (s, e) => MessageBox.Show("Functionality to open document location is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearQaSelectedRequestDetails();
            lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }

        // Public method for MainForm to call when the tab is selected
        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            btnQaRefreshList.Enabled = false;
            try
            {
                dgvQaQueue.DataSource = null;
                var data = await _repository.GetQaPendingQueueAsync();
                dgvQaQueue.DataSource = data;
                lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue.Rows.Count})";
                ClearQaSelectedRequestDetails();
                if (dgvQaQueue.Rows.Count > 0)
                {
                    dgvQaQueue.Rows[0].Selected = true;
                    // *** THIS IS THE FIX: Explicitly call the detail display method ***
                    await DisplaySelectedRequestDetailsAsync(dgvQaQueue.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load QA queue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnQaRefreshList.Enabled = true;
            }
        }

        private async void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue.SelectedRows.Count > 0)
                await DisplaySelectedRequestDetailsAsync(dgvQaQueue.SelectedRows[0]);
            else
                ClearQaSelectedRequestDetails();
        }

        private async Task DisplaySelectedRequestDetailsAsync(DataGridViewRow selectedRow)
        {
            // Cast to our new DTO
            if (!(selectedRow.DataBoundItem is PendingRequestSummary request))
            {
                ClearQaSelectedRequestDetails();
                return;
            }

            // Access data via properties
            string requestNo = request.RequestNo;
            txtQaDetailRequestNo.Text = request.RequestNo;
            txtQaDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtQaDetailProduct.Text = request.Product;
            txtQaDetailDocTypes.Text = request.DocumentNo;
            txtQaDetailPreparedBy.Text = request.PreparedBy;
            if (request.GmActionAt.HasValue)
                txtQaDetailGmActionTime.Text = request.GmActionAt.Value.ToString("dd-MMM-yyyy HH:mm");

            // The rest of this method remains the same
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = await _repository.GetFullRequestDetailsAsync(requestNo);
                if (dt.Rows.Count > 0)
                {
                    DataRow detailRow = dt.Rows[0];
                    txtQaDetailFromDept.Text = detailRow["FromDepartment"].ToString();
                    txtQaDetailBatchNo.Text = detailRow["BatchNo"].ToString();
                    txtQaDetailMfgDate.Text = detailRow["ItemMfgDate"].ToString();
                    txtQaDetailExpDate.Text = detailRow["ItemExpDate"].ToString();
                    txtQaDetailMarket.Text = detailRow["Market"].ToString();
                    txtQaDetailPackSize.Text = detailRow["PackSize"].ToString();
                    txtQaDetailRequesterComments.Text = detailRow["RequestComment"].ToString();
                    txtQaDetailGmComment.Text = detailRow["GmOperationsComment"].ToString();
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

        private void ClearQaSelectedRequestDetails()
        {
            foreach (Control c in tlpQaRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtQaComment.Clear();
            numQaPrintCount.Value = 1;
        }

        private void BtnQaApprove_Click(object sender, EventArgs e) => ProcessQaActionAsync(AppConstants.ActionApproved, false);
        private void BtnQaReject_Click(object sender, EventArgs e) => ProcessQaActionAsync(AppConstants.ActionRejected, true);

        private async void ProcessQaActionAsync(string action, bool commentsMandatory)
        {
            if (dgvQaQueue.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtQaDetailRequestNo.Text))
            {
                MessageBox.Show($"Please select a request to {action.ToLower()}.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (commentsMandatory && string.IsNullOrWhiteSpace(txtQaComment.Text))
            {
                MessageBox.Show("Rejection comments are mandatory.", "Comments Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQaComment.Focus();
                return;
            }
            string requestNo = txtQaDetailRequestNo.Text;
            int printCount = (int)numQaPrintCount.Value;
            string message = action == AppConstants.ActionApproved
                ? $"Are you sure you want to approve request '{requestNo}'?\nPrint Count: {printCount}"
                : $"Are you sure you want to reject request '{requestNo}'?";

            if (MessageBox.Show(message, $"Confirm {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnQaApprove.Enabled = btnQaReject.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bool success = await _repository.UpdateQaActionAsync(requestNo, action, txtQaComment.Text, _loggedInUserName);
                    if (success)
                    {
                        string successMessage = action == AppConstants.ActionApproved
                            ? $"Request '{requestNo}' approved successfully. Printed {printCount} copies."
                            : $"Request '{requestNo}' rejected successfully.";
                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    btnQaApprove.Enabled = btnQaReject.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}