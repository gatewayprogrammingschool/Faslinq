namespace Faslinq.Benchmarks.Collections;

[TestClass]
[BenchmarkCategory("WhereTake", "List")]
public class WhereTakeList : WhereTakeBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereTake_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTake_1_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTake_250_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTake_5000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTake_100000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new ());

    public new static IEnumerable<object[]> GenerateTestRecords1()
        => BenchmarkBase.GenerateTestRecords1();

    public new static IEnumerable<object[]> GenerateTestRecords250()
        => BenchmarkBase.GenerateTestRecords250();

    public new static IEnumerable<object[]> GenerateTestRecords5000()
        => BenchmarkBase.GenerateTestRecords5000();

    public new static IEnumerable<object[]> GenerateTestRecords100000()
        => BenchmarkBase.GenerateTestRecords100000();
}
