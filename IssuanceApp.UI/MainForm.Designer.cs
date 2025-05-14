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
            this.pnlStatusDI = new System.Windows.Forms.Panel();
            this.lblStatusValueDI = new System.Windows.Forms.Label();
            this.lblStatusLabelDI = new System.Windows.Forms.Label();
            this.pnlActionBottomDI = new System.Windows.Forms.Panel();
            this.btnClearFormDI = new System.Windows.Forms.Button();
            this.btnSubmitRequestDI = new System.Windows.Forms.Button();
            this.grpRemarksDI = new System.Windows.Forms.GroupBox();
            this.txtRemarksDI = new System.Windows.Forms.TextBox();
            this.grpItemDetailsDI = new System.Windows.Forms.GroupBox();
            this.txtExportOrderNoDI = new System.Windows.Forms.TextBox();
            this.lblExportOrderNoDI = new System.Windows.Forms.Label();
            this.txtPackSizeDI = new System.Windows.Forms.TextBox();
            this.lblPackSizeDI = new System.Windows.Forms.Label();
            this.txtMarketDI = new System.Windows.Forms.TextBox();
            this.lblMarketDI = new System.Windows.Forms.Label();
            this.dtpItemExpDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblItemExpDateDI = new System.Windows.Forms.Label();
            this.dtpItemMfgDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblItemMfgDateDI = new System.Windows.Forms.Label();
            this.txtBatchSizeDI = new System.Windows.Forms.TextBox();
            this.lblBatchSizeDI = new System.Windows.Forms.Label();
            this.txtBatchNoDI = new System.Windows.Forms.TextBox();
            this.lblBatchNoDI = new System.Windows.Forms.Label();
            this.txtDocumentNoDI = new System.Windows.Forms.TextBox();
            this.lblDocumentNoDI = new System.Windows.Forms.Label();
            this.txtProductDI = new System.Windows.Forms.TextBox();
            this.lblProductDI = new System.Windows.Forms.Label();
            this.grpParentBatchInfoDI = new System.Windows.Forms.GroupBox();
            this.dtpParentExpDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblParentExpDateDI = new System.Windows.Forms.Label();
            this.dtpParentMfgDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblParentMfgDateDI = new System.Windows.Forms.Label();
            this.numParentBatchSizeDI = new System.Windows.Forms.NumericUpDown();
            this.lblParentBatchSizeDI = new System.Windows.Forms.Label();
            this.txtParentBatchNoDI = new System.Windows.Forms.TextBox();
            this.lblParentBatchNoDI = new System.Windows.Forms.Label();
            this.pnlRequestDetailsDI = new System.Windows.Forms.Panel();
            this.cmbFromDepartmentDI = new System.Windows.Forms.ComboBox();
            this.lblFromDepartmentDI = new System.Windows.Forms.Label();
            this.dtpRequestDateDI = new System.Windows.Forms.DateTimePicker();
            this.lblRequestDateDI = new System.Windows.Forms.Label();
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
            this.lblHeaderDI = new System.Windows.Forms.Label();
            this.tabPageGmOperations = new System.Windows.Forms.TabPage();
            this.tabPageQa = new System.Windows.Forms.TabPage();
            this.tabPageAuditTrail = new System.Windows.Forms.TabPage();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.panelLoginContainer.SuspendLayout();
            this.tabPageDocumentIssuance.SuspendLayout();
            this.pnlStatusDI.SuspendLayout();
            this.pnlActionBottomDI.SuspendLayout();
            this.grpRemarksDI.SuspendLayout();
            this.grpItemDetailsDI.SuspendLayout();
            this.grpParentBatchInfoDI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParentBatchSizeDI)).BeginInit();
            this.pnlRequestDetailsDI.SuspendLayout();
            this.grpDocTypeDI.SuspendLayout();
            this.pnlTopRightDI.SuspendLayout();
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
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1204, 597);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.panelLoginContainer);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 26);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1196, 567);
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
            this.panelLoginContainer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLoginContainer.Location = new System.Drawing.Point(377, 169);
            this.panelLoginContainer.Name = "panelLoginContainer";
            this.panelLoginContainer.Size = new System.Drawing.Size(444, 228);
            this.panelLoginContainer.TabIndex = 0;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginStatus.Location = new System.Drawing.Point(138, 179);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(162, 17);
            this.lblLoginStatus.TabIndex = 5;
            this.lblLoginStatus.Text = "*Please login to continue.";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(141, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.Location = new System.Drawing.Point(141, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(230, 29);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(46, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(141, 46);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(230, 29);
            this.cmbRole.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(46, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(89, 20);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Select Role:";
            // 
            // tabPageDocumentIssuance
            // 
            this.tabPageDocumentIssuance.AutoScroll = true;
            this.tabPageDocumentIssuance.Controls.Add(this.pnlStatusDI);
            this.tabPageDocumentIssuance.Controls.Add(this.pnlActionBottomDI);
            this.tabPageDocumentIssuance.Controls.Add(this.grpRemarksDI);
            this.tabPageDocumentIssuance.Controls.Add(this.grpItemDetailsDI);
            this.tabPageDocumentIssuance.Controls.Add(this.grpParentBatchInfoDI);
            this.tabPageDocumentIssuance.Controls.Add(this.pnlRequestDetailsDI);
            this.tabPageDocumentIssuance.Controls.Add(this.grpDocTypeDI);
            this.tabPageDocumentIssuance.Controls.Add(this.pnlTopRightDI);
            this.tabPageDocumentIssuance.Controls.Add(this.lblHeaderDI);
            this.tabPageDocumentIssuance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDocumentIssuance.Location = new System.Drawing.Point(4, 26);
            this.tabPageDocumentIssuance.Name = "tabPageDocumentIssuance";
            this.tabPageDocumentIssuance.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageDocumentIssuance.Size = new System.Drawing.Size(1196, 567);
            this.tabPageDocumentIssuance.TabIndex = 1;
            this.tabPageDocumentIssuance.Text = "Document Issuance";
            this.tabPageDocumentIssuance.UseVisualStyleBackColor = true;
            // 
            // pnlStatusDI
            // 
            this.pnlStatusDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatusDI.Controls.Add(this.lblStatusValueDI);
            this.pnlStatusDI.Controls.Add(this.lblStatusLabelDI);
            this.pnlStatusDI.Location = new System.Drawing.Point(18, 509);
            this.pnlStatusDI.Name = "pnlStatusDI";
            this.pnlStatusDI.Size = new System.Drawing.Size(1160, 30);
            this.pnlStatusDI.TabIndex = 8;
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
            // pnlActionBottomDI
            // 
            this.pnlActionBottomDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActionBottomDI.Controls.Add(this.btnClearFormDI);
            this.pnlActionBottomDI.Controls.Add(this.btnSubmitRequestDI);
            this.pnlActionBottomDI.Location = new System.Drawing.Point(18, 459);
            this.pnlActionBottomDI.Name = "pnlActionBottomDI";
            this.pnlActionBottomDI.Size = new System.Drawing.Size(1160, 45);
            this.pnlActionBottomDI.TabIndex = 7;
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
            // grpRemarksDI
            // 
            this.grpRemarksDI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRemarksDI.Controls.Add(this.txtRemarksDI);
            this.grpRemarksDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpRemarksDI.Location = new System.Drawing.Point(18, 390);
            this.grpRemarksDI.Name = "grpRemarksDI";
            this.grpRemarksDI.Padding = new System.Windows.Forms.Padding(10);
            this.grpRemarksDI.Size = new System.Drawing.Size(1160, 64);
            this.grpRemarksDI.TabIndex = 6;
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
            this.txtRemarksDI.Size = new System.Drawing.Size(1140, 26);
            this.txtRemarksDI.TabIndex = 0;
            // 
            // grpItemDetailsDI
            // 
            this.grpItemDetailsDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItemDetailsDI.Controls.Add(this.txtExportOrderNoDI);
            this.grpItemDetailsDI.Controls.Add(this.lblExportOrderNoDI);
            this.grpItemDetailsDI.Controls.Add(this.txtPackSizeDI);
            this.grpItemDetailsDI.Controls.Add(this.lblPackSizeDI);
            this.grpItemDetailsDI.Controls.Add(this.txtMarketDI);
            this.grpItemDetailsDI.Controls.Add(this.lblMarketDI);
            this.grpItemDetailsDI.Controls.Add(this.dtpItemExpDateDI);
            this.grpItemDetailsDI.Controls.Add(this.lblItemExpDateDI);
            this.grpItemDetailsDI.Controls.Add(this.dtpItemMfgDateDI);
            this.grpItemDetailsDI.Controls.Add(this.lblItemMfgDateDI);
            this.grpItemDetailsDI.Controls.Add(this.txtBatchSizeDI);
            this.grpItemDetailsDI.Controls.Add(this.lblBatchSizeDI);
            this.grpItemDetailsDI.Controls.Add(this.txtBatchNoDI);
            this.grpItemDetailsDI.Controls.Add(this.lblBatchNoDI);
            this.grpItemDetailsDI.Controls.Add(this.txtDocumentNoDI);
            this.grpItemDetailsDI.Controls.Add(this.lblDocumentNoDI);
            this.grpItemDetailsDI.Controls.Add(this.txtProductDI);
            this.grpItemDetailsDI.Controls.Add(this.lblProductDI);
            this.grpItemDetailsDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpItemDetailsDI.Location = new System.Drawing.Point(18, 260);
            this.grpItemDetailsDI.Name = "grpItemDetailsDI";
            this.grpItemDetailsDI.Size = new System.Drawing.Size(1160, 125);
            this.grpItemDetailsDI.TabIndex = 5;
            this.grpItemDetailsDI.TabStop = false;
            this.grpItemDetailsDI.Text = "Item/Product Details";
            // 
            // txtExportOrderNoDI
            // 
            this.txtExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtExportOrderNoDI.Location = new System.Drawing.Point(780, 93);
            this.txtExportOrderNoDI.Name = "txtExportOrderNoDI";
            this.txtExportOrderNoDI.Size = new System.Drawing.Size(220, 25);
            this.txtExportOrderNoDI.TabIndex = 17;
            // 
            // lblExportOrderNoDI
            // 
            this.lblExportOrderNoDI.AutoSize = true;
            this.lblExportOrderNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblExportOrderNoDI.Location = new System.Drawing.Point(690, 96);
            this.lblExportOrderNoDI.Name = "lblExportOrderNoDI";
            this.lblExportOrderNoDI.Size = new System.Drawing.Size(79, 17);
            this.lblExportOrderNoDI.TabIndex = 16;
            this.lblExportOrderNoDI.Text = "Export Ord.:";
            // 
            // txtPackSizeDI
            // 
            this.txtPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPackSizeDI.Location = new System.Drawing.Point(450, 93);
            this.txtPackSizeDI.Name = "txtPackSizeDI";
            this.txtPackSizeDI.Size = new System.Drawing.Size(220, 25);
            this.txtPackSizeDI.TabIndex = 15;
            // 
            // lblPackSizeDI
            // 
            this.lblPackSizeDI.AutoSize = true;
            this.lblPackSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPackSizeDI.Location = new System.Drawing.Point(350, 96);
            this.lblPackSizeDI.Name = "lblPackSizeDI";
            this.lblPackSizeDI.Size = new System.Drawing.Size(64, 17);
            this.lblPackSizeDI.TabIndex = 14;
            this.lblPackSizeDI.Text = "Pack Size:";
            // 
            // txtMarketDI
            // 
            this.txtMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMarketDI.Location = new System.Drawing.Point(100, 93);
            this.txtMarketDI.Name = "txtMarketDI";
            this.txtMarketDI.Size = new System.Drawing.Size(220, 25);
            this.txtMarketDI.TabIndex = 13;
            // 
            // lblMarketDI
            // 
            this.lblMarketDI.AutoSize = true;
            this.lblMarketDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblMarketDI.Location = new System.Drawing.Point(12, 96);
            this.lblMarketDI.Name = "lblMarketDI";
            this.lblMarketDI.Size = new System.Drawing.Size(52, 17);
            this.lblMarketDI.TabIndex = 12;
            this.lblMarketDI.Text = "Market:";
            // 
            // dtpItemExpDateDI
            // 
            this.dtpItemExpDateDI.Checked = false;
            this.dtpItemExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpItemExpDateDI.Location = new System.Drawing.Point(780, 60);
            this.dtpItemExpDateDI.Name = "dtpItemExpDateDI";
            this.dtpItemExpDateDI.ShowCheckBox = true;
            this.dtpItemExpDateDI.Size = new System.Drawing.Size(220, 25);
            this.dtpItemExpDateDI.TabIndex = 11;
            // 
            // lblItemExpDateDI
            // 
            this.lblItemExpDateDI.AutoSize = true;
            this.lblItemExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemExpDateDI.Location = new System.Drawing.Point(690, 63);
            this.lblItemExpDateDI.Name = "lblItemExpDateDI";
            this.lblItemExpDateDI.Size = new System.Drawing.Size(66, 17);
            this.lblItemExpDateDI.TabIndex = 10;
            this.lblItemExpDateDI.Text = "Exp. Date:";
            // 
            // dtpItemMfgDateDI
            // 
            this.dtpItemMfgDateDI.Checked = false;
            this.dtpItemMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpItemMfgDateDI.Location = new System.Drawing.Point(450, 60);
            this.dtpItemMfgDateDI.Name = "dtpItemMfgDateDI";
            this.dtpItemMfgDateDI.ShowCheckBox = true;
            this.dtpItemMfgDateDI.Size = new System.Drawing.Size(220, 25);
            this.dtpItemMfgDateDI.TabIndex = 9;
            // 
            // lblItemMfgDateDI
            // 
            this.lblItemMfgDateDI.AutoSize = true;
            this.lblItemMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblItemMfgDateDI.Location = new System.Drawing.Point(350, 63);
            this.lblItemMfgDateDI.Name = "lblItemMfgDateDI";
            this.lblItemMfgDateDI.Size = new System.Drawing.Size(69, 17);
            this.lblItemMfgDateDI.TabIndex = 8;
            this.lblItemMfgDateDI.Text = "Mfg. Date:";
            // 
            // txtBatchSizeDI
            // 
            this.txtBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBatchSizeDI.Location = new System.Drawing.Point(100, 60);
            this.txtBatchSizeDI.Name = "txtBatchSizeDI";
            this.txtBatchSizeDI.Size = new System.Drawing.Size(220, 25);
            this.txtBatchSizeDI.TabIndex = 7;
            // 
            // lblBatchSizeDI
            // 
            this.lblBatchSizeDI.AutoSize = true;
            this.lblBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchSizeDI.Location = new System.Drawing.Point(12, 63);
            this.lblBatchSizeDI.Name = "lblBatchSizeDI";
            this.lblBatchSizeDI.Size = new System.Drawing.Size(69, 17);
            this.lblBatchSizeDI.TabIndex = 6;
            this.lblBatchSizeDI.Text = "Batch Size:";
            // 
            // txtBatchNoDI
            // 
            this.txtBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBatchNoDI.Location = new System.Drawing.Point(780, 27);
            this.txtBatchNoDI.Name = "txtBatchNoDI";
            this.txtBatchNoDI.Size = new System.Drawing.Size(220, 25);
            this.txtBatchNoDI.TabIndex = 5;
            // 
            // lblBatchNoDI
            // 
            this.lblBatchNoDI.AutoSize = true;
            this.lblBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchNoDI.Location = new System.Drawing.Point(690, 30);
            this.lblBatchNoDI.Name = "lblBatchNoDI";
            this.lblBatchNoDI.Size = new System.Drawing.Size(67, 17);
            this.lblBatchNoDI.TabIndex = 4;
            this.lblBatchNoDI.Text = "Batch No.:";
            // 
            // txtDocumentNoDI
            // 
            this.txtDocumentNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDocumentNoDI.Location = new System.Drawing.Point(450, 27);
            this.txtDocumentNoDI.Name = "txtDocumentNoDI";
            this.txtDocumentNoDI.Size = new System.Drawing.Size(220, 25);
            this.txtDocumentNoDI.TabIndex = 3;
            // 
            // lblDocumentNoDI
            // 
            this.lblDocumentNoDI.AutoSize = true;
            this.lblDocumentNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDocumentNoDI.Location = new System.Drawing.Point(350, 30);
            this.lblDocumentNoDI.Name = "lblDocumentNoDI";
            this.lblDocumentNoDI.Size = new System.Drawing.Size(95, 17);
            this.lblDocumentNoDI.TabIndex = 2;
            this.lblDocumentNoDI.Text = "Document No.:";
            // 
            // txtProductDI
            // 
            this.txtProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProductDI.Location = new System.Drawing.Point(100, 27);
            this.txtProductDI.Name = "txtProductDI";
            this.txtProductDI.Size = new System.Drawing.Size(220, 25);
            this.txtProductDI.TabIndex = 1;
            // 
            // lblProductDI
            // 
            this.lblProductDI.AutoSize = true;
            this.lblProductDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblProductDI.Location = new System.Drawing.Point(12, 30);
            this.lblProductDI.Name = "lblProductDI";
            this.lblProductDI.Size = new System.Drawing.Size(56, 17);
            this.lblProductDI.TabIndex = 0;
            this.lblProductDI.Text = "Product:";
            // 
            // grpParentBatchInfoDI
            // 
            this.grpParentBatchInfoDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParentBatchInfoDI.Controls.Add(this.dtpParentExpDateDI);
            this.grpParentBatchInfoDI.Controls.Add(this.lblParentExpDateDI);
            this.grpParentBatchInfoDI.Controls.Add(this.dtpParentMfgDateDI);
            this.grpParentBatchInfoDI.Controls.Add(this.lblParentMfgDateDI);
            this.grpParentBatchInfoDI.Controls.Add(this.numParentBatchSizeDI);
            this.grpParentBatchInfoDI.Controls.Add(this.lblParentBatchSizeDI);
            this.grpParentBatchInfoDI.Controls.Add(this.txtParentBatchNoDI);
            this.grpParentBatchInfoDI.Controls.Add(this.lblParentBatchNoDI);
            this.grpParentBatchInfoDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpParentBatchInfoDI.Location = new System.Drawing.Point(18, 160);
            this.grpParentBatchInfoDI.Name = "grpParentBatchInfoDI";
            this.grpParentBatchInfoDI.Size = new System.Drawing.Size(1160, 95);
            this.grpParentBatchInfoDI.TabIndex = 4;
            this.grpParentBatchInfoDI.TabStop = false;
            this.grpParentBatchInfoDI.Text = "Parent Batch Information (If Applicable)";
            // 
            // dtpParentExpDateDI
            // 
            this.dtpParentExpDateDI.Checked = false;
            this.dtpParentExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpParentExpDateDI.Location = new System.Drawing.Point(510, 60);
            this.dtpParentExpDateDI.Name = "dtpParentExpDateDI";
            this.dtpParentExpDateDI.ShowCheckBox = true;
            this.dtpParentExpDateDI.Size = new System.Drawing.Size(200, 25);
            this.dtpParentExpDateDI.TabIndex = 7;
            // 
            // lblParentExpDateDI
            // 
            this.lblParentExpDateDI.AutoSize = true;
            this.lblParentExpDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentExpDateDI.Location = new System.Drawing.Point(380, 63);
            this.lblParentExpDateDI.Name = "lblParentExpDateDI";
            this.lblParentExpDateDI.Size = new System.Drawing.Size(107, 17);
            this.lblParentExpDateDI.TabIndex = 6;
            this.lblParentExpDateDI.Text = "Parent Exp. Date:";
            // 
            // dtpParentMfgDateDI
            // 
            this.dtpParentMfgDateDI.Checked = false;
            this.dtpParentMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpParentMfgDateDI.Location = new System.Drawing.Point(150, 60);
            this.dtpParentMfgDateDI.Name = "dtpParentMfgDateDI";
            this.dtpParentMfgDateDI.ShowCheckBox = true;
            this.dtpParentMfgDateDI.Size = new System.Drawing.Size(200, 25);
            this.dtpParentMfgDateDI.TabIndex = 5;
            // 
            // lblParentMfgDateDI
            // 
            this.lblParentMfgDateDI.AutoSize = true;
            this.lblParentMfgDateDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentMfgDateDI.Location = new System.Drawing.Point(12, 63);
            this.lblParentMfgDateDI.Name = "lblParentMfgDateDI";
            this.lblParentMfgDateDI.Size = new System.Drawing.Size(110, 17);
            this.lblParentMfgDateDI.TabIndex = 4;
            this.lblParentMfgDateDI.Text = "Parent Mfg. Date:";
            // 
            // numParentBatchSizeDI
            // 
            this.numParentBatchSizeDI.DecimalPlaces = 2;
            this.numParentBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numParentBatchSizeDI.Location = new System.Drawing.Point(510, 28);
            this.numParentBatchSizeDI.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numParentBatchSizeDI.Name = "numParentBatchSizeDI";
            this.numParentBatchSizeDI.Size = new System.Drawing.Size(150, 25);
            this.numParentBatchSizeDI.TabIndex = 3;
            // 
            // lblParentBatchSizeDI
            // 
            this.lblParentBatchSizeDI.AutoSize = true;
            this.lblParentBatchSizeDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchSizeDI.Location = new System.Drawing.Point(380, 30);
            this.lblParentBatchSizeDI.Name = "lblParentBatchSizeDI";
            this.lblParentBatchSizeDI.Size = new System.Drawing.Size(110, 17);
            this.lblParentBatchSizeDI.TabIndex = 2;
            this.lblParentBatchSizeDI.Text = "Parent Batch Size:";
            // 
            // txtParentBatchNoDI
            // 
            this.txtParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtParentBatchNoDI.Location = new System.Drawing.Point(150, 27);
            this.txtParentBatchNoDI.Name = "txtParentBatchNoDI";
            this.txtParentBatchNoDI.Size = new System.Drawing.Size(200, 25);
            this.txtParentBatchNoDI.TabIndex = 1;
            // 
            // lblParentBatchNoDI
            // 
            this.lblParentBatchNoDI.AutoSize = true;
            this.lblParentBatchNoDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParentBatchNoDI.Location = new System.Drawing.Point(12, 30);
            this.lblParentBatchNoDI.Name = "lblParentBatchNoDI";
            this.lblParentBatchNoDI.Size = new System.Drawing.Size(135, 17);
            this.lblParentBatchNoDI.TabIndex = 0;
            this.lblParentBatchNoDI.Text = "Parent Batch Number:";
            // 
            // pnlRequestDetailsDI
            // 
            this.pnlRequestDetailsDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRequestDetailsDI.Controls.Add(this.cmbFromDepartmentDI);
            this.pnlRequestDetailsDI.Controls.Add(this.lblFromDepartmentDI);
            this.pnlRequestDetailsDI.Controls.Add(this.dtpRequestDateDI);
            this.pnlRequestDetailsDI.Controls.Add(this.lblRequestDateDI);
            this.pnlRequestDetailsDI.Location = new System.Drawing.Point(18, 115);
            this.pnlRequestDetailsDI.Name = "pnlRequestDetailsDI";
            this.pnlRequestDetailsDI.Size = new System.Drawing.Size(1160, 40);
            this.pnlRequestDetailsDI.TabIndex = 3;
            // 
            // cmbFromDepartmentDI
            // 
            this.cmbFromDepartmentDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDepartmentDI.FormattingEnabled = true;
            this.cmbFromDepartmentDI.Items.AddRange(new object[] {
            "PRD - Production Department",
            "PKG - Packaging Department"});
            this.cmbFromDepartmentDI.Location = new System.Drawing.Point(510, 7);
            this.cmbFromDepartmentDI.Name = "cmbFromDepartmentDI";
            this.cmbFromDepartmentDI.Size = new System.Drawing.Size(250, 25);
            this.cmbFromDepartmentDI.TabIndex = 3;
            // 
            // lblFromDepartmentDI
            // 
            this.lblFromDepartmentDI.AutoSize = true;
            this.lblFromDepartmentDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFromDepartmentDI.Location = new System.Drawing.Point(380, 10);
            this.lblFromDepartmentDI.Name = "lblFromDepartmentDI";
            this.lblFromDepartmentDI.Size = new System.Drawing.Size(120, 17);
            this.lblFromDepartmentDI.TabIndex = 2;
            this.lblFromDepartmentDI.Text = "From Department:";
            // 
            // dtpRequestDateDI
            // 
            this.dtpRequestDateDI.Location = new System.Drawing.Point(120, 7);
            this.dtpRequestDateDI.Name = "dtpRequestDateDI";
            this.dtpRequestDateDI.Size = new System.Drawing.Size(230, 25);
            this.dtpRequestDateDI.TabIndex = 1;
            // 
            // lblRequestDateDI
            // 
            this.lblRequestDateDI.AutoSize = true;
            this.lblRequestDateDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRequestDateDI.Location = new System.Drawing.Point(12, 10);
            this.lblRequestDateDI.Name = "lblRequestDateDI";
            this.lblRequestDateDI.Size = new System.Drawing.Size(92, 17);
            this.lblRequestDateDI.TabIndex = 0;
            this.lblRequestDateDI.Text = "Request Date:";
            // 
            // grpDocTypeDI
            // 
            this.grpDocTypeDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeAddendumDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeAppendixDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeBPRDI);
            this.grpDocTypeDI.Controls.Add(this.chkDocTypeBMRDI);
            this.grpDocTypeDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDocTypeDI.Location = new System.Drawing.Point(18, 50);
            this.grpDocTypeDI.Name = "grpDocTypeDI";
            this.grpDocTypeDI.Size = new System.Drawing.Size(815, 60);
            this.grpDocTypeDI.TabIndex = 2;
            this.grpDocTypeDI.TabStop = false;
            this.grpDocTypeDI.Text = "Document Type";
            // 
            // chkDocTypeAddendumDI
            // 
            this.chkDocTypeAddendumDI.AutoSize = true;
            this.chkDocTypeAddendumDI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkDocTypeAddendumDI.Location = new System.Drawing.Point(300, 25);
            this.chkDocTypeAddendumDI.Name = "chkDocTypeAddendumDI";
            this.chkDocTypeAddendumDI.Size = new System.Drawing.Size(91, 21);
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
            this.chkDocTypeAppendixDI.Size = new System.Drawing.Size(82, 21);
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
            this.chkDocTypeBPRDI.Size = new System.Drawing.Size(49, 21);
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
            this.chkDocTypeBMRDI.Size = new System.Drawing.Size(54, 21);
            this.chkDocTypeBMRDI.TabIndex = 0;
            this.chkDocTypeBMRDI.Text = "BMR";
            this.chkDocTypeBMRDI.UseVisualStyleBackColor = true;
            // 
            // pnlTopRightDI
            // 
            this.pnlTopRightDI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopRightDI.Controls.Add(this.txtRequestNoValueDI);
            this.pnlTopRightDI.Controls.Add(this.lblRequestNoLabelDI);
            this.pnlTopRightDI.Controls.Add(this.lblTrackerNoValueDI);
            this.pnlTopRightDI.Controls.Add(this.lblTrackerNoLabelDI);
            this.pnlTopRightDI.Location = new System.Drawing.Point(845, 50);
            this.pnlTopRightDI.Name = "pnlTopRightDI";
            this.pnlTopRightDI.Size = new System.Drawing.Size(330, 60);
            this.pnlTopRightDI.TabIndex = 1;
            // 
            // txtRequestNoValueDI
            // 
            this.txtRequestNoValueDI.Location = new System.Drawing.Point(100, 29);
            this.txtRequestNoValueDI.Name = "txtRequestNoValueDI";
            this.txtRequestNoValueDI.ReadOnly = true;
            this.txtRequestNoValueDI.Size = new System.Drawing.Size(220, 25);
            this.txtRequestNoValueDI.TabIndex = 3;
            this.txtRequestNoValueDI.Text = "(placeholder)";
            // 
            // lblRequestNoLabelDI
            // 
            this.lblRequestNoLabelDI.AutoSize = true;
            this.lblRequestNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestNoLabelDI.Location = new System.Drawing.Point(3, 32);
            this.lblRequestNoLabelDI.Name = "lblRequestNoLabelDI";
            this.lblRequestNoLabelDI.Size = new System.Drawing.Size(85, 17);
            this.lblRequestNoLabelDI.TabIndex = 2;
            this.lblRequestNoLabelDI.Text = "Request No.:";
            // 
            // lblTrackerNoValueDI
            // 
            this.lblTrackerNoValueDI.AutoSize = true;
            this.lblTrackerNoValueDI.Location = new System.Drawing.Point(100, 5);
            this.lblTrackerNoValueDI.Name = "lblTrackerNoValueDI";
            this.lblTrackerNoValueDI.Size = new System.Drawing.Size(52, 17);
            this.lblTrackerNoValueDI.TabIndex = 1;
            this.lblTrackerNoValueDI.Text = "(empty)";
            // 
            // lblTrackerNoLabelDI
            // 
            this.lblTrackerNoLabelDI.AutoSize = true;
            this.lblTrackerNoLabelDI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackerNoLabelDI.Location = new System.Drawing.Point(3, 5);
            this.lblTrackerNoLabelDI.Name = "lblTrackerNoLabelDI";
            this.lblTrackerNoLabelDI.Size = new System.Drawing.Size(79, 17);
            this.lblTrackerNoLabelDI.TabIndex = 0;
            this.lblTrackerNoLabelDI.Text = "Tracker No.:";
            // 
            // lblHeaderDI
            // 
            this.lblHeaderDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderDI.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDI.Location = new System.Drawing.Point(18, 15);
            this.lblHeaderDI.Name = "lblHeaderDI";
            this.lblHeaderDI.Size = new System.Drawing.Size(1160, 30);
            this.lblHeaderDI.TabIndex = 0;
            this.lblHeaderDI.Text = "DOCUMENT ISSUANCE";
            this.lblHeaderDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageGmOperations
            // 
            this.tabPageGmOperations.Location = new System.Drawing.Point(4, 26);
            this.tabPageGmOperations.Name = "tabPageGmOperations";
            this.tabPageGmOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGmOperations.Size = new System.Drawing.Size(1051, 633);
            this.tabPageGmOperations.TabIndex = 2;
            this.tabPageGmOperations.Text = "GM Operations";
            this.tabPageGmOperations.UseVisualStyleBackColor = true;
            // 
            // tabPageQa
            // 
            this.tabPageQa.Location = new System.Drawing.Point(4, 26);
            this.tabPageQa.Name = "tabPageQa";
            this.tabPageQa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQa.Size = new System.Drawing.Size(1051, 633);
            this.tabPageQa.TabIndex = 3;
            this.tabPageQa.Text = "QA";
            this.tabPageQa.UseVisualStyleBackColor = true;
            // 
            // tabPageAuditTrail
            // 
            this.tabPageAuditTrail.Location = new System.Drawing.Point(4, 26);
            this.tabPageAuditTrail.Name = "tabPageAuditTrail";
            this.tabPageAuditTrail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuditTrail.Size = new System.Drawing.Size(1051, 633);
            this.tabPageAuditTrail.TabIndex = 4;
            this.tabPageAuditTrail.Text = "Audit Trail";
            this.tabPageAuditTrail.UseVisualStyleBackColor = true;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Location = new System.Drawing.Point(4, 26);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1051, 633);
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
            this.statusStripMain.Location = new System.Drawing.Point(0, 597);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1204, 26);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(127, 21);
            this.toolStripStatusLabelUser.Text = "User: Loading...";
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(848, 21);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // toolStripStatusLabelDateTime
            // 
            this.toolStripStatusLabelDateTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            this.toolStripStatusLabelDateTime.Size = new System.Drawing.Size(170, 21);
            this.toolStripStatusLabelDateTime.Text = "Date Time: Loading...";
            this.toolStripStatusLabelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 623);
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
            this.pnlStatusDI.ResumeLayout(false);
            this.pnlStatusDI.PerformLayout();
            this.pnlActionBottomDI.ResumeLayout(false);
            this.grpRemarksDI.ResumeLayout(false);
            this.grpRemarksDI.PerformLayout();
            this.grpItemDetailsDI.ResumeLayout(false);
            this.grpItemDetailsDI.PerformLayout();
            this.grpParentBatchInfoDI.ResumeLayout(false);
            this.grpParentBatchInfoDI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParentBatchSizeDI)).EndInit();
            this.pnlRequestDetailsDI.ResumeLayout(false);
            this.pnlRequestDetailsDI.PerformLayout();
            this.grpDocTypeDI.ResumeLayout(false);
            this.grpDocTypeDI.PerformLayout();
            this.pnlTopRightDI.ResumeLayout(false);
            this.pnlTopRightDI.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageDocumentIssuance;
        private System.Windows.Forms.TabPage tabPageGmOperations;
        private System.Windows.Forms.TabPage tabPageQa;
        private System.Windows.Forms.TabPage tabPageAuditTrail;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
        private System.Windows.Forms.Panel panelLoginContainer;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginStatus;

        // Controls for Document Issuance Tab
        private System.Windows.Forms.Label lblHeaderDI;
        private System.Windows.Forms.Panel pnlTopRightDI;
        private System.Windows.Forms.Label lblTrackerNoLabelDI;
        private System.Windows.Forms.Label lblTrackerNoValueDI;
        private System.Windows.Forms.Label lblRequestNoLabelDI;
        private System.Windows.Forms.TextBox txtRequestNoValueDI;
        private System.Windows.Forms.GroupBox grpDocTypeDI;
        private System.Windows.Forms.CheckBox chkDocTypeBMRDI;
        private System.Windows.Forms.CheckBox chkDocTypeBPRDI;
        private System.Windows.Forms.CheckBox chkDocTypeAppendixDI;
        private System.Windows.Forms.CheckBox chkDocTypeAddendumDI;
        private System.Windows.Forms.Panel pnlRequestDetailsDI;
        private System.Windows.Forms.Label lblRequestDateDI;
        private System.Windows.Forms.DateTimePicker dtpRequestDateDI;
        private System.Windows.Forms.Label lblFromDepartmentDI;
        private System.Windows.Forms.ComboBox cmbFromDepartmentDI;
        private System.Windows.Forms.GroupBox grpParentBatchInfoDI;
        private System.Windows.Forms.Label lblParentBatchNoDI;
        private System.Windows.Forms.TextBox txtParentBatchNoDI;
        private System.Windows.Forms.Label lblParentBatchSizeDI;
        private System.Windows.Forms.NumericUpDown numParentBatchSizeDI;
        private System.Windows.Forms.Label lblParentMfgDateDI;
        private System.Windows.Forms.DateTimePicker dtpParentMfgDateDI;
        private System.Windows.Forms.Label lblParentExpDateDI;
        private System.Windows.Forms.DateTimePicker dtpParentExpDateDI;
        private System.Windows.Forms.GroupBox grpItemDetailsDI;
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
        private System.Windows.Forms.Button btnSubmitRequestDI;
        private System.Windows.Forms.Button btnClearFormDI;
        private System.Windows.Forms.Panel pnlStatusDI;
        private System.Windows.Forms.Label lblStatusLabelDI;
        private System.Windows.Forms.Label lblStatusValueDI;
    }
}
