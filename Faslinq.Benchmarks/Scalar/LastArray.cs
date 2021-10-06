// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

[BenchmarkCategory("Last", "Array")]
public class LastArray : LastBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple Last_1_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple Last_250_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple Last_5000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple Last_100000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
#endif
