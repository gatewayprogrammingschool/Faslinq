namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereSelectTake", "Array")]
public class WhereSelectTakeArray : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelectTake_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelectTake_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelectTake_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelectTake_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
