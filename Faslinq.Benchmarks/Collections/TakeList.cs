namespace Faslinq.Benchmarks.Collections;

public class TakeList : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void Take_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void Take_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void Take_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void Take_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
