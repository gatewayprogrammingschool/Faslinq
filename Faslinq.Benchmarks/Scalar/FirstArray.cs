﻿// ReSharper disable InvokeAsExtensionMethod

namespace Faslinq.Benchmarks.Scalar;
#if !NO_FASLINQ

public class FirstArray : FirstBenchmarks
{
    // Arrays
    [Benchmark]
    [BenchmarkCategory("First", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public TestValueTuple First_1_Faslinq(object[] item)
        => ProcessScalar(item, FirstGenerateRecords1);

    [Benchmark]
    [BenchmarkCategory("First", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public TestValueTuple First_250_Faslinq(object[] item)
        => ProcessScalar(item, FirstGenerateRecords250);

    [Benchmark]
    [BenchmarkCategory("First", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public TestValueTuple First_5000_Faslinq(object[] item)
        => ProcessScalar(item, FirstGenerateRecords5000);

    [Benchmark]
    [BenchmarkCategory("First", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public TestValueTuple First_100000_Faslinq(object[] item)
        => ProcessScalar(item, FirstGenerateRecords100000);
}
#endif
