namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class TakeList : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Take_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Take_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Take_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Take_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
