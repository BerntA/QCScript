//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: QC Command List Browser.
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
using QScript.Core;
using System.IO;
using Filesystem;

namespace QScript.Controls
{
    public partial class CommandList : UserControl
    {
        RichQCEditor _qcEditor = null;
        KeyValues _pkvData = null;
        public CommandList(RichQCEditor editor)
        {
            InitializeComponent();

            _qcEditor = editor;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            textSearch.KeyDown += new KeyEventHandler(OnKeyDown);
            itemList.KeyDown += new KeyEventHandler(OnKeyDown);
            textSearch.TextChanged += new EventHandler(OnTextSearchChanged);
        }

        public void ShowCommandList()
        {
            Visible = true;
            itemList.Items.Clear();
            textSearch.Text = null;

            string commandFile = string.Format("{0}\\config\\commands.txt", Globals.GetAppPath());
            if (!File.Exists(commandFile))
                return;

            _pkvData = new KeyValues();
            if (!_pkvData.LoadFromFile(commandFile))
                CloseCommandList();
            else
                AddCommands();
        }

        public void CloseCommandList()
        {
            if (_pkvData != null)
            {
                _pkvData.Dispose();
                _pkvData = null;
            }

            itemList.Items.Clear();
            textSearch.Text = null;
            Visible = false;

            _qcEditor.Focus();
        }

        public void PrintCommandInEditor()
        {
            string commandChosen = null;
            if (itemList.SelectedItem != null)
                commandChosen = itemList.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(commandChosen))
            {
                string template = null;
                for (int i = 0; i < _pkvData.GetItems().Count(); i++)
                {
                    if (_pkvData.GetItems()[i].key == commandChosen)
                    {
                        template = _pkvData.GetItems()[i].value;
                        break;
                    }
                }

                int length = 0;
                Clipboard.Clear();
                if (!string.IsNullOrEmpty(template))
                {
                    _qcEditor.SelectedText = template;
                    _qcEditor.Paste();
                    length = template.Length;
                }
                else
                {
                    _qcEditor.SelectedText = commandChosen;
                    _qcEditor.Paste();
                    length = commandChosen.Length;
                }

                _qcEditor.SelectionStart = _qcEditor.GetLastSelectionStart() + length;
            }

            CloseCommandList();
        }

        public void AddCommands(string search = null)
        {
            if (_pkvData == null)
                return;

            itemList.Items.Clear();

            for (int i = 0; i < _pkvData.GetItems().Count(); i++)
            {
                if (!string.IsNullOrEmpty(search) && !_pkvData.GetItems()[i].key.Contains(search))
                    continue;

                itemList.Items.Add(_pkvData.GetItems()[i].key);
            }
        }

        private void OnTextSearchChanged(object sender, EventArgs e)
        {
            AddCommands(textSearch.Text);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textSearch.Text = null;
                CloseCommandList();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (itemList.SelectedItem != null)
                    PrintCommandInEditor();
            }
        }

        private void itemList_DoubleClick(object sender, EventArgs e)
        {
            if (itemList.SelectedItem != null)
            {
                PrintCommandInEditor();
            }
        }
    }
}
