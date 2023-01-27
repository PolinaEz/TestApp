using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class CsvReader
    {
        private StreamReader streamReader;

        public CsvReader(StreamReader streamReader)
        {
            this.streamReader = streamReader;
        }

        public List<Station> ReadAll()
        {
            string? line;
            List<Station> records = new List<Station>();

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] splittedLine = line.Split(',');
                if (splittedLine[0] != "GSM")
                {
                    continue;
                }

                records.Add(new Station
                {
                    Mcc = int.Parse(splittedLine[1], CultureInfo.InvariantCulture),
                    Mnc = int.Parse(splittedLine[2], CultureInfo.InvariantCulture),
                    Lac = int.Parse(splittedLine[3], CultureInfo.InvariantCulture),
                    CellId = int.Parse(splittedLine[4], CultureInfo.InvariantCulture),                  
                    Long = double.Parse(splittedLine[6], CultureInfo.InvariantCulture),
                    Lat = double.Parse(splittedLine[7], CultureInfo.InvariantCulture),
                });
            }

            return records;
        }
    }
}
