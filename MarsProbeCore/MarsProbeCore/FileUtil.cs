using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    public class FileUtil
    {
        private string _filePath;
        private StreamReader _fileUtilReader;
        private StreamWriter _fileUtilWriter;
        private static Grid? _grid = null;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public FileUtil(string path)
        {
            FilePath = path;
        }

        public Grid GetGrid()
        {
            if (_grid != null)
            {
                return _grid.Value;
            }
            else
            {
                try
                {
                    int[] gridSides = File.ReadLines(FilePath)
                                            .First()
                                            .Split(';')
                                            .Select(
                                                        c => Convert.ToInt32(c)
                                                    )
                                            .ToArray();
                    _grid = new Grid(gridSides[0], gridSides[1]);
                    return _grid.Value;
                }
                catch { throw; }
            }
        }

        public string WriteOutputFile(List<Probe> probesMoved)
        {
            string outFileName = string.Format(@"C:\tmp\ProbesOutput{0}.txt", DateTime.Now.ToString("yyyyMMddHHMMssfff"));
            try
            {
                using (_fileUtilWriter = new StreamWriter(outFileName))
                {
                    _fileUtilWriter.WriteLine("X;Y;Cardinal");
                    foreach (Probe probe in probesMoved)
                    {
                        _fileUtilWriter.WriteLine($"{probe.CurrentPosition.XAxis};{probe.CurrentPosition.YAxis};{probe.CurrentPosition.CardinalPoint}");
                    }
                }
                return outFileName;
            }
            catch { throw; }
        }

        public List<Probe> GetProbesFromInputFile()
        {
            List<Probe> probes = new List<Probe>();
            using (_fileUtilReader = new StreamReader(FilePath))
            {
                _fileUtilReader.ReadLine();
                while (!_fileUtilReader.EndOfStream)
                {
                    string initialPosition = _fileUtilReader.ReadLine();
                    char[] commands = _fileUtilReader.ReadLine().ToCharArray();
                    probes.Add(GetProbe(initialPosition, commands));
                }
            }
            return probes;
        }

        private Probe GetProbe(string initialPosition, char[] commands)
        {
            string[] positionData = initialPosition.Split(';');

            int x = Convert.ToInt32(positionData[0]);
            int y = Convert.ToInt32(positionData[1]);
            char cardinal = Convert.ToChar(positionData[2]);

            Position position = new Position(x, y, cardinal);

            return new Probe(position, GetGrid(), commands);
        }

    }
}
