using System.Collections.Generic;
using System.Linq;
using System.Reflection;
// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks;

[TestClass]
public class FirstBenchmarks : BenchmarkBase
{
    public FirstBenchmarks() : base() { }

#if !NO_FASLINQ
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void First_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords1);


    // Lists
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple First_1_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords1);
    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple First_250_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords250);
    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple First_5000_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords5000);
    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple First_100000_Faslinq(object item) => ProcessScalar(item, FirstGenerateRecords100000);

    // Arrays
    [Benchmark, ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple First_1_Faslinq(object[] item) => ProcessScalar(item, FirstGenerateRecords1);
    [Benchmark, ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple First_250_Faslinq(object[] item) => ProcessScalar(item, FirstGenerateRecords250);
    [Benchmark, ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple First_5000_Faslinq(object[] item) => ProcessScalar(item, FirstGenerateRecords5000);
    [Benchmark, ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple First_100000_Faslinq(object[] item) => ProcessScalar(item, FirstGenerateRecords100000);
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple First_1_Linq(object item) => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple First_250_Linq(object item) => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple First_5000_Linq(object item) => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple First_100000_Linq(object item) => ProcessScalar(item, FirstGenerateRecords100000);


    public new static IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public new static IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public new static IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public new static IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();

    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        return ListExtensions.First(list, null);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        return ListExtensions.First(list, null);
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        return ArrayExtensions.First(array, null);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        return ArrayExtensions.First(array, null);
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        return Enumerable.First(enumerable!);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        return Enumerable.First(enumerable!);
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