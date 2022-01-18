namespace Faslinq.Benchmarks.Collections;

public abstract class SelectTakeLastBenchmarks : CollectionBenchmarkBase
{
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
        return list.SelectTakeLast(i => i, TakeCount(list));
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        return array.SelectTakeLast(i => i, TakeCount(array));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
    {
        return enumerable.Select(i => i)
            .TakeLast(TakeCount(enumerable));
    }

    protected override List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values)
    {
        return list.SelectTakeLast(i => i, TakeCount(list));
    }

    protected override TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values)
    {
        return array.SelectTakeLast(i => i, TakeCount(array));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values)
    {
        return enumerable.Select(i => i)
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
            var takeCount = TakeCount(p0);
            var testData = p0.Cast<TData>();

#if !NETFRAMEWORK
            return Enumerable
                .Select(testData, i => i)
                .TakeLast(takeCount);
#else
            return Enumerable
                .Select(testData, i => i)
                .Skip(takeCount);
#endif
        }

        return Array.Empty<TData>();
    }
}
