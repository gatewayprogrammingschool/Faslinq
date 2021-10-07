namespace Faslinq.Benchmarks.Collections;

public class WhereArray : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void Where_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void Where_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void Where_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void Where_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
