namespace Faslinq.Benchmarks.Collections;

public class TakeArray : TakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Take", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void Take_1_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void Take_250_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "50000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void Take_5000_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("Take", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void Take_100000_Array(object[] item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());
}
