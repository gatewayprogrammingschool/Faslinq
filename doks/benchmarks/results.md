---
# Page settings
layout: page
keywords: Linq Dotnet
---
# Benchmark Run at 10/6/2021 10:48:42 AM


```powershell
dotnet publish -c Debug  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe --runOncePerIteration  -Select --platform X64
```

## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG
  Job-OQGVGN : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-MMTZWH : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-OFFBSW : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT
  Job-MNDRSS : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Platform=X64  Categories=Select,Array  

```

|              Runtime |     Mean |   StdDev |   Median |      Min |      Max | Ratio |   Size |
|--------------------- |---------:|---------:|---------:|---------:|---------:|------:|------- |
|             .NET 5.0 | 2.942 ms | 0.000 ms | 2.942 ms | 2.942 ms | 2.942 ms |  0.95 |      1 |
|             .NET 6.0 | 3.101 ms | 0.000 ms | 3.101 ms | 3.101 ms | 3.101 ms |  1.00 |      1 |
|   .NET Framework 4.8 | 4.736 ms | 0.000 ms | 4.736 ms | 4.736 ms | 4.736 ms |  1.53 |      1 |
| .NET Framework 4.7.2 | 4.763 ms | 0.000 ms | 4.763 ms | 4.763 ms | 4.763 ms |  1.54 |      1 |
|                      |          |          |          |          |          |       |        |
|             .NET 5.0 | 2.999 ms | 0.000 ms | 2.999 ms | 2.999 ms | 2.999 ms |  0.99 | 100000 |
|             .NET 6.0 | 3.026 ms | 0.000 ms | 3.026 ms | 3.026 ms | 3.026 ms |  1.00 | 100000 |
|   .NET Framework 4.8 | 4.567 ms | 0.000 ms | 4.567 ms | 4.567 ms | 4.567 ms |  1.51 | 100000 |
| .NET Framework 4.7.2 | 4.749 ms | 0.000 ms | 4.749 ms | 4.749 ms | 4.749 ms |  1.57 | 100000 |
|                      |          |          |          |          |          |       |        |
|             .NET 6.0 | 2.840 ms | 0.000 ms | 2.840 ms | 2.840 ms | 2.840 ms |  1.00 |    250 |
|             .NET 5.0 | 3.043 ms | 0.000 ms | 3.043 ms | 3.043 ms | 3.043 ms |  1.07 |    250 |
|   .NET Framework 4.8 | 4.600 ms | 0.000 ms | 4.600 ms | 4.600 ms | 4.600 ms |  1.62 |    250 |
| .NET Framework 4.7.2 | 4.719 ms | 0.000 ms | 4.719 ms | 4.719 ms | 4.719 ms |  1.66 |    250 |
|                      |          |          |          |          |          |       |        |
|             .NET 6.0 | 2.836 ms | 0.000 ms | 2.836 ms | 2.836 ms | 2.836 ms |  1.00 |   5000 |
|             .NET 5.0 | 3.230 ms | 0.000 ms | 3.230 ms | 3.230 ms | 3.230 ms |  1.14 |   5000 |
|   .NET Framework 4.8 | 4.524 ms | 0.000 ms | 4.524 ms | 4.524 ms | 4.524 ms |  1.60 |   5000 |
| .NET Framework 4.7.2 | 4.817 ms | 0.000 ms | 4.817 ms | 4.817 ms | 4.817 ms |  1.70 |   5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG
  Job-MMTZWH : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-OQGVGN : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-OFFBSW : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT
  Job-MNDRSS : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Platform=X64  Categories=Select,Linq  

```

