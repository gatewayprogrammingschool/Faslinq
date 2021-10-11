// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
public class LastWhereList : LastWhereBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void LastWhere_List(object item)
    {
        ProcessScalar(item, LastGenerateRecords1);
    }

    [Benchmark]
    [BenchmarkCategory("LastWhere", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple LastWhere_1_List(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple LastWhere_250_List(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple LastWhere_5000_List(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("LastWhere", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple LastWhere_100000_List(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
#endif
