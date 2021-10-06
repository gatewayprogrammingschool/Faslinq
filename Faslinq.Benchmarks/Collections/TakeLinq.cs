namespace Faslinq.Benchmarks.Collections;

public class TakeLinq : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Take_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Take_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Take_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Take_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
