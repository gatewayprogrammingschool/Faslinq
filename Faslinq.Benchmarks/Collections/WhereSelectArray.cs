namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectArray : WhereSelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelect", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelect_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelect_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelect_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelect_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
