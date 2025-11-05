// QaControl.Designer.cs

namespace IssuanceApp.UI.Controls
{
    partial class QaControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpQaOperationsMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQaTopSection = new System.Windows.Forms.Panel();
            this.tlpQaTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQaQueueHeader = new System.Windows.Forms.Panel();
            this.lblQaQueueTitle = new System.Windows.Forms.Label();
            this.btnQaRefreshList = new IssuanceApp.UI.RoundedButton();
            this.dgvQaQueue = new System.Windows.Forms.DataGridView();
            this.colQaRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaDocTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaRequestedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaAuthorizedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaHodActionAt = new System.Windows.Forms.DataGridViewTextBoxColumn(); // RENAMED
            this.tlpQaBottomSection = new System.Windows.Forms.TableLayoutPanel();
            this.grpQaSelectedRequest = new System.Windows.Forms.GroupBox();
            this.tlpQaRequestDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblQaDetailRequestNoLabel = new System.Windows.Forms.Label();
            this.txtQaDetailRequestNo = new System.Windows.Forms.TextBox();
            this.lblQaDetailRequestDateLabel = new System.Windows.Forms.Label();
            this.txtQaDetailRequestDate = new System.Windows.Forms.TextBox();
            this.lblQaDetailFromDeptLabel = new System.Windows.Forms.Label();
            this.txtQaDetailFromDept = new System.Windows.Forms.TextBox();
            this.lblQaDetailDocTypesLabel = new System.Windows.Forms.Label();
            this.txtQaDetailDocTypes = new System.Windows.Forms.TextBox();
            this.lblQaDetailProductLabel = new System.Windows.Forms.Label();
            this.txtQaDetailProduct = new System.Windows.Forms.TextBox();
            this.lblQaDetailBatchNoLabel = new System.Windows.Forms.Label();
            this.txtQaDetailBatchNo = new System.Windows.Forms.TextBox();
            this.lblQaDetailMfgDateLabel = new System.Windows.Forms.Label();
            this.txtQaDetailMfgDate = new System.Windows.Forms.TextBox();
            this.lblQaDetailExpDateLabel = new System.Windows.Forms.Label();
            this.txtQaDetailExpDate = new System.Windows.Forms.TextBox();
            this.lblQaDetailMarketLabel = new System.Windows.Forms.Label();
            this.txtQaDetailMarket = new System.Windows.Forms.TextBox();
            this.lblQaDetailPackSizeLabel = new System.Windows.Forms.Label();
            this.txtQaDetailPackSize = new System.Windows.Forms.TextBox();
            this.lblQaDetailPreparedByLabel = new System.Windows.Forms.Label();
            this.txtQaDetailPreparedBy = new System.Windows.Forms.TextBox();
            this.lblQaDetailRequestedAtLabel = new System.Windows.Forms.Label();
            this.txtQaDetailRequestedAt = new System.Windows.Forms.TextBox();
            this.lblQaDetailRequesterCommentsLabel = new System.Windows.Forms.Label();
            this.txtQaDetailRequesterComments = new System.Windows.Forms.TextBox();
            this.lblQaDetailHodCommentLabel = new System.Windows.Forms.Label(); // RENAMED
            this.txtQaDetailHodComment = new System.Windows.Forms.TextBox(); // RENAMED
            this.lblQaDetailHodActionTimeLabel = new System.Windows.Forms.Label(); // RENAMED
            this.txtQaDetailHodActionTime = new System.Windows.Forms.TextBox(); // RENAMED
            this.grpQaAction = new System.Windows.Forms.GroupBox();
            this.tlpQaActionControls = new System.Windows.Forms.TableLayoutPanel();
            this.flpQaOptionalControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQaBrowseSelectDocument = new IssuanceApp.UI.RoundedButton();
            this.lblQaComment = new System.Windows.Forms.Label();
            this.txtQaComment = new System.Windows.Forms.TextBox();
            this.flpQaActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQaApprove = new IssuanceApp.UI.RoundedButton();
            this.btnQaReject = new IssuanceApp.UI.RoundedButton();
            this.grpQaParentBatchInfo = new System.Windows.Forms.GroupBox();
            this.tlpQaParentBatchInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblQaParentBatchNo = new System.Windows.Forms.Label();
            this.txtQaParentBatchNo = new System.Windows.Forms.TextBox();
            this.lblQaParentBatchSize = new System.Windows.Forms.Label();
            this.txtQaParentBatchSize = new System.Windows.Forms.TextBox();
            this.lblQaParentMfgDate = new System.Windows.Forms.Label();
            this.txtQaParentMfgDate = new System.Windows.Forms.TextBox();
            this.lblQaParentExpDate = new System.Windows.Forms.Label();
            this.txtQaParentExpDate = new System.Windows.Forms.TextBox();
            this.tlpQaOperationsMain.SuspendLayout();
            this.pnlQaTopSection.SuspendLayout();
            this.tlpQaTopControls.SuspendLayout();
            this.pnlQaQueueHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQaQueue)).BeginInit();
            this.tlpQaBottomSection.SuspendLayout();
            this.grpQaSelectedRequest.SuspendLayout();
            this.tlpQaRequestDetails.SuspendLayout();
            this.grpQaAction.SuspendLayout();
            this.tlpQaActionControls.SuspendLayout();
            this.flpQaOptionalControls.SuspendLayout();
            this.flpQaActionButtons.SuspendLayout();
            this.grpQaParentBatchInfo.SuspendLayout();
            this.tlpQaParentBatchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpQaOperationsMain
            // 
            this.tlpQaOperationsMain.AutoScroll = true;
            this.tlpQaOperationsMain.ColumnCount = 1;
            this.tlpQaOperationsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaOperationsMain.Controls.Add(this.pnlQaTopSection, 0, 0);
            this.tlpQaOperationsMain.Controls.Add(this.tlpQaBottomSection, 0, 1);
            this.tlpQaOperationsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaOperationsMain.Location = new System.Drawing.Point(0, 0);
            this.tlpQaOperationsMain.Name = "tlpQaOperationsMain";
            this.tlpQaOperationsMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpQaOperationsMain.RowCount = 2;
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaOperationsMain.Size = new System.Drawing.Size(1330, 817);
            this.tlpQaOperationsMain.TabIndex = 1;
            // 
            // pnlQaTopSection
            // 
            this.pnlQaTopSection.Controls.Add(this.tlpQaTopControls);
            this.pnlQaTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQaTopSection.Location = new System.Drawing.Point(13, 13);
            this.pnlQaTopSection.Name = "pnlQaTopSection";
            this.pnlQaTopSection.Size = new System.Drawing.Size(1304, 244);
            this.pnlQaTopSection.TabIndex = 0;
            // 
            // tlpQaTopControls
            // 
            this.tlpQaTopControls.ColumnCount = 1;
            this.tlpQaTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaTopControls.Controls.Add(this.pnlQaQueueHeader, 0, 0);
            this.tlpQaTopControls.Controls.Add(this.dgvQaQueue, 0, 1);
            this.tlpQaTopControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaTopControls.Location = new System.Drawing.Point(0, 0);
            this.tlpQaTopControls.Name = "tlpQaTopControls";
            this.tlpQaTopControls.RowCount = 2;
            this.tlpQaTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpQaTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaTopControls.Size = new System.Drawing.Size(1304, 244);
            this.tlpQaTopControls.TabIndex = 0;
            // 
            // pnlQaQueueHeader
            // 
            this.pnlQaQueueHeader.Controls.Add(this.lblQaQueueTitle);
            this.pnlQaQueueHeader.Controls.Add(this.btnQaRefreshList);
            this.pnlQaQueueHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQaQueueHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlQaQueueHeader.Name = "pnlQaQueueHeader";
            this.pnlQaQueueHeader.Size = new System.Drawing.Size(1298, 34);
            this.pnlQaQueueHeader.TabIndex = 0;
            // 
            // lblQaQueueTitle
            // 
            this.lblQaQueueTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQaQueueTitle.AutoSize = true;
            this.lblQaQueueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQaQueueTitle.Location = new System.Drawing.Point(5, 6);
            this.lblQaQueueTitle.Name = "lblQaQueueTitle";
            this.lblQaQueueTitle.Size = new System.Drawing.Size(229, 21);
            this.lblQaQueueTitle.TabIndex = 0;
            this.lblQaQueueTitle.Text = "Pending QA Approval Queue";
            // 
            // btnQaRefreshList
            // 
            this.btnQaRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQaRefreshList.CornerRadius = 8;
            this.btnQaRefreshList.FlatAppearance.BorderSize = 0;
            this.btnQaRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQaRefreshList.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQaRefreshList.Location = new System.Drawing.Point(1173, 2);
            this.btnQaRefreshList.Name = "btnQaRefreshList";
            this.btnQaRefreshList.Size = new System.Drawing.Size(120, 30);
            this.btnQaRefreshList.TabIndex = 1;
            this.btnQaRefreshList.Text = "Refresh List";
            this.btnQaRefreshList.UseVisualStyleBackColor = true;
            // 
            // dgvQaQueue
            // 
            this.dgvQaQueue.AllowUserToAddRows = false;
            this.dgvQaQueue.AllowUserToDeleteRows = false;
            this.dgvQaQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQaQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvQaQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQaQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQaRequestNo,
            this.colQaRequestDate,
            this.colQaProduct,
            this.colQaDocTypes,
            this.colQaPreparedBy,
            this.colQaRequestedAt,
            this.colQaAuthorizedBy,
            this.colQaHodActionAt});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "NA";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQaQueue.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQaQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQaQueue.Location = new System.Drawing.Point(3, 43);
            this.dgvQaQueue.MultiSelect = false;
            this.dgvQaQueue.Name = "dgvQaQueue";
            this.dgvQaQueue.ReadOnly = true;
            this.dgvQaQueue.RowHeadersWidth = 51;
            this.dgvQaQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQaQueue.Size = new System.Drawing.Size(1298, 198);
            this.dgvQaQueue.TabIndex = 1;
            // 
            // colQaRequestNo
            // 
            this.colQaRequestNo.DataPropertyName = "RequestNo";
            this.colQaRequestNo.HeaderText = "Request No.";
            this.colQaRequestNo.MinimumWidth = 6;
            this.colQaRequestNo.Name = "colQaRequestNo";
            this.colQaRequestNo.ReadOnly = true;
            // 
            // colQaRequestDate
            // 
            this.colQaRequestDate.DataPropertyName = "RequestDate";
            this.colQaRequestDate.HeaderText = "Request Date";
            this.colQaRequestDate.MinimumWidth = 6;
            this.colQaRequestDate.Name = "colQaRequestDate";
            this.colQaRequestDate.ReadOnly = true;
            // 
            // colQaProduct
            // 
            this.colQaProduct.DataPropertyName = "Product";
            this.colQaProduct.HeaderText = "Product";
            this.colQaProduct.MinimumWidth = 6;
            this.colQaProduct.Name = "colQaProduct";
            this.colQaProduct.ReadOnly = true;
            // 
            // colQaDocTypes
            // 
            this.colQaDocTypes.DataPropertyName = "DocumentNo";
            this.colQaDocTypes.HeaderText = "Document No(s).";
            this.colQaDocTypes.MinimumWidth = 6;
            this.colQaDocTypes.Name = "colQaDocTypes";
            this.colQaDocTypes.ReadOnly = true;
            // 
            // colQaPreparedBy
            // 
            this.colQaPreparedBy.DataPropertyName = "PreparedBy";
            this.colQaPreparedBy.HeaderText = "Prepared By";
            this.colQaPreparedBy.MinimumWidth = 6;
            this.colQaPreparedBy.Name = "colQaPreparedBy";
            this.colQaPreparedBy.ReadOnly = true;
            // 
            // colQaRequestedAt
            // 
            this.colQaRequestedAt.DataPropertyName = "RequestedAt";
            this.colQaRequestedAt.HeaderText = "Requested At";
            this.colQaRequestedAt.Name = "colQaRequestedAt";
            this.colQaRequestedAt.ReadOnly = true;
            // 
            // colQaAuthorizedBy
            // 
            this.colQaAuthorizedBy.DataPropertyName = "AuthorizedBy";
            this.colQaAuthorizedBy.HeaderText = "Authorized By (HOD)"; // UPDATED TEXT
            this.colQaAuthorizedBy.MinimumWidth = 6;
            this.colQaAuthorizedBy.Name = "colQaAuthorizedBy";
            this.colQaAuthorizedBy.ReadOnly = true;
            // 
            // colQaHodActionAt
            // 
            this.colQaHodActionAt.DataPropertyName = "HodAt"; // UPDATED PROPERTY NAME
            this.colQaHodActionAt.HeaderText = "HOD Action At"; // UPDATED TEXT
            this.colQaHodActionAt.MinimumWidth = 6;
            this.colQaHodActionAt.Name = "colQaHodActionAt";
            this.colQaHodActionAt.ReadOnly = true;
            // 
            // tlpQaBottomSection
            // 
            this.tlpQaBottomSection.AutoSize = true;
            this.tlpQaBottomSection.ColumnCount = 1;
            this.tlpQaBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaBottomSection.Controls.Add(this.grpQaSelectedRequest, 0, 0);
            this.tlpQaBottomSection.Controls.Add(this.grpQaParentBatchInfo, 0, 1);
            this.tlpQaBottomSection.Controls.Add(this.grpQaAction, 0, 2);
            this.tlpQaBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaBottomSection.Location = new System.Drawing.Point(13, 263);
            this.tlpQaBottomSection.Name = "tlpQaBottomSection";
            this.tlpQaBottomSection.RowCount = 3;
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpQaBottomSection.Size = new System.Drawing.Size(1304, 541);
            this.tlpQaBottomSection.TabIndex = 1;
            // 
            // grpQaSelectedRequest
            // 
            this.grpQaSelectedRequest.AutoSize = true;
            this.grpQaSelectedRequest.Controls.Add(this.tlpQaRequestDetails);
            this.grpQaSelectedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaSelectedRequest.Location = new System.Drawing.Point(3, 3);
            this.grpQaSelectedRequest.Name = "grpQaSelectedRequest";
            this.grpQaSelectedRequest.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaSelectedRequest.Size = new System.Drawing.Size(1298, 355);
            this.grpQaSelectedRequest.TabIndex = 0;
            this.grpQaSelectedRequest.TabStop = false;
            this.grpQaSelectedRequest.Text = "Selected Request Details";
            // 
            // tlpQaRequestDetails
            // 
            this.tlpQaRequestDetails.AutoScroll = true;
            this.tlpQaRequestDetails.AutoSize = true;
            this.tlpQaRequestDetails.ColumnCount = 4;
            this.tlpQaRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpQaRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQaRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpQaRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailRequestNoLabel, 0, 0);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailRequestNo, 1, 0);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailRequestDateLabel, 2, 0);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailRequestDate, 3, 0);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailFromDeptLabel, 0, 1);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailFromDept, 1, 1);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailDocTypesLabel, 2, 1);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailDocTypes, 3, 1);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailProductLabel, 0, 2);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailProduct, 1, 2);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailBatchNoLabel, 2, 2);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailBatchNo, 3, 2);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailMfgDateLabel, 0, 3);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailMfgDate, 1, 3);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailExpDateLabel, 2, 3);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailExpDate, 3, 3);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailMarketLabel, 0, 4);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailMarket, 1, 4);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailPackSizeLabel, 2, 4);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailPackSize, 3, 4);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailPreparedByLabel, 0, 5);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailPreparedBy, 1, 5);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailRequestedAtLabel, 2, 5);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailRequestedAt, 3, 5);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailRequesterCommentsLabel, 0, 6);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailRequesterComments, 1, 6);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailHodCommentLabel, 0, 7); // RENAMED
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailHodComment, 1, 7); // RENAMED
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailHodActionTimeLabel, 0, 8); // RENAMED
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailHodActionTime, 1, 8); // RENAMED
            this.tlpQaRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaRequestDetails.Location = new System.Drawing.Point(10, 28);
            this.tlpQaRequestDetails.Name = "tlpQaRequestDetails";
            this.tlpQaRequestDetails.RowCount = 9;
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.Size = new System.Drawing.Size(1278, 317);
            this.tlpQaRequestDetails.TabIndex = 0;
            // 
            // lblQaDetailRequestNoLabel
            // 
            this.lblQaDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestNoLabel.AutoSize = true;
            this.lblQaDetailRequestNoLabel.Location = new System.Drawing.Point(72, 7);
            this.lblQaDetailRequestNoLabel.Name = "lblQaDetailRequestNoLabel";
            this.lblQaDetailRequestNoLabel.Size = new System.Drawing.Size(85, 17);
            this.lblQaDetailRequestNoLabel.TabIndex = 0;
            this.lblQaDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtQaDetailRequestNo
            // 
            this.txtQaDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestNo.Location = new System.Drawing.Point(163, 3);
            this.txtQaDetailRequestNo.Name = "txtQaDetailRequestNo";
            this.txtQaDetailRequestNo.ReadOnly = true;
            this.txtQaDetailRequestNo.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailRequestNo.TabIndex = 1;
            // 
            // lblQaDetailRequestDateLabel
            // 
            this.lblQaDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestDateLabel.AutoSize = true;
            this.lblQaDetailRequestDateLabel.Location = new System.Drawing.Point(699, 7);
            this.lblQaDetailRequestDateLabel.Name = "lblQaDetailRequestDateLabel";
            this.lblQaDetailRequestDateLabel.Size = new System.Drawing.Size(92, 17);
            this.lblQaDetailRequestDateLabel.TabIndex = 2;
            this.lblQaDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtQaDetailRequestDate
            // 
            this.txtQaDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestDate.Location = new System.Drawing.Point(797, 3);
            this.txtQaDetailRequestDate.Name = "txtQaDetailRequestDate";
            this.txtQaDetailRequestDate.ReadOnly = true;
            this.txtQaDetailRequestDate.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailRequestDate.TabIndex = 3;
            // 
            // lblQaDetailFromDeptLabel
            // 
            this.lblQaDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailFromDeptLabel.AutoSize = true;
            this.lblQaDetailFromDeptLabel.Location = new System.Drawing.Point(37, 38);
            this.lblQaDetailFromDeptLabel.Name = "lblQaDetailFromDeptLabel";
            this.lblQaDetailFromDeptLabel.Size = new System.Drawing.Size(120, 17);
            this.lblQaDetailFromDeptLabel.TabIndex = 4;
            this.lblQaDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtQaDetailFromDept
            // 
            this.txtQaDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailFromDept.Location = new System.Drawing.Point(163, 34);
            this.txtQaDetailFromDept.Name = "txtQaDetailFromDept";
            this.txtQaDetailFromDept.ReadOnly = true;
            this.txtQaDetailFromDept.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailFromDept.TabIndex = 5;
            // 
            // lblQaDetailDocTypesLabel
            // 
            this.lblQaDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailDocTypesLabel.AutoSize = true;
            this.lblQaDetailDocTypesLabel.Location = new System.Drawing.Point(679, 38);
            this.lblQaDetailDocTypesLabel.Name = "lblQaDetailDocTypesLabel";
            this.lblQaDetailDocTypesLabel.Size = new System.Drawing.Size(112, 17);
            this.lblQaDetailDocTypesLabel.TabIndex = 6;
            this.lblQaDetailDocTypesLabel.Text = "Document No.(s):";
            // 
            // txtQaDetailDocTypes
            // 
            this.txtQaDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailDocTypes.Location = new System.Drawing.Point(797, 34);
            this.txtQaDetailDocTypes.Name = "txtQaDetailDocTypes";
            this.txtQaDetailDocTypes.ReadOnly = true;
            this.txtQaDetailDocTypes.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailDocTypes.TabIndex = 7;
            // 
            // lblQaDetailProductLabel
            // 
            this.lblQaDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailProductLabel.AutoSize = true;
            this.lblQaDetailProductLabel.Location = new System.Drawing.Point(98, 69);
            this.lblQaDetailProductLabel.Name = "lblQaDetailProductLabel";
            this.lblQaDetailProductLabel.Size = new System.Drawing.Size(59, 17);
            this.lblQaDetailProductLabel.TabIndex = 8;
            this.lblQaDetailProductLabel.Text = "Product:";
            // 
            // txtQaDetailProduct
            // 
            this.txtQaDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailProduct.Location = new System.Drawing.Point(163, 65);
            this.txtQaDetailProduct.Name = "txtQaDetailProduct";
            this.txtQaDetailProduct.ReadOnly = true;
            this.txtQaDetailProduct.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailProduct.TabIndex = 9;
            // 
            // lblQaDetailBatchNoLabel
            // 
            this.lblQaDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailBatchNoLabel.AutoSize = true;
            this.lblQaDetailBatchNoLabel.Location = new System.Drawing.Point(721, 69);
            this.lblQaDetailBatchNoLabel.Name = "lblQaDetailBatchNoLabel";
            this.lblQaDetailBatchNoLabel.Size = new System.Drawing.Size(70, 17);
            this.lblQaDetailBatchNoLabel.TabIndex = 10;
            this.lblQaDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtQaDetailBatchNo
            // 
            this.txtQaDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailBatchNo.Location = new System.Drawing.Point(797, 65);
            this.txtQaDetailBatchNo.Name = "txtQaDetailBatchNo";
            this.txtQaDetailBatchNo.ReadOnly = true;
            this.txtQaDetailBatchNo.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailBatchNo.TabIndex = 11;
            // 
            // lblQaDetailMfgDateLabel
            // 
            this.lblQaDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMfgDateLabel.AutoSize = true;
            this.lblQaDetailMfgDateLabel.Location = new System.Drawing.Point(87, 100);
            this.lblQaDetailMfgDateLabel.Name = "lblQaDetailMfgDateLabel";
            this.lblQaDetailMfgDateLabel.Size = new System.Drawing.Size(70, 17);
            this.lblQaDetailMfgDateLabel.TabIndex = 12;
            this.lblQaDetailMfgDateLabel.Text = "Mfg. Date:";
            // 
            // txtQaDetailMfgDate
            // 
            this.txtQaDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMfgDate.Location = new System.Drawing.Point(163, 96);
            this.txtQaDetailMfgDate.Name = "txtQaDetailMfgDate";
            this.txtQaDetailMfgDate.ReadOnly = true;
            this.txtQaDetailMfgDate.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailMfgDate.TabIndex = 13;
            // 
            // lblQaDetailExpDateLabel
            // 
            this.lblQaDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailExpDateLabel.AutoSize = true;
            this.lblQaDetailExpDateLabel.Location = new System.Drawing.Point(723, 100);
            this.lblQaDetailExpDateLabel.Name = "lblQaDetailExpDateLabel";
            this.lblQaDetailExpDateLabel.Size = new System.Drawing.Size(68, 17);
            this.lblQaDetailExpDateLabel.TabIndex = 14;
            this.lblQaDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtQaDetailExpDate
            // 
            this.txtQaDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailExpDate.Location = new System.Drawing.Point(797, 96);
            this.txtQaDetailExpDate.Name = "txtQaDetailExpDate";
            this.txtQaDetailExpDate.ReadOnly = true;
            this.txtQaDetailExpDate.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailExpDate.TabIndex = 15;
            // 
            // lblQaDetailMarketLabel
            // 
            this.lblQaDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMarketLabel.AutoSize = true;
            this.lblQaDetailMarketLabel.Location = new System.Drawing.Point(103, 131);
            this.lblQaDetailMarketLabel.Name = "lblQaDetailMarketLabel";
            this.lblQaDetailMarketLabel.Size = new System.Drawing.Size(54, 17);
            this.lblQaDetailMarketLabel.TabIndex = 16;
            this.lblQaDetailMarketLabel.Text = "Market:";
            // 
            // txtQaDetailMarket
            // 
            this.txtQaDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMarket.Location = new System.Drawing.Point(163, 127);
            this.txtQaDetailMarket.Name = "txtQaDetailMarket";
            this.txtQaDetailMarket.ReadOnly = true;
            this.txtQaDetailMarket.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailMarket.TabIndex = 17;
            // 
            // lblQaDetailPackSizeLabel
            // 
            this.lblQaDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPackSizeLabel.AutoSize = true;
            this.lblQaDetailPackSizeLabel.Location = new System.Drawing.Point(725, 131);
            this.lblQaDetailPackSizeLabel.Name = "lblQaDetailPackSizeLabel";
            this.lblQaDetailPackSizeLabel.Size = new System.Drawing.Size(66, 17);
            this.lblQaDetailPackSizeLabel.TabIndex = 18;
            this.lblQaDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtQaDetailPackSize
            // 
            this.txtQaDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPackSize.Location = new System.Drawing.Point(797, 127);
            this.txtQaDetailPackSize.Name = "txtQaDetailPackSize";
            this.txtQaDetailPackSize.ReadOnly = true;
            this.txtQaDetailPackSize.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailPackSize.TabIndex = 19;
            // 
            // lblQaDetailPreparedByLabel
            // 
            this.lblQaDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPreparedByLabel.AutoSize = true;
            this.lblQaDetailPreparedByLabel.Location = new System.Drawing.Point(72, 162);
            this.lblQaDetailPreparedByLabel.Name = "lblQaDetailPreparedByLabel";
            this.lblQaDetailPreparedByLabel.Size = new System.Drawing.Size(85, 17);
            this.lblQaDetailPreparedByLabel.TabIndex = 20;
            this.lblQaDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtQaDetailPreparedBy
            // 
            this.txtQaDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPreparedBy.Location = new System.Drawing.Point(163, 158);
            this.txtQaDetailPreparedBy.Name = "txtQaDetailPreparedBy";
            this.txtQaDetailPreparedBy.ReadOnly = true;
            this.txtQaDetailPreparedBy.Size = new System.Drawing.Size(473, 25);
            this.txtQaDetailPreparedBy.TabIndex = 21;
            // 
            // lblQaDetailRequestedAtLabel
            // 
            this.lblQaDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestedAtLabel.AutoSize = true;
            this.lblQaDetailRequestedAtLabel.Location = new System.Drawing.Point(698, 162);
            this.lblQaDetailRequestedAtLabel.Name = "lblQaDetailRequestedAtLabel";
            this.lblQaDetailRequestedAtLabel.Size = new System.Drawing.Size(93, 17);
            this.lblQaDetailRequestedAtLabel.TabIndex = 22;
            this.lblQaDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtQaDetailRequestedAt
            // 
            this.txtQaDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestedAt.Location = new System.Drawing.Point(797, 158);
            this.txtQaDetailRequestedAt.Name = "txtQaDetailRequestedAt";
            this.txtQaDetailRequestedAt.ReadOnly = true;
            this.txtQaDetailRequestedAt.Size = new System.Drawing.Size(478, 25);
            this.txtQaDetailRequestedAt.TabIndex = 23;
            // 
            // lblQaDetailRequesterCommentsLabel
            // 
            this.lblQaDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailRequesterCommentsLabel.AutoSize = true;
            this.lblQaDetailRequesterCommentsLabel.Location = new System.Drawing.Point(15, 186);
            this.lblQaDetailRequesterCommentsLabel.Name = "lblQaDetailRequesterCommentsLabel";
            this.lblQaDetailRequesterCommentsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblQaDetailRequesterCommentsLabel.Size = new System.Drawing.Size(142, 22);
            this.lblQaDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblQaDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtQaDetailRequesterComments
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailRequesterComments, 3);
            this.txtQaDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailRequesterComments.Location = new System.Drawing.Point(163, 189);
            this.txtQaDetailRequesterComments.Multiline = true;
            this.txtQaDetailRequesterComments.Name = "txtQaDetailRequesterComments";
            this.txtQaDetailRequesterComments.ReadOnly = true;
            this.txtQaDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailRequesterComments.Size = new System.Drawing.Size(1112, 44);
            this.txtQaDetailRequesterComments.TabIndex = 25;
            // 
            // lblQaDetailHodCommentLabel
            // 
            this.lblQaDetailHodCommentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailHodCommentLabel.AutoSize = true;
            this.lblQaDetailHodCommentLabel.Location = new System.Drawing.Point(55, 236);
            this.lblQaDetailHodCommentLabel.Name = "lblQaDetailHodCommentLabel"; // UPDATED TEXT
            this.lblQaDetailHodCommentLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblQaDetailHodCommentLabel.Size = new System.Drawing.Size(102, 22);
            this.lblQaDetailHodCommentLabel.TabIndex = 26;
            this.lblQaDetailHodCommentLabel.Text = "HOD Comments:"; // UPDATED TEXT
            // 
            // txtQaDetailHodComment
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailHodComment, 3);
            this.txtQaDetailHodComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailHodComment.Location = new System.Drawing.Point(163, 239);
            this.txtQaDetailHodComment.Multiline = true;
            this.txtQaDetailHodComment.Name = "txtQaDetailHodComment"; // UPDATED NAME
            this.txtQaDetailHodComment.ReadOnly = true;
            this.txtQaDetailHodComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailHodComment.Size = new System.Drawing.Size(1112, 44);
            this.txtQaDetailHodComment.TabIndex = 27;
            // 
            // lblQaDetailHodActionTimeLabel
            // 
            this.lblQaDetailHodActionTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailHodActionTimeLabel.AutoSize = true;
            this.lblQaDetailHodActionTimeLabel.Location = new System.Drawing.Point(49, 293);
            this.lblQaDetailHodActionTimeLabel.Name = "lblQaDetailHodActionTimeLabel"; // UPDATED NAME
            this.lblQaDetailHodActionTimeLabel.Size = new System.Drawing.Size(108, 17);
            this.lblQaDetailHodActionTimeLabel.TabIndex = 28;
            this.lblQaDetailHodActionTimeLabel.Text = "HOD Action Time:"; // UPDATED TEXT
            // 
            // txtQaDetailHodActionTime
            // 
            this.txtQaDetailHodActionTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailHodActionTime, 3);
            this.txtQaDetailHodActionTime.Location = new System.Drawing.Point(163, 289);
            this.txtQaDetailHodActionTime.Name = "txtQaDetailHodActionTime"; // UPDATED NAME
            this.txtQaDetailHodActionTime.ReadOnly = true;
            this.txtQaDetailHodActionTime.Size = new System.Drawing.Size(1112, 25);
            this.txtQaDetailHodActionTime.TabIndex = 29;
            // 
            // grpQaParentBatchInfo
            // 
            this.grpQaParentBatchInfo.AutoSize = true;
            this.grpQaParentBatchInfo.Controls.Add(this.tlpQaParentBatchInfo);
            this.grpQaParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaParentBatchInfo.Location = new System.Drawing.Point(3, 364);
            this.grpQaParentBatchInfo.Name = "grpQaParentBatchInfo";
            this.grpQaParentBatchInfo.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaParentBatchInfo.Size = new System.Drawing.Size(1298, 96);
            this.grpQaParentBatchInfo.TabIndex = 2;
            this.grpQaParentBatchInfo.TabStop = false;
            this.grpQaParentBatchInfo.Text = "Parent Batch Information";
            this.grpQaParentBatchInfo.Visible = false;
            // 
            // tlpQaParentBatchInfo
            // 
            this.tlpQaParentBatchInfo.AutoSize = true;
            this.tlpQaParentBatchInfo.ColumnCount = 4;
            this.tlpQaParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpQaParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQaParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpQaParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQaParentBatchInfo.Controls.Add(this.lblQaParentBatchNo, 0, 0);
            this.tlpQaParentBatchInfo.Controls.Add(this.txtQaParentBatchNo, 1, 0);
            this.tlpQaParentBatchInfo.Controls.Add(this.lblQaParentBatchSize, 2, 0);
            this.tlpQaParentBatchInfo.Controls.Add(this.txtQaParentBatchSize, 3, 0);
            this.tlpQaParentBatchInfo.Controls.Add(this.lblQaParentMfgDate, 0, 1);
            this.tlpQaParentBatchInfo.Controls.Add(this.txtQaParentMfgDate, 1, 1);
            this.tlpQaParentBatchInfo.Controls.Add(this.lblQaParentExpDate, 2, 1);
            this.tlpQaParentBatchInfo.Controls.Add(this.txtQaParentExpDate, 3, 1);
            this.tlpQaParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaParentBatchInfo.Location = new System.Drawing.Point(10, 28);
            this.tlpQaParentBatchInfo.Name = "tlpQaParentBatchInfo";
            this.tlpQaParentBatchInfo.RowCount = 2;
            this.tlpQaParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpQaParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpQaParentBatchInfo.Size = new System.Drawing.Size(1278, 58);
            this.tlpQaParentBatchInfo.TabIndex = 0;
            // 
            // lblQaParentBatchNo
            // 
            this.lblQaParentBatchNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaParentBatchNo.AutoSize = true;
            this.lblQaParentBatchNo.Location = new System.Drawing.Point(43, 6);
            this.lblQaParentBatchNo.Name = "lblQaParentBatchNo";
            this.lblQaParentBatchNo.Size = new System.Drawing.Size(114, 17);
            this.lblQaParentBatchNo.TabIndex = 0;
            this.lblQaParentBatchNo.Text = "Parent Batch No.:";
            // 
            // txtQaParentBatchNo
            // 
            this.txtQaParentBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaParentBatchNo.Location = new System.Drawing.Point(163, 3);
            this.txtQaParentBatchNo.Name = "txtQaParentBatchNo";
            this.txtQaParentBatchNo.ReadOnly = true;
            this.txtQaParentBatchNo.Size = new System.Drawing.Size(473, 25);
            this.txtQaParentBatchNo.TabIndex = 1;
            // 
            // lblQaParentBatchSize
            // 
            this.lblQaParentBatchSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaParentBatchSize.AutoSize = true;
            this.lblQaParentBatchSize.Location = new System.Drawing.Point(675, 6);
            this.lblQaParentBatchSize.Name = "lblQaParentBatchSize";
            this.lblQaParentBatchSize.Size = new System.Drawing.Size(116, 17);
            this.lblQaParentBatchSize.TabIndex = 2;
            this.lblQaParentBatchSize.Text = "Parent Batch Size:";
            // 
            // txtQaParentBatchSize
            // 
            this.txtQaParentBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaParentBatchSize.Location = new System.Drawing.Point(797, 3);
            this.txtQaParentBatchSize.Name = "txtQaParentBatchSize";
            this.txtQaParentBatchSize.ReadOnly = true;
            this.txtQaParentBatchSize.Size = new System.Drawing.Size(478, 25);
            this.txtQaParentBatchSize.TabIndex = 3;
            // 
            // lblQaParentMfgDate
            // 
            this.lblQaParentMfgDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaParentMfgDate.AutoSize = true;
            this.lblQaParentMfgDate.Location = new System.Drawing.Point(43, 36);
            this.lblQaParentMfgDate.Name = "lblQaParentMfgDate";
            this.lblQaParentMfgDate.Size = new System.Drawing.Size(114, 17);
            this.lblQaParentMfgDate.TabIndex = 4;
            this.lblQaParentMfgDate.Text = "Parent Mfg. Date:";
            // 
            // txtQaParentMfgDate
            // 
            this.txtQaParentMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaParentMfgDate.Location = new System.Drawing.Point(163, 33);
            this.txtQaParentMfgDate.Name = "txtQaParentMfgDate";
            this.txtQaParentMfgDate.ReadOnly = true;
            this.txtQaParentMfgDate.Size = new System.Drawing.Size(473, 25);
            this.txtQaParentMfgDate.TabIndex = 5;
            // 
            // lblQaParentExpDate
            // 
            this.lblQaParentExpDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaParentExpDate.AutoSize = true;
            this.lblQaParentExpDate.Location = new System.Drawing.Point(679, 36);
            this.lblQaParentExpDate.Name = "lblQaParentExpDate";
            this.lblQaParentExpDate.Size = new System.Drawing.Size(112, 17);
            this.lblQaParentExpDate.TabIndex = 6;
            this.lblQaParentExpDate.Text = "Parent Exp. Date:";
            // 
            // txtQaParentExpDate
            // 
            this.txtQaParentExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaParentExpDate.Location = new System.Drawing.Point(797, 33);
            this.txtQaParentExpDate.Name = "txtQaParentExpDate";
            this.txtQaParentExpDate.ReadOnly = true;
            this.txtQaParentExpDate.Size = new System.Drawing.Size(478, 25);
            this.txtQaParentExpDate.TabIndex = 7;
            // 
            // grpQaAction
            // 
            this.grpQaAction.Controls.Add(this.tlpQaActionControls);
            this.grpQaAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaAction.Location = new System.Drawing.Point(3, 466);
            this.grpQaAction.Name = "grpQaAction";
            this.grpQaAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaAction.Size = new System.Drawing.Size(1298, 174);
            this.grpQaAction.TabIndex = 1;
            this.grpQaAction.TabStop = false;
            this.grpQaAction.Text = "QA Action & Verification";
            // 
            // tlpQaActionControls
            // 
            this.tlpQaActionControls.ColumnCount = 1;
            this.tlpQaActionControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaActionControls.Controls.Add(this.flpQaOptionalControls, 0, 0);
            this.tlpQaActionControls.Controls.Add(this.lblQaComment, 0, 1);
            this.tlpQaActionControls.Controls.Add(this.txtQaComment, 0, 2);
            this.tlpQaActionControls.Controls.Add(this.flpQaActionButtons, 0, 3);
            this.tlpQaActionControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaActionControls.Location = new System.Drawing.Point(10, 28);
            this.tlpQaActionControls.Name = "tlpQaActionControls";
            this.tlpQaActionControls.RowCount = 4;
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpQaActionControls.Size = new System.Drawing.Size(1278, 136);
            this.tlpQaActionControls.TabIndex = 0;
            // 
            // flpQaOptionalControls
            // 
            this.flpQaOptionalControls.Controls.Add(this.btnQaBrowseSelectDocument);
            this.flpQaOptionalControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQaOptionalControls.Location = new System.Drawing.Point(3, 3);
            this.flpQaOptionalControls.Name = "flpQaOptionalControls";
            this.flpQaOptionalControls.Size = new System.Drawing.Size(1272, 34);
            this.flpQaOptionalControls.TabIndex = 0;
            this.flpQaOptionalControls.WrapContents = false;
            // 
            // btnQaBrowseSelectDocument
            // 
            this.btnQaBrowseSelectDocument.CornerRadius = 8;
            this.btnQaBrowseSelectDocument.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQaBrowseSelectDocument.Location = new System.Drawing.Point(3, 3);
            this.btnQaBrowseSelectDocument.Name = "btnQaBrowseSelectDocument";
            this.btnQaBrowseSelectDocument.Size = new System.Drawing.Size(180, 30);
            this.btnQaBrowseSelectDocument.TabIndex = 2;
            this.btnQaBrowseSelectDocument.Text = "Open Document Location";
            this.btnQaBrowseSelectDocument.UseVisualStyleBackColor = true;
            // 
            // lblQaComment
            // 
            this.lblQaComment.AutoSize = true;
            this.lblQaComment.Location = new System.Drawing.Point(3, 40);
            this.lblQaComment.Name = "lblQaComment";
            this.lblQaComment.Size = new System.Drawing.Size(100, 17);
            this.lblQaComment.TabIndex = 1;
            this.lblQaComment.Text = "QA Comments:";
            // 
            // txtQaComment
            // 
            this.txtQaComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaComment.Location = new System.Drawing.Point(3, 60);
            this.txtQaComment.Multiline = true;
            this.txtQaComment.Name = "txtQaComment";
            this.txtQaComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaComment.Size = new System.Drawing.Size(1272, 26);
            this.txtQaComment.TabIndex = 2;
            // 
            // flpQaActionButtons
            // 
            this.flpQaActionButtons.Controls.Add(this.btnQaApprove);
            this.flpQaActionButtons.Controls.Add(this.btnQaReject);
            this.flpQaActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQaActionButtons.Location = new System.Drawing.Point(3, 92);
            this.flpQaActionButtons.Name = "flpQaActionButtons";
            this.flpQaActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpQaActionButtons.Size = new System.Drawing.Size(1272, 41);
            this.flpQaActionButtons.TabIndex = 3;
            // 
            // btnQaApprove
            // 
            this.btnQaApprove.CornerRadius = 8;
            this.btnQaApprove.FlatAppearance.BorderSize = 0;
            this.btnQaApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQaApprove.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQaApprove.Location = new System.Drawing.Point(3, 8);
            this.btnQaApprove.Name = "btnQaApprove";
            this.btnQaApprove.Size = new System.Drawing.Size(120, 30);
            this.btnQaApprove.TabIndex = 0;
            this.btnQaApprove.Text = "Approve";
            this.btnQaApprove.UseVisualStyleBackColor = true;
            // 
            // btnQaReject
            // 
            this.btnQaReject.CornerRadius = 8;
            this.btnQaReject.FlatAppearance.BorderSize = 0;
            this.btnQaReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQaReject.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQaReject.Location = new System.Drawing.Point(129, 8);
            this.btnQaReject.Name = "btnQaReject";
            this.btnQaReject.Size = new System.Drawing.Size(120, 30);
            this.btnQaReject.TabIndex = 1;
            this.btnQaReject.Text = "Reject";
            this.btnQaReject.UseVisualStyleBackColor = true;
            // 
            // QaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpQaOperationsMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QaControl";
            this.Size = new System.Drawing.Size(1330, 817);
            this.tlpQaOperationsMain.ResumeLayout(false);
            this.tlpQaOperationsMain.PerformLayout();
            this.pnlQaTopSection.ResumeLayout(false);
            this.tlpQaTopControls.ResumeLayout(false);
            this.pnlQaQueueHeader.ResumeLayout(false);
            this.pnlQaQueueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQaQueue)).EndInit();
            this.tlpQaBottomSection.ResumeLayout(false);
            this.tlpQaBottomSection.PerformLayout();
            this.grpQaSelectedRequest.ResumeLayout(false);
            this.grpQaSelectedRequest.PerformLayout();
            this.tlpQaRequestDetails.ResumeLayout(false);
            this.tlpQaRequestDetails.PerformLayout();
            this.grpQaAction.ResumeLayout(false);
            this.tlpQaActionControls.ResumeLayout(false);
            this.tlpQaActionControls.PerformLayout();
            this.flpQaOptionalControls.ResumeLayout(false);
            this.flpQaActionButtons.ResumeLayout(false);
            this.grpQaParentBatchInfo.ResumeLayout(false);
            this.tlpQaParentBatchInfo.ResumeLayout(false);
            this.tlpQaParentBatchInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpQaOperationsMain;
        private System.Windows.Forms.Panel pnlQaTopSection;
        private System.Windows.Forms.TableLayoutPanel tlpQaTopControls;
        private System.Windows.Forms.Panel pnlQaQueueHeader;
        private System.Windows.Forms.Label lblQaQueueTitle;
        private UI.RoundedButton btnQaRefreshList;
        private System.Windows.Forms.DataGridView dgvQaQueue;
        private System.Windows.Forms.TableLayoutPanel tlpQaBottomSection;
        private System.Windows.Forms.GroupBox grpQaSelectedRequest;
        private System.Windows.Forms.TableLayoutPanel tlpQaRequestDetails;
        private System.Windows.Forms.Label lblQaDetailRequestNoLabel;
        private System.Windows.Forms.TextBox txtQaDetailRequestNo;
        private System.Windows.Forms.Label lblQaDetailRequestDateLabel;
        private System.Windows.Forms.TextBox txtQaDetailRequestDate;
        private System.Windows.Forms.Label lblQaDetailFromDeptLabel;
        private System.Windows.Forms.TextBox txtQaDetailFromDept;
        private System.Windows.Forms.Label lblQaDetailDocTypesLabel;
        private System.Windows.Forms.TextBox txtQaDetailDocTypes;
        private System.Windows.Forms.Label lblQaDetailProductLabel;
        private System.Windows.Forms.TextBox txtQaDetailProduct;
        private System.Windows.Forms.Label lblQaDetailBatchNoLabel;
        private System.Windows.Forms.TextBox txtQaDetailBatchNo;
        private System.Windows.Forms.Label lblQaDetailMfgDateLabel;
        private System.Windows.Forms.TextBox txtQaDetailMfgDate;
        private System.Windows.Forms.Label lblQaDetailExpDateLabel;
        private System.Windows.Forms.TextBox txtQaDetailExpDate;
        private System.Windows.Forms.Label lblQaDetailMarketLabel;
        private System.Windows.Forms.TextBox txtQaDetailMarket;
        private System.Windows.Forms.Label lblQaDetailPackSizeLabel;
        private System.Windows.Forms.TextBox txtQaDetailPackSize;
        private System.Windows.Forms.Label lblQaDetailPreparedByLabel;
        private System.Windows.Forms.TextBox txtQaDetailPreparedBy;
        private System.Windows.Forms.Label lblQaDetailRequestedAtLabel;
        private System.Windows.Forms.TextBox txtQaDetailRequestedAt;
        private System.Windows.Forms.Label lblQaDetailRequesterCommentsLabel;
        private System.Windows.Forms.TextBox txtQaDetailRequesterComments;
        private System.Windows.Forms.Label lblQaDetailHodCommentLabel; // RENAMED
        private System.Windows.Forms.TextBox txtQaDetailHodComment; // RENAMED
        private System.Windows.Forms.Label lblQaDetailHodActionTimeLabel; // RENAMED
        private System.Windows.Forms.TextBox txtQaDetailHodActionTime; // RENAMED
        private System.Windows.Forms.GroupBox grpQaAction;
        private System.Windows.Forms.TableLayoutPanel tlpQaActionControls;
        private System.Windows.Forms.FlowLayoutPanel flpQaOptionalControls;
        private UI.RoundedButton btnQaBrowseSelectDocument;
        private System.Windows.Forms.Label lblQaComment;
        private System.Windows.Forms.TextBox txtQaComment;
        private System.Windows.Forms.FlowLayoutPanel flpQaActionButtons;
        private UI.RoundedButton btnQaApprove;
        private UI.RoundedButton btnQaReject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaRequestedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaAuthorizedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaHodActionAt; // RENAMED
        // --- NEW CONTROL DECLARATIONS ---
        private System.Windows.Forms.GroupBox grpQaParentBatchInfo;
        private System.Windows.Forms.TableLayoutPanel tlpQaParentBatchInfo;
        private System.Windows.Forms.Label lblQaParentBatchNo;
        private System.Windows.Forms.TextBox txtQaParentBatchNo;
        private System.Windows.Forms.Label lblQaParentBatchSize;
        private System.Windows.Forms.TextBox txtQaParentBatchSize;
        private System.Windows.Forms.Label lblQaParentMfgDate;
        private System.Windows.Forms.TextBox txtQaParentMfgDate;
        private System.Windows.Forms.Label lblQaParentExpDate;
        private System.Windows.Forms.TextBox txtQaParentExpDate;
    }
}