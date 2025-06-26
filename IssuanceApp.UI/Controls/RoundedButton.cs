// RoundedButton.cs

using System;
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
            // Set styles for custom painting to reduce flicker
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
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

        // Helper method to create a slightly darker color for the 'pressed' state
        private Color GetPressedColor(Color baseColor)
        {
            if (baseColor == Color.Transparent)
            {
                return baseColor;
            }
            // A simple but effective darkening effect
            int r = Math.Max(0, baseColor.R - 25);
            int g = Math.Max(0, baseColor.G - 25);
            int b = Math.Max(0, baseColor.B - 25);
            return Color.FromArgb(baseColor.A, r, g, b);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Do NOT call the base class OnPaint. We are handling all drawing ourselves.
            // base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the rectangle for the button
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int radius = cornerRadius * 2;

            // Prevent the radius from being too large for the button
            if (radius > this.Width) radius = this.Width;
            if (radius > this.Height) radius = this.Height;

            // Create the path for the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
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

                // --- 1. Determine Colors and State ---
                Color backColor;
                Color foreColor = this.ForeColor;
                bool isPressed = this.Capture && this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
                bool isHovered = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

                if (!this.Enabled)
                {
                    backColor = SystemColors.ControlDark;
                    foreColor = SystemColors.GrayText;
                }
                else if (isPressed)
                {
                    backColor = GetPressedColor(this.FlatAppearance.MouseOverBackColor);
                }
                else if (isHovered && this.FlatAppearance.MouseOverBackColor != Color.Transparent)
                {
                    backColor = this.FlatAppearance.MouseOverBackColor;
                }
                else
                {
                    backColor = this.BackColor;
                }

                // --- 2. Draw the button ---
                // Fill the background
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw the border
                if (this.FlatAppearance.BorderSize > 0)
                {
                    using (Pen pen = new Pen(this.FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                // --- 3. Draw Image and Text ---
                Rectangle contentRectangle = this.ClientRectangle;
                contentRectangle.X += this.Padding.Left;
                contentRectangle.Y += this.Padding.Top;
                contentRectangle.Width -= this.Padding.Horizontal;
                contentRectangle.Height -= this.Padding.Vertical;

                if (this.Image != null)
                {
                    // This is a simplified implementation for TextImageRelation.ImageBeforeText,
                    // which is the most common use case.
                    Point imagePoint = new Point(contentRectangle.Left, contentRectangle.Top + (contentRectangle.Height - this.Image.Height) / 2);
                    
                    // Draw image
                    if (this.Enabled)
                    {
                        g.DrawImage(this.Image, imagePoint);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(g, this.Image, imagePoint.X, imagePoint.Y, backColor);
                    }
                    
                    // Adjust text rectangle to be to the right of the image
                    int textLeftOffset = this.Image.Width + 8; // 8px gap
                    Rectangle textRectangle = new Rectangle(
                        contentRectangle.Left + textLeftOffset,
                        contentRectangle.Top,
                        contentRectangle.Width - textLeftOffset,
                        contentRectangle.Height
                    );

                    TextRenderer.DrawText(g, this.Text, this.Font, textRectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    // Draw the text in the center if no image is present
                    TextRenderer.DrawText(g, this.Text, this.Font, contentRectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }
}