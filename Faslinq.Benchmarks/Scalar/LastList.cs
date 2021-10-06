// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
public class LastList : LastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Last", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple Last_1_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("Last", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple Last_250_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("Last", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple Last_5000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("Last", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple Last_100000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Last_Faslinq(object item)
    {
        ProcessScalar(item, LastGenerateRecords1);
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
