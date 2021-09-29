namespace Faslinq.Tests;

public class Program
{
    public static void Main(string[] args)
        => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}

[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
//[SimpleJob(RuntimeMoniker.Net48)]
//[SimpleJob(RuntimeMoniker.NetCoreApp31)]
//[SimpleJob(RuntimeMoniker.CoreRt30)]
//[SimpleJob(RuntimeMoniker.Net50)]
//[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter]
public class ListBenchmarks
{
    private ListExtensionsTests _tests = new ListExtensionsTests();
    private static ServiceProvider? _services;

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

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100))]
    public void Measure(object item)
    {
        if(item is List<TestValueTuple> list)
        {
            var result = list.Where(i => i.Item2 != null);
            Debug.WriteLine($"result.Count: {result.Count}");
        }
    }
    public static IEnumerable<object> GenerateRecords100()
        => GenerateRecords(100);

    public static IEnumerable<object> GenerateRecords(int count)
    {
        var ints = Services.GetRequiredService<IntegerGenerator>().Generate(0, count).ToList();
        var names = Services.GetRequiredService<NameGenerator>().Generate(0, count).ToList();
        var doubles = ints.Select(i => Math.Pow(Math.PI, i)).ToList();

        yield return new object [] 
        {
            Enumerable.Range(0, count)
                         .Select(index => (ints[index],names[index],doubles[index]))
                         .ToList()
        };
    }
}