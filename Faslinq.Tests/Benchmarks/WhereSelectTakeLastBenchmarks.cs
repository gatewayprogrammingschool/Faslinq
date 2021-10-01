namespace Faslinq.Tests.Benchmarks;

#if !NETFRAMEWORK
[TestClass]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
public class WhereSelectTakeLastBenchmarks : BenchmarkBase
{
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTakeLast_1_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public void WhereSelectTakeLast_10_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public void WhereSelectTakeLast_100_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public void WhereSelectTakeLast_1000_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTakeLast_1_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public void WhereSelectTakeLast_10_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public void WhereSelectTakeLast_100_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public void WhereSelectTakeLast_1000_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords1000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords1);
    public void WhereSelectTakeLast_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                int toTake = ToTake(list);
                var result = list.WhereSelectTakeLast(i => Predicate((i, LastGenerateRecords10)), Selector, toTake);
#if DEBUG
                Console.WriteLine($"WhereSelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
                result.Should().BeEquivalentTo(WhereSelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            int toTake = ToTake(list);
            var result = list.WhereSelectTakeLast(i => Predicate((i, LastGenerateRecords10)), Selector, toTake);
#if DEBUG
            Console.WriteLine($"WhereSelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
            result.Should().BeEquivalentTo(WhereSelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
        }
        else
        {
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public IEnumerable<object> WhereSelectTakeLast_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                int toTake = ToTake(enumerable);
                var result = enumerable.Where(i => Predicate((i, LastGenerateRecords10)))
                                        .Select(Selector)
                                        .TakeLast(toTake)
                                        .ToList();
#if DEBUG
                Console.WriteLine($"WhereSelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result;
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            int toTake = ToTake(enumerable);
            var result = enumerable.Where(i => Predicate((i, LastGenerateRecords10)))
                                    .Select(Selector)
                                    .TakeLast(toTake)
                                    .ToList();
#if DEBUG
            Console.WriteLine($"WhereSelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
            return result;
        }

        throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords10() => BenchmarkBase.GenerateTestRecords10();
    public static new IEnumerable<object[]> GenerateTestRecords100() => BenchmarkBase.GenerateTestRecords100();
    public static new IEnumerable<object[]> GenerateTestRecords1000() => BenchmarkBase.GenerateTestRecords1000();
}
#endif