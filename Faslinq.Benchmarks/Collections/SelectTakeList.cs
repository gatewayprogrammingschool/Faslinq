namespace Faslinq.Benchmarks.Collections;

[TestClass]
[BenchmarkCategory("SelectTake", "List")]
public class SelectTakeList : SelectTakeBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void SelectTake_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTake_1_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTake_250_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTake_5000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTake_100000_Faslinq(object item)
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
