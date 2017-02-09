using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDSimulServer
{
    class ObsRun
    {
        private string dir = "";
        private string name = "";
        private int numExps = 0;
        private double expLen = 0.0;

        public string filePath { get; set; }
        public int numExpsRemaining { get; set; }

        public ObsRun(string dir, string name, int numExps, double expLen)
        {
            this.dir = dir;
            this.name = name;
            this.numExps = numExps;
            this.expLen = expLen;

            filePath = dir + name;
            numExpsRemaining = 4 * numExps; // 4 half-wave-plate angles
        }


    }
}
