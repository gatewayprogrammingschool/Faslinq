// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ
#endif

[BenchmarkCategory("Last", "Linq")]
public class LastLinq : LastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords1))]
    public TestValueTuple Last_1_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords250))]
    public TestValueTuple Last_250_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords5000))]
    public TestValueTuple Last_5000_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateRecords100000))]
    public TestValueTuple Last_100000_Linq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
