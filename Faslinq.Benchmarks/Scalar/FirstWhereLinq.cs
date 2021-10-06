// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

[BenchmarkCategory("FirstWhere", "Linq")]
public class FirstWhereLinq : FirstWhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
