using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Serilog;
using SerilogExtensions;

namespace BenchmarkApp
{
    // [ClrJob] gives an error at the moment
    [CoreJob]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, RPlotExporter]
    [MemoryDiagnoser]
    public class HereBenchmark
    {
        private static readonly ILogger Logger = LoggerFactory.Create<HereBenchmark>();

        [Benchmark]
        public int WithHereDebugLevel()
        {
            Logger.Here().Debug("Some Text");
            return 0;
        }

        [Benchmark]
        public int WithDebugLevel()
        {
            Logger.Debug("Some Text");
            return 0;
        }

        [Benchmark]
        public int WithVerboseLevel()
        {
            Logger.Verbose("Some Text");
            return 0;
        }

        [Benchmark]
        public int WithHereVerboseLevel()
        {
            Logger.Here().Debug("Some Text");
            return 0;
        }
    }
}
