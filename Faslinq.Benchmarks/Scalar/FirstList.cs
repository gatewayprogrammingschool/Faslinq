// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
public class FirstList : FirstBenchmarks
{
    // Lists
    [Benchmark]
    [BenchmarkCategory("First", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public TestValueTuple First_1_List(object item)
        => ProcessScalar(item, FirstGenerated1);

    [Benchmark]
    [BenchmarkCategory("First", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public TestValueTuple First_250_List(object item)
        => ProcessScalar(item, FirstGenerated250);

    [Benchmark]
    [BenchmarkCategory("First", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public TestValueTuple First_5000_List(object item)
        => ProcessScalar(item, FirstGenerated5000);

    [Benchmark]
    [BenchmarkCategory("First", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public TestValueTuple First_100000_List(object item)
        => ProcessScalar(item, FirstGenerated100000);
}
#endif
