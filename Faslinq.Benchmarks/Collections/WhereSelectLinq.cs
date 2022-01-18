namespace Faslinq.Benchmarks.Collections;

public class WhereSelectLinq : WhereSelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelect", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void WhereSelect_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void WhereSelect_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void WhereSelect_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void WhereSelect_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
