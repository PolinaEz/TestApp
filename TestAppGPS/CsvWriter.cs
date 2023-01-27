﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace TestApp
{
    internal class CsvWriter
    {
        private StreamWriter writer;

        public CsvWriter(StreamWriter writer)
        {
            this.writer = writer;
        }

        public void Write(List<Station> stations)
        {
            var format = CultureInfo.CreateSpecificCulture("en-US");
            
            foreach (Station station in stations)
            {
                this.writer.WriteLine($"{station.Mcc},{station.Mnc},{station.Lac},{station.CellId},{station.Long.ToString(format)},{station.Lat.ToString(format)}");
            }
        }
    }
}
