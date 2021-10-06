namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("TakeLast", "Array")]
public class TakeLastArray : TakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void TakeLast_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void TakeLast_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void TakeLast_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void TakeLast_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
