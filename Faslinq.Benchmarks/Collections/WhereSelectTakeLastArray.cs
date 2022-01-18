namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeLastArray : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void WhereSelectTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void WhereSelectTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void WhereSelectTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void WhereSelectTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerated100000).Consume(new ());
}
