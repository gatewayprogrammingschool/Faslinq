namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereLinq : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Where_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Where_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Where_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Where_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
}
