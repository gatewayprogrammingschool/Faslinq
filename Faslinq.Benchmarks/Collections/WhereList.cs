namespace Faslinq.Benchmarks.Collections;

public class WhereList : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void Where_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void Where_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void Where_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void Where_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
