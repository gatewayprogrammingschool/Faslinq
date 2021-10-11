// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;

public abstract class FirstWhereBenchmarks : ScalarBenchmarkBase
{
    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        var s = list.FirstOrDefault();

        return list.First(i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        var s = list.FirstOrDefault();

        return list.First(i => i.Equals(s));
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        var s = array.FirstOrDefault();

        return array.First(i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        var s = array.FirstOrDefault();

        return array.First(i => i.Equals(s));
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        var s = enumerable.FirstOrDefault();

        // ReSharper disable once InvokeAsExtensionMethod
        return enumerable!.First(i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        var s = enumerable.FirstOrDefault();

        // ReSharper disable once InvokeAsExtensionMethod
        return enumerable!.First(i => i.Equals(s));
    }

    protected override List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values)
        => throw new NotImplementedException();

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
        => throw new NotImplementedException();

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
        => throw new NotImplementedException();

    protected override List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values)
        => throw new NotImplementedException();

    protected override TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values)
        => throw new NotImplementedException();

    protected override IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values)
        => throw new NotImplementedException();

    protected override TData LinqControl<TData>(object item)
        where TData : struct
    {
        if (item is object[] { Length: 1, } p)
        {
            return Enumerable
                .First(p.Cast<TData>(), i => i.As<TestValueTuple>().Equals(FirstGenerateRecords1));
        }

        return default;
    }
}
