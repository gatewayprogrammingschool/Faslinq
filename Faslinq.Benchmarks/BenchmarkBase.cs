using System;
using System.Collections.Generic;
using System.Reflection;

using Faslinq.Benchmarks.Scalar;

// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable ReturnTypeCanBeEnumerable.Local

namespace Faslinq.Benchmarks;
#pragma warning disable CS0693

public abstract class BenchmarkBase
{
    public const string FASLINQ = "Faslinq";
    public const string LINQ = "Linq";

    public const string _1 = "1";
    public const string _250 = "250";
    public const string _5000 = "5000";
    public const string _100000 = "100000";

    public static ServiceProvider ServiceProvider
        => Services ??= GetServices();

    private static TestValueTuple Target { get; set; }

    protected static Func<TestValueTuple, int, bool> Function
        => (tuple, _) => tuple.Item1 == Target.Item1
                         || tuple.Item2 == Target.Item2
                         || tuple.Item3 == Target.Item3;

    protected static Func<dynamic, object> Selector
        => item => item.Item2;

    protected static IEnumerable<TestValueTuple>? Generated1 { get; set; }
    protected static IEnumerable<TestValueTuple>? Generated250 { get; set; }
    protected static IEnumerable<TestValueTuple>? Generated5000 { get; set; }
    protected static IEnumerable<TestValueTuple>? Generated100000 { get; set; }

    public static TestValueTuple FirstGenerated1 { get; set; }
    public static TestValueTuple LastGenerated1 { get; set; }
    public static TestValueTuple FirstGenerated250 { get; set; }
    public static TestValueTuple LastGenerated250 { get; set; }
    public static TestValueTuple FirstGenerated5000 { get; set; }
    public static TestValueTuple LastGenerated5000 { get; set; }
    public static TestValueTuple FirstGenerated100000 { get; set; }
    public static TestValueTuple LastGenerated100000 { get; set; }
    protected static ServiceProvider? Services { get; set; }

    public static ServiceProvider GetServices()
    {

        var collection = new ServiceCollection();
        collection.AddGenerators();
        return collection.BuildServiceProvider();
    }

    protected static int ToTake<T>(List<T> list)
        => Math.Max((int)(list.Count * .2m), 1);

    protected static int ToTake<T>(T[] array)
        => Math.Max((int)(array.Length * .2m), 1);

    protected static int ToTake<T>(IEnumerable<T> enumerable)
        => Math.Max((int)(enumerable.Count() * .2m), 1);

    public static IEnumerable<TestValueTuple> GenerateRecords(Tests test, int count)
    {
        var integers = ServiceProvider.GetRequiredService<IntegerGenerator>()
            .Generate(0, count, 0, Math.Max(1, (int)(count * .01)))
            .ToList();
        var names = ServiceProvider.GetRequiredService<ColorNameGenerator>()
            .Generate(0, count)
            .ToList();
        var doubles = integers
            .Select(i => Math.Pow(Math.PI, i))
            .ToList();

        var data = Enumerable.Range(0, count)
            .Select(index => (integers[index], names[index], doubles[index]));

        _ = count switch
        {
            1 => Generated1 = data,
            250 => Generated250 = data,
            5000 => Generated5000 = data,
            10000 => Generated100000 = data,
            _ => null,
        };

        _ = count switch
        {
            1 => FirstGenerated1 = Generated1!.First(),
            250 => FirstGenerated250 = Generated250!.First(),
            5000 => FirstGenerated5000 = Generated5000!.First(),
            10000 => FirstGenerated100000 = Generated100000!.First(),
            _ => default,
        };

        _ = count switch
        {
            1 => LastGenerated1 = Generated1!.Last(),
            250 => LastGenerated250 = Generated250!.Last(),
            5000 => LastGenerated5000 = Generated5000!.Last(),
            10000 => LastGenerated100000 = Generated100000!.Last(),
            _ => default,
        };

        return test switch
        {
            Tests.List => data.ToList(),
            Tests.Array => data.ToArray(),
            _ => data,
        };
    }

    protected abstract TResult GetScalarByFaslinq<TResult>(List<TResult> list, params object[] values);

    protected abstract TResult GetScalarStructByFaslinq<TResult>(List<TResult> list, params object[] values)
        where TResult : struct;

    protected abstract TResult GetScalarByFaslinq<TResult>(TResult[] array, params object[] values);

    protected abstract TResult GetScalarStructByFaslinq<TResult>(TResult[] array, params object[] values)
        where TResult : struct;

