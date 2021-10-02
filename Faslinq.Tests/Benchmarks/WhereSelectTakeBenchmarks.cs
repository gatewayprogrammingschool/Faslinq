using System.Reflection;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
public class WhereSelectTakeBenchmarks : BenchmarkBase
{
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords100000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTake_1_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTake_250_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTake_5000_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTake_100000_Linq(object item) => WhereSelectTake_Linq(item, FirstGenerateRecords100000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereSelectTake_Faslinq(object item) => WhereSelectTake_Faslinq(item, FirstGenerateRecords1);
    public void WhereSelectTake_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                int toTake = ToTake(list);
                var result = list.WhereSelectTake(i => Predicate((i, FirstGenerateRecords250)), Selector, toTake);
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
                result.Should().BeEquivalentTo(WhereSelectTake_Linq(item, FirstGenerateRecords1));
#endif
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            int toTake = ToTake(list);
            var result = list.WhereSelectTake(i => Predicate((i, FirstGenerateRecords250)), Selector, toTake);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
            result.Should().BeEquivalentTo(WhereSelectTake_Linq(item, FirstGenerateRecords1));
#endif
        }
        else
        {
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public IEnumerable<object> WhereSelectTake_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                int toTake = ToTake(enumerable);
                var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords250)))
                                        .Select(Selector)
                                        .Take(toTake)
                                        .ToList();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            int toTake = ToTake(enumerable);
            var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords250)))
                                    .Select(Selector)
                                    .Take(toTake)
                                    .ToList();
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public static new IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public static new IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();
}
