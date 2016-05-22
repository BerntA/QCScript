//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Handle opening, closing, creating and saving projects.
//
//==================================================================//

using Filesystem;
using QScript.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Core
{
    public static class ProjectUtils
    {
        public static string GetProjectName() { return _projectName; }
        public static string GetActiveProject() { return _pszActiveProjectPath; }
        public static string GetGameInfoPath() { return _pszGameInfoPath; }
        public static string GetStudioModelPath() { return _pszStudioModelPath; }
        public static string GetProjectDirectory() 
        {
            if (IsProjectLoaded())
                return Path.GetDirectoryName(_pszActiveProjectPath);

            return null;
        }

        static Filter _projectFilters = null;
        static string _pszActiveProjectPath;
        static string _pszGameInfoPath;
        static string _pszStudioModelPath;
        static string _projectName;

        public static bool CreateProject(string name, string path, string gameinfoPath, string studiomodelPath)
        {
            if (!Globals.IsStringValid(name) || !Globals.IsPathValid(path))
            {
                LoggingUtils.LogEvent("Failed to create a new project due to a faulty project name or path!");
                return false;
            }

            // Is there a project up already?
            if (!string.IsNullOrEmpty(_pszActiveProjectPath))
                CloseProject();

            // Set the new active project properties.
            _pszActiveProjectPath = string.Format("{0}\\{1}\\{1}.qcs", path, name);
            _pszGameInfoPath = gameinfoPath;
            _pszStudioModelPath = studiomodelPath;
            _projectName = name;
            _projectFilters = new Filter(_projectName);

            CreateEnvironment();

            SharedEvents.CreatedNewProject();
            // Create the default .qcs file, then write to it.
            return SaveProject();
        }

        public static bool OpenProject(string path)
        {
            // Is there a project up already?
            if (!string.IsNullOrEmpty(_pszActiveProjectPath))
                CloseProject();

            Properties.Settings.Default.lastProjectPath = Path.GetDirectoryName(path);
            Properties.Settings.Default.Save();

            _pszActiveProjectPath = path;
            CreateEnvironment();

            bool bLoaded = false;
            KeyValues pkvProjectFile = new KeyValues();
            if (pkvProjectFile.LoadFromFile(_pszActiveProjectPath))
            {
                bLoaded = true;

                _projectName = pkvProjectFile.GetName();
                _pszGameInfoPath = pkvProjectFile.GetString("GameInfoPath");
                _pszStudioModelPath = pkvProjectFile.GetString("StudioModelPath");

                KeyValues pkvFileData = pkvProjectFile.FindSubKey("Files");
                if (pkvFileData != null)
                {
                    _projectFilters = new Filter(_projectName);
                    IterateFileData(_projectFilters, pkvFileData);
                }
            }

            pkvProjectFile.Dispose();
            pkvProjectFile = null;

            SharedEvents.OpenedProject();
            return bLoaded;
        }

        public static void CloseProject()
        {
            if (!IsProjectLoaded())
                return;

            // We want to close our project, what do we do?:        
            // Close all windows associated to the project,
            // Auto Save the current stuff,
            // Cancel any in-action process such as compiling.
            if (CompilerUtils.IsCompiling())
                CompilerUtils.StopCompile();

            SaveProject();
            WindowHandler.CloseAllWindows();

            _projectFilters.Dispose();
            _projectFilters = null;
            SharedEvents.ClosedProject();
            _pszActiveProjectPath = null;
            Globals.compileLog.Text = null;
        }

        public static bool SaveProject()
        {
            if (string.IsNullOrEmpty(_pszActiveProjectPath))
                return false;

            if (!IsProjectLoaded())
                return false;

            // We re-create the file here - we need to store the structure of the project such as the .QC's you have and under which folders and stuff.
            using (StreamWriter writer = new StreamWriter(_pszActiveProjectPath))
            {
                writer.WriteLine(string.Format("\"{0}\"", _projectName));
                writer.WriteLine("{");

                writer.WriteLine("    \"GameInfoPath\" \"{0}\"", _pszGameInfoPath);
                writer.WriteLine("    \"StudioModelPath\" \"{0}\"", _pszStudioModelPath);
                writer.WriteLine("");

                _projectFilters.SaveFilters(writer);

                writer.WriteLine("}");
            }

            SharedEvents.SavedProject();
            return true;
        }

        public static void UpdateProjectSettings(string gameinfoPath, string studiomdlPath)
        {
            if (Directory.Exists(gameinfoPath))
                _pszGameInfoPath = gameinfoPath;

            if (Directory.Exists(studiomdlPath))
                _pszStudioModelPath = studiomdlPath;

            SaveProject();
        }

        public static void CreateEnvironment()
        {
            string directoryTree = Path.GetDirectoryName(_pszActiveProjectPath);

            // Create the directory tree(s).
            Directory.CreateDirectory(directoryTree);
            // Here we'll keep the .QC's
            Directory.CreateDirectory(string.Format("{0}\\src", directoryTree));
            // Whenever we compile we store a file with the compile log. <modelName_date_complog>
            Directory.CreateDirectory(string.Format("{0}\\logs", directoryTree));
            // Whenever we compile we will create a temp .qc file which is slightly modified from the original.
            Directory.CreateDirectory(string.Format("{0}\\temp", directoryTree));
        }

        public static bool IsProjectLoaded()
        {
            if (string.IsNullOrEmpty(_pszActiveProjectPath))
                return false;

            if (!Directory.Exists(Path.GetDirectoryName(_pszActiveProjectPath)))
            {
                LoggingUtils.LogEvent(string.Format("Couldn't locate the path for the project {0}!", _pszActiveProjectPath));
                return false;
            }

            return true;
        }

        public static void RefreshTreeView(TreeView view, ContextMenuStrip filterStrip, ContextMenuStrip fileStrip)
        {
            view.Nodes.Clear();

            TreeNode rootNode = new TreeNode(_projectName);
            rootNode.ContextMenuStrip = filterStrip;
            rootNode.ImageIndex = rootNode.SelectedImageIndex = rootNode.StateImageIndex = 1;
            _projectFilters.BuildTreeView(rootNode, filterStrip, fileStrip);
            view.Nodes.Add(rootNode);
            view.ExpandAll();
        }

        public static string GetFilePathForTreeNodeItem(string filterName, string fileName)
        {
            FilterInfo info = _projectFilters.GetFileInfo(filterName, fileName);
            if (info != null)
                return info.GetPath();

            return null;
        }

        public static void BuildCurrentProject()
        {
            BuildFilter(_projectName);
        }

        public static void BuildFilter(string filter)
        {
            if (_projectFilters == null)
                return;

            Filter filterToBuild = _projectFilters.FindFilterByName(_projectFilters, filter);
            if (filterToBuild != null)
                filterToBuild.BuildFilter();
        }

        public static bool RemoveFile(string name, string filter)
        {
            return _projectFilters.RemoveFile(filter, name);
        }

        public static void RemoveFilter(string filter, bool bDelete = false)
        {
            _projectFilters.RemoveFilter(filter, bDelete);  
        }

        public static void RemoveProject(bool bDelete = false)
        {
            string projectPath = GetProjectDirectory();
            WindowHandler.CloseAllWindows();
            Globals.compileLog.Text = null;
            _projectFilters.Dispose();
            _projectFilters = null; 

            if (bDelete)
            {
                try
                {
                    if (Directory.Exists(projectPath))
                        Directory.Delete(projectPath, true);
                }
                catch
                {
                    LoggingUtils.LogEvent("Unable to delete entire folder.");
                }

                _pszActiveProjectPath = null;
                return;
            }

            _projectFilters = new Filter(_projectName); 
        }

        public static Filter GetFilter(string filter)
        {
            return _projectFilters.FindFilterByName(_projectFilters, filter);
        }

        private static void IterateFileData(Filter filter, KeyValues data)
        {
            for (int i = 0; i < data.GetItems().Count(); i++)
            {
                filter.AddFile(data.GetItems()[i].key, data.GetItems()[i].value);
            }

            for (KeyValues sub = data.GetFirstKey(); sub != null; sub = data.GetNextKey())
            {
                Filter newSub = filter.AddSubFilter(sub.GetName());
                IterateFileData(newSub, sub);
            }
        }
    }
}
