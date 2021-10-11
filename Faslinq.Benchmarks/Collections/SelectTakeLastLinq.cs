namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeLastLinq : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
