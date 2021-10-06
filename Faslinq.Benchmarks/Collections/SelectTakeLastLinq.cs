namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("SelectTakeLast", "Linq")]
public class SelectTakeLastLinq : SelectTakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
