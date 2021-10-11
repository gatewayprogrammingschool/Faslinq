namespace Faslinq.Benchmarks.Collections;

[TestClass]
public class WhereSelectTakeLastLinq : WhereSelectTakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "1", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public void WhereSelectTakeLast_1_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "250", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public void WhereSelectTakeLast_250_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "5000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public void WhereSelectTakeLast_5000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelectTakeLast", "100000", "Linq")]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public void WhereSelectTakeLast_100000_Linq(object item)
        => ProcessCollection(Tests.IEnumerable, item, LastGenerateRecords100000).Consume(new ());
}
