# Benchmark Run at 10/4/2021 10:01:19 PM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```


```powershell
& .\Faslinq.Benchmarks.exe --runOncePerIteration --join -Select -Where --platform X64
```


## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-MKYALJ : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT
  Job-ZCOKZX : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Platform=X64  

```
|            Runtime |          Mean |        StdDev |        Median |           Min |           Max | Ratio |     API |       LogicalGroup |
|------------------- |--------------:|--------------:|--------------:|--------------:|--------------:|------:|-------- |------------------- |
| .NET Framework 4.8 |      5.276 μs |     0.2632 μs |      5.200 μs |      4.900 μs |      6.100 μs |  1.00 | Faslinq |           Select_1 |
|           .NET 6.0 |      5.652 μs |     0.4592 μs |      5.600 μs |      4.800 μs |      6.900 μs |  1.08 | Faslinq |           Select_1 |
|           .NET 6.0 |      5.909 μs |     0.3977 μs |      5.800 μs |      5.300 μs |      7.000 μs |  1.12 |    Linq |           Select_1 |
| .NET Framework 4.8 |      6.637 μs |     0.5604 μs |      6.650 μs |      4.100 μs |      7.900 μs |  1.27 |    Linq |           Select_1 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |  2,993.948 μs |   289.0689 μs |  2,948.200 μs |  2,556.400 μs |  3,932.100 μs |  0.92 |    Linq |      Select_100000 |
| .NET Framework 4.8 |  3,297.678 μs |   308.8310 μs |  3,297.750 μs |  2,615.050 μs |  3,951.050 μs |  1.00 | Faslinq |      Select_100000 |
|           .NET 6.0 |  3,820.510 μs |   323.4516 μs |  3,748.700 μs |  3,226.600 μs |  4,623.000 μs |  1.17 | Faslinq |      Select_100000 |
| .NET Framework 4.8 |  6,489.105 μs |   396.9648 μs |  6,454.100 μs |  5,664.200 μs |  7,625.600 μs |  1.97 |    Linq |      Select_100000 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |     12.606 μs |     0.7471 μs |     12.600 μs |     10.100 μs |     14.500 μs |  0.70 |    Linq |         Select_250 |
|           .NET 6.0 |     15.215 μs |     0.9153 μs |     15.100 μs |     13.700 μs |     17.500 μs |  0.85 | Faslinq |         Select_250 |
| .NET Framework 4.8 |     18.160 μs |     2.2167 μs |     18.950 μs |     14.700 μs |     26.000 μs |  1.00 | Faslinq |         Select_250 |
| .NET Framework 4.8 |     23.288 μs |     1.9526 μs |     23.500 μs |     19.900 μs |     28.400 μs |  1.29 |    Linq |         Select_250 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |    171.588 μs |    20.4067 μs |    168.450 μs |    134.900 μs |    226.900 μs |  0.98 |    Linq |        Select_5000 |
| .NET Framework 4.8 |    175.732 μs |    15.7476 μs |    174.900 μs |    144.200 μs |    219.200 μs |  1.00 | Faslinq |        Select_5000 |
|           .NET 6.0 |    181.422 μs |    21.5261 μs |    175.600 μs |    153.100 μs |    249.600 μs |  1.04 | Faslinq |        Select_5000 |
| .NET Framework 4.8 |    299.722 μs |    31.2678 μs |    289.900 μs |    262.000 μs |    379.600 μs |  1.72 |    Linq |        Select_5000 |
|                    |               |               |               |               |               |       |         |                    |
| .NET Framework 4.8 |      6.300 μs |     0.2533 μs |      6.200 μs |      5.800 μs |      6.900 μs |  1.00 | Faslinq |            Where_1 |
|           .NET 6.0 |      6.599 μs |     0.4885 μs |      6.500 μs |      5.700 μs |      8.000 μs |  1.05 | Faslinq |            Where_1 |
| .NET Framework 4.8 |      7.713 μs |     0.2987 μs |      7.700 μs |      7.100 μs |      8.500 μs |  1.23 |    Linq |            Where_1 |
|           .NET 6.0 |      8.624 μs |     0.3725 μs |      8.700 μs |      7.900 μs |      9.600 μs |  1.37 |    Linq |            Where_1 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 | 10,345.433 μs | 1,000.8598 μs | 10,318.150 μs |  8,495.300 μs | 12,704.000 μs |  0.83 |    Linq |       Where_100000 |
|           .NET 6.0 | 10,769.614 μs |   890.3451 μs | 10,718.850 μs |  8,661.750 μs | 12,629.950 μs |  0.86 | Faslinq |       Where_100000 |
| .NET Framework 4.8 | 12,583.102 μs | 1,182.9412 μs | 12,564.500 μs | 10,086.500 μs | 15,418.000 μs |  1.00 | Faslinq |       Where_100000 |
| .NET Framework 4.8 | 15,487.714 μs | 1,307.4777 μs | 15,492.250 μs | 12,876.150 μs | 19,010.250 μs |  1.24 |    Linq |       Where_100000 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |     34.653 μs |     3.4076 μs |     33.700 μs |     31.800 μs |     48.500 μs |  0.90 | Faslinq |          Where_250 |
| .NET Framework 4.8 |     39.452 μs |     6.3624 μs |     38.800 μs |     30.500 μs |     56.600 μs |  1.00 | Faslinq |          Where_250 |
|           .NET 6.0 |     42.796 μs |    11.1331 μs |     38.550 μs |     32.700 μs |     77.600 μs |  1.10 |    Linq |          Where_250 |
| .NET Framework 4.8 |     48.380 μs |     7.9106 μs |     47.200 μs |     37.200 μs |     68.200 μs |  1.25 |    Linq |          Where_250 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |    576.261 μs |    80.2912 μs |    551.800 μs |    474.700 μs |    830.500 μs |  0.98 |    Linq |         Where_5000 |
| .NET Framework 4.8 |    595.545 μs |    86.0183 μs |    588.700 μs |    468.600 μs |    825.100 μs |  1.00 | Faslinq |         Where_5000 |
|           .NET 6.0 |    607.145 μs |    82.8978 μs |    598.500 μs |    407.900 μs |    831.300 μs |  1.04 | Faslinq |         Where_5000 |
| .NET Framework 4.8 |    734.459 μs |    91.3465 μs |    731.750 μs |    578.200 μs |  1,021.000 μs |  1.26 |    Linq |         Where_5000 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |      5.731 μs |     0.4073 μs |      5.600 μs |      5.100 μs |      6.900 μs |  0.99 | Faslinq |      WhereSelect_1 |
| .NET Framework 4.8 |      5.813 μs |     0.3307 μs |      5.700 μs |      5.300 μs |      6.800 μs |  1.00 | Faslinq |      WhereSelect_1 |
|           .NET 6.0 |      7.138 μs |     0.5279 μs |      7.050 μs |      5.650 μs |      8.450 μs |  1.23 |    Linq |      WhereSelect_1 |
| .NET Framework 4.8 |      7.979 μs |     0.3970 μs |      7.900 μs |      7.200 μs |      9.000 μs |  1.37 |    Linq |      WhereSelect_1 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |  5,640.720 μs |   469.1246 μs |  5,558.000 μs |  4,766.200 μs |  7,000.900 μs |  0.85 |    Linq | WhereSelect_100000 |
|           .NET 6.0 |  5,844.903 μs |   634.8227 μs |  5,688.550 μs |  4,808.600 μs |  7,581.000 μs |  0.88 | Faslinq | WhereSelect_100000 |
| .NET Framework 4.8 |  6,661.845 μs |   464.8549 μs |  6,631.500 μs |  5,912.200 μs |  7,828.500 μs |  1.00 | Faslinq | WhereSelect_100000 |
| .NET Framework 4.8 |  9,558.891 μs |   659.3185 μs |  9,497.600 μs |  8,443.200 μs | 11,230.300 μs |  1.44 |    Linq | WhereSelect_100000 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |     25.104 μs |     1.0846 μs |     24.800 μs |     22.700 μs |     27.800 μs |  0.92 | Faslinq |    WhereSelect_250 |
|           .NET 6.0 |     27.159 μs |     1.4516 μs |     27.000 μs |     24.500 μs |     31.600 μs |  0.98 |    Linq |    WhereSelect_250 |
| .NET Framework 4.8 |     28.160 μs |     2.5261 μs |     28.750 μs |     22.800 μs |     34.100 μs |  1.00 | Faslinq |    WhereSelect_250 |
| .NET Framework 4.8 |     33.913 μs |     2.3460 μs |     33.550 μs |     28.900 μs |     40.800 μs |  1.21 |    Linq |    WhereSelect_250 |
|                    |               |               |               |               |               |       |         |                    |
|           .NET 6.0 |    335.851 μs |    50.7841 μs |    324.700 μs |    234.400 μs |    468.400 μs |  0.98 |    Linq |   WhereSelect_5000 |
| .NET Framework 4.8 |    346.849 μs |    44.7694 μs |    345.400 μs |    274.000 μs |    474.700 μs |  1.00 | Faslinq |   WhereSelect_5000 |
|           .NET 6.0 |    368.924 μs |    68.8514 μs |    356.600 μs |    227.700 μs |    556.500 μs |  1.09 | Faslinq |   WhereSelect_5000 |
| .NET Framework 4.8 |    429.600 μs |    38.5124 μs |    415.350 μs |    384.900 μs |    537.400 μs |  1.26 |    Linq |   WhereSelect_5000 |
