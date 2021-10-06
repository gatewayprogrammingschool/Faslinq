namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectTakeList : WhereSelectTakeBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereSelectTake_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_Faslinq(object item)
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
