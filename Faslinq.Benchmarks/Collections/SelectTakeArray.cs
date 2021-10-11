namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeArray : SelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void SelectTake_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void SelectTake_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void SelectTake_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void SelectTake_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
