//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: A simple custom image based button.
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QScript.Core;
using System.IO;

namespace QScript.Controls
{
    public partial class HoverButton : UserControl
    {
        [Description("Default Image"), Category("Appearance")]
        public string DefaultImage { get { return _image; } set { _image = value; Invalidate(); } }

        [Description("Hover Image"), Category("Appearance")]
        public string HoverImage { get { return _imageHovered; } set { _imageHovered = value; Invalidate(); } }

        private bool m_bIsMouseOver;
        private string _image;
        private string _imageHovered;

        public HoverButton()
        {
            InitializeComponent();
        }

        public HoverButton(string image, string image_hover)
        {
            InitializeComponent();

            _image = image;
            _imageHovered = image_hover;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            m_bIsMouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            m_bIsMouseOver = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            string imagePath = string.Format("{0}\\{1}", Globals.GetAppPath(), (m_bIsMouseOver ? _imageHovered : _image));
            if (File.Exists(imagePath))
                e.Graphics.DrawImage(Image.FromFile(imagePath), new Rectangle(0, 0, Width, Height));
        }
    }
}
