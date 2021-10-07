namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeLastArray : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelectTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelectTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelectTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelectTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
