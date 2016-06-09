//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: A simple QC script parser, we don't really want to parse too much here.
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
        private List<string> _dependentFiles;
        public QCParser(string path)
        {
            _path = path;
            _params = new List<QCKeyValues>();
            _dependentFiles = new List<string>();
        }

        public bool ParseQCFile(bool bImport = false)
        {
            _bHasParsedSuccessfully = false;
            _params.Clear();
            _dependentFiles.Clear();
            _qcContent = null;

            if (!File.Exists(_path))
                return false;

            FileInfo info = new FileInfo(_path);
            if ((info.Extension != ".qc") && (info.Extension != ".qci"))
                return false;

            string qcName = Path.GetFileNameWithoutExtension(_path);
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

                        if (bImport)
                        {
                            string absPath = string.Format("{0}\\{1}", Path.GetDirectoryName(_path), value);
                            if (File.Exists(absPath))
                                _dependentFiles.Add(absPath.Replace("/", "\\"));
                        }
                    }

                    if (bImport)
                    {
                        if (line.Contains("$body ") || line.Contains("$model ") || line.Contains("replacemodel "))
                        {
                            int lastQuote = line.LastIndexOf("\"");
                            int previousQuote = line.LastIndexOf("\"", lastQuote - 1);

                            string rawValue = line.Substring(previousQuote, (lastQuote - previousQuote + 1));
                            string value = rawValue.ToLower().Replace("\"", "").Replace(".smd", "");

                            string absPath = string.Format("{0}\\{1}.smd", Path.GetDirectoryName(_path), value);
                            if (File.Exists(absPath))
                                _dependentFiles.Add(absPath.Replace("/", "\\"));

                            line = line.Remove(previousQuote, rawValue.Length).Insert(previousQuote, string.Format("\"{0}/{1}.smd\"", qcName, value));
                        }

                        if (line.Contains("$sequence ") || line.Contains("$animation "))
                        {
                            string animType = (line.Contains("$sequence ") ? "$sequence " : "$animation ");

                            int startIndex = line.IndexOf(animType) + animType.Length;
                            int nextIndex = line.IndexOf(" ", startIndex) + 1;
                            int endIndex = line.IndexOf(" ", nextIndex);

                            string rawValue = line.Substring(nextIndex, (endIndex - nextIndex));
                            string value = line.ToLower().Substring(nextIndex, (endIndex - nextIndex)).Replace("\"", "").Replace(".smd", "");
                            string absPath = string.Format("{0}\\{1}.smd", Path.GetDirectoryName(_path), value);

                            if (File.Exists(absPath))
                                _dependentFiles.Add(absPath.Replace("/", "\\"));

                            line = line.Remove(nextIndex, rawValue.Length).Insert(nextIndex, string.Format("\"{0}/{1}.smd\"", qcName, value));
                        }
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
            if (bImport)
                _qcContent = string.Format("{0}\n", localContent);

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

        public bool ImportDependenciesToPath(string path)
        {
            if (!ParseQCFile(true))
                return false;

            if (_dependentFiles.Count() <= 0)
                return false;         

            try
            {
                string qcDir = Path.GetDirectoryName(_path);
                string relativeSubDir = Path.GetFileNameWithoutExtension(_path);
                for (int i = 0; i < _dependentFiles.Count(); i++)
                {
                    string source = _dependentFiles[i];
                    string relativePath = Path.GetDirectoryName(source.Replace(qcDir, ""));
                    string outputFile = string.Format("{0}\\{1}{2}\\{3}", path, relativeSubDir, relativePath, Path.GetFileName(source));

                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    File.Copy(source, outputFile, true);
                }

                File.WriteAllText(string.Format("{0}\\{1}", path, Path.GetFileName(_path)), GetQCContent(), Encoding.ASCII);
            }
            catch
            {
                LoggingUtils.LogEvent(string.Format("Unable to import anims, includes and references for QC {0} at path {1}!", Path.GetFileName(_path), Path.GetDirectoryName(_path)));
                return false;
            }

            return true;
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
