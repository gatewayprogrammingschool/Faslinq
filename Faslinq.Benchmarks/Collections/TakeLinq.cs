namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("Take", "Linq")]
public class TakeLinq : TakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Take_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Take_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Take_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Take_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
