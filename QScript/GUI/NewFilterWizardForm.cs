//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Add a new filter in the project hierarchy.
//
//==================================================================//

using QScript.Core;
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
    public partial class NewFilterWizardForm : BorderlessFormBase
    {
        private TreeNode _node;
        private Filter _filter;
        private ContextMenuStrip _filterStrip;
        public NewFilterWizardForm(TreeNode parentNode, Filter filter, ContextMenuStrip filterStrip)
        {
            InitializeComponent();

            _node = parentNode;
            _filter = filter;
            _filterStrip = filterStrip;
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            string text = textBoxName.Text;
            Filter hasFilter = ProjectUtils.GetFilter(text);
            if (hasFilter != null)
            {
                InfoDialog.ShowDialog(this, "This filter already exists!", "Error!");
                return;
            }

            if (Globals.IsStringValid(text))
            {
                TreeNode newNode = new TreeNode(text);
                newNode.ContextMenuStrip = _filterStrip;
                newNode.ImageIndex = newNode.SelectedImageIndex = newNode.StateImageIndex = 1;
                _node.Nodes.Add(newNode);
                Filter newSubFilter = _filter.AddSubFilter(text);
                string fullPath = string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), newSubFilter.GetFilterDirectory());
                Directory.CreateDirectory(fullPath);

                _node.ExpandAll();
                Close();
            }
        }
    }
}
