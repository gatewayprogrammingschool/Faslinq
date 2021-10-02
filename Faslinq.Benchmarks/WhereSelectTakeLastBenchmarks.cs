namespace Faslinq.Tests.Benchmarks;

#if !NETFRAMEWORK
[TestClass]
public class WhereSelectTakeLastBenchmarks : BenchmarkBase
{
    public WhereSelectTakeLastBenchmarks() : base() { }

#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereSelectTakeLast_1_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> WhereSelectTakeLast_250_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> WhereSelectTakeLast_5000_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> WhereSelectTakeLast_100000_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void WhereSelectTakeLast_Faslinq(object item) => WhereSelectTakeLast_Faslinq(item, LastGenerateRecords1);
    public List<object> WhereSelectTakeLast_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                int toTake = ToTake(list);
                var result = list.WhereSelectTakeLast(i => Predicate((i, LastGenerateRecords250)), Selector, toTake);
#if DEBUG
                Console.WriteLine($"WhereSelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(WhereSelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            int toTake = ToTake(list);
            var result = list.WhereSelectTakeLast(i => Predicate((i, LastGenerateRecords250)), Selector, toTake);
#if DEBUG
            Console.WriteLine($"WhereSelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(WhereSelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereSelectTakeLast_1_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> WhereSelectTakeLast_250_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> WhereSelectTakeLast_5000_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> WhereSelectTakeLast_100000_Linq(object item) => WhereSelectTakeLast_Linq(item, LastGenerateRecords100000);


    public List<object>  WhereSelectTakeLast_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                int toTake = ToTake(enumerable);
                var result = enumerable.Where(i => Predicate((i, LastGenerateRecords250)))
                                        .Select(Selector)
                                        .TakeLast(toTake)
                                        .ToList();
#if DEBUG
                Console.WriteLine($"WhereSelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            int toTake = ToTake(enumerable);
            var result = enumerable.Where(i => Predicate((i, LastGenerateRecords250)))
                                    .Select(Selector)
                                    .TakeLast(toTake)
                                    .ToList();
#if DEBUG
            Console.WriteLine($"WhereSelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
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
#endif
