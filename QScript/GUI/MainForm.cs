//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Main Master Form.
//
//==================================================================//

using QScript.Core;
using QScript.Filesystem;
using QScript.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript
{
    public partial class MainForm : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ContextMenuStrip filterMenuStrip;
        private ContextMenuStrip fileMenuStrip;
        public MainForm()
        {
            InitializeComponent();

            WindowHandler.contextWindowMenu = editorMenu;
            Globals.compileArguments = textCommandLineParams;

            string fileDialogPath = Properties.Settings.Default.lastProjectPath;
            if (string.IsNullOrEmpty(fileDialogPath))
                fileDialogPath = @"C:\\";

            // Dynamic File Open Dialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.InitialDirectory = fileDialogPath;
            openFileDialog.DefaultExt = "*.qcs";
            openFileDialog.Filter = "QScript Project|*.qcs";
            openFileDialog.Title = "Select a project file";

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.InitialDirectory = fileDialogPath;
            saveFileDialog.DefaultExt = "*.qcs";
            saveFileDialog.Filter = "QScript Project|*.qcs";
            saveFileDialog.Title = "Create a project file";

            SharedEvents.OnCreatedProject += new SharedEvents.DefaultEvent(OnOpenProject);
            SharedEvents.OnOpenedProject += new SharedEvents.DefaultEvent(OnOpenProject);
            SharedEvents.OnClosedProject += new SharedEvents.DefaultEvent(OnClosedProject);

            SharedEvents.OnCompileStart += new SharedEvents.DefaultEvent(OnCompileStart);
            SharedEvents.OnCompileStop += new SharedEvents.DefaultEvent(OnCompileStop);
            SharedEvents.OnCompileComplete += new SharedEvents.DefaultEvent(OnCompileCompleted);

            filterMenuStrip = new ContextMenuStrip();

            ToolStripItem item = null;
            item = filterMenuStrip.Items.Add("Add File");
            item.Image = Properties.Resources.icon_addfile;
            item.Click += new EventHandler(MenuStripFilterOnAddFile);

            item = filterMenuStrip.Items.Add("Add Filter");
            item.Image = Properties.Resources.icon_newproject;
            item.Click += new EventHandler(MenuStripFilterOnAddFilter);

            item = filterMenuStrip.Items.Add("Build");
            item.Image = Properties.Resources.icon_compile;
            item.Click += new EventHandler(MenuStripFilterOnBuild);

            item = filterMenuStrip.Items.Add("Remove");
            item.Image = Properties.Resources.icon_removefolder;
            item.Click += new EventHandler(MenuStripFilterOnRemove);

            item = filterMenuStrip.Items.Add("Delete");
            item.Image = Properties.Resources.icon_removefolder;
            item.Click += new EventHandler(MenuStripFilterOnDelete);

            fileMenuStrip = new ContextMenuStrip();

            item = fileMenuStrip.Items.Add("Build");
            item.Image = Properties.Resources.icon_compile;
            item.Click += new EventHandler(MenuStripFileOnBuild);

            item = fileMenuStrip.Items.Add("Open");
            item.Image = Properties.Resources.icon_openproject;
            item.Click += new EventHandler(MenuStripFileOnOpen);

            item = fileMenuStrip.Items.Add("Open in HLMV");
            item.Image = Properties.Resources.icon_gen;
            item.Click += new EventHandler(MenuStripFileOnOpenHLMV);

            item = fileMenuStrip.Items.Add("Save");
            item.Image = Properties.Resources.icon_save;
            item.Click += new EventHandler(MenuStripFileOnSave);

            item = fileMenuStrip.Items.Add("Close");
            item.Image = Properties.Resources.icon_closefile;
            item.Click += new EventHandler(MenuStripFileOnClose);

            item = fileMenuStrip.Items.Add("Remove");
            item.Image = Properties.Resources.icon_filedel;
            item.Click += new EventHandler(MenuStripFileOnRemove);

            item = fileMenuStrip.Items.Add("Delete");
            item.Image = Properties.Resources.icon_filedel;
            item.Click += new EventHandler(MenuStripFileOnDelete);

            string projectFileArg = CommandLineUtils.GetProjectInputPath();
            if (!string.IsNullOrEmpty(projectFileArg))
                ProjectUtils.OpenProject(projectFileArg);
        }

        private void MenuStripFilterOnAddFile(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(filterMenuStrip.Bounds.Location));
            if (node == null)
                return;

            Filter filter = ProjectUtils.GetFilter(node.Text);
            if (filter == null)
                return;

            NewFileWizardForm fileForm = new NewFileWizardForm(node, filter, fileMenuStrip);
            fileForm.ShowDialog(this);
        }

        private void MenuStripFilterOnAddFilter(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(filterMenuStrip.Bounds.Location));
            if (node == null)
                return;

            Filter filter = ProjectUtils.GetFilter(node.Text);
            if (filter == null)
                return;

            NewFilterWizardForm filterForm = new NewFilterWizardForm(node, filter, filterMenuStrip);
            filterForm.ShowDialog(this);
        }

        private void MenuStripFilterOnBuild(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(filterMenuStrip.Bounds.Location));
            if (node == null)
                return;

            ProjectUtils.BuildFilter(node.Text);
        }

        private void MenuStripFilterOnRemove(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(filterMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Text == ProjectUtils.GetProjectName())
            {
                ProjectUtils.RemoveProject(false);
                ProjectUtils.RefreshTreeView(projectTreeView, filterMenuStrip, fileMenuStrip);
                ProjectUtils.SaveProject();
                return;
            }

            ProjectUtils.RemoveFilter(node.Text, false);
            ProjectUtils.SaveProject();

            TreeNode parentNode = node.Parent;
            if (parentNode == null)
                return;

            parentNode.Nodes.Remove(node);
        }

        private void MenuStripFilterOnDelete(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(filterMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Text == ProjectUtils.GetProjectName())
            {
                ProjectUtils.RemoveProject(true);
                projectTreeView.Nodes.Clear();
                return;
            }

            ProjectUtils.RemoveFilter(node.Text, true);
            ProjectUtils.SaveProject();

            TreeNode parentNode = node.Parent;
            if (parentNode == null)
                return;

            parentNode.Nodes.Remove(node);
        }

        private void MenuStripFileOnBuild(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Parent == null || (node.Nodes.Count > 0))
                return;

            string path = ProjectUtils.GetFilePathForTreeNodeItem(node.Parent.Text, node.Text);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                CompilerUtils.AddToQueue(path);
        }

        private void MenuStripFileOnOpen(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Parent == null || (node.Nodes.Count > 0))
                return;

            string path = ProjectUtils.GetFilePathForTreeNodeItem(node.Parent.Text, node.Text);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                WindowHandler.RegisterWindow(node.Text, node.Parent.Text);
        }

        private void MenuStripFileOnOpenHLMV(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Parent == null || (node.Nodes.Count > 0))
                return;

            string path = ProjectUtils.GetFilePathForTreeNodeItem(node.Parent.Text, node.Text);
            Globals.OpenModelInHLMV(path);
        }

        private void MenuStripFileOnSave(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Parent == null || (node.Nodes.Count > 0))
                return;

            WindowHandler.SaveFile(node.Text, node.Parent.Text);
        }

        private void MenuStripFileOnClose(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            if (node.Parent == null || (node.Nodes.Count > 0))
                return;

            WindowHandler.DeregisterWindow(node.Text, node.Parent.Text);
        }

        private void MenuStripFileOnRemove(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            RemoveFile(node, false);
        }

        private void MenuStripFileOnDelete(object sender, EventArgs e)
        {
            TreeNode node = projectTreeView.GetNodeAt(projectTreeView.PointToClient(fileMenuStrip.Bounds.Location));
            if (node == null)
                return;

            RemoveFile(node, true);
        }

        private void RemoveFile(TreeNode node, bool bDelete = false)
        {
            if (node == null)
                return;

            TreeNode parent = node.Parent;
            if (parent == null || (node.Nodes.Count > 0))
                return;

            string path = ProjectUtils.GetFilePathForTreeNodeItem(node.Parent.Text, node.Text);
            if (ProjectUtils.RemoveFile(node.Text, node.Parent.Text))
            {
                WindowHandler.DeregisterWindow(node.Text, node.Parent.Text);
                parent.Nodes.Remove(node);

                if (bDelete && File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {
                        LoggingUtils.LogEvent(string.Format("Unable to delete file {0}!", path));
                    }
                }
            }
        }

        private void OnCompileCompleted()
        {
            statusBanner.Items.Clear();
        }

        private void OnCompileStop()
        {
            statusBanner.Items.Clear();
        }

        private void OnCompileStart()
        {
            ToolStripItem item = statusBanner.Items.Add("Compiling...");
            item.Image = Properties.Resources.compiling;
            item.ImageAlign = ContentAlignment.MiddleLeft;
            item.TextAlign = ContentAlignment.MiddleCenter;
            item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            item.BackColor = Color.Transparent;
        }

        private void OnClosedProject()
        {
            projectTreeView.Nodes.Clear();
        }

        private void OnOpenProject()
        {
            ProjectUtils.RefreshTreeView(projectTreeView, filterMenuStrip, fileMenuStrip);
        }

        private void menuWindowCloseAll_Click(object sender, EventArgs e)
        {
            WindowHandler.CloseAllWindows();
        }

        private void menuProjectNew_Click(object sender, EventArgs e)
        {
            ProjectWizardForm projectCreator = new ProjectWizardForm();
            projectCreator.ShowDialog(this);
        }

        private void menuProjectOpen_Click(object sender, EventArgs e)
        {
            var file_dialog = openFileDialog.ShowDialog();
            if (file_dialog == DialogResult.OK)
                ProjectUtils.OpenProject(openFileDialog.FileName);
        }

        private void menuProjectClose_Click(object sender, EventArgs e)
        {
            ProjectUtils.CloseProject();
        }

        private void projectTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = projectTreeView.SelectedNode;
            if ((selectedNode == null))
                return;

            if (selectedNode.Parent == null || (selectedNode.Nodes.Count > 0))
                return;

            string path = ProjectUtils.GetFilePathForTreeNodeItem(projectTreeView.SelectedNode.Parent.Text, projectTreeView.SelectedNode.Text);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                WindowHandler.RegisterWindow(projectTreeView.SelectedNode.Text, projectTreeView.SelectedNode.Parent.Text);
            }
        }

        private void menuBuildProject_Click(object sender, EventArgs e)
        {
            ProjectUtils.BuildCurrentProject();
        }

        private void menuBuildFile_Click(object sender, EventArgs e)
        {
            WindowHandler.BuildActiveFile();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            WindowHandler.SaveActiveFile();
        }

        private void menuFileClose_Click(object sender, EventArgs e)
        {
            WindowHandler.DeregisterWindow();
        }

        private void menuBuildTerminate_Click(object sender, EventArgs e)
        {
            CompilerUtils.StopCompile();
        }

        private void menuProjectSave_Click(object sender, EventArgs e)
        {
            ProjectUtils.SaveProject();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectUtils.SaveProject();
        }

        private void menuProjectSettings_Click(object sender, EventArgs e)
        {
            if (!ProjectUtils.IsProjectLoaded())
                return;

            ProjectSettingsWizardForm projectSettings = new ProjectSettingsWizardForm();
            projectSettings.ShowDialog(this);
        }

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            TreeNode activeNode = projectTreeView.SelectedNode;
            if (activeNode == null)
                return;

            if (activeNode.ContextMenuStrip != filterMenuStrip)
                return;

            Filter filter = ProjectUtils.GetFilter(activeNode.Text);
            if (filter == null)
                return;

            NewFileWizardForm newFileForm = new NewFileWizardForm(activeNode, filter, fileMenuStrip);
            newFileForm.ShowDialog(this);
        }

        private void menuToolsAnimationReverse_Click(object sender, EventArgs e)
        {
            AnimationReversionToolWizard animReversion = new AnimationReversionToolWizard();
            animReversion.ShowDialog(this);
        }

        private void menuToolsDirectoryCleanup_Click(object sender, EventArgs e)
        {
            DirectoryCleanupToolWizard directoryCleanup = new DirectoryCleanupToolWizard();
            directoryCleanup.ShowDialog(this);
        }

        private void menuToolsVMTGen_Click(object sender, EventArgs e)
        {
            VMTGeneratorToolWizard vmtGenTool = new VMTGeneratorToolWizard();
            vmtGenTool.ShowDialog(this);
        }

        private void menuHelpOnline_Click(object sender, EventArgs e)
        {
            Process.Start("https://developer.valvesoftware.com/wiki/SDK_Docs");
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutInfoForm appInfo = new AboutInfoForm();
            appInfo.ShowDialog(this);
        }
    }
}
