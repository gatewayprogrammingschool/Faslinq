namespace Faslinq.Benchmarks.Collections;

public class SelectTakeLastList : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void SelectTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void SelectTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void SelectTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void SelectTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated100000).Consume(new ());
}
