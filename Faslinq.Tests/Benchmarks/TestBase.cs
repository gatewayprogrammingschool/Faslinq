namespace Faslinq.Tests.Benchmarks;

public class BenchmarkBase
{
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
    protected static IEnumerable<object>? _generateRecords250;
    protected static IEnumerable<object>? _generateRecords5000;
    protected static IEnumerable<object>? _generateRecords100000;

    public static TestValueTuple FirstGenerateRecords1 { get; set; }
    public static (int, string, double) LastGenerateRecords1 { get; private set; }
    public static TestValueTuple FirstGenerateRecords250 { get; set; }
    public static (int, string, double) LastGenerateRecords250 { get; private set; }
    public static TestValueTuple FirstGenerateRecords5000 { get; set; }
    public static (int, string, double) LastGenerateRecords5000 { get; private set; }
    public static TestValueTuple FirstGenerateRecords100000 { get; set; }
    public static (int, string, double) LastGenerateRecords100000 { get; private set; }

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

    public static IEnumerable<object> GenerateRecords250()
    {
        _generateRecords250 ??= GenerateRecords(10);
        FirstGenerateRecords250 = _generateRecords250!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords250 = _generateRecords250!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords250;
    }

    public static IEnumerable<object[]> GenerateTestRecords250()
    {
        _generateRecords250 ??= GenerateRecords(10);
        FirstGenerateRecords250 = _generateRecords250!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords250 = _generateRecords250!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords250.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords5000()
    {
        _generateRecords5000 ??= GenerateRecords(100);
        FirstGenerateRecords5000 = _generateRecords5000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords5000 = _generateRecords5000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords5000;
    }

    public static IEnumerable<object[]> GenerateTestRecords5000()
    {
        _generateRecords5000 ??= GenerateRecords(100);
        FirstGenerateRecords5000 = _generateRecords5000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords5000 = _generateRecords5000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords5000.ToArray() };
    }

    public static IEnumerable<object> GenerateRecords100000()
    {
        _generateRecords100000 ??= GenerateRecords(1000);
        FirstGenerateRecords100000 = _generateRecords100000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords100000 = _generateRecords100000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return _generateRecords100000;
    }

    public static IEnumerable<object[]> GenerateTestRecords100000()
    {
        _generateRecords100000 ??= GenerateRecords(1000);
        FirstGenerateRecords100000 = _generateRecords100000!.First().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        LastGenerateRecords100000 = _generateRecords100000!.Last().As<object[]>().First().As<IEnumerable<TestValueTuple>>().First();
        return new[] { _generateRecords100000.ToArray() };
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
