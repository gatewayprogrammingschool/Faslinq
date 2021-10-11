namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectTakeList : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
