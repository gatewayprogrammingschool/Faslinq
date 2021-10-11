namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereTakeLastArray : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
