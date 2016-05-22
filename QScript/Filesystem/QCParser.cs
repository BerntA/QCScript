//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: A simple QC script parser, we don't really want to parse too much here.
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Filesystem
{
    public sealed class QCParser
    {
        public struct QCKeyValues
        {
            public string parameter;
            public string value;
        }

        public string GetQCContent() { return _qcContent; }

        private string[] parameters =
        {
            "$modelname ",
            "$cdmaterials ",
            "$includemodel ",
            "$include ",
        };

        private string _path;
        private string _qcContent;
        private bool _bHasParsedSuccessfully;
        private List<QCKeyValues> _params;
        public QCParser(string path)
        {
            _path = path;
            _params = new List<QCKeyValues>();
        }

        public bool ParseQCFile()
        {
            _bHasParsedSuccessfully = false;
            _params.Clear();
            _qcContent = null;

            if (!File.Exists(_path))
                return false;

            FileInfo info = new FileInfo(_path);
            if ((info.Extension != ".qc") && (info.Extension != ".qci"))
                return false;

            string localContent = null;
            using (StreamReader reader = new StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("$include "))
                    {
                        string value = GetKeyValue(line, "$include ");
                        if (!File.Exists(value))
                            line = string.Format("$include \"{0}\\{1}\"", Path.GetDirectoryName(_path), value);
                    }
                    else if (line.Contains("$includemodel "))
                    {
                        string value = GetKeyValue(line, "$includemodel ");
                        if (!File.Exists(value))
                            line = string.Format("$includemodel \"{0}\\{1}\"", Path.GetDirectoryName(_path), value);
                    }

                    if (!line.Contains("$cd "))
                    {
                        for (int i = 0; i < parameters.Count(); i++)
                        {
                            if (line.Contains(parameters[i]))
                            {
                                line = line.ToLower().Replace("\\", "/"); // Make sure that the material path and model path is lowercase + uses forward slashes.

                                QCKeyValues item;
                                item.parameter = parameters[i];
                                item.value = GetKeyValue(line, parameters[i]);

                                _params.Add(item);
                            }
                        }

                        localContent += (line + Environment.NewLine);
                    }
                }
            }

            _qcContent = string.Format("$cd \"{0}\"\n{1}\n", Path.GetDirectoryName(_path), localContent);
            _bHasParsedSuccessfully = true;
            return true;
        }

        public string GetQCParamValue(string param)
        {
            if (!_bHasParsedSuccessfully)
                return null;

            for (int i = 0; i < _params.Count(); i++)
            {
                if (_params[i].parameter.StartsWith(param))
                    return _params[i].value;
            }

            return null;
        }

        private string GetKeyValue(string line, string param)
        {
            bool bHasQuotes = line.Contains('"');
            string value = line.Replace(param, "").Replace("\"", "");

            if (bHasQuotes)
            {
                int indexOfFirstQuote = (line.IndexOf('"') + 1);
                int indexOfNextQuote = line.IndexOf('"', indexOfFirstQuote);
                value = line.Substring(indexOfFirstQuote, (indexOfNextQuote - indexOfFirstQuote));
            }

            return value;
        }
    }
}
