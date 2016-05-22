//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Project Creation Wizard Form.
//
//==================================================================//

using QScript.Core;
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
    public partial class ProjectWizardForm : BorderlessFormBase
    {
        public ProjectWizardForm()
        {
            InitializeComponent();
        }

        private string GetFolderPath(string desc)
        {
            string path = null;
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.ShowNewFolderButton = true;
                folderDialog.Description = desc;
                var dialog = folderDialog.ShowDialog(this);
                if (dialog == System.Windows.Forms.DialogResult.OK)
                    path = folderDialog.SelectedPath;
            }

            return path;
        }

        private void btnCreateProj_Click(object sender, EventArgs e)
        {
            if (ProjectUtils.CreateProject(textBoxProjectName.Text, textBoxProjectPath.Text, textBoxGameinfoPath.Text, textBoxStudiomdlPath.Text))
                Close();
        }

        private void buttonProjectPath_Click(object sender, EventArgs e)
        {
            textBoxProjectPath.Text = GetFolderPath("Navigate to the desired path of your new project!");
        }

        private void buttonGameinfoPath_Click(object sender, EventArgs e)
        {
            textBoxGameinfoPath.Text = GetFolderPath("Navigate to the gameinfo.txt file related to your project.");
        }

        private void buttonStudiomdlPath_Click(object sender, EventArgs e)
        {
            textBoxStudiomdlPath.Text = GetFolderPath("Navigate to any folder which contains studiomdl.exe.");
        }
    }
}
