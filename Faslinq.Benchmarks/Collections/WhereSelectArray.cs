﻿namespace Faslinq.Benchmarks.Collections;

public class WhereSelectArray : WhereSelectBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereSelect", "1", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray1))]
    public void WhereSelect_1_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "250", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray250))]
    public void WhereSelect_250_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "5000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray5000))]
    public void WhereSelect_5000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereSelect", "100000", "Array")]
    [ArgumentsSource(nameof(GenerateTestArray100000))]
    public void WhereSelect_100000_Array(object[] item)
        => ProcessCollection(Tests.Array, item, FirstGenerated100000).Consume(new ());
}
