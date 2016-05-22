//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: SMD Compile Class.
//
//==================================================================//

using QScript.Filesystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QScript.Core
{
    public static class CompilerUtils
    {
        public static bool IsCompiling() { return _m_bIsCompiling; }
        public static string _compileArgs { get; set; }
        public static string GetStudioMdlPath()
        {
            if (ProjectUtils.IsProjectLoaded())
                return string.Format("{0}\\studiomdl.exe", ProjectUtils.GetStudioModelPath());

            return null;
        }

        private static bool _m_bIsCompiling = false;
        private static bool CanCompile() { return File.Exists(GetStudioMdlPath()); }
        private static int _currentItemInList = 0;
        private static List<string> _compileList = new List<string>();

        public static void AddToQueue(string path)
        {
            if (!CanCompile() || !File.Exists(path))
                return;

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Extension != ".qc")
                return;

            int count = _compileList.Count();
            _compileList.Add(path);

            if (count <= 0)
            {
                _compileArgs = Globals.compileArguments.Text;
                Globals.compileLog.Text = null;
                _currentItemInList = 0;
                _m_bIsCompiling = true;
                WindowHandler.SaveOpenedFiles();
                SharedEvents.StartCompile();
                ProcessQCFile();
            }
        }

        public static bool StopCompile()
        {
            if (!_m_bIsCompiling)
                return false;

            _compileList.Clear();
            bool bFound = false;
            for (int i = 0; i < Process.GetProcesses().Length; i++)
            {
                Process proc = Process.GetProcesses()[i];
                if (proc.ProcessName == "studiomdl")
                {                   
                    proc.Kill();
                    bFound = true;
                }
            }

            if (bFound)
            {
                LoggingUtils.LogEvent("Canceled a model compilation.");
                _m_bIsCompiling = false;
                SharedEvents.StopCompile();
                Globals.compileLog.Text = null;
            }

            return bFound;
        }

        public static void ProcessQCFile()
        {
            if (_currentItemInList >= _compileList.Count())
            {
                _compileList.Clear();
                _m_bIsCompiling = false;
                SharedEvents.CompileFinished();
                return;
            }

            string path = _compileList[_currentItemInList];
            _currentItemInList++;

            CompileThread compileQC = new CompileThread(path);
            Thread compThread = new Thread(new ThreadStart(compileQC.Compile));
            compThread.Start();
        }
    }

    public class CompileThread
    {
        private string _path;
        private string _log;
        private string _mdlName;
        private string _directoryStructure;

        public CompileThread(string path)
        {
            _path = path;
            _log = null;
            _mdlName = "";
            _directoryStructure = (Path.GetDirectoryName(path).Replace(ProjectUtils.GetProjectDirectory(), ""));

            string content = "";
            QCParser qcFile = new QCParser(_path);
            if (qcFile.ParseQCFile())
            {
                content = qcFile.GetQCContent();
                _mdlName = qcFile.GetQCParamValue("$modelname");
            }

            _path = string.Format("{0}\\temp\\compile.qc", ProjectUtils.GetProjectDirectory());
            File.WriteAllText(_path, content);
        }

        public void Compile()
        {
            string _args = CompilerUtils._compileArgs;
            string arguments = string.Format("-game \"{0}\" \"{1}\"", ProjectUtils.GetGameInfoPath(), _path);
            if (!string.IsNullOrEmpty(_args))
                arguments = string.Format("-game \"{0}\" {1} \"{2}\"", ProjectUtils.GetGameInfoPath(), _args, _path);

            Process procLaunchStudioMdl = new Process();
            procLaunchStudioMdl.StartInfo.Arguments = arguments;
            procLaunchStudioMdl.StartInfo.CreateNoWindow = true;
            procLaunchStudioMdl.StartInfo.FileName = CompilerUtils.GetStudioMdlPath();
            procLaunchStudioMdl.StartInfo.UseShellExecute = false;
            procLaunchStudioMdl.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            procLaunchStudioMdl.StartInfo.RedirectStandardOutput = true;
            procLaunchStudioMdl.Start();

            while (!procLaunchStudioMdl.StandardOutput.EndOfStream && CompilerUtils.IsCompiling())
            {
                string line = procLaunchStudioMdl.StandardOutput.ReadLine();

                Globals.compileLog.Invoke(new Action(() => Globals.compileLog.Text += (line + Environment.NewLine)));
                _log += (line + Environment.NewLine);
            }

            LoggingUtils.CreateCompileLog(_mdlName, _log, _directoryStructure);
            CompilerUtils.ProcessQCFile();
        }
    }
}