    protected abstract TResult GetScalarByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values);

    protected abstract TResult GetScalarStructByLinq<TResult>(IEnumerable<TResult> enumerable, params object[] values)
        where TResult : struct;

    protected abstract List<TestValueTuple> GetListByFaslinq(List<TestValueTuple> list, params object[] values);
    protected abstract List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values);
    protected abstract TestValueTuple[] GetArrayByArray(TestValueTuple[] array, params object[] values);
    protected abstract TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values);
    protected abstract IEnumerable<TestValueTuple> GetEnumerableByLinq(IEnumerable<TestValueTuple> enumerable, params object[] values);

    protected abstract IEnumerable<TestValueTuple> GetEnumerableStructByLinq(
        IEnumerable<TestValueTuple> enumerable,
        params object[] values
    );

    public TestValueTuple ProcessScalar(object? item, TestValueTuple first)
    {
        if (item is not object[])
        {
            item = new[]
            {
                item,
            };
        }

        TestValueTuple result = default;

        while (item is not null)
        {
            if (item is List<TestValueTuple> list)
            {
                result = ProcessList(list, first);
                break;
            }

            if (item is TestValueTuple[] array)
            {
                result = ProcessArray(array, first);
                break;
            }

            if (item is IEnumerable<TestValueTuple> enumerable)
            {
                result = ProcessEnumerable(enumerable, first);
                break;
            }

            if (item is object[] o)
            {
                item = o[0];
            }
            else
            {
                item = null;
            }
        }

        return result;

        TestValueTuple ProcessEnumerable(IEnumerable<TestValueTuple> enumerable, TestValueTuple first)
        {
            var result = GetScalarStructByLinq(enumerable, first);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.Equals(first)}");
#endif
            return result;
        }

        TestValueTuple ProcessArray(TestValueTuple[] array, TestValueTuple first)
        {
            var result = GetScalarStructByFaslinq(array, first);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.Equals(first)}");
