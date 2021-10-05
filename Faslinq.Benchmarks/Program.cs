using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace Faslinq.Benchmarks;

public class Program
{
    private class Config : IConfig
    {
        private IConfig _cfg;
        public IOrderer Orderer => _cfg.Orderer;
        public SummaryStyle SummaryStyle => _cfg.SummaryStyle;
        public ConfigUnionRule UnionRule => _cfg.UnionRule;
        public string ArtifactsPath => _cfg.ArtifactsPath;
        public CultureInfo CultureInfo => _cfg.CultureInfo;
        public ConfigOptions Options => ConfigOptions.StopOnFirstError;

        public Config()
        {
            _cfg =
#if DEBUG
                new DebugBuildConfig();
#else
                ManualConfig.CreateMinimumViable();
#endif
        }

        internal static string GetPart(string name, char separator, int index)
            => name.Split(separator)[index];

        public IEnumerable<Job> GetJobs()
        {
#if DEBUG
            yield return new Job(Job.Dry.WithRuntime(ClrRuntime.Net48).WithBaseline(true));
            yield return new Job(Job.Dry.WithRuntime(CoreRuntime.Core60).WithBaseline(false));
#else
            yield return new Job(Job.Default.WithRuntime(ClrRuntime.Net48).WithBaseline(true));
            yield return new Job(Job.Default.WithRuntime(CoreRuntime.Core60).WithBaseline(false));
#endif
        }

        public IEnumerable<IColumnProvider> GetColumnProviders()
        {
            yield return new FaslinqColumnProvider();
        }

        public IEnumerable<IExporter> GetExporters()
        {
            yield return MarkdownExporter.GitHub;
        }

        public IEnumerable<ILogger> GetLoggers()
        {
            yield return ConsoleLogger.Unicode;
        }

        public IEnumerable<IDiagnoser> GetDiagnosers()
        {
            return _cfg.GetDiagnosers();
        }

        public IEnumerable<IAnalyser> GetAnalysers()
        {
            return _cfg.GetAnalysers();
        }

        public IEnumerable<IValidator> GetValidators()
        {
            return _cfg.GetValidators();
        }

        public IEnumerable<HardwareCounter> GetHardwareCounters()
        {
            return _cfg.GetHardwareCounters();
        }

        public IEnumerable<IFilter> GetFilters()
        {
            return _cfg.GetFilters();
        }

        public IEnumerable<BenchmarkLogicalGroupRule> GetLogicalGroupRules()
        {
            yield return BenchmarkLogicalGroupRule.ByMethod;
        }

        public class FaslinqOrderer : IOrderer
        {
            public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase) =>
                from benchmark in benchmarksCase
                orderby benchmark.Parameters["X"] descending,
                    benchmark.Descriptor?.WorkloadMethodDisplayInfo
                        .Substring(0, (benchmark.Descriptor?.WorkloadMethodDisplayInfo.LastIndexOf("_") ?? 0))
                select benchmark;

            public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) =>
                from benchmark in benchmarksCase
                orderby benchmark.Descriptor?.WorkloadMethodDisplayInfo
                        .Substring(0, (benchmark.Descriptor?.WorkloadMethodDisplayInfo.LastIndexOf("_") ?? 0)),
                    summary[benchmark]?.ResultStatistics?.Mean
                select benchmark;

            public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

