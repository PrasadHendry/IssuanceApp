// RoundedButton.cs

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DocumentIssuanceApp
{
    // --- CUSTOM ROUNDED BUTTON CONTROL ---
    public class RoundedButton : Button
    {
        private int cornerRadius = 10; // Default radius

        public RoundedButton()
        {
            // Ensure crisp rendering and reduce flicker
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
        }

        [Category("Appearance")]
        [Description("The radius of the button's corners.")]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                this.Invalidate(); // Redraw the button when the radius changes
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Let the base class do its thing first

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Make the corners smooth

            // Define the rectangle for the button
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int radius = cornerRadius * 2;

            // Prevent the radius from being too large for the button
            if (radius > this.Width) radius = this.Width;
            if (radius > this.Height) radius = this.Height;

            // Create the path for the rounded rectangle
            GraphicsPath path = new GraphicsPath();
            if (radius > 0)
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left
            }
            else
            {
                path.AddRectangle(rect); // If radius is 0, just a normal rectangle
            }
            path.CloseFigure();

            // Set the button's visible region to the rounded shape
            this.Region = new Region(path);

            // --- Draw the button ---
            // Determine the background color (handle hover effect)
            Color backColor = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)) ?
                              this.FlatAppearance.MouseOverBackColor : this.BackColor;

            // Fill the background
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillPath(brush, path);
            }

            // Draw the border
            using (Pen pen = new Pen(this.FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
            {
                g.DrawPath(pen, path);
            }

            // Draw the text in the center
            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}