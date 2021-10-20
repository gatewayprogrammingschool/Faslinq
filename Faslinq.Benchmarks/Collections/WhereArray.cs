namespace Faslinq.Benchmarks.Collections;

public class WhereArray : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void Where_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void Where_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void Where_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void Where_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
}
