namespace Faslinq.Benchmarks.Collections;

public class WhereTakeArray : WhereTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void WhereTake_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void WhereTake_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void WhereTake_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void WhereTake_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
}
