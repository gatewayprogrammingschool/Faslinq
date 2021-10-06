// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;

public abstract class LastWhereBenchmarks : BenchmarkBase
{
    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        return list.Last(i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        return list.Last(i => i.Equals(values[0]));
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        return array.Last(i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        return array.Last(i => i.Equals(values[0]));
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        return enumerable.First(i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        return enumerable!.First(i => i.Equals(values[0]));
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

    protected override List<object> GetListByFaslinq(List<object> list, params object[] values)
        => throw new NotImplementedException();

    protected override object[] GetArrayByFaslinq(object[] array, params object[] values)
        => throw new NotImplementedException();

    protected override IEnumerable<object> GetEnumerableByLinq(IEnumerable<object> enumerable, params object[] values)
        => throw new NotImplementedException();
}
