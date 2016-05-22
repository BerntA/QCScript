//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Application Info.
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.GUI
{
    public partial class AboutInfoForm : BorderlessFormBase
    {
        public AboutInfoForm()
        {
            InitializeComponent();

            label2.Text = string.Format("Version: {0}", Application.ProductVersion);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/tfobernt");
        }
    }
}
