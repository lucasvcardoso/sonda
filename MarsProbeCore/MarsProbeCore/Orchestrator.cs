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
                List<Probe> probes = fileUtil.GetProbesFromInputFile();
                probes.ForEach(p => p.RunCommands());
                string outputFilePath = fileUtil.WriteOutputFile(probes);
                return outputFilePath;
            }
            catch { throw; }
        }               
    }
}
