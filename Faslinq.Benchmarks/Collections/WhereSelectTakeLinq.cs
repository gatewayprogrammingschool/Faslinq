namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeLinq : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void WhereSelectTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void WhereSelectTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void WhereSelectTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void WhereSelectTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
