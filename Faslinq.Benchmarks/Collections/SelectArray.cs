using BenchmarkDotNet.Engines;

namespace Faslinq.Benchmarks.Collections;

public class SelectArray : SelectBenchmarks
{
    public SelectArray()
    {
        //Debugger.Launch();
    }

    [Benchmark]
    [BenchmarkCategory("Select", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void Select_1_Array(object item)
    {
        //Debugger.Break();
        ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void Select_250_Array(object item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void Select_5000_Array(object item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void Select_100000_Array(object item)
    {
        ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
    }
}
