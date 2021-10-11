// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
[TestClass]
public class FirstList : FirstBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void First_List(object item)
    {
        ProcessScalar(item, FirstGenerateRecords1);
    }

    // Lists
    [Benchmark]
    [BenchmarkCategory("First", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple First_1_List(object item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("First", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple First_250_List(object item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("First", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple First_5000_List(object item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("First", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple First_100000_List(object item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
#endif
