// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
public class LastList : LastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Last", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public TestValueTuple Last_1_List(object item)
        => ProcessScalar(item, LastGenerated1);

    [Benchmark]
    [BenchmarkCategory("Last", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public TestValueTuple Last_250_List(object item)
        => ProcessScalar(item, LastGenerated250);

    [Benchmark]
    [BenchmarkCategory("Last", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public TestValueTuple Last_5000_List(object item)
        => ProcessScalar(item, LastGenerated5000);

    [Benchmark]
    [BenchmarkCategory("Last", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public TestValueTuple Last_100000_List(object item)
        => ProcessScalar(item, LastGenerated100000);
}
#endif
