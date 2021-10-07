// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class FirstWhereArray : FirstWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("FirstWhere", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple FirstWhere_1_Array(object[] item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple FirstWhere_250_Array(object[] item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple FirstWhere_5000_Array(object[] item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple FirstWhere_100000_Array(object[] item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
#endif
