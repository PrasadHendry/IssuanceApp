// IssuanceApp.UI/Controls/DocumentIssuanceControl.cs

using IssuanceApp.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
{
    public partial class DocumentIssuanceControl : UserControl
    {
        private IssuanceRepository _repository;
        private string _loggedInUserName;

        public DocumentIssuanceControl()
        {
            InitializeComponent();
            ThemeManager.StyleSuccessButton(btnSubmitRequestDI);
            ThemeManager.StyleSecondaryButton(btnClearFormDI);
        }

        public void InitializeControl(IssuanceRepository repository, string loggedInUserName)
        {
            _repository = repository;
            _loggedInUserName = loggedInUserName;

            // Wire up events
            chkDocTypeBMRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeBPRDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeAppendixDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            chkDocTypeAddendumDI.CheckedChanged += DocTypeCheckbox_CheckedChanged;
            txtParentBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;
            txtItemBatchSizeValueDI.KeyPress += NumericTextBox_KeyPress;
            btnSubmitRequestDI.Click += BtnSubmitRequestDI_Click;
            btnClearFormDI.Click += BtnClearFormDI_Click;

            // Populate static controls
            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray();
            int currentYear = DateTime.Now.Year;
            List<string> years = Enumerable.Range(currentYear - 10, 21).Select(y => y.ToString()).ToList();
            PopulateMonthYearComboBox(cmbParentMfgMonthDI, cmbParentMfgYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbParentExpMonthDI, cmbParentExpYearDI, monthNames, years, true);
            PopulateMonthYearComboBox(cmbItemMfgMonthDI, cmbItemMfgYearDI, monthNames, years, false);
            PopulateMonthYearComboBox(cmbItemExpMonthDI, cmbItemExpYearDI, monthNames, years, false);

            string[] batchUnits = { "KGS", "TAB", "ML", "GM", "LTR", "MG", "CAPS", "VIALS", "AMPOULES", "BTL" };
            PopulateUnitComboBox(cmbParentBatchSizeUnitDI, batchUnits, true);
            PopulateUnitComboBox(cmbItemBatchSizeUnitDI, batchUnits, false);

            cmbFromDepartmentDI.Items.Clear();
            cmbFromDepartmentDI.Items.AddRange(new string[] { "Production Department", "Quality Assurance", "Research & Development", "Regulatory Affairs", "Manufacturing", "Packaging Department" });
        }

        // This public method will be called by MainForm when the tab becomes visible
        public async Task LoadInitialDataAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                txtRequestNoValueDI.Text = await _repository.GenerateNewRequestNumberAsync();
                ClearDocumentIssuanceForm();
                lblStatusValueDI.Text = "Ready to create a new request.";
                lblStatusValueDI.ForeColor = SystemColors.ControlText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating new request number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequestNoValueDI.Text = "ERROR";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DocTypeCheckbox_CheckedChanged(object sender, EventArgs e) => UpdateDocumentNumberFieldsVisibility();

        private void UpdateDocumentNumberFieldsVisibility()
        {
            lblBmrDocNoDI.Visible = txtBmrDocNoDI.Visible = chkDocTypeBMRDI.Checked;
            if (!chkDocTypeBMRDI.Checked) txtBmrDocNoDI.Clear();
            lblBprDocNoDI.Visible = txtBprDocNoDI.Visible = chkDocTypeBPRDI.Checked;
            if (!chkDocTypeBPRDI.Checked) txtBprDocNoDI.Clear();
            lblAppendixDocNoDI.Visible = txtAppendixDocNoDI.Visible = chkDocTypeAppendixDI.Checked;
            if (!chkDocTypeAppendixDI.Checked) txtAppendixDocNoDI.Clear();
            lblAddendumDocNoDI.Visible = txtAddendumDocNoDI.Visible = chkDocTypeAddendumDI.Checked;
            if (!chkDocTypeAddendumDI.Checked) txtAddendumDocNoDI.Clear();
        }

        private void PopulateMonthYearComboBox(ComboBox cmbMonth, ComboBox cmbYear, string[] months, List<string> years, bool allowNotApplicable)
        {
            cmbMonth.Items.Clear();
            if (allowNotApplicable) cmbMonth.Items.Add("N/A");
            cmbMonth.Items.AddRange(months);
            cmbMonth.SelectedIndex = allowNotApplicable ? 0 : (DateTime.Now.Month - 1);
            cmbYear.Items.Clear();
            if (allowNotApplicable) cmbYear.Items.Add("N/A");
            cmbYear.Items.AddRange(years.ToArray());
            cmbYear.SelectedItem = allowNotApplicable ? "N/A" : DateTime.Now.Year.ToString();
        }

        private void PopulateUnitComboBox(ComboBox cmbUnit, string[] units, bool allowNotApplicable)
        {
            cmbUnit.Items.Clear();
            if (allowNotApplicable) cmbUnit.Items.Add("N/A");
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private async void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            if (cmbFromDepartmentDI.SelectedItem == null || string.IsNullOrWhiteSpace(cmbFromDepartmentDI.SelectedItem.ToString()))
            { MessageBox.Show("Please select a 'From Department'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbFromDepartmentDI.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtProductDI.Text))
            { MessageBox.Show("Please enter the 'Product'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtProductDI.Focus(); return; }
            var docNumbersList = new List<string>();
            if (chkDocTypeBMRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { MessageBox.Show("BMR is checked, please enter BMR Document No.", "Validation Error"); txtBmrDocNoDI.Focus(); return; } docNumbersList.Add(txtBmrDocNoDI.Text.Trim()); }
            if (chkDocTypeBPRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { MessageBox.Show("BPR is checked, please enter BPR Document No.", "Validation Error"); txtBprDocNoDI.Focus(); return; } docNumbersList.Add(txtBprDocNoDI.Text.Trim()); }
            if (chkDocTypeAppendixDI.Checked) { if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { MessageBox.Show("Appendix is checked, please enter Appendix Document No.", "Validation Error"); txtAppendixDocNoDI.Focus(); return; } docNumbersList.Add(txtAppendixDocNoDI.Text.Trim()); }
            if (chkDocTypeAddendumDI.Checked) { if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { MessageBox.Show("Addendum is checked, please enter Addendum Document No.", "Validation Error"); txtAddendumDocNoDI.Focus(); return; } docNumbersList.Add(txtAddendumDocNoDI.Text.Trim()); }
            if (!docNumbersList.Any()) { MessageBox.Show("Please select at least one 'Document Type' and provide its number.", "Validation Error"); grpDocTypeDI.Focus(); return; }
            string parentBatchSizeStr = null;
            if (!string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI.Text))
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _)) { MessageBox.Show("Parent Batch Size must be a valid number.", "Validation Error"); txtParentBatchSizeValueDI.Focus(); return; }
                if (cmbParentBatchSizeUnitDI.SelectedItem == null || cmbParentBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { MessageBox.Show("Please select a Unit for the Parent Batch Size.", "Validation Error"); cmbParentBatchSizeUnitDI.Focus(); return; }
                parentBatchSizeStr = $"{txtParentBatchSizeValueDI.Text.Trim()} {cmbParentBatchSizeUnitDI.SelectedItem}";
            }
            if (string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI.Text)) { MessageBox.Show("Item Batch Size value is required.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _)) { MessageBox.Show("Item Batch Size must be a valid number.", "Validation Error"); txtItemBatchSizeValueDI.Focus(); return; }
            if (cmbItemBatchSizeUnitDI.SelectedItem == null || cmbItemBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { MessageBox.Show("Please select a Unit for the Item Batch Size.", "Validation Error"); cmbItemBatchSizeUnitDI.Focus(); return; }

            var issuanceData = new IssuanceRequestData
            {
                RequestNo = txtRequestNoValueDI.Text,
                RequestDate = dtpRequestDateDI.Value.Date,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentNo = string.Join(",", docNumbersList),
                ParentBatchNumber = string.IsNullOrWhiteSpace(txtParentBatchNoDI.Text) ? null : txtParentBatchNoDI.Text.Trim(),
                ParentBatchSize = parentBatchSizeStr,
                ParentMfgDate = GetDateStringFromComboBoxes(cmbParentMfgMonthDI, cmbParentMfgYearDI),
                ParentExpDate = GetDateStringFromComboBoxes(cmbParentExpMonthDI, cmbParentExpYearDI),
                Product = txtProductDI.Text.Trim(),
                BatchNo = string.IsNullOrWhiteSpace(txtBatchNoDI.Text) ? null : txtBatchNoDI.Text.Trim(),
                BatchSize = $"{txtItemBatchSizeValueDI.Text.Trim()} {cmbItemBatchSizeUnitDI.SelectedItem}",
                ItemMfgDate = GetDateStringFromComboBoxes(cmbItemMfgMonthDI, cmbItemMfgYearDI),
                ItemExpDate = GetDateStringFromComboBoxes(cmbItemExpMonthDI, cmbItemExpYearDI),
                Market = string.IsNullOrWhiteSpace(txtMarketDI.Text) ? null : txtMarketDI.Text.Trim(),
                PackSize = string.IsNullOrWhiteSpace(txtPackSizeDI.Text) ? null : txtPackSizeDI.Text.Trim(),
                ExportOrderNo = string.IsNullOrWhiteSpace(txtExportOrderNoDI.Text) ? null : txtExportOrderNoDI.Text.Trim(),
                RequestComment = txtRemarksDI.Text.Trim(),
                PreparedBy = _loggedInUserName
            };

            btnSubmitRequestDI.Enabled = false;
            btnClearFormDI.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblStatusValueDI.Text = "Submitting request...";
            lblStatusValueDI.ForeColor = SystemColors.ControlText;

            try
            {
                await _repository.CreateIssuanceRequestAsync(issuanceData);
                lblStatusValueDI.Text = $"Request '{issuanceData.RequestNo}' submitted successfully!";
                lblStatusValueDI.ForeColor = ThemeManager.SuccessColor;
                MessageBox.Show($"Request '{issuanceData.RequestNo}' submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadInitialDataAsync();
            }
            catch (Exception ex)
            {
                lblStatusValueDI.Text = "Error submitting request.";
                lblStatusValueDI.ForeColor = ThemeManager.DangerColor;
                MessageBox.Show($"Error submitting request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmitRequestDI.Enabled = true;
                btnClearFormDI.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async void BtnClearFormDI_Click(object sender, EventArgs e)
        {
            await LoadInitialDataAsync();
            lblStatusValueDI.Text = "Form cleared. Ready for new request.";
            lblStatusValueDI.ForeColor = SystemColors.ControlText;
        }

        private void ClearDocumentIssuanceForm()
        {
            chkDocTypeBMRDI.Checked = chkDocTypeBPRDI.Checked = chkDocTypeAppendixDI.Checked = chkDocTypeAddendumDI.Checked = false;
            dtpRequestDateDI.Value = DateTime.Now;
            if (cmbFromDepartmentDI.Items.Count > 0) cmbFromDepartmentDI.SelectedIndex = 0;
            txtParentBatchNoDI.Clear();
            txtParentBatchSizeValueDI.Clear();
            if (cmbParentBatchSizeUnitDI.Items.Count > 0) cmbParentBatchSizeUnitDI.SelectedIndex = 0;
            if (cmbParentMfgMonthDI.Items.Count > 0) cmbParentMfgMonthDI.SelectedIndex = 0;
            if (cmbParentMfgYearDI.Items.Count > 0) cmbParentMfgYearDI.SelectedIndex = 0;
            if (cmbParentExpMonthDI.Items.Count > 0) cmbParentExpMonthDI.SelectedIndex = 0;
            if (cmbParentExpYearDI.Items.Count > 0) cmbParentExpYearDI.SelectedIndex = 0;
            txtProductDI.Clear();
            txtBatchNoDI.Clear();
            txtItemBatchSizeValueDI.Clear();
            if (cmbItemBatchSizeUnitDI.Items.Count > 0) cmbItemBatchSizeUnitDI.SelectedIndex = 0;
            cmbItemMfgMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            cmbItemMfgYearDI.SelectedItem = DateTime.Now.Year.ToString();
            cmbItemExpMonthDI.SelectedIndex = DateTime.Now.Month - 1;
            cmbItemExpYearDI.SelectedItem = DateTime.Now.Year.ToString();
            txtMarketDI.Clear();
            txtPackSizeDI.Clear();
            txtExportOrderNoDI.Clear();
            txtRemarksDI.Clear();
        }

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox)
        {
            string month = monthComboBox?.SelectedItem?.ToString();
            string year = yearComboBox?.SelectedItem?.ToString();
            return (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(year) || month == "N/A" || year == "N/A") ? null : $"{month}/{year}";
        }
    }
}