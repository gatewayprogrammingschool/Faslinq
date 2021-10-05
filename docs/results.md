# Benchmark Run at 10/5/2021 6:12:55 PM


```powershell
dotnet publish -c Debug  -f net6.0 -a x64 --self-contained
```


```powershell
& .\Faslinq.Benchmarks.exe --runOncePerIteration --join -Select -Where -Take -TakeLast --platform X64
```


## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG
  Job-GGIJEW : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT
  Job-GTTIEE : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Platform=X64  

```
|            Runtime |     Mean |   StdDev |   Median |      Min |      Max | Ratio |     API | LogicalGroup |
|------------------- |---------:|---------:|---------:|---------:|---------:|------:|-------- |------------- |
| .NET Framework 4.8 |       NA |       NA |       NA |       NA |       NA |     ? | Faslinq |     Select_1 |
|           .NET 6.0 | 2.376 ms | 0.000 ms | 2.376 ms | 2.376 ms | 2.376 ms |     ? | Faslinq |     Select_1 |
| .NET Framework 4.8 | 4.526 ms | 0.000 ms | 4.526 ms | 4.526 ms | 4.526 ms |     ? | Faslinq |     Select_1 |

Benchmarks with issues:
  SelectBenchmarks.Select_1_Faslinq: Job-GGIJEW(Platform=X64, Runtime=.NET Framework 4.8, InvocationCount=1, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1) [item=Object[1]]
