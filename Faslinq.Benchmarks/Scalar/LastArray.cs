// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class LastArray : LastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("Last", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple Last_1_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("Last", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple Last_250_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("Last", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple Last_5000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("Last", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple Last_100000_Faslinq(object item)
        => ProcessScalar(item, LastGenerateRecords100000);
}
#endif
