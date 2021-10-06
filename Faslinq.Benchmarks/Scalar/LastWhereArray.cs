// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

[BenchmarkCategory("LastWhere", "Array")]
public class LastWhereArray : LastWhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple LastWhere_1_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple LastWhere_250_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple LastWhere_5000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple LastWhere_100000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
#endif
