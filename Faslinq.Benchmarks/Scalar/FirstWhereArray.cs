// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

[BenchmarkCategory("FirstWhere", "Array")]
public class FirstWhereArray : FirstWhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple FirstWhere_1_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple FirstWhere_250_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple FirstWhere_5000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple FirstWhere_100000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
#endif
