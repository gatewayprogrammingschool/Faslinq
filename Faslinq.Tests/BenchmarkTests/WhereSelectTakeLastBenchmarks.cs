using Faslinq.Benchmarks;
using Faslinq.Benchmarks.Collections;

namespace Faslinq.Tests.BenchmarkTests;

#if !NO_FASLINQ
#endif

[TestClass]
public abstract class WhereSelectTakeLastBenchmarks : CollectionBenchmarkBase
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_Array(object[] item) => Test(item, Benchmarks.Tests.Array);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_List(object[] item) => Test(item, Benchmarks.Tests.List);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_Linq(object[] item) => Test(item, Benchmarks.Tests.IEnumerable);

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
    {
        return list.WhereSelectTakeLast(Function, i => i, TakeCount(list));
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        return array.WhereSelectTakeLast(
            Function,
            i => i,
            TakeCount(array));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
    {
        return enumerable.Where(Function)
            .Select(i => i)
            .TakeLast(TakeCount(enumerable));
    }

    protected override List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values)
    {
        return list.WhereSelectTakeLast(Function, i => i, TakeCount(list));
    }

    protected override TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values)
    {
        return array.WhereSelectTakeLast(Function, i => i, TakeCount(array));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values)
    {
        return enumerable.Where(Function)
            .Select(i => i)
            .TakeLast(TakeCount(enumerable));
    }

    protected override IEnumerable<TData> LinqControl<TData>(object item)
    {
        (item is object[] { Length: 1, } z && z[0] is object[])
            .Should()
            .BeTrue($"{item.GetType().FullName} with Length"
                    + $" {item.GetType().GetProperty("Length")?.GetValue(item) ?? "<<null>>"}");

        if (item is object[] { Length: 1, } p
            && p[0] is object[] p0)
        {
            var testData = p0.Cast<TestValueTuple>();

#if !NETFRAMEWORK
            return Enumerable
                    .Where(testData,
                        Function)
                    .Select(i => i)
                .TakeLast(TakeCount(p0))
                    .Cast<TData>();
#else
            return Enumerable
                .Where(testData,
                    Function)
                .Select(i => i)
                .TakeLast(TakeCount(p0))
                .Skip(p.Length - 2)
                .Cast<TData>();
#endif
        }

        return Array.Empty<TData>();
    }
}
