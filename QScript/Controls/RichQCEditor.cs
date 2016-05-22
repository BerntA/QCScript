//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Custom Rich Text Editor.
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

namespace QScript.Controls
{
    public partial class RichQCEditor : RichTextBox
    {
        public int GetLastSelectionStart() { return _lastSelectionIndex; }
        int _lastSelectionIndex = 0;
        string _lastKeyDown = null;
        CommandList _cmdList = null;
        public RichQCEditor()
        {
            InitializeComponent();

            _cmdList = new CommandList(this);
            _cmdList.Parent = this;
            _cmdList.Visible = false;

            SizeChanged += new EventHandler(OnSizeChanged);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((_lastKeyDown == "ControlKey") && e.KeyCode.ToString() == "OemPeriod")
            {
                if (!_cmdList.Visible)
                {
                    SetupCommandListPosAndSize();
                    _cmdList.ShowCommandList();
                    _cmdList.Focus();
                }
            }

            _lastKeyDown = e.KeyCode.ToString();
            base.OnKeyDown(e);
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (_cmdList.Visible)
            {
                SetupCommandListPosAndSize();
                _cmdList.Focus();
            }
        }

        private void SetupCommandListPosAndSize()
        {
            _lastSelectionIndex = this.SelectionStart;
            Point pos = GetPositionFromCharIndex(_lastSelectionIndex);
            pos.X = 0;

            int height = _cmdList.Height;
            int width = (Width - 22);

            if ((pos.Y + height) > Height)
                pos.Y = Height - height;

            _cmdList.Location = pos;

            _cmdList.Size = new Size(width, height); 
        }
    }
}
