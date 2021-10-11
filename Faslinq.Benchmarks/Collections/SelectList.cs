namespace Faslinq.Benchmarks.Collections;

public class SelectList : SelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Select", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Select_1_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1)
            .Consume(new Consumer());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_250_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Select_5000_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Select_100000_List(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new());
    }
}
