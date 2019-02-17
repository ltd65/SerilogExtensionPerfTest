using System;
using BenchmarkDotNet.Running;

namespace BenchmarkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HereBenchmark>();
        }
    }
}
