// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

public class FirstLinq : FirstBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("First", "1" , "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public TestValueTuple First_1_Linq(object item)
        => ProcessScalar(item, FirstGenerated1);

    [Benchmark]
    [BenchmarkCategory("First", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public TestValueTuple First_250_Linq(object item)
        => ProcessScalar(item, FirstGenerated250);

    [Benchmark]
    [BenchmarkCategory("First", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public TestValueTuple First_5000_Linq(object item)
        => ProcessScalar(item, FirstGenerated5000);

    [Benchmark]
    [BenchmarkCategory("First", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public TestValueTuple First_100000_Linq(object item)
        => ProcessScalar(item, FirstGenerated100000);
}
