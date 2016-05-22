//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Utility funcs for KeyValues!
//
//==================================================================//

using QScript.Core;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Filesystem
{
    internal static class KeyValuesUtils
    {
        public static List<string> ReadFileToList(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    List<string> fileLines = new List<string>();
                    while (!sr.EndOfStream)
                        fileLines.Add(sr.ReadLine());
                    return fileLines;
                }
            }
            catch
            {
                LoggingUtils.LogEvent(string.Format("Unable to read file '{0}' for KeyValues!", filePath));
                return null;
            }
        }

        public static List<string> ReadStreamToList(string stream)
        {
            try
            {
                using (StringReader sr = new StringReader(stream))
                {
                    List<string> fileLines = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        fileLines.Add(line);
                    return fileLines;
                }
            }
            catch
            {
                LoggingUtils.LogEvent("Unable to read stream for KeyValues!");
                return null;
            }
        }

        public static string GetUrlStream(string url)
        {
            try
            {
                return new WebClient().DownloadString(url);
            }
            catch
            {
                LoggingUtils.LogEvent("Unable to read url for KeyValues!");
                return null;
            }
        }
    }
}
