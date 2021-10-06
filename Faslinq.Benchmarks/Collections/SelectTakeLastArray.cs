namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("SelectTakeLast", "Array")]
public class SelectTakeLastArray : SelectTakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
