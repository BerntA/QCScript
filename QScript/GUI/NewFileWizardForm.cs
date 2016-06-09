//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Add a file to some filter in the project hierarchy.
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
    public partial class NewFileWizardForm : BorderlessFormBase
    {
        private TreeNode _node;
        private Filter _filter;
        private ContextMenuStrip _fileStrip;
        public NewFileWizardForm(TreeNode parentNode, Filter filter, ContextMenuStrip fileStrip)
        {
            InitializeComponent();

            _node = parentNode;
            _filter = filter;
            _fileStrip = fileStrip;
        }

        private string GetFilePath(string desc)
        {
            string path = null;

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.AddExtension = true;
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "QC files (*.qc, *.qci) | *.qc; *.qci";
                fileDialog.FilterIndex = 1;
                fileDialog.ValidateNames = true;
                fileDialog.InitialDirectory = Globals.GetImportPath();
                fileDialog.Title = desc;
                var dialog = fileDialog.ShowDialog(this);
                if (dialog == System.Windows.Forms.DialogResult.OK)
                    path = fileDialog.FileName;
            }

            return path;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string fileName = textBoxName.Text;
            string path = fileName;
            if (File.Exists(fileName))
            {
                path = string.Format("{0}\\{1}", _filter.GetFilterDirectory(), Path.GetFileName(fileName));
                QCParser importedQC = new QCParser(fileName);
                if (!importedQC.ImportDependenciesToPath(string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), Path.GetDirectoryName(path))))
                {
                    try
                    {
                        File.Copy(fileName, string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), path), true);
                    }
                    catch
                    {
                        LoggingUtils.LogEvent("Failed to import a file!");
                    }
                }
            }
            else
            {
                if (!Globals.IsStringValid(fileName))
                    return;

                path = string.Format("{0}\\{1}", _filter.GetFilterDirectory(), fileName);
            }

            if (!fileName.EndsWith(".qc", StringComparison.InvariantCultureIgnoreCase) && !fileName.EndsWith(".qci", StringComparison.InvariantCultureIgnoreCase))
            {
                InfoDialog.ShowDialog(this, "Invalid file extension!", "Error!");
                return;
            }

            string hasFile = ProjectUtils.GetFilePathForTreeNodeItem(_filter.GetName(), Path.GetFileName(path));
            if (!string.IsNullOrEmpty(hasFile))
            {
                InfoDialog.ShowDialog(this, "This file already exists in the choosen filter!", "Error!");
                return;
            }

            string fullPath = string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), path);
            if (!File.Exists(fullPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.WriteAllText(fullPath, "");
            }

            _filter.AddFile("local", path);

            TreeNode newNode = new TreeNode(Path.GetFileName(path));
            newNode.ContextMenuStrip = _fileStrip;
            newNode.ImageIndex = newNode.SelectedImageIndex = newNode.StateImageIndex = 0;
            _node.Nodes.Add(newNode);
            _node.ExpandAll();

            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string path = textBoxName.Text = GetFilePath("Import QC or QCI file");
            if (!string.IsNullOrEmpty(path))
            {
                Properties.Settings.Default.lastImportPath = path;
                Properties.Settings.Default.Save();
            }
        }
    }
}
