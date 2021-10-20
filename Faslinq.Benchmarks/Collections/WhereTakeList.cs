﻿namespace Faslinq.Benchmarks.Collections;

public class WhereTakeList : WhereTakeBenchmarks
{
    [Benchmark]
    [BenchmarkCategory("WhereTake", "1", "List")]
    [ArgumentsSource(nameof(GenerateTestList1))]
    public void WhereTake_1_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated1).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "250", "List")]
    [ArgumentsSource(nameof(GenerateTestList250))]
    public void WhereTake_250_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated250).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "5000", "List")]
    [ArgumentsSource(nameof(GenerateTestList5000))]
    public void WhereTake_5000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated5000).Consume(new ());

    [Benchmark]
    [BenchmarkCategory("WhereTake", "100000", "List")]
    [ArgumentsSource(nameof(GenerateTestList100000))]
    public void WhereTake_100000_List(object item)
        => ProcessCollection(Tests.List, item, FirstGenerated100000).Consume(new ());
}
