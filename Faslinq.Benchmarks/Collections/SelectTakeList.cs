namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeList : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
