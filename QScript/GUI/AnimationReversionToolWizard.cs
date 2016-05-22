//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Allows the user to reverse the animation of some input .smd file.
//
//==================================================================//

using QScript.Core;
using QScript.Filesystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.GUI
{
    public partial class AnimationReversionToolWizard : BorderlessFormBase
    {
        public AnimationReversionToolWizard()
        {
            InitializeComponent();
        }

        private string GetFilePath(string desc, bool bNew = false)
        {
            string path = null;

            if (bNew)
            {
                using (SaveFileDialog fileDialog = new SaveFileDialog())
                {
                    fileDialog.OverwritePrompt = true;
                    fileDialog.AddExtension = true;
                    fileDialog.CheckFileExists = false;
                    fileDialog.CheckPathExists = false;
                    fileDialog.Filter = "SMD file (*.smd) | *.smd";
                    fileDialog.FilterIndex = 1;
                    fileDialog.ValidateNames = true;
                    fileDialog.InitialDirectory = ProjectUtils.GetProjectDirectory();
                    fileDialog.Title = desc;
                    var dialog = fileDialog.ShowDialog(this);
                    if (dialog == System.Windows.Forms.DialogResult.OK)
                        path = fileDialog.FileName;
                }
            }
            else
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.AddExtension = true;
                    fileDialog.CheckFileExists = true;
                    fileDialog.CheckPathExists = true;
                    fileDialog.Filter = "SMD file (*.smd) | *.smd";
                    fileDialog.FilterIndex = 1;
                    fileDialog.ValidateNames = true;
                    fileDialog.InitialDirectory = ProjectUtils.GetProjectDirectory();
                    fileDialog.Title = desc;
                    var dialog = fileDialog.ShowDialog(this);
                    if (dialog == System.Windows.Forms.DialogResult.OK)
                        path = fileDialog.FileName;
                }
            }

            return path;
        }

        private void btnBrowseIn_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = GetFilePath("SMD to reverse");
        }

        private void btnBrowseOut_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = GetFilePath("Output SMD", true);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            string inputFile = textBoxInput.Text;
            string outputFile = textBoxOutput.Text;

            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile))
                return;

            if (!File.Exists(inputFile))
                return;

            SMDParser smdFile = new SMDParser(inputFile);
            if (smdFile.ParseSMDFile())
            {
                smdFile.ReverseAnimation(outputFile);
                InfoDialog.ShowDialog(this, string.Format("Successfully reversed the animation!\nPath: {0}", outputFile), "Success!");
                Close();
            }
        }
    }
}
