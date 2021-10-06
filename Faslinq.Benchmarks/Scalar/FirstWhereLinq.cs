// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

public class FirstWhereLinq : FirstWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("FirstWhere", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "10000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_Linq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
