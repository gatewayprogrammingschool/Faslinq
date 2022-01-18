namespace Faslinq.Benchmarks.Collections;

public class SelectTakeList : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void SelectTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void SelectTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void SelectTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void SelectTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
