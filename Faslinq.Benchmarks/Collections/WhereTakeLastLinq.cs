namespace Faslinq.Benchmarks.Collections;

public class WhereTakeLastLinq : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