            public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) =>
                //benchmarkCase?.Job?.DisplayInfo + "_" + benchmarkCase?.Parameters?.DisplayInfo;
                benchmarkCase?.Descriptor?.WorkloadMethodDisplayInfo
                        .Substring(0, (benchmarkCase?.Descriptor?.WorkloadMethodDisplayInfo.LastIndexOf("_") ?? 0)) ?? "";

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups) =>
                logicalGroups.OrderBy(it => it.Key);

            public bool SeparateLogicalGroups => true;
        }

        public class FaslinqColumnProvider : IColumnProvider
        {
            public IEnumerable<IColumn> GetColumns(Summary summary)
            {
                //yield return new TagColumn("Method", name => Config.GetPart(name, '_', 0));
                //yield return new TagColumn("Size", name => Config.GetPart(name, '_', 1));
                yield return LogicalGroupColumn.Default;
                yield return new TagColumn("API", name => Config.GetPart(name, '_', 2));
                yield return StatisticColumn.Median;
                yield return StatisticColumn.Mean;
                yield return BaselineRatioColumn.RatioMean;
                yield return StatisticColumn.StdDev;
                yield return StatisticColumn.Min;
                yield return StatisticColumn.Max;
                var names = JobCharacteristicColumn.AllColumns.Select(c => c.ColumnName);
                foreach (var col in JobCharacteristicColumn.AllColumns)
                {
                    if (col.ColumnName is "Platform" or "BuildConfiguration" or "Runtime")
                    {
                        yield return col;
                    }
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        args = args.ToList()
                    .SelectMany(ab => ab.Split(' '))
                    .ToArray();

        Console.WriteLine($"{args.Length}");
        Console.WriteLine($"{string.Join(", ", args)}");
        Console.WriteLine("---\n");

        List<string> aa = new(args);

        var filters = ProcessFilters(aa);

        var config =
            new Config()
                .KeepBenchmarkFiles()
                .WithOrderer(new Config.FaslinqOrderer())
        ;

        var counter = 1;
        foreach (var filter in filters)
        {
            if (!aa.Any(a => a.Equals("--filter", StringComparison.CurrentCultureIgnoreCase)))
            {
                aa.Insert(0, "--filter");
            }

            if (counter < aa.Count)
            {
                aa.Insert(counter++, $"*{filter}*");
            }
            else
            {
                aa.Add($"*{filter}*");
            }
        }

#if DEBUG
        if (aa.All(a => !a.Equals("--runonceperiteration", StringComparison.CurrentCultureIgnoreCase)))
        {
            aa.Add("--runOncePerIteration");
        }
#endif

        Console.WriteLine("--------");
        aa.ToList().ForEach(Console.WriteLine);
        Console.WriteLine("--------\n");

        BenchmarkSwitcher
            .FromAssembly(typeof(Faslinq.Benchmarks.Program).Assembly)
            .Run(aa.ToArray(), config);
    }

    private static List<string> ProcessFilters(List<string> args)
    {
        var Where = args.Any(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase));
        var Select = args.Any(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase));
        var Take = args.Any(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase));
        var TakeLast = args.Any(a => a.Equals("-takelast", StringComparison.OrdinalIgnoreCase));
        var First = args.Any(a => a.Equals("-first", StringComparison.OrdinalIgnoreCase));
        var FirstWhere = args.Any(a => a.Equals("-firstwhere", StringComparison.OrdinalIgnoreCase));
        var Last = args.Any(a => a.Equals("-last", StringComparison.OrdinalIgnoreCase));
        var LastWhere = args.Any(a => a.Equals("-lastwhere", StringComparison.OrdinalIgnoreCase));

        List<string> filters = new();
        List<string> f = new();

        var match = (Where, Select, Take || TakeLast, FirstWhere || First || LastWhere || Last);

        switch (match)
        {
            case (true, true, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(take);

                        f.Add("WhereSelectTake");
                        f.Add("WhereTake");
                        f.Add("SelectTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(args.FirstOrDefault(a =>
                                a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(takeLast);

                        f.Add("WhereSelectTakeLast");
                        f.Add("WhereTakeLast");
                        f.Add("SelectTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("WhereSelect");
                    f.Add("Where");
                    f.Add("Select");

                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(@where);

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(@select);
                    break;
                }
            case (true, false, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(take);

                        f.Add("WhereTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(args.FirstOrDefault(a =>
                                a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(takeLast);

                        f.Add("WhereTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("Where");

                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(@where);
                    break;
                }
            case (false, true, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(take);

                        f.Add("SelectTake");
                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLastArg = args.FirstOrDefault(a =>
                            a.Equals("-takelast", StringComparison.InvariantCultureIgnoreCase));
                        var takeLast = args.IndexOf(takeLastArg ?? "");
                        args.RemoveAt(takeLast);

                        f.Add("SelectTakeLast");
                        f.Add("TakeLast");
                    }

                    f.Add("Select");

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(@select);
                    break;
                }
            case (false, false, true, _):
                {
                    if (Take)
                    {
                        var take = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(take);

                        f.Add("Take");
                    }

                    if (TakeLast)
                    {
                        var takeLast =
                            args.IndexOf(args.FirstOrDefault(a =>
                                a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(takeLast);

                        f.Add("TakeLast");
                    }

                    break;
                }

            case (true, true, false, _):
                {
                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(where);

                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(select);

                    f.Add("WhereSelect");
                    f.Add("Where");
                    f.Add("Select");

                    break;
                }

            case (true, false, false, _):
                {
                    var where = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(where);

                    f.Add("Where");
                    break;
                }

            case (false, true, false, _):
                {
                    var select =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                    args.RemoveAt(select);

                    f.Add("Select");
                    break;
                }

            case (_, _, _, true):
                {
                    if (FirstWhere)
                    {
                        var firstWhere =
                            args.IndexOf(args.FirstOrDefault(a =>
                                a.Equals("-firstwhere", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(firstWhere);

                        f.Add("FirstWhere");
                    }

                    if (First)
                    {
                        var first = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-first", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(first);

                        f.Add("First");
                    }

                    if (LastWhere)
                    {
                        var lastWhere =
                            args.IndexOf(
                                args.FirstOrDefault(a => a.Equals("-lastwhere", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(lastWhere);

                        f.Add("LastWhere");
                    }

                    if (Last)
                    {
                        var last = args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-last", StringComparison.OrdinalIgnoreCase)) ?? "");
                        args.RemoveAt(last);

                        f.Add("Last");
                    }
                    break;
                }
        }

        if (f.Count <= 0) return filters;

        foreach (var fil in f)
        {
            filters.Add($".{fil}_");
        }

        return filters;
    }
}
