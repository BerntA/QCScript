//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Handles Loading KeyValues, similar to the way Source Engine handles data.
//
//==================================================================//

using QScript.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace Filesystem
{
    public class KeyValues : IDisposable
    {
        public struct KeyValueItem
        {
            public string key;
            public string value;
        }

        public string GetName() { return _name; }
        public List<KeyValueItem> GetItems() { return _items; }

        bool _bHasParsedFully = false;
        int _iterator = 0;
        string _name = null;
        List<string> _internalData = null;
        List<KeyValueItem> _items = null;
        List<KeyValues> _keys = null;

        public KeyValues()
        {
        }

        public KeyValues(List<string> data)
        {
            _internalData = data;
            Initialize();
        }

        public bool LoadFromFile(string path)
        {
            _internalData = KeyValuesUtils.ReadFileToList(path);
            return LoadData();
        }

        public bool LoadFromStream(string stream)
        {
            _internalData = KeyValuesUtils.ReadStreamToList(stream);
            return LoadData();
        }

        public bool LoadFromUrl(string url)
        {
            return LoadFromStream(KeyValuesUtils.GetUrlStream(url));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public KeyValues FindSubKey(string name)
        {
            if (_bHasParsedFully)
            {
                for (int i = 0; i < _keys.Count; i++)
                {
                    if (_keys[i].GetName() == name)
                        return _keys[i];
                }
            }

            return null;
        }

        public KeyValues GetFirstKey()
        {
            if (_keys.Count <= 0)
                return null;

            _iterator = 0;
            return _keys[0];
        }

        public KeyValues GetNextKey()
        {
            _iterator++;
            if (_iterator >= _keys.Count)
                return null;

            return _keys[_iterator];
        }

        public string GetString(string name, string defaultValue = "")
        {
            string value = FetchValueFromKey(name);
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            return value;
        }

        public bool GetBool(string name)
        {
            try
            {
                return bool.Parse(GetString(name));
            }
            catch
            {
                return false;
            }
        }

        public int GetInt(string name, int defaultValue = 0)
        {
            try
            {
                return int.Parse(GetString(name, defaultValue.ToString()));
            }
            catch
            {
                return defaultValue;
            }
        }

        public float GetFloat(string name, float defaultValue = 0)
        {
            try
            {
                return float.Parse(GetString(name, defaultValue.ToString()));
            }
            catch
            {
                return defaultValue;
            }
        }

        public double GetDouble(string name, double defaultValue = 0)
        {
            try
            {
                return double.Parse(GetString(name, defaultValue.ToString()));
            }
            catch
            {
                return defaultValue;
            }
        }

        public long GetLong(string name, long defaultValue = 0)
        {
            try
            {
                return long.Parse(GetString(name, defaultValue.ToString()));
            }
            catch
            {
                return defaultValue;
            }
        }

        private void Initialize()
        {
            _items = new List<KeyValueItem>();
            _keys = new List<KeyValues>();

            bool bCouldParse = true;
            int indexFirst = GetFirstBracket();
            if (indexFirst != -1)
            {
                _name = GetKeyFromLine(_internalData[indexFirst]);
                _internalData.RemoveRange(indexFirst, 2); // Remove the first key and bracket.

                int indexLast = GetLastBracket(0, true);
                if (indexLast != -1)
                    _internalData.RemoveAt(indexLast); // Remove the last bracket.
                else
                    bCouldParse = false;
            }
            else
                bCouldParse = false;

            if (!bCouldParse)
            {
                LoggingUtils.LogEvent("Unable to parse KeyValues! Fauly brackets...");
                return;
            }

            ParseData();
        }

        private void ParseData()
        {
            // Find the next key to parse:
            int iStart = GetFirstBracket();
            while (iStart != -1)
            {
                List<string> newData = new List<string>();
                int iEnd = GetLastBracket(iStart + 2);

                for (int i = iStart; i < iEnd; i++)
                    newData.Add(_internalData[i]);

                // Remove stuff we no longer need.
                for (int i = (iEnd - 1); i >= iStart; i--)
                    _internalData.RemoveAt(i);

                KeyValues pkvSubKey = new KeyValues(newData);
                _keys.Add(pkvSubKey);

                iStart = GetFirstBracket();
                _bHasParsedFully = true;
            }

            // Parse the rest, which is supposed to be non subkeys:
            for (int i = 0; i < _internalData.Count; i++)
            {
                _bHasParsedFully = true;
                KeyValueItem item;
                item.key = GetKeyFromLine(_internalData[i]);
                item.value = GetValueFromLine(_internalData[i]);
                _items.Add(item);
            }

            // No keys or sub keys were found!!
            if (!_bHasParsedFully)
                LoggingUtils.LogEvent("Unable to parse sub-keys for KeyValues!");
        }

        private bool LoadData()
        {
            if (_internalData == null)
                return false;

            // Remove certain items!
            for (int i = (_internalData.Count - 1); i >= 0; i--)
            {
                if (string.IsNullOrEmpty(_internalData[i]) || string.IsNullOrWhiteSpace(_internalData[i]) ||
                    _internalData[i].StartsWith("/") || (!_internalData[i].Contains("\"") && !_internalData[i].Contains("{") && !_internalData[i].Contains("}")))
                {
                    _internalData.RemoveAt(i);
                    continue;
                }
            }

            Initialize();
            return true;
        }

        private string FetchValueFromKey(string key)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (key == _items[i].key)
                    return _items[i].value;
            }

            return null;
        }

        private int GetFirstBracket()
        {
            for (int i = 0; i < _internalData.Count; i++)
            {
                if (_internalData[i].Contains("{"))
                    return (i - 1);
            }

            return -1;
        }

        private int GetLastBracket(int start = 0, bool bForceEnd = false)
        {
            if (bForceEnd)
            {
                for (int i = (_internalData.Count - 1); i >= 0; i--)
                {
                    if (_internalData[i].Contains("}"))
                    {
                        return i;
                    }
                }

                return -1;
            }

            int passes = 0;
            int index = -1;
            for (int i = start; i < _internalData.Count; i++)
            {
                if (_internalData[i].Contains("{"))
                {
                    passes++;
                    continue;
                }

                if (_internalData[i].Contains("}") && (passes > 0))
                {
                    passes--;
                    continue;
                }

                if (_internalData[i].Contains("}"))
                {
                    index = (i + 1);
                    break;
                }
            }

            if (passes > 0)
                return -1;

            return index;
        }

        private string GetKeyFromLine(string line)
        {
            int iStartIndex = line.IndexOf('"', 0) + 1;
            int iEndIndex = line.IndexOf('"', (iStartIndex + 1));

            return line.Substring(iStartIndex, (iEndIndex - iStartIndex));
        }

        private string GetValueFromLine(string line)
        {
            int quotes = 0;
            int iStartIndex = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                    quotes++;

                if (quotes > 2 && (iStartIndex == 0))
                {
                    iStartIndex = (i + 1);
                }
            }

            if (quotes != 4)
                return null;

            int iEndIndex = line.IndexOf('"', iStartIndex);

            return line.Substring(iStartIndex, (iEndIndex - iStartIndex));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_internalData != null)
                {
                    _internalData.Clear();
                    _internalData = null;
                }

                if (_items != null)
                {
                    _items.Clear();
                    _items = null;
                }

                if (_keys != null)
                {
                    for (int i = 0; i < _keys.Count; i++)
                    {
                        _keys[i].Dispose();
                    }

                    _keys.Clear();
                    _keys = null;
                }

                _bHasParsedFully = false;
                _name = null;
                _iterator = 0;
            }
        }
    }
}
