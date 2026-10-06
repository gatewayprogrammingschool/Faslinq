using Faslinq.Benchmarks;

namespace Faslinq.Tests.BenchmarkTests;

/// <summary>
/// Checks that each input shape of <see cref="Benchmarks.Collections.TakeLastBenchmarks"/> produces
/// the same results as its System.Linq control.
/// </summary>
[TestClass]
public class TakeLastBenchmarks : Benchmarks.Collections.TakeLastBenchmarks
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_Array(object[] item) => Test(item, Benchmarks.Tests.Array);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_List(object[] item) => Test(item, Benchmarks.Tests.List);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_Linq(object[] item) => Test(item, Benchmarks.Tests.IEnumerable);
}
