﻿// QaControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
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

            SetupQaQueueColumns();

            // CORRECTED: Unsubscribe from events before subscribing to prevent duplicates.
            dgvQaQueue.SelectionChanged -= DgvQaQueue_SelectionChanged;
            dgvQaQueue.SelectionChanged += DgvQaQueue_SelectionChanged;

            btnQaRefreshList.Click -= async (s, e) => await LoadPendingQueueAsync();
            btnQaRefreshList.Click += async (s, e) => await LoadPendingQueueAsync();

            btnQaApprove.Click -= BtnQaApprove_Click;
            btnQaApprove.Click += BtnQaApprove_Click;

            btnQaReject.Click -= BtnQaReject_Click;
            btnQaReject.Click += BtnQaReject_Click;

            btnQaBrowseSelectDocument.Click -= BrowseDocument_Click; // Assuming a named handler might be added later
            btnQaBrowseSelectDocument.Click += BrowseDocument_Click;

            ClearQaSelectedRequestDetails();
            lblQaQueueTitle.Text = "Pending QA Approval Queue (0)";
        }

        private void BrowseDocument_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Functionality to open document location is not yet implemented.", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupQaQueueColumns()
        {
            dgvQaQueue.AutoGenerateColumns = false;
            dgvQaQueue.Columns.Clear();
            dgvQaQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaRequestNo", DataPropertyName = nameof(QaQueueItemDto.RequestNo), HeaderText = "Request No.", FillWeight = 15 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaRequestDate", DataPropertyName = nameof(QaQueueItemDto.RequestDate), HeaderText = "Request Date", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" }, FillWeight = 12 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaProduct", DataPropertyName = nameof(QaQueueItemDto.Product), HeaderText = "Product", FillWeight = 23 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaDocTypes", DataPropertyName = nameof(QaQueueItemDto.DocumentNo), HeaderText = "Document No(s).", FillWeight = 15 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaPreparedBy", DataPropertyName = nameof(QaQueueItemDto.PreparedBy), HeaderText = "Prepared By", FillWeight = 10 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaRequestedAt", DataPropertyName = nameof(QaQueueItemDto.RequestedAt), HeaderText = "Requested At", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, FillWeight = 15 });
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaAuthorizedBy", DataPropertyName = nameof(QaQueueItemDto.AuthorizedBy), HeaderText = "Authorized By (GM)", FillWeight = 10 });
            // --- FIX: Updated DataPropertyName to match the corrected model ---
            dgvQaQueue.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQaGmActionAt", DataPropertyName = nameof(QaQueueItemDto.GmOperationsAt), HeaderText = "GM Action At", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" }, FillWeight = 15 });
        }

        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnQaRefreshList.Enabled = false;
            try
            {
                var data = await _repository.GetQaPendingQueueAsync();
                dgvQaQueue.DataSource = data;
                lblQaQueueTitle.Text = $"Pending QA Approval Queue ({dgvQaQueue.Rows.Count})";
                if (dgvQaQueue.Rows.Count == 0)
                {
                    ClearQaSelectedRequestDetails();
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

        private void DgvQaQueue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQaQueue.SelectedRows.Count > 0)
            {
                DisplaySelectedRequestDetails(dgvQaQueue.SelectedRows[0]);
                grpQaAction.Enabled = true;
            }
            else
            {
                ClearQaSelectedRequestDetails();
            }
        }

        private void DisplaySelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (!(selectedRow.DataBoundItem is QaQueueItemDto request))
            {
                ClearQaSelectedRequestDetails();
                return;
            }

            txtQaDetailRequestNo.Text = request.RequestNo;
            txtQaDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtQaDetailProduct.Text = request.Product;
            txtQaDetailDocTypes.Text = request.DocumentNo;
            txtQaDetailPreparedBy.Text = request.PreparedBy;
            txtQaDetailRequestedAt.Text = request.RequestedAt.ToString("dd-MMM-yyyy HH:mm");
            // --- FIX: Updated property name to match the corrected model ---
            txtQaDetailGmActionTime.Text = request.GmOperationsAt.ToString("dd-MMM-yyyy HH:mm");
            txtQaDetailFromDept.Text = request.FromDepartment;
            txtQaDetailBatchNo.Text = request.BatchNo;
            txtQaDetailMfgDate.Text = request.ItemMfgDate;
            txtQaDetailExpDate.Text = request.ItemExpDate;
            txtQaDetailMarket.Text = request.Market;
            txtQaDetailPackSize.Text = request.PackSize;
            txtQaDetailRequesterComments.Text = request.RequestComment;
            txtQaDetailGmComment.Text = request.GmOperationsComment;

            // --- ADDED ---
            txtQaParentBatchNo.Text = request.ParentBatchNumber;
            txtQaParentBatchSize.Text = request.ParentBatchSize;
            txtQaParentMfgDate.Text = request.ParentMfgDate;
            txtQaParentExpDate.Text = request.ParentExpDate;
            grpQaParentBatchInfo.Visible = !string.IsNullOrEmpty(request.ParentBatchNumber);
        }

        private void ClearQaSelectedRequestDetails()
        {
            foreach (Control c in tlpQaRequestDetails.Controls)
                if (c is TextBox tb) tb.Clear();
            txtQaComment.Clear();

            // --- ADDED ---
            foreach (Control c in tlpQaParentBatchInfo.Controls)
                if (c is TextBox tb) tb.Clear();
            grpQaParentBatchInfo.Visible = false;

            grpQaAction.Enabled = false;
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

            string message = $"Are you sure you want to {action.ToLower()} request '{requestNo}'?";

            if (MessageBox.Show(message, $"Confirm {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnQaApprove.Enabled = btnQaReject.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bool success = await _repository.UpdateQaActionAsync(requestNo, action, txtQaComment.Text, _loggedInUserName);
                    if (success)
                    {
                        string successMessage = $"Request '{requestNo}' has been {action.ToLower()}ed successfully.";
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