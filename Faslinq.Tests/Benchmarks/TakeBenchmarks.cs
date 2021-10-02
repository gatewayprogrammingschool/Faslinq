using System.Collections.Generic;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
public class TakeBenchmarks : BenchmarkBase
{
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void Take_1_Faslinq(object item) => Take_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void Take_250_Faslinq(object item) => Take_Faslinq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void Take_5000_Faslinq(object item) => Take_Faslinq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void Take_100000_Faslinq(object item) => Take_Faslinq(item, FirstGenerateRecords100000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void Take_1_Linq(object item) => Take_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public void Take_250_Linq(object item) => Take_Linq(item, FirstGenerateRecords250);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public void Take_5000_Linq(object item) => Take_Linq(item, FirstGenerateRecords5000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public void Take_100000_Linq(object item) => Take_Linq(item, FirstGenerateRecords100000);

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Take_Faslinq(object item) => Take_Faslinq(item, FirstGenerateRecords1);

    public void Take_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.Take(ToTake(list));
#if DEBUG
                Console.WriteLine($"Take_Faslinq: result.Count: {result.Count}, first: {first}");
                result.Should().BeEquivalentTo(Take_Linq(item, FirstGenerateRecords1));
#endif
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.Take(ToTake(list));
#if DEBUG
            Console.WriteLine($"Take_Faslinq: result.Count: {result.Count}, first: {first}");
            result.Should().BeEquivalentTo(Take_Linq(item, FirstGenerateRecords1));
#endif
        }
        else
        {
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public IEnumerable<object> Take_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
{
                var result = enumerable.Take(ToTake(enumerable)).ToList();
#if DEBUG
                Console.WriteLine($"Take_Linq: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Take(ToTake(enumerable)).ToList();
#if DEBUG
            Console.WriteLine($"Take_Linq: result.Count: {result.Count}, first: {first}");
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
