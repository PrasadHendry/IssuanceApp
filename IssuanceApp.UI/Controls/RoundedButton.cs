// RoundedButton.cs

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IssuanceApp.UI
{
    public class RoundedButton : Button
    {
        private int cornerRadius = 10;
        private bool isHovered = false;
        private bool isPressed = false;

        public RoundedButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
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
                this.Invalidate();
            }
        }

        private Color GetPressedColor(Color baseColor)
        {
            if (baseColor == Color.Transparent) return baseColor;
            int r = Math.Max(0, baseColor.R - 25);
            int g = Math.Max(0, baseColor.G - 25);
            int b = Math.Max(0, baseColor.B - 25);
            return Color.FromArgb(baseColor.A, r, g, b);
        }

        // Using event-driven state management for better performance
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Do not call base.OnPaintBackground(e) as we are doing all the painting.
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int radius = cornerRadius * 2;
            if (radius > this.Width) radius = this.Width;
            if (radius > this.Height) radius = this.Height;

            using (GraphicsPath path = new GraphicsPath())
            {
                if (radius > 0)
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                }
                else
                {
                    path.AddRectangle(rect);
                }
                path.CloseFigure();
                this.Region = new Region(path);

                Color backColor;
                Color foreColor = this.ForeColor;

                if (!this.Enabled)
                {
                    backColor = Color.FromArgb(150, this.BackColor);
                    foreColor = Color.FromArgb(180, this.ForeColor);
                }
                else if (isPressed)
                {
                    backColor = GetPressedColor(this.FlatAppearance.MouseDownBackColor != Color.Empty && this.FlatAppearance.MouseDownBackColor != Color.Transparent ? this.FlatAppearance.MouseDownBackColor : this.BackColor);
                }
                else if (isHovered && this.FlatAppearance.MouseOverBackColor != Color.Empty && this.FlatAppearance.MouseOverBackColor != Color.Transparent)
                {
                    backColor = this.FlatAppearance.MouseOverBackColor;
                }
                else
                {
                    backColor = this.BackColor;
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillPath(brush, path);
                }
                if (this.FlatAppearance.BorderSize > 0)
                {
                    using (Pen pen = new Pen(this.FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                Rectangle contentRectangle = this.ClientRectangle;
                contentRectangle.Inflate(-this.Padding.Horizontal, -this.Padding.Vertical);

                if (this.Image != null)
                {
                    Point imagePoint = new Point(contentRectangle.Left, contentRectangle.Top + (contentRectangle.Height - this.Image.Height) / 2);
                    if (this.Enabled)
                    {
                        g.DrawImage(this.Image, imagePoint);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(g, this.Image, imagePoint.X, imagePoint.Y, backColor);
                    }
                    int textLeftOffset = this.Image.Width + 8;
                    Rectangle textRectangle = new Rectangle(
                        contentRectangle.Left + textLeftOffset,
                        contentRectangle.Top,
                        contentRectangle.Width - textLeftOffset,
                        contentRectangle.Height);
                    TextRenderer.DrawText(g, this.Text, this.Font, textRectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    TextRenderer.DrawText(g, this.Text, this.Font, contentRectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }
}