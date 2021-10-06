namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereTakeLast", "Array")]
public class WhereTakeLastArray : WhereTakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereTakeLast_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereTakeLast_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereTakeLast_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereTakeLast_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
