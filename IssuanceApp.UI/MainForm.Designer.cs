// MainForm.Designer.cs
// This code is typically auto-generated and managed by the Visual Studio WinForms Designer.
using System.Drawing;
using System.Windows.Forms;

namespace DocumentIssuanceApp
{
    partial class MainForm
    {
        #region Windows Form Designer generated code

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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tlpLoginMain = new System.Windows.Forms.TableLayoutPanel();
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
            this.tlpDocTypesAndNumbers = new System.Windows.Forms.TableLayoutPanel();
            this.chkDocTypeBMRDI = new System.Windows.Forms.CheckBox();
            this.lblBmrDocNo = new System.Windows.Forms.Label();
            this.txtBmrDocNoDI = new System.Windows.Forms.TextBox();
            this.chkDocTypeBPRDI = new System.Windows.Forms.CheckBox();
            this.txtBprDocNoDI = new System.Windows.Forms.TextBox();
            this.chkDocTypeAppendixDI = new System.Windows.Forms.CheckBox();
            this.lblAppendixDocNo = new System.Windows.Forms.Label();
            this.txtAppendixDocNoDI = new System.Windows.Forms.TextBox();
            this.chkDocTypeAddendumDI = new System.Windows.Forms.CheckBox();
            this.lblAddendumDocNo = new System.Windows.Forms.Label();
            this.txtAddendumDocNoDI = new System.Windows.Forms.TextBox();
            this.lblBprDocNo = new System.Windows.Forms.Label();
            this.pnlTopRightDI = new System.Windows.Forms.Panel();
            this.tlpTopRightDetailsDI = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrackerNoLabelDI = new System.Windows.Forms.Label();
            this.lblTrackerNoValueDI = new System.Windows.Forms.Label();
            this.lblRequestNoLabelDI = new System.Windows.Forms.Label();
            this.txtRequestNoValueDI = new System.Windows.Forms.TextBox();
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
            this.flpParentBatchSize = new System.Windows.Forms.FlowLayoutPanel();
            this.txtParentBatchSizeValueDI = new System.Windows.Forms.TextBox();
            this.cmbParentBatchSizeUnitDI = new System.Windows.Forms.ComboBox();
            this.lblParentMfgDateDI = new System.Windows.Forms.Label();
            this.flpParentMfgDate = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbParentMfgMonthDI = new System.Windows.Forms.ComboBox();
            this.cmbParentMfgYearDI = new System.Windows.Forms.ComboBox();
            this.lblParentExpDateDI = new System.Windows.Forms.Label();
            this.flpParentExpDate = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbParentExpMonthDI = new System.Windows.Forms.ComboBox();
            this.cmbParentExpYearDI = new System.Windows.Forms.ComboBox();
            this.grpItemDetailsDI = new System.Windows.Forms.GroupBox();
            this.tlpItemDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductDI = new System.Windows.Forms.Label();
            this.txtProductDI = new System.Windows.Forms.TextBox();
            this.lblBatchNoDI = new System.Windows.Forms.Label();
            this.txtBatchNoDI = new System.Windows.Forms.TextBox();
            this.lblBatchSizeDI = new System.Windows.Forms.Label();
            this.flpItemBatchSize = new System.Windows.Forms.FlowLayoutPanel();
            this.txtItemBatchSizeValueDI = new System.Windows.Forms.TextBox();
            this.cmbItemBatchSizeUnitDI = new System.Windows.Forms.ComboBox();
            this.lblItemMfgDateDI = new System.Windows.Forms.Label();
            this.flpItemMfgDate = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbItemMfgMonthDI = new System.Windows.Forms.ComboBox();
            this.cmbItemMfgYearDI = new System.Windows.Forms.ComboBox();
            this.lblItemExpDateDI = new System.Windows.Forms.Label();
            this.flpItemExpDate = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbItemExpMonthDI = new System.Windows.Forms.ComboBox();
            this.cmbItemExpYearDI = new System.Windows.Forms.ComboBox();
            this.lblMarketDI = new System.Windows.Forms.Label();
            this.txtMarketDI = new System.Windows.Forms.TextBox();
            this.lblPackSizeDI = new System.Windows.Forms.Label();
            this.txtPackSizeDI = new System.Windows.Forms.TextBox();
            this.lblExportOrderNoDI = new System.Windows.Forms.Label();
            this.txtExportOrderNoDI = new System.Windows.Forms.TextBox();
            this.grpRemarksDI = new System.Windows.Forms.GroupBox();
            this.txtRemarksDI = new System.Windows.Forms.TextBox();
            this.pnlActionBottomDI = new System.Windows.Forms.Panel();
            this.flpActionButtonsDI = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubmitRequestDI = new System.Windows.Forms.Button();
            this.btnClearFormDI = new System.Windows.Forms.Button();
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
            this.scUsersMain = new System.Windows.Forms.SplitContainer();
            this.dgvUserRoles = new System.Windows.Forms.DataGridView();
            this.colUserRoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpUserRolesHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblApplicationRoles = new System.Windows.Forms.Label();
            this.btnRefreshUserRoles = new System.Windows.Forms.Button();
            this.grpManageRole = new System.Windows.Forms.GroupBox();
            this.tlpManageRole = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoleNameManage = new System.Windows.Forms.Label();
            this.txtRoleNameManage = new System.Windows.Forms.TextBox();
            this.flpRoleManagementButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tlpLoginMain.SuspendLayout();
            this.panelLoginContainer.SuspendLayout();
            this.tabPageDocumentIssuance.SuspendLayout();
            this.tlpDocumentIssuanceMain.SuspendLayout();
            this.tlpTopSectionDI.SuspendLayout();
            this.grpDocTypeDI.SuspendLayout();
            this.tlpDocTypesAndNumbers.SuspendLayout();
            this.pnlTopRightDI.SuspendLayout();
            this.tlpTopRightDetailsDI.SuspendLayout();
            this.pnlRequestDetailsDI.SuspendLayout();
            this.tlpRequestDetails.SuspendLayout();
            this.grpParentBatchInfoDI.SuspendLayout();
            this.tlpParentBatchInfo.SuspendLayout();
            this.flpParentBatchSize.SuspendLayout();
            this.flpParentMfgDate.SuspendLayout();
            this.flpParentExpDate.SuspendLayout();
            this.grpItemDetailsDI.SuspendLayout();
            this.tlpItemDetails.SuspendLayout();
            this.flpItemBatchSize.SuspendLayout();
            this.flpItemMfgDate.SuspendLayout();
            this.flpItemExpDate.SuspendLayout();
            this.grpRemarksDI.SuspendLayout();
            this.pnlActionBottomDI.SuspendLayout();
            this.flpActionButtonsDI.SuspendLayout();
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
            this.tabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scUsersMain)).BeginInit();
            this.scUsersMain.Panel1.SuspendLayout();
            this.scUsersMain.Panel2.SuspendLayout();
            this.scUsersMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).BeginInit();
            this.tlpUserRolesHeader.SuspendLayout();
            this.grpManageRole.SuspendLayout();
            this.tlpManageRole.SuspendLayout();
            this.flpRoleManagementButtons.SuspendLayout();
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
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1368, 694);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.tlpLoginMain);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 30);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1360, 660);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tlpLoginMain
            // 
            this.tlpLoginMain.ColumnCount = 3;
            this.tlpLoginMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLoginMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpLoginMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLoginMain.Controls.Add(this.panelLoginContainer, 1, 1);
            this.tlpLoginMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoginMain.Location = new System.Drawing.Point(3, 3);
            this.tlpLoginMain.Name = "tlpLoginMain";
            this.tlpLoginMain.RowCount = 3;
            this.tlpLoginMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLoginMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLoginMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLoginMain.Size = new System.Drawing.Size(1354, 654);
            this.tlpLoginMain.TabIndex = 1;
            // 
            // panelLoginContainer
            // 
            this.panelLoginContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoginContainer.Controls.Add(this.lblLoginStatus);
            this.panelLoginContainer.Controls.Add(this.btnLogin);
            this.panelLoginContainer.Controls.Add(this.txtPassword);
            this.panelLoginContainer.Controls.Add(this.lblPassword);
            this.panelLoginContainer.Controls.Add(this.cmbRole);
            this.panelLoginContainer.Controls.Add(this.lblRole);
            this.panelLoginContainer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.panelLoginContainer.Location = new System.Drawing.Point(432, 213);
            this.panelLoginContainer.Name = "panelLoginContainer";
            this.panelLoginContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelLoginContainer.Size = new System.Drawing.Size(489, 228);
            this.panelLoginContainer.TabIndex = 0;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginStatus.Location = new System.Drawing.Point(82, 207);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(206, 21);
            this.lblLoginStatus.TabIndex = 5;
            this.lblLoginStatus.Text = "*Please login to continue.";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(146, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(142, 56);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(146, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(320, 35);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(29, 77);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(111, 30);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(146, 15);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(320, 38);
            this.cmbRole.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(14, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(126, 30);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Select Role:";
            // 
            // tabPageDocumentIssuance
            // 
            this.tabPageDocumentIssuance.AutoScroll = true;
            this.tabPageDocumentIssuance.Controls.Add(this.tlpDocumentIssuanceMain);
            this.tabPageDocumentIssuance.Location = new System.Drawing.Point(4, 30);
            this.tabPageDocumentIssuance.Name = "tabPageDocumentIssuance";
            this.tabPageDocumentIssuance.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageDocumentIssuance.Size = new System.Drawing.Size(1360, 660);
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
            this.tlpDocumentIssuanceMain.Size = new System.Drawing.Size(1340, 640);
            this.tlpDocumentIssuanceMain.TabIndex = 0;
            // 
            // lblHeaderDI
            // 
            this.lblHeaderDI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeaderDI.AutoSize = true;
            this.lblHeaderDI.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeaderDI.Location = new System.Drawing.Point(550, 5);
            this.lblHeaderDI.Name = "lblHeaderDI";
            this.lblHeaderDI.Size = new System.Drawing.Size(240, 30);
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
            this.tlpTopSectionDI.Size = new System.Drawing.Size(1334, 155);
            this.tlpTopSectionDI.TabIndex = 1;
            // 
            // grpDocTypeDI
            // 
            this.grpDocTypeDI.Controls.Add(this.tlpDocTypesAndNumbers);
            this.grpDocTypeDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDocTypeDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpDocTypeDI.Location = new System.Drawing.Point(3, 3);
            this.grpDocTypeDI.Name = "grpDocTypeDI";
            this.grpDocTypeDI.Size = new System.Drawing.Size(927, 149);
            this.grpDocTypeDI.TabIndex = 0;
            this.grpDocTypeDI.TabStop = false;
            this.grpDocTypeDI.Text = "Document Type";
            // 
            // tlpDocTypesAndNumbers
            // 
            this.tlpDocTypesAndNumbers.ColumnCount = 3;
            this.tlpDocTypesAndNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpDocTypesAndNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDocTypesAndNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDocTypesAndNumbers.Controls.Add(this.chkDocTypeBMRDI, 0, 0);
            this.tlpDocTypesAndNumbers.Controls.Add(this.lblBmrDocNo, 1, 0);
            this.tlpDocTypesAndNumbers.Controls.Add(this.txtBmrDocNoDI, 2, 0);
            this.tlpDocTypesAndNumbers.Controls.Add(this.chkDocTypeBPRDI, 0, 1);
            this.tlpDocTypesAndNumbers.Controls.Add(this.txtBprDocNoDI, 2, 1);
            this.tlpDocTypesAndNumbers.Controls.Add(this.chkDocTypeAppendixDI, 0, 2);
            this.tlpDocTypesAndNumbers.Controls.Add(this.lblAppendixDocNo, 1, 2);
            this.tlpDocTypesAndNumbers.Controls.Add(this.txtAppendixDocNoDI, 2, 2);
            this.tlpDocTypesAndNumbers.Controls.Add(this.chkDocTypeAddendumDI, 0, 3);
            this.tlpDocTypesAndNumbers.Controls.Add(this.lblAddendumDocNo, 1, 3);
            this.tlpDocTypesAndNumbers.Controls.Add(this.txtAddendumDocNoDI, 2, 3);
            this.tlpDocTypesAndNumbers.Controls.Add(this.lblBprDocNo, 1, 1);
            this.tlpDocTypesAndNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDocTypesAndNumbers.Location = new System.Drawing.Point(3, 21);
            this.tlpDocTypesAndNumbers.Name = "tlpDocTypesAndNumbers";
            this.tlpDocTypesAndNumbers.RowCount = 4;
            this.tlpDocTypesAndNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDocTypesAndNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDocTypesAndNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDocTypesAndNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDocTypesAndNumbers.Size = new System.Drawing.Size(921, 125);
            this.tlpDocTypesAndNumbers.TabIndex = 0;
            // 
            // chkDocTypeBMRDI
            // 
            this.chkDocTypeBMRDI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDocTypeBMRDI.AutoSize = true;
            this.chkDocTypeBMRDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkDocTypeBMRDI.Location = new System.Drawing.Point(3, 4);
            this.chkDocTypeBMRDI.Name = "chkDocTypeBMRDI";
            this.chkDocTypeBMRDI.Size = new System.Drawing.Size(55, 21);
            this.chkDocTypeBMRDI.TabIndex = 0;
            this.chkDocTypeBMRDI.Text = "BMR";
            this.chkDocTypeBMRDI.UseVisualStyleBackColor = true;
            // 
            // lblBmrDocNo
            // 
            this.lblBmrDocNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBmrDocNo.AutoSize = true;
            this.lblBmrDocNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBmrDocNo.Location = new System.Drawing.Point(146, 6);
            this.lblBmrDocNo.Name = "lblBmrDocNo";
            this.lblBmrDocNo.Size = new System.Drawing.Size(131, 17);
            this.lblBmrDocNo.TabIndex = 1;
            this.lblBmrDocNo.Text = "BMR Document No.:";
            this.lblBmrDocNo.Visible = false;
            // 
            // txtBmrDocNoDI
            // 
            this.txtBmrDocNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBmrDocNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBmrDocNoDI.Location = new System.Drawing.Point(283, 3);
            this.txtBmrDocNoDI.Name = "txtBmrDocNoDI";
            this.txtBmrDocNoDI.Size = new System.Drawing.Size(635, 25);
            this.txtBmrDocNoDI.TabIndex = 2;
            this.txtBmrDocNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBmrDocNoDI.Visible = false;
            // 
            // chkDocTypeBPRDI
            // 
            this.chkDocTypeBPRDI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDocTypeBPRDI.AutoSize = true;
            this.chkDocTypeBPRDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkDocTypeBPRDI.Location = new System.Drawing.Point(3, 34);
            this.chkDocTypeBPRDI.Name = "chkDocTypeBPRDI";
            this.chkDocTypeBPRDI.Size = new System.Drawing.Size(51, 21);
            this.chkDocTypeBPRDI.TabIndex = 3;
            this.chkDocTypeBPRDI.Text = "BPR";
            this.chkDocTypeBPRDI.UseVisualStyleBackColor = true;
            // 
            // txtBprDocNoDI
            // 
            this.txtBprDocNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBprDocNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBprDocNoDI.Location = new System.Drawing.Point(283, 33);
            this.txtBprDocNoDI.Name = "txtBprDocNoDI";
            this.txtBprDocNoDI.Size = new System.Drawing.Size(635, 25);
            this.txtBprDocNoDI.TabIndex = 5;
            this.txtBprDocNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBprDocNoDI.Visible = false;
            // 
            // chkDocTypeAppendixDI
            // 
            this.chkDocTypeAppendixDI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDocTypeAppendixDI.AutoSize = true;
            this.chkDocTypeAppendixDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkDocTypeAppendixDI.Location = new System.Drawing.Point(3, 64);
            this.chkDocTypeAppendixDI.Name = "chkDocTypeAppendixDI";
            this.chkDocTypeAppendixDI.Size = new System.Drawing.Size(85, 21);
            this.chkDocTypeAppendixDI.TabIndex = 6;
            this.chkDocTypeAppendixDI.Text = "Appendix";
            this.chkDocTypeAppendixDI.UseVisualStyleBackColor = true;
            // 
            // lblAppendixDocNo
            // 
            this.lblAppendixDocNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppendixDocNo.AutoSize = true;
            this.lblAppendixDocNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAppendixDocNo.Location = new System.Drawing.Point(156, 66);
            this.lblAppendixDocNo.Name = "lblAppendixDocNo";
            this.lblAppendixDocNo.Size = new System.Drawing.Size(121, 17);
            this.lblAppendixDocNo.TabIndex = 7;
            this.lblAppendixDocNo.Text = "Appendix Doc No.:";
            this.lblAppendixDocNo.Visible = false;
            // 
            // txtAppendixDocNoDI
            // 
            this.txtAppendixDocNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppendixDocNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAppendixDocNoDI.Location = new System.Drawing.Point(283, 63);
            this.txtAppendixDocNoDI.Name = "txtAppendixDocNoDI";
            this.txtAppendixDocNoDI.Size = new System.Drawing.Size(635, 25);
            this.txtAppendixDocNoDI.TabIndex = 8;
            this.txtAppendixDocNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAppendixDocNoDI.Visible = false;
            // 
            // chkDocTypeAddendumDI
            // 
            this.chkDocTypeAddendumDI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDocTypeAddendumDI.AutoSize = true;
            this.chkDocTypeAddendumDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkDocTypeAddendumDI.Location = new System.Drawing.Point(3, 97);
            this.chkDocTypeAddendumDI.Name = "chkDocTypeAddendumDI";
            this.chkDocTypeAddendumDI.Size = new System.Drawing.Size(95, 21);
            this.chkDocTypeAddendumDI.TabIndex = 9;
            this.chkDocTypeAddendumDI.Text = "Addendum";
            this.chkDocTypeAddendumDI.UseVisualStyleBackColor = true;
            // 
            // lblAddendumDocNo
            // 
            this.lblAddendumDocNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAddendumDocNo.AutoSize = true;
            this.lblAddendumDocNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAddendumDocNo.Location = new System.Drawing.Point(146, 99);
            this.lblAddendumDocNo.Name = "lblAddendumDocNo";
            this.lblAddendumDocNo.Size = new System.Drawing.Size(131, 17);
            this.lblAddendumDocNo.TabIndex = 10;
            this.lblAddendumDocNo.Text = "Addendum Doc No.:";
            this.lblAddendumDocNo.Visible = false;
            // 
            // txtAddendumDocNoDI
            // 
            this.txtAddendumDocNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddendumDocNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAddendumDocNoDI.Location = new System.Drawing.Point(283, 95);
            this.txtAddendumDocNoDI.Name = "txtAddendumDocNoDI";
            this.txtAddendumDocNoDI.Size = new System.Drawing.Size(635, 25);
            this.txtAddendumDocNoDI.TabIndex = 11;
            this.txtAddendumDocNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddendumDocNoDI.Visible = false;
            // 
            // lblBprDocNo
            // 
            this.lblBprDocNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBprDocNo.AutoSize = true;
            this.lblBprDocNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBprDocNo.Location = new System.Drawing.Point(150, 36);
            this.lblBprDocNo.Name = "lblBprDocNo";
            this.lblBprDocNo.Size = new System.Drawing.Size(127, 17);
            this.lblBprDocNo.TabIndex = 4;
            this.lblBprDocNo.Text = "BPR Document No.:";
            this.lblBprDocNo.Visible = false;
            // 
            // pnlTopRightDI
            // 
            this.pnlTopRightDI.Controls.Add(this.tlpTopRightDetailsDI);
            this.pnlTopRightDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRightDI.Location = new System.Drawing.Point(936, 3);
            this.pnlTopRightDI.Name = "pnlTopRightDI";
            this.pnlTopRightDI.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.pnlTopRightDI.Size = new System.Drawing.Size(395, 149);
            this.pnlTopRightDI.TabIndex = 1;
            // 
            // tlpTopRightDetailsDI
            // 
            this.tlpTopRightDetailsDI.ColumnCount = 2;
            this.tlpTopRightDetailsDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTopRightDetailsDI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopRightDetailsDI.Controls.Add(this.lblTrackerNoLabelDI, 0, 0);
            this.tlpTopRightDetailsDI.Controls.Add(this.lblTrackerNoValueDI, 1, 0);
            this.tlpTopRightDetailsDI.Controls.Add(this.lblRequestNoLabelDI, 0, 1);
            this.tlpTopRightDetailsDI.Controls.Add(this.txtRequestNoValueDI, 1, 1);
            this.tlpTopRightDetailsDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopRightDetailsDI.Location = new System.Drawing.Point(5, 10);
            this.tlpTopRightDetailsDI.Name = "tlpTopRightDetailsDI";
            this.tlpTopRightDetailsDI.RowCount = 2;
            this.tlpTopRightDetailsDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopRightDetailsDI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopRightDetailsDI.Size = new System.Drawing.Size(385, 134);
            this.tlpTopRightDetailsDI.TabIndex = 0;
            // 
            // lblTrackerNoLabelDI
            // 
            this.lblTrackerNoLabelDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTrackerNoLabelDI.AutoSize = true;
            this.lblTrackerNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTrackerNoLabelDI.Location = new System.Drawing.Point(9, 25);
            this.lblTrackerNoLabelDI.Name = "lblTrackerNoLabelDI";
            this.lblTrackerNoLabelDI.Size = new System.Drawing.Size(79, 17);
            this.lblTrackerNoLabelDI.TabIndex = 0;
            this.lblTrackerNoLabelDI.Text = "Tracker No.:";
            // 
            // lblTrackerNoValueDI
            // 
            this.lblTrackerNoValueDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrackerNoValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTrackerNoValueDI.Location = new System.Drawing.Point(94, 25);
            this.lblTrackerNoValueDI.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblTrackerNoValueDI.Name = "lblTrackerNoValueDI";
            this.lblTrackerNoValueDI.Size = new System.Drawing.Size(281, 17);
            this.lblTrackerNoValueDI.TabIndex = 1;
            this.lblTrackerNoValueDI.Text = "(empty)";
            this.lblTrackerNoValueDI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRequestNoLabelDI
            // 
            this.lblRequestNoLabelDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRequestNoLabelDI.AutoSize = true;
            this.lblRequestNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRequestNoLabelDI.Location = new System.Drawing.Point(3, 92);
            this.lblRequestNoLabelDI.Name = "lblRequestNoLabelDI";
            this.lblRequestNoLabelDI.Size = new System.Drawing.Size(85, 17);
            this.lblRequestNoLabelDI.TabIndex = 2;
            this.lblRequestNoLabelDI.Text = "Request No.:";
            // 
            // txtRequestNoValueDI
            // 
            this.txtRequestNoValueDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestNoValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRequestNoValueDI.Location = new System.Drawing.Point(94, 88);
            this.txtRequestNoValueDI.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.txtRequestNoValueDI.Name = "txtRequestNoValueDI";
            this.txtRequestNoValueDI.ReadOnly = true;
            this.txtRequestNoValueDI.Size = new System.Drawing.Size(281, 25);
            this.txtRequestNoValueDI.TabIndex = 3;
            this.txtRequestNoValueDI.Text = "(placeholder)";
            // 
            // pnlRequestDetailsDI
            // 
            this.pnlRequestDetailsDI.AutoSize = true;
            this.pnlRequestDetailsDI.Controls.Add(this.tlpRequestDetails);
            this.pnlRequestDetailsDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequestDetailsDI.Location = new System.Drawing.Point(3, 204);
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
            this.lblRequestDateDI.Location = new System.Drawing.Point(13, 12);
            this.lblRequestDateDI.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblRequestDateDI.Name = "lblRequestDateDI";
            this.lblRequestDateDI.Size = new System.Drawing.Size(92, 17);
            this.lblRequestDateDI.TabIndex = 0;
            this.lblRequestDateDI.Text = "Request Date:";
            // 
            // dtpRequestDateDI
            // 
            this.dtpRequestDateDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpRequestDateDI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestDateDI.Location = new System.Drawing.Point(111, 6);
            this.dtpRequestDateDI.Name = "dtpRequestDateDI";
            this.dtpRequestDateDI.Size = new System.Drawing.Size(294, 29);
            this.dtpRequestDateDI.TabIndex = 1;
            // 
            // lblFromDepartmentDI
            // 
            this.lblFromDepartmentDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFromDepartmentDI.AutoSize = true;
            this.lblFromDepartmentDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDepartmentDI.Location = new System.Drawing.Point(922, 10);
            this.lblFromDepartmentDI.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblFromDepartmentDI.Name = "lblFromDepartmentDI";
            this.lblFromDepartmentDI.Size = new System.Drawing.Size(139, 20);
            this.lblFromDepartmentDI.TabIndex = 2;
            this.lblFromDepartmentDI.Text = "From Department:";
            // 
            // cmbFromDepartmentDI
            // 
            this.cmbFromDepartmentDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromDepartmentDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDepartmentDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromDepartmentDI.FormattingEnabled = true;
            this.cmbFromDepartmentDI.Items.AddRange(new object[] {
            "PRD - Production Department",
            "PKG - Packaging Department"});
            this.cmbFromDepartmentDI.Location = new System.Drawing.Point(1074, 6);
            this.cmbFromDepartmentDI.Name = "cmbFromDepartmentDI";
            this.cmbFromDepartmentDI.Size = new System.Drawing.Size(254, 28);
            this.cmbFromDepartmentDI.TabIndex = 3;
            // 
            // grpParentBatchInfoDI
            // 
            this.grpParentBatchInfoDI.AutoSize = true;
            this.grpParentBatchInfoDI.Controls.Add(this.tlpParentBatchInfo);
            this.grpParentBatchInfoDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParentBatchInfoDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpParentBatchInfoDI.Location = new System.Drawing.Point(3, 251);
            this.grpParentBatchInfoDI.Name = "grpParentBatchInfoDI";
            this.grpParentBatchInfoDI.Size = new System.Drawing.Size(1334, 114);
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
            this.tlpParentBatchInfo.Controls.Add(this.flpParentBatchSize, 3, 0);
            this.tlpParentBatchInfo.Controls.Add(this.lblParentMfgDateDI, 0, 1);
            this.tlpParentBatchInfo.Controls.Add(this.flpParentMfgDate, 1, 1);
            this.tlpParentBatchInfo.Controls.Add(this.lblParentExpDateDI, 2, 1);
            this.tlpParentBatchInfo.Controls.Add(this.flpParentExpDate, 3, 1);
            this.tlpParentBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParentBatchInfo.Location = new System.Drawing.Point(3, 21);
            this.tlpParentBatchInfo.Name = "tlpParentBatchInfo";
            this.tlpParentBatchInfo.Padding = new System.Windows.Forms.Padding(5);
            this.tlpParentBatchInfo.RowCount = 2;
            this.tlpParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpParentBatchInfo.Size = new System.Drawing.Size(1328, 90);
            this.tlpParentBatchInfo.TabIndex = 0;
            // 
            // lblParentBatchNoDI
            // 
            this.lblParentBatchNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentBatchNoDI.AutoSize = true;
            this.lblParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchNoDI.Location = new System.Drawing.Point(8, 16);
            this.lblParentBatchNoDI.Name = "lblParentBatchNoDI";
            this.lblParentBatchNoDI.Size = new System.Drawing.Size(135, 17);
            this.lblParentBatchNoDI.TabIndex = 0;
            this.lblParentBatchNoDI.Text = "Parent Batch Number:";
            // 
            // txtParentBatchNoDI
            // 
            this.txtParentBatchNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtParentBatchNoDI.Location = new System.Drawing.Point(149, 12);
            this.txtParentBatchNoDI.Name = "txtParentBatchNoDI";
            this.txtParentBatchNoDI.Size = new System.Drawing.Size(524, 25);
            this.txtParentBatchNoDI.TabIndex = 1;
            this.txtParentBatchNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblParentBatchSizeDI
            // 
            this.lblParentBatchSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentBatchSizeDI.AutoSize = true;
            this.lblParentBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchSizeDI.Location = new System.Drawing.Point(679, 16);
            this.lblParentBatchSizeDI.Name = "lblParentBatchSizeDI";
            this.lblParentBatchSizeDI.Size = new System.Drawing.Size(110, 17);
            this.lblParentBatchSizeDI.TabIndex = 2;
            this.lblParentBatchSizeDI.Text = "Parent Batch Size:";
            // 
            // flpParentBatchSize
            // 
            this.flpParentBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpParentBatchSize.AutoSize = true;
            this.flpParentBatchSize.Controls.Add(this.txtParentBatchSizeValueDI);
            this.flpParentBatchSize.Controls.Add(this.cmbParentBatchSizeUnitDI);
            this.flpParentBatchSize.Location = new System.Drawing.Point(795, 8);
            this.flpParentBatchSize.Name = "flpParentBatchSize";
            this.flpParentBatchSize.Size = new System.Drawing.Size(525, 34);
            this.flpParentBatchSize.TabIndex = 3;
            this.flpParentBatchSize.WrapContents = false;
            // 
            // txtParentBatchSizeValueDI
            // 
            this.txtParentBatchSizeValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtParentBatchSizeValueDI.Location = new System.Drawing.Point(3, 3);
            this.txtParentBatchSizeValueDI.Name = "txtParentBatchSizeValueDI";
            this.txtParentBatchSizeValueDI.Size = new System.Drawing.Size(150, 25);
            this.txtParentBatchSizeValueDI.TabIndex = 0;
            this.txtParentBatchSizeValueDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbParentBatchSizeUnitDI
            // 
            this.cmbParentBatchSizeUnitDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentBatchSizeUnitDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentBatchSizeUnitDI.FormattingEnabled = true;
            this.cmbParentBatchSizeUnitDI.Location = new System.Drawing.Point(159, 3);
            this.cmbParentBatchSizeUnitDI.Name = "cmbParentBatchSizeUnitDI";
            this.cmbParentBatchSizeUnitDI.Size = new System.Drawing.Size(100, 28);
            this.cmbParentBatchSizeUnitDI.TabIndex = 1;
            // 
            // lblParentMfgDateDI
            // 
            this.lblParentMfgDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentMfgDateDI.AutoSize = true;
            this.lblParentMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentMfgDateDI.Location = new System.Drawing.Point(33, 56);
            this.lblParentMfgDateDI.Name = "lblParentMfgDateDI";
            this.lblParentMfgDateDI.Size = new System.Drawing.Size(110, 17);
            this.lblParentMfgDateDI.TabIndex = 4;
            this.lblParentMfgDateDI.Text = "Parent Mfg. Date:";
            // 
            // flpParentMfgDate
            // 
            this.flpParentMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpParentMfgDate.AutoSize = true;
            this.flpParentMfgDate.Controls.Add(this.cmbParentMfgMonthDI);
            this.flpParentMfgDate.Controls.Add(this.cmbParentMfgYearDI);
            this.flpParentMfgDate.Location = new System.Drawing.Point(149, 48);
            this.flpParentMfgDate.Name = "flpParentMfgDate";
            this.flpParentMfgDate.Size = new System.Drawing.Size(524, 34);
            this.flpParentMfgDate.TabIndex = 5;
            this.flpParentMfgDate.WrapContents = false;
            // 
            // cmbParentMfgMonthDI
            // 
            this.cmbParentMfgMonthDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentMfgMonthDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentMfgMonthDI.FormattingEnabled = true;
            this.cmbParentMfgMonthDI.Location = new System.Drawing.Point(3, 3);
            this.cmbParentMfgMonthDI.Name = "cmbParentMfgMonthDI";
            this.cmbParentMfgMonthDI.Size = new System.Drawing.Size(120, 28);
            this.cmbParentMfgMonthDI.TabIndex = 0;
            // 
            // cmbParentMfgYearDI
            // 
            this.cmbParentMfgYearDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentMfgYearDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentMfgYearDI.FormattingEnabled = true;
            this.cmbParentMfgYearDI.Location = new System.Drawing.Point(129, 3);
            this.cmbParentMfgYearDI.Name = "cmbParentMfgYearDI";
            this.cmbParentMfgYearDI.Size = new System.Drawing.Size(100, 28);
            this.cmbParentMfgYearDI.TabIndex = 1;
            // 
            // lblParentExpDateDI
            // 
            this.lblParentExpDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParentExpDateDI.AutoSize = true;
            this.lblParentExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentExpDateDI.Location = new System.Drawing.Point(682, 56);
            this.lblParentExpDateDI.Name = "lblParentExpDateDI";
            this.lblParentExpDateDI.Size = new System.Drawing.Size(107, 17);
            this.lblParentExpDateDI.TabIndex = 6;
            this.lblParentExpDateDI.Text = "Parent Exp. Date:";
            // 
            // flpParentExpDate
            // 
            this.flpParentExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpParentExpDate.AutoSize = true;
            this.flpParentExpDate.Controls.Add(this.cmbParentExpMonthDI);
            this.flpParentExpDate.Controls.Add(this.cmbParentExpYearDI);
            this.flpParentExpDate.Location = new System.Drawing.Point(795, 48);
            this.flpParentExpDate.Name = "flpParentExpDate";
            this.flpParentExpDate.Size = new System.Drawing.Size(525, 34);
            this.flpParentExpDate.TabIndex = 7;
            this.flpParentExpDate.WrapContents = false;
            // 
            // cmbParentExpMonthDI
            // 
            this.cmbParentExpMonthDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentExpMonthDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentExpMonthDI.FormattingEnabled = true;
            this.cmbParentExpMonthDI.Location = new System.Drawing.Point(3, 3);
            this.cmbParentExpMonthDI.Name = "cmbParentExpMonthDI";
            this.cmbParentExpMonthDI.Size = new System.Drawing.Size(120, 28);
            this.cmbParentExpMonthDI.TabIndex = 0;
            // 
            // cmbParentExpYearDI
            // 
            this.cmbParentExpYearDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentExpYearDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentExpYearDI.FormattingEnabled = true;
            this.cmbParentExpYearDI.Location = new System.Drawing.Point(129, 3);
            this.cmbParentExpYearDI.Name = "cmbParentExpYearDI";
            this.cmbParentExpYearDI.Size = new System.Drawing.Size(100, 28);
            this.cmbParentExpYearDI.TabIndex = 1;
            // 
            // grpItemDetailsDI
            // 
            this.grpItemDetailsDI.AutoSize = true;
            this.grpItemDetailsDI.Controls.Add(this.tlpItemDetails);
            this.grpItemDetailsDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemDetailsDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpItemDetailsDI.Location = new System.Drawing.Point(3, 371);
            this.grpItemDetailsDI.Name = "grpItemDetailsDI";
            this.grpItemDetailsDI.Size = new System.Drawing.Size(1334, 154);
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
            this.tlpItemDetails.Controls.Add(this.lblBatchNoDI, 4, 0);
            this.tlpItemDetails.Controls.Add(this.txtBatchNoDI, 5, 0);
            this.tlpItemDetails.Controls.Add(this.lblBatchSizeDI, 0, 1);
            this.tlpItemDetails.Controls.Add(this.flpItemBatchSize, 1, 1);
            this.tlpItemDetails.Controls.Add(this.lblItemMfgDateDI, 2, 1);
            this.tlpItemDetails.Controls.Add(this.flpItemMfgDate, 3, 1);
            this.tlpItemDetails.Controls.Add(this.lblItemExpDateDI, 4, 1);
            this.tlpItemDetails.Controls.Add(this.flpItemExpDate, 5, 1);
            this.tlpItemDetails.Controls.Add(this.lblMarketDI, 0, 2);
            this.tlpItemDetails.Controls.Add(this.txtMarketDI, 1, 2);
            this.tlpItemDetails.Controls.Add(this.lblPackSizeDI, 2, 2);
            this.tlpItemDetails.Controls.Add(this.txtPackSizeDI, 3, 2);
            this.tlpItemDetails.Controls.Add(this.lblExportOrderNoDI, 4, 2);
            this.tlpItemDetails.Controls.Add(this.txtExportOrderNoDI, 5, 2);
            this.tlpItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItemDetails.Location = new System.Drawing.Point(3, 21);
            this.tlpItemDetails.Name = "tlpItemDetails";
            this.tlpItemDetails.Padding = new System.Windows.Forms.Padding(5);
            this.tlpItemDetails.RowCount = 3;
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpItemDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpItemDetails.Size = new System.Drawing.Size(1328, 130);
            this.tlpItemDetails.TabIndex = 0;
            // 
            // lblProductDI
            // 
            this.lblProductDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProductDI.AutoSize = true;
            this.lblProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblProductDI.Location = new System.Drawing.Point(21, 16);
            this.lblProductDI.Name = "lblProductDI";
            this.lblProductDI.Size = new System.Drawing.Size(56, 17);
            this.lblProductDI.TabIndex = 0;
            this.lblProductDI.Text = "Product:";
            // 
            // txtProductDI
            // 
            this.txtProductDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProductDI.Location = new System.Drawing.Point(83, 12);
            this.txtProductDI.Name = "txtProductDI";
            this.txtProductDI.Size = new System.Drawing.Size(354, 25);
            this.txtProductDI.TabIndex = 1;
            this.txtProductDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatchNoDI
            // 
            this.lblBatchNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBatchNoDI.AutoSize = true;
            this.lblBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchNoDI.Location = new System.Drawing.Point(890, 16);
            this.lblBatchNoDI.Name = "lblBatchNoDI";
            this.lblBatchNoDI.Size = new System.Drawing.Size(67, 17);
            this.lblBatchNoDI.TabIndex = 4;
            this.lblBatchNoDI.Text = "Batch No.:";
            // 
            // txtBatchNoDI
            // 
            this.txtBatchNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBatchNoDI.Location = new System.Drawing.Point(963, 12);
            this.txtBatchNoDI.Name = "txtBatchNoDI";
            this.txtBatchNoDI.Size = new System.Drawing.Size(357, 25);
            this.txtBatchNoDI.TabIndex = 5;
            this.txtBatchNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatchSizeDI
            // 
            this.lblBatchSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBatchSizeDI.AutoSize = true;
            this.lblBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchSizeDI.Location = new System.Drawing.Point(8, 55);
            this.lblBatchSizeDI.Name = "lblBatchSizeDI";
            this.lblBatchSizeDI.Size = new System.Drawing.Size(69, 17);
            this.lblBatchSizeDI.TabIndex = 6;
            this.lblBatchSizeDI.Text = "Batch Size:";
            // 
            // flpItemBatchSize
            // 
            this.flpItemBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpItemBatchSize.AutoSize = true;
            this.flpItemBatchSize.Controls.Add(this.txtItemBatchSizeValueDI);
            this.flpItemBatchSize.Controls.Add(this.cmbItemBatchSizeUnitDI);
            this.flpItemBatchSize.Location = new System.Drawing.Point(83, 47);
            this.flpItemBatchSize.Name = "flpItemBatchSize";
            this.flpItemBatchSize.Size = new System.Drawing.Size(354, 33);
            this.flpItemBatchSize.TabIndex = 7;
            this.flpItemBatchSize.WrapContents = false;
            // 
            // txtItemBatchSizeValueDI
            // 
            this.txtItemBatchSizeValueDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtItemBatchSizeValueDI.Location = new System.Drawing.Point(3, 3);
            this.txtItemBatchSizeValueDI.Name = "txtItemBatchSizeValueDI";
            this.txtItemBatchSizeValueDI.Size = new System.Drawing.Size(150, 25);
            this.txtItemBatchSizeValueDI.TabIndex = 0;
            this.txtItemBatchSizeValueDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbItemBatchSizeUnitDI
            // 
            this.cmbItemBatchSizeUnitDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemBatchSizeUnitDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemBatchSizeUnitDI.FormattingEnabled = true;
            this.cmbItemBatchSizeUnitDI.Location = new System.Drawing.Point(159, 3);
            this.cmbItemBatchSizeUnitDI.Name = "cmbItemBatchSizeUnitDI";
            this.cmbItemBatchSizeUnitDI.Size = new System.Drawing.Size(100, 28);
            this.cmbItemBatchSizeUnitDI.TabIndex = 1;
            // 
            // lblItemMfgDateDI
            // 
            this.lblItemMfgDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemMfgDateDI.AutoSize = true;
            this.lblItemMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemMfgDateDI.Location = new System.Drawing.Point(443, 55);
            this.lblItemMfgDateDI.Name = "lblItemMfgDateDI";
            this.lblItemMfgDateDI.Size = new System.Drawing.Size(69, 17);
            this.lblItemMfgDateDI.TabIndex = 8;
            this.lblItemMfgDateDI.Text = "Mfg. Date:";
            // 
            // flpItemMfgDate
            // 
            this.flpItemMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpItemMfgDate.AutoSize = true;
            this.flpItemMfgDate.Controls.Add(this.cmbItemMfgMonthDI);
            this.flpItemMfgDate.Controls.Add(this.cmbItemMfgYearDI);
            this.flpItemMfgDate.Location = new System.Drawing.Point(518, 47);
            this.flpItemMfgDate.Name = "flpItemMfgDate";
            this.flpItemMfgDate.Size = new System.Drawing.Size(354, 33);
            this.flpItemMfgDate.TabIndex = 9;
            this.flpItemMfgDate.WrapContents = false;
            // 
            // cmbItemMfgMonthDI
            // 
            this.cmbItemMfgMonthDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemMfgMonthDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemMfgMonthDI.FormattingEnabled = true;
            this.cmbItemMfgMonthDI.Location = new System.Drawing.Point(3, 3);
            this.cmbItemMfgMonthDI.Name = "cmbItemMfgMonthDI";
            this.cmbItemMfgMonthDI.Size = new System.Drawing.Size(120, 28);
            this.cmbItemMfgMonthDI.TabIndex = 0;
            // 
            // cmbItemMfgYearDI
            // 
            this.cmbItemMfgYearDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemMfgYearDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemMfgYearDI.FormattingEnabled = true;
            this.cmbItemMfgYearDI.Location = new System.Drawing.Point(129, 3);
            this.cmbItemMfgYearDI.Name = "cmbItemMfgYearDI";
            this.cmbItemMfgYearDI.Size = new System.Drawing.Size(100, 28);
            this.cmbItemMfgYearDI.TabIndex = 1;
            // 
            // lblItemExpDateDI
            // 
            this.lblItemExpDateDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemExpDateDI.AutoSize = true;
            this.lblItemExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemExpDateDI.Location = new System.Drawing.Point(891, 55);
            this.lblItemExpDateDI.Name = "lblItemExpDateDI";
            this.lblItemExpDateDI.Size = new System.Drawing.Size(66, 17);
            this.lblItemExpDateDI.TabIndex = 10;
            this.lblItemExpDateDI.Text = "Exp. Date:";
            // 
            // flpItemExpDate
            // 
            this.flpItemExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpItemExpDate.AutoSize = true;
            this.flpItemExpDate.Controls.Add(this.cmbItemExpMonthDI);
            this.flpItemExpDate.Controls.Add(this.cmbItemExpYearDI);
            this.flpItemExpDate.Location = new System.Drawing.Point(963, 47);
            this.flpItemExpDate.Name = "flpItemExpDate";
            this.flpItemExpDate.Size = new System.Drawing.Size(357, 33);
            this.flpItemExpDate.TabIndex = 11;
            this.flpItemExpDate.WrapContents = false;
            // 
            // cmbItemExpMonthDI
            // 
            this.cmbItemExpMonthDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemExpMonthDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemExpMonthDI.FormattingEnabled = true;
            this.cmbItemExpMonthDI.Location = new System.Drawing.Point(3, 3);
            this.cmbItemExpMonthDI.Name = "cmbItemExpMonthDI";
            this.cmbItemExpMonthDI.Size = new System.Drawing.Size(120, 28);
            this.cmbItemExpMonthDI.TabIndex = 0;
            // 
            // cmbItemExpYearDI
            // 
            this.cmbItemExpYearDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemExpYearDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemExpYearDI.FormattingEnabled = true;
            this.cmbItemExpYearDI.Location = new System.Drawing.Point(129, 3);
            this.cmbItemExpYearDI.Name = "cmbItemExpYearDI";
            this.cmbItemExpYearDI.Size = new System.Drawing.Size(100, 28);
            this.cmbItemExpYearDI.TabIndex = 1;
            // 
            // lblMarketDI
            // 
            this.lblMarketDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMarketDI.AutoSize = true;
            this.lblMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblMarketDI.Location = new System.Drawing.Point(25, 95);
            this.lblMarketDI.Name = "lblMarketDI";
            this.lblMarketDI.Size = new System.Drawing.Size(52, 17);
            this.lblMarketDI.TabIndex = 12;
            this.lblMarketDI.Text = "Market:";
            // 
            // txtMarketDI
            // 
            this.txtMarketDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMarketDI.Location = new System.Drawing.Point(83, 91);
            this.txtMarketDI.Name = "txtMarketDI";
            this.txtMarketDI.Size = new System.Drawing.Size(354, 25);
            this.txtMarketDI.TabIndex = 13;
            this.txtMarketDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPackSizeDI
            // 
            this.lblPackSizeDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPackSizeDI.AutoSize = true;
            this.lblPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPackSizeDI.Location = new System.Drawing.Point(448, 95);
            this.lblPackSizeDI.Name = "lblPackSizeDI";
            this.lblPackSizeDI.Size = new System.Drawing.Size(64, 17);
            this.lblPackSizeDI.TabIndex = 14;
            this.lblPackSizeDI.Text = "Pack Size:";
            // 
            // txtPackSizeDI
            // 
            this.txtPackSizeDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPackSizeDI.Location = new System.Drawing.Point(518, 91);
            this.txtPackSizeDI.Name = "txtPackSizeDI";
            this.txtPackSizeDI.Size = new System.Drawing.Size(354, 25);
            this.txtPackSizeDI.TabIndex = 15;
            this.txtPackSizeDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblExportOrderNoDI
            // 
            this.lblExportOrderNoDI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblExportOrderNoDI.AutoSize = true;
            this.lblExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblExportOrderNoDI.Location = new System.Drawing.Point(878, 95);
            this.lblExportOrderNoDI.Name = "lblExportOrderNoDI";
            this.lblExportOrderNoDI.Size = new System.Drawing.Size(79, 17);
            this.lblExportOrderNoDI.TabIndex = 16;
            this.lblExportOrderNoDI.Text = "Export Ord.:";
            // 
            // txtExportOrderNoDI
            // 
            this.txtExportOrderNoDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtExportOrderNoDI.Location = new System.Drawing.Point(963, 91);
            this.txtExportOrderNoDI.Name = "txtExportOrderNoDI";
            this.txtExportOrderNoDI.Size = new System.Drawing.Size(357, 25);
            this.txtExportOrderNoDI.TabIndex = 17;
            this.txtExportOrderNoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpRemarksDI
            // 
            this.grpRemarksDI.Controls.Add(this.txtRemarksDI);
            this.grpRemarksDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRemarksDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpRemarksDI.Location = new System.Drawing.Point(3, 531);
            this.grpRemarksDI.Name = "grpRemarksDI";
            this.grpRemarksDI.Padding = new System.Windows.Forms.Padding(10);
            this.grpRemarksDI.Size = new System.Drawing.Size(1334, 11);
            this.grpRemarksDI.TabIndex = 5;
            this.grpRemarksDI.TabStop = false;
            this.grpRemarksDI.Text = "Remarks";
            // 
            // txtRemarksDI
            // 
            this.txtRemarksDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarksDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRemarksDI.Location = new System.Drawing.Point(10, 28);
            this.txtRemarksDI.Multiline = true;
            this.txtRemarksDI.Name = "txtRemarksDI";
            this.txtRemarksDI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarksDI.Size = new System.Drawing.Size(1314, 0);
            this.txtRemarksDI.TabIndex = 0;
            // 
            // pnlActionBottomDI
            // 
            this.pnlActionBottomDI.Controls.Add(this.flpActionButtonsDI);
            this.pnlActionBottomDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionBottomDI.Location = new System.Drawing.Point(3, 548);
            this.pnlActionBottomDI.Name = "pnlActionBottomDI";
            this.pnlActionBottomDI.Size = new System.Drawing.Size(1334, 49);
            this.pnlActionBottomDI.TabIndex = 6;
            // 
            // flpActionButtonsDI
            // 
            this.flpActionButtonsDI.Controls.Add(this.btnSubmitRequestDI);
            this.flpActionButtonsDI.Controls.Add(this.btnClearFormDI);
            this.flpActionButtonsDI.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpActionButtonsDI.Location = new System.Drawing.Point(0, 0);
            this.flpActionButtonsDI.Name = "flpActionButtonsDI";
            this.flpActionButtonsDI.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.flpActionButtonsDI.Size = new System.Drawing.Size(300, 49);
            this.flpActionButtonsDI.TabIndex = 0;
            // 
            // btnSubmitRequestDI
            // 
            this.btnSubmitRequestDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitRequestDI.Location = new System.Drawing.Point(13, 8);
            this.btnSubmitRequestDI.Name = "btnSubmitRequestDI";
            this.btnSubmitRequestDI.Size = new System.Drawing.Size(127, 35);
            this.btnSubmitRequestDI.TabIndex = 0;
            this.btnSubmitRequestDI.Text = "Submit Request";
            this.btnSubmitRequestDI.UseVisualStyleBackColor = true;
            // 
            // btnClearFormDI
            // 
            this.btnClearFormDI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFormDI.Location = new System.Drawing.Point(146, 8);
            this.btnClearFormDI.Name = "btnClearFormDI";
            this.btnClearFormDI.Size = new System.Drawing.Size(129, 35);
            this.btnClearFormDI.TabIndex = 1;
            this.btnClearFormDI.Text = "Clear Form";
            this.btnClearFormDI.UseVisualStyleBackColor = true;
            // 
            // pnlStatusDI
            // 
            this.pnlStatusDI.Controls.Add(this.lblStatusValueDI);
            this.pnlStatusDI.Controls.Add(this.lblStatusLabelDI);
            this.pnlStatusDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatusDI.Location = new System.Drawing.Point(3, 603);
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
            this.lblStatusValueDI.Size = new System.Drawing.Size(129, 17);
            this.lblStatusValueDI.TabIndex = 1;
            this.lblStatusValueDI.Text = "Awaiting submission...";
            // 
            // lblStatusLabelDI
            // 
            this.lblStatusLabelDI.AutoSize = true;
            this.lblStatusLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabelDI.Location = new System.Drawing.Point(10, 7);
            this.lblStatusLabelDI.Name = "lblStatusLabelDI";
            this.lblStatusLabelDI.Size = new System.Drawing.Size(49, 17);
            this.lblStatusLabelDI.TabIndex = 0;
            this.lblStatusLabelDI.Text = "Status:";
            // 
            // tabPageGmOperations
            // 
            this.tabPageGmOperations.Controls.Add(this.tlpGmOperationsMain);
            this.tabPageGmOperations.Location = new System.Drawing.Point(4, 30);
            this.tabPageGmOperations.Name = "tabPageGmOperations";
            this.tabPageGmOperations.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageGmOperations.Size = new System.Drawing.Size(1360, 660);
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
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpGmOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpGmOperationsMain.Size = new System.Drawing.Size(1340, 640);
            this.tlpGmOperationsMain.TabIndex = 0;
            // 
            // pnlGmTopSection
            // 
            this.pnlGmTopSection.Controls.Add(this.tlpGmTopControls);
            this.pnlGmTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGmTopSection.Location = new System.Drawing.Point(3, 3);
            this.pnlGmTopSection.Name = "pnlGmTopSection";
            this.pnlGmTopSection.Size = new System.Drawing.Size(1334, 250);
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
            this.tlpGmTopControls.Size = new System.Drawing.Size(1334, 250);
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
            this.lblGmQueueTitle.Size = new System.Drawing.Size(232, 21);
            this.lblGmQueueTitle.TabIndex = 0;
            this.lblGmQueueTitle.Text = "Pending GM Approval Queue";
            // 
            // btnGmRefreshList
            // 
            this.btnGmRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGmRefreshList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvGmQueue.Size = new System.Drawing.Size(1328, 204);
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
            this.colGmDocTypes.DataPropertyName = "DocumentNo";
            this.colGmDocTypes.HeaderText = "Document No(s).";
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
            this.tlpGmBottomSection.Location = new System.Drawing.Point(3, 259);
            this.tlpGmBottomSection.Name = "tlpGmBottomSection";
            this.tlpGmBottomSection.RowCount = 2;
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGmBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpGmBottomSection.Size = new System.Drawing.Size(1334, 378);
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
            this.grpGmSelectedRequest.Size = new System.Drawing.Size(1328, 232);
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
            this.tlpGmRequestDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpGmRequestDetails.Location = new System.Drawing.Point(10, 28);
            this.tlpGmRequestDetails.Name = "tlpGmRequestDetails";
            this.tlpGmRequestDetails.RowCount = 7;
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGmRequestDetails.Size = new System.Drawing.Size(1308, 194);
            this.tlpGmRequestDetails.TabIndex = 0;
            // 
            // lblGmDetailRequestNoLabel
            // 
            this.lblGmDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestNoLabel.AutoSize = true;
            this.lblGmDetailRequestNoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailRequestNoLabel.Location = new System.Drawing.Point(64, 7);
            this.lblGmDetailRequestNoLabel.Name = "lblGmDetailRequestNoLabel";
            this.lblGmDetailRequestNoLabel.Size = new System.Drawing.Size(83, 17);
            this.lblGmDetailRequestNoLabel.TabIndex = 0;
            this.lblGmDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtGmDetailRequestNo
            // 
            this.txtGmDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestNo.Location = new System.Drawing.Point(153, 3);
            this.txtGmDetailRequestNo.Name = "txtGmDetailRequestNo";
            this.txtGmDetailRequestNo.ReadOnly = true;
            this.txtGmDetailRequestNo.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailRequestNo.TabIndex = 1;
            // 
            // lblGmDetailRequestDateLabel
            // 
            this.lblGmDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestDateLabel.AutoSize = true;
            this.lblGmDetailRequestDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailRequestDateLabel.Location = new System.Drawing.Point(712, 7);
            this.lblGmDetailRequestDateLabel.Name = "lblGmDetailRequestDateLabel";
            this.lblGmDetailRequestDateLabel.Size = new System.Drawing.Size(89, 17);
            this.lblGmDetailRequestDateLabel.TabIndex = 2;
            this.lblGmDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtGmDetailRequestDate
            // 
            this.txtGmDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestDate.Location = new System.Drawing.Point(807, 3);
            this.txtGmDetailRequestDate.Name = "txtGmDetailRequestDate";
            this.txtGmDetailRequestDate.ReadOnly = true;
            this.txtGmDetailRequestDate.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailRequestDate.TabIndex = 3;
            // 
            // lblGmDetailFromDeptLabel
            // 
            this.lblGmDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailFromDeptLabel.AutoSize = true;
            this.lblGmDetailFromDeptLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailFromDeptLabel.Location = new System.Drawing.Point(33, 38);
            this.lblGmDetailFromDeptLabel.Name = "lblGmDetailFromDeptLabel";
            this.lblGmDetailFromDeptLabel.Size = new System.Drawing.Size(114, 17);
            this.lblGmDetailFromDeptLabel.TabIndex = 4;
            this.lblGmDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtGmDetailFromDept
            // 
            this.txtGmDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailFromDept.Location = new System.Drawing.Point(153, 34);
            this.txtGmDetailFromDept.Name = "txtGmDetailFromDept";
            this.txtGmDetailFromDept.ReadOnly = true;
            this.txtGmDetailFromDept.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailFromDept.TabIndex = 5;
            // 
            // lblGmDetailDocTypesLabel
            // 
            this.lblGmDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailDocTypesLabel.AutoSize = true;
            this.lblGmDetailDocTypesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailDocTypesLabel.Location = new System.Drawing.Point(694, 38);
            this.lblGmDetailDocTypesLabel.Name = "lblGmDetailDocTypesLabel";
            this.lblGmDetailDocTypesLabel.Size = new System.Drawing.Size(107, 17);
            this.lblGmDetailDocTypesLabel.TabIndex = 6;
            this.lblGmDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtGmDetailDocTypes
            // 
            this.txtGmDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailDocTypes.Location = new System.Drawing.Point(807, 34);
            this.txtGmDetailDocTypes.Name = "txtGmDetailDocTypes";
            this.txtGmDetailDocTypes.ReadOnly = true;
            this.txtGmDetailDocTypes.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailDocTypes.TabIndex = 7;
            // 
            // lblGmDetailProductLabel
            // 
            this.lblGmDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailProductLabel.AutoSize = true;
            this.lblGmDetailProductLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailProductLabel.Location = new System.Drawing.Point(91, 69);
            this.lblGmDetailProductLabel.Name = "lblGmDetailProductLabel";
            this.lblGmDetailProductLabel.Size = new System.Drawing.Size(56, 17);
            this.lblGmDetailProductLabel.TabIndex = 8;
            this.lblGmDetailProductLabel.Text = "Product:";
            // 
            // txtGmDetailProduct
            // 
            this.txtGmDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailProduct.Location = new System.Drawing.Point(153, 65);
            this.txtGmDetailProduct.Name = "txtGmDetailProduct";
            this.txtGmDetailProduct.ReadOnly = true;
            this.txtGmDetailProduct.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailProduct.TabIndex = 9;
            // 
            // lblGmDetailBatchNoLabel
            // 
            this.lblGmDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailBatchNoLabel.AutoSize = true;
            this.lblGmDetailBatchNoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailBatchNoLabel.Location = new System.Drawing.Point(734, 69);
            this.lblGmDetailBatchNoLabel.Name = "lblGmDetailBatchNoLabel";
            this.lblGmDetailBatchNoLabel.Size = new System.Drawing.Size(67, 17);
            this.lblGmDetailBatchNoLabel.TabIndex = 10;
            this.lblGmDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtGmDetailBatchNo
            // 
            this.txtGmDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailBatchNo.Location = new System.Drawing.Point(807, 65);
            this.txtGmDetailBatchNo.Name = "txtGmDetailBatchNo";
            this.txtGmDetailBatchNo.ReadOnly = true;
            this.txtGmDetailBatchNo.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailBatchNo.TabIndex = 11;
            // 
            // lblGmDetailMfgDateLabel
            // 
            this.lblGmDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMfgDateLabel.AutoSize = true;
            this.lblGmDetailMfgDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailMfgDateLabel.Location = new System.Drawing.Point(81, 100);
            this.lblGmDetailMfgDateLabel.Name = "lblGmDetailMfgDateLabel";
            this.lblGmDetailMfgDateLabel.Size = new System.Drawing.Size(66, 17);
            this.lblGmDetailMfgDateLabel.TabIndex = 12;
            this.lblGmDetailMfgDateLabel.Text = "Mfg Date:";
            // 
            // txtGmDetailMfgDate
            // 
            this.txtGmDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMfgDate.Location = new System.Drawing.Point(153, 96);
            this.txtGmDetailMfgDate.Name = "txtGmDetailMfgDate";
            this.txtGmDetailMfgDate.ReadOnly = true;
            this.txtGmDetailMfgDate.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailMfgDate.TabIndex = 13;
            // 
            // lblGmDetailExpDateLabel
            // 
            this.lblGmDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailExpDateLabel.AutoSize = true;
            this.lblGmDetailExpDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailExpDateLabel.Location = new System.Drawing.Point(735, 100);
            this.lblGmDetailExpDateLabel.Name = "lblGmDetailExpDateLabel";
            this.lblGmDetailExpDateLabel.Size = new System.Drawing.Size(66, 17);
            this.lblGmDetailExpDateLabel.TabIndex = 14;
            this.lblGmDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtGmDetailExpDate
            // 
            this.txtGmDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailExpDate.Location = new System.Drawing.Point(807, 96);
            this.txtGmDetailExpDate.Name = "txtGmDetailExpDate";
            this.txtGmDetailExpDate.ReadOnly = true;
            this.txtGmDetailExpDate.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailExpDate.TabIndex = 15;
            // 
            // lblGmDetailMarketLabel
            // 
            this.lblGmDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailMarketLabel.AutoSize = true;
            this.lblGmDetailMarketLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailMarketLabel.Location = new System.Drawing.Point(95, 131);
            this.lblGmDetailMarketLabel.Name = "lblGmDetailMarketLabel";
            this.lblGmDetailMarketLabel.Size = new System.Drawing.Size(52, 17);
            this.lblGmDetailMarketLabel.TabIndex = 16;
            this.lblGmDetailMarketLabel.Text = "Market:";
            // 
            // txtGmDetailMarket
            // 
            this.txtGmDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailMarket.Location = new System.Drawing.Point(153, 127);
            this.txtGmDetailMarket.Name = "txtGmDetailMarket";
            this.txtGmDetailMarket.ReadOnly = true;
            this.txtGmDetailMarket.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailMarket.TabIndex = 17;
            // 
            // lblGmDetailPackSizeLabel
            // 
            this.lblGmDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPackSizeLabel.AutoSize = true;
            this.lblGmDetailPackSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailPackSizeLabel.Location = new System.Drawing.Point(737, 131);
            this.lblGmDetailPackSizeLabel.Name = "lblGmDetailPackSizeLabel";
            this.lblGmDetailPackSizeLabel.Size = new System.Drawing.Size(64, 17);
            this.lblGmDetailPackSizeLabel.TabIndex = 18;
            this.lblGmDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtGmDetailPackSize
            // 
            this.txtGmDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPackSize.Location = new System.Drawing.Point(807, 127);
            this.txtGmDetailPackSize.Name = "txtGmDetailPackSize";
            this.txtGmDetailPackSize.ReadOnly = true;
            this.txtGmDetailPackSize.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailPackSize.TabIndex = 19;
            // 
            // lblGmDetailPreparedByLabel
            // 
            this.lblGmDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailPreparedByLabel.AutoSize = true;
            this.lblGmDetailPreparedByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailPreparedByLabel.Location = new System.Drawing.Point(65, 162);
            this.lblGmDetailPreparedByLabel.Name = "lblGmDetailPreparedByLabel";
            this.lblGmDetailPreparedByLabel.Size = new System.Drawing.Size(82, 17);
            this.lblGmDetailPreparedByLabel.TabIndex = 20;
            this.lblGmDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtGmDetailPreparedBy
            // 
            this.txtGmDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailPreparedBy.Location = new System.Drawing.Point(153, 158);
            this.txtGmDetailPreparedBy.Name = "txtGmDetailPreparedBy";
            this.txtGmDetailPreparedBy.ReadOnly = true;
            this.txtGmDetailPreparedBy.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailPreparedBy.TabIndex = 21;
            // 
            // lblGmDetailRequestedAtLabel
            // 
            this.lblGmDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGmDetailRequestedAtLabel.AutoSize = true;
            this.lblGmDetailRequestedAtLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmDetailRequestedAtLabel.Location = new System.Drawing.Point(712, 162);
            this.lblGmDetailRequestedAtLabel.Name = "lblGmDetailRequestedAtLabel";
            this.lblGmDetailRequestedAtLabel.Size = new System.Drawing.Size(89, 17);
            this.lblGmDetailRequestedAtLabel.TabIndex = 22;
            this.lblGmDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtGmDetailRequestedAt
            // 
            this.txtGmDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGmDetailRequestedAt.Location = new System.Drawing.Point(807, 158);
            this.txtGmDetailRequestedAt.Name = "txtGmDetailRequestedAt";
            this.txtGmDetailRequestedAt.ReadOnly = true;
            this.txtGmDetailRequestedAt.Size = new System.Drawing.Size(498, 25);
            this.txtGmDetailRequestedAt.TabIndex = 23;
            // 
            // lblGmDetailRequesterCommentsLabel
            // 
            this.lblGmDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGmDetailRequesterCommentsLabel.AutoSize = true;
            this.lblGmDetailRequesterCommentsLabel.Location = new System.Drawing.Point(11, 186);
            this.lblGmDetailRequesterCommentsLabel.Name = "lblGmDetailRequesterCommentsLabel";
            this.lblGmDetailRequesterCommentsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblGmDetailRequesterCommentsLabel.Size = new System.Drawing.Size(136, 22);
            this.lblGmDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblGmDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtGmDetailRequesterComments
            // 
            this.tlpGmRequestDetails.SetColumnSpan(this.txtGmDetailRequesterComments, 3);
            this.txtGmDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmDetailRequesterComments.Location = new System.Drawing.Point(153, 189);
            this.txtGmDetailRequesterComments.Multiline = true;
            this.txtGmDetailRequesterComments.Name = "txtGmDetailRequesterComments";
            this.txtGmDetailRequesterComments.ReadOnly = true;
            this.txtGmDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmDetailRequesterComments.Size = new System.Drawing.Size(1152, 65);
            this.txtGmDetailRequesterComments.TabIndex = 25;
            // 
            // grpGmAction
            // 
            this.grpGmAction.Controls.Add(this.tlpGmActionControls);
            this.grpGmAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGmAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpGmAction.Location = new System.Drawing.Point(3, 241);
            this.grpGmAction.Name = "grpGmAction";
            this.grpGmAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpGmAction.Size = new System.Drawing.Size(1328, 134);
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
            this.tlpGmActionControls.Size = new System.Drawing.Size(1308, 96);
            this.tlpGmActionControls.TabIndex = 0;
            // 
            // lblGmComment
            // 
            this.lblGmComment.AutoSize = true;
            this.lblGmComment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmComment.Location = new System.Drawing.Point(3, 0);
            this.lblGmComment.Name = "lblGmComment";
            this.lblGmComment.Size = new System.Drawing.Size(110, 20);
            this.lblGmComment.TabIndex = 0;
            this.lblGmComment.Text = "GM Comments:";
            // 
            // txtGmComment
            // 
            this.txtGmComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGmComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGmComment.Location = new System.Drawing.Point(3, 23);
            this.txtGmComment.Multiline = true;
            this.txtGmComment.Name = "txtGmComment";
            this.txtGmComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGmComment.Size = new System.Drawing.Size(1302, 25);
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
            this.flpGmActionButtons.Size = new System.Drawing.Size(1302, 39);
            this.flpGmActionButtons.TabIndex = 2;
            // 
            // btnGmAuthorize
            // 
            this.btnGmAuthorize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGmAuthorize.Location = new System.Drawing.Point(3, 8);
            this.btnGmAuthorize.Name = "btnGmAuthorize";
            this.btnGmAuthorize.Size = new System.Drawing.Size(120, 30);
            this.btnGmAuthorize.TabIndex = 0;
            this.btnGmAuthorize.Text = "Authorize";
            this.btnGmAuthorize.UseVisualStyleBackColor = true;
            // 
            // btnGmReject
            // 
            this.btnGmReject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPageQa.Location = new System.Drawing.Point(4, 30);
            this.tabPageQa.Name = "tabPageQa";
            this.tabPageQa.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageQa.Size = new System.Drawing.Size(1360, 660);
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
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpQaOperationsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpQaOperationsMain.Size = new System.Drawing.Size(1340, 640);
            this.tlpQaOperationsMain.TabIndex = 0;
            // 
            // pnlQaTopSection
            // 
            this.pnlQaTopSection.Controls.Add(this.tlpQaTopControls);
            this.pnlQaTopSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQaTopSection.Location = new System.Drawing.Point(3, 3);
            this.pnlQaTopSection.Name = "pnlQaTopSection";
            this.pnlQaTopSection.Size = new System.Drawing.Size(1334, 250);
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
            this.tlpQaTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaTopControls.Size = new System.Drawing.Size(1334, 250);
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
            this.lblQaQueueTitle.Size = new System.Drawing.Size(229, 21);
            this.lblQaQueueTitle.TabIndex = 0;
            this.lblQaQueueTitle.Text = "Pending QA Approval Queue";
            // 
            // btnQaRefreshList
            // 
            this.btnQaRefreshList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQaRefreshList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "NA";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQaQueue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQaQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQaQueue.Location = new System.Drawing.Point(3, 38);
            this.dgvQaQueue.MultiSelect = false;
            this.dgvQaQueue.Name = "dgvQaQueue";
            this.dgvQaQueue.ReadOnly = true;
            this.dgvQaQueue.RowHeadersWidth = 51;
            this.dgvQaQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQaQueue.Size = new System.Drawing.Size(1328, 209);
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
            this.colQaDocTypes.DataPropertyName = "DocumentNo";
            this.colQaDocTypes.HeaderText = "Document No(s).";
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
            this.tlpQaBottomSection.Location = new System.Drawing.Point(3, 259);
            this.tlpQaBottomSection.Name = "tlpQaBottomSection";
            this.tlpQaBottomSection.RowCount = 2;
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQaBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpQaBottomSection.Size = new System.Drawing.Size(1334, 378);
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
            this.grpQaSelectedRequest.Size = new System.Drawing.Size(1328, 192);
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
            this.tlpQaRequestDetails.Location = new System.Drawing.Point(10, 28);
            this.tlpQaRequestDetails.Name = "tlpQaRequestDetails";
            this.tlpQaRequestDetails.RowCount = 9;
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQaRequestDetails.Size = new System.Drawing.Size(1308, 154);
            this.tlpQaRequestDetails.TabIndex = 0;
            // 
            // lblQaDetailRequestNoLabel
            // 
            this.lblQaDetailRequestNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestNoLabel.AutoSize = true;
            this.lblQaDetailRequestNoLabel.Location = new System.Drawing.Point(83, 7);
            this.lblQaDetailRequestNoLabel.Name = "lblQaDetailRequestNoLabel";
            this.lblQaDetailRequestNoLabel.Size = new System.Drawing.Size(74, 15);
            this.lblQaDetailRequestNoLabel.TabIndex = 0;
            this.lblQaDetailRequestNoLabel.Text = "Request No.:";
            // 
            // txtQaDetailRequestNo
            // 
            this.txtQaDetailRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestNo.Location = new System.Drawing.Point(163, 3);
            this.txtQaDetailRequestNo.Name = "txtQaDetailRequestNo";
            this.txtQaDetailRequestNo.ReadOnly = true;
            this.txtQaDetailRequestNo.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailRequestNo.TabIndex = 1;
            // 
            // lblQaDetailRequestDateLabel
            // 
            this.lblQaDetailRequestDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestDateLabel.AutoSize = true;
            this.lblQaDetailRequestDateLabel.Location = new System.Drawing.Point(732, 7);
            this.lblQaDetailRequestDateLabel.Name = "lblQaDetailRequestDateLabel";
            this.lblQaDetailRequestDateLabel.Size = new System.Drawing.Size(79, 15);
            this.lblQaDetailRequestDateLabel.TabIndex = 2;
            this.lblQaDetailRequestDateLabel.Text = "Request Date:";
            // 
            // txtQaDetailRequestDate
            // 
            this.txtQaDetailRequestDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestDate.Location = new System.Drawing.Point(817, 3);
            this.txtQaDetailRequestDate.Name = "txtQaDetailRequestDate";
            this.txtQaDetailRequestDate.ReadOnly = true;
            this.txtQaDetailRequestDate.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailRequestDate.TabIndex = 3;
            // 
            // lblQaDetailFromDeptLabel
            // 
            this.lblQaDetailFromDeptLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailFromDeptLabel.AutoSize = true;
            this.lblQaDetailFromDeptLabel.Location = new System.Drawing.Point(53, 36);
            this.lblQaDetailFromDeptLabel.Name = "lblQaDetailFromDeptLabel";
            this.lblQaDetailFromDeptLabel.Size = new System.Drawing.Size(104, 15);
            this.lblQaDetailFromDeptLabel.TabIndex = 4;
            this.lblQaDetailFromDeptLabel.Text = "From Department:";
            // 
            // txtQaDetailFromDept
            // 
            this.txtQaDetailFromDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailFromDept.Location = new System.Drawing.Point(163, 32);
            this.txtQaDetailFromDept.Name = "txtQaDetailFromDept";
            this.txtQaDetailFromDept.ReadOnly = true;
            this.txtQaDetailFromDept.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailFromDept.TabIndex = 5;
            // 
            // lblQaDetailDocTypesLabel
            // 
            this.lblQaDetailDocTypesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailDocTypesLabel.AutoSize = true;
            this.lblQaDetailDocTypesLabel.Location = new System.Drawing.Point(712, 36);
            this.lblQaDetailDocTypesLabel.Name = "lblQaDetailDocTypesLabel";
            this.lblQaDetailDocTypesLabel.Size = new System.Drawing.Size(99, 15);
            this.lblQaDetailDocTypesLabel.TabIndex = 6;
            this.lblQaDetailDocTypesLabel.Text = "Document Types:";
            // 
            // txtQaDetailDocTypes
            // 
            this.txtQaDetailDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailDocTypes.Location = new System.Drawing.Point(817, 32);
            this.txtQaDetailDocTypes.Name = "txtQaDetailDocTypes";
            this.txtQaDetailDocTypes.ReadOnly = true;
            this.txtQaDetailDocTypes.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailDocTypes.TabIndex = 7;
            // 
            // lblQaDetailProductLabel
            // 
            this.lblQaDetailProductLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailProductLabel.AutoSize = true;
            this.lblQaDetailProductLabel.Location = new System.Drawing.Point(105, 65);
            this.lblQaDetailProductLabel.Name = "lblQaDetailProductLabel";
            this.lblQaDetailProductLabel.Size = new System.Drawing.Size(52, 15);
            this.lblQaDetailProductLabel.TabIndex = 8;
            this.lblQaDetailProductLabel.Text = "Product:";
            // 
            // txtQaDetailProduct
            // 
            this.txtQaDetailProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailProduct.Location = new System.Drawing.Point(163, 61);
            this.txtQaDetailProduct.Name = "txtQaDetailProduct";
            this.txtQaDetailProduct.ReadOnly = true;
            this.txtQaDetailProduct.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailProduct.TabIndex = 9;
            // 
            // lblQaDetailBatchNoLabel
            // 
            this.lblQaDetailBatchNoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailBatchNoLabel.AutoSize = true;
            this.lblQaDetailBatchNoLabel.Location = new System.Drawing.Point(749, 65);
            this.lblQaDetailBatchNoLabel.Name = "lblQaDetailBatchNoLabel";
            this.lblQaDetailBatchNoLabel.Size = new System.Drawing.Size(62, 15);
            this.lblQaDetailBatchNoLabel.TabIndex = 10;
            this.lblQaDetailBatchNoLabel.Text = "Batch No.:";
            // 
            // txtQaDetailBatchNo
            // 
            this.txtQaDetailBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailBatchNo.Location = new System.Drawing.Point(817, 61);
            this.txtQaDetailBatchNo.Name = "txtQaDetailBatchNo";
            this.txtQaDetailBatchNo.ReadOnly = true;
            this.txtQaDetailBatchNo.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailBatchNo.TabIndex = 11;
            // 
            // lblQaDetailMfgDateLabel
            // 
            this.lblQaDetailMfgDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMfgDateLabel.AutoSize = true;
            this.lblQaDetailMfgDateLabel.Location = new System.Drawing.Point(95, 94);
            this.lblQaDetailMfgDateLabel.Name = "lblQaDetailMfgDateLabel";
            this.lblQaDetailMfgDateLabel.Size = new System.Drawing.Size(62, 15);
            this.lblQaDetailMfgDateLabel.TabIndex = 12;
            this.lblQaDetailMfgDateLabel.Text = "Mfg. Date:";
            // 
            // txtQaDetailMfgDate
            // 
            this.txtQaDetailMfgDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMfgDate.Location = new System.Drawing.Point(163, 90);
            this.txtQaDetailMfgDate.Name = "txtQaDetailMfgDate";
            this.txtQaDetailMfgDate.ReadOnly = true;
            this.txtQaDetailMfgDate.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailMfgDate.TabIndex = 13;
            // 
            // lblQaDetailExpDateLabel
            // 
            this.lblQaDetailExpDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailExpDateLabel.AutoSize = true;
            this.lblQaDetailExpDateLabel.Location = new System.Drawing.Point(753, 94);
            this.lblQaDetailExpDateLabel.Name = "lblQaDetailExpDateLabel";
            this.lblQaDetailExpDateLabel.Size = new System.Drawing.Size(58, 15);
            this.lblQaDetailExpDateLabel.TabIndex = 14;
            this.lblQaDetailExpDateLabel.Text = "Exp. Date:";
            // 
            // txtQaDetailExpDate
            // 
            this.txtQaDetailExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailExpDate.Location = new System.Drawing.Point(817, 90);
            this.txtQaDetailExpDate.Name = "txtQaDetailExpDate";
            this.txtQaDetailExpDate.ReadOnly = true;
            this.txtQaDetailExpDate.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailExpDate.TabIndex = 15;
            // 
            // lblQaDetailMarketLabel
            // 
            this.lblQaDetailMarketLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailMarketLabel.AutoSize = true;
            this.lblQaDetailMarketLabel.Location = new System.Drawing.Point(110, 123);
            this.lblQaDetailMarketLabel.Name = "lblQaDetailMarketLabel";
            this.lblQaDetailMarketLabel.Size = new System.Drawing.Size(47, 15);
            this.lblQaDetailMarketLabel.TabIndex = 16;
            this.lblQaDetailMarketLabel.Text = "Market:";
            // 
            // txtQaDetailMarket
            // 
            this.txtQaDetailMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailMarket.Location = new System.Drawing.Point(163, 119);
            this.txtQaDetailMarket.Name = "txtQaDetailMarket";
            this.txtQaDetailMarket.ReadOnly = true;
            this.txtQaDetailMarket.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailMarket.TabIndex = 17;
            // 
            // lblQaDetailPackSizeLabel
            // 
            this.lblQaDetailPackSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPackSizeLabel.AutoSize = true;
            this.lblQaDetailPackSizeLabel.Location = new System.Drawing.Point(753, 123);
            this.lblQaDetailPackSizeLabel.Name = "lblQaDetailPackSizeLabel";
            this.lblQaDetailPackSizeLabel.Size = new System.Drawing.Size(58, 15);
            this.lblQaDetailPackSizeLabel.TabIndex = 18;
            this.lblQaDetailPackSizeLabel.Text = "Pack Size:";
            // 
            // txtQaDetailPackSize
            // 
            this.txtQaDetailPackSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPackSize.Location = new System.Drawing.Point(817, 119);
            this.txtQaDetailPackSize.Name = "txtQaDetailPackSize";
            this.txtQaDetailPackSize.ReadOnly = true;
            this.txtQaDetailPackSize.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailPackSize.TabIndex = 19;
            // 
            // lblQaDetailPreparedByLabel
            // 
            this.lblQaDetailPreparedByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailPreparedByLabel.AutoSize = true;
            this.lblQaDetailPreparedByLabel.Location = new System.Drawing.Point(84, 152);
            this.lblQaDetailPreparedByLabel.Name = "lblQaDetailPreparedByLabel";
            this.lblQaDetailPreparedByLabel.Size = new System.Drawing.Size(73, 15);
            this.lblQaDetailPreparedByLabel.TabIndex = 20;
            this.lblQaDetailPreparedByLabel.Text = "Prepared By:";
            // 
            // txtQaDetailPreparedBy
            // 
            this.txtQaDetailPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailPreparedBy.Location = new System.Drawing.Point(163, 148);
            this.txtQaDetailPreparedBy.Name = "txtQaDetailPreparedBy";
            this.txtQaDetailPreparedBy.ReadOnly = true;
            this.txtQaDetailPreparedBy.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailPreparedBy.TabIndex = 21;
            // 
            // lblQaDetailRequestedAtLabel
            // 
            this.lblQaDetailRequestedAtLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailRequestedAtLabel.AutoSize = true;
            this.lblQaDetailRequestedAtLabel.Location = new System.Drawing.Point(731, 152);
            this.lblQaDetailRequestedAtLabel.Name = "lblQaDetailRequestedAtLabel";
            this.lblQaDetailRequestedAtLabel.Size = new System.Drawing.Size(80, 15);
            this.lblQaDetailRequestedAtLabel.TabIndex = 22;
            this.lblQaDetailRequestedAtLabel.Text = "Requested At:";
            // 
            // txtQaDetailRequestedAt
            // 
            this.txtQaDetailRequestedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailRequestedAt.Location = new System.Drawing.Point(817, 148);
            this.txtQaDetailRequestedAt.Name = "txtQaDetailRequestedAt";
            this.txtQaDetailRequestedAt.ReadOnly = true;
            this.txtQaDetailRequestedAt.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailRequestedAt.TabIndex = 23;
            // 
            // lblQaDetailRequesterCommentsLabel
            // 
            this.lblQaDetailRequesterCommentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailRequesterCommentsLabel.AutoSize = true;
            this.lblQaDetailRequesterCommentsLabel.Location = new System.Drawing.Point(33, 174);
            this.lblQaDetailRequesterCommentsLabel.Name = "lblQaDetailRequesterCommentsLabel";
            this.lblQaDetailRequesterCommentsLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblQaDetailRequesterCommentsLabel.Size = new System.Drawing.Size(124, 20);
            this.lblQaDetailRequesterCommentsLabel.TabIndex = 24;
            this.lblQaDetailRequesterCommentsLabel.Text = "Requester Comments:";
            // 
            // txtQaDetailRequesterComments
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailRequesterComments, 3);
            this.txtQaDetailRequesterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailRequesterComments.Location = new System.Drawing.Point(163, 177);
            this.txtQaDetailRequesterComments.Multiline = true;
            this.txtQaDetailRequesterComments.Name = "txtQaDetailRequesterComments";
            this.txtQaDetailRequesterComments.ReadOnly = true;
            this.txtQaDetailRequesterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailRequesterComments.Size = new System.Drawing.Size(1142, 20);
            this.txtQaDetailRequesterComments.TabIndex = 25;
            // 
            // lblQaDetailGmCommentLabel
            // 
            this.lblQaDetailGmCommentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQaDetailGmCommentLabel.AutoSize = true;
            this.lblQaDetailGmCommentLabel.Location = new System.Drawing.Point(66, 200);
            this.lblQaDetailGmCommentLabel.Name = "lblQaDetailGmCommentLabel";
            this.lblQaDetailGmCommentLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblQaDetailGmCommentLabel.Size = new System.Drawing.Size(91, 20);
            this.lblQaDetailGmCommentLabel.TabIndex = 26;
            this.lblQaDetailGmCommentLabel.Text = "GM Comments:";
            // 
            // txtQaDetailGmComment
            // 
            this.tlpQaRequestDetails.SetColumnSpan(this.txtQaDetailGmComment, 3);
            this.txtQaDetailGmComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaDetailGmComment.Location = new System.Drawing.Point(163, 203);
            this.txtQaDetailGmComment.Multiline = true;
            this.txtQaDetailGmComment.Name = "txtQaDetailGmComment";
            this.txtQaDetailGmComment.ReadOnly = true;
            this.txtQaDetailGmComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaDetailGmComment.Size = new System.Drawing.Size(1142, 20);
            this.txtQaDetailGmComment.TabIndex = 27;
            // 
            // lblQaDetailGmActionTimeLabel
            // 
            this.lblQaDetailGmActionTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQaDetailGmActionTimeLabel.AutoSize = true;
            this.lblQaDetailGmActionTimeLabel.Location = new System.Drawing.Point(60, 235);
            this.lblQaDetailGmActionTimeLabel.Name = "lblQaDetailGmActionTimeLabel";
            this.lblQaDetailGmActionTimeLabel.Size = new System.Drawing.Size(97, 15);
            this.lblQaDetailGmActionTimeLabel.TabIndex = 28;
            this.lblQaDetailGmActionTimeLabel.Text = "GM Action Time:";
            // 
            // txtQaDetailGmActionTime
            // 
            this.txtQaDetailGmActionTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaDetailGmActionTime.Location = new System.Drawing.Point(163, 231);
            this.txtQaDetailGmActionTime.Name = "txtQaDetailGmActionTime";
            this.txtQaDetailGmActionTime.ReadOnly = true;
            this.txtQaDetailGmActionTime.Size = new System.Drawing.Size(488, 23);
            this.txtQaDetailGmActionTime.TabIndex = 29;
            // 
            // grpQaAction
            // 
            this.grpQaAction.Controls.Add(this.tlpQaActionControls);
            this.grpQaAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQaAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpQaAction.Location = new System.Drawing.Point(3, 201);
            this.grpQaAction.Name = "grpQaAction";
            this.grpQaAction.Padding = new System.Windows.Forms.Padding(10);
            this.grpQaAction.Size = new System.Drawing.Size(1328, 174);
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
            this.tlpQaActionControls.Size = new System.Drawing.Size(1308, 136);
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
            this.lblQaPrintCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQaPrintCount.Location = new System.Drawing.Point(3, 8);
            this.lblQaPrintCount.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.lblQaPrintCount.Name = "lblQaPrintCount";
            this.lblQaPrintCount.Size = new System.Drawing.Size(85, 20);
            this.lblQaPrintCount.TabIndex = 0;
            this.lblQaPrintCount.Text = "Print Count:";
            // 
            // numQaPrintCount
            // 
            this.numQaPrintCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnQaBrowseSelectDocument.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblQaComment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQaComment.Location = new System.Drawing.Point(3, 40);
            this.lblQaComment.Name = "lblQaComment";
            this.lblQaComment.Size = new System.Drawing.Size(108, 20);
            this.lblQaComment.TabIndex = 1;
            this.lblQaComment.Text = "QA Comments:";
            // 
            // txtQaComment
            // 
            this.txtQaComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQaComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQaComment.Location = new System.Drawing.Point(3, 63);
            this.txtQaComment.Multiline = true;
            this.txtQaComment.Name = "txtQaComment";
            this.txtQaComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQaComment.Size = new System.Drawing.Size(1302, 23);
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
            this.flpQaActionButtons.Size = new System.Drawing.Size(1302, 41);
            this.flpQaActionButtons.TabIndex = 3;
            // 
            // btnQaApprove
            // 
            this.btnQaApprove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQaApprove.Location = new System.Drawing.Point(3, 8);
            this.btnQaApprove.Name = "btnQaApprove";
            this.btnQaApprove.Size = new System.Drawing.Size(120, 30);
            this.btnQaApprove.TabIndex = 0;
            this.btnQaApprove.Text = "Approve";
            this.btnQaApprove.UseVisualStyleBackColor = true;
            // 
            // btnQaReject
            // 
            this.btnQaReject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPageAuditTrail.Location = new System.Drawing.Point(4, 30);
            this.tabPageAuditTrail.Name = "tabPageAuditTrail";
            this.tabPageAuditTrail.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageAuditTrail.Size = new System.Drawing.Size(1360, 660);
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
            this.tlpAuditTrailMain.Size = new System.Drawing.Size(1340, 640);
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
            this.grpAuditFilters.Size = new System.Drawing.Size(1334, 108);
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
            this.tlpAuditFilters.Location = new System.Drawing.Point(10, 28);
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
            this.lblAuditFromDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditFromDate.Location = new System.Drawing.Point(10, 7);
            this.lblAuditFromDate.Name = "lblAuditFromDate";
            this.lblAuditFromDate.Size = new System.Drawing.Size(82, 20);
            this.lblAuditFromDate.TabIndex = 0;
            this.lblAuditFromDate.Text = "From Date:";
            // 
            // dtpAuditFrom
            // 
            this.dtpAuditFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAuditFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditFrom.Location = new System.Drawing.Point(98, 3);
            this.dtpAuditFrom.Name = "dtpAuditFrom";
            this.dtpAuditFrom.Size = new System.Drawing.Size(144, 29);
            this.dtpAuditFrom.TabIndex = 1;
            // 
            // lblAuditToDate
            // 
            this.lblAuditToDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditToDate.AutoSize = true;
            this.lblAuditToDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditToDate.Location = new System.Drawing.Point(248, 7);
            this.lblAuditToDate.Name = "lblAuditToDate";
            this.lblAuditToDate.Size = new System.Drawing.Size(64, 20);
            this.lblAuditToDate.TabIndex = 2;
            this.lblAuditToDate.Text = "To Date:";
            // 
            // dtpAuditTo
            // 
            this.dtpAuditTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAuditTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditTo.Location = new System.Drawing.Point(318, 3);
            this.dtpAuditTo.Name = "dtpAuditTo";
            this.dtpAuditTo.Size = new System.Drawing.Size(144, 29);
            this.dtpAuditTo.TabIndex = 3;
            // 
            // lblAuditStatus
            // 
            this.lblAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditStatus.AutoSize = true;
            this.lblAuditStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditStatus.Location = new System.Drawing.Point(536, 7);
            this.lblAuditStatus.Name = "lblAuditStatus";
            this.lblAuditStatus.Size = new System.Drawing.Size(52, 20);
            this.lblAuditStatus.TabIndex = 4;
            this.lblAuditStatus.Text = "Status:";
            // 
            // cmbAuditStatus
            // 
            this.cmbAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbAuditStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAuditStatus.FormattingEnabled = true;
            this.cmbAuditStatus.Location = new System.Drawing.Point(594, 5);
            this.cmbAuditStatus.Name = "cmbAuditStatus";
            this.cmbAuditStatus.Size = new System.Drawing.Size(174, 25);
            this.cmbAuditStatus.TabIndex = 5;
            // 
            // lblAuditRequestNo
            // 
            this.lblAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditRequestNo.AutoSize = true;
            this.lblAuditRequestNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditRequestNo.Location = new System.Drawing.Point(3, 42);
            this.lblAuditRequestNo.Name = "lblAuditRequestNo";
            this.lblAuditRequestNo.Size = new System.Drawing.Size(89, 20);
            this.lblAuditRequestNo.TabIndex = 6;
            this.lblAuditRequestNo.Text = "Request No:";
            // 
            // txtAuditRequestNo
            // 
            this.txtAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditRequestNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAuditRequestNo.Location = new System.Drawing.Point(98, 40);
            this.txtAuditRequestNo.Name = "txtAuditRequestNo";
            this.txtAuditRequestNo.Size = new System.Drawing.Size(144, 25);
            this.txtAuditRequestNo.TabIndex = 7;
            // 
            // lblAuditProduct
            // 
            this.lblAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditProduct.AutoSize = true;
            this.lblAuditProduct.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditProduct.Location = new System.Drawing.Point(249, 42);
            this.lblAuditProduct.Name = "lblAuditProduct";
            this.lblAuditProduct.Size = new System.Drawing.Size(63, 20);
            this.lblAuditProduct.TabIndex = 8;
            this.lblAuditProduct.Text = "Product:";
            // 
            // txtAuditProduct
            // 
            this.txtAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAuditProduct.Location = new System.Drawing.Point(318, 40);
            this.txtAuditProduct.Name = "txtAuditProduct";
            this.txtAuditProduct.Size = new System.Drawing.Size(144, 25);
            this.txtAuditProduct.TabIndex = 9;
            // 
            // btnApplyAuditFilter
            // 
            this.btnApplyAuditFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApplyAuditFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApplyAuditFilter.Location = new System.Drawing.Point(468, 38);
            this.btnApplyAuditFilter.Name = "btnApplyAuditFilter";
            this.btnApplyAuditFilter.Size = new System.Drawing.Size(120, 29);
            this.btnApplyAuditFilter.TabIndex = 10;
            this.btnApplyAuditFilter.Text = "Apply Filters";
            this.btnApplyAuditFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearAuditFilters
            // 
            this.btnClearAuditFilters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearAuditFilters.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAuditFilters.Location = new System.Drawing.Point(594, 38);
            this.btnClearAuditFilters.Name = "btnClearAuditFilters";
            this.btnClearAuditFilters.Size = new System.Drawing.Size(120, 29);
            this.btnClearAuditFilters.TabIndex = 11;
            this.btnClearAuditFilters.Text = "Clear Filters";
            this.btnClearAuditFilters.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAuditList
            // 
            this.btnRefreshAuditList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefreshAuditList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAuditList.Location = new System.Drawing.Point(774, 38);
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
            this.dgvAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditTrail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditTrail.Location = new System.Drawing.Point(3, 117);
            this.dgvAuditTrail.Name = "dgvAuditTrail";
            this.dgvAuditTrail.ReadOnly = true;
            this.dgvAuditTrail.RowHeadersWidth = 51;
            this.dgvAuditTrail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditTrail.Size = new System.Drawing.Size(1334, 475);
            this.dgvAuditTrail.TabIndex = 1;
            // 
            // flpAuditExportButtons
            // 
            this.flpAuditExportButtons.Controls.Add(this.btnExportToCsv);
            this.flpAuditExportButtons.Controls.Add(this.btnExportToExcel);
            this.flpAuditExportButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAuditExportButtons.Location = new System.Drawing.Point(3, 598);
            this.flpAuditExportButtons.Name = "flpAuditExportButtons";
            this.flpAuditExportButtons.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpAuditExportButtons.Size = new System.Drawing.Size(1334, 39);
            this.flpAuditExportButtons.TabIndex = 2;
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportToCsv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPageUsers.Controls.Add(this.scUsersMain);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 30);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageUsers.Size = new System.Drawing.Size(1360, 660);
            this.tabPageUsers.TabIndex = 5;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // scUsersMain
            // 
            this.scUsersMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scUsersMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scUsersMain.Location = new System.Drawing.Point(10, 10);
            this.scUsersMain.Name = "scUsersMain";
            // 
            // scUsersMain.Panel1
            // 
            this.scUsersMain.Panel1.Controls.Add(this.dgvUserRoles);
            this.scUsersMain.Panel1.Controls.Add(this.tlpUserRolesHeader);
            this.scUsersMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // scUsersMain.Panel2
            // 
            this.scUsersMain.Panel2.Controls.Add(this.grpManageRole);
            this.scUsersMain.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.scUsersMain.Size = new System.Drawing.Size(1340, 640);
            this.scUsersMain.SplitterDistance = 450;
            this.scUsersMain.TabIndex = 0;
            // 
            // dgvUserRoles
            // 
            this.dgvUserRoles.AllowUserToAddRows = false;
            this.dgvUserRoles.AllowUserToDeleteRows = false;
            this.dgvUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserRoleId,
            this.colUserRoleName});
            this.dgvUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserRoles.Location = new System.Drawing.Point(5, 40);
            this.dgvUserRoles.MultiSelect = false;
            this.dgvUserRoles.Name = "dgvUserRoles";
            this.dgvUserRoles.ReadOnly = true;
            this.dgvUserRoles.RowHeadersWidth = 51;
            this.dgvUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserRoles.Size = new System.Drawing.Size(440, 595);
            this.dgvUserRoles.TabIndex = 0;
            // 
            // colUserRoleId
            // 
            this.colUserRoleId.DataPropertyName = "RoleID";
            this.colUserRoleId.FillWeight = 50F;
            this.colUserRoleId.HeaderText = "Role ID";
            this.colUserRoleId.MinimumWidth = 6;
            this.colUserRoleId.Name = "colUserRoleId";
            this.colUserRoleId.ReadOnly = true;
            // 
            // colUserRoleName
            // 
            this.colUserRoleName.DataPropertyName = "RoleName";
            this.colUserRoleName.FillWeight = 150F;
            this.colUserRoleName.HeaderText = "Role Name";
            this.colUserRoleName.MinimumWidth = 6;
            this.colUserRoleName.Name = "colUserRoleName";
            this.colUserRoleName.ReadOnly = true;
            // 
            // tlpUserRolesHeader
            // 
            this.tlpUserRolesHeader.ColumnCount = 2;
            this.tlpUserRolesHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpUserRolesHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpUserRolesHeader.Controls.Add(this.lblApplicationRoles, 0, 0);
            this.tlpUserRolesHeader.Controls.Add(this.btnRefreshUserRoles, 1, 0);
            this.tlpUserRolesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpUserRolesHeader.Location = new System.Drawing.Point(5, 5);
            this.tlpUserRolesHeader.Name = "tlpUserRolesHeader";
            this.tlpUserRolesHeader.RowCount = 1;
            this.tlpUserRolesHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpUserRolesHeader.Size = new System.Drawing.Size(440, 35);
            this.tlpUserRolesHeader.TabIndex = 2;
            // 
            // lblApplicationRoles
            // 
            this.lblApplicationRoles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblApplicationRoles.AutoSize = true;
            this.lblApplicationRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblApplicationRoles.Location = new System.Drawing.Point(3, 8);
            this.lblApplicationRoles.Name = "lblApplicationRoles";
            this.lblApplicationRoles.Size = new System.Drawing.Size(119, 19);
            this.lblApplicationRoles.TabIndex = 0;
            this.lblApplicationRoles.Text = "Application Roles";
            // 
            // btnRefreshUserRoles
            // 
            this.btnRefreshUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshUserRoles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshUserRoles.Location = new System.Drawing.Point(322, 3);
            this.btnRefreshUserRoles.Name = "btnRefreshUserRoles";
            this.btnRefreshUserRoles.Size = new System.Drawing.Size(115, 29);
            this.btnRefreshUserRoles.TabIndex = 1;
            this.btnRefreshUserRoles.Text = "Refresh List";
            this.btnRefreshUserRoles.UseVisualStyleBackColor = true;
            // 
            // grpManageRole
            // 
            this.grpManageRole.Controls.Add(this.tlpManageRole);
            this.grpManageRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManageRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpManageRole.Location = new System.Drawing.Point(5, 5);
            this.grpManageRole.Name = "grpManageRole";
            this.grpManageRole.Padding = new System.Windows.Forms.Padding(10);
            this.grpManageRole.Size = new System.Drawing.Size(876, 630);
            this.grpManageRole.TabIndex = 0;
            this.grpManageRole.TabStop = false;
            this.grpManageRole.Text = "Manage Role";
            // 
            // tlpManageRole
            // 
            this.tlpManageRole.ColumnCount = 2;
            this.tlpManageRole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpManageRole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpManageRole.Controls.Add(this.lblRoleNameManage, 0, 0);
            this.tlpManageRole.Controls.Add(this.txtRoleNameManage, 1, 0);
            this.tlpManageRole.Controls.Add(this.flpRoleManagementButtons, 0, 1);
            this.tlpManageRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpManageRole.Location = new System.Drawing.Point(10, 32);
            this.tlpManageRole.Name = "tlpManageRole";
            this.tlpManageRole.RowCount = 2;
            this.tlpManageRole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpManageRole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpManageRole.Size = new System.Drawing.Size(856, 588);
            this.tlpManageRole.TabIndex = 0;
            // 
            // lblRoleNameManage
            // 
            this.lblRoleNameManage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRoleNameManage.AutoSize = true;
            this.lblRoleNameManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleNameManage.Location = new System.Drawing.Point(3, 7);
            this.lblRoleNameManage.Name = "lblRoleNameManage";
            this.lblRoleNameManage.Size = new System.Drawing.Size(90, 21);
            this.lblRoleNameManage.TabIndex = 0;
            this.lblRoleNameManage.Text = "Role Name:";
            // 
            // txtRoleNameManage
            // 
            this.txtRoleNameManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoleNameManage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRoleNameManage.Location = new System.Drawing.Point(99, 5);
            this.txtRoleNameManage.Name = "txtRoleNameManage";
            this.txtRoleNameManage.ReadOnly = true;
            this.txtRoleNameManage.Size = new System.Drawing.Size(754, 25);
            this.txtRoleNameManage.TabIndex = 1;
            // 
            // flpRoleManagementButtons
            // 
            this.tlpManageRole.SetColumnSpan(this.flpRoleManagementButtons, 2);
            this.flpRoleManagementButtons.Controls.Add(this.btnAddRole);
            this.flpRoleManagementButtons.Controls.Add(this.btnEditRole);
            this.flpRoleManagementButtons.Controls.Add(this.btnDeleteRole);
            this.flpRoleManagementButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRoleManagementButtons.Location = new System.Drawing.Point(3, 38);
            this.flpRoleManagementButtons.Name = "flpRoleManagementButtons";
            this.flpRoleManagementButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpRoleManagementButtons.Size = new System.Drawing.Size(850, 547);
            this.flpRoleManagementButtons.TabIndex = 2;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.Location = new System.Drawing.Point(3, 8);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(120, 35);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.UseVisualStyleBackColor = true;
            // 
            // btnEditRole
            // 
            this.btnEditRole.Enabled = false;
            this.btnEditRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRole.Location = new System.Drawing.Point(129, 8);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(120, 35);
            this.btnEditRole.TabIndex = 1;
            this.btnEditRole.Text = "Edit Role";
            this.btnEditRole.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Enabled = false;
            this.btnDeleteRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRole.Location = new System.Drawing.Point(255, 8);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteRole.TabIndex = 2;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelSpring,
            this.toolStripStatusLabelDateTime});
            this.statusStripMain.Location = new System.Drawing.Point(0, 694);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1368, 26);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(127, 21);
            this.toolStripStatusLabelUser.Text = "User: Loading...";
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(1056, 21);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // toolStripStatusLabelDateTime
            // 
            this.toolStripStatusLabelDateTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            this.toolStripStatusLabelDateTime.Size = new System.Drawing.Size(170, 21);
            this.toolStripStatusLabelDateTime.Text = "Date Time: Loading...";
            this.toolStripStatusLabelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
            this.tlpLoginMain.ResumeLayout(false);
            this.panelLoginContainer.ResumeLayout(false);
            this.panelLoginContainer.PerformLayout();
            this.tabPageDocumentIssuance.ResumeLayout(false);
            this.tlpDocumentIssuanceMain.ResumeLayout(false);
            this.tlpDocumentIssuanceMain.PerformLayout();
            this.tlpTopSectionDI.ResumeLayout(false);
            this.grpDocTypeDI.ResumeLayout(false);
            this.tlpDocTypesAndNumbers.ResumeLayout(false);
            this.tlpDocTypesAndNumbers.PerformLayout();
            this.pnlTopRightDI.ResumeLayout(false);
            this.tlpTopRightDetailsDI.ResumeLayout(false);
            this.tlpTopRightDetailsDI.PerformLayout();
            this.pnlRequestDetailsDI.ResumeLayout(false);
            this.pnlRequestDetailsDI.PerformLayout();
            this.tlpRequestDetails.ResumeLayout(false);
            this.tlpRequestDetails.PerformLayout();
            this.grpParentBatchInfoDI.ResumeLayout(false);
            this.grpParentBatchInfoDI.PerformLayout();
            this.tlpParentBatchInfo.ResumeLayout(false);
            this.tlpParentBatchInfo.PerformLayout();
            this.flpParentBatchSize.ResumeLayout(false);
            this.flpParentBatchSize.PerformLayout();
            this.flpParentMfgDate.ResumeLayout(false);
            this.flpParentExpDate.ResumeLayout(false);
            this.grpItemDetailsDI.ResumeLayout(false);
            this.grpItemDetailsDI.PerformLayout();
            this.tlpItemDetails.ResumeLayout(false);
            this.tlpItemDetails.PerformLayout();
            this.flpItemBatchSize.ResumeLayout(false);
            this.flpItemBatchSize.PerformLayout();
            this.flpItemMfgDate.ResumeLayout(false);
            this.flpItemExpDate.ResumeLayout(false);
            this.grpRemarksDI.ResumeLayout(false);
            this.grpRemarksDI.PerformLayout();
            this.pnlActionBottomDI.ResumeLayout(false);
            this.flpActionButtonsDI.ResumeLayout(false);
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
            this.tabPageUsers.ResumeLayout(false);
            this.scUsersMain.Panel1.ResumeLayout(false);
            this.scUsersMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scUsersMain)).EndInit();
            this.scUsersMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).EndInit();
            this.tlpUserRolesHeader.ResumeLayout(false);
            this.tlpUserRolesHeader.PerformLayout();
            this.grpManageRole.ResumeLayout(false);
            this.tlpManageRole.ResumeLayout(false);
            this.tlpManageRole.PerformLayout();
            this.flpRoleManagementButtons.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TableLayoutPanel tlpLoginMain;
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
        private System.Windows.Forms.Label lblParentMfgDateDI;
        private System.Windows.Forms.Label lblParentExpDateDI;
        private System.Windows.Forms.GroupBox grpItemDetailsDI;
        private System.Windows.Forms.TableLayoutPanel tlpItemDetails;
        private System.Windows.Forms.Label lblProductDI;
        private System.Windows.Forms.TextBox txtProductDI;
        private System.Windows.Forms.Label lblBatchNoDI;
        private System.Windows.Forms.TextBox txtBatchNoDI;
        private System.Windows.Forms.Label lblBatchSizeDI;
        private System.Windows.Forms.Label lblItemMfgDateDI;
        private System.Windows.Forms.Label lblItemExpDateDI;
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
        private System.Windows.Forms.TabPage tabPageGmOperations;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaAuthorizedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaGmActionAt;
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
        private System.Windows.Forms.Label lblQaDetailGmCommentLabel;
        private System.Windows.Forms.TextBox txtQaDetailGmComment;
        private System.Windows.Forms.Label lblQaDetailGmActionTimeLabel;
        private System.Windows.Forms.TextBox txtQaDetailGmActionTime;
        private System.Windows.Forms.GroupBox grpQaAction;
        private System.Windows.Forms.TableLayoutPanel tlpQaActionControls;
        private System.Windows.Forms.FlowLayoutPanel flpQaOptionalControls;
        private System.Windows.Forms.Label lblQaPrintCount;
        private System.Windows.Forms.NumericUpDown numQaPrintCount;
        private System.Windows.Forms.Button btnQaBrowseSelectDocument;
        private System.Windows.Forms.Label lblQaComment;
        private System.Windows.Forms.TextBox txtQaComment;
        private System.Windows.Forms.FlowLayoutPanel flpQaActionButtons;
        private System.Windows.Forms.Button btnQaApprove;
        private System.Windows.Forms.Button btnQaReject;
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
        private System.Windows.Forms.SplitContainer scUsersMain;
        private System.Windows.Forms.TableLayoutPanel tlpUserRolesHeader;
        private System.Windows.Forms.Label lblApplicationRoles;
        private System.Windows.Forms.Button btnRefreshUserRoles;
        private System.Windows.Forms.DataGridView dgvUserRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRoleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRoleName;
        private System.Windows.Forms.GroupBox grpManageRole;
        private System.Windows.Forms.TableLayoutPanel tlpManageRole;
        private System.Windows.Forms.Label lblRoleNameManage;
        private System.Windows.Forms.TextBox txtRoleNameManage;
        private System.Windows.Forms.FlowLayoutPanel flpRoleManagementButtons;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.TableLayoutPanel tlpDocTypesAndNumbers;
        private System.Windows.Forms.Label lblBmrDocNo;
        private System.Windows.Forms.TextBox txtBmrDocNoDI;
        private System.Windows.Forms.Label lblBprDocNo;
        private System.Windows.Forms.TextBox txtBprDocNoDI;
        private System.Windows.Forms.Label lblAppendixDocNo;
        private System.Windows.Forms.TextBox txtAppendixDocNoDI;
        private System.Windows.Forms.Label lblAddendumDocNo;
        private System.Windows.Forms.TextBox txtAddendumDocNoDI;
        private System.Windows.Forms.FlowLayoutPanel flpParentMfgDate;
        private System.Windows.Forms.ComboBox cmbParentMfgMonthDI;
        private System.Windows.Forms.ComboBox cmbParentMfgYearDI;
        private System.Windows.Forms.FlowLayoutPanel flpParentExpDate;
        private System.Windows.Forms.ComboBox cmbParentExpMonthDI;
        private System.Windows.Forms.ComboBox cmbParentExpYearDI;
        private System.Windows.Forms.FlowLayoutPanel flpItemMfgDate;
        private System.Windows.Forms.ComboBox cmbItemMfgMonthDI;
        private System.Windows.Forms.ComboBox cmbItemMfgYearDI;
        private System.Windows.Forms.FlowLayoutPanel flpItemExpDate;
        private System.Windows.Forms.ComboBox cmbItemExpMonthDI;
        private System.Windows.Forms.ComboBox cmbItemExpYearDI;
        private System.Windows.Forms.FlowLayoutPanel flpParentBatchSize;
        private System.Windows.Forms.TextBox txtParentBatchSizeValueDI;
        private System.Windows.Forms.ComboBox cmbParentBatchSizeUnitDI;
        private System.Windows.Forms.FlowLayoutPanel flpItemBatchSize;
        private System.Windows.Forms.TextBox txtItemBatchSizeValueDI;
        private System.Windows.Forms.ComboBox cmbItemBatchSizeUnitDI;
        private System.Windows.Forms.TableLayoutPanel tlpTopRightDetailsDI;
        private System.Windows.Forms.FlowLayoutPanel flpActionButtonsDI;

    }

}