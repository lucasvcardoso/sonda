using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    class FileUtil
    {
        private string _filePath;

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
            //Implement code to get the Grid height and width from the input file
            return new Grid(0,0);
        }

        public string WriteOutputFile(List<Probe> probesMoved)
        {
            throw new NotImplementedException();
        }

        public List<Probe> GetProbes()
        {
            //TODO
            return new List<Probe>();
        }

    }
}
