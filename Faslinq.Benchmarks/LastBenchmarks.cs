using System.Collections.Generic;
using System.Linq;
using System.Reflection;
// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks;

[TestClass]
public class LastBenchmarks : BenchmarkBase
{
#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple Last_1_Faslinq(object item) => Last_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple Last_250_Faslinq(object item) => Last_Faslinq(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple Last_5000_Faslinq(object item) => Last_Faslinq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple Last_100000_Faslinq(object item) => Last_Faslinq(item, LastGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Last_Faslinq(object item) => Last_Faslinq(item, LastGenerateRecords1);
    public TestValueTuple Last_Faslinq(object item, TestValueTuple last)
    {
        switch (item)
        {
            case object[] array and { Length: 1 }:
            {
                if (array[0] is not List<TestValueTuple> list)
                {
                    throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
                }

                var result = list.Last();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == last: {result == last}");
#endif
                return result;
            }
            case List<TestValueTuple> list:
            {
                var result = list.Last();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == last: {result == last}");
#endif
                return result;
            }
            default:
                throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple Last_1_Linq(object item) => Last_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple Last_250_Linq(object item) => Last_Linq(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple Last_5000_Linq(object item) => Last_Linq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple Last_100000_Linq(object item) => Last_Linq(item, LastGenerateRecords100000);


    public TestValueTuple  Last_Linq(object item, TestValueTuple last)
    {
        switch (item)
        {
            case object[] array and { Length: 1 }:
            {
                if (array[0] is not IEnumerable<TestValueTuple> enumerable)
                {
                    throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
                }

                var result = enumerable.Last();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == last: {result == last}");
#endif
                return result;
            }
            case IEnumerable<TestValueTuple> enumerable:
            {
                var result = enumerable.Last();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == last: {result == last}");
#endif
                return result;
            }

            default:
                throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public new static IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public new static IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public new static IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public new static IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();

    protected override TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : default
    {
        return ListExtensions.Last(list);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct
    {
        return ListExtensions.Last(list);
    }

    protected override TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : default
    {
        return ArrayExtensions.Last(array);
    }

    protected override TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct
    {
        return ArrayExtensions.Last(array);
    }

    protected override TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : default
    {
        // ReSharper disable once InvokeAsExtensionMethod
        return Enumerable.First(enumerable);
    }

    protected override TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct
    {
        // ReSharper disable once InvokeAsExtensionMethod
        return Enumerable.First(enumerable);
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