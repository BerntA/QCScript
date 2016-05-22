//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Logging Handler.
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Core
{
    public static class LoggingUtils
    {
        public static void LogEvent(string message)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd-HH");
            string logDir = string.Format("{0}\\logs", Globals.GetAppPath());
            string filePath = string.Format("{0}\\{1}.txt", logDir, date);

            // If we're writing to the same log multiple times during the same time space we want to append to make sure we don't lose valuable info.
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message + Environment.NewLine);
            }
        }

        public static bool CreateCompileLog(string mdlName, string log, string directoryStructure)
        {
            if (!ProjectUtils.IsProjectLoaded())
                return false;

            string logFile = string.Format("{0}\\logs{1}\\{2}.txt", ProjectUtils.GetProjectDirectory(), directoryStructure, Path.GetFileNameWithoutExtension(mdlName));
            Directory.CreateDirectory(Path.GetDirectoryName(logFile));
            File.WriteAllText(logFile, log);
            return true;
        }
    }
}
