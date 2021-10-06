namespace Faslinq.Benchmarks.Collections;

//[BenchmarkCategory("Select")]
public class SelectLinq : SelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Select", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_1_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_250_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords250).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Select_5000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords5000).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Select_100000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerateRecords100000).Consume(new ());
    }
}
