//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Borderless From Base Class.
//
//==================================================================//

using QScript.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace QScript.GUI
{
    public partial class BorderlessFormBase : Form
    {
        public BorderlessFormBase()
        {
            InitializeComponent();

            // Setup the controls
            closeButton.Location = new Point(Width - closeButton.Size.Width, -6);
            minimizeButton.Location = new Point(Width - (minimizeButton.Size.Width * 2), -6);
        }

        public void AddFrameButtonOffset(int xoffset, int yoffset)
        {
            closeButton.Location = new Point(Width - closeButton.Size.Width + xoffset, -6 + yoffset);
            minimizeButton.Location = new Point(Width - (minimizeButton.Size.Width * 2) + xoffset, -6 + yoffset);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        private Controls.HoverButton closeButton;
        private Controls.HoverButton minimizeButton;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return;
            }

            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 155, 160, 140));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, (int)(e.Graphics.MeasureString(this.Text, this.Font).Height * 1.35)));

            // Draw the actual name of this window:
            SolidBrush drawBrush = new SolidBrush(Color.White);
            e.Graphics.DrawString(this.Text, this.Font, drawBrush, new PointF(2, 3));
        }

        private void InitializeComponent()
        {
            this.minimizeButton = new QScript.Controls.HoverButton();
            this.closeButton = new QScript.Controls.HoverButton();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.DefaultImage = "textures\\\\controls\\\\MinimizeDefault.png";
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.HoverImage = "textures\\\\controls\\\\MinimizeHover.png";
            this.minimizeButton.Location = new System.Drawing.Point(433, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(30, 30);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.DefaultImage = "textures\\\\controls\\\\CloseDefault.png";
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.HoverImage = "textures\\\\controls\\\\CloseHover.png";
            this.closeButton.Location = new System.Drawing.Point(469, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 0;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // BorderlessFormBase
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.ControlBox = false;
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorderlessFormBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SharedEvents.CloseForm(this);
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
