// QaControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
// NOTE: Removed System.Text.Json to resolve reference errors. Manual JSON is used.

namespace IssuanceApp.UI.Controls
{
    public partial class QaControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _loggedInUserName;

        private const string WorkerExeName = "WordProcessorFrameworkPrototype.exe";

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
                    bool success = false;

                    if (action == AppConstants.ActionApproved)
                    {
                        // --- INTEGRATION POINT: Fetch DTO, Serialize, and Execute Worker ---

                        // 1. Fetch the full DTO from the selected row
                        QaQueueItemDto requestDto = dgvQaQueue.SelectedRows[0].DataBoundItem as QaQueueItemDto;
                        if (requestDto == null) throw new InvalidOperationException("Could not retrieve request data from the queue.");

                        // 2. Set the *final* QA action/user for the stamp footer
                        requestDto.QAAction = action; // Set the action to 'Approved' (uses the new DTO field)
                        requestDto.ApprovedBy = _loggedInUserName; // Use logged-in user as the final approver (uses the new DTO field)
                        requestDto.GmOperationsAction = AppConstants.ActionAuthorized; // Ensure GM Action is set

                        string documentNoList = requestDto.DocumentNo;

                        // 3. Manual JSON Serialization (to avoid System.Text.Json reference issues)
                        // NOTE: Dates are formatted to be easily parsable by the worker.
                        string recordJson = $@"{{
                            ""RequestNo"": ""{requestDto.RequestNo}"",
                            ""RequestDate"": ""{requestDto.RequestDate:yyyy-MM-dd HH:mm:ss}"",
                            ""Product"": ""{requestDto.Product}"",
                            ""DocumentNo"": ""{requestDto.DocumentNo}"",
                            ""BatchNo"": ""{requestDto.BatchNo}"",
                            ""PreparedBy"": ""{requestDto.PreparedBy}"",
                            ""RequestedAt"": ""{requestDto.RequestedAt:yyyy-MM-dd HH:mm:ss}"",
                            ""AuthorizedBy"": ""{requestDto.AuthorizedBy}"",
                            ""GmOperationsAt"": ""{requestDto.GmOperationsAt:yyyy-MM-dd HH:mm:ss}"",
                            ""GmOperationsComment"": ""{requestDto.GmOperationsComment.Replace("\"", "\\\"")}"",
                            ""GmOperationsAction"": ""{requestDto.GmOperationsAction}"",
                            ""QAAction"": ""{requestDto.QAAction}"",
                            ""ApprovedBy"": ""{requestDto.ApprovedBy}"",
                            ""ItemMfgDate"": ""{requestDto.ItemMfgDate}"",
                            ""ItemExpDate"": ""{requestDto.ItemExpDate}""
                        }}";

                        Console.WriteLine($"[QA Control] Approving request {requestNo}. Launching external worker for documents: {documentNoList}");

                        // 4. Pass BOTH the document list and the serialized record (using Base64 for safe CLI transfer)
                        bool workerSuccess = await ExecuteWordProcessorWorkerAsync(documentNoList, recordJson);

                        if (workerSuccess)
                        {
                            // Worker succeeded: Proceed to update status in DB
                            success = await _repository.UpdateQaActionAsync(requestNo, action, txtQaComment.Text, _loggedInUserName);
                            if (!success)
                            {
                                MessageBox.Show("Database update failed. The request may have been processed by another user.", "Data Stale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // Worker failed: Do NOT update DB status. Keep as 'Pending QA Approval'.
                            MessageBox.Show($"Document processing failed for request '{requestNo}'. The request status remains 'Pending QA Approval'. See logs for details.", "Processing Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            success = false;
                        }
                    }
                    else
                    {
                        // Rejection: Directly update DB status
                        success = await _repository.UpdateQaActionAsync(requestNo, action, txtQaComment.Text, _loggedInUserName);
                    }

                    // Final UI Update
                    if (success)
                    {
                        string successMessage = $"Request '{requestNo}' has been {action.ToLower()}ed successfully.";
                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    await LoadPendingQueueAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A critical error occurred during the approval process: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnQaApprove.Enabled = btnQaReject.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Executes the external Word Processor Worker application asynchronously.
        /// </summary>
        /// <param name="documentList">Comma-delimited string of document names to process.</param>
        /// <param name="recordJson">JSON string of the QaQueueItemDto to be used for stamping.</param>
        /// <returns>True if the worker process exits with code 0 (Success), False otherwise.</returns>
        private async Task<bool> ExecuteWordProcessorWorkerAsync(string documentList, string recordJson)
        {
            string workerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WorkerExeName);

            if (!File.Exists(workerPath))
            {
                MessageBox.Show($"Worker executable not found: {workerPath}", "FATAL Worker Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Arguments will be: "[doc1,doc2]" "[Base64_JSON_STRING]"
            // Base64 encoding is used to safely pass the JSON string via CLI.
            string base64Json = Convert.ToBase64String(Encoding.UTF8.GetBytes(recordJson));
            // --- FIX: Set CreateNoWindow = false to show the console window ---
            string arguments = $"\"{documentList}\" \"{base64Json}\"";

            var startInfo = new ProcessStartInfo
            {
                FileName = workerPath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = false, // Set to FALSE so output goes to the visible console
                CreateNoWindow = false          // Set to FALSE to show the console window
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                // NOTE: Since we are not redirecting output, we cannot asynchronously read the stream.
                // We rely on the console window being visible to the user for process monitoring.

                process.Start();

                // Wait for the process to exit
                await Task.Run(() => process.WaitForExit()); // Use Task.Run to avoid blocking the UI thread

                int exitCode = process.ExitCode;

                if (exitCode != 0)
                {
                    // If the worker fails, we rely on the visible console for the error message.
                    // We also show a message box to ensure the user is alerted.
                    MessageBox.Show($"Worker process failed with Exit Code {exitCode}. Please review the worker's console window for details.", "Worker Process Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return exitCode == 0;
            }
        }
    }
}