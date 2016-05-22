//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: We cleanup a specified directory + sub dirs, change all names to lowercase, fix bad slashes in vmt files, etc...
//
//==================================================================//

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
    public partial class DirectoryCleanupToolWizard : BorderlessFormBase
    {
        public DirectoryCleanupToolWizard()
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = GetFolderPath("Path to a directory which you want to cleanup");
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInput.Text))
                return;

            if (!Directory.Exists(textBoxInput.Text))
                return;

            string path = textBoxInput.Text;
            textLog.Text = string.Format("Cleaning up directory: {0}...", path) + Environment.NewLine;

            // Change folder names to lowercase.
            foreach (string dir in Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories))
            {
                string newDir = dir.ToLower();
                string tempDir = newDir + "_temp";
                textLog.Text += string.Format("Renamed directory {0} to {1}", dir, newDir) + Environment.NewLine;
                Directory.Move(dir, tempDir);
                Directory.Move(tempDir, newDir);
            }

            // Change all files to lowercase.
            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                string newFilePath = file.ToLower();
                File.Move(file, newFilePath);
                textLog.Text += string.Format("Renamed file {0} to {1}", file, newFilePath) + Environment.NewLine;
            }

            // Parse all .VMT files. Change texture paths to lowercase within the VMT's... + Fixup faulty brackets, \\ becomes / = Platform friendly.
            foreach (string file in Directory.EnumerateFiles(path, "*.vmt", SearchOption.AllDirectories))
            {
                if (CleanupVMTFile(file))
                    textLog.Text += string.Format("Cleaned file {0}", file) + Environment.NewLine;
            }

            textLog.Text += string.Format("Directory {0} has been successfully cleaned!", path) + Environment.NewLine;
        }

        private bool IsTexturePath(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("\\") || value.Contains("/"))
                    return true;

                string tempValue = value.ToLower();
                if (
                    tempValue.Contains("$basetexture") ||
                    tempValue.Contains("$envmap") ||
                    tempValue.Contains("$detail") ||
                    tempValue.Contains("$bumpmap") ||
                    tempValue.Contains("$normalmap") ||
                    tempValue.Contains("$reflecttexture") ||
                    tempValue.Contains("$refracttexture") ||
                    tempValue.Contains("$iris") ||
                    tempValue.Contains("$blendmodulatetexture") ||
                    tempValue.Contains("$phongexponenttexture") ||
                    tempValue.Contains("$ambientoccltexture") ||
                    tempValue.Contains("%tooltexture") ||
                    tempValue.Contains("$corneatexture")
                    )
                    return true;
            }

            return false;
        }

        private bool CleanupVMTFile(string file)
        {
            string fileContents = null;
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (IsTexturePath(line))
                    {
                        line = line.Replace(@"\", "/").ToLower();
                    }

                    fileContents += (line + Environment.NewLine);
                }
            }

            // Refresh/Update the file:
            if (!string.IsNullOrEmpty(fileContents))
            {
                File.WriteAllText(file, fileContents);
                return true;
            }

            return false;
        }
    }
}
