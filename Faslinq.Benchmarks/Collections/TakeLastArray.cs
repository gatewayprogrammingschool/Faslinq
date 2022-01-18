namespace Faslinq.Benchmarks.Collections;

public class TakeLastArray : TakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("TakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void TakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void TakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void TakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void TakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated100000).Consume(new ());
}
