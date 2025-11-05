// AuditTrailControl.Designer.cs

namespace IssuanceApp.UI.Controls
{
    partial class AuditTrailControl
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
            this.btnApplyAuditFilter = new IssuanceApp.UI.RoundedButton();
            this.btnClearAuditFilters = new IssuanceApp.UI.RoundedButton();
            this.btnRefreshAuditList = new IssuanceApp.UI.RoundedButton();
            this.chkIgnoreDateFilter = new System.Windows.Forms.CheckBox();
            this.chkFilterByCurrentUser = new System.Windows.Forms.CheckBox();
            this.dgvAuditTrail = new System.Windows.Forms.DataGridView();
            this.flpAuditExportButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportToCsv = new IssuanceApp.UI.RoundedButton();
            this.btnExportToExcel = new IssuanceApp.UI.RoundedButton();
            this.tlpAuditTrailMain.SuspendLayout();
            this.grpAuditFilters.SuspendLayout();
            this.tlpAuditFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).BeginInit();
            this.flpAuditExportButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAuditTrailMain
            // 
            this.tlpAuditTrailMain.AutoScroll = true;
            this.tlpAuditTrailMain.ColumnCount = 1;
            this.tlpAuditTrailMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuditTrailMain.Controls.Add(this.grpAuditFilters, 0, 0);
            this.tlpAuditTrailMain.Controls.Add(this.dgvAuditTrail, 0, 1);
            this.tlpAuditTrailMain.Controls.Add(this.flpAuditExportButtons, 0, 2);
            this.tlpAuditTrailMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuditTrailMain.Location = new System.Drawing.Point(0, 0);
            this.tlpAuditTrailMain.Name = "tlpAuditTrailMain";
            this.tlpAuditTrailMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpAuditTrailMain.RowCount = 3;
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuditTrailMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpAuditTrailMain.Size = new System.Drawing.Size(1313, 581);
            this.tlpAuditTrailMain.TabIndex = 1;
            // 
            // grpAuditFilters
            // 
            this.grpAuditFilters.AutoSize = true;
            this.grpAuditFilters.Controls.Add(this.tlpAuditFilters);
            this.grpAuditFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAuditFilters.Location = new System.Drawing.Point(13, 13);
            this.grpAuditFilters.Name = "grpAuditFilters";
            this.grpAuditFilters.Padding = new System.Windows.Forms.Padding(10);
            this.grpAuditFilters.Size = new System.Drawing.Size(1287, 143);
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
            this.tlpAuditFilters.Controls.Add(this.chkIgnoreDateFilter, 0, 2);
            this.tlpAuditFilters.Controls.Add(this.chkFilterByCurrentUser, 2, 2);
            this.tlpAuditFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuditFilters.Location = new System.Drawing.Point(10, 28);
            this.tlpAuditFilters.Name = "tlpAuditFilters";
            this.tlpAuditFilters.RowCount = 3;
            this.tlpAuditFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAuditFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAuditFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAuditFilters.Size = new System.Drawing.Size(1267, 105);
            this.tlpAuditFilters.TabIndex = 0;
            // 
            // lblAuditFromDate
            // 
            this.lblAuditFromDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditFromDate.AutoSize = true;
            this.lblAuditFromDate.Location = new System.Drawing.Point(10, 9);
            this.lblAuditFromDate.Name = "lblAuditFromDate";
            this.lblAuditFromDate.Size = new System.Drawing.Size(75, 17);
            this.lblAuditFromDate.TabIndex = 0;
            this.lblAuditFromDate.Text = "From Date:";
            // 
            // dtpAuditFrom
            // 
            this.dtpAuditFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditFrom.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAuditFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditFrom.Location = new System.Drawing.Point(91, 4);
            this.dtpAuditFrom.Name = "dtpAuditFrom";
            this.dtpAuditFrom.Size = new System.Drawing.Size(144, 27);
            this.dtpAuditFrom.TabIndex = 1;
            // 
            // lblAuditToDate
            // 
            this.lblAuditToDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditToDate.AutoSize = true;
            this.lblAuditToDate.Location = new System.Drawing.Point(243, 9);
            this.lblAuditToDate.Name = "lblAuditToDate";
            this.lblAuditToDate.Size = new System.Drawing.Size(57, 17);
            this.lblAuditToDate.TabIndex = 2;
            this.lblAuditToDate.Text = "To Date:";
            // 
            // dtpAuditTo
            // 
            this.dtpAuditTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAuditTo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAuditTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditTo.Location = new System.Drawing.Point(306, 4);
            this.dtpAuditTo.Name = "dtpAuditTo";
            this.dtpAuditTo.Size = new System.Drawing.Size(144, 27);
            this.dtpAuditTo.TabIndex = 3;
            // 
            // lblAuditStatus
            // 
            this.lblAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditStatus.AutoSize = true;
            this.lblAuditStatus.Location = new System.Drawing.Point(514, 9);
            this.lblAuditStatus.Name = "lblAuditStatus";
            this.lblAuditStatus.Size = new System.Drawing.Size(49, 17);
            this.lblAuditStatus.TabIndex = 4;
            this.lblAuditStatus.Text = "Status:";
            // 
            // cmbAuditStatus
            // 
            this.cmbAuditStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbAuditStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditStatus.FormattingEnabled = true;
            this.cmbAuditStatus.Location = new System.Drawing.Point(569, 5);
            this.cmbAuditStatus.Name = "cmbAuditStatus";
            this.cmbAuditStatus.Size = new System.Drawing.Size(174, 25);
            this.cmbAuditStatus.TabIndex = 5;
            // 
            // lblAuditRequestNo
            // 
            this.lblAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditRequestNo.AutoSize = true;
            this.lblAuditRequestNo.Location = new System.Drawing.Point(3, 44);
            this.lblAuditRequestNo.Name = "lblAuditRequestNo";
            this.lblAuditRequestNo.Size = new System.Drawing.Size(82, 17);
            this.lblAuditRequestNo.TabIndex = 6;
            this.lblAuditRequestNo.Text = "Request No:";
            // 
            // txtAuditRequestNo
            // 
            this.txtAuditRequestNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditRequestNo.Location = new System.Drawing.Point(91, 40);
            this.txtAuditRequestNo.Name = "txtAuditRequestNo";
            this.txtAuditRequestNo.Size = new System.Drawing.Size(144, 25);
            this.txtAuditRequestNo.TabIndex = 7;
            // 
            // lblAuditProduct
            // 
            this.lblAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuditProduct.AutoSize = true;
            this.lblAuditProduct.Location = new System.Drawing.Point(241, 44);
            this.lblAuditProduct.Name = "lblAuditProduct";
            this.lblAuditProduct.Size = new System.Drawing.Size(59, 17);
            this.lblAuditProduct.TabIndex = 8;
            this.lblAuditProduct.Text = "Product:";
            // 
            // txtAuditProduct
            // 
            this.txtAuditProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAuditProduct.Location = new System.Drawing.Point(306, 40);
            this.txtAuditProduct.Name = "txtAuditProduct";
            this.txtAuditProduct.Size = new System.Drawing.Size(144, 25);
            this.txtAuditProduct.TabIndex = 9;
            // 
            // btnApplyAuditFilter
            // 
            this.btnApplyAuditFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApplyAuditFilter.CornerRadius = 8;
            this.btnApplyAuditFilter.FlatAppearance.BorderSize = 0;
            this.btnApplyAuditFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyAuditFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyAuditFilter.Location = new System.Drawing.Point(456, 38);
            this.btnApplyAuditFilter.Name = "btnApplyAuditFilter";
            this.btnApplyAuditFilter.Size = new System.Drawing.Size(107, 29);
            this.btnApplyAuditFilter.TabIndex = 10;
            this.btnApplyAuditFilter.Text = "Apply Filters";
            this.btnApplyAuditFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearAuditFilters
            // 
            this.btnClearAuditFilters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearAuditFilters.CornerRadius = 8;
            this.btnClearAuditFilters.FlatAppearance.BorderSize = 0;
            this.btnClearAuditFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAuditFilters.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAuditFilters.Location = new System.Drawing.Point(569, 38);
            this.btnClearAuditFilters.Name = "btnClearAuditFilters";
            this.btnClearAuditFilters.Size = new System.Drawing.Size(120, 29);
            this.btnClearAuditFilters.TabIndex = 11;
            this.btnClearAuditFilters.Text = "Clear Filters";
            this.btnClearAuditFilters.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAuditList
            // 
            this.btnRefreshAuditList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefreshAuditList.CornerRadius = 8;
            this.btnRefreshAuditList.FlatAppearance.BorderSize = 0;
            this.btnRefreshAuditList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAuditList.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAuditList.Location = new System.Drawing.Point(749, 38);
            this.btnRefreshAuditList.Name = "btnRefreshAuditList";
            this.btnRefreshAuditList.Size = new System.Drawing.Size(120, 29);
            this.btnRefreshAuditList.TabIndex = 12;
            this.btnRefreshAuditList.Text = "Refresh List";
            this.btnRefreshAuditList.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreDateFilter
            // 
            this.chkIgnoreDateFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIgnoreDateFilter.AutoSize = true;
            this.tlpAuditFilters.SetColumnSpan(this.chkIgnoreDateFilter, 2);
            this.chkIgnoreDateFilter.Location = new System.Drawing.Point(3, 76);
            this.chkIgnoreDateFilter.Name = "chkIgnoreDateFilter";
            this.chkIgnoreDateFilter.Size = new System.Drawing.Size(180, 21);
            this.chkIgnoreDateFilter.TabIndex = 13;
            this.chkIgnoreDateFilter.Text = "Ignore Date Filter (All Time)";
            this.chkIgnoreDateFilter.UseVisualStyleBackColor = true;
            // 
            // chkFilterByCurrentUser
            // 
            this.chkFilterByCurrentUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFilterByCurrentUser.AutoSize = true;
            this.tlpAuditFilters.SetColumnSpan(this.chkFilterByCurrentUser, 2);
            this.chkFilterByCurrentUser.Location = new System.Drawing.Point(241, 76);
            this.chkFilterByCurrentUser.Name = "chkFilterByCurrentUser";
            this.chkFilterByCurrentUser.Size = new System.Drawing.Size(180, 21);
            this.chkFilterByCurrentUser.TabIndex = 14;
            this.chkFilterByCurrentUser.Text = "Show My Requests Only";
            this.chkFilterByCurrentUser.UseVisualStyleBackColor = true;
            // 
            // dgvAuditTrail
            // 
            this.dgvAuditTrail.AllowUserToAddRows = false;
            this.dgvAuditTrail.AllowUserToDeleteRows = false;
            this.dgvAuditTrail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvAuditTrail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditTrail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditTrail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditTrail.Location = new System.Drawing.Point(13, 162);
            this.dgvAuditTrail.Name = "dgvAuditTrail";
            this.dgvAuditTrail.ReadOnly = true;
            this.dgvAuditTrail.RowHeadersWidth = 51;
            this.dgvAuditTrail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditTrail.Size = new System.Drawing.Size(1287, 370);
            this.dgvAuditTrail.TabIndex = 1;
            this.dgvAuditTrail.VirtualMode = true;
            // 
            // flpAuditExportButtons
            // 
            this.flpAuditExportButtons.Controls.Add(this.btnExportToCsv);
            this.flpAuditExportButtons.Controls.Add(this.btnExportToExcel);
            this.flpAuditExportButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAuditExportButtons.Location = new System.Drawing.Point(13, 538);
            this.flpAuditExportButtons.Name = "flpAuditExportButtons";
            this.flpAuditExportButtons.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpAuditExportButtons.Size = new System.Drawing.Size(1287, 30);
            this.flpAuditExportButtons.TabIndex = 2;
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportToCsv.CornerRadius = 8;
            this.btnExportToCsv.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCsv.Location = new System.Drawing.Point(8, 4);
            this.btnExportToCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(180, 30);
            this.btnExportToCsv.TabIndex = 0;
            this.btnExportToCsv.Text = "Export to CSV";
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportToExcel.CornerRadius = 8;
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(194, 4);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(180, 30);
            this.btnExportToExcel.TabIndex = 1;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // AuditTrailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpAuditTrailMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Name = "AuditTrailControl";
            this.Size = new System.Drawing.Size(1313, 581);
            this.tlpAuditTrailMain.ResumeLayout(false);
            this.tlpAuditTrailMain.PerformLayout();
            this.grpAuditFilters.ResumeLayout(false);
            this.grpAuditFilters.PerformLayout();
            this.tlpAuditFilters.ResumeLayout(false);
            this.tlpAuditFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTrail)).EndInit();
            this.flpAuditExportButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

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
        private UI.RoundedButton btnApplyAuditFilter;
        private UI.RoundedButton btnClearAuditFilters;
        private UI.RoundedButton btnRefreshAuditList;
        private System.Windows.Forms.CheckBox chkIgnoreDateFilter;
        private System.Windows.Forms.CheckBox chkFilterByCurrentUser;
        private System.Windows.Forms.DataGridView dgvAuditTrail;
        private System.Windows.Forms.FlowLayoutPanel flpAuditExportButtons;
        private UI.RoundedButton btnExportToCsv;
        private UI.RoundedButton btnExportToExcel;
    }
}