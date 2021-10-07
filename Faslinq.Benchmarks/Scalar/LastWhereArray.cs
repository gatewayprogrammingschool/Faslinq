// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class LastWhereArray : LastWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("LastWhere", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple LastWhere_1_Array(object[] item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple LastWhere_250_Array(object[] item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple LastWhere_5000_Array(object[] item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple LastWhere_100000_Array(object[] item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
#endif
