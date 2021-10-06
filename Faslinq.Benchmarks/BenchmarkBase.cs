using System.Reflection;

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

    protected static ServiceProvider? Services;

    public static ServiceProvider ServiceProvider
        => Services ??= GetServices();

    private static TestValueTuple Target { get; set; }

    protected static Predicate<TestValueTuple> Predicate
        => tuple => tuple.Item1 == Target.Item1
                    || tuple.Item2 == Target.Item2
                    || tuple.Item3 == Target.Item3;

    protected static Func<TestValueTuple, int, bool> Function
        => (tuple, _) => tuple.Item1 == Target.Item1
                         || tuple.Item2 == Target.Item2
                         || tuple.Item3 == Target.Item3;

    protected static Func<dynamic, object> Selector
        => item => item.Item2;

    protected static IEnumerable<object>? GeneratedRecords1 { get; set; }
    protected static IEnumerable<object>? GeneratedRecords250 { get; set; }
    protected static IEnumerable<object>? GeneratedRecords5000 { get; set; }
    protected static IEnumerable<object>? GeneratedRecords100000 { get; set; }

    public static TestValueTuple FirstGenerateRecords1 { get; set; }
    public static TestValueTuple LastGenerateRecords1 { get; set; }
    public static TestValueTuple FirstGenerateRecords250 { get; set; }
    public static TestValueTuple LastGenerateRecords250 { get; set; }
    public static TestValueTuple FirstGenerateRecords5000 { get; set; }
    public static TestValueTuple LastGenerateRecords5000 { get; set; }
    public static TestValueTuple FirstGenerateRecords100000 { get; set; }
    public static TestValueTuple LastGenerateRecords100000 { get; set; }

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

    public static List<object> GenerateRecords1()
    {
        GeneratedRecords1 ??= GenerateRecords(1);
        FirstGenerateRecords1 = GeneratedRecords1
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords1 = GeneratedRecords1
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return GeneratedRecords1.ToList();
    }

    public static object[] GenerateArray1()
        => GenerateTestRecords1()
            .ToArray();

    public static object[][] GenerateTestRecords1()
    {
        GeneratedRecords1 ??= GenerateRecords(1);
        FirstGenerateRecords1 = GeneratedRecords1
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords1 = GeneratedRecords1
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return new[]
        {
            GeneratedRecords1.ToArray(),
        };
    }

    public static List<object> GenerateRecords250()
    {
        GeneratedRecords250 ??= GenerateRecords(250);
        FirstGenerateRecords250 = GeneratedRecords250
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords250 = GeneratedRecords250
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return GeneratedRecords250.ToList();
    }

    public static object[] GenerateArray250()
        => GenerateTestRecords250()
            .ToArray();

    public static object[][] GenerateTestRecords250()
    {
        GeneratedRecords250 ??= GenerateRecords(250);
        FirstGenerateRecords250 = GeneratedRecords250
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords250 = GeneratedRecords250
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return new[]
        {
            GeneratedRecords250.ToArray(),
        };
    }

    public static List<object> GenerateRecords5000()
    {
        GeneratedRecords5000 ??= GenerateRecords(5000);
        FirstGenerateRecords5000 = GeneratedRecords5000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords5000 = GeneratedRecords5000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return GeneratedRecords5000.ToList();
    }

    public static object[] GenerateArray5000()
        => GenerateTestRecords5000()
            .ToArray();

    public static object[][] GenerateTestRecords5000()
    {
        GeneratedRecords5000 ??= GenerateRecords(5000);
        FirstGenerateRecords5000 = GeneratedRecords5000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords5000 = GeneratedRecords5000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return new[]
        {
            GeneratedRecords5000.ToArray(),
        };
    }

    public static List<object> GenerateRecords100000()
    {
        GeneratedRecords100000 ??= GenerateRecords(100000);
        FirstGenerateRecords100000 = GeneratedRecords100000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords100000 = GeneratedRecords100000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return GeneratedRecords100000.ToList();
    }

    public static object[] GenerateArray100000()
        => GenerateTestRecords100000()
            .ToArray();

    public static object[][] GenerateTestRecords100000()
    {
        GeneratedRecords100000 ??= GenerateRecords(100000);
        FirstGenerateRecords100000 = GeneratedRecords100000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .First()
            .First();
        LastGenerateRecords100000 = GeneratedRecords100000
            .SelectMany(
                i => i.As<object[]>()
                    .Select(ii => ii.As<List<TestValueTuple>>())
            )
            .Last()
            .Last();
        return new[]
        {
            GeneratedRecords100000.ToArray(),
        };
    }

    public static IEnumerable<object> GenerateRecords(int count)
    {
        var integers = ServiceProvider.GetRequiredService<IntegerGenerator>()
            .Generate(0, count)
            .ToList();
        var names = ServiceProvider.GetRequiredService<ColorNameGenerator>()
            .Generate(0, count)
            .ToList();
        var doubles = integers.Select(i => Math.Pow(Math.PI, i))
            .ToList();

        yield return new object[]
        {
            Enumerable.Range(0, count)
                .Select(index => (integers[index], names[index], doubles[index]))
                .ToList(),
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

    protected abstract List<object> GetListByFaslinq(List<object> list, params object[] values);
    protected abstract List<TestValueTuple> GetStructListByFaslinq(List<TestValueTuple> list, params object[] values);
    protected abstract object[] GetArrayByFaslinq(object[] array, params object[] values);
    protected abstract TestValueTuple[] GetStructArrayByFaslinq(TestValueTuple[] array, params object[] values);
    protected abstract IEnumerable<object> GetEnumerableByLinq(IEnumerable<object> enumerable, params object[] values);

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
        if (item is not object[])
        {
            item = new[]
            {
                item,
            };
        }

        //if(test is Tests.Array)
        //{
        //    Debugger.Launch();
        //}

        return item is object[] {Length: 1,} p
            ? test switch
            {
                Tests.List => ProcessList(p[0], first),
                Tests.Array => ProcessArray(p[0], first),
                Tests.IEnumerable => ProcessEnumerable(p[0], first),
                _ => throw new ArgumentException($"Unexpected data.  Received {item.GetType()}"),
            }
            : throw new ArgumentException($"Unexpected data.  Received {item.GetType()}");


#pragma warning disable CS8603 // Possible null reference return.
        IEnumerable<TestValueTuple> ProcessEnumerable(object? enumerable, TestValueTuple first)
        {
            IEnumerable<TestValueTuple> result = Array.Empty<TestValueTuple>();
            while (enumerable is not null)
            {
                if (enumerable is IEnumerable<TestValueTuple> testEnumerable)
                {
                    result = GetEnumerableStructByLinq(testEnumerable, first);
                    break;
                }

                if (enumerable is object[] o)
                {
                    enumerable = o.FirstOrDefault() as IEnumerable<object>;
                }
                else
                {
                    enumerable = null;
                }
            }

#if DEBUG
            Console.WriteLine(
                $"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.FirstOrDefault().Equals(first)}"
            );
#endif
            return result;
        }

        TestValueTuple[] ProcessArray(object? array, TestValueTuple first)
        {
            TestValueTuple[] result = Array.Empty<TestValueTuple>();
            while (array is not null)
            {
                if (array is TestValueTuple[] testArray)
                {
                    result = GetStructArrayByFaslinq(testArray, first);
                    break;
                }

                if (array is object[] o)
                {
                    array = o.FirstOrDefault();
                }
                else
                {
                    array = null;
                }
            }

#if DEBUG
            Console.WriteLine(
                $"{MethodBase.GetCurrentMethod()?.Name}: result == first: {result.FirstOrDefault().Equals(first)}"
            );
#endif
            return result;
        }

        List<TestValueTuple> ProcessList(object? list, TestValueTuple first)
        {
            List<TestValueTuple> result = new();
            while (list is not null)
            {
                if (list is List<TestValueTuple> testList)
                {
                    result = GetStructListByFaslinq(testList, first);
                    break;
                }

                if (list is object[] o)
                {
                    list = o.FirstOrDefault() as IEnumerable<object>;
                }
                else
                {
                    list = null;
                }
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
}

#pragma warning restore CS0693
