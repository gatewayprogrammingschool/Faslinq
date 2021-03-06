namespace Faslinq.Benchmarks.Collections;

public class SelectTakeLastLinq : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void SelectTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void SelectTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void SelectTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void SelectTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated100000).Consume(new ());
}
