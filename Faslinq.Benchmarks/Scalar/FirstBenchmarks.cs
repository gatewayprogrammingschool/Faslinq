// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;

public abstract class FirstBenchmarks : ScalarBenchmarkBase
{
    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
        => list.First();

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
        => list.First();

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
        => array.First();

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
        => array.First();

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
        => enumerable!.First();

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
        => enumerable!.First();

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

    protected override TestValueTuple SelectTarget(IReadOnlyList<TestValueTuple> records)
        => records[0];

    protected override TestValueTuple LinqControl(IEnumerable<TestValueTuple> records, TestValueTuple target)
        => Enumerable.First(records);
}
