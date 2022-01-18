namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeArray : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void WhereSelectTake_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void WhereSelectTake_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void WhereSelectTake_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void WhereSelectTake_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
}
