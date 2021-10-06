namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("Where", "Array")]
public class WhereArray : WhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void Where_1_Faslinq(object item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void Where_250_Faslinq(object item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void Where_5000_Faslinq(object item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void Where_100000_Faslinq(object item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
