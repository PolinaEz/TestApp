using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class Station
    {
        public int Mcc { get; set; }

        public int Mnc { get; set; }

        public int Lac { get; set; }

        public int CellId { get; set; }

        public double Long { get; set; }

        public double Lat { get; set; }
    }
}
