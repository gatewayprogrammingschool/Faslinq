namespace Faslinq.Benchmarks.Collections;

[BenchmarkCategory("Take", "Array")]
public class TakeArray : TakeBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void Take_1_Faslinq(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void Take_250_Faslinq(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void Take_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void Take_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
