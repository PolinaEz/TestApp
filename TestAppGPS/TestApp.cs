using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace TestApp
{
    public class TestApp
    {
        private const string importFile = "257.csv";
        private const string exportFile = "D:\\GSM.csv";

        public void Test()
        {
            try
            {
                using (FileStream fileStream = new FileStream(importFile, FileMode.Open))
                {
                    using (StreamWriter sw = new StreamWriter(exportFile, false))
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        string? line;
                        var format = CultureInfo.CreateSpecificCulture("en-US");

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var lineAsSpan = line.AsSpan();

                            if (!(lineAsSpan[0] == 'G' && lineAsSpan[1] == 'S' && lineAsSpan[2] == 'M'))
                            continue;

                            var index = line.IndexOf(',');
                            if (index == -1)
                                continue;

                            var nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;

                            var mcc = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            index = nextIndex;
                            nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;

                            var mnc = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            index = nextIndex;
                            nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;

                            var lac = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            index = nextIndex;
                            nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;

                            var cellId = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            index = line.IndexOf(',', nextIndex + 1);
                            if (index == -1)
                                continue;

                            nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;
                            var lon = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            index = nextIndex;
                            nextIndex = line.IndexOf(',', index + 1);
                            if (nextIndex == -1)
                                continue;

                            var lat = lineAsSpan.Slice(index + 1, nextIndex - index - 1);

                            sw.WriteLine($"{mcc}, {mnc}, {lac}, {cellId}, {lon}, {lat}");
                        }
                    };
                }
            }
            catch
            {
                Console.WriteLine($"Import or export error.");
                return;
            }
        }
    }
}
