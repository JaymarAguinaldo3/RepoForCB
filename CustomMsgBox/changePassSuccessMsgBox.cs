using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authenti_Gate.CustomMsgBox
{
    public partial class changePassSuccessMsgBox : Form
    {
        private int _cornerRadius = 40;
        private Color _borderColor = Color.Green;
        private int _borderThickness = 1;
        public changePassSuccessMsgBox()
        {
            InitializeComponent();

            ApplyRoundedCorners(_cornerRadius);

            this.Paint += LogoutMsgBox_Paint;

            btnYes.DialogResult = DialogResult.Yes;
            btnYes.Click += (sender, e) => this.Close();
        }
        private void LogoutMsgBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the border
            using (GraphicsPath path = new GraphicsPath())
            {
                // Border rectangle path with rounded corners
                path.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90);
                path.AddArc(this.Width - _cornerRadius - _borderThickness, 0, _cornerRadius, _cornerRadius, 270, 90);
                path.AddArc(this.Width - _cornerRadius - _borderThickness, this.Height - _cornerRadius - _borderThickness, _cornerRadius, _cornerRadius, 0, 90);
                path.AddArc(0, this.Height - _cornerRadius - _borderThickness, _cornerRadius, _cornerRadius, 90, 90);
                path.CloseFigure();

                // Draw border with specified color and thickness
                using (Pen pen = new Pen(_borderColor, _borderThickness))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void ApplyRoundedCorners(int radius)
        {
            // Define a path with rounded corners
            var path = new GraphicsPath();
            path.StartFigure();

            // Top-left corner
            path.AddArc(0, 0, radius, radius, 180, 90);

            // Top-right corner
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);

            // Bottom-right corner
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);

            // Bottom-left corner
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            // Set the region of the form to apply the rounded path
            this.Region = new Region(path);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners(_cornerRadius); // Reapply rounded corners on resize
            this.Invalidate();
        }
    }
}
