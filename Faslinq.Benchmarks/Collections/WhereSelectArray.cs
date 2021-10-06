namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereSelect", "Array")]
public class WhereSelectArray : WhereSelectBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelect_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelect_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelect_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelect_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
