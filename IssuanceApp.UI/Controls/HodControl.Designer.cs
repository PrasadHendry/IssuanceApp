// HodControl.Designer.cs

namespace IssuanceApp.UI.Controls
{
    partial class HodControl
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
            this.tlpHodOperationsMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHodTopSection = new System.Windows.Forms.Panel();
            this.tlpHodTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHodQueueHeader = new System.Windows.Forms.Panel();
            this.lblHodQueueTitle = new System.Windows.Forms.Label();
            this.btnHodRefreshList = new IssuanceApp.UI.RoundedButton();
            this.dgvHodQueue = new System.Windows.Forms.DataGridView();
            this.colHodRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHodRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHodProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHodDocTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHodPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHodRequestedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpHodBottomSection = new System.Windows.Forms.TableLayoutPanel();
            this.grpHodSelectedRequest = new System.Windows.Forms.GroupBox();
            this.tlpHodRequestDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblHodDetailRequestNoLabel = new System.Windows.Forms.Label();
            this.txtHodDetailRequestNo = new System.Windows.Forms.TextBox();
            this.lblHodDetailRequestDateLabel = new System.Windows.Forms.Label();
            this.txtHodDetailRequestDate = new System.Windows.Forms.TextBox();
            this.lblHodDetailFromDeptLabel = new System.Windows.Forms.Label();
            this.txtHodDetailFromDept = new System.Windows.Forms.TextBox();
            this.lblHodDetailDocTypesLabel = new System.Windows.Forms.Label();
            this.txtHodDetailDocTypes = new System.Windows.Forms.TextBox();
            this.lblHodDetailProductLabel = new System.Windows.Forms.Label();
            this.txtHodDetailProduct = new System.Windows.Forms.TextBox();
            this.lblHodDetailBatchNoLabel = new System.Windows.Forms.Label();
            this.txtHodDetailBatchNo = new System.Windows.Forms.TextBox();
            this.lblHodDetailMfgDateLabel = new System.Windows.Forms.Label();
            this.txtHodDetailMfgDate = new System.Windows.Forms.TextBox();
            this.lblHodDetailExpDateLabel = new System.Windows.Forms.Label();
            this.txtHodDetailExpDate = new System.Windows.Forms.TextBox();
            this.lblHodDetailMarketLabel = new System.Windows.Forms.Label();
            this.txtHodDetailMarket = new System.Windows.Forms.TextBox();
            this.lblHodDetailPackSizeLabel = new System.Windows.Forms.Label();
            this.txtHodDetailPackSize = new System.Windows.Forms.TextBox();
            this.lblHodDetailPreparedByLabel = new System.Windows.Forms.Label();
            this.txtHodDetailPreparedBy = new System.Windows.Forms.TextBox();
            this.lblHodDetailRequestedAtLabel = new System.Windows.Forms.Label();
            this.txtHodDetailRequestedAt = new System.Windows.Forms.TextBox();
            this.lblHodDetailRequesterCommentsLabel = new System.Windows.Forms.Label();
            this.txtHodDetailRequesterComments = new System.Windows.Forms.TextBox();
            this.grpHodAction = new System.Windows.Forms.GroupBox();
            this.tlpHodActionControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblHodComment = new System.Windows.Forms.Label();
            this.txtHodComment = new System.Windows.Forms.TextBox();
            this.flpHodActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHodAuthorize = new IssuanceApp.UI.RoundedButton();
            this.btnHodReject = new IssuanceApp.UI.RoundedButton();
            this.grpHodParentBatchInfo = new System.Windows.Forms.GroupBox();
            this.tlpHodParentBatchInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblHodParentBatchNo = new System.Windows.Forms.Label();
            this.txtHodParentBatchNo = new System.Windows.Forms.TextBox();
            this.lblHodParentBatchSize = new System.Windows.Forms.Label();
            this.txtHodParentBatchSize = new System.Windows.Forms.TextBox();
            this.lblHodParentMfgDate = new System.Windows.Forms.Label();
            this.txtHodParentMfgDate = new System.Windows.Forms.TextBox();
            this.lblHodParentExpDate = new System.Windows.Forms.Label();
            this.txtHodParentExpDate = new System.Windows.Forms.TextBox();
            this.tlpHodOperationsMain.SuspendLayout();
            this.pnlHodTopSection.SuspendLayout();
            this.tlpHodTopControls.SuspendLayout();
            this.pnlHodQueueHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHodQueue)).BeginInit();
            this.tlpHodBottomSection.SuspendLayout();
            this.grpHodSelectedRequest.SuspendLayout();
            this.tlpHodRequestDetails.SuspendLayout();
            this.grpHodAction.SuspendLayout();
            this.tlpHodActionControls.SuspendLayout();
            this.flpHodActionButtons.SuspendLayout();
            this.grpHodParentBatchInfo.SuspendLayout();
            this.tlpHodParentBatchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGmOperationsMain
            // 
            this.tlpHodOperationsMain.AutoScroll = true;
            this.tlpHodOperationsMain.ColumnCount = 1;
            this.tlpHodOperationsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodOperationsMain.Controls.Add(this.pnlHodTopSection, 0, 0);
            this.tlpHodOperationsMain.Controls.Add(this.tlpHodBottomSection, 0, 1);
            this.tlpHodOperationsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodOperationsMain.Location = new System.Drawing.Point(0, 0);
            this.tlpHodOperationsMain.Name = "tlpHodOperationsMain";
            this.tlpHodOperationsMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpHodOperationsMain.RowCount = 2;
            this.tlpHodOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpHodOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodOperationsMain.Size = new System.Drawing.Size(1313, 706);
            this.tlpHodOperationsMain.TabIndex = 1;
            // 
            // pnlHodTopSection
            // 
            this.pnlHodTopSection.Controls.Add(this.tlpHodTopControls);
            this.pnlHodTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHodTopSection.Location = new System.Drawing.Point(13, 13);
            this.pnlHodTopSection.Name = "pnlHodTopSection";
            this.pnlHodTopSection.Size = new System.Drawing.Size(1287, 244);
            this.pnlHodTopSection.TabIndex = 0;
            // 
            // tlpHodTopControls
            // 
            this.tlpHodTopControls.ColumnCount = 1;
            this.tlpHodTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodTopControls.Controls.Add(this.pnlHodQueueHeader, 0, 0);
            this.tlpHodTopControls.Controls.Add(this.dgvHodQueue, 0, 1);
            this.tlpHodTopControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodTopControls.Location = new System.Drawing.Point(0, 0);
            this.tlpHodTopControls.Name = "tlpHodTopControls";
            this.tlpHodTopControls.RowCount = 2;
            this.tlpHodTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHodTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodTopControls.Size = new System.Drawing.Size(1287, 244);
            this.tlpHodTopControls.TabIndex = 0;
            // 
            // pnlHodQueueHeader
            // 
            this.pnlHodQueueHeader.Controls.Add(this.lblHodQueueTitle);
            this.pnlHodQueueHeader.Controls.Add(this.btnHodRefreshList);
            this.pnlHodQueueHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHodQueueHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHodQueueHeader.Name = "pnlHodQueueHeader";
            this.pnlHodQueueHeader.Size = new System.Drawing.Size(1281, 34);
            this.pnlHodQueueHeader.TabIndex = 0;
            // 
            // lblHodQueueTitle
            // 
            this.lblHodQueueTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHodQueueTitle.AutoSize = true;
            this.lblHodQueueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHodQueueTitle.Location = new System.Drawing.Point(5, 6);
            this.lblHodQueueTitle.Name = "lblHodQueueTitle";
            this.lblHodQueueTitle.Size = new System.Drawing.Size(232, 21);
            this.lblHodQueueTitle.TabIndex = 0;
            this.lblHodQueueTitle.Text = "Pending HOD Approval Queue";
            // 
            // btnHodRefreshList
            // 
            this.btnHodRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHodRefreshList.CornerRadius = 8;
            this.btnHodRefreshList.FlatAppearance.BorderSize = 0;
            this.btnHodRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHodRefreshList.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHodRefreshList.Location = new System.Drawing.Point(1156, 2);
            this.btnHodRefreshList.Name = "btnHodRefreshList";
            this.btnHodRefreshList.Size = new System.Drawing.Size(120, 30);
            this.btnHodRefreshList.TabIndex = 1;
            this.btnHodRefreshList.Text = "Refresh List";
            this.btnHodRefreshList.UseVisualStyleBackColor = true;
            // 
            // dgvHodQueue
            // 
            this.dgvHodQueue.AllowUserToAddRows = false;
            this.dgvHodQueue.AllowUserToDeleteRows = false;
            this.dgvHodQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHodQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvHodQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHodQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHodRequestNo,
            this.colHodRequestDate,
            this.colHodProduct,
            this.colHodDocTypes,
            this.colHodPreparedBy,
            this.colHodRequestedAt});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHodQueue.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHodQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHodQueue.Location = new System.Drawing.Point(3, 43);
            this.dgvHodQueue.MultiSelect = false;
            this.dgvHodQueue.Name = "dgvHodQueue";
            this.dgvHodQueue.ReadOnly = true;
            this.dgvHodQueue.RowHeadersWidth = 51;
            this.dgvHodQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHodQueue.Size = new System.Drawing.Size(1281, 198);
            this.dgvHodQueue.TabIndex = 1;
            // 
            // colHodRequestNo
            // 
            this.colHodRequestNo.DataPropertyName = "RequestNo";
            this.colHodRequestNo.HeaderText = "Request No.";
            this.colHodRequestNo.MinimumWidth = 6;
            this.colHodRequestNo.Name = "colHodRequestNo";
            this.colHodRequestNo.ReadOnly = true;
            // 
            // colHodRequestDate
            // 
            this.colHodRequestDate.DataPropertyName = "RequestDate";
            this.colHodRequestDate.HeaderText = "Request Date";
            this.colHodRequestDate.MinimumWidth = 6;
            this.colHodRequestDate.Name = "colHodRequestDate";
            this.colHodRequestDate.ReadOnly = true;
            // 
            // colHodProduct
            // 
            this.colHodProduct.DataPropertyName = "Product";
            this.colHodProduct.HeaderText = "Product";
            this.colHodProduct.MinimumWidth = 6;
            this.colHodProduct.Name = "colHodProduct";
            this.colHodProduct.ReadOnly = true;
            // 
            // colHodDocTypes
            // 
            this.colHodDocTypes.DataPropertyName = "DocumentNo";
            this.colHodDocTypes.HeaderText = "Document No(s).";
            this.colHodDocTypes.MinimumWidth = 6;
            this.colHodDocTypes.Name = "colHodDocTypes";
            this.colHodDocTypes.ReadOnly = true;
            // 
            // colHodPreparedBy
            // 
            this.colHodPreparedBy.DataPropertyName = "PreparedBy";
            this.colHodPreparedBy.HeaderText = "Prepared By";
            this.colHodPreparedBy.MinimumWidth = 6;
            this.colHodPreparedBy.Name = "colHodPreparedBy";
            this.colHodPreparedBy.ReadOnly = true;
            // 
            // colHodRequestedAt
            // 
            this.colHodRequestedAt.DataPropertyName = "RequestedAt";
            this.colHodRequestedAt.HeaderText = "Requested At";
            this.colHodRequestedAt.MinimumWidth = 6;
            this.colHodRequestedAt.Name = "colHodRequestedAt";
            this.colHodRequestedAt.ReadOnly = true;
            // 
            // tlpHodBottomSection
            // 
            this.tlpHodBottomSection.AutoSize = true;
            this.tlpHodBottomSection.ColumnCount = 1;
            this.tlpHodBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodBottomSection.Controls.Add(this.grpHodSelectedRequest, 0, 0);
            this.tlpHodBottomSection.Controls.Add(this.grpHodParentBatchInfo, 0, 1);
            this.tlpHodBottomSection.Controls.Add(this.grpHodAction, 0, 2);
            this.tlpHodBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodBottomSection.Location = new System.Drawing.Point(13, 263);
            this.tlpHodBottomSection.Name = "tlpHodBottomSection";
            this.tlpHodBottomSection.RowCount = 3;
            this.tlpHodBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpHodBottomSection.Size = new System.Drawing.Size(1287, 430);
            this.tlpHodBottomSection.TabIndex = 1;
            // 
            // grpHodSelectedRequest
            // 
            this.grpHodSelectedRequest.AutoSize = true;
            this.grpHodSelectedRequest.Controls.Add(this.tlpHodRequestDetails);
            this.grpHodSelectedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHodSelectedRequest.Location = new System.Drawing.Point(3, 3);
            this.grpHodSelectedRequest.Name = "grpHodSelectedRequest";
            this.grpHodSelectedRequest.Padding = new System.Windows.Forms.Padding(10);
            this.grpHodSelectedRequest.Size = new System.Drawing.Size(1281, 284);
            this.grpHodSelectedRequest.TabIndex = 0;
            this.grpHodSelectedRequest.TabStop = false;
            this.grpHodSelectedRequest.Text = "Selected Request Details";
            // 
            // tlpHodRequestDetails
            // 
            this.tlpHodRequestDetails.AutoScroll = true;
            this.tlpHodRequestDetails.AutoSize = true;
            this.tlpHodRequestDetails.ColumnCount = 4;
            this.tlpHodRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpHodRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHodRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpHodRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailRequestNoLabel, 0, 0);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailRequestNo, 1, 0);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailRequestDateLabel, 2, 0);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailRequestDate, 3, 0);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailFromDeptLabel, 0, 1);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailFromDept, 1, 1);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailDocTypesLabel, 2, 1);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailDocTypes, 3, 1);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailProductLabel, 0, 2);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailProduct, 1, 2);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailBatchNoLabel, 2, 2);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailBatchNo, 3, 2);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailMfgDateLabel, 0, 3);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailMfgDate, 1, 3);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailExpDateLabel, 2, 3);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailExpDate, 3, 3);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailMarketLabel, 0, 4);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailMarket, 1, 4);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailPackSizeLabel, 2, 4);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailPackSize, 3, 4);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailPreparedByLabel, 0, 5);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailPreparedBy, 1, 5);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailRequestedAtLabel, 2, 5);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailRequestedAt, 3, 5);
            this.tlpHodRequestDetails.Controls.Add(this.lblHodDetailRequesterCommentsLabel, 0, 6);
            this.tlpHodRequestDetails.Controls.Add(this.txtHodDetailRequesterComments, 1, 6);
            this.tlpHodRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodRequestDetails.Location = new System.Drawing.Point(10, 28);
            this.tlpHodRequestDetails.Name = "tlpHodRequestDetails";
            this.tlpHodRequestDetails.RowCount = 7;
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpHodRequestDetails.Size = new System.Drawing.Size(1261, 246);
            this.tlpHodRequestDetails.TabIndex = 0;
            // 
            // lblHodDetailRequestNoLabel
            // 
            this.lblHodDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailRequestNoLabel.AutoSize = true;
            this.lblHodDetailRequestNoLabel.Location = new System.Drawing.Point(62, 7);
            this.lblHodDetailRequestNoLabel.Name = "lblHodDetailRequestNoLabel";
            this.lblHodDetailRequestNoLabel.Size = new System.Drawing.Size(85, 17);
            this.lblHodDetailRequestNoLabel.TabIndex = 0;
            this.lblHodDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtHodDetailRequestNo
            // 
            this.txtHodDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailRequestNo.Location = new System.Drawing.Point(153, 3);
            this.txtHodDetailRequestNo.Name = "txtHodDetailRequestNo";
            this.txtHodDetailRequestNo.ReadOnly = true;
            this.txtHodDetailRequestNo.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailRequestNo.TabIndex = 1;
            // 
            // lblHodDetailRequestDateLabel
            // 
            this.lblHodDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailRequestDateLabel.AutoSize = true;
            this.lblHodDetailRequestDateLabel.Location = new System.Drawing.Point(685, 7);
            this.lblHodDetailRequestDateLabel.Name = "lblHodDetailRequestDateLabel";
            this.lblHodDetailRequestDateLabel.Size = new System.Drawing.Size(92, 17);
            this.lblHodDetailRequestDateLabel.TabIndex = 2;
            this.lblHodDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtHodDetailRequestDate
            // 
            this.txtHodDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailRequestDate.Location = new System.Drawing.Point(783, 3);
            this.txtHodDetailRequestDate.Name = "txtHodDetailRequestDate";
            this.txtHodDetailRequestDate.ReadOnly = true;
            this.txtHodDetailRequestDate.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailRequestDate.TabIndex = 3;
            // 
            // lblHodDetailFromDeptLabel
            // 
            this.lblHodDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailFromDeptLabel.AutoSize = true;
            this.lblHodDetailFromDeptLabel.Location = new System.Drawing.Point(27, 38);
            this.lblHodDetailFromDeptLabel.Name = "lblHodDetailFromDeptLabel";
            this.lblHodDetailFromDeptLabel.Size = new System.Drawing.Size(120, 17);
            this.lblHodDetailFromDeptLabel.TabIndex = 4;
            this.lblHodDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtHodDetailFromDept
            // 
            this.txtHodDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailFromDept.Location = new System.Drawing.Point(153, 34);
            this.txtHodDetailFromDept.Name = "txtHodDetailFromDept";
            this.txtHodDetailFromDept.ReadOnly = true;
            this.txtHodDetailFromDept.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailFromDept.TabIndex = 5;
            // 
            // lblHodDetailDocTypesLabel
            // 
            this.lblHodDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailDocTypesLabel.AutoSize = true;
            this.lblHodDetailDocTypesLabel.Location = new System.Drawing.Point(665, 38);
            this.lblHodDetailDocTypesLabel.Name = "lblHodDetailDocTypesLabel";
            this.lblHodDetailDocTypesLabel.Size = new System.Drawing.Size(112, 17);
            this.lblHodDetailDocTypesLabel.TabIndex = 6;
            this.lblHodDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtHodDetailDocTypes
            // 
            this.txtHodDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailDocTypes.Location = new System.Drawing.Point(783, 34);
            this.txtHodDetailDocTypes.Name = "txtHodDetailDocTypes";
            this.txtHodDetailDocTypes.ReadOnly = true;
            this.txtHodDetailDocTypes.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailDocTypes.TabIndex = 7;
            // 
            // lblHodDetailProductLabel
            // 
            this.lblHodDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailProductLabel.AutoSize = true;
            this.lblHodDetailProductLabel.Location = new System.Drawing.Point(88, 69);
            this.lblHodDetailProductLabel.Name = "lblHodDetailProductLabel";
            this.lblHodDetailProductLabel.Size = new System.Drawing.Size(59, 17);
            this.lblHodDetailProductLabel.TabIndex = 8;
            this.lblHodDetailProductLabel.Text = "Product:";
            // 
            // txtHodDetailProduct
            // 
            this.txtHodDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailProduct.Location = new System.Drawing.Point(153, 65);
            this.txtHodDetailProduct.Name = "txtHodDetailProduct";
            this.txtHodDetailProduct.ReadOnly = true;
            this.txtHodDetailProduct.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailProduct.TabIndex = 9;
            // 
            // lblHodDetailBatchNoLabel
            // 
            this.lblHodDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailBatchNoLabel.AutoSize = true;
            this.lblHodDetailBatchNoLabel.Location = new System.Drawing.Point(707, 69);
            this.lblHodDetailBatchNoLabel.Name = "lblHodDetailBatchNoLabel";
            this.lblHodDetailBatchNoLabel.Size = new System.Drawing.Size(70, 17);
            this.lblHodDetailBatchNoLabel.TabIndex = 10;
            this.lblHodDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtHodDetailBatchNo
            // 
            this.txtHodDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailBatchNo.Location = new System.Drawing.Point(783, 65);
            this.txtHodDetailBatchNo.Name = "txtHodDetailBatchNo";
            this.txtHodDetailBatchNo.ReadOnly = true;
            this.txtHodDetailBatchNo.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailBatchNo.TabIndex = 11;
            // 
            // lblHodDetailMfgDateLabel
            // 
            this.lblHodDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailMfgDateLabel.AutoSize = true;
            this.lblHodDetailMfgDateLabel.Location = new System.Drawing.Point(80, 100);
            this.lblHodDetailMfgDateLabel.Name = "lblHodDetailMfgDateLabel";
            this.lblHodDetailMfgDateLabel.Size = new System.Drawing.Size(67, 17);
            this.lblHodDetailMfgDateLabel.TabIndex = 12;
            this.lblHodDetailMfgDateLabel.Text = "Mfg Date:";
            // 
            // txtHodDetailMfgDate
            // 
            this.txtHodDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailMfgDate.Location = new System.Drawing.Point(153, 96);
            this.txtHodDetailMfgDate.Name = "txtHodDetailMfgDate";
            this.txtHodDetailMfgDate.ReadOnly = true;
            this.txtHodDetailMfgDate.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailMfgDate.TabIndex = 13;
            // 
            // lblHodDetailExpDateLabel
            // 
            this.lblHodDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailExpDateLabel.AutoSize = true;
            this.lblHodDetailExpDateLabel.Location = new System.Drawing.Point(709, 100);
            this.lblHodDetailExpDateLabel.Name = "lblHodDetailExpDateLabel";
            this.lblHodDetailExpDateLabel.Size = new System.Drawing.Size(68, 17);
            this.lblHodDetailExpDateLabel.TabIndex = 14;
            this.lblHodDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtHodDetailExpDate
            // 
            this.txtHodDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailExpDate.Location = new System.Drawing.Point(783, 96);
            this.txtHodDetailExpDate.Name = "txtHodDetailExpDate";
            this.txtHodDetailExpDate.ReadOnly = true;
            this.txtHodDetailExpDate.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailExpDate.TabIndex = 15;
            // 
            // lblHodDetailMarketLabel
            // 
            this.lblHodDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailMarketLabel.AutoSize = true;
            this.lblHodDetailMarketLabel.Location = new System.Drawing.Point(93, 131);
            this.lblHodDetailMarketLabel.Name = "lblHodDetailMarketLabel";
            this.lblHodDetailMarketLabel.Size = new System.Drawing.Size(54, 17);
            this.lblHodDetailMarketLabel.TabIndex = 16;
            this.lblHodDetailMarketLabel.Text = "Market:";
            // 
            // txtHodDetailMarket
            // 
            this.txtHodDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailMarket.Location = new System.Drawing.Point(153, 127);
            this.txtHodDetailMarket.Name = "txtHodDetailMarket";
            this.txtHodDetailMarket.ReadOnly = true;
            this.txtHodDetailMarket.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailMarket.TabIndex = 17;
            // 
            // lblHodDetailPackSizeLabel
            // 
            this.lblHodDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailPackSizeLabel.AutoSize = true;
            this.lblHodDetailPackSizeLabel.Location = new System.Drawing.Point(711, 131);
            this.lblHodDetailPackSizeLabel.Name = "lblHodDetailPackSizeLabel";
            this.lblHodDetailPackSizeLabel.Size = new System.Drawing.Size(66, 17);
            this.lblHodDetailPackSizeLabel.TabIndex = 18;
            this.lblHodDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtHodDetailPackSize
            // 
            this.txtHodDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailPackSize.Location = new System.Drawing.Point(783, 127);
            this.txtHodDetailPackSize.Name = "txtHodDetailPackSize";
            this.txtHodDetailPackSize.ReadOnly = true;
            this.txtHodDetailPackSize.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailPackSize.TabIndex = 19;
            // 
            // lblHodDetailPreparedByLabel
            // 
            this.lblHodDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailPreparedByLabel.AutoSize = true;
            this.lblHodDetailPreparedByLabel.Location = new System.Drawing.Point(62, 162);
            this.lblHodDetailPreparedByLabel.Name = "lblHodDetailPreparedByLabel";
            this.lblHodDetailPreparedByLabel.Size = new System.Drawing.Size(85, 17);
            this.lblHodDetailPreparedByLabel.TabIndex = 20;
            this.lblHodDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtHodDetailPreparedBy
            // 
            this.txtHodDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailPreparedBy.Location = new System.Drawing.Point(153, 158);
            this.txtHodDetailPreparedBy.Name = "txtHodDetailPreparedBy";
            this.txtHodDetailPreparedBy.ReadOnly = true;
            this.txtHodDetailPreparedBy.Size = new System.Drawing.Size(474, 25);
            this.txtHodDetailPreparedBy.TabIndex = 21;
            // 
            // lblHodDetailRequestedAtLabel
            // 
            this.lblHodDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodDetailRequestedAtLabel.AutoSize = true;
            this.lblHodDetailRequestedAtLabel.Location = new System.Drawing.Point(684, 162);
            this.lblHodDetailRequestedAtLabel.Name = "lblHodDetailRequestedAtLabel";
            this.lblHodDetailRequestedAtLabel.Size = new System.Drawing.Size(93, 17);
            this.lblHodDetailRequestedAtLabel.TabIndex = 22;
            this.lblHodDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtHodDetailRequestedAt
            // 
            this.txtHodDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodDetailRequestedAt.Location = new System.Drawing.Point(783, 158);
            this.txtHodDetailRequestedAt.Name = "txtHodDetailRequestedAt";
            this.txtHodDetailRequestedAt.ReadOnly = true;
            this.txtHodDetailRequestedAt.Size = new System.Drawing.Size(475, 25);
            this.txtHodDetailRequestedAt.TabIndex = 23;
            // 
            // lblHodDetailRequesterCommentsLabel
            // 
            this.lblHodDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHodDetailRequesterCommentsLabel.AutoSize = true;
            this.lblHodDetailRequesterCommentsLabel.Location = new System.Drawing.Point(5, 196);
            this.lblHodDetailRequesterCommentsLabel.Name = "lblHodDetailRequesterCommentsLabel";
            this.lblHodDetailRequesterCommentsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblHodDetailRequesterCommentsLabel.Size = new System.Drawing.Size(142, 22);
            this.lblHodDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblHodDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtHodDetailRequesterComments
            // 
            this.tlpHodRequestDetails.SetColumnSpan(this.txtHodDetailRequesterComments, 3);
            this.txtHodDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHodDetailRequesterComments.Location = new System.Drawing.Point(153, 199);
            this.txtHodDetailRequesterComments.Multiline = true;
            this.txtHodDetailRequesterComments.Name = "txtHodDetailRequesterComments";
            this.txtHodDetailRequesterComments.ReadOnly = true;
            this.txtHodDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHodDetailRequesterComments.Size = new System.Drawing.Size(1105, 44);
            this.txtHodDetailRequesterComments.TabIndex = 25;
            // 
            // grpHodParentBatchInfo
            // 
            this.grpHodParentBatchInfo.AutoSize = true;
            this.grpHodParentBatchInfo.Controls.Add(this.tlpHodParentBatchInfo);
            this.grpHodParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHodParentBatchInfo.Location = new System.Drawing.Point(3, 293);
            this.grpHodParentBatchInfo.Name = "grpHodParentBatchInfo";
            this.grpHodParentBatchInfo.Padding = new System.Windows.Forms.Padding(10);
            this.grpHodParentBatchInfo.Size = new System.Drawing.Size(1281, 96);
            this.grpHodParentBatchInfo.TabIndex = 2;
            this.grpHodParentBatchInfo.TabStop = false;
            this.grpHodParentBatchInfo.Text = "Parent Batch Information";
            this.grpHodParentBatchInfo.Visible = false;
            // 
            // tlpHodParentBatchInfo
            // 
            this.tlpHodParentBatchInfo.AutoSize = true;
            this.tlpHodParentBatchInfo.ColumnCount = 4;
            this.tlpHodParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpHodParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHodParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpHodParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHodParentBatchInfo.Controls.Add(this.lblHodParentBatchNo, 0, 0);
            this.tlpHodParentBatchInfo.Controls.Add(this.txtHodParentBatchNo, 1, 0);
            this.tlpHodParentBatchInfo.Controls.Add(this.lblHodParentBatchSize, 2, 0);
            this.tlpHodParentBatchInfo.Controls.Add(this.txtHodParentBatchSize, 3, 0);
            this.tlpHodParentBatchInfo.Controls.Add(this.lblHodParentMfgDate, 0, 1);
            this.tlpHodParentBatchInfo.Controls.Add(this.txtHodParentMfgDate, 1, 1);
            this.tlpHodParentBatchInfo.Controls.Add(this.lblHodParentExpDate, 2, 1);
            this.tlpHodParentBatchInfo.Controls.Add(this.txtHodParentExpDate, 3, 1);
            this.tlpHodParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodParentBatchInfo.Location = new System.Drawing.Point(10, 28);
            this.tlpHodParentBatchInfo.Name = "tlpHodParentBatchInfo";
            this.tlpHodParentBatchInfo.RowCount = 2;
            this.tlpHodParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpHodParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpHodParentBatchInfo.Size = new System.Drawing.Size(1261, 58);
            this.tlpHodParentBatchInfo.TabIndex = 0;
            // 
            // lblHodParentBatchNo
            // 
            this.lblHodParentBatchNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodParentBatchNo.AutoSize = true;
            this.lblHodParentBatchNo.Location = new System.Drawing.Point(33, 6);
            this.lblHodParentBatchNo.Name = "lblHodParentBatchNo";
            this.lblHodParentBatchNo.Size = new System.Drawing.Size(114, 17);
            this.lblHodParentBatchNo.TabIndex = 0;
            this.lblHodParentBatchNo.Text = "Parent Batch No.:";
            // 
            // txtHodParentBatchNo
            // 
            this.txtHodParentBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodParentBatchNo.Location = new System.Drawing.Point(153, 3);
            this.txtHodParentBatchNo.Name = "txtHodParentBatchNo";
            this.txtHodParentBatchNo.ReadOnly = true;
            this.txtHodParentBatchNo.Size = new System.Drawing.Size(474, 25);
            this.txtHodParentBatchNo.TabIndex = 1;
            // 
            // lblHodParentBatchSize
            // 
            this.lblHodParentBatchSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodParentBatchSize.AutoSize = true;
            this.lblHodParentBatchSize.Location = new System.Drawing.Point(661, 6);
            this.lblHodParentBatchSize.Name = "lblHodParentBatchSize";
            this.lblHodParentBatchSize.Size = new System.Drawing.Size(116, 17);
            this.lblHodParentBatchSize.TabIndex = 2;
            this.lblHodParentBatchSize.Text = "Parent Batch Size:";
            // 
            // txtHodParentBatchSize
            // 
            this.txtHodParentBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodParentBatchSize.Location = new System.Drawing.Point(783, 3);
            this.txtHodParentBatchSize.Name = "txtHodParentBatchSize";
            this.txtHodParentBatchSize.ReadOnly = true;
            this.txtHodParentBatchSize.Size = new System.Drawing.Size(475, 25);
            this.txtHodParentBatchSize.TabIndex = 3;
            // 
            // lblHodParentMfgDate
            // 
            this.lblHodParentMfgDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodParentMfgDate.AutoSize = true;
            this.lblHodParentMfgDate.Location = new System.Drawing.Point(33, 36);
            this.lblHodParentMfgDate.Name = "lblHodParentMfgDate";
            this.lblHodParentMfgDate.Size = new System.Drawing.Size(114, 17);
            this.lblHodParentMfgDate.TabIndex = 4;
            this.lblHodParentMfgDate.Text = "Parent Mfg. Date:";
            // 
            // txtHodParentMfgDate
            // 
            this.txtHodParentMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodParentMfgDate.Location = new System.Drawing.Point(153, 33);
            this.txtHodParentMfgDate.Name = "txtHodParentMfgDate";
            this.txtHodParentMfgDate.ReadOnly = true;
            this.txtHodParentMfgDate.Size = new System.Drawing.Size(474, 25);
            this.txtHodParentMfgDate.TabIndex = 5;
            // 
            // lblHodParentExpDate
            // 
            this.lblHodParentExpDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHodParentExpDate.AutoSize = true;
            this.lblHodParentExpDate.Location = new System.Drawing.Point(665, 36);
            this.lblHodParentExpDate.Name = "lblHodParentExpDate";
            this.lblHodParentExpDate.Size = new System.Drawing.Size(112, 17);
            this.lblHodParentExpDate.TabIndex = 6;
            this.lblHodParentExpDate.Text = "Parent Exp. Date:";
            // 
            // txtHodParentExpDate
            // 
            this.txtHodParentExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHodParentExpDate.Location = new System.Drawing.Point(783, 33);
            this.txtHodParentExpDate.Name = "txtHodParentExpDate";
            this.txtHodParentExpDate.ReadOnly = true;
            this.txtHodParentExpDate.Size = new System.Drawing.Size(475, 25);
            this.txtHodParentExpDate.TabIndex = 7;
            // 
            // grpHodAction
            // 
            this.grpHodAction.Controls.Add(this.tlpHodActionControls);
            this.grpHodAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHodAction.Location = new System.Drawing.Point(3, 395);
            this.grpHodAction.Name = "grpHodAction";
            this.grpHodAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpHodAction.Size = new System.Drawing.Size(1281, 134);
            this.grpHodAction.TabIndex = 1;
            this.grpHodAction.TabStop = false;
            this.grpHodAction.Text = "HOD Action";
            // 
            // tlpHodActionControls
            // 
            this.tlpHodActionControls.ColumnCount = 1;
            this.tlpHodActionControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodActionControls.Controls.Add(this.lblHodComment, 0, 0);
            this.tlpHodActionControls.Controls.Add(this.txtHodComment, 0, 1);
            this.tlpHodActionControls.Controls.Add(this.flpHodActionButtons, 0, 2);
            this.tlpHodActionControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHodActionControls.Location = new System.Drawing.Point(10, 28);
            this.tlpHodActionControls.Name = "tlpHodActionControls";
            this.tlpHodActionControls.RowCount = 3;
            this.tlpHodActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHodActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHodActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpHodActionControls.Size = new System.Drawing.Size(1261, 96);
            this.tlpHodActionControls.TabIndex = 0;
            // 
            // lblHodComment
            // 
            this.lblHodComment.AutoSize = true;
            this.lblHodComment.Location = new System.Drawing.Point(3, 0);
            this.lblHodComment.Name = "lblHodComment";
            this.lblHodComment.Size = new System.Drawing.Size(102, 17);
            this.lblHodComment.TabIndex = 0;
            this.lblHodComment.Text = "HOD Comments:";
            // 
            // txtHodComment
            // 
            this.txtHodComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHodComment.Location = new System.Drawing.Point(3, 20);
            this.txtHodComment.Multiline = true;
            this.txtHodComment.Name = "txtHodComment";
            this.txtHodComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHodComment.Size = new System.Drawing.Size(1255, 28);
            this.txtHodComment.TabIndex = 1;
            // 
            // flpHodActionButtons
            // 
            this.flpHodActionButtons.Controls.Add(this.btnHodAuthorize);
            this.flpHodActionButtons.Controls.Add(this.btnHodReject);
            this.flpHodActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHodActionButtons.Location = new System.Drawing.Point(3, 54);
            this.flpHodActionButtons.Name = "flpHodActionButtons";
            this.flpHodActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpHodActionButtons.Size = new System.Drawing.Size(1255, 39);
            this.flpHodActionButtons.TabIndex = 2;
            // 
            // btnHodAuthorize
            // 
            this.btnHodAuthorize.CornerRadius = 8;
            this.btnHodAuthorize.FlatAppearance.BorderSize = 0;
            this.btnHodAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHodAuthorize.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHodAuthorize.Location = new System.Drawing.Point(3, 8);
            this.btnHodAuthorize.Name = "btnHodAuthorize";
            this.btnHodAuthorize.Size = new System.Drawing.Size(120, 30);
            this.btnHodAuthorize.TabIndex = 0;
            this.btnHodAuthorize.Text = "Authorize";
            this.btnHodAuthorize.UseVisualStyleBackColor = true;
            // 
            // btnHodReject
            // 
            this.btnHodReject.CornerRadius = 8;
            this.btnHodReject.FlatAppearance.BorderSize = 0;
            this.btnHodReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHodReject.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHodReject.Location = new System.Drawing.Point(129, 8);
            this.btnHodReject.Name = "btnHodReject";
            this.btnHodReject.Size = new System.Drawing.Size(120, 30);
            this.btnHodReject.TabIndex = 1;
            this.btnHodReject.Text = "Reject";
            this.btnHodReject.UseVisualStyleBackColor = true;
            // 
            // HodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpHodOperationsMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HodControl";
            this.Size = new System.Drawing.Size(1313, 706);
            this.tlpHodOperationsMain.ResumeLayout(false);
            this.tlpHodOperationsMain.PerformLayout();
            this.pnlHodTopSection.ResumeLayout(false);
            this.tlpHodTopControls.ResumeLayout(false);
            this.pnlHodQueueHeader.ResumeLayout(false);
            this.pnlHodQueueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHodQueue)).EndInit();
            this.tlpHodBottomSection.ResumeLayout(false);
            this.tlpHodBottomSection.PerformLayout();
            this.grpHodSelectedRequest.ResumeLayout(false);
            this.grpHodSelectedRequest.PerformLayout();
            this.tlpHodRequestDetails.ResumeLayout(false);
            this.tlpHodRequestDetails.PerformLayout();
            this.grpHodAction.ResumeLayout(false);
            this.tlpHodActionControls.ResumeLayout(false);
            this.tlpHodActionControls.PerformLayout();
            this.flpHodActionButtons.ResumeLayout(false);
            this.grpHodParentBatchInfo.ResumeLayout(false);
            this.grpHodParentBatchInfo.PerformLayout();
            this.tlpHodParentBatchInfo.ResumeLayout(false);
            this.tlpHodParentBatchInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHodOperationsMain;
        private System.Windows.Forms.Panel pnlHodTopSection;
        private System.Windows.Forms.TableLayoutPanel tlpHodTopControls;
        private System.Windows.Forms.Panel pnlHodQueueHeader;
        private System.Windows.Forms.Label lblHodQueueTitle;
        private UI.RoundedButton btnHodRefreshList;
        private System.Windows.Forms.DataGridView dgvHodQueue;
        private System.Windows.Forms.TableLayoutPanel tlpHodBottomSection;
        private System.Windows.Forms.GroupBox grpHodSelectedRequest;
        private System.Windows.Forms.TableLayoutPanel tlpHodRequestDetails;
        private System.Windows.Forms.Label lblHodDetailRequestNoLabel;
        private System.Windows.Forms.TextBox txtHodDetailRequestNo;
        private System.Windows.Forms.Label lblHodDetailRequestDateLabel;
        private System.Windows.Forms.TextBox txtHodDetailRequestDate;
        private System.Windows.Forms.Label lblHodDetailFromDeptLabel;
        private System.Windows.Forms.TextBox txtHodDetailFromDept;
        private System.Windows.Forms.Label lblHodDetailDocTypesLabel;
        private System.Windows.Forms.TextBox txtHodDetailDocTypes;
        private System.Windows.Forms.Label lblHodDetailProductLabel;
        private System.Windows.Forms.TextBox txtHodDetailProduct;
        private System.Windows.Forms.Label lblHodDetailBatchNoLabel;
        private System.Windows.Forms.TextBox txtHodDetailBatchNo;
        private System.Windows.Forms.Label lblHodDetailMfgDateLabel;
        private System.Windows.Forms.TextBox txtHodDetailMfgDate;
        private System.Windows.Forms.Label lblHodDetailExpDateLabel;
        private System.Windows.Forms.TextBox txtHodDetailExpDate;
        private System.Windows.Forms.Label lblHodDetailMarketLabel;
        private System.Windows.Forms.TextBox txtHodDetailMarket;
        private System.Windows.Forms.Label lblHodDetailPackSizeLabel;
        private System.Windows.Forms.TextBox txtHodDetailPackSize;
        private System.Windows.Forms.Label lblHodDetailPreparedByLabel;
        private System.Windows.Forms.TextBox txtHodDetailPreparedBy;
        private System.Windows.Forms.Label lblHodDetailRequestedAtLabel;
        private System.Windows.Forms.TextBox txtHodDetailRequestedAt;
        private System.Windows.Forms.Label lblHodDetailRequesterCommentsLabel;
        private System.Windows.Forms.TextBox txtHodDetailRequesterComments;
        private System.Windows.Forms.GroupBox grpHodAction;
        private System.Windows.Forms.TableLayoutPanel tlpHodActionControls;
        private System.Windows.Forms.Label lblHodComment;
        private System.Windows.Forms.TextBox txtHodComment;
        private System.Windows.Forms.FlowLayoutPanel flpHodActionButtons;
        private UI.RoundedButton btnHodAuthorize;
        private UI.RoundedButton btnHodReject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHodRequestedAt;
        // --- NEW CONTROL DECLARATIONS ---
        private System.Windows.Forms.GroupBox grpHodParentBatchInfo;
        private System.Windows.Forms.TableLayoutPanel tlpHodParentBatchInfo;
        private System.Windows.Forms.Label lblHodParentBatchNo;
        private System.Windows.Forms.TextBox txtHodParentBatchNo;
        private System.Windows.Forms.Label lblHodParentBatchSize;
        private System.Windows.Forms.TextBox txtHodParentBatchSize;
        private System.Windows.Forms.Label lblHodParentMfgDate;
        private System.Windows.Forms.TextBox txtHodParentMfgDate;
        private System.Windows.Forms.Label lblHodParentExpDate;
        private System.Windows.Forms.TextBox txtHodParentExpDate;
    }
}