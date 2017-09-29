using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    public class Position
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public char CardinalPoint { get; set; }

        public Position(int x, int y, char cardinal)
        {
            XAxis = x;
            YAxis = y;
            CardinalPoint = cardinal;
        }
    }
}
