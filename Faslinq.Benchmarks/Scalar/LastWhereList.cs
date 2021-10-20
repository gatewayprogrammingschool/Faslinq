// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
public class LastWhereList : LastWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("LastWhere", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public TestValueTuple LastWhere_1_List(object item)
        => ProcessScalar(item, LastGenerated1);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public TestValueTuple LastWhere_250_List(object item)
        => ProcessScalar(item, LastGenerated250);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public TestValueTuple LastWhere_5000_List(object item)
        => ProcessScalar(item, LastGenerated5000);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public TestValueTuple LastWhere_100000_List(object item)
        => ProcessScalar(item, LastGenerated100000);
}
#endif
