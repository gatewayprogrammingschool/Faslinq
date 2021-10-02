using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
public class WhereBenchmarks : BenchmarkBase
{
    public WhereBenchmarks() : base() { }

#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> Where_1_Faslinq(object item) => Where_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> Where_250_Faslinq(object item) => Where_Faslinq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> Where_5000_Faslinq(object item) => Where_Faslinq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> Where_100000_Faslinq(object item) => Where_Faslinq(item, FirstGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Where_Faslinq(object item) => Where_Faslinq(item, FirstGenerateRecords1);
    public List<object> Where_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.Where(i => Predicate((i, first)));
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(Where_Linq(item, FirstGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.Where(i => Predicate((i, first)));
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(Where_Linq(item, FirstGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> Where_1_Linq(object item) => Where_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> Where_250_Linq(object item) => Where_Linq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> Where_5000_Linq(object item) => Where_Linq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> Where_100000_Linq(object item) => Where_Linq(item, FirstGenerateRecords100000);


    public List<object>  Where_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords250))).ToList();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords250))).ToList();
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>().ToList();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public static new IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public static new IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();
}
