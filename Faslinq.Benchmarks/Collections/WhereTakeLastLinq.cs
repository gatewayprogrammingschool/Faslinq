namespace Faslinq.Benchmarks.Collections;

public class WhereTakeLastLinq : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void WhereTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void WhereTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void WhereTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void WhereTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated100000).Consume(new ());
}
