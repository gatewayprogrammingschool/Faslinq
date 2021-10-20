// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class FirstArray : FirstBenchmarks
{
    // Arrays
    [Benchmark]
    [BenchmarkCategory("First", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public TestValueTuple First_1_Array(object[] item)
        => ProcessScalar(item, FirstGenerated1);

    [Benchmark]
    [BenchmarkCategory("First", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public TestValueTuple First_250_Array(object[] item)
        => ProcessScalar(item, FirstGenerated250);

    [Benchmark]
    [BenchmarkCategory("First", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public TestValueTuple First_5000_Array(object[] item)
        => ProcessScalar(item, FirstGenerated5000);

    [Benchmark]
    [BenchmarkCategory("First", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public TestValueTuple First_100000_Array(object[] item)
        => ProcessScalar(item, FirstGenerated100000);
}
#endif
