using System.Xml.Linq;

namespace Faslinq.Benchmarks.Collections;

#if !NO_FASLINQ
#endif

[TestClass]
public class TakeLastBenchmarks : CollectionBenchmarkBase
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_Array(object[] item) => Test(item, Tests.Array);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_List(object[] item) => Test(item, Tests.List);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void TakeLast_Linq(object[] item) => Test(item, Tests.IEnumerable);

    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
        => throw new NotImplementedException();

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
        => throw new NotImplementedException();

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
        => throw new NotImplementedException();

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
        => throw new NotImplementedException();

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
        => throw new NotImplementedException();

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
        => throw new NotImplementedException();

    protected override List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values)
        => list.TakeLast(TakeCount(list));

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
        => array.TakeLast(TakeCount(array));

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
        => enumerable.TakeLast(TakeCount(enumerable));

    protected override List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values)
        => list.TakeLast(TakeCount(list));

    protected override TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values)
        => array.TakeLast(TakeCount(array));

    protected override IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values)
        => enumerable.TakeLast(TakeCount(enumerable));

    protected override IEnumerable<TData> LinqControl<TData>(object item)
    {
        (item is object[] { Length: 1, } z && z[0] is object[])
            .Should()
            .BeTrue($"{item.GetType().FullName} with Length"
                    + $" {item.GetType().GetProperty("Length")?.GetValue(item) ?? "<<null>>"}");

        if (item is object[] { Length: 1, } p
            && p[0] is object[] p0)
        {
            var takeCount = TakeCount(p0);
            var testData = p0.Cast<TData>();

#if !NETFRAMEWORK
            return Enumerable.TakeLast(testData, takeCount);
#else
            return testData.Skip(p.Length-(takeCount));
#endif
        }

        return Array.Empty<TData>();

    }
}
