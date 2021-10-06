namespace Faslinq.Benchmarks.Collections;

[TestClass]
[BenchmarkCategory("WhereSelectTakeLast", "List")]
public class WhereSelectTakeLastList : WhereSelectTakeLastBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTakeLast_1_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTakeLast_250_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTakeLast_5000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTakeLast_100000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords100000).Consume(new ());

    public new static IEnumerable<object[]> GenerateTestRecords1()
        => BenchmarkBase.GenerateTestRecords1();

    public new static IEnumerable<object[]> GenerateTestRecords250()
        => BenchmarkBase.GenerateTestRecords250();

    public new static IEnumerable<object[]> GenerateTestRecords5000()
        => BenchmarkBase.GenerateTestRecords5000();

    public new static IEnumerable<object[]> GenerateTestRecords100000()
        => BenchmarkBase.GenerateTestRecords100000();
}
