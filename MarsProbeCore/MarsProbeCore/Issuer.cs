using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    class Issuer
    {
        List<Probe> _probes;
        Grid _grid;

        public Issuer(Grid grid, List<Probe> probes)
        {
            _probes = probes;
            _grid = grid;
        }
        internal void IssueCommands()
        {
            throw new NotImplementedException();
        }
    }
}
