namespace Faslinq.Tests.Benchmarks;

#if !NETFRAMEWORK
[TestClass]
public class WhereTakeLastBenchmarks : BenchmarkBase
{
    public WhereTakeLastBenchmarks() : base() { }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereTakeLast_1_Faslinq(object item) => WhereTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereTakeLast_10_Faslinq(object item) => WhereTakeLast_Faslinq(item, LastGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereTakeLast_100_Faslinq(object item) => WhereTakeLast_Faslinq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereTakeLast_1000_Faslinq(object item) => WhereTakeLast_Faslinq(item, LastGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> WhereTakeLast_1_Linq(object item) => WhereTakeLast_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> WhereTakeLast_10_Linq(object item) => WhereTakeLast_Linq(item, LastGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> WhereTakeLast_100_Linq(object item) => WhereTakeLast_Linq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> WhereTakeLast_1000_Linq(object item) => WhereTakeLast_Linq(item, LastGenerateRecords1000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void WhereTakeLast_Faslinq(object item) => WhereTakeLast_Faslinq(item, LastGenerateRecords1);

    public List<object> WhereTakeLast_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.WhereTakeLast(i => Predicate((i, first)), ToTake(list));
#if DEBUG
                Console.WriteLine($"WhereTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(WhereTakeLast_Linq(item, LastGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.WhereTakeLast(i => Predicate((i, first)), ToTake(list));
#if DEBUG
            Console.WriteLine($"WhereTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(WhereTakeLast_Linq(item, LastGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public List<object>  WhereTakeLast_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
{
                var result = enumerable.Where(i => Predicate((i, first))).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
                Console.WriteLine($"WhereTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Where(i => Predicate((i, first))).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
            Console.WriteLine($"WhereTakeLast_Linq: result.Count: {result.Count}, first: {first}");
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
#endif