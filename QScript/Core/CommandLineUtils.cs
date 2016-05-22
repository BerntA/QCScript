//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Command Line Handler
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QScript.Core
{
    public static class CommandLineUtils
    {
        public static string GetProjectInputPath()
        {
            string[] args = System.Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string filePath = args[1];
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    if (info.Extension == ".qcs")
                        return filePath;
                }
            }

            return null;
        }
    }
}
