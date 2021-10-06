namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("WhereSelectTakeLast", "Array")]
public class WhereSelectTakeLastArray : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereSelectTakeLast_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereSelectTakeLast_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereSelectTakeLast_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereSelectTakeLast_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
