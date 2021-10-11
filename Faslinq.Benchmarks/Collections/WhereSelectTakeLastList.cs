namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectTakeLastList : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords100000).Consume(new ());
}
