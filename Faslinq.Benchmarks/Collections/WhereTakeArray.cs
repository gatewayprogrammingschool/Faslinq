﻿namespace Faslinq.Benchmarks.Collections;

public class WhereTakeArray : WhereTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTake", "1", "Array")]
    [ArgumentsSource(nameof(GenerateArray1))]
    public void WhereTake_1_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "250", "Array")]
    [ArgumentsSource(nameof(GenerateArray250))]
    public void WhereTake_250_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateArray5000))]
    public void WhereTake_5000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateArray100000))]
    public void WhereTake_100000_Faslinq(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerateRecords100000).Consume(new ());
}
