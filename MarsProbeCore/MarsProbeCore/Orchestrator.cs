using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    public class Orchestrator
    {
        string _inputFilePath;
        
        public Orchestrator(string inputFilePath)
        {
            _inputFilePath = inputFilePath;            
        }

        public string RunOrchestrator()
        {
            try
            {
                FileUtil fileUtil = fileUtil = new FileUtil(_inputFilePath);
                Grid grid = fileUtil.GetGrid();
                List<Probe> probes = fileUtil.GetProbes();
                Issuer issuer = new Issuer(grid, probes);
                issuer.IssueCommands();
                string outputFilePath = fileUtil.WriteOutputFile(probes);
                return outputFilePath;
            }
            catch { throw; }
        }

        

        private void ProcessInputFile()
        {
            
        }
    }
}
