// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
public class FirstWhereList : FirstWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("FirstWhere", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public TestValueTuple FirstWhere_1_List(object item)
        => ProcessScalar(item, FirstGenerated1);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public TestValueTuple FirstWhere_250_List(object item)
        => ProcessScalar(item, FirstGenerated250);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public TestValueTuple FirstWhere_5000_List(object item)
        => ProcessScalar(item, FirstGenerated5000);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public TestValueTuple FirstWhere_100000_List(object item)
        => ProcessScalar(item, FirstGenerated100000);
}
#endif
