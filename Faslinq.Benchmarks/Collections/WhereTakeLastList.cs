namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereTakeLastList : WhereTakeLastBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereTakeLast_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());
    }

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereTakeLast_1_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereTakeLast_250_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereTakeLast_5000_Faslinq(object item)
        => ProcessCollection(Tests.List, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTakeLast", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereTakeLast_100000_Faslinq(object item)
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
