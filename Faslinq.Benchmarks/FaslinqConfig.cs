// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
// ReSharper disable RedundantEnumerableCastCall
namespace Faslinq.Benchmarks;

internal class FaslinqConfig : IConfig
{
    private readonly IConfig _cfg;

    public FaslinqConfig()
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
        yield return new FaslinqExporter();
        yield return MarkdownExporter.GitHub;
        yield return JsonExporter.Full;
        yield return BenchmarkReportExporter.Default;
    }

    public static AccumulationLogger Logger { get; } = new AccumulationLogger();

    public IEnumerable<ILogger> GetLoggers()
    {
        yield return Logger;
        yield return ConsoleLogger.Unicode;
    }

    public IEnumerable<IDiagnoser> GetDiagnosers()
    {
        foreach (var item in _cfg.GetDiagnosers())
        {
            yield return item;
        }

        yield return new MemoryDiagnoser(new());
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

    public class FaslinqExporter : IExporter
    {
        private readonly ConcurrentDictionary<string, object> _groupStats = new();

        private string FindPlatform(BenchmarkCase bm)
        {
            Match match = new Regex(@"\.(\w+_\d+)").Match(bm.DisplayInfo);

            return match.Captures
                       .Cast<Capture>()
                       .LastOrDefault()
                       ?.Value
                       .Trim('.')
                   ?? "";
        }

        // ReSharper disable once UnusedParameter.Local
        private void Export(IGrouping<string, BenchmarkCase> g, Summary summary, ILogger _)
        {
            var baseline = g.FirstOrDefault(bm => bm.Job.Meta.Baseline);
            if (baseline is null)
            {
                throw new ApplicationException($"Cannot find baseline for {g.Key}");
            }

            var baselineStats = summary.Reports
                .Where(br => br.BenchmarkCase.DisplayInfo == baseline.DisplayInfo)
                .Select(
                    br => new
                    {
                        ID = br.BenchmarkCase.DisplayInfo,
                        Group = g.Key,
                        Platform = Filter(baseline),
                        Method = g.Key.Split('_').First(),
                        Size = g.Key.Split('_').Last(),
                        Api = br.BenchmarkCase.DisplayInfo.Split(':').First().Split('_').Last(),
                        IsBaseline = true,
                        Ratio = 1.0,
                        br.ResultStatistics!.Mean,
                        br.ResultStatistics.Median,
                        br.ResultStatistics.Min,
                        br.ResultStatistics.Max,
                        br.ResultStatistics.StandardDeviation,
                        br.GcStats.TotalOperations,
                        BytesAllocatedPerOperation
                            = br.GcStats.GetBytesAllocatedPerOperation(br.BenchmarkCase),
                        Gen0CollectionsCount = br.GcStats.GetCollectionsCount(0),
                        Gen1CollectionsCount = br.GcStats.GetCollectionsCount(1),
                        Gen2CollectionsCount = br.GcStats.GetCollectionsCount(2),
                        //BenchmarkResult = br,
                    }
                )
                .First();

            _groupStats.TryAdd(baselineStats.ID, baselineStats);

            foreach (var bc in g.Where(item => item != baseline))
            {
                var stats = summary.Reports
                    .Where(br => br.BenchmarkCase.DisplayInfo == bc.DisplayInfo)
                    .Select(
                        br => new
                        {
                            ID = br.BenchmarkCase.DisplayInfo,
                            Group = g.Key,
                            Platform = Filter(bc),
                            Method = g.Key.Split('_').First(),
                            Size = g.Key.Split('_').Last(),
                            Api = br.BenchmarkCase.DisplayInfo.Split(':').First().Split('_').Last(),
                            IsBaseline = false,
                            Ratio = br.ResultStatistics!.Mean / baselineStats.Mean,
                            br.ResultStatistics.Mean,
                            br.ResultStatistics.Median,
                            br.ResultStatistics.Min,
                            br.ResultStatistics.Max,
                            br.ResultStatistics.StandardDeviation,
                            br.GcStats.TotalOperations,
                            BytesAllocatedPerOperation
                                = br.GcStats.GetBytesAllocatedPerOperation(br.BenchmarkCase),
                            Gen0CollectionsCount = br.GcStats.GetCollectionsCount(0),
                            Gen1CollectionsCount = br.GcStats.GetCollectionsCount(1),
                            Gen2CollectionsCount = br.GcStats.GetCollectionsCount(2),
                            //BenchmarkResult = br,
                        }
                    )
                    .First();

                _groupStats.TryAdd(stats.ID, stats);
            }
        }


        private static string Filter(BenchmarkCase benchmark)
        {
            var displayInfo = benchmark.DisplayInfo;
            var regex = new Regex(@"Job[^(]*\(([^)]*)");
            var matches = regex.Matches(displayInfo).Cast<Match>().ToList();
            if (!matches.Any()) return "";
            var properties = matches[^1]
                .Captures
                .Cast<Capture>()
                .Last()
                .Value
                .Split(',')
                .Select(item => item.Trim().Split('='));

            var runtime = properties[1][1].Replace("Framework ", "");

            return runtime;
        }

        /// <inheritdoc />
        public void ExportToLog(Summary summary, ILogger logger)
        { }

        /// <inheritdoc />
        public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
        {
            var jsonOptions = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var serializer = JsonSerializer.Create(jsonOptions);
            var groups = summary.BenchmarksCases
                .GroupBy((Func<BenchmarkCase, string>)FindPlatform)
                .ToList();

            foreach (var g in groups)
            {
                Export(g, summary, consoleLogger);
            }

            var name = summary.Title;
            var path = summary.ResultsDirectoryPath;

            var filename = Path.Combine(
                path,
                $"Faslinq-{name}.json"
            );

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            var file = new FileInfo(filename);
            using var streamWriter = file.CreateText();
            using var jsonWriter = new JsonTextWriter(streamWriter);

            var stats = _groupStats
                .OrderBy(pair => ((dynamic)pair.Value).Method)
                .ThenBy(pair => int.Parse(((dynamic)pair.Value).Size))
                .ThenBy(pair => ((dynamic)pair.Value).Api)
                .ThenBy(pair => ((dynamic)pair.Value).Ratio);

            serializer.Serialize(jsonWriter, stats);
            jsonWriter.Flush();
            streamWriter.Close();

            yield return filename;
        }

        /// <inheritdoc />
        public string Name { get; } = nameof(FaslinqExporter);
    }


    public class FaslinqColumnProvider : IColumnProvider
    {
        public readonly string[] Filters = { "counter", "heap", "memory" };
        private IColumn[]? _columns;

        public IEnumerable<IColumn> GetColumns(Summary summary)
        {
            _columns ??= DefaultColumnProviders
                .Instance
                .SelectMany(p => p.GetColumns(summary))
                .ToArray();

            foreach (var col in _columns)
            {
                Logger.WriteLine(col.Id);
            }

            Logger.Flush();

            MemoryDiagnoser.Default.DisplayResults(Logger);

            Logger.Flush();
            var logged = Logger.GetLog();
            Console.WriteLine(logged);

            var heap = _columns.FirstOrDefault(c => c.Id.IndexOf("heapcount", StringComparison.OrdinalIgnoreCase) > -1)
                       ?? _columns.FirstOrDefault(c => c.Id.IndexOf("heap", StringComparison.OrdinalIgnoreCase) > -1);

            if (heap is null)
            {
                throw new ApplicationException("Cannot find HeapCount column.");
            }

            yield return new TagColumn("Use Case", name => $"{GetPart(name, '_', 2)}:{GetPart(name, '_', 0)}");
            yield return new TagColumn("Count", name => GetPart(name, '_', 1));
            yield return LogicalGroupColumn.Default;
            yield return StatisticColumn.Median;
            yield return StatisticColumn.Mean;
            yield return BaselineRatioColumn.RatioMean;
            yield return StatisticColumn.StdDev;
            yield return StatisticColumn.Min;
            yield return StatisticColumn.Max;
            yield return heap;
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
