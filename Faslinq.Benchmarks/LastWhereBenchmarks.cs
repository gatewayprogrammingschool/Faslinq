using System.Reflection;
// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks;

[TestClass]
public class LastWhereBenchmarks : BenchmarkBase
{
#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple LastWhere_1_Faslinq(object item) => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple LastWhere_250_Faslinq(object item) => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple LastWhere_5000_Faslinq(object item) => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple LastWhere_100000_Faslinq(object item) => ProcessScalar(item, LastGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void LastWhere_Faslinq(object item) => ProcessScalar(item, LastGenerateRecords1);
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple LastWhere_1_Linq(object item) => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple LastWhere_250_Linq(object item) => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple LastWhere_5000_Linq(object item) => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple LastWhere_100000_Linq(object item) => ProcessScalar(item, LastGenerateRecords100000);

    public new static IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public new static IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public new static IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public new static IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();

    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        return ListExtensions.Last(list, i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        return ListExtensions.Last(list, i => i.Equals(values[0]));
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        return ArrayExtensions.Last(array, i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        return ArrayExtensions.Last(array,  i => i.Equals(values[0]));
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        return Enumerable.First(enumerable,  i => i?.Equals(values[0]) ?? false);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        return Enumerable.First(enumerable!,  i => i.Equals(values[0]));
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