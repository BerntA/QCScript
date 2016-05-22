namespace QScript
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuCommands = new System.Windows.Forms.MenuStrip();
            this.menuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuildProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuildFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuildTerminate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsAnimationReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsDirectoryCleanup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsVMTGen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.projectTreeView = new System.Windows.Forms.TreeView();
            this.treeViewImgList = new System.Windows.Forms.ImageList(this.components);
            this.statusBanner = new System.Windows.Forms.StatusStrip();
            this.textCommandLineParams = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editorMenu = new QScript.Controls.EditorContext();
            this.menuCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuCommands
            // 
            this.menuCommands.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProject,
            this.menuFile,
            this.menuBuild,
            this.menuTools,
            this.menuWindow,
            this.helpMenu});
            this.menuCommands.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuCommands.Location = new System.Drawing.Point(0, 0);
            this.menuCommands.Name = "menuCommands";
            this.menuCommands.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuCommands.Size = new System.Drawing.Size(580, 24);
            this.menuCommands.TabIndex = 3;
            this.menuCommands.Text = "Menu";
            // 
            // menuProject
            // 
            this.menuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProjectNew,
            this.menuProjectOpen,
            this.menuProjectClose,
            this.menuProjectSave,
            this.menuProjectSettings});
            this.menuProject.ForeColor = System.Drawing.Color.Black;
            this.menuProject.Image = global::QScript.Properties.Resources.icon_project;
            this.menuProject.Name = "menuProject";
            this.menuProject.Size = new System.Drawing.Size(72, 20);
            this.menuProject.Text = "Project";
            // 
            // menuProjectNew
            // 
            this.menuProjectNew.Image = global::QScript.Properties.Resources.icon_newproject;
            this.menuProjectNew.Name = "menuProjectNew";
            this.menuProjectNew.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.F)));
            this.menuProjectNew.Size = new System.Drawing.Size(180, 22);
            this.menuProjectNew.Text = "New";
            this.menuProjectNew.Click += new System.EventHandler(this.menuProjectNew_Click);
            // 
            // menuProjectOpen
            // 
            this.menuProjectOpen.Image = global::QScript.Properties.Resources.icon_openproject;
            this.menuProjectOpen.Name = "menuProjectOpen";
            this.menuProjectOpen.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.menuProjectOpen.Size = new System.Drawing.Size(180, 22);
            this.menuProjectOpen.Text = "Open";
            this.menuProjectOpen.Click += new System.EventHandler(this.menuProjectOpen_Click);
            // 
            // menuProjectClose
            // 
            this.menuProjectClose.Image = global::QScript.Properties.Resources.icon_closefile;
            this.menuProjectClose.Name = "menuProjectClose";
            this.menuProjectClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.menuProjectClose.Size = new System.Drawing.Size(180, 22);
            this.menuProjectClose.Text = "Close";
            this.menuProjectClose.Click += new System.EventHandler(this.menuProjectClose_Click);
            // 
            // menuProjectSave
            // 
            this.menuProjectSave.Image = global::QScript.Properties.Resources.icon_save;
            this.menuProjectSave.Name = "menuProjectSave";
            this.menuProjectSave.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.menuProjectSave.Size = new System.Drawing.Size(180, 22);
            this.menuProjectSave.Text = "Save";
            this.menuProjectSave.Click += new System.EventHandler(this.menuProjectSave_Click);
            // 
            // menuProjectSettings
            // 
            this.menuProjectSettings.Image = global::QScript.Properties.Resources.icon_settings;
            this.menuProjectSettings.Name = "menuProjectSettings";
            this.menuProjectSettings.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
            this.menuProjectSettings.Size = new System.Drawing.Size(180, 22);
            this.menuProjectSettings.Text = "Settings";
            this.menuProjectSettings.Click += new System.EventHandler(this.menuProjectSettings_Click);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileClose,
            this.menuFileSave});
            this.menuFile.Image = global::QScript.Properties.Resources.icon_file;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(53, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Image = global::QScript.Properties.Resources.icon_addfile;
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.menuFileNew.Size = new System.Drawing.Size(177, 22);
            this.menuFileNew.Text = "New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Image = global::QScript.Properties.Resources.icon_closefile;
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.menuFileClose.Size = new System.Drawing.Size(177, 22);
            this.menuFileClose.Text = "Close";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::QScript.Properties.Resources.icon_save;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(177, 22);
            this.menuFileSave.Text = "Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuBuild
            // 
            this.menuBuild.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBuildProject,
            this.menuBuildFile,
            this.menuBuildTerminate});
            this.menuBuild.Image = global::QScript.Properties.Resources.icon_tools;
            this.menuBuild.Name = "menuBuild";
            this.menuBuild.Size = new System.Drawing.Size(62, 20);
            this.menuBuild.Text = "Build";
            // 
            // menuBuildProject
            // 
            this.menuBuildProject.Image = global::QScript.Properties.Resources.icon_compile;
            this.menuBuildProject.Name = "menuBuildProject";
            this.menuBuildProject.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.menuBuildProject.Size = new System.Drawing.Size(160, 22);
            this.menuBuildProject.Text = "Build Project";
            this.menuBuildProject.Click += new System.EventHandler(this.menuBuildProject_Click);
            // 
            // menuBuildFile
            // 
            this.menuBuildFile.Image = global::QScript.Properties.Resources.icon_compile;
            this.menuBuildFile.Name = "menuBuildFile";
            this.menuBuildFile.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.menuBuildFile.Size = new System.Drawing.Size(160, 22);
            this.menuBuildFile.Text = "Build File";
            this.menuBuildFile.Click += new System.EventHandler(this.menuBuildFile_Click);
            // 
            // menuBuildTerminate
            // 
            this.menuBuildTerminate.Image = global::QScript.Properties.Resources.icon_closefile;
            this.menuBuildTerminate.Name = "menuBuildTerminate";
            this.menuBuildTerminate.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.menuBuildTerminate.Size = new System.Drawing.Size(160, 22);
            this.menuBuildTerminate.Text = "Terminate";
            this.menuBuildTerminate.Click += new System.EventHandler(this.menuBuildTerminate_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsAnimationReverse,
            this.menuToolsDirectoryCleanup,
            this.menuToolsVMTGen});
            this.menuTools.Image = global::QScript.Properties.Resources.icon_build;
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(64, 20);
            this.menuTools.Text = "Tools";
            // 
            // menuToolsAnimationReverse
            // 
            this.menuToolsAnimationReverse.Image = global::QScript.Properties.Resources.icon_reverse;
            this.menuToolsAnimationReverse.Name = "menuToolsAnimationReverse";
            this.menuToolsAnimationReverse.Size = new System.Drawing.Size(184, 22);
            this.menuToolsAnimationReverse.Text = "Animation Reversion";
            this.menuToolsAnimationReverse.Click += new System.EventHandler(this.menuToolsAnimationReverse_Click);
            // 
            // menuToolsDirectoryCleanup
            // 
            this.menuToolsDirectoryCleanup.Image = global::QScript.Properties.Resources.icon_gen;
            this.menuToolsDirectoryCleanup.Name = "menuToolsDirectoryCleanup";
            this.menuToolsDirectoryCleanup.Size = new System.Drawing.Size(184, 22);
            this.menuToolsDirectoryCleanup.Text = "Directory Cleanup";
            this.menuToolsDirectoryCleanup.Click += new System.EventHandler(this.menuToolsDirectoryCleanup_Click);
            // 
            // menuToolsVMTGen
            // 
            this.menuToolsVMTGen.Image = global::QScript.Properties.Resources.icon_gen;
            this.menuToolsVMTGen.Name = "menuToolsVMTGen";
            this.menuToolsVMTGen.Size = new System.Drawing.Size(184, 22);
            this.menuToolsVMTGen.Text = "VMT Generator";
            this.menuToolsVMTGen.Click += new System.EventHandler(this.menuToolsVMTGen_Click);
            // 
            // menuWindow
            // 
            this.menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowCloseAll});
            this.menuWindow.Image = global::QScript.Properties.Resources.icon_tab;
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(79, 20);
            this.menuWindow.Text = "Window";
            // 
            // menuWindowCloseAll
            // 
            this.menuWindowCloseAll.Image = global::QScript.Properties.Resources.icon_closefile;
            this.menuWindowCloseAll.Name = "menuWindowCloseAll";
            this.menuWindowCloseAll.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.menuWindowCloseAll.Size = new System.Drawing.Size(217, 22);
            this.menuWindowCloseAll.Text = "Close All";
            this.menuWindowCloseAll.Click += new System.EventHandler(this.menuWindowCloseAll_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpOnline,
            this.menuHelpAbout});
            this.helpMenu.Image = global::QScript.Properties.Resources.icon_help;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(60, 20);
            this.helpMenu.Text = "Help";
            // 
            // menuHelpOnline
            // 
            this.menuHelpOnline.Image = global::QScript.Properties.Resources.icon_online;
            this.menuHelpOnline.Name = "menuHelpOnline";
            this.menuHelpOnline.Size = new System.Drawing.Size(152, 22);
            this.menuHelpOnline.Text = "Online";
            this.menuHelpOnline.Click += new System.EventHandler(this.menuHelpOnline_Click);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Image = global::QScript.Properties.Resources.icon_help;
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.menuHelpAbout.Text = "About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // projectTreeView
            // 
            this.projectTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.projectTreeView.BackColor = System.Drawing.Color.DarkGray;
            this.projectTreeView.ForeColor = System.Drawing.Color.White;
            this.projectTreeView.HotTracking = true;
            this.projectTreeView.ImageIndex = 0;
            this.projectTreeView.ImageList = this.treeViewImgList;
            this.projectTreeView.Location = new System.Drawing.Point(0, 25);
            this.projectTreeView.Name = "projectTreeView";
            this.projectTreeView.SelectedImageIndex = 0;
            this.projectTreeView.Size = new System.Drawing.Size(173, 408);
            this.projectTreeView.TabIndex = 4;
            this.projectTreeView.DoubleClick += new System.EventHandler(this.projectTreeView_DoubleClick);
            // 
            // treeViewImgList
            // 
            this.treeViewImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImgList.ImageStream")));
            this.treeViewImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImgList.Images.SetKeyName(0, "icon_file.png");
            this.treeViewImgList.Images.SetKeyName(1, "icon_project.png");
            // 
            // statusBanner
            // 
            this.statusBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusBanner.Location = new System.Drawing.Point(0, 436);
            this.statusBanner.Name = "statusBanner";
            this.statusBanner.Size = new System.Drawing.Size(580, 22);
            this.statusBanner.TabIndex = 6;
            // 
            // textCommandLineParams
            // 
            this.textCommandLineParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textCommandLineParams.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textCommandLineParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCommandLineParams.ForeColor = System.Drawing.Color.Black;
            this.textCommandLineParams.Location = new System.Drawing.Point(440, 437);
            this.textCommandLineParams.Name = "textCommandLineParams";
            this.textCommandLineParams.Size = new System.Drawing.Size(120, 20);
            this.textCommandLineParams.TabIndex = 7;
            this.textCommandLineParams.Text = "-nop4 -nox360 -verbose";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(309, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Studiomodel Parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editorMenu
            // 
            this.editorMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editorMenu.Location = new System.Drawing.Point(179, 27);
            this.editorMenu.Name = "editorMenu";
            this.editorMenu.Size = new System.Drawing.Size(401, 406);
            this.editorMenu.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(580, 458);
            this.Controls.Add(this.textCommandLineParams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBanner);
            this.Controls.Add(this.menuCommands);
            this.Controls.Add(this.projectTreeView);
            this.Controls.Add(this.editorMenu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuCommands;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QCScript Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuCommands.ResumeLayout(false);
            this.menuCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuCommands;
        private System.Windows.Forms.ToolStripMenuItem menuProject;
        private System.Windows.Forms.ToolStripMenuItem menuProjectNew;
        private System.Windows.Forms.ToolStripMenuItem menuProjectOpen;
        private System.Windows.Forms.ToolStripMenuItem menuProjectClose;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSave;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuBuild;
        private System.Windows.Forms.ToolStripMenuItem menuBuildProject;
        private System.Windows.Forms.ToolStripMenuItem menuBuildFile;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolsAnimationReverse;
        private System.Windows.Forms.ToolStripMenuItem menuToolsDirectoryCleanup;
        private System.Windows.Forms.ToolStripMenuItem menuToolsVMTGen;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuWindowCloseAll;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem menuHelpOnline;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.TreeView projectTreeView;
        private Controls.EditorContext editorMenu;
        private System.Windows.Forms.StatusStrip statusBanner;
        private System.Windows.Forms.ToolStripMenuItem menuBuildTerminate;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSettings;
        private System.Windows.Forms.TextBox textCommandLineParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList treeViewImgList;
    }
}