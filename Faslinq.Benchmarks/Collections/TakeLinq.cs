namespace Faslinq.Benchmarks.Collections;

public class TakeLinq : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void Take_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void Take_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void Take_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void Take_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new ());
}
