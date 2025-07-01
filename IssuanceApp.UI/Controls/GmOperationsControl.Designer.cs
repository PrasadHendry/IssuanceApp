// GmOperationsControl.Designer.cs

namespace IssuanceApp.UI.Controls
{
    partial class GmOperationsControl
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
            this.tlpGmOperationsMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGmTopSection = new System.Windows.Forms.Panel();
            this.tlpGmTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGmQueueHeader = new System.Windows.Forms.Panel();
            this.lblGmQueueTitle = new System.Windows.Forms.Label();
            this.btnGmRefreshList = new IssuanceApp.UI.RoundedButton();
            this.dgvGmQueue = new System.Windows.Forms.DataGridView();
            this.colGmRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGmRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGmProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGmDocTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGmPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGmRequestedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpGmBottomSection = new System.Windows.Forms.TableLayoutPanel();
            this.grpGmSelectedRequest = new System.Windows.Forms.GroupBox();
            this.tlpGmRequestDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblGmDetailRequestNoLabel = new System.Windows.Forms.Label();
            this.txtGmDetailRequestNo = new System.Windows.Forms.TextBox();
            this.lblGmDetailRequestDateLabel = new System.Windows.Forms.Label();
            this.txtGmDetailRequestDate = new System.Windows.Forms.TextBox();
            this.lblGmDetailFromDeptLabel = new System.Windows.Forms.Label();
            this.txtGmDetailFromDept = new System.Windows.Forms.TextBox();
            this.lblGmDetailDocTypesLabel = new System.Windows.Forms.Label();
            this.txtGmDetailDocTypes = new System.Windows.Forms.TextBox();
            this.lblGmDetailProductLabel = new System.Windows.Forms.Label();
            this.txtGmDetailProduct = new System.Windows.Forms.TextBox();
            this.lblGmDetailBatchNoLabel = new System.Windows.Forms.Label();
            this.txtGmDetailBatchNo = new System.Windows.Forms.TextBox();
            this.lblGmDetailMfgDateLabel = new System.Windows.Forms.Label();
            this.txtGmDetailMfgDate = new System.Windows.Forms.TextBox();
            this.lblGmDetailExpDateLabel = new System.Windows.Forms.Label();
            this.txtGmDetailExpDate = new System.Windows.Forms.TextBox();
            this.lblGmDetailMarketLabel = new System.Windows.Forms.Label();
            this.txtGmDetailMarket = new System.Windows.Forms.TextBox();
            this.lblGmDetailPackSizeLabel = new System.Windows.Forms.Label();
            this.txtGmDetailPackSize = new System.Windows.Forms.TextBox();
            this.lblGmDetailPreparedByLabel = new System.Windows.Forms.Label();
            this.txtGmDetailPreparedBy = new System.Windows.Forms.TextBox();
            this.lblGmDetailRequestedAtLabel = new System.Windows.Forms.Label();
            this.txtGmDetailRequestedAt = new System.Windows.Forms.TextBox();
            this.lblGmDetailRequesterCommentsLabel = new System.Windows.Forms.Label();
            this.txtGmDetailRequesterComments = new System.Windows.Forms.TextBox();
            this.grpGmAction = new System.Windows.Forms.GroupBox();
            this.tlpGmActionControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblGmComment = new System.Windows.Forms.Label();
            this.txtGmComment = new System.Windows.Forms.TextBox();
            this.flpGmActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGmAuthorize = new IssuanceApp.UI.RoundedButton();
            this.btnGmReject = new IssuanceApp.UI.RoundedButton();
            this.tlpGmOperationsMain.SuspendLayout();
            this.pnlGmTopSection.SuspendLayout();
            this.tlpGmTopControls.SuspendLayout();
            this.pnlGmQueueHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGmQueue)).BeginInit();
            this.tlpGmBottomSection.SuspendLayout();
            this.grpGmSelectedRequest.SuspendLayout();
            this.tlpGmRequestDetails.SuspendLayout();
            this.grpGmAction.SuspendLayout();
            this.tlpGmActionControls.SuspendLayout();
            this.flpGmActionButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGmOperationsMain
            // 
            this.tlpGmOperationsMain.AutoScroll = true;
            this.tlpGmOperationsMain.ColumnCount = 1;
            this.tlpGmOperationsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmOperationsMain.Controls.Add(this.pnlGmTopSection, 0, 0);
            this.tlpGmOperationsMain.Controls.Add(this.tlpGmBottomSection, 0, 1);
            this.tlpGmOperationsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmOperationsMain.Location = new System.Drawing.Point(0, 0);
            this.tlpGmOperationsMain.Name = "tlpGmOperationsMain";
            this.tlpGmOperationsMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpGmOperationsMain.RowCount = 2;
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmOperationsMain.Size = new System.Drawing.Size(1313, 706);
            this.tlpGmOperationsMain.TabIndex = 1;
            // 
            // pnlGmTopSection
            // 
            this.pnlGmTopSection.Controls.Add(this.tlpGmTopControls);
            this.pnlGmTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGmTopSection.Location = new System.Drawing.Point(13, 13);
            this.pnlGmTopSection.Name = "pnlGmTopSection";
            this.pnlGmTopSection.Size = new System.Drawing.Size(1287, 244);
            this.pnlGmTopSection.TabIndex = 0;
            // 
            // tlpGmTopControls
            // 
            this.tlpGmTopControls.ColumnCount = 1;
            this.tlpGmTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmTopControls.Controls.Add(this.pnlGmQueueHeader, 0, 0);
            this.tlpGmTopControls.Controls.Add(this.dgvGmQueue, 0, 1);
            this.tlpGmTopControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmTopControls.Location = new System.Drawing.Point(0, 0);
            this.tlpGmTopControls.Name = "tlpGmTopControls";
            this.tlpGmTopControls.RowCount = 2;
            this.tlpGmTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGmTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmTopControls.Size = new System.Drawing.Size(1287, 244);
            this.tlpGmTopControls.TabIndex = 0;
            // 
            // pnlGmQueueHeader
            // 
            this.pnlGmQueueHeader.Controls.Add(this.lblGmQueueTitle);
            this.pnlGmQueueHeader.Controls.Add(this.btnGmRefreshList);
            this.pnlGmQueueHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGmQueueHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlGmQueueHeader.Name = "pnlGmQueueHeader";
            this.pnlGmQueueHeader.Size = new System.Drawing.Size(1281, 34);
            this.pnlGmQueueHeader.TabIndex = 0;
            // 
            // lblGmQueueTitle
            // 
            this.lblGmQueueTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGmQueueTitle.AutoSize = true;
            this.lblGmQueueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGmQueueTitle.Location = new System.Drawing.Point(5, 6);
            this.lblGmQueueTitle.Name = "lblGmQueueTitle";
            this.lblGmQueueTitle.Size = new System.Drawing.Size(232, 21);
            this.lblGmQueueTitle.TabIndex = 0;
            this.lblGmQueueTitle.Text = "Pending GM Approval Queue";
            // 
            // btnGmRefreshList
            // 
            this.btnGmRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGmRefreshList.CornerRadius = 8;
            this.btnGmRefreshList.FlatAppearance.BorderSize = 0;
            this.btnGmRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGmRefreshList.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGmRefreshList.Location = new System.Drawing.Point(1156, 2);
            this.btnGmRefreshList.Name = "btnGmRefreshList";
            this.btnGmRefreshList.Size = new System.Drawing.Size(120, 30);
            this.btnGmRefreshList.TabIndex = 1;
            this.btnGmRefreshList.Text = "Refresh List";
            this.btnGmRefreshList.UseVisualStyleBackColor = true;
            // 
            // dgvGmQueue
            // 
            this.dgvGmQueue.AllowUserToAddRows = false;
            this.dgvGmQueue.AllowUserToDeleteRows = false;
            this.dgvGmQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGmQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvGmQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGmQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGmRequestNo,
            this.colGmRequestDate,
            this.colGmProduct,
            this.colGmDocTypes,
            this.colGmPreparedBy,
            this.colGmRequestedAt});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGmQueue.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGmQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGmQueue.Location = new System.Drawing.Point(3, 43);
            this.dgvGmQueue.MultiSelect = false;
            this.dgvGmQueue.Name = "dgvGmQueue";
            this.dgvGmQueue.ReadOnly = true;
            this.dgvGmQueue.RowHeadersWidth = 51;
            this.dgvGmQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGmQueue.Size = new System.Drawing.Size(1281, 198);
            this.dgvGmQueue.TabIndex = 1;
            // 
            // colGmRequestNo
            // 
            this.colGmRequestNo.DataPropertyName = "RequestNo";
            this.colGmRequestNo.HeaderText = "Request No.";
            this.colGmRequestNo.MinimumWidth = 6;
            this.colGmRequestNo.Name = "colGmRequestNo";
            this.colGmRequestNo.ReadOnly = true;
            // 
            // colGmRequestDate
            // 
            this.colGmRequestDate.DataPropertyName = "RequestDate";
            this.colGmRequestDate.HeaderText = "Request Date";
            this.colGmRequestDate.MinimumWidth = 6;
            this.colGmRequestDate.Name = "colGmRequestDate";
            this.colGmRequestDate.ReadOnly = true;
            // 
            // colGmProduct
            // 
            this.colGmProduct.DataPropertyName = "Product";
            this.colGmProduct.HeaderText = "Product";
            this.colGmProduct.MinimumWidth = 6;
            this.colGmProduct.Name = "colGmProduct";
            this.colGmProduct.ReadOnly = true;
            // 
            // colGmDocTypes
            // 
            this.colGmDocTypes.DataPropertyName = "DocumentNo";
            this.colGmDocTypes.HeaderText = "Document No(s).";
            this.colGmDocTypes.MinimumWidth = 6;
            this.colGmDocTypes.Name = "colGmDocTypes";
            this.colGmDocTypes.ReadOnly = true;
            // 
            // colGmPreparedBy
            // 
            this.colGmPreparedBy.DataPropertyName = "PreparedBy";
            this.colGmPreparedBy.HeaderText = "Prepared By";
            this.colGmPreparedBy.MinimumWidth = 6;
            this.colGmPreparedBy.Name = "colGmPreparedBy";
            this.colGmPreparedBy.ReadOnly = true;
            // 
            // colGmRequestedAt
            // 
            this.colGmRequestedAt.DataPropertyName = "RequestedAt";
            this.colGmRequestedAt.HeaderText = "Requested At";
            this.colGmRequestedAt.MinimumWidth = 6;
            this.colGmRequestedAt.Name = "colGmRequestedAt";
            this.colGmRequestedAt.ReadOnly = true;
            // 
            // tlpGmBottomSection
            // 
            this.tlpGmBottomSection.AutoSize = true;
            this.tlpGmBottomSection.ColumnCount = 1;
            this.tlpGmBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmBottomSection.Controls.Add(this.grpGmSelectedRequest, 0, 0);
            this.tlpGmBottomSection.Controls.Add(this.grpGmAction, 0, 1);
            this.tlpGmBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmBottomSection.Location = new System.Drawing.Point(13, 263);
            this.tlpGmBottomSection.Name = "tlpGmBottomSection";
            this.tlpGmBottomSection.RowCount = 2;
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpGmBottomSection.Size = new System.Drawing.Size(1287, 430);
            this.tlpGmBottomSection.TabIndex = 1;
            // 
            // grpGmSelectedRequest
            // 
            this.grpGmSelectedRequest.AutoSize = true;
            this.grpGmSelectedRequest.Controls.Add(this.tlpGmRequestDetails);
            this.grpGmSelectedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGmSelectedRequest.Location = new System.Drawing.Point(3, 3);
            this.grpGmSelectedRequest.Name = "grpGmSelectedRequest";
            this.grpGmSelectedRequest.Padding = new System.Windows.Forms.Padding(10);
            this.grpGmSelectedRequest.Size = new System.Drawing.Size(1281, 284);
            this.grpGmSelectedRequest.TabIndex = 0;
            this.grpGmSelectedRequest.TabStop = false;
            this.grpGmSelectedRequest.Text = "Selected Request Details";
            // 
            // tlpGmRequestDetails
            // 
            this.tlpGmRequestDetails.AutoScroll = true;
            this.tlpGmRequestDetails.AutoSize = true;
            this.tlpGmRequestDetails.ColumnCount = 4;
            this.tlpGmRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpGmRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGmRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpGmRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailRequestNoLabel, 0, 0);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailRequestNo, 1, 0);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailRequestDateLabel, 2, 0);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailRequestDate, 3, 0);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailFromDeptLabel, 0, 1);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailFromDept, 1, 1);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailDocTypesLabel, 2, 1);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailDocTypes, 3, 1);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailProductLabel, 0, 2);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailProduct, 1, 2);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailBatchNoLabel, 2, 2);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailBatchNo, 3, 2);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailMfgDateLabel, 0, 3);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailMfgDate, 1, 3);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailExpDateLabel, 2, 3);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailExpDate, 3, 3);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailMarketLabel, 0, 4);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailMarket, 1, 4);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailPackSizeLabel, 2, 4);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailPackSize, 3, 4);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailPreparedByLabel, 0, 5);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailPreparedBy, 1, 5);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailRequestedAtLabel, 2, 5);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailRequestedAt, 3, 5);
            this.tlpGmRequestDetails.Controls.Add(this.lblGmDetailRequesterCommentsLabel, 0, 6);
            this.tlpGmRequestDetails.Controls.Add(this.txtGmDetailRequesterComments, 1, 6);
            this.tlpGmRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmRequestDetails.Location = new System.Drawing.Point(10, 28);
            this.tlpGmRequestDetails.Name = "tlpGmRequestDetails";
            this.tlpGmRequestDetails.RowCount = 7;
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpGmRequestDetails.Size = new System.Drawing.Size(1261, 246);
            this.tlpGmRequestDetails.TabIndex = 0;
            // 
            // lblGmDetailRequestNoLabel
            // 
            this.lblGmDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestNoLabel.AutoSize = true;
            this.lblGmDetailRequestNoLabel.Location = new System.Drawing.Point(62, 7);
            this.lblGmDetailRequestNoLabel.Name = "lblGmDetailRequestNoLabel";
            this.lblGmDetailRequestNoLabel.Size = new System.Drawing.Size(85, 17);
            this.lblGmDetailRequestNoLabel.TabIndex = 0;
            this.lblGmDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtGmDetailRequestNo
            // 
            this.txtGmDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestNo.Location = new System.Drawing.Point(153, 3);
            this.txtGmDetailRequestNo.Name = "txtGmDetailRequestNo";
            this.txtGmDetailRequestNo.ReadOnly = true;
            this.txtGmDetailRequestNo.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailRequestNo.TabIndex = 1;
            // 
            // lblGmDetailRequestDateLabel
            // 
            this.lblGmDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestDateLabel.AutoSize = true;
            this.lblGmDetailRequestDateLabel.Location = new System.Drawing.Point(685, 7);
            this.lblGmDetailRequestDateLabel.Name = "lblGmDetailRequestDateLabel";
            this.lblGmDetailRequestDateLabel.Size = new System.Drawing.Size(92, 17);
            this.lblGmDetailRequestDateLabel.TabIndex = 2;
            this.lblGmDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtGmDetailRequestDate
            // 
            this.txtGmDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestDate.Location = new System.Drawing.Point(783, 3);
            this.txtGmDetailRequestDate.Name = "txtGmDetailRequestDate";
            this.txtGmDetailRequestDate.ReadOnly = true;
            this.txtGmDetailRequestDate.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailRequestDate.TabIndex = 3;
            // 
            // lblGmDetailFromDeptLabel
            // 
            this.lblGmDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailFromDeptLabel.AutoSize = true;
            this.lblGmDetailFromDeptLabel.Location = new System.Drawing.Point(27, 38);
            this.lblGmDetailFromDeptLabel.Name = "lblGmDetailFromDeptLabel";
            this.lblGmDetailFromDeptLabel.Size = new System.Drawing.Size(120, 17);
            this.lblGmDetailFromDeptLabel.TabIndex = 4;
            this.lblGmDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtGmDetailFromDept
            // 
            this.txtGmDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailFromDept.Location = new System.Drawing.Point(153, 34);
            this.txtGmDetailFromDept.Name = "txtGmDetailFromDept";
            this.txtGmDetailFromDept.ReadOnly = true;
            this.txtGmDetailFromDept.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailFromDept.TabIndex = 5;
            // 
            // lblGmDetailDocTypesLabel
            // 
            this.lblGmDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailDocTypesLabel.AutoSize = true;
            this.lblGmDetailDocTypesLabel.Location = new System.Drawing.Point(665, 38);
            this.lblGmDetailDocTypesLabel.Name = "lblGmDetailDocTypesLabel";
            this.lblGmDetailDocTypesLabel.Size = new System.Drawing.Size(112, 17);
            this.lblGmDetailDocTypesLabel.TabIndex = 6;
            this.lblGmDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtGmDetailDocTypes
            // 
            this.txtGmDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailDocTypes.Location = new System.Drawing.Point(783, 34);
            this.txtGmDetailDocTypes.Name = "txtGmDetailDocTypes";
            this.txtGmDetailDocTypes.ReadOnly = true;
            this.txtGmDetailDocTypes.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailDocTypes.TabIndex = 7;
            // 
            // lblGmDetailProductLabel
            // 
            this.lblGmDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailProductLabel.AutoSize = true;
            this.lblGmDetailProductLabel.Location = new System.Drawing.Point(88, 69);
            this.lblGmDetailProductLabel.Name = "lblGmDetailProductLabel";
            this.lblGmDetailProductLabel.Size = new System.Drawing.Size(59, 17);
            this.lblGmDetailProductLabel.TabIndex = 8;
            this.lblGmDetailProductLabel.Text = "Product:";
            // 
            // txtGmDetailProduct
            // 
            this.txtGmDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailProduct.Location = new System.Drawing.Point(153, 65);
            this.txtGmDetailProduct.Name = "txtGmDetailProduct";
            this.txtGmDetailProduct.ReadOnly = true;
            this.txtGmDetailProduct.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailProduct.TabIndex = 9;
            // 
            // lblGmDetailBatchNoLabel
            // 
            this.lblGmDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailBatchNoLabel.AutoSize = true;
            this.lblGmDetailBatchNoLabel.Location = new System.Drawing.Point(707, 69);
            this.lblGmDetailBatchNoLabel.Name = "lblGmDetailBatchNoLabel";
            this.lblGmDetailBatchNoLabel.Size = new System.Drawing.Size(70, 17);
            this.lblGmDetailBatchNoLabel.TabIndex = 10;
            this.lblGmDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtGmDetailBatchNo
            // 
            this.txtGmDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailBatchNo.Location = new System.Drawing.Point(783, 65);
            this.txtGmDetailBatchNo.Name = "txtGmDetailBatchNo";
            this.txtGmDetailBatchNo.ReadOnly = true;
            this.txtGmDetailBatchNo.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailBatchNo.TabIndex = 11;
            // 
            // lblGmDetailMfgDateLabel
            // 
            this.lblGmDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMfgDateLabel.AutoSize = true;
            this.lblGmDetailMfgDateLabel.Location = new System.Drawing.Point(80, 100);
            this.lblGmDetailMfgDateLabel.Name = "lblGmDetailMfgDateLabel";
            this.lblGmDetailMfgDateLabel.Size = new System.Drawing.Size(67, 17);
            this.lblGmDetailMfgDateLabel.TabIndex = 12;
            this.lblGmDetailMfgDateLabel.Text = "Mfg Date:";
            // 
            // txtGmDetailMfgDate
            // 
            this.txtGmDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMfgDate.Location = new System.Drawing.Point(153, 96);
            this.txtGmDetailMfgDate.Name = "txtGmDetailMfgDate";
            this.txtGmDetailMfgDate.ReadOnly = true;
            this.txtGmDetailMfgDate.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailMfgDate.TabIndex = 13;
            // 
            // lblGmDetailExpDateLabel
            // 
            this.lblGmDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailExpDateLabel.AutoSize = true;
            this.lblGmDetailExpDateLabel.Location = new System.Drawing.Point(709, 100);
            this.lblGmDetailExpDateLabel.Name = "lblGmDetailExpDateLabel";
            this.lblGmDetailExpDateLabel.Size = new System.Drawing.Size(68, 17);
            this.lblGmDetailExpDateLabel.TabIndex = 14;
            this.lblGmDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtGmDetailExpDate
            // 
            this.txtGmDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailExpDate.Location = new System.Drawing.Point(783, 96);
            this.txtGmDetailExpDate.Name = "txtGmDetailExpDate";
            this.txtGmDetailExpDate.ReadOnly = true;
            this.txtGmDetailExpDate.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailExpDate.TabIndex = 15;
            // 
            // lblGmDetailMarketLabel
            // 
            this.lblGmDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMarketLabel.AutoSize = true;
            this.lblGmDetailMarketLabel.Location = new System.Drawing.Point(93, 131);
            this.lblGmDetailMarketLabel.Name = "lblGmDetailMarketLabel";
            this.lblGmDetailMarketLabel.Size = new System.Drawing.Size(54, 17);
            this.lblGmDetailMarketLabel.TabIndex = 16;
            this.lblGmDetailMarketLabel.Text = "Market:";
            // 
            // txtGmDetailMarket
            // 
            this.txtGmDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMarket.Location = new System.Drawing.Point(153, 127);
            this.txtGmDetailMarket.Name = "txtGmDetailMarket";
            this.txtGmDetailMarket.ReadOnly = true;
            this.txtGmDetailMarket.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailMarket.TabIndex = 17;
            // 
            // lblGmDetailPackSizeLabel
            // 
            this.lblGmDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPackSizeLabel.AutoSize = true;
            this.lblGmDetailPackSizeLabel.Location = new System.Drawing.Point(711, 131);
            this.lblGmDetailPackSizeLabel.Name = "lblGmDetailPackSizeLabel";
            this.lblGmDetailPackSizeLabel.Size = new System.Drawing.Size(66, 17);
            this.lblGmDetailPackSizeLabel.TabIndex = 18;
            this.lblGmDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtGmDetailPackSize
            // 
            this.txtGmDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPackSize.Location = new System.Drawing.Point(783, 127);
            this.txtGmDetailPackSize.Name = "txtGmDetailPackSize";
            this.txtGmDetailPackSize.ReadOnly = true;
            this.txtGmDetailPackSize.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailPackSize.TabIndex = 19;
            // 
            // lblGmDetailPreparedByLabel
            // 
            this.lblGmDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPreparedByLabel.AutoSize = true;
            this.lblGmDetailPreparedByLabel.Location = new System.Drawing.Point(62, 162);
            this.lblGmDetailPreparedByLabel.Name = "lblGmDetailPreparedByLabel";
            this.lblGmDetailPreparedByLabel.Size = new System.Drawing.Size(85, 17);
            this.lblGmDetailPreparedByLabel.TabIndex = 20;
            this.lblGmDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtGmDetailPreparedBy
            // 
            this.txtGmDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPreparedBy.Location = new System.Drawing.Point(153, 158);
            this.txtGmDetailPreparedBy.Name = "txtGmDetailPreparedBy";
            this.txtGmDetailPreparedBy.ReadOnly = true;
            this.txtGmDetailPreparedBy.Size = new System.Drawing.Size(474, 25);
            this.txtGmDetailPreparedBy.TabIndex = 21;
            // 
            // lblGmDetailRequestedAtLabel
            // 
            this.lblGmDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestedAtLabel.AutoSize = true;
            this.lblGmDetailRequestedAtLabel.Location = new System.Drawing.Point(684, 162);
            this.lblGmDetailRequestedAtLabel.Name = "lblGmDetailRequestedAtLabel";
            this.lblGmDetailRequestedAtLabel.Size = new System.Drawing.Size(93, 17);
            this.lblGmDetailRequestedAtLabel.TabIndex = 22;
            this.lblGmDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtGmDetailRequestedAt
            // 
            this.txtGmDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestedAt.Location = new System.Drawing.Point(783, 158);
            this.txtGmDetailRequestedAt.Name = "txtGmDetailRequestedAt";
            this.txtGmDetailRequestedAt.ReadOnly = true;
            this.txtGmDetailRequestedAt.Size = new System.Drawing.Size(475, 25);
            this.txtGmDetailRequestedAt.TabIndex = 23;
            // 
            // lblGmDetailRequesterCommentsLabel
            // 
            this.lblGmDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGmDetailRequesterCommentsLabel.AutoSize = true;
            this.lblGmDetailRequesterCommentsLabel.Location = new System.Drawing.Point(5, 196);
            this.lblGmDetailRequesterCommentsLabel.Name = "lblGmDetailRequesterCommentsLabel";
            this.lblGmDetailRequesterCommentsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblGmDetailRequesterCommentsLabel.Size = new System.Drawing.Size(142, 22);
            this.lblGmDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblGmDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtGmDetailRequesterComments
            // 
            this.tlpGmRequestDetails.SetColumnSpan(this.txtGmDetailRequesterComments, 3);
            this.txtGmDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmDetailRequesterComments.Location = new System.Drawing.Point(153, 199);
            this.txtGmDetailRequesterComments.Multiline = true;
            this.txtGmDetailRequesterComments.Name = "txtGmDetailRequesterComments";
            this.txtGmDetailRequesterComments.ReadOnly = true;
            this.txtGmDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmDetailRequesterComments.Size = new System.Drawing.Size(1105, 44);
            this.txtGmDetailRequesterComments.TabIndex = 25;
            // 
            // grpGmAction
            // 
            this.grpGmAction.Controls.Add(this.tlpGmActionControls);
            this.grpGmAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGmAction.Location = new System.Drawing.Point(3, 293);
            this.grpGmAction.Name = "grpGmAction";
            this.grpGmAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpGmAction.Size = new System.Drawing.Size(1281, 134);
            this.grpGmAction.TabIndex = 1;
            this.grpGmAction.TabStop = false;
            this.grpGmAction.Text = "GM Action";
            // 
            // tlpGmActionControls
            // 
            this.tlpGmActionControls.ColumnCount = 1;
            this.tlpGmActionControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmActionControls.Controls.Add(this.lblGmComment, 0, 0);
            this.tlpGmActionControls.Controls.Add(this.txtGmComment, 0, 1);
            this.tlpGmActionControls.Controls.Add(this.flpGmActionButtons, 0, 2);
            this.tlpGmActionControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmActionControls.Location = new System.Drawing.Point(10, 28);
            this.tlpGmActionControls.Name = "tlpGmActionControls";
            this.tlpGmActionControls.RowCount = 3;
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpGmActionControls.Size = new System.Drawing.Size(1261, 96);
            this.tlpGmActionControls.TabIndex = 0;
            // 
            // lblGmComment
            // 
            this.lblGmComment.AutoSize = true;
            this.lblGmComment.Location = new System.Drawing.Point(3, 0);
            this.lblGmComment.Name = "lblGmComment";
            this.lblGmComment.Size = new System.Drawing.Size(102, 17);
            this.lblGmComment.TabIndex = 0;
            this.lblGmComment.Text = "GM Comments:";
            // 
            // txtGmComment
            // 
            this.txtGmComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmComment.Location = new System.Drawing.Point(3, 20);
            this.txtGmComment.Multiline = true;
            this.txtGmComment.Name = "txtGmComment";
            this.txtGmComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmComment.Size = new System.Drawing.Size(1255, 28);
            this.txtGmComment.TabIndex = 1;
            // 
            // flpGmActionButtons
            // 
            this.flpGmActionButtons.Controls.Add(this.btnGmAuthorize);
            this.flpGmActionButtons.Controls.Add(this.btnGmReject);
            this.flpGmActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGmActionButtons.Location = new System.Drawing.Point(3, 54);
            this.flpGmActionButtons.Name = "flpGmActionButtons";
            this.flpGmActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpGmActionButtons.Size = new System.Drawing.Size(1255, 39);
            this.flpGmActionButtons.TabIndex = 2;
            // 
            // btnGmAuthorize
            // 
            this.btnGmAuthorize.CornerRadius = 8;
            this.btnGmAuthorize.FlatAppearance.BorderSize = 0;
            this.btnGmAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGmAuthorize.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGmAuthorize.Location = new System.Drawing.Point(3, 8);
            this.btnGmAuthorize.Name = "btnGmAuthorize";
            this.btnGmAuthorize.Size = new System.Drawing.Size(120, 30);
            this.btnGmAuthorize.TabIndex = 0;
            this.btnGmAuthorize.Text = "Authorize";
            this.btnGmAuthorize.UseVisualStyleBackColor = true;
            // 
            // btnGmReject
            // 
            this.btnGmReject.CornerRadius = 8;
            this.btnGmReject.FlatAppearance.BorderSize = 0;
            this.btnGmReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGmReject.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGmReject.Location = new System.Drawing.Point(129, 8);
            this.btnGmReject.Name = "btnGmReject";
            this.btnGmReject.Size = new System.Drawing.Size(120, 30);
            this.btnGmReject.TabIndex = 1;
            this.btnGmReject.Text = "Reject";
            this.btnGmReject.UseVisualStyleBackColor = true;
            // 
            // GmOperationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpGmOperationsMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GmOperationsControl";
            this.Size = new System.Drawing.Size(1313, 706);
            this.tlpGmOperationsMain.ResumeLayout(false);
            this.tlpGmOperationsMain.PerformLayout();
            this.pnlGmTopSection.ResumeLayout(false);
            this.tlpGmTopControls.ResumeLayout(false);
            this.pnlGmQueueHeader.ResumeLayout(false);
            this.pnlGmQueueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGmQueue)).EndInit();
            this.tlpGmBottomSection.ResumeLayout(false);
            this.tlpGmBottomSection.PerformLayout();
            this.grpGmSelectedRequest.ResumeLayout(false);
            this.grpGmSelectedRequest.PerformLayout();
            this.tlpGmRequestDetails.ResumeLayout(false);
            this.tlpGmRequestDetails.PerformLayout();
            this.grpGmAction.ResumeLayout(false);
            this.tlpGmActionControls.ResumeLayout(false);
            this.tlpGmActionControls.PerformLayout();
            this.flpGmActionButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGmOperationsMain;
        private System.Windows.Forms.Panel pnlGmTopSection;
        private System.Windows.Forms.TableLayoutPanel tlpGmTopControls;
        private System.Windows.Forms.Panel pnlGmQueueHeader;
        private System.Windows.Forms.Label lblGmQueueTitle;
        private UI.RoundedButton btnGmRefreshList;
        private System.Windows.Forms.DataGridView dgvGmQueue;
        private System.Windows.Forms.TableLayoutPanel tlpGmBottomSection;
        private System.Windows.Forms.GroupBox grpGmSelectedRequest;
        private System.Windows.Forms.TableLayoutPanel tlpGmRequestDetails;
        private System.Windows.Forms.Label lblGmDetailRequestNoLabel;
        private System.Windows.Forms.TextBox txtGmDetailRequestNo;
        private System.Windows.Forms.Label lblGmDetailRequestDateLabel;
        private System.Windows.Forms.TextBox txtGmDetailRequestDate;
        private System.Windows.Forms.Label lblGmDetailFromDeptLabel;
        private System.Windows.Forms.TextBox txtGmDetailFromDept;
        private System.Windows.Forms.Label lblGmDetailDocTypesLabel;
        private System.Windows.Forms.TextBox txtGmDetailDocTypes;
        private System.Windows.Forms.Label lblGmDetailProductLabel;
        private System.Windows.Forms.TextBox txtGmDetailProduct;
        private System.Windows.Forms.Label lblGmDetailBatchNoLabel;
        private System.Windows.Forms.TextBox txtGmDetailBatchNo;
        private System.Windows.Forms.Label lblGmDetailMfgDateLabel;
        private System.Windows.Forms.TextBox txtGmDetailMfgDate;
        private System.Windows.Forms.Label lblGmDetailExpDateLabel;
        private System.Windows.Forms.TextBox txtGmDetailExpDate;
        private System.Windows.Forms.Label lblGmDetailMarketLabel;
        private System.Windows.Forms.TextBox txtGmDetailMarket;
        private System.Windows.Forms.Label lblGmDetailPackSizeLabel;
        private System.Windows.Forms.TextBox txtGmDetailPackSize;
        private System.Windows.Forms.Label lblGmDetailPreparedByLabel;
        private System.Windows.Forms.TextBox txtGmDetailPreparedBy;
        private System.Windows.Forms.Label lblGmDetailRequestedAtLabel;
        private System.Windows.Forms.TextBox txtGmDetailRequestedAt;
        private System.Windows.Forms.Label lblGmDetailRequesterCommentsLabel;
        private System.Windows.Forms.TextBox txtGmDetailRequesterComments;
        private System.Windows.Forms.GroupBox grpGmAction;
        private System.Windows.Forms.TableLayoutPanel tlpGmActionControls;
        private System.Windows.Forms.Label lblGmComment;
        private System.Windows.Forms.TextBox txtGmComment;
        private System.Windows.Forms.FlowLayoutPanel flpGmActionButtons;
        private UI.RoundedButton btnGmAuthorize;
        private UI.RoundedButton btnGmReject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestedAt;
    }
}