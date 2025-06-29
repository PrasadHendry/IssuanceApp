// IssuanceApp.UI/ThemeManager.cs

using System.Drawing;
using System.Windows.Forms;

namespace DocumentIssuanceApp.Controls
{
    /// <summary>
    /// Centralizes UI styling, colors, and fonts for the entire application.
    /// </summary>
    public static class ThemeManager
    {
        #region Color Palette
        public static readonly Color SuccessColor = Color.FromArgb(28, 184, 65);
        public static readonly Color DangerColor = Color.FromArgb(220, 53, 69);
        public static readonly Color PrimaryColor = Color.FromArgb(0, 123, 255);
        public static readonly Color SecondaryColor = Color.FromArgb(108, 117, 125);
        public static readonly Color SuccessHoverColor = Color.FromArgb(33, 205, 74);
        public static readonly Color DangerHoverColor = Color.FromArgb(225, 66, 82);
        public static readonly Color PrimaryHoverColor = Color.FromArgb(10, 136, 255);
        public static readonly Color SecondaryHoverColor = Color.FromArgb(124, 132, 140);
        public static readonly Color HeaderTextColor = Color.White;
        public static readonly Color FormBackColor = Color.FromArgb(240, 242, 245);
        public static readonly Color GridSelectionBackColor = Color.FromArgb(188, 220, 244);
        public static readonly Color GridSelectionForeColor = Color.Black;
        public static readonly Color AppHeaderColor = Color.FromArgb(65, 84, 110);
        public static readonly Color GridAltRowColor = Color.FromArgb(248, 249, 250);
        #endregion

        #region Styling Methods
        public static void StyleButton(Button btn, Color backColor, Color hoverColor)
        {
            if (btn is RoundedButton roundedBtn)
            {
                roundedBtn.CornerRadius = 8;
            }
            btn.FlatStyle = FlatStyle.Popup;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = HeaderTextColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Padding = new Padding(5, 0, 5, 0);
        }

        public static void StyleSuccessButton(Button btn) { StyleButton(btn, SuccessColor, SuccessHoverColor); }
        public static void StyleDangerButton(Button btn) { StyleButton(btn, DangerColor, DangerHoverColor); }
        public static void StylePrimaryButton(Button btn) { StyleButton(btn, PrimaryColor, PrimaryHoverColor); }
        public static void StyleSecondaryButton(Button btn) { StyleButton(btn, SecondaryColor, SecondaryHoverColor); }

        public static void StyleDataGridView(DataGridView dgv)
        {
            // Enable double buffering for smoother scrolling
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = FormBackColor;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppHeaderColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = HeaderTextColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAltRowColor;
            dgv.AlternatingRowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dgv.RowsDefaultCellStyle.SelectionBackColor = GridSelectionBackColor;
            dgv.RowsDefaultCellStyle.SelectionForeColor = GridSelectionForeColor;
        }
        #endregion
    }
}