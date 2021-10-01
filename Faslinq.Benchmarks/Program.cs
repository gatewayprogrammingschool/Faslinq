using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Validators;
using System.Globalization;
using Perfolizer.Horology;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using System.Collections.Immutable;

namespace Faslinq.Tests.Benchmarks;

public class Program
{
    private class Config : ManualConfig
    {
        public Config()
        {
            //AddJob(Job.Dry.WithRuntime(ClrRuntime.Net472));
            //AddJob(Job.Dry.WithRuntime(ClrRuntime.Net48));
            //AddJob(Job.Dry.WithRuntime(CoreRuntime.Core50));
            //AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));
            AddLogger(ConsoleLogger.Unicode);
            AddColumn(new TagColumn("Method", name => GetPart(name, '_', 0)));
            AddColumn(new TagColumn("Size", name => GetPart(name, '_', 1)));
            AddColumn(new TagColumn("API", name => GetPart(name, '_', 2)));
            AddColumn(StatisticColumn.Median, StatisticColumn.Mean, StatisticColumn.StdDev, StatisticColumn.Min, StatisticColumn.Max);
            AddExporter(MarkdownExporter.GitHub, CsvExporter.Default);
            AddAnalyser(EnvironmentAnalyser.Default, MultimodalDistributionAnalyzer.Default);

            Orderer = new FastestToSlowestOrderer();
        }

        internal static string GetPart(string name, char separator, int index)
            => name.Split(separator)[index];

        private class FastestToSlowestOrderer : IOrderer
        {
            public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase) =>
                from benchmark in benchmarksCase
                orderby benchmark.Parameters["X"] descending,
                    benchmark.Descriptor?.WorkloadMethodDisplayInfo
                select benchmark;

            public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) =>
                from benchmark in benchmarksCase
                orderby summary[benchmark]?.ResultStatistics?.Mean
                select benchmark;

            public string GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

            public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) =>
                benchmarkCase?.Job?.DisplayInfo + "_" + benchmarkCase?.Parameters?.DisplayInfo;

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups) =>
                logicalGroups.OrderBy(it => it.Key);

            public bool SeparateLogicalGroups => true;
        }
    }

    public static void Main(string[] args)
    {
        var debugConfig =
            new DebugInProcessConfig()
                .AddColumn(new TagColumn("Method", name => Config.GetPart(name, '_', 0)))
                .AddColumn(new TagColumn("Size", name => Config.GetPart(name, '_', 1)))
                .AddColumn(new TagColumn("API", name => Config.GetPart(name, '_', 2)));

        debugConfig.GetJobs().ToList().ForEach(job =>
        {
            job.RunOncePerIteration();
        });

        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args: args,
#if !DEBUG
                 config: new Config()
                            .KeepBenchmarkFiles()
                            //.WithUnionRule(ConfigUnionRule.Union)
                            //.WithSummaryStyle(new (CultureInfo.CurrentCulture, true, SizeUnit.MB, TimeUnit.Millisecond, true, true, 30, RatioStyle.Percentage))
                            //.AddValidator(ExecutionValidator.FailOnError)
#else
                config: debugConfig
#endif
                );
    }
}
