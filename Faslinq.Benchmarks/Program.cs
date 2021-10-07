using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Extensions;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Faslinq.Benchmarks;

public class Program
{
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
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
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

        var join = aa.FirstOrDefault(a => a.Equals("-Join", StringComparison.CurrentCultureIgnoreCase));
        if (join is not (null or ""))
        {
            aa.Remove(join);
            aa.Add("--join");
        }

#if DEBUG
        if (aa.All(a => !a.Equals("--runonceperiteration", StringComparison.CurrentCultureIgnoreCase)))
        {
            aa.Add("--runOncePerIteration");
        }
#endif

        Console.WriteLine("--------");
        aa.ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine("--------\n");

        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
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
                        args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(take);

                    f.Add("WhereSelectTake");
                    f.Add("WhereTake");
                    f.Add("SelectTake");
                    f.Add("Take");
                }

                if (TakeLast)
                {
                    var takeLast =
                        args.IndexOf(
                            args.FirstOrDefault(
                                a =>
                                    a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                            )
                            ?? ""
                        );
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
                    args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                );
                args.RemoveAt(where);

                var select =
                    args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                args.RemoveAt(select);
                break;
            }
            case (true, false, true, _):
            {
                if (Take)
                {
                    var take = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(take);

                    f.Add("WhereTake");
                    f.Add("Take");
                }

                if (TakeLast)
                {
                    var takeLast =
                        args.IndexOf(
                            args.FirstOrDefault(
                                a =>
                                    a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                            )
                            ?? ""
                        );
                    args.RemoveAt(takeLast);

                    f.Add("WhereTakeLast");
                    f.Add("TakeLast");
                }

                f.Add("Where");

                var where = args.IndexOf(
                    args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                );
                args.RemoveAt(where);
                break;
            }
            case (false, true, true, _):
            {
                if (Take)
                {
                    var take = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(take);

                    f.Add("SelectTake");
                    f.Add("Take");
                }

                if (TakeLast)
                {
                    var takeLastArg = args.FirstOrDefault(
                        a =>
                            a.Equals("-takelast", StringComparison.InvariantCultureIgnoreCase)
                    );
                    var takeLast = args.IndexOf(takeLastArg ?? "");
                    args.RemoveAt(takeLast);

                    f.Add("SelectTakeLast");
                    f.Add("TakeLast");
                }

                f.Add("Select");

                var select =
                    args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                args.RemoveAt(select);
                break;
            }
            case (false, false, true, _):
            {
                if (Take)
                {
                    var take = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(take);

                    f.Add("Take");
                }

                if (TakeLast)
                {
                    var takeLast =
                        args.IndexOf(
                            args.FirstOrDefault(
                                a =>
                                    a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)
                            )
                            ?? ""
                        );
                    args.RemoveAt(takeLast);

                    f.Add("TakeLast");
                }

                break;
            }

            case (true, true, false, _):
            {
                var where = args.IndexOf(
                    args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                );
                args.RemoveAt(where);

                var select =
                    args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                args.RemoveAt(select);

                f.Add("WhereSelect");
                f.Add("Where");
                f.Add("Select");

                break;
            }

            case (true, false, false, _):
            {
                var where = args.IndexOf(
                    args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? ""
                );
                args.RemoveAt(where);

                f.Add("Where");
                break;
            }

            case (false, true, false, _):
            {
                var select =
                    args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                args.RemoveAt(select);

                f.Add("Select");
                break;
            }
        }

        switch (match)
        {
            case (_, _, _, true):
            {
                if (FirstWhere)
                {
                    var firstWhere =
                        args.IndexOf(
                            args.FirstOrDefault(
                                a =>
                                    a.Equals("-firstwhere", StringComparison.OrdinalIgnoreCase)
                            )
                            ?? ""
                        );
                    args.RemoveAt(firstWhere);

                    f.Add("FirstWhere");
                }

                if (First)
                {
                    var first = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-first", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(first);

                    f.Add("First");
                }

                if (LastWhere)
                {
                    var lastWhere =
                        args.IndexOf(
                            args.FirstOrDefault(a => a.Equals("-lastwhere", StringComparison.OrdinalIgnoreCase)) ?? ""
                        );
                    args.RemoveAt(lastWhere);

                    f.Add("LastWhere");
                }

                if (Last)
                {
                    var last = args.IndexOf(
                        args.FirstOrDefault(a => a.Equals("-last", StringComparison.OrdinalIgnoreCase)) ?? ""
                    );
                    args.RemoveAt(last);

                    f.Add("Last");
                }

                break;
            }
        }

        if (f.Count <= 0)
        {
            return filters;
        }

        foreach (var fil in f)
        {
            filters.Add($".{fil}_");
        }

        return filters;
    }

    private class Config : IConfig
    {
        private readonly IConfig _cfg;

        public Config()
        {
            _cfg =
#if DEBUG
                new DebugBuildConfig();
#else
                ManualConfig.CreateMinimumViable();
#endif
        }

        public IOrderer Orderer
            => _cfg.Orderer;

        public SummaryStyle SummaryStyle
            => _cfg.SummaryStyle;

        public ConfigUnionRule UnionRule
            => _cfg.UnionRule;

        public string ArtifactsPath
            => _cfg.ArtifactsPath;

        public CultureInfo CultureInfo
            => _cfg.CultureInfo;

        public ConfigOptions Options
            => ConfigOptions.StopOnFirstError;

        public IEnumerable<Job> GetJobs()
        {
#if !DEBUG
            yield return new Job(
                Job.Default.WithRuntime(ClrRuntime.Net472)
                    .WithBaseline(false)
            );
            yield return new Job(
                Job.Default.WithRuntime(ClrRuntime.Net48)
                    .WithBaseline(false)
            );
            yield return new Job(
                Job.Default.WithRuntime(CoreRuntime.Core50)
                    .WithBaseline(false)
            );
            yield return new Job(
                Job.Default.WithRuntime(CoreRuntime.Core60)
                    .WithBaseline(true)
            );
#else
            yield return new Job(Job.Dry.WithRuntime(ClrRuntime.Net48).WithBaseline(false));
            yield return new Job(Job.Dry.WithRuntime(CoreRuntime.Core60).WithBaseline(true));
#endif
        }

        public IEnumerable<IColumnProvider> GetColumnProviders()
        {
            yield return new FaslinqColumnProvider();
        }

        public IEnumerable<IExporter> GetExporters()
        {
            yield return MarkdownExporter.GitHub;
            yield return JsonExporter.Full;
        }

        public IEnumerable<ILogger> GetLoggers()
        {
            yield return ConsoleLogger.Unicode;
        }

        public IEnumerable<IDiagnoser> GetDiagnosers()
        {
            foreach (var item in _cfg.GetDiagnosers())
            {
                yield return item;
            }

            yield return new MemoryDiagnoser(new (true));
        }

        public IEnumerable<IAnalyser> GetAnalysers()
            => _cfg.GetAnalysers();

        public IEnumerable<IValidator> GetValidators()
            => _cfg.GetValidators();

        public IEnumerable<HardwareCounter> GetHardwareCounters()
            => _cfg.GetHardwareCounters();

        public IEnumerable<IFilter> GetFilters()
            => _cfg.GetFilters();

        public IEnumerable<BenchmarkLogicalGroupRule> GetLogicalGroupRules()
        {
            yield return BenchmarkLogicalGroupRule.ByCategory;
        }

        internal static string GetPart(string name, char separator, int index)
            => name.Split(separator)[index];

        public class FaslinqOrderer : IOrderer
        {
            public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase)
                => benchmarksCase.OrderBy(benchmark => benchmark.Descriptor.Categories.ElementAtOrDefault(0))
                    .ThenBy(benchmark => int.Parse(benchmark.Descriptor.Categories.ElementAtOrDefault(1) ?? "0"));
                    //.ThenBy(benchmark => int.TryParse(GetPart(benchmark.Descriptor?.WorkloadMethodDisplayInfo ?? "a_0_b", '_', 1), out int value) ? value : throw new ApplicationException($"Cannot parse {GetPart(benchmark.Descriptor?.WorkloadMethodDisplayInfo ?? "a_0_b", '_', 1)} to int."));

            public IEnumerable<BenchmarkCase> GetSummaryOrder(
                ImmutableArray<BenchmarkCase> benchmarksCase,
                Summary summary
            )
                => benchmarksCase.OrderBy(benchmark => benchmark.Descriptor.Categories.ElementAtOrDefault(0))
                    .ThenBy(benchmark => int.Parse(benchmark.Descriptor.Categories.ElementAtOrDefault(1) ?? "0"))
                    .ThenBy(benchmark => summary[benchmark].ResultStatistics.Mean);

            public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase)
                => null;

            public string GetLogicalGroupKey(
                ImmutableArray<BenchmarkCase> allBenchmarksCases,
                BenchmarkCase benchmark
            )
                => $"{benchmark.Descriptor.Categories[0]}"
                   + $":{int.Parse(benchmark.Descriptor.Categories[1]):000000}";
                   //+ $"_{GetPart(benchmark.Descriptor?.WorkloadMethodDisplayInfo ?? "a_0_b", '_', 1)}";

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(
                IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups
            )
                => logicalGroups.OrderBy(group => group.Key);

            public bool SeparateLogicalGroups
                => true;
        }

        public class FaslinqColumnProvider : IColumnProvider
        {
            public IEnumerable<IColumn> GetColumns(Summary summary)
            {
                yield return new TagColumn("Use Case", name => $"{GetPart(name, '_', 2)}:{GetPart(name, '_', 0)}");
                yield return new TagColumn("Count", name => GetPart(name, '_', 1));
                yield return LogicalGroupColumn.Default;
                yield return StatisticColumn.Median;
                yield return StatisticColumn.Mean;
                yield return BaselineRatioColumn.RatioMean;
                yield return StatisticColumn.StdDev;
                yield return StatisticColumn.Min;
                yield return StatisticColumn.Max;
                var metric = summary.Reports[0]
                    .Metrics.Values.FirstOrDefault();
                yield return new MetricColumn(metric?.Descriptor);
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
}
