// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class LastArray : LastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Last", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public TestValueTuple Last_1_Array(object[] item)
        => ProcessScalar(item, LastGenerated1);

    [Benchmark]
    [BenchmarkCategory("Last", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public TestValueTuple Last_250_Array(object[] item)
        => ProcessScalar(item, LastGenerated250);

    [Benchmark]
    [BenchmarkCategory("Last", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public TestValueTuple Last_5000_Array(object[] item)
        => ProcessScalar(item, LastGenerated5000);

    [Benchmark]
    [BenchmarkCategory("Last", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public TestValueTuple Last_100000_Array(object[] item)
        => ProcessScalar(item, LastGenerated100000);
}
#endif