#endif
            return result;
        }

        TestValueTuple ProcessList(List<TestValueTuple> list, TestValueTuple first)
        {
            var result = GetScalarStructByFaslinq(list, first);
#if DEBUG
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.Equals(first)}");
#endif
            return result;
        }
    }

    public IEnumerable<TestValueTuple> ProcessCollection(Tests test, object item, TestValueTuple first)
    {
        //Debugger.Launch();
        //Debugger.Break();

        if (item is not object[])
        {
            item = new[]
            {
                item,
            };
        }

        var empty = test switch
        {
            Tests.List => new List<TestValueTuple>(),
            Tests.Array => Array.Empty<TestValueTuple>(),
            _ => Enumerable.Empty<TestValueTuple>()
        };

        (bool, object[]?) Part1(object obj)
            => (obj is object[] { Length: 1, }, (obj is object[] { Length: 1, } pp)
                ? pp
                : default);

        IEnumerable<TestValueTuple> Part2(object[]? p)
        {
            var p0 = p[0];
            if (p0 is TestValueTuple)
            {
                return p.Cast<TestValueTuple>();
            }

            //Debugger.Break();

            object? next = p0;
            object? last = null;

            do
            {
                last = next;
                next = next switch
                {
                    IEnumerable<TestValueTuple> p1 => empty,
                    object[] p2 => p2.FirstOrDefault() switch
                    {
                        TestValueTuple[] p4 => p4,
                        object[] p7 => p7.Cast<TestValueTuple>().ToArray(),
                        IEnumerable<TestValueTuple> p3 => p3,
                        IEnumerable<object> p6 => p6.Cast<TestValueTuple>(),
                        _ => empty
                    },
                    IEnumerable<object> p5 => p5.FirstOrDefault(),
                    _ => empty
                };
            }
            while (next != empty);

            return last.As<IEnumerable<TestValueTuple>>();
        }

        var p1result = Part1(item);
        var p2result = p1result.Item1 ? Part2(p1result.Item2) : empty;

        //Debugger.Break();

        var result = p2result is IEnumerable<TestValueTuple> p0
            ? test switch
            {
                Tests.List => ProcessList(p0, first),
                Tests.Array => ProcessArray(p0, first),
                Tests.IEnumerable => ProcessEnumerable(p0, first),
                _ => empty,
                //throw new ArgumentException($"This should not happen.  Received {p0.GetType()}"),
            }
            : empty;

        //Debugger.Break();
        return result;

        //: throw new ArgumentException(
        //    $"Received unexpected data: obj is object[] {{Length: 1,}}: {p1result.Item1} && p[0] is IEnumerable<TestValueTuple>: {p2result!.First().Item1}"
        //    + $"\b\tp1result.Item2[0].GetType().FullName: {((object[])p1result.Item2!)[0].GetType().FullName}"
        //);

#pragma warning disable CS8603 // Possible null reference return.
        IEnumerable<TestValueTuple> ProcessEnumerable(IEnumerable<TestValueTuple> enumerable, TestValueTuple first)
        {
            Target = first;
            IEnumerable<TestValueTuple> result = Array.Empty<TestValueTuple>();
            while (enumerable is not null)
            {
                if (enumerable is IEnumerable<TestValueTuple> collection)
                {
#if DEBUG
                    Console.WriteLine($"## Processing Enumerable of Count(): {collection.Count()}");
#endif

                    result = GetEnumerableStructByLinq(collection, first);
                    break;
                }

                enumerable = enumerable.FirstOrDefault().As<IEnumerable<TestValueTuple>>();

                if (enumerable is not null)
                {
                    continue;
                }

                Debugger.Launch();
                Debugger.Break();

            }

#if DEBUG
            Console.WriteLine(
                $"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.FirstOrDefault().Equals(first)}"
            );
#endif
            return result;
        }

        TestValueTuple[] ProcessArray(IEnumerable<TestValueTuple> array, TestValueTuple first)
        {
            Target = first;
            TestValueTuple[] result = Array.Empty<TestValueTuple>();
            while (array is not null)
            {
                if (array is IEnumerable<TestValueTuple> and TestValueTuple[] testArray)
                {
#if DEBUG
                    Console.WriteLine($"## Processing Array of Length: {testArray.Length}");
#endif

                    result = GetStructArrayByFaslinq(testArray, first);
                    break;
                }

                array = array.FirstOrDefault().As<IEnumerable<TestValueTuple>>();

                if (array is not null)
                {
                    continue;
                }

                Debugger.Launch();
                Debugger.Break();
            }

#if DEBUG
            Console.WriteLine(
                $"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.FirstOrDefault().Equals(first)}"
            );
#endif
            return result;
        }

        List<TestValueTuple> ProcessList(IEnumerable<TestValueTuple> list, TestValueTuple first)
        {
            Target = first;
            List<TestValueTuple> result = new();
            while (list is not null)
            {
                if (list is List<TestValueTuple> testList)
                {
#if DEBUG
                    Console.WriteLine($"## Processing List of Count: {testList.Count}");
#endif

                    result = GetStructListByFaslinq(testList, first);
                    break;
                }

                list = list.FirstOrDefault().As<IEnumerable<TestValueTuple>>();
                if (list is not null)
                {
                    continue;
                }

                Debugger.Launch();
                Debugger.Break();
            }

#if DEBUG
            Console.WriteLine(
                $"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.FirstOrDefault().Equals(first)}"
            );
#endif
            return result;
        }
#pragma warning restore CS8603 // Possible null reference return.

    }

    public static IEnumerable<object[]> GenerateTestArray1()
        => GenerateTestArray(Tests.Array, 1);

    public static IEnumerable<object[]> GenerateTestArray250()
        => GenerateTestArray(Tests.Array, 250);

    public static IEnumerable<object[]> GenerateTestArray5000()
        => GenerateTestArray(Tests.Array, 5000);

    public static IEnumerable<object[]> GenerateTestArray100000()
        => GenerateTestArray(Tests.Array, 100000);

    public static IEnumerable<object[]> GenerateTestLinq1()
        => GenerateTestArray(Tests.IEnumerable, 1);

    public static IEnumerable<object[]> GenerateTestLinq250()
        => GenerateTestArray(Tests.IEnumerable, 250);

    public static IEnumerable<object[]> GenerateTestLinq5000()
        => GenerateTestArray(Tests.IEnumerable, 5000);

    public static IEnumerable<object[]> GenerateTestLinq100000()
        => GenerateTestArray(Tests.IEnumerable, 100000);

    public static IEnumerable<object[]> GenerateTestList1()
        => GenerateTestArray(Tests.List, 1);

    public static IEnumerable<object[]> GenerateTestList250()
        => GenerateTestArray(Tests.List, 250);

    public static IEnumerable<object[]> GenerateTestList5000()
        => GenerateTestArray(Tests.List, 5000);

    public static IEnumerable<object[]> GenerateTestList100000()
        => GenerateTestArray(Tests.List, 100000);

    protected static IEnumerable<object[]> GenerateTestArray(Tests test, int count)
    {
        var data = new List<object[]>
        {
            (count switch
            {
                1 => (Generated1 ??= GenerateRecords(test, 1)).Cast<object>(),
                250 => (Generated250 ??= GenerateRecords(test, 250)).Cast<object>(),
                5000 => (Generated5000 ??= GenerateRecords(test, 5000)).Cast<object>(),
                100000 => (Generated100000 ??= GenerateRecords(test, 100000) ).Cast<object>(),
                _ => Enumerable.Empty<object>(),
            }).ToArray(),
        };

        yield return new object[]
        {
            test switch
            {
                Tests.Array => data.ToArray(),
                Tests.List => data,
                _ => data.Cast<object[]>(),
            },
        };
    }

    protected int TakeCount<TData>(IEnumerable<TData> data)
    {
        return (int)(data.Count() * 0.2m);
    }
}

#pragma warning restore CS0693
