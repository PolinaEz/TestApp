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
                if (line.Split(',')[0] != "GSM")
                {
                    continue;
                }

                records.Add(new Station
                {
                    Mcc = int.Parse(line.Split(',')[1], CultureInfo.InvariantCulture),
                    Mnc = int.Parse(line.Split(',')[2], CultureInfo.InvariantCulture),
                    Lac = int.Parse(line.Split(',')[3], CultureInfo.InvariantCulture),
                    CellId = int.Parse(line.Split(',')[4], CultureInfo.InvariantCulture),                  
                    Long = double.Parse(line.Split(',')[6], CultureInfo.InvariantCulture),
                    Lat = double.Parse(line.Split(',')[7], CultureInfo.InvariantCulture),
                });
            }

            return records;
        }
    }
}
