//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: File Filter - This is a virtual 'folder' which contains file info which is loaded from the .qcs project file.
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
    public sealed class FilterInfo
    {
        public string GetPath() { return _path; }
        public string GetLocalPath() { return _localPath; }
        public string GetPathType() { return _pathType; }

        private string _pathType;
        private string _localPath;
        private string _path;
        public FilterInfo(string path, string localPath, string pathType)
        {
            _path = path;
            _localPath = localPath;
            _pathType = pathType;
        }
    }

    public class Filter : IDisposable
    {
        public string GetName() { return _name; }
        public Filter GetParent() { return _parent; }
        public FilterInfo[] GetFiles() { return _files.ToArray(); }
        public Filter[] GetSubFilters() { return _subFilters.ToArray(); }
        public void RemoveFile(FilterInfo info) { _files.Remove(info); }
        public void RemoveFilter(Filter filter) { _subFilters.Remove(filter); }

        private string _name;
        private List<FilterInfo> _files;
        private List<Filter> _subFilters;
        private Filter _parent;
        public Filter(string name)
        {
            _name = name;
            _parent = null;
            _files = new List<FilterInfo>();
            _subFilters = new List<Filter>();
        }

        public Filter(string name, Filter parent)
        {
            _name = name;
            _parent = parent;
            _files = new List<FilterInfo>();
            _subFilters = new List<Filter>();
        }

        public Filter AddSubFilter(string name)
        {
            Filter sub = FindSubFilter(name);
            if ((sub != null) || (name == GetName()))
                return null;

            Filter newSub = new Filter(name, this);         
            _subFilters.Add(newSub);
            return newSub;
        }

        public Filter FindSubFilter(string name)
        {
            for (int i = (_subFilters.Count() - 1); i >= 0; i--)
            {
                if (_subFilters[i].GetName() == name)
                    return _subFilters[i];
            }

            return null;
        }

        public void AddFile(string pathType, string path)
        {
            string fullPath = path;
            if (pathType != "path")
                fullPath = string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), path);

            _files.Add(new FilterInfo(fullPath, path, pathType));
        }

        public bool RemoveFile(string filterName, string fileName)
        {
            Filter filter = FindFilterByName(this, filterName);
            if (filter != null)
            {
                for (int i = (filter.GetFiles().Count() - 1); i >= 0; i--)
                {
                    string name = Path.GetFileName(filter.GetFiles()[i].GetPath());
                    if (fileName.Equals(name, StringComparison.CurrentCulture))
                    {
                        filter.RemoveFile(filter.GetFiles()[i]);
                        return true;
                    }
                }
            }

            return false;
        }

        public void RemoveFiles(bool bDelete = false)
        {
            RemoveFiles(this, bDelete);
        }

        public void RemoveFiles(Filter subFilter, bool bDelete)
        {
            for (int i = 0; i < subFilter.GetFiles().Count(); i++)
            {
                string path = subFilter.GetFiles()[i].GetPath();
                if (bDelete && File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {
                        LoggingUtils.LogEvent(string.Format("Unable to delete file {0}!", path));
                    }
                }
            }

            subFilter._files.Clear();

            for (int i = (subFilter.GetSubFilters().Count() - 1); i >= 0; i--)
                RemoveFiles(subFilter.GetSubFilters()[i], bDelete);
        }

        public bool RemoveFilter(string filter, bool bDelete = false)
        {
            Filter filterToRemove = FindFilterByName(this, filter);
            if (filterToRemove == null)
                return false;

            string directoryToRemove = string.Format("{0}\\{1}", ProjectUtils.GetProjectDirectory(), filterToRemove.GetFilterDirectory());
            filterToRemove.RemoveFiles(bDelete);

            try
            {
                Directory.Delete(directoryToRemove);
            }
            catch
            {
                LoggingUtils.LogEvent("Unable to delete directory!");
            }

            Filter parentFilter = filterToRemove.GetParent();
            if (parentFilter == null)
                return true;

            parentFilter.RemoveFilter(filterToRemove);
            return true;
        }

        public FilterInfo GetFileInfo(string filterName, string fileName)
        {
            Filter filter = FindFilterByName(this, filterName);
            if (filter != null)
            {
                for (int i = (filter.GetFiles().Count() - 1); i >= 0; i--)
                {
                    string name = Path.GetFileName(filter.GetFiles()[i].GetPath());
                    if (fileName.Equals(name, StringComparison.CurrentCulture))
                        return filter.GetFiles()[i];
                }
            }

            return null;
        }

        public Filter FindFilterByName(Filter start, string filterName)
        {
            if (start.GetName() == filterName)
                return start;

            Filter subFilter = null;
            for (int i = (start.GetSubFilters().Count() - 1); i >= 0; i--)
            {
                subFilter = FindFilterByName(start.GetSubFilters()[i], filterName);
                if (subFilter != null)
                    break;
            }

            return subFilter;
        }

        public void SaveFilters(StreamWriter writer)
        {
            SaveFilters(this, writer);
        }

        public void SaveFilters(Filter sub, StreamWriter writer, string extraSpace = "")
        {
            extraSpace += "    ";
            string fileSpace = extraSpace + "    ";
            string filterName = sub.GetName();
            if (filterName == ProjectUtils.GetProjectName())
                filterName = "Files";

            writer.WriteLine(string.Format("{0}\"{1}\"", extraSpace, filterName));
            writer.WriteLine(string.Format("{0}", extraSpace) + "{");

            for (int i = 0; i < sub.GetFiles().Count(); i++)
                writer.WriteLine(string.Format("{0}\"{1}\" \"{2}\"", fileSpace, sub.GetFiles()[i].GetPathType(), sub.GetFiles()[i].GetLocalPath()));

            for (int i = 0; i < sub.GetSubFilters().Count(); i++)
                SaveFilters(sub.GetSubFilters()[i], writer, extraSpace);

             writer.WriteLine(string.Format("{0}", extraSpace) + "}");
        }

        public void BuildFilter()
        {
            BuildFilter(this);
        }

        public void BuildFilter(Filter sub)
        {
            for (int i = 0; i < sub.GetFiles().Count(); i++)
                CompilerUtils.AddToQueue(sub.GetFiles()[i].GetPath());

            for (int i = 0; i < sub.GetSubFilters().Count(); i++)
                BuildFilter(sub.GetSubFilters()[i]);
        }

        public void BuildTreeView(TreeNode node, ContextMenuStrip filterStrip, ContextMenuStrip fileStrip)
        {
            BuildTreeView(this, node, filterStrip, fileStrip);
        }

        public void BuildTreeView(Filter subFilter, TreeNode subNode, ContextMenuStrip filterStrip, ContextMenuStrip fileStrip)
        {
            for (int i = 0; i < subFilter.GetFiles().Count(); i++)
            {
                TreeNode newSub = new TreeNode(Path.GetFileName(subFilter.GetFiles()[i].GetPath()));
                newSub.ContextMenuStrip = fileStrip;
                newSub.ImageIndex = newSub.SelectedImageIndex = newSub.StateImageIndex = 0;
                subNode.Nodes.Add(newSub);
            }

            for (int i = 0; i < subFilter.GetSubFilters().Count(); i++)
            {
                TreeNode newSub = new TreeNode(subFilter.GetSubFilters()[i].GetName());
                newSub.ContextMenuStrip = filterStrip;
                newSub.ImageIndex = newSub.SelectedImageIndex = newSub.StateImageIndex = 1;
                subNode.Nodes.Add(newSub);
                BuildTreeView(subFilter.GetSubFilters()[i], newSub, filterStrip, fileStrip);
            }
        }

        public string GetFilterDirectory()
        {
            if (GetName() == ProjectUtils.GetProjectName())
                return "src";

            string folder = string.Format("{0}\\{1}", GetFilterDirectory(GetParent()), GetName());
            folder = folder.Replace(string.Format("{0}\\", ProjectUtils.GetProjectName()), "");

            return folder;
        }

        public string GetFilterDirectory(Filter parentSub)
        {
            if (parentSub == null)
                return "src";

            return string.Format("{0}\\{1}", GetFilterDirectory(parentSub.GetParent()), parentSub.GetName());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                for (int i = (_subFilters.Count() - 1); i >= 0; i--)
                    _subFilters[i].Dispose();

                _subFilters.Clear();
                _files.Clear();
                _name = null;
            }
        }
    }
}
