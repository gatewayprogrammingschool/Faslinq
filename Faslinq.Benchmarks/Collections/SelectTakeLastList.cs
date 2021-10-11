namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeLastList : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords100000).Consume(new ());
}
