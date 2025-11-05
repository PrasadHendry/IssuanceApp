// MainForm.Designer.cs

using System.Windows.Forms;

namespace IssuanceApp.UI
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
        /// Required method for support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.loginControl1 = new IssuanceApp.UI.Controls.LoginControl();
            this.tabPageDocumentIssuance = new System.Windows.Forms.TabPage();
            this.documentIssuanceControl1 = new IssuanceApp.UI.Controls.DocumentIssuanceControl();
            // --- RENAMED: tabPageGmOperations to tabPageHod ---
            this.tabPageHod = new System.Windows.Forms.TabPage();
            this.hodControl1 = new IssuanceApp.UI.Controls.HodControl(); // RENAMED CONTROL VARIABLE AND TYPE
            // --- END RENAMED ---
            this.tabPageQa = new System.Windows.Forms.TabPage();
            this.qaControl1 = new IssuanceApp.UI.Controls.QaControl();
            this.tabPageAuditTrail = new System.Windows.Forms.TabPage();
            this.auditTrailControl1 = new IssuanceApp.UI.Controls.AuditTrailControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.usersControl1 = new IssuanceApp.UI.Controls.UsersControl();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMasterContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAppHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.flpHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSignOut = new IssuanceApp.UI.RoundedButton();
            this.lblCurrentUserHeader = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageDocumentIssuance.SuspendLayout();
            // --- RENAMED: tabPageGmOperations to tabPageHod ---
            this.tabPageHod.SuspendLayout();
            // --- END RENAMED ---
            this.tabPageQa.SuspendLayout();
            this.tabPageAuditTrail.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tlpMasterContainer.SuspendLayout();
            this.pnlAppHeader.SuspendLayout();
            this.flpHeader.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLogin);
            this.tabControlMain.Controls.Add(this.tabPageDocumentIssuance);
            // --- RENAMED: tabPageGmOperations to tabPageHod ---
            this.tabControlMain.Controls.Add(this.tabPageHod);
            // --- END RENAMED ---
            this.tabControlMain.Controls.Add(this.tabPageQa);
            this.tabControlMain.Controls.Add(this.tabPageAuditTrail);
            this.tabControlMain.Controls.Add(this.tabPageUsers);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 56);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1342, 615);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.loginControl1);
            this.tabPageLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageLogin.Location = new System.Drawing.Point(4, 26);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1334, 585);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // loginControl1
            // 
            this.loginControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginControl1.Location = new System.Drawing.Point(3, 3);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(1328, 579);
            this.loginControl1.TabIndex = 0;
            // 
            // tabPageDocumentIssuance
            // 
            this.tabPageDocumentIssuance.Controls.Add(this.documentIssuanceControl1);
            this.tabPageDocumentIssuance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDocumentIssuance.Location = new System.Drawing.Point(4, 26);
            this.tabPageDocumentIssuance.Name = "tabPageDocumentIssuance";
            this.tabPageDocumentIssuance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDocumentIssuance.Size = new System.Drawing.Size(1334, 585);
            this.tabPageDocumentIssuance.TabIndex = 1;
            this.tabPageDocumentIssuance.Text = "Document Issuance";
            this.tabPageDocumentIssuance.UseVisualStyleBackColor = true;
            // 
            // documentIssuanceControl1
            // 
            this.documentIssuanceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentIssuanceControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentIssuanceControl1.Location = new System.Drawing.Point(3, 3);
            this.documentIssuanceControl1.Name = "documentIssuanceControl1";
            this.documentIssuanceControl1.Size = new System.Drawing.Size(1328, 579);
            this.documentIssuanceControl1.TabIndex = 0;
            // 
            // tabPageHod
            // 
            this.tabPageHod.Controls.Add(this.hodControl1); // RENAMED CONTROL INSTANCE
            this.tabPageHod.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageHod.Location = new System.Drawing.Point(4, 26);
            this.tabPageHod.Name = "tabPageHod"; // RENAMED TAB PAGE NAME
            this.tabPageHod.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHod.Size = new System.Drawing.Size(1334, 585);
            this.tabPageHod.TabIndex = 2;
            this.tabPageHod.Text = "HOD Operations"; // UPDATED DISPLAY TEXT
            this.tabPageHod.UseVisualStyleBackColor = true;
            // 
            // hodControl1
            // 
            this.hodControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hodControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hodControl1.Location = new System.Drawing.Point(3, 3);
            this.hodControl1.Name = "hodControl1"; // RENAMED CONTROL NAME
            this.hodControl1.Size = new System.Drawing.Size(1328, 579);
            this.hodControl1.TabIndex = 0;
            // 
            // tabPageQa
            // 
            this.tabPageQa.Controls.Add(this.qaControl1);
            this.tabPageQa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageQa.Location = new System.Drawing.Point(4, 26);
            this.tabPageQa.Name = "tabPageQa";
            this.tabPageQa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQa.Size = new System.Drawing.Size(1334, 585);
            this.tabPageQa.TabIndex = 3;
            this.tabPageQa.Text = "QA";
            this.tabPageQa.UseVisualStyleBackColor = true;
            // 
            // qaControl1
            // 
            this.qaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qaControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qaControl1.Location = new System.Drawing.Point(3, 3);
            this.qaControl1.Name = "qaControl1";
            this.qaControl1.Size = new System.Drawing.Size(1328, 579);
            this.qaControl1.TabIndex = 0;
            // 
            // tabPageAuditTrail
            // 
            this.tabPageAuditTrail.Controls.Add(this.auditTrailControl1);
            this.tabPageAuditTrail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAuditTrail.Location = new System.Drawing.Point(4, 26);
            this.tabPageAuditTrail.Name = "tabPageAuditTrail";
            this.tabPageAuditTrail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuditTrail.Size = new System.Drawing.Size(1334, 585);
            this.tabPageAuditTrail.TabIndex = 4;
            this.tabPageAuditTrail.Text = "Audit Trail";
            this.tabPageAuditTrail.UseVisualStyleBackColor = true;
            // 
            // auditTrailControl1
            // 
            this.auditTrailControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.auditTrailControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.auditTrailControl1.Location = new System.Drawing.Point(3, 3);
            this.auditTrailControl1.Name = "auditTrailControl1";
            this.auditTrailControl1.Size = new System.Drawing.Size(1328, 579);
            this.auditTrailControl1.TabIndex = 0;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.usersControl1);
            this.tabPageUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageUsers.Location = new System.Drawing.Point(4, 26);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1334, 585);
            this.tabPageUsers.TabIndex = 5;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // usersControl1
            // 
            this.usersControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.usersControl1.Location = new System.Drawing.Point(3, 3);
            this.usersControl1.Name = "usersControl1";
            this.usersControl1.Padding = new System.Windows.Forms.Padding(10);
            this.usersControl1.Size = new System.Drawing.Size(1328, 579);
            this.usersControl1.TabIndex = 0;
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
            // tlpMasterContainer
            // 
            this.tlpMasterContainer.ColumnCount = 1;
            this.tlpMasterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMasterContainer.Controls.Add(this.pnlAppHeader, 0, 0);
            this.tlpMasterContainer.Controls.Add(this.tabControlMain, 0, 1);
            this.tlpMasterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMasterContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpMasterContainer.Name = "tlpMasterContainer";
            this.tlpMasterContainer.RowCount = 2;
            this.tlpMasterContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMasterContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMasterContainer.Size = new System.Drawing.Size(1348, 674);
            this.tlpMasterContainer.TabIndex = 2;
            // 
            // pnlAppHeader
            // 
            this.pnlAppHeader.AutoSize = true;
            this.pnlAppHeader.Controls.Add(this.lblAppTitle);
            this.pnlAppHeader.Controls.Add(this.flpHeader);
            this.pnlAppHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlAppHeader.Name = "pnlAppHeader";
            this.pnlAppHeader.Size = new System.Drawing.Size(1342, 47);
            this.pnlAppHeader.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(12, 11);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(254, 25);
            this.lblAppTitle.TabIndex = 102;
            this.lblAppTitle.Text = "Document Issuance System";
            // 
            // flpHeader
            // 
            this.flpHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHeader.AutoSize = true;
            this.flpHeader.Controls.Add(this.btnSignOut);
            this.flpHeader.Controls.Add(this.lblCurrentUserHeader);
            this.flpHeader.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpHeader.Location = new System.Drawing.Point(929, 3);
            this.flpHeader.Name = "flpHeader";
            this.flpHeader.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.flpHeader.Size = new System.Drawing.Size(410, 41);
            this.flpHeader.TabIndex = 0;
            // 
            // btnSignOut
            // 
            this.btnSignOut.CornerRadius = 8;
            this.btnSignOut.FlatAppearance.BorderSize = 1;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(312, 8);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(85, 30);
            this.btnSignOut.TabIndex = 100;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // lblCurrentUserHeader
            // 
            this.lblCurrentUserHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrentUserHeader.AutoSize = true;
            this.lblCurrentUserHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUserHeader.Location = new System.Drawing.Point(156, 13);
            this.lblCurrentUserHeader.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblCurrentUserHeader.Name = "lblCurrentUserHeader";
            this.lblCurrentUserHeader.Size = new System.Drawing.Size(143, 19);
            this.lblCurrentUserHeader.TabIndex = 101;
            this.lblCurrentUserHeader.Text = "User: [Name] ([Role])";
            this.lblCurrentUserHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlMainContainer.Controls.Add(this.tlpMasterContainer);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainContainer.Size = new System.Drawing.Size(1368, 694);
            this.pnlMainContainer.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1368, 720);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.statusStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Issuance App (BMR/BPR - Requests)";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageDocumentIssuance.ResumeLayout(false);
            // --- RENAMED: tabPageGmOperations to tabPageHod ---
            this.tabPageHod.ResumeLayout(false);
            // --- END RENAMED ---
            this.tabPageQa.ResumeLayout(false);
            this.tabPageAuditTrail.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tlpMasterContainer.ResumeLayout(false);
            this.tlpMasterContainer.PerformLayout();
            this.pnlAppHeader.ResumeLayout(false);
            this.pnlAppHeader.PerformLayout();
            this.flpHeader.ResumeLayout(false);
            this.flpHeader.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageDocumentIssuance;
        private System.Windows.Forms.TabPage tabPageQa;
        private System.Windows.Forms.TabPage tabPageAuditTrail;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDateTime;
        // --- RENAMED: tabPageGmOperations to tabPageHod ---
        private System.Windows.Forms.TabPage tabPageHod;
        // --- END RENAMED ---
        private System.Windows.Forms.TableLayoutPanel tlpMasterContainer;
        private System.Windows.Forms.Panel pnlAppHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.FlowLayoutPanel flpHeader;
        private RoundedButton btnSignOut;
        private System.Windows.Forms.Label lblCurrentUserHeader;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.LoginControl loginControl1;
        private Controls.DocumentIssuanceControl documentIssuanceControl1;
        // --- RENAMED: GmOperationsControl to HodControl ---
        private Controls.HodControl hodControl1;
        // --- END RENAMED ---
        private Controls.QaControl qaControl1;
        private Controls.AuditTrailControl auditTrailControl1;
        private Controls.UsersControl usersControl1;
    }
}