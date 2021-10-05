namespace Faslinq.Benchmarks;

[TestClass]
public class TakeLastBenchmarks : BenchmarkBase
{
    public TakeLastBenchmarks() : base() { }

#if !NO_FASLINQ
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void TakeLast_Faslinq(object item) => ProcessCollection(Tests.List, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public IEnumerable<TestValueTuple> TakeLast_1_Faslinq(object item) => ProcessCollection(Tests.List, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public IEnumerable<TestValueTuple> TakeLast_250_Faslinq(object item) => ProcessCollection(Tests.List, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public IEnumerable<TestValueTuple> TakeLast_5000_Faslinq(object item) => ProcessCollection(Tests.List, item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public IEnumerable<TestValueTuple> TakeLast_100000_Faslinq(object item) => ProcessCollection(Tests.List, item, LastGenerateRecords100000);

    [Benchmark, ArgumentsSource(nameof(GenerateArray1))]
    public IEnumerable<TestValueTuple> TakeLast_1_Faslinq(object[] item) => ProcessCollection(Tests.Array, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateArray250))]
    public IEnumerable<TestValueTuple> TakeLast_250_Faslinq(object[] item) => ProcessCollection(Tests.Array, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateArray5000))]
    public IEnumerable<TestValueTuple> TakeLast_5000_Faslinq(object[] item) => ProcessCollection(Tests.Array, item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateArray100000))]
    public IEnumerable<TestValueTuple> TakeLast_100000_Faslinq(object[] item) => ProcessCollection(Tests.Array, item, LastGenerateRecords100000);

#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public IEnumerable<TestValueTuple> TakeLast_1_Linq(object item) => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public IEnumerable<TestValueTuple> TakeLast_250_Linq(object item) => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public IEnumerable<TestValueTuple> TakeLast_5000_Linq(object item) => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public IEnumerable<TestValueTuple> TakeLast_100000_Linq(object item) => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000);


    public new static IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public new static IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public new static IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public new static IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();
    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        throw new NotImplementedException();
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        throw new NotImplementedException();
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        throw new NotImplementedException();
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        throw new NotImplementedException();
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        throw new NotImplementedException();
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        throw new NotImplementedException();
    }

    protected override List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values)
    {
        return ListExtensions.TakeLast(list, (int)(list.Count * 0.2m));
    }

    protected override TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values)
    {
        return ArrayExtensions.TakeLast(array, (int)(array.Length * 0.2m));
    }

    protected override IEnumerable<TestValueTuple> GetEnumerableStructByLinq(IEnumerable<TestValueTuple> enumerable,
        params object[] values)
    {
        return enumerable.TakeLast((int)(enumerable.Count() * 0.2m));
    }

    protected override List<object> GetListByFaslinq(List<object> list, params object[] values)
    {
        return ListExtensions.TakeLast(list, (int)(list.Count * 0.2m));
    }

    protected override object[] GetArrayByFaslinq(object[] array, params object[] values)
    {
        return ArrayExtensions.TakeLast(array,(int)(array.Length * 0.2m));
    }

    protected override IEnumerable<object> GetEnumerableByLinq(IEnumerable<object> enumerable, params object[] values)
    {
        return enumerable.TakeLast((int)(enumerable.Count() * 0.2m));
    }
}
