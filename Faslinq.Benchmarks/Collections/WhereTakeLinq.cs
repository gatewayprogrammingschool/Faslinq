namespace Faslinq.Benchmarks.Collections;

public class WhereTakeLinq : WhereTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTake", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void WhereTake_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void WhereTake_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void WhereTake_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void WhereTake_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
