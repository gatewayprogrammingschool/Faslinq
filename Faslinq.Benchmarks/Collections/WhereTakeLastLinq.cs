namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereTakeLast", "Linq")]
public class WhereTakeLastLinq : WhereTakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
