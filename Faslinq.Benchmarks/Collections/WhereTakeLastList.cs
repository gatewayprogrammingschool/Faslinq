namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereTakeLastList : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords100000).Consume(new ());
}
