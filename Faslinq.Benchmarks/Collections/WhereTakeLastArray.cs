namespace Faslinq.Benchmarks.Collections;

public class WhereTakeLastArray : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void WhereTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void WhereTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void WhereTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void WhereTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated100000).Consume(new ());
}
