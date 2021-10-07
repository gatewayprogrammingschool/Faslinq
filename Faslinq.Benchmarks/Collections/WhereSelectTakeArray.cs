namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeArray : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelectTake_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelectTake_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelectTake_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelectTake_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
