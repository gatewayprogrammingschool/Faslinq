namespace Faslinq.Tests.Benchmarks;

public abstract class BenchmarkBase
{
    protected BenchmarkBase()
    {
#if !DEBUG
        //System.Diagnostics.Debugger.Launch();
#endif
    }

    public const string FASLINQ = "Faslinq";
    public const string LINQ = "Linq";

    public const string _1 = "1";
    public const string _10 = "10";
    public const string _100 = "100";
    public const string _1000 = "1000";

    protected ListExtensionsTests _tests = new ListExtensionsTests();
    protected static ServiceProvider? _services;

    public static ServiceProvider Services { get => _services ??= GetServices(); }

    public List<object> AnonymousTestData()
        => ListExtensionsTests.GetAnonymousTestData().SelectMany(i => i).ToList();

    public List<TestValueTuple> ValueTupleTestData()
        => ListExtensionsTests.GetValueTupleTestData().SelectMany(i => i).Cast<TestValueTuple>().ToList();

    public List<object[]> TestDataMethodsTestData()
        => ListExtensionsTests.GetTestDataMethodsTestData().ToList();

    public static ServiceProvider GetServices()
    {
        var collection = new ServiceCollection();
        collection.AddGenerators();
        return collection.BuildServiceProvider();
    }

    protected static int ToTake<T>(List<T> list) => Math.Max((int)(list.Count * .2m), 1);
    protected static int ToTake<T>(T[] array) => Math.Max((int)(array.Length * .2m), 1);
    protected static int ToTake<T>(IEnumerable<T> enumerable) => Math.Max((int)(enumerable.Count() * .2m), 1);

    protected static Predicate<(TestValueTuple item, TestValueTuple target)> Predicate =>
        tuple => tuple.item.Item2 != tuple.target.Item2;

    protected static Func<TestValueTuple, string> Selector => item => item.Item2;

    protected static IEnumerable<object>? _generateRecords1;
    protected static IEnumerable<object>? _generateRecords10;
    protected static IEnumerable<object>? _generateRecords100;
    protected static IEnumerable<object>? _generateRecords1000;

    public static TestValueTuple FirstGenerateRecords1 { get; set; }
    public static (int, string, double) LastGenerateRecords1 { get; private set; }
    public static TestValueTuple FirstGenerateRecords10 { get; set; }
    public static (int, string, double) LastGenerateRecords10 { get; private set; }
    public static TestValueTuple FirstGenerateRecords100 { get; set; }
    public static (int, string, double) LastGenerateRecords100 { get; private set; }
    public static TestValueTuple FirstGenerateRecords1000 { get; set; }
    public static (int, string, double) LastGenerateRecords1000 { get; private set; }

    public static IEnumerable<object> GenerateRecords1()
    {
        _generateRecords1 ??= GenerateRecords(1);
        FirstGenerateRecords1 = _generateRecords1!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords1 = _generateRecords1!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords1;
    }

    public static IEnumerable<object[]> GenerateTestRecords1()
    {
        _generateRecords1 ??= GenerateRecords(1);
        FirstGenerateRecords1 = _generateRecords1!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords1 = _generateRecords1!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords1.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords10()
    {
        _generateRecords10 ??= GenerateRecords(10);
        FirstGenerateRecords10 = _generateRecords10!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords10 = _generateRecords10!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords10;
    }

    public static IEnumerable<object[]> GenerateTestRecords10()
    {
        _generateRecords10 ??= GenerateRecords(10);
        FirstGenerateRecords10 = _generateRecords10!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords10 = _generateRecords10!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords10.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords100()
    {
        _generateRecords100 ??= GenerateRecords(100);
        FirstGenerateRecords100 = _generateRecords100!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords100 = _generateRecords100!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords100;
    }

    public static IEnumerable<object[]> GenerateTestRecords100()
    {
        _generateRecords100 ??= GenerateRecords(100);
        FirstGenerateRecords100 = _generateRecords100!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords100 = _generateRecords100!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords100.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords1000()
    {
        _generateRecords1000 ??= GenerateRecords(1000);
        FirstGenerateRecords1000 = _generateRecords1000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords1000 = _generateRecords1000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords1000;
    }

    public static IEnumerable<object[]> GenerateTestRecords1000()
    {
        _generateRecords1000 ??= GenerateRecords(1000);
        FirstGenerateRecords1000 = _generateRecords1000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords1000 = _generateRecords1000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords1000.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords(int count)
    {
        var ints = Services.GetRequiredService<IntegerGenerator>().Generate(0, count).ToList();
        var names = Services.GetRequiredService<NameGenerator>().Generate(0, count).ToList();
        var doubles = ints.Select(i => Math.Pow(Math.PI, i)).ToList();

        yield return new object[]
        {
            Enumerable.Range(0, count)
                         .Select(index => (ints[index],names[index],doubles[index]))
                         .ToList()
        };
    }
}
