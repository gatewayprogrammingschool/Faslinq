namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereTake", "Array")]
public class WhereTakeArray : WhereTakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereTake_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereTake_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereTake_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereTake_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
