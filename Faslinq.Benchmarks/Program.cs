using BenchmarkDotNet.Order;

namespace Faslinq.Benchmarks;

public class Program
{
    private class Config :
#if DEBUG
        DebugConfig
#else
        ManualConfig
#endif
    {
        public Config()
        {
        }

        internal static string GetPart(string name, char separator, int index)
            => name.Split(separator)[index];

        public override IEnumerable<Job> GetJobs()
        {
            yield return new Job(Job.Dry.WithRuntime(ClrRuntime.Net48));
            yield return new Job(Job.Dry.WithRuntime(CoreRuntime.Core60));
        }

        public class FastestToSlowestOrderer : IOrderer
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

            public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

            public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) =>
                benchmarkCase?.Job?.DisplayInfo + "_" + benchmarkCase?.Parameters?.DisplayInfo;

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups) =>
                logicalGroups.OrderBy(it => it.Key);

            public bool SeparateLogicalGroups => true;
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
#if DEBUG
            new Config()
                //AddJob(Job.Dry.WithRuntime(ClrRuntime.Net472));
                //.AddJob(Job.Dry.WithRuntime(ClrRuntime.Net48))
                //AddJob(Job.Dry.WithRuntime(CoreRuntime.Core50));
                //.AddJob(Job.Dry.WithRuntime(CoreRuntime.Core60))
                .AddColumn(new TagColumn("Method", name => Config.GetPart(name, '_', 0)))
                .AddColumn(new TagColumn("Size", name => Config.GetPart(name, '_', 1)))
                .AddColumn(new TagColumn("API", name => Config.GetPart(name, '_', 2)))
                .AddColumn(StatisticColumn.Median, StatisticColumn.Mean, StatisticColumn.StdDev, StatisticColumn.Min, StatisticColumn.Max)
                .AddLogger(ConsoleLogger.Unicode)
                .WithOrderer(new Config.FastestToSlowestOrderer())
        //AddExporter(MarkdownExporter.GitHub, CsvExporter.Default);
        //AddAnalyser(EnvironmentAnalyser.Default, MultimodalDistributionAnalyzer.Default);

#else
            new Config()
                //AddJob(Job.Dry.WithRuntime(ClrRuntime.Net472));
                .AddJob(Job.Dry.WithRuntime(ClrRuntime.Net48))
                //AddJob(Job.Dry.WithRuntime(CoreRuntime.Core50));
                .AddJob(Job.Dry.WithRuntime(CoreRuntime.Core60))
                .KeepBenchmarkFiles()
                .WithOptions(ConfigOptions.StopOnFirstError)
                //.WithUnionRule(ConfigUnionRule.Union)
                //.WithSummaryStyle(new (CultureInfo.CurrentCulture, true, SizeUnit.MB, TimeUnit.Millisecond, true, true, 30, RatioStyle.Percentage))
                //.AddValidator(ExecutionValidator.FailOnError)
#endif

        ;

        config.GetJobs().ToList().ForEach(job =>
        {
            Job newJob = new(Job.Default.WithRuntime(ClrRuntime.Net48));
            config.AddJob(newJob);
        });

        var counter = 1;
        foreach (var filter in filters)
        {
            if (aa.All(a => a.ToLower() != "--filter"))
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
        if (aa.All(a => a.ToLower() != "--runonceperiteration"))
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

        List<string> filters = new();
        List<string> f = new();
        if (Where && Select && (Take || TakeLast))
        {
            if (Take)
            {
                var take = args.IndexOf(args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(take);

                f.Add("WhereSelectTake");
                f.Add("WhereTake");
                f.Add("SelectTake");
                f.Add("Take");
            }

            if (TakeLast)
            {
                var takeLast = args.IndexOf(args.FirstOrDefault(a => a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(takeLast);

                f.Add("WhereSelectTakeLast");
                f.Add("WhereTakeLast");
                f.Add("SelectTakeLast");
                f.Add("TakeLast");
            }

            var where = args.IndexOf(args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
            args.RemoveAt(where);

            var select = args.IndexOf(args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
            args.RemoveAt(select);
        }
        else if (Where && (!Select) && (Take || TakeLast))
        {
            if (Take)
            {
                var take = args.IndexOf(args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(take);

                f.Add("WhereTake");
                f.Add("Take");
            }

            if (TakeLast)
            {
                var takeLast = args.IndexOf(args.FirstOrDefault(a => a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(takeLast);

                f.Add("WhereTakeLast");
                f.Add("TakeLast");
            }

            f.Add("Where");

            var where = args.IndexOf(args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
            args.RemoveAt(where);
        }
        else if ((!Where) && Select && (Take || TakeLast))
        {
            if (Take)
            {
                var take = args.IndexOf(args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(take);

                f.Add("SelectTake");
                f.Add("Take");
            }

            if (TakeLast)
            {
                var takeLastArg = args.FirstOrDefault(a => a.Equals("-takelast", StringComparison.InvariantCultureIgnoreCase));
                var takeLast = args.IndexOf(takeLastArg);
                args.RemoveAt(takeLast);

                f.Add("SelectTakeLast");
                f.Add("TakeLast");
            }

            f.Add("Select");

            var select = args.IndexOf(args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
            args.RemoveAt(select);
        }
        else if ((!Where) && (!Select) && (Take || TakeLast))
        {
            if (Take)
            {
                var take = args.IndexOf(args.FirstOrDefault(a => a.Equals("-take", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(take);

                f.Add("Take");
            }

            if (TakeLast)
            {
                var takeLast = args.IndexOf(args.FirstOrDefault(a => a.Equals("-takelast", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(takeLast);

                f.Add("TakeLast");
            }
        }

        if ((!Take) && (!TakeLast))
        {
            if (Where && Select)
            {
                var where = args.IndexOf(args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(where);

                var select = args.IndexOf(args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(select);

                f.Add("WhereSelect");
                f.Add("Where");
                f.Add("Select");
            }
            else if (Where)
            {
                var where = args.IndexOf(args.FirstOrDefault(a => a.Equals("-where", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(where);

                f.Add("Where");
            }
            else if (Select)
            {
                var select = args.IndexOf(args.FirstOrDefault(a => a.Equals("-select", StringComparison.OrdinalIgnoreCase)) ?? "");
                args.RemoveAt(select);

                f.Add("Select");
            }
        }

        if (f.Count > 0)
        {
            foreach (var fil in f)
            {
                filters.Add($".{fil}_");
            }
        }

        return filters;
    }
}
