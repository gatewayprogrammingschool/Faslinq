---
# Page settings
layout: page
keywords: Linq Dotnet
---
# Benchmark Run at 10/6/2021 9:36:48 AM


```powershell
dotnet publish -c Debug  -f net6.0 -a x64 --self-contained
```


```powershell
& .\Faslinq.Benchmarks.exe --runOncePerIteration  -Select --platform X64
```


## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG
  Job-LUDJNR : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-MOYFVI : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Platform=X64  Categories=Select,Array  

```
|              Runtime |     Mean |   StdDev |   Median |      Min |      Max | Ratio | Size |
|--------------------- |---------:|---------:|---------:|---------:|---------:|------:|----- |
|             .NET 5.0 |       NA |       NA |       NA |       NA |       NA |     ? |    1 |
|             .NET 6.0 | 2.627 ms | 0.000 ms | 2.627 ms | 2.627 ms | 2.627 ms |  1.00 |    1 |
| .NET Framework 4.7.2 | 4.508 ms | 0.000 ms | 4.508 ms | 4.508 ms | 4.508 ms |  1.72 |    1 |

Benchmarks with issues:
  SelectArray.Select_1_Faslinq: Job-UHJABR(Platform=X64, Runtime=.NET 5.0, InvocationCount=1, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1) [item=Object[1]]
