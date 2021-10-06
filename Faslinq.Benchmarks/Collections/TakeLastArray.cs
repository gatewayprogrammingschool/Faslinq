﻿namespace Faslinq.Benchmarks.Collections;

public class TakeLastArray : TakeLastBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("TakeLast", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void TakeLast_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void TakeLast_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void TakeLast_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("TakeLast", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void TakeLast_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, LastGenerateRecords100000).Consume(new ());
}
