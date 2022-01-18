// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

public class FirstWhereLinq : FirstWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("FirstWhere", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public TestValueTuple FirstWhere_1_Linq(object item)
        => ProcessScalar(item, FirstGenerated1);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public TestValueTuple FirstWhere_250_Linq(object item)
        => ProcessScalar(item, FirstGenerated250);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public TestValueTuple FirstWhere_5000_Linq(object item)
        => ProcessScalar(item, FirstGenerated5000);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "10000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public TestValueTuple FirstWhere_100000_Linq(object item)
        => ProcessScalar(item, FirstGenerated100000);
}
