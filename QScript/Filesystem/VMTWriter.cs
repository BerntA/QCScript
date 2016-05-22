//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Creates .vmt files from a bunch of input files.
//
//==================================================================//

using QScript.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Filesystem
{
    public sealed class VMTWriter
    {
        private string[] _files;
        private RichTextBox _textLog;
        private string _script;
        private string _prefix;
        private string _texturePath;
        public VMTWriter(string texturePath, string prefix, string script, RichTextBox log, string[] selectedFiles)
        {
            _texturePath = texturePath;
            _prefix = prefix;
            _script = script;
            _textLog = log;
            _files = selectedFiles;
        }

        public bool CreateVMTFiles()
        {
            _textLog.Text = null;
            bool bCreated = false;
            for (int i = 0; i < _files.Count(); i++)
            {
                string path = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(_files[i]), _prefix, Path.GetFileName(_files[i]));
                string texturePath = string.Format("{0}{1}", _texturePath, Path.GetFileNameWithoutExtension(path));
                texturePath = texturePath.ToLower().Replace("\\", "/");
                string script = _script.Replace("%path%", texturePath);
                _textLog.Text += string.Format("Created .vmt for {0}!", Path.GetFileNameWithoutExtension(path)) + Environment.NewLine;

                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.WriteAllText(path, script);
                }
                catch
                {
                    LoggingUtils.LogEvent("Unable to create .vmt file!");
                }

                bCreated = true;
            }

            return bCreated;
        }
    }
}
