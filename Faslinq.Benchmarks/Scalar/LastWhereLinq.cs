// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

[BenchmarkCategory("LastWhere", "Linq")]
public class LastWhereLinq : LastWhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple LastWhere_1_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple LastWhere_250_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple LastWhere_5000_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple LastWhere_100000_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
