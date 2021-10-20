namespace Faslinq.Benchmarks.Collections;

public class TakeArray : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void Take_1_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void Take_250_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "50000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void Take_5000_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void Take_100000_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
