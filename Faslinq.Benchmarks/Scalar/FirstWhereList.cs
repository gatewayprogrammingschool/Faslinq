// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
[BenchmarkCategory("FirstWhere", "List")]
public class FirstWhereList : FirstWhereBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void FirstWhere_Faslinq(object item)
    {
        ProcessScalar(item, FirstGenerateRecords1);
    }

    public new static IEnumerable<object[]> GenerateTestRecords1()
        => BenchmarkBase.GenerateTestRecords1();

    public new static IEnumerable<object[]> GenerateTestRecords250()
        => BenchmarkBase.GenerateTestRecords250();

    public new static IEnumerable<object[]> GenerateTestRecords5000()
        => BenchmarkBase.GenerateTestRecords5000();

    public new static IEnumerable<object[]> GenerateTestRecords100000()
        => BenchmarkBase.GenerateTestRecords100000();
}
#endif
