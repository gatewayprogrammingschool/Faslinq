namespace Faslinq.Benchmarks.Collections;

public class SelectTakeArray : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void SelectTake_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void SelectTake_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void SelectTake_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void SelectTake_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
}
