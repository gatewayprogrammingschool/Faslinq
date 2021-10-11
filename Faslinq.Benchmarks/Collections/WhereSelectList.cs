namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectList : WhereSelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelect", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelect_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelect_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelect_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelect_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
