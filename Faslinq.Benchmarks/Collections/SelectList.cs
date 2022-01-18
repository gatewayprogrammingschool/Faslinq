namespace Faslinq.Benchmarks.Collections;

public class SelectList : SelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Select", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void Select_1_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerated1)
            .Consume(new Consumer());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void Select_250_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void Select_5000_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void Select_100000_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new());
    }
}
