namespace Faslinq.Benchmarks.Collections;

public class WhereSelectList : WhereSelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelect", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void WhereSelect_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void WhereSelect_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void WhereSelect_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void WhereSelect_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
