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

            // Setup the DataGridView programmatically. This prevents the crash.
            SetupGmQueueColumns();

            // Wire up events
            dgvGmQueue.SelectionChanged += DgvGmQueue_SelectionChanged;
            btnGmRefreshList.Click += async (s, e) => await LoadPendingQueueAsync();
            btnGmAuthorize.Click += BtnGmAuthorize_Click;
            btnGmReject.Click += BtnGmReject_Click;

            ClearGmSelectedRequestDetails();
            lblGmQueueTitle.Text = "Pending GM Approval Queue (0)";
        }

        // This new method creates the columns in code, making it robust and easy to manage.
        private void SetupGmQueueColumns()
        {
            dgvGmQueue.AutoGenerateColumns = false;
            dgvGmQueue.Columns.Clear();

            // Set the base AutoSizeMode for the entire grid
            dgvGmQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Now, add the columns with their proportional FillWeight
            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmRequestNo",
                DataPropertyName = nameof(PendingRequestSummary.RequestNo),
                HeaderText = "Request No.",
                FillWeight = 15  // Give it a medium weight
            });

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmRequestDate",
                DataPropertyName = nameof(PendingRequestSummary.RequestDate),
                HeaderText = "Request Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy" },
                FillWeight = 12 // A bit smaller
            });

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmProduct",
                DataPropertyName = nameof(PendingRequestSummary.Product),
                HeaderText = "Product",
                FillWeight = 28 // Give it a larger weight
            });

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmDocTypes",
                DataPropertyName = nameof(PendingRequestSummary.DocumentNo),
                HeaderText = "Document No(s).",
                FillWeight = 20 // Also larger
            });

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmPreparedBy",
                DataPropertyName = nameof(PendingRequestSummary.PreparedBy),
                HeaderText = "Prepared By",
                FillWeight = 10 // Smallest weight
            });

            dgvGmQueue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGmRequestedAt",
                DataPropertyName = nameof(PendingRequestSummary.RequestedAt),
                HeaderText = "Requested At",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MMM-yyyy HH:mm" },
                FillWeight = 15 // Medium weight
            });
        }

        public async Task LoadPendingQueueAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            btnGmRefreshList.Enabled = false;
            try
            {
                // This call now fetches all data needed, preventing extra DB calls later.
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
                // No 'await' needed anymore
                DisplaySelectedRequestDetails(dgvGmQueue.SelectedRows[0]);
            else
                ClearGmSelectedRequestDetails();
        }

        // This method is now synchronous and much faster.
        private void DisplaySelectedRequestDetails(DataGridViewRow selectedRow)
        {
            if (!(selectedRow.DataBoundItem is PendingRequestSummary request))
            {
                ClearGmSelectedRequestDetails();
                return;
            }

            // All data comes directly from the 'request' object, making this instant.
            txtGmDetailRequestNo.Text = request.RequestNo;
            txtGmDetailRequestDate.Text = request.RequestDate.ToString("dd-MMM-yyyy");
            txtGmDetailProduct.Text = request.Product;
            txtGmDetailDocTypes.Text = request.DocumentNo;
            txtGmDetailPreparedBy.Text = request.PreparedBy;
            txtGmDetailRequestedAt.Text = request.RequestedAt.ToString("dd-MMM-yyyy HH:mm");

            // --- POPULATE THE REST OF THE FIELDS ---
            txtGmDetailFromDept.Text = request.FromDepartment;
            txtGmDetailBatchNo.Text = request.BatchNo;
            txtGmDetailMfgDate.Text = request.ItemMfgDate;
            txtGmDetailExpDate.Text = request.ItemExpDate;
            txtGmDetailMarket.Text = request.Market;
            txtGmDetailPackSize.Text = request.PackSize;
            txtGmDetailRequesterComments.Text = request.RequestComment;
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
                        MessageBox.Show($"Request '{requestNo}' has been {action.ToLower()}ed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadPendingQueueAsync(); // Reload the queue
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