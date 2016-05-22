//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Window & Script Editor Menu.
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
using System.IO;
using QScript.Core;

namespace QScript.Controls
{
    public partial class EditorContext : UserControl
    {
        public TabControl GetTabControl() { return tabEditor; }
        Point _lastClickPosition;
        ContextMenuStrip _contextMenuStrip = null;
        public EditorContext()
        {
            InitializeComponent();
            tabEditor.Visible = false;

            _contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

            ToolStripItem item = null;
            item = _contextMenuStrip.Items.Add("Save");
            item.Image = Properties.Resources.icon_save;
            item.Click += new EventHandler(OnMenuStripClickSave);

            item = _contextMenuStrip.Items.Add("Close");
            item.Image = Properties.Resources.icon_closefile;
            item.Click += new EventHandler(OnMenuStripClickClose);

            item = _contextMenuStrip.Items.Add("Build");
            item.Image = Properties.Resources.icon_compile;
            item.Click += new EventHandler(OnMenuStripClickBuild);

            item = _contextMenuStrip.Items.Add("Open in HLMV");
            item.Image = Properties.Resources.icon_gen;
            item.Click += new EventHandler(OnMenuStripClickOnOpenHLMV);

            tabEditor.MouseClick += new MouseEventHandler(tabMouseClick);

            RichTextBox box = new RichTextBox();
            box.Parent = this;
            box.Size = new System.Drawing.Size(Width, 140);
            box.Dock = DockStyle.Bottom;
            box.ReadOnly = true;
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.BackColor = Color.DimGray;
            box.ForeColor = Color.White;
            box.ScrollBars = RichTextBoxScrollBars.Vertical;
            box.AcceptsTab = false;
            box.DetectUrls = false;
            box.Font = new System.Drawing.Font("Century", 9);
            Globals.compileLog = box;
        }

        public void AddWindow(string name, string filter)
        {
            if (!tabEditor.Visible)
                tabEditor.Visible = true;

            TabPage tab = FindPage(filter, name);
            if (tab != null)
            {
                tabEditor.SelectTab(tab);
                return;
            }

            RichQCEditor textBox = new RichQCEditor();
            string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(filter, name);
            if (!string.IsNullOrEmpty(pathToFile))
                textBox.Text = File.ReadAllText(pathToFile);
            
            tab = new TabPage(name);
            tab.Name = filter;
            textBox.Parent = tab;
            textBox.Dock = DockStyle.Fill;
            tabEditor.TabPages.Add(tab);
            tabEditor.SelectTab(tab);
        }

        public void RemoveWindow(TabPage tab)
        {
            tabEditor.TabPages.Remove(tab);

            if (tabEditor.TabPages.Count <= 0)
                tabEditor.Visible = false;
        }

        public void RemoveWindow(string name = null, string filter = null)
        {
            if (!tabEditor.Visible)
                return;

            // If name and filter is null we'll remove the 'active' tab.
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(filter))
            {
                tabEditor.TabPages.Remove(tabEditor.SelectedTab);
            }
            else
            {
                foreach (TabPage tab in tabEditor.TabPages)
                {
                    if (tab.Name == filter && tab.Text == name)
                    {
                        tabEditor.TabPages.Remove(tab);
                        break;
                    }
                }
            }

            if (tabEditor.TabPages.Count <= 0)
                tabEditor.Visible = false;
        }

        public void RemoveAllWindows()
        {
            tabEditor.TabPages.Clear();
            tabEditor.Visible = false;
        }

        public void BuildActiveFile()
        {
            if (!tabEditor.Visible)
                return;

            TabPage tab = tabEditor.SelectedTab;
            if (tab == null)
                return;

            string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(tab.Name, tab.Text);
            if (!string.IsNullOrEmpty(pathToFile))
                CompilerUtils.AddToQueue(pathToFile);
        }

        public void SaveActiveFile()
        {
            if (!tabEditor.Visible)
                return;

            TabPage tab = tabEditor.SelectedTab;
            if (tab == null)
                return;

            SaveFile(tab);
        }

        public bool SaveFile(string name, string filter)
        {
            if (!tabEditor.Visible)
                return false;

            TabPage page = FindPage(filter, name);
            if (page != null)
            {
                SaveFile(page);
                return true;
            }

            return false;
        }

        public RichQCEditor GetTextBoxFromTab(TabPage tab)
        {
            foreach (Control control in tab.Controls)
            {
                if (control is RichQCEditor)
                    return ((RichQCEditor)control);
            }

            return null;
        }

        private void tabMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _contextMenuStrip.Show(tabEditor, e.Location);
                _lastClickPosition = Cursor.Position;
            }
        }

        private void SaveFile(TabPage tab)
        {
            RichQCEditor richText = GetTextBoxFromTab(tab);
            if (richText == null)
                return;

            string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(tab.Name, tab.Text);
            if (!string.IsNullOrEmpty(pathToFile))
            {
                File.WriteAllText(pathToFile, richText.Text);
            }
        }

        private TabPage FindPage(string filter, string fileName)
        {
            foreach (TabPage tab in tabEditor.TabPages)
            {
                if (tab.Name == filter && tab.Text == fileName)
                {
                    return tab;
                }
            }

            return null;
        }

        private void OnMenuStripClickSave(object sender, EventArgs e)
        {
            TabPage tab = GetCurrentTabPage();
            if (tab != null)
                SaveFile(tab);
        }

        private void OnMenuStripClickClose(object sender, EventArgs e)
        {
            TabPage tab = GetCurrentTabPage();
            if (tab != null)
                RemoveWindow(tab);
        }

        private void OnMenuStripClickBuild(object sender, EventArgs e)
        {
            TabPage tab = GetCurrentTabPage();
            if (tab != null)
            {
                string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(tab.Name, tab.Text);
                if (!string.IsNullOrEmpty(pathToFile))
                    CompilerUtils.AddToQueue(pathToFile);
            }
        }

        private void OnMenuStripClickOnOpenHLMV(object sender, EventArgs e)
        {
            TabPage tab = GetCurrentTabPage();
            if (tab != null)
            {
                string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(tab.Name, tab.Text);
                Globals.OpenModelInHLMV(pathToFile);
            }
        }

        private TabPage GetCurrentTabPage()
        {
            for (int i = 0; i < tabEditor.TabCount; i++)
            {
                if (tabEditor.GetTabRect(i).Contains(tabEditor.PointToClient(_lastClickPosition)))
                    return (tabEditor.Controls[i] as TabPage);
            }

            return null;
        }
    }
}
