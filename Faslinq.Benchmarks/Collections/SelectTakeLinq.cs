namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeLinq : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
