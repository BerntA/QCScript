//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Main Entry Point.
//
//==================================================================//

using QScript.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QScript
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
