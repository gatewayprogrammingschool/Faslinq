// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
public class FirstWhereList : FirstWhereBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("FirstWhere", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_List(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_List(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_List(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("FirstWhere", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_List(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void FirstWhere_List(object item)
    {
        ProcessScalar(item, FirstGenerateRecords1);
    }
}
#endif
