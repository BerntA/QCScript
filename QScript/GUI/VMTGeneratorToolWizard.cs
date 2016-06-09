//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Generate .vmt files for the selected .vtf files.
//
//==================================================================//

using Filesystem;
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
    public partial class VMTGeneratorToolWizard : BorderlessFormBase
    {
        private string _selectedPath;
        public VMTGeneratorToolWizard()
        {
            InitializeComponent();

            comboBoxShaderList.Items.Clear();
            checkListParams.Items.Clear();

            string filePath = string.Format("{0}\\config\\shader_params.txt", Globals.GetAppPath());
            KeyValues pkvData = new KeyValues();
            if (pkvData.LoadFromFile(filePath))
            {
                for (int i = 0; i < pkvData.GetItems().Count(); i++)
                    comboBoxShaderList.Items.Add(pkvData.GetItems()[i].value);

                if (comboBoxShaderList.Items.Count > 0)
                    comboBoxShaderList.SelectedIndex = 0;
            }
            pkvData.Dispose();

            filePath = string.Format("{0}\\config\\material_params.txt", Globals.GetAppPath());
            pkvData = new KeyValues();
            if (pkvData.LoadFromFile(filePath))
            {
                for (int i = 0; i < pkvData.GetItems().Count(); i++)
                    checkListParams.Items.Add(pkvData.GetItems()[i].value);
            }

            pkvData.Dispose();
            pkvData = null;

            AddFrameButtonOffset(0, 0);
        }

        private string GetFolderPath(string desc)
        {
            string path = null;
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.SelectedPath = Globals.GetVMTPath();
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
            string path = GetFolderPath("Path to VTF files");
            if (!string.IsNullOrEmpty(path))
            {
                _selectedPath = path;
                Properties.Settings.Default.lastVMTPath = path;
                Properties.Settings.Default.Save();

                foreach (string file in Directory.EnumerateFiles(_selectedPath, "*.vtf"))
                {
                    listBoxFiles.Items.Add(Path.GetFileName(file));
                }

                string properPath = _selectedPath.ToLower().Replace("\\", "/");
                if (properPath.Contains("materials/"))
                {
                    int indexOfMat = properPath.IndexOf("materials/") + 10;
                    textBoxTexturePath.Text = properPath.Substring(indexOfMat);
                    return;
                }

                textBoxTexturePath.Text = null;
            }
        }

        private void checkListParams_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            timUpdate.Enabled = true;
        }

        private void comboBoxShaderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateTextPreview();
        }

        private void GenerateTextPreview()
        {
            richTextFile.Text = null;

            if (comboBoxShaderList.SelectedItem == null)
                return;

            if (comboBoxShaderList.SelectedIndex == 0)
                return;

            string text = null;
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine(string.Format("\"{0}\"", comboBoxShaderList.SelectedItem.ToString()));
                writer.WriteLine("{");

                writer.WriteLine("    \"$basetexture\" \"%path%\""); // %path% defines the end path to the actual .vtf file. $bumpmap "%path%_prefixhere" <== for normal map, ex..

                for (int i = 0; i < checkListParams.CheckedItems.Count; i++)
                {
                    writer.WriteLine(string.Format("    \"{0}\" \"1\"", checkListParams.CheckedItems[i].ToString()));
                }

                writer.WriteLine("}");
                text = writer.ToString();
            }

            richTextFile.Text = text;
        }

        private void timUpdate_Tick(object sender, EventArgs e)
        {
            GenerateTextPreview();
            timUpdate.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (comboBoxShaderList.SelectedItem == null)
                return;

            if (comboBoxShaderList.SelectedIndex == 0)
                return;

            if (listBoxFiles.SelectedItems == null)
                return;

            string script = richTextFile.Text;
            string texturePath = textBoxTexturePath.Text;
            string prefix = textBoxPrefix.Text;

            if (string.IsNullOrEmpty(script) || string.IsNullOrEmpty(_selectedPath))
                return;

            if (!texturePath.EndsWith("/") && !texturePath.EndsWith("\\") && !string.IsNullOrEmpty(texturePath))
                texturePath = texturePath + "/";

            List<string> selectedFiles = new List<string>();
            
            for (int i = 0; i < listBoxFiles.SelectedItems.Count; i++)
            {
                string pathToFile = string.Format("{0}\\{1}", _selectedPath, listBoxFiles.SelectedItems[i].ToString().Replace(".vtf", ".vmt"));
                selectedFiles.Add(pathToFile);
            }

            if (selectedFiles.Count() <= 0)
                return;

            VMTWriter vmtHandler = new VMTWriter(texturePath, prefix, script, richTextLog, selectedFiles.ToArray());
            vmtHandler.CreateVMTFiles();

            selectedFiles.Clear();
            selectedFiles = null;
        }
    }
}
