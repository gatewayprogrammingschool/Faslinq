namespace Faslinq.Benchmarks.Collections;

public class WhereTakeLastList : WhereTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void WhereTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void WhereTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void WhereTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void WhereTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated100000).Consume(new ());
}
