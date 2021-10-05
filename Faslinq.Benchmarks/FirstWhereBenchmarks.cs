using System;
using System.Collections.Generic;
using System.Reflection;

using FluentAssertions.Primitives;
// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks;

[TestClass]
public class FirstWhereBenchmarks : BenchmarkBase
{
#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void FirstWhere_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords1);

#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple FirstWhere_1_Linq(object item) => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple FirstWhere_250_Linq(object item) => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple FirstWhere_5000_Linq(object item) => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple FirstWhere_100000_Linq(object item) => ProcessScalar(item, FirstGenerateRecords100000);


    public new static IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public new static IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public new static IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public new static IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();

    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        var s = list.FirstOrDefault();

        return ListExtensions.First(list, i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        var s = list.FirstOrDefault();

        return ListExtensions.First(list, i => i.Equals(s));
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        var s = array.FirstOrDefault();

        return ArrayExtensions.First(array, i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        var s = array.FirstOrDefault();

        return ArrayExtensions.First(array,  i => i.Equals(s));
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        var s = enumerable.FirstOrDefault();

        // ReSharper disable once InvokeAsExtensionMethod
        return Enumerable.First(enumerable!,  i => i?.Equals(s) ?? false);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        var s = enumerable.FirstOrDefault();

        // ReSharper disable once InvokeAsExtensionMethod
        return Enumerable.First(enumerable!,  i => i.Equals(s));
    }
    protected override List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values)
    {
        throw new NotImplementedException();
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(IEnumerable<TestValueTuple> enumerable,
        params object[] values)
    {
        throw new NotImplementedException();
    }

    protected override List<object> GetListByFaslinq(List<object> list, params object[] values)
    {
        throw new NotImplementedException();
    }

    protected override object[] GetArrayByFaslinq(object[] array, params object[] values)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEnumerableByLinq(IEnumerable<object> enumerable, params object[] values)
    {
        throw new NotImplementedException();
    }
}