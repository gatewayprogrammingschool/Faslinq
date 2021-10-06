using BenchmarkDotNet.Engines;

namespace Faslinq.Benchmarks.Collections;

[TestClass]
//[BenchmarkCategory("Select")]
public class SelectList : SelectBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Select_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1)
            .Consume(new Consumer());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "1", "List")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void Select_1_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords1)
            .Consume(new Consumer());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "250", "List")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void Select_250_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords250).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "5000", "List")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void Select_5000_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords5000).Consume(new());
    }

    [Benchmark]
    [BenchmarkCategory("Select", "100000", "List")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void Select_100000_Faslinq(object item)
    {
        ProcessCollection(Tests.List, item, FirstGenerateRecords100000).Consume(new());
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
