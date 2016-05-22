//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: A simple button which animates between two colors when hovered.
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

namespace QScript.Controls
{
    public partial class PixelAnimatedButton : UserControl
    {
        [Description("Text"), Category("Appearance")]
        public string Txt { get { return _text; } set { _text = value; Invalidate(); } }

        private Color animatedColor;
        private string _text;
        private bool m_bHovered;
        private int m_iFraction;
        public PixelAnimatedButton()
        {
            InitializeComponent();

            m_bHovered = false;
            animatedColor = this.ForeColor;
            m_iFraction = 4;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            m_bHovered = timAnim.Enabled = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            m_bHovered = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush drawBrush = new SolidBrush(animatedColor);
            e.Graphics.DrawString(_text, this.Font, drawBrush, new Rectangle(0, 0, Width, Height));
        }

        private void timAnim_Tick(object sender, EventArgs e)
        {
            Color color = animatedColor;

            if (m_bHovered)
            {
                animatedColor = color = Color.FromArgb(color.R, Globals.MAX(color.G - m_iFraction, 0, 255), Globals.MAX(color.B - m_iFraction, 0, 255));
                Invalidate();
                return;
            }
            else if (color.B < 255)
            {
                animatedColor = color = Color.FromArgb(color.R, Globals.MAX(color.G + m_iFraction, 0, 255), Globals.MAX(color.B + m_iFraction, 0, 255));
                Invalidate();
                return;
            }

            timAnim.Enabled = false;
        }
    }
}
