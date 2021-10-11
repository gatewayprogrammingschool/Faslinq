namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereList : WhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Where", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Where_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Where_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Where_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Where", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Where_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
