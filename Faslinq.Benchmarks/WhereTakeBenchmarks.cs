using System.Collections.Generic;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
public class WhereTakeBenchmarks : BenchmarkBase
{
    public WhereTakeBenchmarks() : base() { }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereTake_1_Faslinq(object item) => WhereTake_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereTake_10_Faslinq(object item) => WhereTake_Faslinq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereTake_100_Faslinq(object item) => WhereTake_Faslinq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereTake_1000_Faslinq(object item) => WhereTake_Faslinq(item, FirstGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereTake_1_Linq(object item) => WhereTake_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereTake_10_Linq(object item) => WhereTake_Linq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereTake_100_Linq(object item) => WhereTake_Linq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereTake_1000_Linq(object item) => WhereTake_Linq(item, FirstGenerateRecords1000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void WhereTake_Faslinq(object item) => WhereTake_Faslinq(item, FirstGenerateRecords1);

    public List<object> WhereTake_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.WhereTake(i => Predicate((i, first)), ToTake(list));
#if DEBUG
                Console.WriteLine($"WhereTake_Faslinq: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(WhereTake_Linq(item, FirstGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.WhereTake(i => Predicate((i, first)), ToTake(list));
#if DEBUG
            Console.WriteLine($"WhereTake_Faslinq: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(WhereTake_Linq(item, FirstGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public List<object>  WhereTake_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
{
                var result = enumerable.Where(i => Predicate((i, first))).Take(ToTake(enumerable)).ToList();
#if DEBUG
                Console.WriteLine($"WhereTake_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Where(i => Predicate((i, first))).Take(ToTake(enumerable)).ToList();
#if DEBUG
            Console.WriteLine($"WhereTake_Linq: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>().ToList();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()} length: {(item as object[])?.Length}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords10() => BenchmarkBase.GenerateTestRecords10();
    public static new IEnumerable<object[]> GenerateTestRecords100() => BenchmarkBase.GenerateTestRecords100();
    public static new IEnumerable<object[]> GenerateTestRecords1000() => BenchmarkBase.GenerateTestRecords1000();
}
