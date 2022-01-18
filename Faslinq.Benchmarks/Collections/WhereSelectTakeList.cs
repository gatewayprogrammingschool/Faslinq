namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeList : WhereSelectTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void WhereSelectTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void WhereSelectTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void WhereSelectTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void WhereSelectTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
