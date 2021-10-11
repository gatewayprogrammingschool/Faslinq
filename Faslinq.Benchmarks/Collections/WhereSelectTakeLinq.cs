namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectTakeLinq : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
