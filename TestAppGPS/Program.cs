using BenchmarkDotNet.Running;
using System;

namespace TestApp
{
    public static class Program
    {
        static void Main()
        {
            TestApp test = new();
            test.Test();
        }
    }
}