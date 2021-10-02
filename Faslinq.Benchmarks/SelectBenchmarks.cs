namespace Faslinq.Tests.Benchmarks;

[TestClass]
public class SelectBenchmarks : BenchmarkBase
{
    public SelectBenchmarks() : base() { }

    public const string CATEGORY = "Select";
    private List<object>? _result;

#if !NO_FASLINQ
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> Select_1_Faslinq(object item)
    {
        _result = Select_Faslinq(item, FirstGenerateRecords1);

#if DEBUG
        //Console.WriteLine($"Select_1_Faslinq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> Select_10_Faslinq(object item)
    {
        _result = Select_Faslinq(item, FirstGenerateRecords250);

#if DEBUG
        //Console.WriteLine($"Select_10_Faslinq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> Select_100_Faslinq(object item)
    {
        _result = Select_Faslinq(item, FirstGenerateRecords5000);

#if DEBUG
        //Console.WriteLine($"Select_100_Faslinq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> Select_1000_Faslinq(object item)
    {
        _result = Select_Faslinq(item, FirstGenerateRecords100000);

#if DEBUG
        //Console.WriteLine($"Select_1000_Faslinq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords250), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords5000), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100000), DynamicDataSourceType.Method)]
    public void Select_Faslinq(object item) => Select_Faslinq(item, FirstGenerateRecords1);

    public List<object> Select_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.Select(Selector);
                return result.Cast<object>().ToList();
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.Select(Selector);
            return result.Cast<object>().ToList();
        }
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }
#endif

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public List<object> Select_1_Linq(object item)
    {
        _result = Select_Linq(item, FirstGenerateRecords1);

#if DEBUG
        //Console.WriteLine($"Select_1_Linq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords250))]
    public List<object> Select_10_Linq(object item)
    {
        _result = Select_Linq(item, FirstGenerateRecords250);

#if DEBUG
        //Console.WriteLine($"Select_10_Linq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords5000))]
    public List<object> Select_100_Linq(object item)
    {
        _result = Select_Linq(item, FirstGenerateRecords5000);

#if DEBUG
        //Console.WriteLine($"Select_100_Linq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100000))]
    public List<object> Select_1000_Linq(object item)
    {
        _result = Select_Linq(item, FirstGenerateRecords1);

#if DEBUG
        //Console.WriteLine($"Select_1000_Linq: result.Count: {_result.Count}, result.LastOrDefault(): {_result.LastOrDefault()}");
#endif

        return _result;
    }

    public List<object>  Select_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                var result = enumerable.Select(Selector).ToList();
                return result.Cast<object>().ToList();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Select(Selector).ToList();
            return result.Cast<object>().ToList();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()} length: {(item as object[])?.Length}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords250() => BenchmarkBase.GenerateTestRecords250();
    public static new IEnumerable<object[]> GenerateTestRecords5000() => BenchmarkBase.GenerateTestRecords5000();
    public static new IEnumerable<object[]> GenerateTestRecords100000() => BenchmarkBase.GenerateTestRecords100000();
}
