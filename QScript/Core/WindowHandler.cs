//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Communicates with the context editor, swaps between windows, registers/removes, etc...
//
//==================================================================//

using QScript.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Core
{
    public static class WindowHandler
    {
        public static EditorContext contextWindowMenu { get; set; }

        public static void RegisterWindow(string name, string filter)
        {
            if (contextWindowMenu != null)
                contextWindowMenu.AddWindow(name, filter);
        }

        public static void DeregisterWindow(string name = null, string filter = null)
        {
            if (contextWindowMenu != null)
                contextWindowMenu.RemoveWindow(name, filter);
        }

        public static void CloseAllWindows()
        {
            if (contextWindowMenu != null)
                contextWindowMenu.RemoveAllWindows();
        }

        public static void BuildActiveFile()
        {
            if (contextWindowMenu != null)
                contextWindowMenu.BuildActiveFile();
        }

        public static void SaveActiveFile()
        {
            if (contextWindowMenu != null)
                contextWindowMenu.SaveActiveFile();
        }

        public static bool SaveFile(string name, string filter)
        {
            if (contextWindowMenu != null)
                return contextWindowMenu.SaveFile(name, filter);

            return false;
        }

        public static bool SaveOpenedFiles()
        {
            if (contextWindowMenu == null)
                return false;

            if (!contextWindowMenu.Visible)
                return false;

            foreach (TabPage page in contextWindowMenu.GetTabControl().TabPages)
            {
                string pathToFile = ProjectUtils.GetFilePathForTreeNodeItem(page.Name, page.Text);
                if (File.Exists(pathToFile))
                {
                    RichQCEditor textBox = contextWindowMenu.GetTextBoxFromTab(page);
                    if (textBox != null)
                        File.WriteAllText(pathToFile, textBox.Text, Encoding.ASCII);
                }
            }

            return true;
        }
    }
}
