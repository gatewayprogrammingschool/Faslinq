// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

[BenchmarkCategory("First", "Linq")]
public class FirstLinq : FirstBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("First", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple First_1_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("First", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple First_250_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("First", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple First_5000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("First", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple First_100000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
