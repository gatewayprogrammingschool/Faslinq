// ReSharper disable InvokeAsExtensionMethod

using Faslinq.Benchmarks;
using Faslinq.Benchmarks.Collections;

namespace Faslinq.Tests.BenchmarkTests;

public class SelectBenchmarks : CollectionBenchmarkBase
{
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void Select_Array(object[] item) => Test(item, Benchmarks.Tests.Array);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void Select_List(object[] item) => Test(item, Benchmarks.Tests.List);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(GenerateTestRecords100000), typeof(BenchmarkBase), DynamicDataSourceType.Method)]
    public void Select_Linq(object[] item) => Test(item, Benchmarks.Tests.IEnumerable);

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
        return list.Select(i => i);
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        return array.Select(i => i);
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
    {
        return enumerable.Select(i => i);
    }

    protected override List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values)
    {
        return list.Select(i => i);
    }

    protected override TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values)
    {
        return array.Select(i => i);
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values)
    {
        return enumerable.Select(i => i);
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
            var testData = p0.Cast<TData>();

            return Enumerable.Select(testData, i => i);
        }

        return Array.Empty<TData>();
    }
}
