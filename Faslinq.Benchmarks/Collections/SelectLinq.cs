namespace Faslinq.Benchmarks.Collections;

public class SelectLinq : SelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Select", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void Select_1_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerated1).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void Select_250_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerated250).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void Select_5000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerated5000).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void Select_100000_Linq(object item)
    {
        ProcessCollection(Tests.IEnumerable, item, FirstGenerated100000).Consume(new());
    }
}
