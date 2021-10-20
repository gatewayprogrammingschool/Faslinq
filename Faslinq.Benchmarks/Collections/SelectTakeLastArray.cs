namespace Faslinq.Benchmarks.Collections;

public class SelectTakeLastArray : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void SelectTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void SelectTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void SelectTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void SelectTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated100000).Consume(new ());
}
