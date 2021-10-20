// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

public class LastLinq : LastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Last", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public TestValueTuple Last_1_Linq(object item)
        => ProcessScalar(item, LastGenerated1);

    [Benchmark]
    [BenchmarkCategory("Last", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public TestValueTuple Last_250_Linq(object item)
        => ProcessScalar(item, LastGenerated250);

    [Benchmark]
    [BenchmarkCategory("Last", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public TestValueTuple Last_5000_Linq(object item)
        => ProcessScalar(item, LastGenerated5000);

    [Benchmark]
    [BenchmarkCategory("Last", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public TestValueTuple Last_100000_Linq(object item)
        => ProcessScalar(item, LastGenerated100000);
}
