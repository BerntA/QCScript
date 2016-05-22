//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Parses a Valve Studio Model Data file. 
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QScript.Filesystem
{
    public sealed class SMDParser
    {
        public int GetNumberOfFrames { get { return _animationData.Count(); } }

        private List<string> _animationData;
        private string _smdPath;
        private string _smdContent;
        private int _startFrameNum;
        private bool _bHasParsedSuccessfully;
        public SMDParser(string path)
        {
            _smdPath = path;
            _animationData = new List<string>();
        }

        public bool ParseSMDFile()
        {
            _bHasParsedSuccessfully = false;
            _startFrameNum = -1;
            _smdContent = null;
            _animationData.Clear();

            if (!File.Exists(_smdPath))
                return false;

            FileInfo info = new FileInfo(_smdPath);
            if (info.Extension != ".smd")
                return false;

            _smdContent = File.ReadAllText(_smdPath);

            using (StreamReader reader = new StreamReader(_smdPath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Add this animation block to the anim data list.
                    if (line.Contains("time "))
                    {
                        int indexOfBlock = _smdContent.IndexOf(line) + line.Length;
                        int indexOfTime = line.IndexOf("time ");
                        string nextFrame = string.Format("time {0}", ((int.Parse(line.Substring(indexOfTime + 5))) + 1));
                        int indexOfNextBlock = _smdContent.IndexOf(nextFrame);
                        if (indexOfNextBlock == -1)
                            indexOfNextBlock = _smdContent.IndexOf("end", indexOfBlock);

                        if (indexOfNextBlock != -1)
                        {
                            string animData = _smdContent.Substring(indexOfBlock, (indexOfNextBlock - indexOfBlock));
                            _animationData.Add(animData);
                        }

                        if (_startFrameNum == -1)
                            _startFrameNum = int.Parse(line.Substring(indexOfTime + 5));
                    }
                }
            }

            _bHasParsedSuccessfully = true;
            return true;
        }

        public void ReverseAnimation(string outputFile)
        {
            if (!_bHasParsedSuccessfully)
                return;

            string content = _smdContent.Substring(0, (_smdContent.IndexOf("time ", StringComparison.CurrentCulture)));
            int frame = _startFrameNum;
            for (int i = (_animationData.Count() - 1); i >= 0; i--)
            {
                content += GetAnimationBlockForData(_animationData[i], frame);
                frame++;
            }

            content += "end" + Environment.NewLine;

            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
            File.WriteAllText(outputFile, content, Encoding.ASCII);
        }

        private string GetAnimationBlockForData(string data, int frame)
        {
            return string.Format(
                "time {0}{1}",
                frame, data
                );
        }
    }
}
