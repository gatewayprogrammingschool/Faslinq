namespace Faslinq.Benchmarks.Collections;

public class TakeLastList : TakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("TakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public void TakeLast_1_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public void TakeLast_250_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public void TakeLast_5000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public void TakeLast_100000_List(object item)
        => ProcessCollection(Tests.List, item, LastGenerated100000).Consume(new ());
}
