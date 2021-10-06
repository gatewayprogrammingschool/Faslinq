namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("TakeLast", "Linq")]
public class TakeLastLinq : TakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void TakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void TakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void TakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void TakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
