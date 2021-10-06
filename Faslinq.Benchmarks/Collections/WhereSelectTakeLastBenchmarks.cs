﻿namespace Faslinq.Benchmarks.Collections;

#if !NO_FASLINQ
#endif

public abstract class WhereSelectTakeLastBenchmarks : BenchmarkBase
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
        return list.WhereSelectTakeLast(i => list[0] == i, i => i, (int)(list.Count * 0.2m));
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        return array.WhereSelectTakeLast(i => array[0] == i, i => i, (int)(array.Length * 0.2m));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    )
    {
        return enumerable.Where(i => enumerable.First() == i)
            .Select(i => i)
            .TakeLast((int)(enumerable.Count() * 0.2m));
    }

    protected override List<object> GetListByFaslinq(List<object> list, params object[] values)
    {
        return list.WhereSelectTakeLast(i => list[0] == i, i => i, (int)(list.Count * 0.2m));
    }

    protected override object[] GetArrayByFaslinq(object[] array, params object[] values)
    {
        return array.WhereSelectTakeLast(i => array[0] == i, i => i, (int)(array.Length * 0.2m));
    }

    protected override IEnumerable<object> GetEnumerableByLinq(IEnumerable<object> enumerable, params object[] values)
    {
        return enumerable.Where(i => enumerable.First() == i)
            .Select(i => i)
            .TakeLast((int)(enumerable.Count() * 0.2m));
    }
}