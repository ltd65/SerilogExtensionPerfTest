using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Serilog;
using SerilogExtensions;

namespace BenchmarkApp
{
    [ClrJob]
    [CoreJob]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, RPlotExporter]
    [MemoryDiagnoser]
    public class HereBenchmark
    {
        private static readonly ILogger Logger = LoggerFactory.Create<HereBenchmark>();

        [Benchmark]
        public int WithHereDebugLevel()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Here().Debug("Some Text {Value}", i);
            }
            return 0;
        }

        [Benchmark]
        public int WithHereDebugLevelcsharpstring()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Here().Debug($"Some Text {i}");
            }
            return 0;
        }

        [Benchmark]
        public int WithDebugLevel()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Debug("Some Text {Value}", i);
            }
            return 0;
        }

        [Benchmark]
        public int WithDebugLevelcsharpstring()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Debug($"Some Text {i}");
            }
            return 0;
        }

        [Benchmark]
        public int WithVerboseLevel()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Verbose("Some Text {Value}", i);
            }
            return 0;
        }

        [Benchmark]
        public int WithVerboseLevelcsharpstring()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Verbose($"Some Text {i}");
            }
            return 0;
        }

        [Benchmark]
        public int WithHereVerboseLevel()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Here().Verbose("Some Text {Value}", i);
            }
            return 0;
        }

        [Benchmark]
        public int WithHereVerboseLevelcsharpstring()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Here().Verbose($"Some Text {i}");
            }
            return 0;
        }
    }
}
