// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
[BenchmarkCategory("First", "List")]
public class FirstList : FirstBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void First_Faslinq(object item)
    {
        ProcessScalar(item, FirstGenerateRecords1);
    }

    // Lists
    [Benchmark]
    [BenchmarkCategory("First", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple First_1_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("First", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple First_250_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("First", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple First_5000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("First", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple First_100000_Faslinq(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);

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
