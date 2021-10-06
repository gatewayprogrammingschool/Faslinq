namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("Select", "Linq")]
public class SelectLinq : SelectBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_1_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_250_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Select_5000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Select_100000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
    }
}
