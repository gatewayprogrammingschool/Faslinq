namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class SelectTakeLastArray : SelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("SelectTakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
