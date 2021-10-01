namespace Faslinq.Tests.Benchmarks;

#if !NETFRAMEWORK
[TestClass]
public class SelectTakeLastBenchmarks : BenchmarkBase
{
    public SelectTakeLastBenchmarks() : base() { }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> SelectTakeLast_1_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> SelectTakeLast_10_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> SelectTakeLast_100_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> SelectTakeLast_1000_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> SelectTakeLast_1_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public List<object> SelectTakeLast_10_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public List<object> SelectTakeLast_100_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public List<object> SelectTakeLast_1000_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords1000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void SelectTakeLast_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);
    public List<object> SelectTakeLast_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.SelectTakeLast(Selector, ToTake(list));
#if DEBUG
                Console.WriteLine($"SelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
                // result.Should()().BeEquivalentTo(SelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.SelectTakeLast(Selector, ToTake(list));
#if DEBUG
            Console.WriteLine($"SelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
            // result.Should()().BeEquivalentTo(SelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public List<object>  SelectTakeLast_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                var result = enumerable.Select(Selector).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
                Console.WriteLine($"SelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Select(Selector).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
            Console.WriteLine($"SelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
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