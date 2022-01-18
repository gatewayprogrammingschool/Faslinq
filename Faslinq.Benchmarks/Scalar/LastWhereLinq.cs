// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

public class LastWhereLinq : LastWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("LastWhere", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq1))]
    public TestValueTuple LastWhere_1_Linq(object item)
        => ProcessScalar(item, LastGenerated1);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq250))]
    public TestValueTuple LastWhere_250_Linq(object item)
        => ProcessScalar(item, LastGenerated250);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq5000))]
    public TestValueTuple LastWhere_5000_Linq(object item)
        => ProcessScalar(item, LastGenerated5000);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateTestLinq100000))]
    public TestValueTuple LastWhere_100000_Linq(object item)
        => ProcessScalar(item, LastGenerated100000);
}
