namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereSelectTake", "Linq")]
public class WhereSelectTakeLinq : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
