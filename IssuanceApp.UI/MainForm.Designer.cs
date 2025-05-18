// MainForm.Designer.cs
// This code is typically auto-generated and managed by the Visual Studio WinForms Designer.
using System.Drawing;
using System.Windows.Forms;

namespace DocumentIssuanceApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.panelLoginContainer = new System.Windows.Forms.Panel();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.tabPageDocumentIssuance = new System.Windows.Forms.TabPage();
            this.tlpDocumentIssuanceMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderDI = new System.Windows.Forms.Label();
            this.tlpTopSectionDI = new System.Windows.Forms.TableLayoutPanel();
            this.grpDocTypeDI = new System.Windows.Forms.GroupBox();
            this.chkDocTypeAddendumDI = new System.Windows.Forms.CheckBox();
            this.chkDocTypeAppendixDI = new System.Windows.Forms.CheckBox();
            this.chkDocTypeBPRDI = new System.Windows.Forms.CheckBox();
            this.chkDocTypeBMRDI = new System.Windows.Forms.CheckBox();
            this.pnlTopRightDI = new System.Windows.Forms.Panel();
            this.txtRequestNoValueDI = new System.Windows.Forms.TextBox();
            this.lblRequestNoLabelDI = new System.Windows.Forms.Label();
            this.lblTrackerNoValueDI = new System.Windows.Forms.Label();
            this.lblTrackerNoLabelDI = new System.Windows.Forms.Label();
            this.pnlRequestDetailsDI = new System.Windows.Forms.Panel();
            this.tlpRequestDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblRequestDateDI = new System.Windows.Forms.Label();
            this.dtpRequestDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblFromDepartmentDI = new System.Windows.Forms.Label();
            this.cmbFromDepartmentDI = new System.Windows.Forms.ComboBox();
            this.grpParentBatchInfoDI = new System.Windows.Forms.GroupBox();
            this.tlpParentBatchInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblParentBatchNoDI = new System.Windows.Forms.Label();
            this.txtParentBatchNoDI = new System.Windows.Forms.TextBox();
            this.lblParentBatchSizeDI = new System.Windows.Forms.Label();
            this.numParentBatchSizeDI = new System.Windows.Forms.NumericUpDown();
            this.lblParentMfgDateDI = new System.Windows.Forms.Label();
            this.dtpParentMfgDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblParentExpDateDI = new System.Windows.Forms.Label();
            this.dtpParentExpDateDI = new System.Windows.Forms.DateTimePicker();
            this.grpItemDetailsDI = new System.Windows.Forms.GroupBox();
            this.tlpItemDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductDI = new System.Windows.Forms.Label();
            this.txtProductDI = new System.Windows.Forms.TextBox();
            this.lblDocumentNoDI = new System.Windows.Forms.Label();
            this.txtDocumentNoDI = new System.Windows.Forms.TextBox();
            this.lblBatchNoDI = new System.Windows.Forms.Label();
            this.txtBatchNoDI = new System.Windows.Forms.TextBox();
            this.lblBatchSizeDI = new System.Windows.Forms.Label();
            this.txtBatchSizeDI = new System.Windows.Forms.TextBox();
            this.lblItemMfgDateDI = new System.Windows.Forms.Label();
            this.dtpItemMfgDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblItemExpDateDI = new System.Windows.Forms.Label();
            this.dtpItemExpDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblMarketDI = new System.Windows.Forms.Label();
            this.txtMarketDI = new System.Windows.Forms.TextBox();
            this.lblPackSizeDI = new System.Windows.Forms.Label();
            this.txtPackSizeDI = new System.Windows.Forms.TextBox();
            this.lblExportOrderNoDI = new System.Windows.Forms.Label();
            this.txtExportOrderNoDI = new System.Windows.Forms.TextBox();
            this.grpRemarksDI = new System.Windows.Forms.GroupBox();
            this.txtRemarksDI = new System.Windows.Forms.TextBox();
            this.pnlActionBottomDI = new System.Windows.Forms.Panel();
            this.btnClearFormDI = new System.Windows.Forms.Button();
            this.btnSubmitRequestDI = new System.Windows.Forms.Button();
            this.pnlStatusDI = new System.Windows.Forms.Panel();
            this.lblStatusValueDI = new System.Windows.Forms.Label();
            this.lblStatusLabelDI = new System.Windows.Forms.Label();
            this.tabPageGmOperations = new System.Windows.Forms.TabPage();
            this.tlpGmOperationsMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGmTopSection = new System.Windows.Forms.Panel();
            this.tlpGmTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGmQueueHeader = new System.Windows.Forms.Panel();
            this.lblGmQueueTitle = new System.Windows.Forms.Label();
            this.btnGmRefreshList = new System.Windows.Forms.Button();
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
            this.btnGmAuthorize = new System.Windows.Forms.Button();
            this.btnGmReject = new System.Windows.Forms.Button();
            this.tabPageQa = new System.Windows.Forms.TabPage();
            this.tlpQaOperationsMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQaTopSection = new System.Windows.Forms.Panel();
            this.tlpQaTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQaQueueHeader = new System.Windows.Forms.Panel();
            this.lblQaQueueTitle = new System.Windows.Forms.Label();
            this.btnQaRefreshList = new System.Windows.Forms.Button();
            this.dgvQaQueue = new System.Windows.Forms.DataGridView();
            this.colQaRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaDocTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaAuthorizedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaGmActionAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblQaDetailGmCommentLabel = new System.Windows.Forms.Label();
            this.txtQaDetailGmComment = new System.Windows.Forms.TextBox();
            this.lblQaDetailGmActionTimeLabel = new System.Windows.Forms.Label();
            this.txtQaDetailGmActionTime = new System.Windows.Forms.TextBox();
            this.grpQaAction = new System.Windows.Forms.GroupBox();
            this.tlpQaActionControls = new System.Windows.Forms.TableLayoutPanel();
            this.flpQaOptionalControls = new System.Windows.Forms.FlowLayoutPanel();
            this.lblQaPrintCount = new System.Windows.Forms.Label();
            this.numQaPrintCount = new System.Windows.Forms.NumericUpDown();
            this.btnQaBrowseSelectDocument = new System.Windows.Forms.Button();
            this.lblQaComment = new System.Windows.Forms.Label();
            this.txtQaComment = new System.Windows.Forms.TextBox();
            this.flpQaActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQaApprove = new System.Windows.Forms.Button();
            this.btnQaReject = new System.Windows.Forms.Button();
            this.tabPageAuditTrail = new System.Windows.Forms.TabPage();
            this.tlpAuditTrailMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpAuditFilters = new System.Windows.Forms.GroupBox();
            this.tlpAuditFilters = new System.Windows.Forms.TableLayoutPanel();
            this.lblAuditFromDate = new System.Windows.Forms.Label();
            this.dtpAuditFrom = new System.Windows.Forms.DateTimePicker();
            this.lblAuditToDate = new System.Windows.Forms.Label();
            this.dtpAuditTo = new System.Windows.Forms.DateTimePicker();
            this.lblAuditStatus = new System.Windows.Forms.Label();
            this.cmbAuditStatus = new System.Windows.Forms.ComboBox();
            this.lblAuditRequestNo = new System.Windows.Forms.Label();
            this.txtAuditRequestNo = new System.Windows.Forms.TextBox();
            this.lblAuditProduct = new System.Windows.Forms.Label();
            this.txtAuditProduct = new System.Windows.Forms.TextBox();
            this.btnApplyAuditFilter = new System.Windows.Forms.Button();
            this.btnClearAuditFilters = new System.Windows.Forms.Button();
            this.btnRefreshAuditList = new System.Windows.Forms.Button();
            this.dgvAuditTrail = new System.Windows.Forms.DataGridView();
            this.flpAuditExportButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.panelLoginContainer.SuspendLayout();
            this.tabPageDocumentIssuance.SuspendLayout();
            this.tlpDocumentIssuanceMain.SuspendLayout();
            this.tlpTopSectionDI.SuspendLayout();
            this.grpDocTypeDI.SuspendLayout();
            this.pnlTopRightDI.SuspendLayout();
            this.pnlRequestDetailsDI.SuspendLayout();
            this.tlpRequestDetails.SuspendLayout();
            this.grpParentBatchInfoDI.SuspendLayout();
            this.tlpParentBatchInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParentBatchSizeDI)).BeginInit();
            this.grpItemDetailsDI.SuspendLayout();
            this.tlpItemDetails.SuspendLayout();
            this.grpRemarksDI.SuspendLayout();
            this.pnlActionBottomDI.SuspendLayout();
            this.pnlStatusDI.SuspendLayout();
            this.tabPageGmOperations.SuspendLayout();
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
            this.tabPageQa.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.numQaPrintCount)).BeginInit();
            this.flpQaActionButtons.SuspendLayout();
            this.tabPageAuditTrail.SuspendLayout();
            this.tlpAuditTrailMain.SuspendLayout();
            this.grpAuditFilters.SuspendLayout();
            this.tlpAuditFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).BeginInit();
            this.flpAuditExportButtons.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLogin);
            this.tabControlMain.Controls.Add(this.tabPageDocumentIssuance);
            this.tabControlMain.Controls.Add(this.tabPageGmOperations);
            this.tabControlMain.Controls.Add(this.tabPageQa);
            this.tabControlMain.Controls.Add(this.tabPageAuditTrail);
            this.tabControlMain.Controls.Add(this.tabPageUsers);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1368, 686);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.panelLoginContainer);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 30);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1360, 652);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // panelLoginContainer
            // 
            this.panelLoginContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLoginContainer.Controls.Add(this.lblLoginStatus);
            this.panelLoginContainer.Controls.Add(this.btnLogin);
            this.panelLoginContainer.Controls.Add(this.txtPassword);
            this.panelLoginContainer.Controls.Add(this.lblPassword);
            this.panelLoginContainer.Controls.Add(this.cmbRole);
            this.panelLoginContainer.Controls.Add(this.lblRole);
            this.panelLoginContainer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.panelLoginContainer.Location = new System.Drawing.Point(365, 212);
            this.panelLoginContainer.Name = "panelLoginContainer";
            this.panelLoginContainer.Size = new System.Drawing.Size(629, 228);
            this.panelLoginContainer.TabIndex = 0;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblLoginStatus.Location = new System.Drawing.Point(227, 179);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(207, 23);
            this.lblLoginStatus.TabIndex = 5;
            this.lblLoginStatus.Text = "*Please login to continue.";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(230, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.Location = new System.Drawing.Point(230, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(230, 34);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(122, 92);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 25);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(230, 46);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(230, 36);
            this.cmbRole.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(111, 52);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(113, 25);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Select Role:";
            // 
            // tabPageDocumentIssuance
            // 
            this.tabPageDocumentIssuance.Controls.Add(this.tlpDocumentIssuanceMain);
            this.tabPageDocumentIssuance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabPageDocumentIssuance.Location = new System.Drawing.Point(4, 30);
            this.tabPageDocumentIssuance.Name = "tabPageDocumentIssuance";
            this.tabPageDocumentIssuance.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageDocumentIssuance.Size = new System.Drawing.Size(1360, 652);
            this.tabPageDocumentIssuance.TabIndex = 1;
            this.tabPageDocumentIssuance.Text = "Document Issuance";
            this.tabPageDocumentIssuance.UseVisualStyleBackColor = true;
            // 
            // tlpDocumentIssuanceMain
            // 
            this.tlpDocumentIssuanceMain.ColumnCount = 1;
            this.tlpDocumentIssuanceMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDocumentIssuanceMain.Controls.Add(this.lblHeaderDI, 0, 0);
            this.tlpDocumentIssuanceMain.Controls.Add(this.tlpTopSectionDI, 0, 1);
            this.tlpDocumentIssuanceMain.Controls.Add(this.pnlRequestDetailsDI, 0, 2);
            this.tlpDocumentIssuanceMain.Controls.Add(this.grpParentBatchInfoDI, 0, 3);
            this.tlpDocumentIssuanceMain.Controls.Add(this.grpItemDetailsDI, 0, 4);
            this.tlpDocumentIssuanceMain.Controls.Add(this.grpRemarksDI, 0, 5);
            this.tlpDocumentIssuanceMain.Controls.Add(this.pnlActionBottomDI, 0, 6);
            this.tlpDocumentIssuanceMain.Controls.Add(this.pnlStatusDI, 0, 7);
            this.tlpDocumentIssuanceMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDocumentIssuanceMain.Location = new System.Drawing.Point(10, 10);
            this.tlpDocumentIssuanceMain.Name = "tlpDocumentIssuanceMain";
            this.tlpDocumentIssuanceMain.RowCount = 8;
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpDocumentIssuanceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDocumentIssuanceMain.Size = new System.Drawing.Size(1340, 632);
            this.tlpDocumentIssuanceMain.TabIndex = 0;
            // 
            // lblHeaderDI
            // 
            this.lblHeaderDI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeaderDI.AutoSize = true;
            this.lblHeaderDI.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeaderDI.Location = new System.Drawing.Point(516, 1);
            this.lblHeaderDI.Name = "lblHeaderDI";
            this.lblHeaderDI.Size = new System.Drawing.Size(307, 37);
            this.lblHeaderDI.TabIndex = 0;
            this.lblHeaderDI.Text = "DOCUMENT ISSUANCE";
            // 
            // tlpTopSectionDI
            // 
            this.tlpTopSectionDI.AutoSize = true;
            this.tlpTopSectionDI.ColumnCount = 2;
            this.tlpTopSectionDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpTopSectionDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTopSectionDI.Controls.Add(this.grpDocTypeDI, 0, 0);
            this.tlpTopSectionDI.Controls.Add(this.pnlTopRightDI, 1, 0);
            this.tlpTopSectionDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopSectionDI.Location = new System.Drawing.Point(3, 43);
            this.tlpTopSectionDI.Name = "tlpTopSectionDI";
            this.tlpTopSectionDI.RowCount = 1;
            this.tlpTopSectionDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopSectionDI.Size = new System.Drawing.Size(1334, 66);
            this.tlpTopSectionDI.TabIndex = 1;
            // 
            // grpDocTypeDI
            // 
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeAddendumDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeAppendixDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeBPRDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeBMRDI);
            this.grpDocTypeDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDocTypeDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDocTypeDI.Location = new System.Drawing.Point(3, 3);
            this.grpDocTypeDI.Name = "grpDocTypeDI";
            this.grpDocTypeDI.Size = new System.Drawing.Size(927, 60);
            this.grpDocTypeDI.TabIndex = 0;
            this.grpDocTypeDI.TabStop = false;
            this.grpDocTypeDI.Text = "Document Type";
            // 
            // chkDocTypeAddendumDI
            // 
            this.chkDocTypeAddendumDI.AutoSize = true;
            this.chkDocTypeAddendumDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDocTypeAddendumDI.Location = new System.Drawing.Point(300, 25);
            this.chkDocTypeAddendumDI.Name = "chkDocTypeAddendumDI";
            this.chkDocTypeAddendumDI.Size = new System.Drawing.Size(117, 27);
            this.chkDocTypeAddendumDI.TabIndex = 3;
            this.chkDocTypeAddendumDI.Text = "Addendum";
            this.chkDocTypeAddendumDI.UseVisualStyleBackColor = true;
            // 
            // chkDocTypeAppendixDI
            // 
            this.chkDocTypeAppendixDI.AutoSize = true;
            this.chkDocTypeAppendixDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDocTypeAppendixDI.Location = new System.Drawing.Point(200, 25);
            this.chkDocTypeAppendixDI.Name = "chkDocTypeAppendixDI";
            this.chkDocTypeAppendixDI.Size = new System.Drawing.Size(104, 27);
            this.chkDocTypeAppendixDI.TabIndex = 2;
            this.chkDocTypeAppendixDI.Text = "Appendix";
            this.chkDocTypeAppendixDI.UseVisualStyleBackColor = true;
            // 
            // chkDocTypeBPRDI
            // 
            this.chkDocTypeBPRDI.AutoSize = true;
            this.chkDocTypeBPRDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDocTypeBPRDI.Location = new System.Drawing.Point(110, 25);
            this.chkDocTypeBPRDI.Name = "chkDocTypeBPRDI";
            this.chkDocTypeBPRDI.Size = new System.Drawing.Size(62, 27);
            this.chkDocTypeBPRDI.TabIndex = 1;
            this.chkDocTypeBPRDI.Text = "BPR";
            this.chkDocTypeBPRDI.UseVisualStyleBackColor = true;
            // 
            // chkDocTypeBMRDI
            // 
            this.chkDocTypeBMRDI.AutoSize = true;
            this.chkDocTypeBMRDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDocTypeBMRDI.Location = new System.Drawing.Point(15, 25);
            this.chkDocTypeBMRDI.Name = "chkDocTypeBMRDI";
            this.chkDocTypeBMRDI.Size = new System.Drawing.Size(67, 27);
            this.chkDocTypeBMRDI.TabIndex = 0;
            this.chkDocTypeBMRDI.Text = "BMR";
            this.chkDocTypeBMRDI.UseVisualStyleBackColor = true;
            // 
            // pnlTopRightDI
            // 
            this.pnlTopRightDI.Controls.Add(this.txtRequestNoValueDI);
            this.pnlTopRightDI.Controls.Add(this.lblRequestNoLabelDI);
            this.pnlTopRightDI.Controls.Add(this.lblTrackerNoValueDI);
            this.pnlTopRightDI.Controls.Add(this.lblTrackerNoLabelDI);
            this.pnlTopRightDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRightDI.Location = new System.Drawing.Point(936, 3);
            this.pnlTopRightDI.Name = "pnlTopRightDI";
            this.pnlTopRightDI.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlTopRightDI.Size = new System.Drawing.Size(395, 60);
            this.pnlTopRightDI.TabIndex = 1;
            // 
            // txtRequestNoValueDI
            // 
            this.txtRequestNoValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRequestNoValueDI.Location = new System.Drawing.Point(132, 29);
            this.txtRequestNoValueDI.Name = "txtRequestNoValueDI";
            this.txtRequestNoValueDI.ReadOnly = true;
            this.txtRequestNoValueDI.Size = new System.Drawing.Size(220, 29);
            this.txtRequestNoValueDI.TabIndex = 3;
            this.txtRequestNoValueDI.Text = "(placeholder)";
            // 
            // lblRequestNoLabelDI
            // 
            this.lblRequestNoLabelDI.AutoSize = true;
            this.lblRequestNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRequestNoLabelDI.Location = new System.Drawing.Point(18, 32);
            this.lblRequestNoLabelDI.Name = "lblRequestNoLabelDI";
            this.lblRequestNoLabelDI.Size = new System.Drawing.Size(108, 23);
            this.lblRequestNoLabelDI.TabIndex = 2;
            this.lblRequestNoLabelDI.Text = "Request No.:";
            // 
            // lblTrackerNoValueDI
            // 
            this.lblTrackerNoValueDI.AutoSize = true;
            this.lblTrackerNoValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTrackerNoValueDI.Location = new System.Drawing.Point(128, 5);
            this.lblTrackerNoValueDI.Name = "lblTrackerNoValueDI";
            this.lblTrackerNoValueDI.Size = new System.Drawing.Size(68, 23);
            this.lblTrackerNoValueDI.TabIndex = 1;
            this.lblTrackerNoValueDI.Text = "(empty)";
            // 
            // lblTrackerNoLabelDI
            // 
            this.lblTrackerNoLabelDI.AutoSize = true;
            this.lblTrackerNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTrackerNoLabelDI.Location = new System.Drawing.Point(25, 5);
            this.lblTrackerNoLabelDI.Name = "lblTrackerNoLabelDI";
            this.lblTrackerNoLabelDI.Size = new System.Drawing.Size(101, 23);
            this.lblTrackerNoLabelDI.TabIndex = 0;
            this.lblTrackerNoLabelDI.Text = "Tracker No.:";
            // 
            // pnlRequestDetailsDI
            // 
            this.pnlRequestDetailsDI.AutoSize = true;
            this.pnlRequestDetailsDI.Controls.Add(this.tlpRequestDetails);
            this.pnlRequestDetailsDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequestDetailsDI.Location = new System.Drawing.Point(3, 115);
            this.pnlRequestDetailsDI.Name = "pnlRequestDetailsDI";
            this.pnlRequestDetailsDI.Size = new System.Drawing.Size(1334, 41);
            this.pnlRequestDetailsDI.TabIndex = 2;
            // 
            // tlpRequestDetails
            // 
            this.tlpRequestDetails.AutoSize = true;
            this.tlpRequestDetails.ColumnCount = 5;
            this.tlpRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRequestDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpRequestDetails.Controls.Add(this.lblRequestDateDI, 0, 0);
            this.tlpRequestDetails.Controls.Add(this.dtpRequestDateDI, 1, 0);
            this.tlpRequestDetails.Controls.Add(this.lblFromDepartmentDI, 3, 0);
            this.tlpRequestDetails.Controls.Add(this.cmbFromDepartmentDI, 4, 0);
            this.tlpRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRequestDetails.Location = new System.Drawing.Point(0, 0);
            this.tlpRequestDetails.Name = "tlpRequestDetails";
            this.tlpRequestDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tlpRequestDetails.RowCount = 1;
            this.tlpRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRequestDetails.Size = new System.Drawing.Size(1334, 41);
            this.tlpRequestDetails.TabIndex = 0;
            // 
            // lblRequestDateDI
            // 
            this.lblRequestDateDI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRequestDateDI.AutoSize = true;
            this.lblRequestDateDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRequestDateDI.Location = new System.Drawing.Point(13, 9);
            this.lblRequestDateDI.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblRequestDateDI.Name = "lblRequestDateDI";
            this.lblRequestDateDI.Size = new System.Drawing.Size(117, 23);
            this.lblRequestDateDI.TabIndex = 0;
            this.lblRequestDateDI.Text = "Request Date:";
            // 
            // dtpRequestDateDI
            // 
            this.dtpRequestDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpRequestDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpRequestDateDI.Location = new System.Drawing.Point(136, 6);
            this.dtpRequestDateDI.Name = "dtpRequestDateDI";
            this.dtpRequestDateDI.Size = new System.Drawing.Size(294, 29);
            this.dtpRequestDateDI.TabIndex = 1;
            // 
            // lblFromDepartmentDI
            // 
            this.lblFromDepartmentDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFromDepartmentDI.AutoSize = true;
            this.lblFromDepartmentDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFromDepartmentDI.Location = new System.Drawing.Point(910, 9);
            this.lblFromDepartmentDI.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblFromDepartmentDI.Name = "lblFromDepartmentDI";
            this.lblFromDepartmentDI.Size = new System.Drawing.Size(151, 23);
            this.lblFromDepartmentDI.TabIndex = 2;
            this.lblFromDepartmentDI.Text = "From Department:";
            // 
            // cmbFromDepartmentDI
            // 
            this.cmbFromDepartmentDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromDepartmentDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDepartmentDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbFromDepartmentDI.FormattingEnabled = true;
            this.cmbFromDepartmentDI.Items.AddRange(new object[] {
            "PRD - Production Department",
            "PKG - Packaging Department"});
            this.cmbFromDepartmentDI.Location = new System.Drawing.Point(1074, 6);
            this.cmbFromDepartmentDI.Name = "cmbFromDepartmentDI";
            this.cmbFromDepartmentDI.Size = new System.Drawing.Size(254, 29);
            this.cmbFromDepartmentDI.TabIndex = 3;
            // 
            // grpParentBatchInfoDI
            // 
            this.grpParentBatchInfoDI.AutoSize = true;
            this.grpParentBatchInfoDI.Controls.Add(this.tlpParentBatchInfo);
            this.grpParentBatchInfoDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParentBatchInfoDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpParentBatchInfoDI.Location = new System.Drawing.Point(3, 162);
            this.grpParentBatchInfoDI.Name = "grpParentBatchInfoDI";
            this.grpParentBatchInfoDI.Size = new System.Drawing.Size(1334, 108);
            this.grpParentBatchInfoDI.TabIndex = 3;
            this.grpParentBatchInfoDI.TabStop = false;
            this.grpParentBatchInfoDI.Text = "Parent Batch Information (If Applicable)";
            // 
            // tlpParentBatchInfo
            // 
            this.tlpParentBatchInfo.AutoSize = true;
            this.tlpParentBatchInfo.ColumnCount = 4;
            this.tlpParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParentBatchInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.Controls.Add(this.lblParentBatchNoDI, 0, 0);
            this.tlpParentBatchInfo.Controls.Add(this.txtParentBatchNoDI, 1, 0);
            this.tlpParentBatchInfo.Controls.Add(this.lblParentBatchSizeDI, 2, 0);
            this.tlpParentBatchInfo.Controls.Add(this.numParentBatchSizeDI, 3, 0);
            this.tlpParentBatchInfo.Controls.Add(this.lblParentMfgDateDI, 0, 1);
            this.tlpParentBatchInfo.Controls.Add(this.dtpParentMfgDateDI, 1, 1);
            this.tlpParentBatchInfo.Controls.Add(this.lblParentExpDateDI, 2, 1);
            this.tlpParentBatchInfo.Controls.Add(this.dtpParentExpDateDI, 3, 1);
            this.tlpParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParentBatchInfo.Location = new System.Drawing.Point(3, 25);
            this.tlpParentBatchInfo.Name = "tlpParentBatchInfo";
            this.tlpParentBatchInfo.Padding = new System.Windows.Forms.Padding(5);
            this.tlpParentBatchInfo.RowCount = 2;
            this.tlpParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.Size = new System.Drawing.Size(1328, 80);
            this.tlpParentBatchInfo.TabIndex = 0;
            // 
            // lblParentBatchNoDI
            // 
            this.lblParentBatchNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentBatchNoDI.AutoSize = true;
            this.lblParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchNoDI.Location = new System.Drawing.Point(8, 11);
            this.lblParentBatchNoDI.Name = "lblParentBatchNoDI";
            this.lblParentBatchNoDI.Size = new System.Drawing.Size(179, 23);
            this.lblParentBatchNoDI.TabIndex = 0;
            this.lblParentBatchNoDI.Text = "Parent Batch Number:";
            // 
            // txtParentBatchNoDI
            // 
            this.txtParentBatchNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtParentBatchNoDI.Location = new System.Drawing.Point(193, 8);
            this.txtParentBatchNoDI.Name = "txtParentBatchNoDI";
            this.txtParentBatchNoDI.Size = new System.Drawing.Size(484, 29);
            this.txtParentBatchNoDI.TabIndex = 1;
            this.txtParentBatchNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblParentBatchSizeDI
            // 
            this.lblParentBatchSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentBatchSizeDI.AutoSize = true;
            this.lblParentBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchSizeDI.Location = new System.Drawing.Point(683, 11);
            this.lblParentBatchSizeDI.Name = "lblParentBatchSizeDI";
            this.lblParentBatchSizeDI.Size = new System.Drawing.Size(146, 23);
            this.lblParentBatchSizeDI.TabIndex = 2;
            this.lblParentBatchSizeDI.Text = "Parent Batch Size:";
            // 
            // numParentBatchSizeDI
            // 
            this.numParentBatchSizeDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numParentBatchSizeDI.DecimalPlaces = 2;
            this.numParentBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numParentBatchSizeDI.Location = new System.Drawing.Point(835, 8);
            this.numParentBatchSizeDI.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numParentBatchSizeDI.Name = "numParentBatchSizeDI";
            this.numParentBatchSizeDI.Size = new System.Drawing.Size(485, 29);
            this.numParentBatchSizeDI.TabIndex = 3;
            this.numParentBatchSizeDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblParentMfgDateDI
            // 
            this.lblParentMfgDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentMfgDateDI.AutoSize = true;
            this.lblParentMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentMfgDateDI.Location = new System.Drawing.Point(44, 46);
            this.lblParentMfgDateDI.Name = "lblParentMfgDateDI";
            this.lblParentMfgDateDI.Size = new System.Drawing.Size(143, 23);
            this.lblParentMfgDateDI.TabIndex = 4;
            this.lblParentMfgDateDI.Text = "Parent Mfg. Date:";
            // 
            // dtpParentMfgDateDI
            // 
            this.dtpParentMfgDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpParentMfgDateDI.Checked = false;
            this.dtpParentMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpParentMfgDateDI.Location = new System.Drawing.Point(193, 43);
            this.dtpParentMfgDateDI.Name = "dtpParentMfgDateDI";
            this.dtpParentMfgDateDI.ShowCheckBox = true;
            this.dtpParentMfgDateDI.Size = new System.Drawing.Size(484, 29);
            this.dtpParentMfgDateDI.TabIndex = 5;
            // 
            // lblParentExpDateDI
            // 
            this.lblParentExpDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentExpDateDI.AutoSize = true;
            this.lblParentExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentExpDateDI.Location = new System.Drawing.Point(689, 46);
            this.lblParentExpDateDI.Name = "lblParentExpDateDI";
            this.lblParentExpDateDI.Size = new System.Drawing.Size(140, 23);
            this.lblParentExpDateDI.TabIndex = 6;
            this.lblParentExpDateDI.Text = "Parent Exp. Date:";
            // 
            // dtpParentExpDateDI
            // 
            this.dtpParentExpDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpParentExpDateDI.Checked = false;
            this.dtpParentExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpParentExpDateDI.Location = new System.Drawing.Point(835, 43);
            this.dtpParentExpDateDI.Name = "dtpParentExpDateDI";
            this.dtpParentExpDateDI.ShowCheckBox = true;
            this.dtpParentExpDateDI.Size = new System.Drawing.Size(485, 29);
            this.dtpParentExpDateDI.TabIndex = 7;
            // 
            // grpItemDetailsDI
            // 
            this.grpItemDetailsDI.AutoSize = true;
            this.grpItemDetailsDI.Controls.Add(this.tlpItemDetails);
            this.grpItemDetailsDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemDetailsDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpItemDetailsDI.Location = new System.Drawing.Point(3, 276);
            this.grpItemDetailsDI.Name = "grpItemDetailsDI";
            this.grpItemDetailsDI.Size = new System.Drawing.Size(1334, 143);
            this.grpItemDetailsDI.TabIndex = 4;
            this.grpItemDetailsDI.TabStop = false;
            this.grpItemDetailsDI.Text = "Item/Product Details";
            // 
            // tlpItemDetails
            // 
            this.tlpItemDetails.AutoSize = true;
            this.tlpItemDetails.ColumnCount = 6;
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpItemDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpItemDetails.Controls.Add(this.lblProductDI, 0, 0);
            this.tlpItemDetails.Controls.Add(this.txtProductDI, 1, 0);
            this.tlpItemDetails.Controls.Add(this.lblDocumentNoDI, 2, 0);
            this.tlpItemDetails.Controls.Add(this.txtDocumentNoDI, 3, 0);
            this.tlpItemDetails.Controls.Add(this.lblBatchNoDI, 4, 0);
            this.tlpItemDetails.Controls.Add(this.txtBatchNoDI, 5, 0);
            this.tlpItemDetails.Controls.Add(this.lblBatchSizeDI, 0, 1);
            this.tlpItemDetails.Controls.Add(this.txtBatchSizeDI, 1, 1);
            this.tlpItemDetails.Controls.Add(this.lblItemMfgDateDI, 2, 1);
            this.tlpItemDetails.Controls.Add(this.dtpItemMfgDateDI, 3, 1);
            this.tlpItemDetails.Controls.Add(this.lblItemExpDateDI, 4, 1);
            this.tlpItemDetails.Controls.Add(this.dtpItemExpDateDI, 5, 1);
            this.tlpItemDetails.Controls.Add(this.lblMarketDI, 0, 2);
            this.tlpItemDetails.Controls.Add(this.txtMarketDI, 1, 2);
            this.tlpItemDetails.Controls.Add(this.lblPackSizeDI, 2, 2);
            this.tlpItemDetails.Controls.Add(this.txtPackSizeDI, 3, 2);
            this.tlpItemDetails.Controls.Add(this.lblExportOrderNoDI, 4, 2);
            this.tlpItemDetails.Controls.Add(this.txtExportOrderNoDI, 5, 2);
            this.tlpItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemDetails.Location = new System.Drawing.Point(3, 25);
            this.tlpItemDetails.Name = "tlpItemDetails";
            this.tlpItemDetails.Padding = new System.Windows.Forms.Padding(5);
            this.tlpItemDetails.RowCount = 3;
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpItemDetails.Size = new System.Drawing.Size(1328, 115);
            this.tlpItemDetails.TabIndex = 0;
            // 
            // lblProductDI
            // 
            this.lblProductDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProductDI.AutoSize = true;
            this.lblProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblProductDI.Location = new System.Drawing.Point(26, 10);
            this.lblProductDI.Name = "lblProductDI";
            this.lblProductDI.Size = new System.Drawing.Size(74, 23);
            this.lblProductDI.TabIndex = 0;
            this.lblProductDI.Text = "Product:";
            // 
            // txtProductDI
            // 
            this.txtProductDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProductDI.Location = new System.Drawing.Point(106, 8);
            this.txtProductDI.Name = "txtProductDI";
            this.txtProductDI.Size = new System.Drawing.Size(320, 29);
            this.txtProductDI.TabIndex = 1;
            this.txtProductDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDocumentNoDI
            // 
            this.lblDocumentNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDocumentNoDI.AutoSize = true;
            this.lblDocumentNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDocumentNoDI.Location = new System.Drawing.Point(432, 10);
            this.lblDocumentNoDI.Name = "lblDocumentNoDI";
            this.lblDocumentNoDI.Size = new System.Drawing.Size(126, 23);
            this.lblDocumentNoDI.TabIndex = 2;
            this.lblDocumentNoDI.Text = "Document No.:";
            // 
            // txtDocumentNoDI
            // 
            this.txtDocumentNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDocumentNoDI.Location = new System.Drawing.Point(564, 8);
            this.txtDocumentNoDI.Name = "txtDocumentNoDI";
            this.txtDocumentNoDI.Size = new System.Drawing.Size(320, 29);
            this.txtDocumentNoDI.TabIndex = 3;
            this.txtDocumentNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatchNoDI
            // 
            this.lblBatchNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBatchNoDI.AutoSize = true;
            this.lblBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchNoDI.Location = new System.Drawing.Point(902, 10);
            this.lblBatchNoDI.Name = "lblBatchNoDI";
            this.lblBatchNoDI.Size = new System.Drawing.Size(89, 23);
            this.lblBatchNoDI.TabIndex = 4;
            this.lblBatchNoDI.Text = "Batch No.:";
            // 
            // txtBatchNoDI
            // 
            this.txtBatchNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBatchNoDI.Location = new System.Drawing.Point(997, 8);
            this.txtBatchNoDI.Name = "txtBatchNoDI";
            this.txtBatchNoDI.Size = new System.Drawing.Size(323, 29);
            this.txtBatchNoDI.TabIndex = 5;
            this.txtBatchNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatchSizeDI
            // 
            this.lblBatchSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBatchSizeDI.AutoSize = true;
            this.lblBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchSizeDI.Location = new System.Drawing.Point(8, 44);
            this.lblBatchSizeDI.Name = "lblBatchSizeDI";
            this.lblBatchSizeDI.Size = new System.Drawing.Size(92, 23);
            this.lblBatchSizeDI.TabIndex = 6;
            this.lblBatchSizeDI.Text = "Batch Size:";
            // 
            // txtBatchSizeDI
            // 
            this.txtBatchSizeDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBatchSizeDI.Location = new System.Drawing.Point(106, 42);
            this.txtBatchSizeDI.Name = "txtBatchSizeDI";
            this.txtBatchSizeDI.Size = new System.Drawing.Size(320, 29);
            this.txtBatchSizeDI.TabIndex = 7;
            this.txtBatchSizeDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblItemMfgDateDI
            // 
            this.lblItemMfgDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemMfgDateDI.AutoSize = true;
            this.lblItemMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemMfgDateDI.Location = new System.Drawing.Point(469, 44);
            this.lblItemMfgDateDI.Name = "lblItemMfgDateDI";
            this.lblItemMfgDateDI.Size = new System.Drawing.Size(89, 23);
            this.lblItemMfgDateDI.TabIndex = 8;
            this.lblItemMfgDateDI.Text = "Mfg. Date:";
            // 
            // dtpItemMfgDateDI
            // 
            this.dtpItemMfgDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpItemMfgDateDI.Checked = false;
            this.dtpItemMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpItemMfgDateDI.Location = new System.Drawing.Point(564, 42);
            this.dtpItemMfgDateDI.Name = "dtpItemMfgDateDI";
            this.dtpItemMfgDateDI.ShowCheckBox = true;
            this.dtpItemMfgDateDI.Size = new System.Drawing.Size(320, 29);
            this.dtpItemMfgDateDI.TabIndex = 9;
            // 
            // lblItemExpDateDI
            // 
            this.lblItemExpDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemExpDateDI.AutoSize = true;
            this.lblItemExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemExpDateDI.Location = new System.Drawing.Point(905, 44);
            this.lblItemExpDateDI.Name = "lblItemExpDateDI";
            this.lblItemExpDateDI.Size = new System.Drawing.Size(86, 23);
            this.lblItemExpDateDI.TabIndex = 10;
            this.lblItemExpDateDI.Text = "Exp. Date:";
            // 
            // dtpItemExpDateDI
            // 
            this.dtpItemExpDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpItemExpDateDI.Checked = false;
            this.dtpItemExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpItemExpDateDI.Location = new System.Drawing.Point(997, 42);
            this.dtpItemExpDateDI.Name = "dtpItemExpDateDI";
            this.dtpItemExpDateDI.ShowCheckBox = true;
            this.dtpItemExpDateDI.Size = new System.Drawing.Size(323, 29);
            this.dtpItemExpDateDI.TabIndex = 11;
            // 
            // lblMarketDI
            // 
            this.lblMarketDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMarketDI.AutoSize = true;
            this.lblMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblMarketDI.Location = new System.Drawing.Point(33, 80);
            this.lblMarketDI.Name = "lblMarketDI";
            this.lblMarketDI.Size = new System.Drawing.Size(67, 23);
            this.lblMarketDI.TabIndex = 12;
            this.lblMarketDI.Text = "Market:";
            // 
            // txtMarketDI
            // 
            this.txtMarketDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMarketDI.Location = new System.Drawing.Point(106, 77);
            this.txtMarketDI.Name = "txtMarketDI";
            this.txtMarketDI.Size = new System.Drawing.Size(320, 29);
            this.txtMarketDI.TabIndex = 13;
            this.txtMarketDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPackSizeDI
            // 
            this.lblPackSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPackSizeDI.AutoSize = true;
            this.lblPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPackSizeDI.Location = new System.Drawing.Point(475, 80);
            this.lblPackSizeDI.Name = "lblPackSizeDI";
            this.lblPackSizeDI.Size = new System.Drawing.Size(83, 23);
            this.lblPackSizeDI.TabIndex = 14;
            this.lblPackSizeDI.Text = "Pack Size:";
            // 
            // txtPackSizeDI
            // 
            this.txtPackSizeDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPackSizeDI.Location = new System.Drawing.Point(564, 77);
            this.txtPackSizeDI.Name = "txtPackSizeDI";
            this.txtPackSizeDI.Size = new System.Drawing.Size(320, 29);
            this.txtPackSizeDI.TabIndex = 15;
            this.txtPackSizeDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblExportOrderNoDI
            // 
            this.lblExportOrderNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblExportOrderNoDI.AutoSize = true;
            this.lblExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblExportOrderNoDI.Location = new System.Drawing.Point(890, 80);
            this.lblExportOrderNoDI.Name = "lblExportOrderNoDI";
            this.lblExportOrderNoDI.Size = new System.Drawing.Size(101, 23);
            this.lblExportOrderNoDI.TabIndex = 16;
            this.lblExportOrderNoDI.Text = "Export Ord.:";
            // 
            // txtExportOrderNoDI
            // 
            this.txtExportOrderNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtExportOrderNoDI.Location = new System.Drawing.Point(997, 77);
            this.txtExportOrderNoDI.Name = "txtExportOrderNoDI";
            this.txtExportOrderNoDI.Size = new System.Drawing.Size(323, 29);
            this.txtExportOrderNoDI.TabIndex = 17;
            this.txtExportOrderNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpRemarksDI
            // 
            this.grpRemarksDI.Controls.Add(this.txtRemarksDI);
            this.grpRemarksDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRemarksDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpRemarksDI.Location = new System.Drawing.Point(3, 425);
            this.grpRemarksDI.Name = "grpRemarksDI";
            this.grpRemarksDI.Padding = new System.Windows.Forms.Padding(10);
            this.grpRemarksDI.Size = new System.Drawing.Size(1334, 109);
            this.grpRemarksDI.TabIndex = 5;
            this.grpRemarksDI.TabStop = false;
            this.grpRemarksDI.Text = "Remarks";
            // 
            // txtRemarksDI
            // 
            this.txtRemarksDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarksDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRemarksDI.Location = new System.Drawing.Point(10, 32);
            this.txtRemarksDI.Multiline = true;
            this.txtRemarksDI.Name = "txtRemarksDI";
            this.txtRemarksDI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarksDI.Size = new System.Drawing.Size(1314, 67);
            this.txtRemarksDI.TabIndex = 0;
            // 
            // pnlActionBottomDI
            // 
            this.pnlActionBottomDI.Controls.Add(this.btnClearFormDI);
            this.pnlActionBottomDI.Controls.Add(this.btnSubmitRequestDI);
            this.pnlActionBottomDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionBottomDI.Location = new System.Drawing.Point(3, 540);
            this.pnlActionBottomDI.Name = "pnlActionBottomDI";
            this.pnlActionBottomDI.Size = new System.Drawing.Size(1334, 49);
            this.pnlActionBottomDI.TabIndex = 6;
            // 
            // btnClearFormDI
            // 
            this.btnClearFormDI.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFormDI.Location = new System.Drawing.Point(150, 5);
            this.btnClearFormDI.Name = "btnClearFormDI";
            this.btnClearFormDI.Size = new System.Drawing.Size(100, 35);
            this.btnClearFormDI.TabIndex = 1;
            this.btnClearFormDI.Text = "Clear Form";
            this.btnClearFormDI.UseVisualStyleBackColor = true;
            // 
            // btnSubmitRequestDI
            // 
            this.btnSubmitRequestDI.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitRequestDI.Location = new System.Drawing.Point(10, 5);
            this.btnSubmitRequestDI.Name = "btnSubmitRequestDI";
            this.btnSubmitRequestDI.Size = new System.Drawing.Size(130, 35);
            this.btnSubmitRequestDI.TabIndex = 0;
            this.btnSubmitRequestDI.Text = "Submit Request";
            this.btnSubmitRequestDI.UseVisualStyleBackColor = true;
            // 
            // pnlStatusDI
            // 
            this.pnlStatusDI.Controls.Add(this.lblStatusValueDI);
            this.pnlStatusDI.Controls.Add(this.lblStatusLabelDI);
            this.pnlStatusDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusDI.Location = new System.Drawing.Point(3, 595);
            this.pnlStatusDI.Name = "pnlStatusDI";
            this.pnlStatusDI.Size = new System.Drawing.Size(1334, 34);
            this.pnlStatusDI.TabIndex = 7;
            // 
            // lblStatusValueDI
            // 
            this.lblStatusValueDI.AutoSize = true;
            this.lblStatusValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblStatusValueDI.Location = new System.Drawing.Point(70, 7);
            this.lblStatusValueDI.Name = "lblStatusValueDI";
            this.lblStatusValueDI.Size = new System.Drawing.Size(173, 23);
            this.lblStatusValueDI.TabIndex = 1;
            this.lblStatusValueDI.Text = "Awaiting submission...";
            // 
            // lblStatusLabelDI
            // 
            this.lblStatusLabelDI.AutoSize = true;
            this.lblStatusLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabelDI.Location = new System.Drawing.Point(10, 7);
            this.lblStatusLabelDI.Name = "lblStatusLabelDI";
            this.lblStatusLabelDI.Size = new System.Drawing.Size(61, 23);
            this.lblStatusLabelDI.TabIndex = 0;
            this.lblStatusLabelDI.Text = "Status:";
            // 
            // tabPageGmOperations
            // 
            this.tabPageGmOperations.Controls.Add(this.tlpGmOperationsMain);
            this.tabPageGmOperations.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabPageGmOperations.Location = new System.Drawing.Point(4, 30);
            this.tabPageGmOperations.Name = "tabPageGmOperations";
            this.tabPageGmOperations.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageGmOperations.Size = new System.Drawing.Size(1360, 652);
            this.tabPageGmOperations.TabIndex = 2;
            this.tabPageGmOperations.Text = "GM Operations";
            this.tabPageGmOperations.UseVisualStyleBackColor = true;
            // 
            // tlpGmOperationsMain
            // 
            this.tlpGmOperationsMain.ColumnCount = 1;
            this.tlpGmOperationsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmOperationsMain.Controls.Add(this.pnlGmTopSection, 0, 0);
            this.tlpGmOperationsMain.Controls.Add(this.tlpGmBottomSection, 0, 1);
            this.tlpGmOperationsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmOperationsMain.Location = new System.Drawing.Point(10, 10);
            this.tlpGmOperationsMain.Name = "tlpGmOperationsMain";
            this.tlpGmOperationsMain.RowCount = 2;
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpGmOperationsMain.Size = new System.Drawing.Size(1340, 632);
            this.tlpGmOperationsMain.TabIndex = 0;
            // 
            // pnlGmTopSection
            // 
            this.pnlGmTopSection.Controls.Add(this.tlpGmTopControls);
            this.pnlGmTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGmTopSection.Location = new System.Drawing.Point(3, 3);
            this.pnlGmTopSection.Name = "pnlGmTopSection";
            this.pnlGmTopSection.Size = new System.Drawing.Size(1334, 183);
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
            this.tlpGmTopControls.Size = new System.Drawing.Size(1334, 183);
            this.tlpGmTopControls.TabIndex = 0;
            // 
            // pnlGmQueueHeader
            // 
            this.pnlGmQueueHeader.Controls.Add(this.lblGmQueueTitle);
            this.pnlGmQueueHeader.Controls.Add(this.btnGmRefreshList);
            this.pnlGmQueueHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGmQueueHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlGmQueueHeader.Name = "pnlGmQueueHeader";
            this.pnlGmQueueHeader.Size = new System.Drawing.Size(1328, 34);
            this.pnlGmQueueHeader.TabIndex = 0;
            // 
            // lblGmQueueTitle
            // 
            this.lblGmQueueTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGmQueueTitle.AutoSize = true;
            this.lblGmQueueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGmQueueTitle.Location = new System.Drawing.Point(5, 3);
            this.lblGmQueueTitle.Name = "lblGmQueueTitle";
            this.lblGmQueueTitle.Size = new System.Drawing.Size(286, 28);
            this.lblGmQueueTitle.TabIndex = 0;
            this.lblGmQueueTitle.Text = "Pending GM Approval Queue";
            // 
            // btnGmRefreshList
            // 
            this.btnGmRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGmRefreshList.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnGmRefreshList.Location = new System.Drawing.Point(1203, 1);
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
            this.dgvGmQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGmQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGmRequestNo,
            this.colGmRequestDate,
            this.colGmProduct,
            this.colGmDocTypes,
            this.colGmPreparedBy,
            this.colGmRequestedAt});
            this.dgvGmQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGmQueue.Location = new System.Drawing.Point(3, 43);
            this.dgvGmQueue.MultiSelect = false;
            this.dgvGmQueue.Name = "dgvGmQueue";
            this.dgvGmQueue.ReadOnly = true;
            this.dgvGmQueue.RowHeadersWidth = 51;
            this.dgvGmQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGmQueue.Size = new System.Drawing.Size(1328, 137);
            this.dgvGmQueue.TabIndex = 1;
            // 
            // colGmRequestNo
            // 
            this.colGmRequestNo.HeaderText = "Request No.";
            this.colGmRequestNo.MinimumWidth = 6;
            this.colGmRequestNo.Name = "colGmRequestNo";
            this.colGmRequestNo.ReadOnly = true;
            // 
            // colGmRequestDate
            // 
            this.colGmRequestDate.HeaderText = "Request Date";
            this.colGmRequestDate.MinimumWidth = 6;
            this.colGmRequestDate.Name = "colGmRequestDate";
            this.colGmRequestDate.ReadOnly = true;
            // 
            // colGmProduct
            // 
            this.colGmProduct.HeaderText = "Product";
            this.colGmProduct.MinimumWidth = 6;
            this.colGmProduct.Name = "colGmProduct";
            this.colGmProduct.ReadOnly = true;
            // 
            // colGmDocTypes
            // 
            this.colGmDocTypes.HeaderText = "Document Types";
            this.colGmDocTypes.MinimumWidth = 6;
            this.colGmDocTypes.Name = "colGmDocTypes";
            this.colGmDocTypes.ReadOnly = true;
            // 
            // colGmPreparedBy
            // 
            this.colGmPreparedBy.HeaderText = "Prepared By";
            this.colGmPreparedBy.MinimumWidth = 6;
            this.colGmPreparedBy.Name = "colGmPreparedBy";
            this.colGmPreparedBy.ReadOnly = true;
            // 
            // colGmRequestedAt
            // 
            this.colGmRequestedAt.HeaderText = "Requested At";
            this.colGmRequestedAt.MinimumWidth = 6;
            this.colGmRequestedAt.Name = "colGmRequestedAt";
            this.colGmRequestedAt.ReadOnly = true;
            // 
            // tlpGmBottomSection
            // 
            this.tlpGmBottomSection.ColumnCount = 1;
            this.tlpGmBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmBottomSection.Controls.Add(this.grpGmSelectedRequest, 0, 0);
            this.tlpGmBottomSection.Controls.Add(this.grpGmAction, 0, 1);
            this.tlpGmBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGmBottomSection.Location = new System.Drawing.Point(3, 192);
            this.tlpGmBottomSection.Name = "tlpGmBottomSection";
            this.tlpGmBottomSection.RowCount = 2;
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpGmBottomSection.Size = new System.Drawing.Size(1334, 437);
            this.tlpGmBottomSection.TabIndex = 1;
            // 
            // grpGmSelectedRequest
            // 
            this.grpGmSelectedRequest.Controls.Add(this.tlpGmRequestDetails);
            this.grpGmSelectedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGmSelectedRequest.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpGmSelectedRequest.Location = new System.Drawing.Point(3, 3);
            this.grpGmSelectedRequest.Name = "grpGmSelectedRequest";
            this.grpGmSelectedRequest.Padding = new System.Windows.Forms.Padding(10);
            this.grpGmSelectedRequest.Size = new System.Drawing.Size(1328, 251);
            this.grpGmSelectedRequest.TabIndex = 0;
            this.grpGmSelectedRequest.TabStop = false;
            this.grpGmSelectedRequest.Text = "Selected Request Details";
            // 
            // tlpGmRequestDetails
            // 
            this.tlpGmRequestDetails.AutoScroll = true;
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
            this.tlpGmRequestDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tlpGmRequestDetails.Location = new System.Drawing.Point(10, 32);
            this.tlpGmRequestDetails.Name = "tlpGmRequestDetails";
            this.tlpGmRequestDetails.RowCount = 7;
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpGmRequestDetails.Size = new System.Drawing.Size(1308, 209);
            this.tlpGmRequestDetails.TabIndex = 0;
            // 
            // lblGmDetailRequestNoLabel
            // 
            this.lblGmDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestNoLabel.AutoSize = true;
            this.lblGmDetailRequestNoLabel.Location = new System.Drawing.Point(55, 5);
            this.lblGmDetailRequestNoLabel.Name = "lblGmDetailRequestNoLabel";
            this.lblGmDetailRequestNoLabel.Size = new System.Drawing.Size(92, 20);
            this.lblGmDetailRequestNoLabel.TabIndex = 0;
            this.lblGmDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtGmDetailRequestNo
            // 
            this.txtGmDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestNo.Location = new System.Drawing.Point(153, 3);
            this.txtGmDetailRequestNo.Name = "txtGmDetailRequestNo";
            this.txtGmDetailRequestNo.ReadOnly = true;
            this.txtGmDetailRequestNo.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailRequestNo.TabIndex = 1;
            // 
            // lblGmDetailRequestDateLabel
            // 
            this.lblGmDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestDateLabel.AutoSize = true;
            this.lblGmDetailRequestDateLabel.Location = new System.Drawing.Point(700, 5);
            this.lblGmDetailRequestDateLabel.Name = "lblGmDetailRequestDateLabel";
            this.lblGmDetailRequestDateLabel.Size = new System.Drawing.Size(101, 20);
            this.lblGmDetailRequestDateLabel.TabIndex = 2;
            this.lblGmDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtGmDetailRequestDate
            // 
            this.txtGmDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestDate.Location = new System.Drawing.Point(807, 3);
            this.txtGmDetailRequestDate.Name = "txtGmDetailRequestDate";
            this.txtGmDetailRequestDate.ReadOnly = true;
            this.txtGmDetailRequestDate.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailRequestDate.TabIndex = 3;
            // 
            // lblGmDetailFromDeptLabel
            // 
            this.lblGmDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailFromDeptLabel.AutoSize = true;
            this.lblGmDetailFromDeptLabel.Location = new System.Drawing.Point(17, 35);
            this.lblGmDetailFromDeptLabel.Name = "lblGmDetailFromDeptLabel";
            this.lblGmDetailFromDeptLabel.Size = new System.Drawing.Size(130, 20);
            this.lblGmDetailFromDeptLabel.TabIndex = 4;
            this.lblGmDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtGmDetailFromDept
            // 
            this.txtGmDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailFromDept.Location = new System.Drawing.Point(153, 33);
            this.txtGmDetailFromDept.Name = "txtGmDetailFromDept";
            this.txtGmDetailFromDept.ReadOnly = true;
            this.txtGmDetailFromDept.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailFromDept.TabIndex = 5;
            // 
            // lblGmDetailDocTypesLabel
            // 
            this.lblGmDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailDocTypesLabel.AutoSize = true;
            this.lblGmDetailDocTypesLabel.Location = new System.Drawing.Point(679, 35);
            this.lblGmDetailDocTypesLabel.Name = "lblGmDetailDocTypesLabel";
            this.lblGmDetailDocTypesLabel.Size = new System.Drawing.Size(122, 20);
            this.lblGmDetailDocTypesLabel.TabIndex = 6;
            this.lblGmDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtGmDetailDocTypes
            // 
            this.txtGmDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailDocTypes.Location = new System.Drawing.Point(807, 33);
            this.txtGmDetailDocTypes.Name = "txtGmDetailDocTypes";
            this.txtGmDetailDocTypes.ReadOnly = true;
            this.txtGmDetailDocTypes.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailDocTypes.TabIndex = 7;
            // 
            // lblGmDetailProductLabel
            // 
            this.lblGmDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailProductLabel.AutoSize = true;
            this.lblGmDetailProductLabel.Location = new System.Drawing.Point(84, 65);
            this.lblGmDetailProductLabel.Name = "lblGmDetailProductLabel";
            this.lblGmDetailProductLabel.Size = new System.Drawing.Size(63, 20);
            this.lblGmDetailProductLabel.TabIndex = 8;
            this.lblGmDetailProductLabel.Text = "Product:";
            // 
            // txtGmDetailProduct
            // 
            this.txtGmDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailProduct.Location = new System.Drawing.Point(153, 63);
            this.txtGmDetailProduct.Name = "txtGmDetailProduct";
            this.txtGmDetailProduct.ReadOnly = true;
            this.txtGmDetailProduct.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailProduct.TabIndex = 9;
            // 
            // lblGmDetailBatchNoLabel
            // 
            this.lblGmDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailBatchNoLabel.AutoSize = true;
            this.lblGmDetailBatchNoLabel.Location = new System.Drawing.Point(725, 65);
            this.lblGmDetailBatchNoLabel.Name = "lblGmDetailBatchNoLabel";
            this.lblGmDetailBatchNoLabel.Size = new System.Drawing.Size(76, 20);
            this.lblGmDetailBatchNoLabel.TabIndex = 10;
            this.lblGmDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtGmDetailBatchNo
            // 
            this.txtGmDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailBatchNo.Location = new System.Drawing.Point(807, 63);
            this.txtGmDetailBatchNo.Name = "txtGmDetailBatchNo";
            this.txtGmDetailBatchNo.ReadOnly = true;
            this.txtGmDetailBatchNo.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailBatchNo.TabIndex = 11;
            // 
            // lblGmDetailMfgDateLabel
            // 
            this.lblGmDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMfgDateLabel.AutoSize = true;
            this.lblGmDetailMfgDateLabel.Location = new System.Drawing.Point(72, 95);
            this.lblGmDetailMfgDateLabel.Name = "lblGmDetailMfgDateLabel";
            this.lblGmDetailMfgDateLabel.Size = new System.Drawing.Size(75, 20);
            this.lblGmDetailMfgDateLabel.TabIndex = 12;
            this.lblGmDetailMfgDateLabel.Text = "Mfg Date:";
            // 
            // txtGmDetailMfgDate
            // 
            this.txtGmDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMfgDate.Location = new System.Drawing.Point(153, 93);
            this.txtGmDetailMfgDate.Name = "txtGmDetailMfgDate";
            this.txtGmDetailMfgDate.ReadOnly = true;
            this.txtGmDetailMfgDate.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailMfgDate.TabIndex = 13;
            // 
            // lblGmDetailExpDateLabel
            // 
            this.lblGmDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailExpDateLabel.AutoSize = true;
            this.lblGmDetailExpDateLabel.Location = new System.Drawing.Point(726, 95);
            this.lblGmDetailExpDateLabel.Name = "lblGmDetailExpDateLabel";
            this.lblGmDetailExpDateLabel.Size = new System.Drawing.Size(75, 20);
            this.lblGmDetailExpDateLabel.TabIndex = 14;
            this.lblGmDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtGmDetailExpDate
            // 
            this.txtGmDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailExpDate.Location = new System.Drawing.Point(807, 93);
            this.txtGmDetailExpDate.Name = "txtGmDetailExpDate";
            this.txtGmDetailExpDate.ReadOnly = true;
            this.txtGmDetailExpDate.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailExpDate.TabIndex = 15;
            // 
            // lblGmDetailMarketLabel
            // 
            this.lblGmDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMarketLabel.AutoSize = true;
            this.lblGmDetailMarketLabel.Location = new System.Drawing.Point(89, 125);
            this.lblGmDetailMarketLabel.Name = "lblGmDetailMarketLabel";
            this.lblGmDetailMarketLabel.Size = new System.Drawing.Size(58, 20);
            this.lblGmDetailMarketLabel.TabIndex = 16;
            this.lblGmDetailMarketLabel.Text = "Market:";
            // 
            // txtGmDetailMarket
            // 
            this.txtGmDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMarket.Location = new System.Drawing.Point(153, 123);
            this.txtGmDetailMarket.Name = "txtGmDetailMarket";
            this.txtGmDetailMarket.ReadOnly = true;
            this.txtGmDetailMarket.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailMarket.TabIndex = 17;
            // 
            // lblGmDetailPackSizeLabel
            // 
            this.lblGmDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPackSizeLabel.AutoSize = true;
            this.lblGmDetailPackSizeLabel.Location = new System.Drawing.Point(729, 125);
            this.lblGmDetailPackSizeLabel.Name = "lblGmDetailPackSizeLabel";
            this.lblGmDetailPackSizeLabel.Size = new System.Drawing.Size(72, 20);
            this.lblGmDetailPackSizeLabel.TabIndex = 18;
            this.lblGmDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtGmDetailPackSize
            // 
            this.txtGmDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPackSize.Location = new System.Drawing.Point(807, 123);
            this.txtGmDetailPackSize.Name = "txtGmDetailPackSize";
            this.txtGmDetailPackSize.ReadOnly = true;
            this.txtGmDetailPackSize.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailPackSize.TabIndex = 19;
            // 
            // lblGmDetailPreparedByLabel
            // 
            this.lblGmDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPreparedByLabel.AutoSize = true;
            this.lblGmDetailPreparedByLabel.Location = new System.Drawing.Point(55, 155);
            this.lblGmDetailPreparedByLabel.Name = "lblGmDetailPreparedByLabel";
            this.lblGmDetailPreparedByLabel.Size = new System.Drawing.Size(92, 20);
            this.lblGmDetailPreparedByLabel.TabIndex = 20;
            this.lblGmDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtGmDetailPreparedBy
            // 
            this.txtGmDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPreparedBy.Location = new System.Drawing.Point(153, 153);
            this.txtGmDetailPreparedBy.Name = "txtGmDetailPreparedBy";
            this.txtGmDetailPreparedBy.ReadOnly = true;
            this.txtGmDetailPreparedBy.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailPreparedBy.TabIndex = 21;
            // 
            // lblGmDetailRequestedAtLabel
            // 
            this.lblGmDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestedAtLabel.AutoSize = true;
            this.lblGmDetailRequestedAtLabel.Location = new System.Drawing.Point(700, 155);
            this.lblGmDetailRequestedAtLabel.Name = "lblGmDetailRequestedAtLabel";
            this.lblGmDetailRequestedAtLabel.Size = new System.Drawing.Size(101, 20);
            this.lblGmDetailRequestedAtLabel.TabIndex = 22;
            this.lblGmDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtGmDetailRequestedAt
            // 
            this.txtGmDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestedAt.Location = new System.Drawing.Point(807, 153);
            this.txtGmDetailRequestedAt.Name = "txtGmDetailRequestedAt";
            this.txtGmDetailRequestedAt.ReadOnly = true;
            this.txtGmDetailRequestedAt.Size = new System.Drawing.Size(498, 27);
            this.txtGmDetailRequestedAt.TabIndex = 23;
            // 
            // lblGmDetailRequesterCommentsLabel
            // 
            this.lblGmDetailRequesterCommentsLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequesterCommentsLabel.AutoSize = true;
            this.lblGmDetailRequesterCommentsLabel.Location = new System.Drawing.Point(64, 190);
            this.lblGmDetailRequesterCommentsLabel.Name = "lblGmDetailRequesterCommentsLabel";
            this.lblGmDetailRequesterCommentsLabel.Size = new System.Drawing.Size(83, 40);
            this.lblGmDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblGmDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtGmDetailRequesterComments
            // 
            this.tlpGmRequestDetails.SetColumnSpan(this.txtGmDetailRequesterComments, 3);
            this.txtGmDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmDetailRequesterComments.Location = new System.Drawing.Point(153, 183);
            this.txtGmDetailRequesterComments.Multiline = true;
            this.txtGmDetailRequesterComments.Name = "txtGmDetailRequesterComments";
            this.txtGmDetailRequesterComments.ReadOnly = true;
            this.txtGmDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmDetailRequesterComments.Size = new System.Drawing.Size(1152, 54);
            this.txtGmDetailRequesterComments.TabIndex = 25;
            // 
            // grpGmAction
            // 
            this.grpGmAction.Controls.Add(this.tlpGmActionControls);
            this.grpGmAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGmAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpGmAction.Location = new System.Drawing.Point(3, 260);
            this.grpGmAction.Name = "grpGmAction";
            this.grpGmAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpGmAction.Size = new System.Drawing.Size(1328, 174);
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
            this.tlpGmActionControls.Location = new System.Drawing.Point(10, 32);
            this.tlpGmActionControls.Name = "tlpGmActionControls";
            this.tlpGmActionControls.RowCount = 3;
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpGmActionControls.Size = new System.Drawing.Size(1308, 132);
            this.tlpGmActionControls.TabIndex = 0;
            // 
            // lblGmComment
            // 
            this.lblGmComment.AutoSize = true;
            this.lblGmComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGmComment.Location = new System.Drawing.Point(3, 0);
            this.lblGmComment.Name = "lblGmComment";
            this.lblGmComment.Size = new System.Drawing.Size(110, 20);
            this.lblGmComment.TabIndex = 0;
            this.lblGmComment.Text = "GM Comments:";
            // 
            // txtGmComment
            // 
            this.txtGmComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGmComment.Location = new System.Drawing.Point(3, 23);
            this.txtGmComment.Multiline = true;
            this.txtGmComment.Name = "txtGmComment";
            this.txtGmComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmComment.Size = new System.Drawing.Size(1302, 61);
            this.txtGmComment.TabIndex = 1;
            // 
            // flpGmActionButtons
            // 
            this.flpGmActionButtons.Controls.Add(this.btnGmAuthorize);
            this.flpGmActionButtons.Controls.Add(this.btnGmReject);
            this.flpGmActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGmActionButtons.Location = new System.Drawing.Point(3, 90);
            this.flpGmActionButtons.Name = "flpGmActionButtons";
            this.flpGmActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpGmActionButtons.Size = new System.Drawing.Size(1302, 39);
            this.flpGmActionButtons.TabIndex = 2;
            // 
            // btnGmAuthorize
            // 
            this.btnGmAuthorize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGmAuthorize.Location = new System.Drawing.Point(3, 8);
            this.btnGmAuthorize.Name = "btnGmAuthorize";
            this.btnGmAuthorize.Size = new System.Drawing.Size(120, 30);
            this.btnGmAuthorize.TabIndex = 0;
            this.btnGmAuthorize.Text = "Authorize";
            this.btnGmAuthorize.UseVisualStyleBackColor = true;
            // 
            // btnGmReject
            // 
            this.btnGmReject.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnGmReject.Location = new System.Drawing.Point(129, 8);
            this.btnGmReject.Name = "btnGmReject";
            this.btnGmReject.Size = new System.Drawing.Size(120, 30);
            this.btnGmReject.TabIndex = 1;
            this.btnGmReject.Text = "Reject";
            this.btnGmReject.UseVisualStyleBackColor = true;
            // 
            // tabPageQa
            // 
            this.tabPageQa.Controls.Add(this.tlpQaOperationsMain);
            this.tabPageQa.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabPageQa.Location = new System.Drawing.Point(4, 30);
            this.tabPageQa.Name = "tabPageQa";
            this.tabPageQa.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageQa.Size = new System.Drawing.Size(1360, 652);
            this.tabPageQa.TabIndex = 3;
            this.tabPageQa.Text = "QA";
            this.tabPageQa.UseVisualStyleBackColor = true;
            // 
            // tlpQaOperationsMain
            // 
            this.tlpQaOperationsMain.ColumnCount = 1;
            this.tlpQaOperationsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaOperationsMain.Controls.Add(this.pnlQaTopSection, 0, 0);
            this.tlpQaOperationsMain.Controls.Add(this.tlpQaBottomSection, 0, 1);
            this.tlpQaOperationsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaOperationsMain.Location = new System.Drawing.Point(10, 10);
            this.tlpQaOperationsMain.Name = "tlpQaOperationsMain";
            this.tlpQaOperationsMain.RowCount = 2;
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpQaOperationsMain.Size = new System.Drawing.Size(1340, 632);
            this.tlpQaOperationsMain.TabIndex = 0;
            // 
            // pnlQaTopSection
            // 
            this.pnlQaTopSection.Controls.Add(this.tlpQaTopControls);
            this.pnlQaTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQaTopSection.Location = new System.Drawing.Point(3, 3);
            this.pnlQaTopSection.Name = "pnlQaTopSection";
            this.pnlQaTopSection.Size = new System.Drawing.Size(1334, 215);
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
            this.tlpQaTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpQaTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpQaTopControls.Size = new System.Drawing.Size(1334, 215);
            this.tlpQaTopControls.TabIndex = 0;
            // 
            // pnlQaQueueHeader
            // 
            this.pnlQaQueueHeader.Controls.Add(this.lblQaQueueTitle);
            this.pnlQaQueueHeader.Controls.Add(this.btnQaRefreshList);
            this.pnlQaQueueHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQaQueueHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlQaQueueHeader.Name = "pnlQaQueueHeader";
            this.pnlQaQueueHeader.Size = new System.Drawing.Size(1328, 29);
            this.pnlQaQueueHeader.TabIndex = 0;
            // 
            // lblQaQueueTitle
            // 
            this.lblQaQueueTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQaQueueTitle.AutoSize = true;
            this.lblQaQueueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQaQueueTitle.Location = new System.Drawing.Point(5, 0);
            this.lblQaQueueTitle.Name = "lblQaQueueTitle";
            this.lblQaQueueTitle.Size = new System.Drawing.Size(282, 28);
            this.lblQaQueueTitle.TabIndex = 0;
            this.lblQaQueueTitle.Text = "Pending QA Approval Queue";
            // 
            // btnQaRefreshList
            // 
            this.btnQaRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQaRefreshList.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnQaRefreshList.Location = new System.Drawing.Point(1203, -2);
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
            this.dgvQaQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQaQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQaRequestNo,
            this.colQaRequestDate,
            this.colQaProduct,
            this.colQaDocTypes,
            this.colQaPreparedBy,
            this.colQaAuthorizedBy,
            this.colQaGmActionAt});
            this.dgvQaQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQaQueue.Location = new System.Drawing.Point(3, 38);
            this.dgvQaQueue.MultiSelect = false;
            this.dgvQaQueue.Name = "dgvQaQueue";
            this.dgvQaQueue.ReadOnly = true;
            this.dgvQaQueue.RowHeadersWidth = 51;
            this.dgvQaQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQaQueue.Size = new System.Drawing.Size(1328, 174);
            this.dgvQaQueue.TabIndex = 1;
            // 
            // colQaRequestNo
            // 
            this.colQaRequestNo.HeaderText = "Request No.";
            this.colQaRequestNo.MinimumWidth = 6;
            this.colQaRequestNo.Name = "colQaRequestNo";
            this.colQaRequestNo.ReadOnly = true;
            // 
            // colQaRequestDate
            // 
            this.colQaRequestDate.HeaderText = "Request Date";
            this.colQaRequestDate.MinimumWidth = 6;
            this.colQaRequestDate.Name = "colQaRequestDate";
            this.colQaRequestDate.ReadOnly = true;
            // 
            // colQaProduct
            // 
            this.colQaProduct.HeaderText = "Product";
            this.colQaProduct.MinimumWidth = 6;
            this.colQaProduct.Name = "colQaProduct";
            this.colQaProduct.ReadOnly = true;
            // 
            // colQaDocTypes
            // 
            this.colQaDocTypes.HeaderText = "Document Types";
            this.colQaDocTypes.MinimumWidth = 6;
            this.colQaDocTypes.Name = "colQaDocTypes";
            this.colQaDocTypes.ReadOnly = true;
            // 
            // colQaPreparedBy
            // 
            this.colQaPreparedBy.HeaderText = "Prepared By";
            this.colQaPreparedBy.MinimumWidth = 6;
            this.colQaPreparedBy.Name = "colQaPreparedBy";
            this.colQaPreparedBy.ReadOnly = true;
            // 
            // colQaAuthorizedBy
            // 
            this.colQaAuthorizedBy.HeaderText = "Authorized By (GM)";
            this.colQaAuthorizedBy.MinimumWidth = 6;
            this.colQaAuthorizedBy.Name = "colQaAuthorizedBy";
            this.colQaAuthorizedBy.ReadOnly = true;
            // 
            // colQaGmActionAt
            // 
            this.colQaGmActionAt.HeaderText = "GM Action At";
            this.colQaGmActionAt.MinimumWidth = 6;
            this.colQaGmActionAt.Name = "colQaGmActionAt";
            this.colQaGmActionAt.ReadOnly = true;
            // 
            // tlpQaBottomSection
            // 
            this.tlpQaBottomSection.ColumnCount = 1;
            this.tlpQaBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaBottomSection.Controls.Add(this.grpQaSelectedRequest, 0, 0);
            this.tlpQaBottomSection.Controls.Add(this.grpQaAction, 0, 1);
            this.tlpQaBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaBottomSection.Location = new System.Drawing.Point(3, 224);
            this.tlpQaBottomSection.Name = "tlpQaBottomSection";
            this.tlpQaBottomSection.RowCount = 2;
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpQaBottomSection.Size = new System.Drawing.Size(1334, 405);
            this.tlpQaBottomSection.TabIndex = 1;
            // 
            // grpQaSelectedRequest
            // 
            this.grpQaSelectedRequest.Controls.Add(this.tlpQaRequestDetails);
            this.grpQaSelectedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaSelectedRequest.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpQaSelectedRequest.Location = new System.Drawing.Point(3, 3);
            this.grpQaSelectedRequest.Name = "grpQaSelectedRequest";
            this.grpQaSelectedRequest.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaSelectedRequest.Size = new System.Drawing.Size(1328, 179);
            this.grpQaSelectedRequest.TabIndex = 0;
            this.grpQaSelectedRequest.TabStop = false;
            this.grpQaSelectedRequest.Text = "Selected Request Details";
            // 
            // tlpQaRequestDetails
            // 
            this.tlpQaRequestDetails.AutoScroll = true;
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
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailGmCommentLabel, 0, 7);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailGmComment, 1, 7);
            this.tlpQaRequestDetails.Controls.Add(this.lblQaDetailGmActionTimeLabel, 0, 8);
            this.tlpQaRequestDetails.Controls.Add(this.txtQaDetailGmActionTime, 1, 8);
            this.tlpQaRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQaRequestDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tlpQaRequestDetails.Location = new System.Drawing.Point(10, 32);
            this.tlpQaRequestDetails.Name = "tlpQaRequestDetails";
            this.tlpQaRequestDetails.RowCount = 9;
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQaRequestDetails.Size = new System.Drawing.Size(1308, 137);
            this.tlpQaRequestDetails.TabIndex = 0;
            // 
            // lblQaDetailRequestNoLabel
            // 
            this.lblQaDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestNoLabel.AutoSize = true;
            this.lblQaDetailRequestNoLabel.Location = new System.Drawing.Point(65, 0);
            this.lblQaDetailRequestNoLabel.Name = "lblQaDetailRequestNoLabel";
            this.lblQaDetailRequestNoLabel.Size = new System.Drawing.Size(92, 20);
            this.lblQaDetailRequestNoLabel.TabIndex = 0;
            this.lblQaDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtQaDetailRequestNo
            // 
            this.txtQaDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestNo.Location = new System.Drawing.Point(163, 3);
            this.txtQaDetailRequestNo.Name = "txtQaDetailRequestNo";
            this.txtQaDetailRequestNo.ReadOnly = true;
            this.txtQaDetailRequestNo.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailRequestNo.TabIndex = 1;
            // 
            // lblQaDetailRequestDateLabel
            // 
            this.lblQaDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestDateLabel.AutoSize = true;
            this.lblQaDetailRequestDateLabel.Location = new System.Drawing.Point(710, 0);
            this.lblQaDetailRequestDateLabel.Name = "lblQaDetailRequestDateLabel";
            this.lblQaDetailRequestDateLabel.Size = new System.Drawing.Size(101, 20);
            this.lblQaDetailRequestDateLabel.TabIndex = 2;
            this.lblQaDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtQaDetailRequestDate
            // 
            this.txtQaDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestDate.Location = new System.Drawing.Point(817, 3);
            this.txtQaDetailRequestDate.Name = "txtQaDetailRequestDate";
            this.txtQaDetailRequestDate.ReadOnly = true;
            this.txtQaDetailRequestDate.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailRequestDate.TabIndex = 3;
            // 
            // lblQaDetailFromDeptLabel
            // 
            this.lblQaDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailFromDeptLabel.AutoSize = true;
            this.lblQaDetailFromDeptLabel.Location = new System.Drawing.Point(27, 20);
            this.lblQaDetailFromDeptLabel.Name = "lblQaDetailFromDeptLabel";
            this.lblQaDetailFromDeptLabel.Size = new System.Drawing.Size(130, 20);
            this.lblQaDetailFromDeptLabel.TabIndex = 4;
            this.lblQaDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtQaDetailFromDept
            // 
            this.txtQaDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailFromDept.Location = new System.Drawing.Point(163, 23);
            this.txtQaDetailFromDept.Name = "txtQaDetailFromDept";
            this.txtQaDetailFromDept.ReadOnly = true;
            this.txtQaDetailFromDept.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailFromDept.TabIndex = 5;
            // 
            // lblQaDetailDocTypesLabel
            // 
            this.lblQaDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailDocTypesLabel.AutoSize = true;
            this.lblQaDetailDocTypesLabel.Location = new System.Drawing.Point(689, 20);
            this.lblQaDetailDocTypesLabel.Name = "lblQaDetailDocTypesLabel";
            this.lblQaDetailDocTypesLabel.Size = new System.Drawing.Size(122, 20);
            this.lblQaDetailDocTypesLabel.TabIndex = 6;
            this.lblQaDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtQaDetailDocTypes
            // 
            this.txtQaDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailDocTypes.Location = new System.Drawing.Point(817, 23);
            this.txtQaDetailDocTypes.Name = "txtQaDetailDocTypes";
            this.txtQaDetailDocTypes.ReadOnly = true;
            this.txtQaDetailDocTypes.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailDocTypes.TabIndex = 7;
            // 
            // lblQaDetailProductLabel
            // 
            this.lblQaDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailProductLabel.AutoSize = true;
            this.lblQaDetailProductLabel.Location = new System.Drawing.Point(94, 40);
            this.lblQaDetailProductLabel.Name = "lblQaDetailProductLabel";
            this.lblQaDetailProductLabel.Size = new System.Drawing.Size(63, 20);
            this.lblQaDetailProductLabel.TabIndex = 8;
            this.lblQaDetailProductLabel.Text = "Product:";
            // 
            // txtQaDetailProduct
            // 
            this.txtQaDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailProduct.Location = new System.Drawing.Point(163, 43);
            this.txtQaDetailProduct.Name = "txtQaDetailProduct";
            this.txtQaDetailProduct.ReadOnly = true;
            this.txtQaDetailProduct.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailProduct.TabIndex = 9;
            // 
            // lblQaDetailBatchNoLabel
            // 
            this.lblQaDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailBatchNoLabel.AutoSize = true;
            this.lblQaDetailBatchNoLabel.Location = new System.Drawing.Point(735, 40);
            this.lblQaDetailBatchNoLabel.Name = "lblQaDetailBatchNoLabel";
            this.lblQaDetailBatchNoLabel.Size = new System.Drawing.Size(76, 20);
            this.lblQaDetailBatchNoLabel.TabIndex = 10;
            this.lblQaDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtQaDetailBatchNo
            // 
            this.txtQaDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailBatchNo.Location = new System.Drawing.Point(817, 43);
            this.txtQaDetailBatchNo.Name = "txtQaDetailBatchNo";
            this.txtQaDetailBatchNo.ReadOnly = true;
            this.txtQaDetailBatchNo.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailBatchNo.TabIndex = 11;
            // 
            // lblQaDetailMfgDateLabel
            // 
            this.lblQaDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMfgDateLabel.AutoSize = true;
            this.lblQaDetailMfgDateLabel.Location = new System.Drawing.Point(79, 60);
            this.lblQaDetailMfgDateLabel.Name = "lblQaDetailMfgDateLabel";
            this.lblQaDetailMfgDateLabel.Size = new System.Drawing.Size(78, 20);
            this.lblQaDetailMfgDateLabel.TabIndex = 12;
            this.lblQaDetailMfgDateLabel.Text = "Mfg. Date:";
            // 
            // txtQaDetailMfgDate
            // 
            this.txtQaDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMfgDate.Location = new System.Drawing.Point(163, 63);
            this.txtQaDetailMfgDate.Name = "txtQaDetailMfgDate";
            this.txtQaDetailMfgDate.ReadOnly = true;
            this.txtQaDetailMfgDate.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailMfgDate.TabIndex = 13;
            // 
            // lblQaDetailExpDateLabel
            // 
            this.lblQaDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailExpDateLabel.AutoSize = true;
            this.lblQaDetailExpDateLabel.Location = new System.Drawing.Point(736, 60);
            this.lblQaDetailExpDateLabel.Name = "lblQaDetailExpDateLabel";
            this.lblQaDetailExpDateLabel.Size = new System.Drawing.Size(75, 20);
            this.lblQaDetailExpDateLabel.TabIndex = 14;
            this.lblQaDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtQaDetailExpDate
            // 
            this.txtQaDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailExpDate.Location = new System.Drawing.Point(817, 63);
            this.txtQaDetailExpDate.Name = "txtQaDetailExpDate";
            this.txtQaDetailExpDate.ReadOnly = true;
            this.txtQaDetailExpDate.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailExpDate.TabIndex = 15;
            // 
            // lblQaDetailMarketLabel
            // 
            this.lblQaDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMarketLabel.AutoSize = true;
            this.lblQaDetailMarketLabel.Location = new System.Drawing.Point(99, 80);
            this.lblQaDetailMarketLabel.Name = "lblQaDetailMarketLabel";
            this.lblQaDetailMarketLabel.Size = new System.Drawing.Size(58, 20);
            this.lblQaDetailMarketLabel.TabIndex = 16;
            this.lblQaDetailMarketLabel.Text = "Market:";
            // 
            // txtQaDetailMarket
            // 
            this.txtQaDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMarket.Location = new System.Drawing.Point(163, 83);
            this.txtQaDetailMarket.Name = "txtQaDetailMarket";
            this.txtQaDetailMarket.ReadOnly = true;
            this.txtQaDetailMarket.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailMarket.TabIndex = 17;
            // 
            // lblQaDetailPackSizeLabel
            // 
            this.lblQaDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPackSizeLabel.AutoSize = true;
            this.lblQaDetailPackSizeLabel.Location = new System.Drawing.Point(739, 80);
            this.lblQaDetailPackSizeLabel.Name = "lblQaDetailPackSizeLabel";
            this.lblQaDetailPackSizeLabel.Size = new System.Drawing.Size(72, 20);
            this.lblQaDetailPackSizeLabel.TabIndex = 18;
            this.lblQaDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtQaDetailPackSize
            // 
            this.txtQaDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPackSize.Location = new System.Drawing.Point(817, 83);
            this.txtQaDetailPackSize.Name = "txtQaDetailPackSize";
            this.txtQaDetailPackSize.ReadOnly = true;
            this.txtQaDetailPackSize.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailPackSize.TabIndex = 19;
            // 
            // lblQaDetailPreparedByLabel
            // 
            this.lblQaDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPreparedByLabel.AutoSize = true;
            this.lblQaDetailPreparedByLabel.Location = new System.Drawing.Point(65, 100);
            this.lblQaDetailPreparedByLabel.Name = "lblQaDetailPreparedByLabel";
            this.lblQaDetailPreparedByLabel.Size = new System.Drawing.Size(92, 20);
            this.lblQaDetailPreparedByLabel.TabIndex = 20;
            this.lblQaDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtQaDetailPreparedBy
            // 
            this.txtQaDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPreparedBy.Location = new System.Drawing.Point(163, 103);
            this.txtQaDetailPreparedBy.Name = "txtQaDetailPreparedBy";
            this.txtQaDetailPreparedBy.ReadOnly = true;
            this.txtQaDetailPreparedBy.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailPreparedBy.TabIndex = 21;
            // 
            // lblQaDetailRequestedAtLabel
            // 
            this.lblQaDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestedAtLabel.AutoSize = true;
            this.lblQaDetailRequestedAtLabel.Location = new System.Drawing.Point(710, 100);
            this.lblQaDetailRequestedAtLabel.Name = "lblQaDetailRequestedAtLabel";
            this.lblQaDetailRequestedAtLabel.Size = new System.Drawing.Size(101, 20);
            this.lblQaDetailRequestedAtLabel.TabIndex = 22;
            this.lblQaDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtQaDetailRequestedAt
            // 
            this.txtQaDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestedAt.Location = new System.Drawing.Point(817, 103);
            this.txtQaDetailRequestedAt.Name = "txtQaDetailRequestedAt";
            this.txtQaDetailRequestedAt.ReadOnly = true;
            this.txtQaDetailRequestedAt.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailRequestedAt.TabIndex = 23;
            // 
            // lblQaDetailRequesterCommentsLabel
            // 
            this.lblQaDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailRequesterCommentsLabel.AutoSize = true;
            this.lblQaDetailRequesterCommentsLabel.Location = new System.Drawing.Point(4, 120);
            this.lblQaDetailRequesterCommentsLabel.Name = "lblQaDetailRequesterCommentsLabel";
            this.lblQaDetailRequesterCommentsLabel.Size = new System.Drawing.Size(153, 20);
            this.lblQaDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblQaDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtQaDetailRequesterComments
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailRequesterComments, 3);
            this.txtQaDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailRequesterComments.Location = new System.Drawing.Point(163, 123);
            this.txtQaDetailRequesterComments.Multiline = true;
            this.txtQaDetailRequesterComments.Name = "txtQaDetailRequesterComments";
            this.txtQaDetailRequesterComments.ReadOnly = true;
            this.txtQaDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailRequesterComments.Size = new System.Drawing.Size(1142, 14);
            this.txtQaDetailRequesterComments.TabIndex = 25;
            // 
            // lblQaDetailGmCommentLabel
            // 
            this.lblQaDetailGmCommentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailGmCommentLabel.AutoSize = true;
            this.lblQaDetailGmCommentLabel.Location = new System.Drawing.Point(47, 140);
            this.lblQaDetailGmCommentLabel.Name = "lblQaDetailGmCommentLabel";
            this.lblQaDetailGmCommentLabel.Size = new System.Drawing.Size(110, 20);
            this.lblQaDetailGmCommentLabel.TabIndex = 26;
            this.lblQaDetailGmCommentLabel.Text = "GM Comments:";
            // 
            // txtQaDetailGmComment
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailGmComment, 3);
            this.txtQaDetailGmComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailGmComment.Location = new System.Drawing.Point(163, 143);
            this.txtQaDetailGmComment.Multiline = true;
            this.txtQaDetailGmComment.Name = "txtQaDetailGmComment";
            this.txtQaDetailGmComment.ReadOnly = true;
            this.txtQaDetailGmComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailGmComment.Size = new System.Drawing.Size(1142, 14);
            this.txtQaDetailGmComment.TabIndex = 27;
            // 
            // lblQaDetailGmActionTimeLabel
            // 
            this.lblQaDetailGmActionTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailGmActionTimeLabel.AutoSize = true;
            this.lblQaDetailGmActionTimeLabel.Location = new System.Drawing.Point(38, 160);
            this.lblQaDetailGmActionTimeLabel.Name = "lblQaDetailGmActionTimeLabel";
            this.lblQaDetailGmActionTimeLabel.Size = new System.Drawing.Size(119, 20);
            this.lblQaDetailGmActionTimeLabel.TabIndex = 28;
            this.lblQaDetailGmActionTimeLabel.Text = "GM Action Time:";
            // 
            // txtQaDetailGmActionTime
            // 
            this.txtQaDetailGmActionTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailGmActionTime.Location = new System.Drawing.Point(163, 163);
            this.txtQaDetailGmActionTime.Name = "txtQaDetailGmActionTime";
            this.txtQaDetailGmActionTime.ReadOnly = true;
            this.txtQaDetailGmActionTime.Size = new System.Drawing.Size(488, 27);
            this.txtQaDetailGmActionTime.TabIndex = 29;
            // 
            // grpQaAction
            // 
            this.grpQaAction.Controls.Add(this.tlpQaActionControls);
            this.grpQaAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpQaAction.Location = new System.Drawing.Point(3, 188);
            this.grpQaAction.Name = "grpQaAction";
            this.grpQaAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaAction.Size = new System.Drawing.Size(1328, 214);
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
            this.tlpQaActionControls.Location = new System.Drawing.Point(10, 32);
            this.tlpQaActionControls.Name = "tlpQaActionControls";
            this.tlpQaActionControls.RowCount = 4;
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaActionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpQaActionControls.Size = new System.Drawing.Size(1308, 172);
            this.tlpQaActionControls.TabIndex = 0;
            // 
            // flpQaOptionalControls
            // 
            this.flpQaOptionalControls.Controls.Add(this.lblQaPrintCount);
            this.flpQaOptionalControls.Controls.Add(this.numQaPrintCount);
            this.flpQaOptionalControls.Controls.Add(this.btnQaBrowseSelectDocument);
            this.flpQaOptionalControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQaOptionalControls.Location = new System.Drawing.Point(3, 3);
            this.flpQaOptionalControls.Name = "flpQaOptionalControls";
            this.flpQaOptionalControls.Size = new System.Drawing.Size(1302, 34);
            this.flpQaOptionalControls.TabIndex = 0;
            this.flpQaOptionalControls.WrapContents = false;
            // 
            // lblQaPrintCount
            // 
            this.lblQaPrintCount.AutoSize = true;
            this.lblQaPrintCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQaPrintCount.Location = new System.Drawing.Point(3, 8);
            this.lblQaPrintCount.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.lblQaPrintCount.Name = "lblQaPrintCount";
            this.lblQaPrintCount.Size = new System.Drawing.Size(85, 20);
            this.lblQaPrintCount.TabIndex = 0;
            this.lblQaPrintCount.Text = "Print Count:";
            // 
            // numQaPrintCount
            // 
            this.numQaPrintCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numQaPrintCount.Location = new System.Drawing.Point(94, 5);
            this.numQaPrintCount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.numQaPrintCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQaPrintCount.Name = "numQaPrintCount";
            this.numQaPrintCount.Size = new System.Drawing.Size(70, 27);
            this.numQaPrintCount.TabIndex = 1;
            this.numQaPrintCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numQaPrintCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnQaBrowseSelectDocument
            // 
            this.btnQaBrowseSelectDocument.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQaBrowseSelectDocument.Location = new System.Drawing.Point(170, 3);
            this.btnQaBrowseSelectDocument.Name = "btnQaBrowseSelectDocument";
            this.btnQaBrowseSelectDocument.Size = new System.Drawing.Size(180, 30);
            this.btnQaBrowseSelectDocument.TabIndex = 2;
            this.btnQaBrowseSelectDocument.Text = "Open Document Location";
            this.btnQaBrowseSelectDocument.UseVisualStyleBackColor = true;
            // 
            // lblQaComment
            // 
            this.lblQaComment.AutoSize = true;
            this.lblQaComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQaComment.Location = new System.Drawing.Point(3, 40);
            this.lblQaComment.Name = "lblQaComment";
            this.lblQaComment.Size = new System.Drawing.Size(108, 20);
            this.lblQaComment.TabIndex = 1;
            this.lblQaComment.Text = "QA Comments:";
            // 
            // txtQaComment
            // 
            this.txtQaComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQaComment.Location = new System.Drawing.Point(3, 63);
            this.txtQaComment.Multiline = true;
            this.txtQaComment.Name = "txtQaComment";
            this.txtQaComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaComment.Size = new System.Drawing.Size(1302, 61);
            this.txtQaComment.TabIndex = 2;
            // 
            // flpQaActionButtons
            // 
            this.flpQaActionButtons.Controls.Add(this.btnQaApprove);
            this.flpQaActionButtons.Controls.Add(this.btnQaReject);
            this.flpQaActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQaActionButtons.Location = new System.Drawing.Point(3, 130);
            this.flpQaActionButtons.Name = "flpQaActionButtons";
            this.flpQaActionButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpQaActionButtons.Size = new System.Drawing.Size(1302, 39);
            this.flpQaActionButtons.TabIndex = 3;
            // 
            // btnQaApprove
            // 
            this.btnQaApprove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnQaApprove.Location = new System.Drawing.Point(3, 8);
            this.btnQaApprove.Name = "btnQaApprove";
            this.btnQaApprove.Size = new System.Drawing.Size(120, 30);
            this.btnQaApprove.TabIndex = 0;
            this.btnQaApprove.Text = "Approve";
            this.btnQaApprove.UseVisualStyleBackColor = true;
            // 
            // btnQaReject
            // 
            this.btnQaReject.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnQaReject.Location = new System.Drawing.Point(129, 8);
            this.btnQaReject.Name = "btnQaReject";
            this.btnQaReject.Size = new System.Drawing.Size(120, 30);
            this.btnQaReject.TabIndex = 1;
            this.btnQaReject.Text = "Reject";
            this.btnQaReject.UseVisualStyleBackColor = true;
            // 
            // tabPageAuditTrail
            // 
            this.tabPageAuditTrail.Controls.Add(this.tlpAuditTrailMain);
            this.tabPageAuditTrail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabPageAuditTrail.Location = new System.Drawing.Point(4, 30);
            this.tabPageAuditTrail.Name = "tabPageAuditTrail";
            this.tabPageAuditTrail.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageAuditTrail.Size = new System.Drawing.Size(1360, 652);
            this.tabPageAuditTrail.TabIndex = 4;
            this.tabPageAuditTrail.Text = "Audit Trail";
            this.tabPageAuditTrail.UseVisualStyleBackColor = true;
            // 
            // tlpAuditTrailMain
            // 
            this.tlpAuditTrailMain.ColumnCount = 1;
            this.tlpAuditTrailMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuditTrailMain.Controls.Add(this.grpAuditFilters, 0, 0);
            this.tlpAuditTrailMain.Controls.Add(this.dgvAuditTrail, 0, 1);
            this.tlpAuditTrailMain.Controls.Add(this.flpAuditExportButtons, 0, 2);
            this.tlpAuditTrailMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuditTrailMain.Location = new System.Drawing.Point(10, 10);
            this.tlpAuditTrailMain.Name = "tlpAuditTrailMain";
            this.tlpAuditTrailMain.RowCount = 3;
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpAuditTrailMain.Size = new System.Drawing.Size(1340, 632);
            this.tlpAuditTrailMain.TabIndex = 0;
            // 
            // grpAuditFilters
            // 
            this.grpAuditFilters.AutoSize = true;
            this.grpAuditFilters.Controls.Add(this.tlpAuditFilters);
            this.grpAuditFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAuditFilters.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpAuditFilters.Location = new System.Drawing.Point(3, 3);
            this.grpAuditFilters.Name = "grpAuditFilters";
            this.grpAuditFilters.Padding = new System.Windows.Forms.Padding(10);
            this.grpAuditFilters.Size = new System.Drawing.Size(1334, 112);
            this.grpAuditFilters.TabIndex = 0;
            this.grpAuditFilters.TabStop = false;
            this.grpAuditFilters.Text = "Filter Audit Trail";
            // 
            // tlpAuditFilters
            // 
            this.tlpAuditFilters.AutoSize = true;
            this.tlpAuditFilters.ColumnCount = 8;
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpAuditFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuditFilters.Controls.Add(this.lblAuditFromDate, 0, 0);
            this.tlpAuditFilters.Controls.Add(this.dtpAuditFrom, 1, 0);
            this.tlpAuditFilters.Controls.Add(this.lblAuditToDate, 2, 0);
            this.tlpAuditFilters.Controls.Add(this.dtpAuditTo, 3, 0);
            this.tlpAuditFilters.Controls.Add(this.lblAuditStatus, 4, 0);
            this.tlpAuditFilters.Controls.Add(this.cmbAuditStatus, 5, 0);
            this.tlpAuditFilters.Controls.Add(this.lblAuditRequestNo, 0, 1);
            this.tlpAuditFilters.Controls.Add(this.txtAuditRequestNo, 1, 1);
            this.tlpAuditFilters.Controls.Add(this.lblAuditProduct, 2, 1);
            this.tlpAuditFilters.Controls.Add(this.txtAuditProduct, 3, 1);
            this.tlpAuditFilters.Controls.Add(this.btnApplyAuditFilter, 4, 1);
            this.tlpAuditFilters.Controls.Add(this.btnClearAuditFilters, 5, 1);
            this.tlpAuditFilters.Controls.Add(this.btnRefreshAuditList, 6, 1);
            this.tlpAuditFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuditFilters.Location = new System.Drawing.Point(10, 32);
            this.tlpAuditFilters.Name = "tlpAuditFilters";
            this.tlpAuditFilters.RowCount = 2;
            this.tlpAuditFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAuditFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAuditFilters.Size = new System.Drawing.Size(1314, 70);
            this.tlpAuditFilters.TabIndex = 0;
            // 
            // lblAuditFromDate
            // 
            this.lblAuditFromDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditFromDate.AutoSize = true;
            this.lblAuditFromDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAuditFromDate.Location = new System.Drawing.Point(12, 6);
            this.lblAuditFromDate.Name = "lblAuditFromDate";
            this.lblAuditFromDate.Size = new System.Drawing.Size(94, 23);
            this.lblAuditFromDate.TabIndex = 0;
            this.lblAuditFromDate.Text = "From Date:";
            // 
            // dtpAuditFrom
            // 
            this.dtpAuditFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpAuditFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditFrom.Location = new System.Drawing.Point(112, 3);
            this.dtpAuditFrom.Name = "dtpAuditFrom";
            this.dtpAuditFrom.Size = new System.Drawing.Size(144, 29);
            this.dtpAuditFrom.TabIndex = 1;
            // 
            // lblAuditToDate
            // 
            this.lblAuditToDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditToDate.AutoSize = true;
            this.lblAuditToDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAuditToDate.Location = new System.Drawing.Point(264, 6);
            this.lblAuditToDate.Name = "lblAuditToDate";
            this.lblAuditToDate.Size = new System.Drawing.Size(72, 23);
            this.lblAuditToDate.TabIndex = 2;
            this.lblAuditToDate.Text = "To Date:";
            // 
            // dtpAuditTo
            // 
            this.dtpAuditTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpAuditTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditTo.Location = new System.Drawing.Point(342, 3);
            this.dtpAuditTo.Name = "dtpAuditTo";
            this.dtpAuditTo.Size = new System.Drawing.Size(144, 29);
            this.dtpAuditTo.TabIndex = 3;
            // 
            // lblAuditStatus
            // 
            this.lblAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditStatus.AutoSize = true;
            this.lblAuditStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAuditStatus.Location = new System.Drawing.Point(552, 6);
            this.lblAuditStatus.Name = "lblAuditStatus";
            this.lblAuditStatus.Size = new System.Drawing.Size(60, 23);
            this.lblAuditStatus.TabIndex = 4;
            this.lblAuditStatus.Text = "Status:";
            // 
            // cmbAuditStatus
            // 
            this.cmbAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbAuditStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAuditStatus.FormattingEnabled = true;
            this.cmbAuditStatus.Location = new System.Drawing.Point(618, 3);
            this.cmbAuditStatus.Name = "cmbAuditStatus";
            this.cmbAuditStatus.Size = new System.Drawing.Size(174, 29);
            this.cmbAuditStatus.TabIndex = 5;
            // 
            // lblAuditRequestNo
            // 
            this.lblAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditRequestNo.AutoSize = true;
            this.lblAuditRequestNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAuditRequestNo.Location = new System.Drawing.Point(3, 41);
            this.lblAuditRequestNo.Name = "lblAuditRequestNo";
            this.lblAuditRequestNo.Size = new System.Drawing.Size(103, 23);
            this.lblAuditRequestNo.TabIndex = 6;
            this.lblAuditRequestNo.Text = "Request No:";
            // 
            // txtAuditRequestNo
            // 
            this.txtAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditRequestNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAuditRequestNo.Location = new System.Drawing.Point(112, 38);
            this.txtAuditRequestNo.Name = "txtAuditRequestNo";
            this.txtAuditRequestNo.Size = new System.Drawing.Size(144, 29);
            this.txtAuditRequestNo.TabIndex = 7;
            // 
            // lblAuditProduct
            // 
            this.lblAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditProduct.AutoSize = true;
            this.lblAuditProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAuditProduct.Location = new System.Drawing.Point(262, 41);
            this.lblAuditProduct.Name = "lblAuditProduct";
            this.lblAuditProduct.Size = new System.Drawing.Size(74, 23);
            this.lblAuditProduct.TabIndex = 8;
            this.lblAuditProduct.Text = "Product:";
            // 
            // txtAuditProduct
            // 
            this.txtAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAuditProduct.Location = new System.Drawing.Point(342, 38);
            this.txtAuditProduct.Name = "txtAuditProduct";
            this.txtAuditProduct.Size = new System.Drawing.Size(144, 29);
            this.txtAuditProduct.TabIndex = 9;
            // 
            // btnApplyAuditFilter
            // 
            this.btnApplyAuditFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApplyAuditFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApplyAuditFilter.Location = new System.Drawing.Point(492, 38);
            this.btnApplyAuditFilter.Name = "btnApplyAuditFilter";
            this.btnApplyAuditFilter.Size = new System.Drawing.Size(120, 29);
            this.btnApplyAuditFilter.TabIndex = 10;
            this.btnApplyAuditFilter.Text = "Apply Filters";
            this.btnApplyAuditFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearAuditFilters
            // 
            this.btnClearAuditFilters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearAuditFilters.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnClearAuditFilters.Location = new System.Drawing.Point(618, 38);
            this.btnClearAuditFilters.Name = "btnClearAuditFilters";
            this.btnClearAuditFilters.Size = new System.Drawing.Size(120, 29);
            this.btnClearAuditFilters.TabIndex = 11;
            this.btnClearAuditFilters.Text = "Clear Filters";
            this.btnClearAuditFilters.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAuditList
            // 
            this.btnRefreshAuditList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefreshAuditList.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRefreshAuditList.Location = new System.Drawing.Point(798, 38);
            this.btnRefreshAuditList.Name = "btnRefreshAuditList";
            this.btnRefreshAuditList.Size = new System.Drawing.Size(120, 29);
            this.btnRefreshAuditList.TabIndex = 12;
            this.btnRefreshAuditList.Text = "Refresh List";
            this.btnRefreshAuditList.UseVisualStyleBackColor = true;
            // 
            // dgvAuditTrail
            // 
            this.dgvAuditTrail.AllowUserToAddRows = false;
            this.dgvAuditTrail.AllowUserToDeleteRows = false;
            this.dgvAuditTrail.AllowUserToResizeColumns = false;
            this.dgvAuditTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "NA";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditTrail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditTrail.Location = new System.Drawing.Point(3, 121);
            this.dgvAuditTrail.Name = "dgvAuditTrail";
            this.dgvAuditTrail.ReadOnly = true;
            this.dgvAuditTrail.RowHeadersWidth = 51;
            this.dgvAuditTrail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditTrail.Size = new System.Drawing.Size(1334, 463);
            this.dgvAuditTrail.TabIndex = 1;
            // 
            // flpAuditExportButtons
            // 
            this.flpAuditExportButtons.Controls.Add(this.btnExportToCsv);
            this.flpAuditExportButtons.Controls.Add(this.btnExportToExcel);
            this.flpAuditExportButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAuditExportButtons.Location = new System.Drawing.Point(3, 590);
            this.flpAuditExportButtons.Name = "flpAuditExportButtons";
            this.flpAuditExportButtons.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpAuditExportButtons.Size = new System.Drawing.Size(1334, 39);
            this.flpAuditExportButtons.TabIndex = 2;
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportToCsv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportToCsv.Location = new System.Drawing.Point(8, 4);
            this.btnExportToCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(130, 30);
            this.btnExportToCsv.TabIndex = 0;
            this.btnExportToCsv.Text = "Export to CSV";
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportToExcel.Location = new System.Drawing.Point(144, 4);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(130, 30);
            this.btnExportToExcel.TabIndex = 1;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Location = new System.Drawing.Point(4, 30);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1360, 652);
            this.tabPageUsers.TabIndex = 5;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelSpring,
            this.toolStripStatusLabelDateTime});
            this.statusStripMain.Location = new System.Drawing.Point(0, 686);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1368, 34);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(156, 28);
            this.toolStripStatusLabelUser.Text = "User: Loading...";
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(986, 28);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // toolStripStatusLabelDateTime
            // 
            this.toolStripStatusLabelDateTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            this.toolStripStatusLabelDateTime.Size = new System.Drawing.Size(211, 28);
            this.toolStripStatusLabelDateTime.Text = "Date Time: Loading...";
            this.toolStripStatusLabelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 720);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Issuance App (BMR/BPR - Requests)";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.panelLoginContainer.ResumeLayout(false);
            this.panelLoginContainer.PerformLayout();
            this.tabPageDocumentIssuance.ResumeLayout(false);
            this.tlpDocumentIssuanceMain.ResumeLayout(false);
            this.tlpDocumentIssuanceMain.PerformLayout();
            this.tlpTopSectionDI.ResumeLayout(false);
            this.grpDocTypeDI.ResumeLayout(false);
            this.grpDocTypeDI.PerformLayout();
            this.pnlTopRightDI.ResumeLayout(false);
            this.pnlTopRightDI.PerformLayout();
            this.pnlRequestDetailsDI.ResumeLayout(false);
            this.pnlRequestDetailsDI.PerformLayout();
            this.tlpRequestDetails.ResumeLayout(false);
            this.tlpRequestDetails.PerformLayout();
            this.grpParentBatchInfoDI.ResumeLayout(false);
            this.grpParentBatchInfoDI.PerformLayout();
            this.tlpParentBatchInfo.ResumeLayout(false);
            this.tlpParentBatchInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParentBatchSizeDI)).EndInit();
            this.grpItemDetailsDI.ResumeLayout(false);
            this.grpItemDetailsDI.PerformLayout();
            this.tlpItemDetails.ResumeLayout(false);
            this.tlpItemDetails.PerformLayout();
            this.grpRemarksDI.ResumeLayout(false);
            this.grpRemarksDI.PerformLayout();
            this.pnlActionBottomDI.ResumeLayout(false);
            this.pnlStatusDI.ResumeLayout(false);
            this.pnlStatusDI.PerformLayout();
            this.tabPageGmOperations.ResumeLayout(false);
            this.tlpGmOperationsMain.ResumeLayout(false);
            this.pnlGmTopSection.ResumeLayout(false);
            this.tlpGmTopControls.ResumeLayout(false);
            this.pnlGmQueueHeader.ResumeLayout(false);
            this.pnlGmQueueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGmQueue)).EndInit();
            this.tlpGmBottomSection.ResumeLayout(false);
            this.grpGmSelectedRequest.ResumeLayout(false);
            this.tlpGmRequestDetails.ResumeLayout(false);
            this.tlpGmRequestDetails.PerformLayout();
            this.grpGmAction.ResumeLayout(false);
            this.tlpGmActionControls.ResumeLayout(false);
            this.tlpGmActionControls.PerformLayout();
            this.flpGmActionButtons.ResumeLayout(false);
            this.tabPageQa.ResumeLayout(false);
            this.tlpQaOperationsMain.ResumeLayout(false);
            this.pnlQaTopSection.ResumeLayout(false);
            this.tlpQaTopControls.ResumeLayout(false);
            this.pnlQaQueueHeader.ResumeLayout(false);
            this.pnlQaQueueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQaQueue)).EndInit();
            this.tlpQaBottomSection.ResumeLayout(false);
            this.grpQaSelectedRequest.ResumeLayout(false);
            this.tlpQaRequestDetails.ResumeLayout(false);
            this.tlpQaRequestDetails.PerformLayout();
            this.grpQaAction.ResumeLayout(false);
            this.tlpQaActionControls.ResumeLayout(false);
            this.tlpQaActionControls.PerformLayout();
            this.flpQaOptionalControls.ResumeLayout(false);
            this.flpQaOptionalControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQaPrintCount)).EndInit();
            this.flpQaActionButtons.ResumeLayout(false);
            this.tabPageAuditTrail.ResumeLayout(false);
            this.tlpAuditTrailMain.ResumeLayout(false);
            this.tlpAuditTrailMain.PerformLayout();
            this.grpAuditFilters.ResumeLayout(false);
            this.grpAuditFilters.PerformLayout();
            this.tlpAuditFilters.ResumeLayout(false);
            this.tlpAuditFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).EndInit();
            this.flpAuditExportButtons.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Original control declarations (Login, DocIssuance, StatusStrip etc.) should be here
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.Panel panelLoginContainer;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TabPage tabPageDocumentIssuance;
        private System.Windows.Forms.TableLayoutPanel tlpDocumentIssuanceMain;
        private System.Windows.Forms.Label lblHeaderDI;
        private System.Windows.Forms.TableLayoutPanel tlpTopSectionDI;
        private System.Windows.Forms.GroupBox grpDocTypeDI;
        private System.Windows.Forms.CheckBox chkDocTypeAddendumDI;
        private System.Windows.Forms.CheckBox chkDocTypeAppendixDI;
        private System.Windows.Forms.CheckBox chkDocTypeBPRDI;
        private System.Windows.Forms.CheckBox chkDocTypeBMRDI;
        private System.Windows.Forms.Panel pnlTopRightDI;
        private System.Windows.Forms.TextBox txtRequestNoValueDI;
        private System.Windows.Forms.Label lblRequestNoLabelDI;
        private System.Windows.Forms.Label lblTrackerNoValueDI;
        private System.Windows.Forms.Label lblTrackerNoLabelDI;
        private System.Windows.Forms.Panel pnlRequestDetailsDI;
        private System.Windows.Forms.TableLayoutPanel tlpRequestDetails;
        private System.Windows.Forms.Label lblRequestDateDI;
        private System.Windows.Forms.DateTimePicker dtpRequestDateDI;
        private System.Windows.Forms.Label lblFromDepartmentDI;
        private System.Windows.Forms.ComboBox cmbFromDepartmentDI;
        private System.Windows.Forms.GroupBox grpParentBatchInfoDI;
        private System.Windows.Forms.TableLayoutPanel tlpParentBatchInfo;
        private System.Windows.Forms.Label lblParentBatchNoDI;
        private System.Windows.Forms.TextBox txtParentBatchNoDI;
        private System.Windows.Forms.Label lblParentBatchSizeDI;
        private System.Windows.Forms.NumericUpDown numParentBatchSizeDI;
        private System.Windows.Forms.Label lblParentMfgDateDI;
        private System.Windows.Forms.DateTimePicker dtpParentMfgDateDI;
        private System.Windows.Forms.Label lblParentExpDateDI;
        private System.Windows.Forms.DateTimePicker dtpParentExpDateDI;
        private System.Windows.Forms.GroupBox grpItemDetailsDI;
        private System.Windows.Forms.TableLayoutPanel tlpItemDetails;
        private System.Windows.Forms.Label lblProductDI;
        private System.Windows.Forms.TextBox txtProductDI;
        private System.Windows.Forms.Label lblDocumentNoDI;
        private System.Windows.Forms.TextBox txtDocumentNoDI;
        private System.Windows.Forms.Label lblBatchNoDI;
        private System.Windows.Forms.TextBox txtBatchNoDI;
        private System.Windows.Forms.Label lblBatchSizeDI;
        private System.Windows.Forms.TextBox txtBatchSizeDI;
        private System.Windows.Forms.Label lblItemMfgDateDI;
        private System.Windows.Forms.DateTimePicker dtpItemMfgDateDI;
        private System.Windows.Forms.Label lblItemExpDateDI;
        private System.Windows.Forms.DateTimePicker dtpItemExpDateDI;
        private System.Windows.Forms.Label lblMarketDI;
        private System.Windows.Forms.TextBox txtMarketDI;
        private System.Windows.Forms.Label lblPackSizeDI;
        private System.Windows.Forms.TextBox txtPackSizeDI;
        private System.Windows.Forms.Label lblExportOrderNoDI;
        private System.Windows.Forms.TextBox txtExportOrderNoDI;
        private System.Windows.Forms.GroupBox grpRemarksDI;
        private System.Windows.Forms.TextBox txtRemarksDI;
        private System.Windows.Forms.Panel pnlActionBottomDI;
        private System.Windows.Forms.Button btnClearFormDI;
        private System.Windows.Forms.Button btnSubmitRequestDI;
        private System.Windows.Forms.Panel pnlStatusDI;
        private System.Windows.Forms.Label lblStatusValueDI;
        private System.Windows.Forms.Label lblStatusLabelDI;
        private System.Windows.Forms.TabPage tabPageQa;
        private System.Windows.Forms.TabPage tabPageAuditTrail;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDateTime;
        // GM Operations Tab Controls - Declarations should be consolidated here
        private System.Windows.Forms.TabPage tabPageGmOperations; // Ensure this is declared
        private System.Windows.Forms.TableLayoutPanel tlpGmOperationsMain;
        private System.Windows.Forms.Panel pnlGmTopSection;
        private System.Windows.Forms.TableLayoutPanel tlpGmTopControls;
        private System.Windows.Forms.Panel pnlGmQueueHeader;
        private System.Windows.Forms.Label lblGmQueueTitle;
        private System.Windows.Forms.Button btnGmRefreshList;
        private System.Windows.Forms.DataGridView dgvGmQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGmRequestedAt;
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
        private System.Windows.Forms.Button btnGmAuthorize;
        private System.Windows.Forms.Button btnGmReject;
        // QA Tab Controls
        private System.Windows.Forms.TableLayoutPanel tlpQaOperationsMain;
        private System.Windows.Forms.Panel pnlQaTopSection;
        private System.Windows.Forms.TableLayoutPanel tlpQaTopControls;
        private System.Windows.Forms.Panel pnlQaQueueHeader;
        private System.Windows.Forms.Label lblQaQueueTitle;
        private System.Windows.Forms.Button btnQaRefreshList;
        private System.Windows.Forms.DataGridView dgvQaQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaAuthorizedBy; // GM
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaGmActionAt;
        private System.Windows.Forms.TableLayoutPanel tlpQaBottomSection;
        private System.Windows.Forms.GroupBox grpQaSelectedRequest;
        private System.Windows.Forms.TableLayoutPanel tlpQaRequestDetails;
        // Labels and TextBoxes for QA Selected Request Details (mirroring GM tab + GM info)
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
        private System.Windows.Forms.Label lblQaDetailGmCommentLabel; // New for QA: GM's Comments
        private System.Windows.Forms.TextBox txtQaDetailGmComment;   // New for QA
        private System.Windows.Forms.Label lblQaDetailGmActionTimeLabel; // New for QA: GM's Action Time
        private System.Windows.Forms.TextBox txtQaDetailGmActionTime;  // New for QA
        private System.Windows.Forms.GroupBox grpQaAction;
        private System.Windows.Forms.TableLayoutPanel tlpQaActionControls;
        private System.Windows.Forms.FlowLayoutPanel flpQaOptionalControls; // For Print Count and Browse
        private System.Windows.Forms.Label lblQaPrintCount;
        private System.Windows.Forms.NumericUpDown numQaPrintCount;
        private System.Windows.Forms.Button btnQaBrowseSelectDocument;
        private System.Windows.Forms.Label lblQaComment;
        private System.Windows.Forms.TextBox txtQaComment;
        private System.Windows.Forms.FlowLayoutPanel flpQaActionButtons;
        private System.Windows.Forms.Button btnQaApprove;
        private System.Windows.Forms.Button btnQaReject;
        // --- Audit Trail Tab Control Declarations ---
        private System.Windows.Forms.TableLayoutPanel tlpAuditTrailMain;
        private System.Windows.Forms.GroupBox grpAuditFilters;
        private System.Windows.Forms.TableLayoutPanel tlpAuditFilters;
        private System.Windows.Forms.Label lblAuditFromDate;
        private System.Windows.Forms.DateTimePicker dtpAuditFrom;
        private System.Windows.Forms.Label lblAuditToDate;
        private System.Windows.Forms.DateTimePicker dtpAuditTo;
        private System.Windows.Forms.Label lblAuditStatus;
        private System.Windows.Forms.ComboBox cmbAuditStatus;
        private System.Windows.Forms.Label lblAuditRequestNo;
        private System.Windows.Forms.TextBox txtAuditRequestNo;
        private System.Windows.Forms.Label lblAuditProduct;
        private System.Windows.Forms.TextBox txtAuditProduct;
        private System.Windows.Forms.Button btnApplyAuditFilter;
        private System.Windows.Forms.Button btnClearAuditFilters;
        private System.Windows.Forms.DataGridView dgvAuditTrail;
        private System.Windows.Forms.FlowLayoutPanel flpAuditExportButtons;
        private System.Windows.Forms.Button btnExportToCsv;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnRefreshAuditList;
    }
}
