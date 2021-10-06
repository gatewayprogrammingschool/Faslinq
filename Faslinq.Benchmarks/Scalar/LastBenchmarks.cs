// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;

public abstract class LastBenchmarks : BenchmarkBase
{
    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
        => list.Last();

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
        => list.Last();

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
        => array.Last();

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
        => array.Last();

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    // ReSharper disable once InvokeAsExtensionMethod
        => enumerable.First();

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    // ReSharper disable once InvokeAsExtensionMethod
        => enumerable.First();

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
