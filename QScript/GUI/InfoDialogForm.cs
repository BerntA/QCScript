//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: A new dialog form similar to MessageBox.Show...
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.GUI
{
    public partial class InfoDialogForm : BorderlessFormBase
    {
        public InfoDialogForm()
        {
            InitializeComponent();
        }

        public void SetMessage(string msg)
        {
            labelText.Text = msg;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }

    public static class InfoDialog
    {
        public static DialogResult ShowDialog(IWin32Window owner, string message, string header)
        {
            if (_infoDialog == null)
            {
                _infoDialog = new InfoDialogForm();
            }

            _infoDialog.Text = header;
            _infoDialog.SetMessage(message);

            bool bOwner = (owner != null);
            DialogResult result = bOwner ? _infoDialog.ShowDialog(owner) : _infoDialog.ShowDialog();

            _infoDialog = null;
            return result;
        }

        private static InfoDialogForm _infoDialog = null;
    }
}
