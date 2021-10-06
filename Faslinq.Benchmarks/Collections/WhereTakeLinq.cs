namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereTake", "Linq")]
public class WhereTakeLinq : WhereTakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