|              Runtime |      Mean |   StdDev |    Median |       Min |       Max | Ratio |   Size |
|--------------------- |----------:|---------:|----------:|----------:|----------:|------:|------- |
|             .NET 6.0 |  5.084 ms | 0.000 ms |  5.084 ms |  5.084 ms |  5.084 ms |  1.00 |      1 |
|             .NET 5.0 |  5.373 ms | 0.000 ms |  5.373 ms |  5.373 ms |  5.373 ms |  1.06 |      1 |
|   .NET Framework 4.8 |  8.551 ms | 0.000 ms |  8.551 ms |  8.551 ms |  8.551 ms |  1.68 |      1 |
| .NET Framework 4.7.2 |  8.555 ms | 0.000 ms |  8.555 ms |  8.555 ms |  8.555 ms |  1.68 |      1 |
|                      |           |          |           |           |           |       |        |
| .NET Framework 4.7.2 | 12.906 ms | 0.000 ms | 12.906 ms | 12.906 ms | 12.906 ms |  0.50 | 100000 |
|   .NET Framework 4.8 | 13.203 ms | 0.000 ms | 13.203 ms | 13.203 ms | 13.203 ms |  0.51 | 100000 |
|             .NET 6.0 | 25.973 ms | 0.000 ms | 25.973 ms | 25.973 ms | 25.973 ms |  1.00 | 100000 |
|             .NET 5.0 | 28.314 ms | 0.000 ms | 28.314 ms | 28.314 ms | 28.314 ms |  1.09 | 100000 |
|                      |           |          |           |           |           |       |        |
|             .NET 6.0 |  5.095 ms | 0.000 ms |  5.095 ms |  5.095 ms |  5.095 ms |  1.00 |    250 |
|             .NET 5.0 |  5.605 ms | 0.000 ms |  5.605 ms |  5.605 ms |  5.605 ms |  1.10 |    250 |
| .NET Framework 4.7.2 |  8.193 ms | 0.000 ms |  8.193 ms |  8.193 ms |  8.193 ms |  1.61 |    250 |
|   .NET Framework 4.8 |  9.113 ms | 0.000 ms |  9.113 ms |  9.113 ms |  9.113 ms |  1.79 |    250 |
|                      |           |          |           |           |           |       |        |
|             .NET 6.0 |  6.281 ms | 0.000 ms |  6.281 ms |  6.281 ms |  6.281 ms |  1.00 |   5000 |
|             .NET 5.0 |  6.333 ms | 0.000 ms |  6.333 ms |  6.333 ms |  6.333 ms |  1.01 |   5000 |
|   .NET Framework 4.8 |  8.222 ms | 0.000 ms |  8.222 ms |  8.222 ms |  8.222 ms |  1.31 |   5000 |
| .NET Framework 4.7.2 |  8.811 ms | 0.000 ms |  8.811 ms |  8.811 ms |  8.811 ms |  1.40 |   5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT DEBUG
  Job-MMTZWH : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-OQGVGN : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-MNDRSS : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT
  Job-OFFBSW : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Platform=X64  Categories=Select,List  

```

|              Runtime |      Mean |   StdDev |    Median |       Min |       Max | Ratio |   Size |
|--------------------- |----------:|---------:|----------:|----------:|----------:|------:|------- |
|             .NET 6.0 |  4.947 ms | 0.000 ms |  4.947 ms |  4.947 ms |  4.947 ms |  1.00 |      1 |
|             .NET 5.0 |  5.279 ms | 0.000 ms |  5.279 ms |  5.279 ms |  5.279 ms |  1.07 |      1 |
| .NET Framework 4.7.2 |  6.797 ms | 0.000 ms |  6.797 ms |  6.797 ms |  6.797 ms |  1.37 |      1 |
|   .NET Framework 4.8 |  6.865 ms | 0.000 ms |  6.865 ms |  6.865 ms |  6.865 ms |  1.39 |      1 |
|                      |           |          |           |           |           |       |        |
|   .NET Framework 4.8 | 12.951 ms | 0.000 ms | 12.951 ms | 12.951 ms | 12.951 ms |  0.51 | 100000 |
| .NET Framework 4.7.2 | 13.252 ms | 0.000 ms | 13.252 ms | 13.252 ms | 13.252 ms |  0.52 | 100000 |
|             .NET 6.0 | 25.350 ms | 0.000 ms | 25.350 ms | 25.350 ms | 25.350 ms |  1.00 | 100000 |
|             .NET 5.0 | 26.183 ms | 0.000 ms | 26.183 ms | 26.183 ms | 26.183 ms |  1.03 | 100000 |
|                      |           |          |           |           |           |       |        |
|             .NET 5.0 |  5.039 ms | 0.000 ms |  5.039 ms |  5.039 ms |  5.039 ms |  1.00 |    250 |
|             .NET 6.0 |  5.049 ms | 0.000 ms |  5.049 ms |  5.049 ms |  5.049 ms |  1.00 |    250 |
| .NET Framework 4.7.2 |  6.821 ms | 0.000 ms |  6.821 ms |  6.821 ms |  6.821 ms |  1.35 |    250 |
|   .NET Framework 4.8 |  6.952 ms | 0.000 ms |  6.952 ms |  6.952 ms |  6.952 ms |  1.38 |    250 |
|                      |           |          |           |           |           |       |        |
|             .NET 6.0 |  6.103 ms | 0.000 ms |  6.103 ms |  6.103 ms |  6.103 ms |  1.00 |   5000 |
|             .NET 5.0 |  6.397 ms | 0.000 ms |  6.397 ms |  6.397 ms |  6.397 ms |  1.05 |   5000 |
| .NET Framework 4.7.2 |  7.070 ms | 0.000 ms |  7.070 ms |  7.070 ms |  7.070 ms |  1.16 |   5000 |
|   .NET Framework 4.8 |  7.416 ms | 0.000 ms |  7.416 ms |  7.416 ms |  7.416 ms |  1.22 |   5000 |
