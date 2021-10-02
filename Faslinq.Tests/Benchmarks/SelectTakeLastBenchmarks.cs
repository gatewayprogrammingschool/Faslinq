namespace Faslinq.Tests.Benchmarks;

#if !NETFRAMEWORK
[TestClass]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
public class SelectTakeLastBenchmarks : BenchmarkBase
{
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords100000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void SelectTakeLast_1_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void SelectTakeLast_250_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void SelectTakeLast_5000_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void SelectTakeLast_100000_Linq(object item) => SelectTakeLast_Linq(item, LastGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void SelectTakeLast_Faslinq(object item) => SelectTakeLast_Faslinq(item, LastGenerateRecords1);
    public void SelectTakeLast_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.SelectTakeLast(Selector, ToTake(list));
#if DEBUG
                Console.WriteLine($"SelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
                result.Should().BeEquivalentTo(SelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.SelectTakeLast(Selector, ToTake(list));
#if DEBUG
            Console.WriteLine($"SelectTakeLast_Faslinq: result.Count: {result.Count}, first: {first}");
            result.Should().BeEquivalentTo(SelectTakeLast_Linq(item, LastGenerateRecords1));
#endif
        }
        else
        {
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public IEnumerable<object> SelectTakeLast_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                var result = enumerable.Select(Selector).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
                Console.WriteLine($"SelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Select(Selector).TakeLast(ToTake(enumerable)).ToList();
#if DEBUG
            Console.WriteLine($"SelectTakeLast_Linq: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()} length: {(item as object[])?.Length}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public static new IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public static new IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();
}
#endif
