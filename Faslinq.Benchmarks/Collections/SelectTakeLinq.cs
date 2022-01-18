namespace Faslinq.Benchmarks.Collections;

public class SelectTakeLinq : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void SelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void SelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void SelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void SelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
