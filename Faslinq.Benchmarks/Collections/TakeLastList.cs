namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class TakeLastList : TakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("TakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void TakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void TakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void TakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void TakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords100000).Consume(new ());
}
