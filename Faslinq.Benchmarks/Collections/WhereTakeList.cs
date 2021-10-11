namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereTakeList : WhereTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
