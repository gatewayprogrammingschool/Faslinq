namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("SelectTake", "Linq")]
public class SelectTakeLinq : SelectTakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
