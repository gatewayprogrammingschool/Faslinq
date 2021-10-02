# Benchmark Run at 10/2/2021 2:30:23 AM


```powershell
dotnet publish -c Debug  -f net6.0 -a x64 --self-contained
```


```powershell
.\Faslinq.Benchmarks.exe --runOncePerIteration --join -Select -r net6.0 --platform X64 --keepFiles -e GitHub
```


## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host] : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG

Runtime=.NET 6.0  IterationCount=1  LaunchCount=1  
RunStrategy=ColdStart  UnrollFactor=1  WarmupCount=1  

```
|           Method |      item | Mean | Error | StdDev | Median | Min | Max | Method | Size |     API |
|----------------- |---------- |-----:|------:|-------:|-------:|----:|----:|------- |----- |-------- |
| Select_1_Faslinq | Object[1] |   NA |    NA |     NA |     NA |  NA |  NA | Select |    1 | Faslinq |

Benchmarks with issues:
  SelectBenchmarks.Select_1_Faslinq: Job-CPREMQ(Runtime=.NET 6.0, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1) [item=Object[1]]
