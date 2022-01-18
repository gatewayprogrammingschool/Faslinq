namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeLastList : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void WhereSelectTakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void WhereSelectTakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void WhereSelectTakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void WhereSelectTakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated100000).Consume(new ());
}
