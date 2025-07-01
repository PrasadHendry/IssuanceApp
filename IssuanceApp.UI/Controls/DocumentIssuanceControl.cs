// DocumentIssuanceControl.cs

using IssuanceApp.Data;
using IssuanceApp.UI; // For ThemeManager
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuanceApp.UI.Controls
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

        public async Task LoadInitialDataAsync()
        {
            if (_repository == null) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                txtRequestNoValueDI.Text = await _repository.GenerateNewRequestNumberAsync();
                ClearDocumentIssuanceForm();
                lblStatusValueDI.Text = "Ready to create a new request.";
                lblStatusValueDI.ForeColor = System.Drawing.SystemColors.ControlText;
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

        #region UI and Helper Methods
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

        private string GetDateStringFromComboBoxes(ComboBox monthComboBox, ComboBox yearComboBox)
        {
            string month = monthComboBox?.SelectedItem?.ToString();
            string year = yearComboBox?.SelectedItem?.ToString();
            return (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(year) || month == "N/A" || year == "N/A") ? null : $"{month}/{year}";
        }

        private void ClearDocumentIssuanceForm()
        {
            Action<Control.ControlCollection> clearControls = null;
            clearControls = (controls) =>
            {
                foreach (Control c in controls)
                {
                    if (c is TextBox) ((TextBox)c).Clear();
                    else if (c is CheckBox) ((CheckBox)c).Checked = false;
                    else if (c is ComboBox)
                    {
                        var cmb = (ComboBox)c;
                        if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
                    }
                    else if (c.HasChildren) clearControls(c.Controls);
                }
            };
            clearControls(this.Controls);
            dtpRequestDateDI.Value = DateTime.Now;
        }
        #endregion

        #region Validation
        private bool IsFormValid(out string errorMessage, out Control controlToFocus)
        {
            errorMessage = string.Empty;
            controlToFocus = null;

            if (cmbFromDepartmentDI.SelectedItem == null || string.IsNullOrWhiteSpace(cmbFromDepartmentDI.SelectedItem.ToString()))
            {
                errorMessage = "Please select a 'From Department'.";
                controlToFocus = cmbFromDepartmentDI;
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductDI.Text))
            {
                errorMessage = "Please enter the 'Product'.";
                controlToFocus = txtProductDI;
                return false;
            }

            var docNumbersList = new List<string>();
            if (chkDocTypeBMRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBmrDocNoDI.Text)) { errorMessage = "BMR is checked, please enter BMR Document No."; controlToFocus = txtBmrDocNoDI; return false; } docNumbersList.Add(txtBmrDocNoDI.Text.Trim()); }
            if (chkDocTypeBPRDI.Checked) { if (string.IsNullOrWhiteSpace(txtBprDocNoDI.Text)) { errorMessage = "BPR is checked, please enter BPR Document No."; controlToFocus = txtBprDocNoDI; return false; } docNumbersList.Add(txtBprDocNoDI.Text.Trim()); }
            if (chkDocTypeAppendixDI.Checked) { if (string.IsNullOrWhiteSpace(txtAppendixDocNoDI.Text)) { errorMessage = "Appendix is checked, please enter Appendix Document No."; controlToFocus = txtAppendixDocNoDI; return false; } docNumbersList.Add(txtAppendixDocNoDI.Text.Trim()); }
            if (chkDocTypeAddendumDI.Checked) { if (string.IsNullOrWhiteSpace(txtAddendumDocNoDI.Text)) { errorMessage = "Addendum is checked, please enter Addendum Document No."; controlToFocus = txtAddendumDocNoDI; return false; } docNumbersList.Add(txtAddendumDocNoDI.Text.Trim()); }
            if (!docNumbersList.Any()) { errorMessage = "Please select at least one 'Document Type' and provide its number."; controlToFocus = grpDocTypeDI; return false; }

            if (!string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI.Text))
            {
                if (!decimal.TryParse(txtParentBatchSizeValueDI.Text, out _)) { errorMessage = "Parent Batch Size must be a valid number."; controlToFocus = txtParentBatchSizeValueDI; return false; }
                if (cmbParentBatchSizeUnitDI.SelectedItem == null || cmbParentBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { errorMessage = "Please select a Unit for the Parent Batch Size."; controlToFocus = cmbParentBatchSizeUnitDI; return false; }
            }

            if (string.IsNullOrWhiteSpace(txtItemBatchSizeValueDI.Text)) { errorMessage = "Item Batch Size value is required."; controlToFocus = txtItemBatchSizeValueDI; return false; }
            if (!decimal.TryParse(txtItemBatchSizeValueDI.Text, out _)) { errorMessage = "Item Batch Size must be a valid number."; controlToFocus = txtItemBatchSizeValueDI; return false; }
            if (cmbItemBatchSizeUnitDI.SelectedItem == null || cmbItemBatchSizeUnitDI.SelectedItem.ToString() == "N/A") { errorMessage = "Please select a Unit for the Item Batch Size."; controlToFocus = cmbItemBatchSizeUnitDI; return false; }

            return true;
        }
        #endregion

        #region Event Handlers
        private async void BtnSubmitRequestDI_Click(object sender, EventArgs e)
        {
            if (!IsFormValid(out string errorMessage, out Control controlToFocus))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                controlToFocus?.Focus();
                return;
            }

            string parentBatchSizeStr = !string.IsNullOrWhiteSpace(txtParentBatchSizeValueDI.Text)
                ? $"{txtParentBatchSizeValueDI.Text.Trim()} {cmbParentBatchSizeUnitDI.SelectedItem}"
                : null;

            var docNumbers = new List<string>();
            if (chkDocTypeBMRDI.Checked) docNumbers.Add(txtBmrDocNoDI.Text.Trim());
            if (chkDocTypeBPRDI.Checked) docNumbers.Add(txtBprDocNoDI.Text.Trim());
            if (chkDocTypeAppendixDI.Checked) docNumbers.Add(txtAppendixDocNoDI.Text.Trim());
            if (chkDocTypeAddendumDI.Checked) docNumbers.Add(txtAddendumDocNoDI.Text.Trim());

            var issuanceData = new IssuanceRequestData
            {
                RequestNo = txtRequestNoValueDI.Text,
                RequestDate = dtpRequestDateDI.Value.Date,
                FromDepartment = cmbFromDepartmentDI.SelectedItem.ToString(),
                DocumentNo = string.Join(",", docNumbers),
                Product = txtProductDI.Text.Trim(),
                BatchNo = string.IsNullOrWhiteSpace(txtBatchNoDI.Text) ? null : txtBatchNoDI.Text.Trim(),
                BatchSize = $"{txtItemBatchSizeValueDI.Text.Trim()} {cmbItemBatchSizeUnitDI.SelectedItem}",
                PreparedBy = _loggedInUserName,
                ParentBatchNumber = string.IsNullOrWhiteSpace(txtParentBatchNoDI.Text) ? null : txtParentBatchNoDI.Text.Trim(),
                ParentBatchSize = parentBatchSizeStr,
                ParentMfgDate = GetDateStringFromComboBoxes(cmbParentMfgMonthDI, cmbParentMfgYearDI),
                ParentExpDate = GetDateStringFromComboBoxes(cmbParentExpMonthDI, cmbParentExpYearDI),
                ItemMfgDate = GetDateStringFromComboBoxes(cmbItemMfgMonthDI, cmbItemMfgYearDI),
                ItemExpDate = GetDateStringFromComboBoxes(cmbItemExpMonthDI, cmbItemExpYearDI),
                Market = string.IsNullOrWhiteSpace(txtMarketDI.Text) ? null : txtMarketDI.Text.Trim(),
                PackSize = string.IsNullOrWhiteSpace(txtPackSizeDI.Text) ? null : txtPackSizeDI.Text.Trim(),
                ExportOrderNo = string.IsNullOrWhiteSpace(txtExportOrderNoDI.Text) ? null : txtExportOrderNoDI.Text.Trim(),
                RequestComment = txtRemarksDI.Text.Trim(),
            };

            btnSubmitRequestDI.Enabled = false;
            btnClearFormDI.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            lblStatusValueDI.Text = "Submitting request...";
            lblStatusValueDI.ForeColor = System.Drawing.SystemColors.ControlText;

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
        }
        #endregion
    }
}