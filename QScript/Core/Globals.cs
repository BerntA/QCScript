//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Misc Utilities...
//
//==================================================================//

using QScript.Filesystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Core
{
    public static class Globals
    {
        public static string GetAppPath() { return Application.StartupPath; }
        public static RichTextBox compileLog { get; set; }
        public static TextBox compileArguments { get; set; }

        public static bool IsStringValid(string vString)
        {
            if (string.IsNullOrEmpty(vString) || string.IsNullOrWhiteSpace(vString))
                return false;

            if (vString.Contains('#') || vString.Contains(':') || vString.Contains('^') ||
                vString.Contains('\'') || vString.Contains('!') || vString.Contains('¤'))
                return false;

            return true;
        }

        public static bool IsPathValid(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
                return false;

            if (!path.Contains(':') || (!path.Contains('\\') && !path.Contains('/')))
                return false;

            return true;
        }

        public static int GetAverageColorValue(Color color)
        {
            int normalizedColor = (color.R + color.G + color.B);
            return (normalizedColor / 3);
        }

        public static int MAX(int value, int rangeMin, int rangeMax)
        {
            if (value > rangeMax)
                return rangeMax;
            else if (value < rangeMin)
                return rangeMin;

            return value;
        }

        public static bool OpenModelInHLMV(string path)
        {
            if (string.IsNullOrEmpty(path) || !ProjectUtils.IsProjectLoaded())
                return false;

            if (!File.Exists(path))
                return false;

            QCParser qcInfo = new QCParser(path);
            if (qcInfo.ParseQCFile())
            {
                string modelPath = string.Format("{0}\\models\\{1}", ProjectUtils.GetGameInfoPath(), qcInfo.GetQCParamValue("$modelname"));
                if (File.Exists(modelPath))
                {
                    string hlmv = string.Format("{0}\\hlmv.exe", ProjectUtils.GetStudioModelPath());
                    if (File.Exists(hlmv))
                    {
                        using (Process procLaunchHLMV = new Process())
                        {
                            procLaunchHLMV.StartInfo.Arguments = string.Format("-game \"{0}\" \"{1}\"", ProjectUtils.GetGameInfoPath(), modelPath);
                            procLaunchHLMV.StartInfo.CreateNoWindow = true;
                            procLaunchHLMV.StartInfo.FileName = hlmv;
                            procLaunchHLMV.StartInfo.UseShellExecute = false;
                            procLaunchHLMV.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            procLaunchHLMV.StartInfo.RedirectStandardOutput = true;
                            procLaunchHLMV.Start();
                        }
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
