using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Serilog;
using Serilog.Events;
using SerilogExtensions;

namespace BenchmarkApp
{
    [ClrJob]
    [CoreJob]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter]//, RPlotExporter]
    [MemoryDiagnoser]
    public class HereBenchmark
    {
        private static readonly ILogger Logger = LoggerFactory.Create<HereBenchmark>();

        [Benchmark]
        public int WithHereDebugLevel()
        {
            Logger.Here().Debug("Some Text {Value}", 2);
            return 0;
        }

        [Benchmark]
        public int WithDebugLevel()
        {
            Logger.Debug("Some Text {Value}", 2);
            return 0;
        }


        [Benchmark]
        public int WithHereVerboseLevel()
        {
            Logger.Here().Verbose("Some Text {Value}", 2);
            return 0;
        }

        [Benchmark]
        public int WithHereLvlDebugLevel()
        {
            Logger.HereLvl(LogEventLevel.Debug).Debug("Some Text {Value}", 2);
            return 0;
        }


        [Benchmark]
        public int WithHereLvlVerboseLevel()
        {
            Logger.HereLvl().Verbose("Some Text {Value}", 2);
            return 0;
        }
    }
}
