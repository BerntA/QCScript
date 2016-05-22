//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Manage your project settings.
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
    public partial class ProjectSettingsWizardForm : BorderlessFormBase
    {
        public ProjectSettingsWizardForm()
        {
            InitializeComponent();

            textBoxGameinfoPath.Text = ProjectUtils.GetGameInfoPath();
            textBoxStudiomdlPath.Text = ProjectUtils.GetStudioModelPath();
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

        private void btnBrowseGameinfoPath_Click(object sender, EventArgs e)
        {
            textBoxGameinfoPath.Text = GetFolderPath("Navigate to the gameinfo.txt file related to your project.");
        }

        private void btnBrowseStudiomdlPath_Click(object sender, EventArgs e)
        {
            textBoxStudiomdlPath.Text = GetFolderPath("Navigate to any folder which contains studiomdl.exe.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProjectUtils.UpdateProjectSettings(textBoxGameinfoPath.Text, textBoxStudiomdlPath.Text);
            Close();
        }
    }
}
