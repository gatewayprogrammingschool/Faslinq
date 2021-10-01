using System.Reflection;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
public class WhereSelectTakeBenchmarks : BenchmarkBase
{
    public WhereSelectTakeBenchmarks() : base() { }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereSelectTake_1_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereSelectTake_10_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereSelectTake_100_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereSelectTake_1000_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereSelectTake_1_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereSelectTake_10_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereSelectTake_100_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereSelectTake_1000_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords1000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords10))]
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void WhereSelectTake_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords1);
    public List<object> WhereSelectTake_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                int toTake = ToTake(list);
                var result = list.WhereSelectTake(i => Predicate((i, FirstGenerateRecords10)), Selector, toTake);
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(WhereSelectTake_Linq(item, FirstGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            int toTake = ToTake(list);
            var result = list.WhereSelectTake(i => Predicate((i, FirstGenerateRecords10)), Selector, toTake);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(WhereSelectTake_Linq(item, FirstGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public List<object>  WhereSelectTake_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                int toTake = ToTake(enumerable);
                var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords10)))
                                        .Select(Selector)
                                        .Take(toTake)
                                        .ToList();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            int toTake = ToTake(enumerable);
            var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords10)))
                                    .Select(Selector)
                                    .Take(toTake)
                                    .ToList();
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>().ToList();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords10() => BenchmarkBase.GenerateTestRecords10();
    public static new IEnumerable<object[]> GenerateTestRecords100() => BenchmarkBase.GenerateTestRecords100();
    public static new IEnumerable<object[]> GenerateTestRecords1000() => BenchmarkBase.GenerateTestRecords1000();
}
