namespace Faslinq.Benchmarks.Collections;

public class WhereLinq : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void Where_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void Where_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void Where_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void Where_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
