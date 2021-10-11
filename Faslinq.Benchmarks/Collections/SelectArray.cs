using BenchmarkDotNet.Engines;

namespace Faslinq.Benchmarks.Collections;

public class SelectArray : SelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Select", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void Select_1_Array(object[] item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void Select_250_Array(object[] item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void Select_5000_Array(object[] item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void Select_100000_Array(object[] item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
    }
}
