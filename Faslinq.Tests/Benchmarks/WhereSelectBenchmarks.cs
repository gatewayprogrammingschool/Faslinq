﻿using System.Reflection;

namespace Faslinq.Tests.Benchmarks;

[TestClass]
[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
public class WhereSelectBenchmarks : BenchmarkBase
{
    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelect_1_Faslinq(object item) => WhereSelect_Faslinq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public void WhereSelect_10_Faslinq(object item) => WhereSelect_Faslinq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public void WhereSelect_100_Faslinq(object item) => WhereSelect_Faslinq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public void WhereSelect_1000_Faslinq(object item) => WhereSelect_Faslinq(item, FirstGenerateRecords1000);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelect_1_Linq(object item) => WhereSelect_Linq(item, FirstGenerateRecords1);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords10))]
    public void WhereSelect_10_Linq(object item) => WhereSelect_Linq(item, FirstGenerateRecords10);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords100))]
    public void WhereSelect_100_Linq(object item) => WhereSelect_Linq(item, FirstGenerateRecords100);

    [Benchmark, ArgumentsSource(nameof(GenerateRecords1000))]
    public void WhereSelect_1000_Linq(object item) => WhereSelect_Linq(item, FirstGenerateRecords1000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords10))]
    [DataTestMethod]
    [DynamicData(nameof(GenerateTestRecords1), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords10), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords100), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GenerateTestRecords1000), DynamicDataSourceType.Method)]
    public void WhereSelect_Faslinq(object item) => WhereSelect_Faslinq(item, FirstGenerateRecords1);
    public void WhereSelect_Faslinq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is List<TestValueTuple> list)
            {
                var result = list.WhereSelect(i => Predicate((i, FirstGenerateRecords10)), Selector);
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
                result.Should().BeEquivalentTo(WhereSelect_Linq(item, FirstGenerateRecords1));
#endif
            }
        }
        else if (item is List<TestValueTuple> list)
        {
            var result = list.WhereSelect(i => Predicate((i, FirstGenerateRecords10)), Selector);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
            result.Should().BeEquivalentTo(WhereSelect_Linq(item, FirstGenerateRecords1));
#endif
        }
        else
        {
            throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
        }
    }

    public IEnumerable<object> WhereSelect_Linq(object item, TestValueTuple first)
    {
        if (item is object[] array and { Length: 1 })
        {
            if (array[0] is IEnumerable<TestValueTuple> enumerable)
            {
                var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords10)))
                                        .Select(Selector)
                                        .ToList();
#if DEBUG
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
                return result.Cast<object>();
            }
        }
        else if (item is IEnumerable<TestValueTuple> enumerable)
        {
            var result = enumerable.Where(i => Predicate((i, FirstGenerateRecords10)))
                                    .Select(Selector)
                                    .ToList();
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result.Count: {result.Count}, first: {first}");
#endif
            return result.Cast<object>();
        }
        throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");
    }

    public static new IEnumerable<object[]> GenerateTestRecords1() => BenchmarkBase.GenerateTestRecords1();
    public static new IEnumerable<object[]> GenerateTestRecords10() => BenchmarkBase.GenerateTestRecords10();
    public static new IEnumerable<object[]> GenerateTestRecords100() => BenchmarkBase.GenerateTestRecords100();
    public static new IEnumerable<object[]> GenerateTestRecords1000() => BenchmarkBase.GenerateTestRecords1000();
}