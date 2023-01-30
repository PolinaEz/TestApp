using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CsvBenchmark
    {
        private static readonly TestApp csv = new TestApp();

        [Benchmark]
        public void Test()
        {
            csv.Test();
        }
    }
}
