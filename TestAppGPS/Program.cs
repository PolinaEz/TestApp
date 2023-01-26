using System;

namespace TestApp
{
    public static class Program
    {
        private static List<Station> list = new();

        private const string importFile = "257.csv";
        private const string exportFile = "GSM.csv";

        public static void Main(string[] args)
        {
            Program.Import(importFile);
            Program.Export(exportFile);
        }

        private static void Import(string command)
        {
            try
            {
                using (FileStream fileStream = new FileStream(command, FileMode.Open))
                {
                    CsvReader reader = new CsvReader(new StreamReader(fileStream));
                    list = new List<Station>(reader.ReadAll());
                }
            }
            catch
            {
                Console.WriteLine($"Import error: file {command} is not exist.");
                return;
            }
        }

        private static void Export(string command)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(command, false))
                {
                    CsvWriter writer = new CsvWriter(sw);
                    writer.Write(list);
                };
            }
            catch
            {
                Console.WriteLine($"Export failed: can't open file {command}");
                return;
            }
        }
    }
}