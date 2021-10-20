namespace Faslinq.Benchmarks.Collections;

public class WhereSelectTakeLastLinq : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void WhereSelectTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void WhereSelectTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void WhereSelectTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void WhereSelectTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerated100000).Consume(new ());
}
