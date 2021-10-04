# Benchmark Run at 10/2/2021 3:45:52 PM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```


```powershell
& .\Faslinq.Benchmarks.exe   -Select -Where -Take --platform X64
```


## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |            Mean |         StdDev |         Median |             Min |            Max | Ratio |     API |  LogicalGroup |
|------------------- |----------------:|---------------:|---------------:|----------------:|---------------:|------:|-------- |-------------- |
|           .NET 6.0 |        99.55 ns |       3.710 ns |       100.5 ns |        91.05 ns |       104.9 ns |  0.43 | Faslinq |      Select_1 |
|           .NET 6.0 |       131.33 ns |       4.989 ns |       131.2 ns |       118.85 ns |       141.7 ns |  0.57 |    Linq |      Select_1 |
| .NET Framework 4.8 |       231.52 ns |       7.039 ns |       232.7 ns |       212.38 ns |       242.2 ns |  1.00 | Faslinq |      Select_1 |
| .NET Framework 4.8 |       426.66 ns |      10.603 ns |       426.3 ns |       406.11 ns |       444.6 ns |  1.85 |    Linq |      Select_1 |
|                    |                 |                |                |                 |                |       |         |               |
| .NET Framework 4.8 | 2,532,993.01 ns |  68,916.453 ns | 2,511,298.4 ns | 2,420,391.41 ns | 2,667,848.8 ns |  1.00 | Faslinq | Select_100000 |
|           .NET 6.0 | 2,962,906.35 ns | 144,922.006 ns | 2,975,209.4 ns | 2,556,390.43 ns | 3,299,649.0 ns |  1.16 |    Linq | Select_100000 |
|           .NET 6.0 | 4,206,765.36 ns | 200,964.533 ns | 4,183,398.2 ns | 3,645,002.34 ns | 4,643,857.0 ns |  1.65 | Faslinq | Select_100000 |
| .NET Framework 4.8 | 4,221,875.72 ns | 110,630.203 ns | 4,223,231.2 ns | 4,042,467.97 ns | 4,431,050.8 ns |  1.67 |    Linq | Select_100000 |
|                    |                 |                |                |                 |                |       |         |               |
|           .NET 6.0 |     5,104.91 ns |     159.995 ns |     5,090.5 ns |     4,700.22 ns |     5,392.7 ns |  0.89 |    Linq |    Select_250 |
|           .NET 6.0 |     5,139.48 ns |     138.788 ns |     5,158.8 ns |     4,774.07 ns |     5,431.5 ns |  0.90 | Faslinq |    Select_250 |
| .NET Framework 4.8 |     5,689.07 ns |      91.743 ns |     5,680.5 ns |     5,552.40 ns |     5,871.5 ns |  1.00 | Faslinq |    Select_250 |
| .NET Framework 4.8 |    10,633.29 ns |     282.414 ns |    10,624.5 ns |    10,152.09 ns |    11,220.8 ns |  1.87 |    Linq |    Select_250 |
|                    |                 |                |                |                 |                |       |         |               |
|           .NET 6.0 |    97,588.88 ns |   2,556.324 ns |    97,624.7 ns |    91,508.06 ns |   100,905.6 ns |  0.89 |    Linq |   Select_5000 |
|           .NET 6.0 |   102,503.89 ns |   2,413.219 ns |   102,814.4 ns |    98,271.51 ns |   106,317.6 ns |  0.94 | Faslinq |   Select_5000 |
| .NET Framework 4.8 |   108,995.06 ns |   2,357.877 ns |   108,892.0 ns |   103,518.52 ns |   113,698.1 ns |  1.00 | Faslinq |   Select_5000 |
| .NET Framework 4.8 |   205,363.07 ns |   5,010.317 ns |   205,362.9 ns |   195,617.94 ns |   214,633.7 ns |  1.88 |    Linq |   Select_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |           Mean |       StdDev |         Median |          Min |            Max | Ratio |     API |      LogicalGroup |
|------------------- |---------------:|-------------:|---------------:|-------------:|---------------:|------:|-------- |------------------ |
|           .NET 6.0 |       117.6 ns |      1.56 ns |       117.6 ns |     115.2 ns |       120.8 ns |  0.43 | Faslinq |      SelectTake_1 |
|           .NET 6.0 |       184.5 ns |      5.46 ns |       185.7 ns |     171.5 ns |       196.3 ns |  0.68 |    Linq |      SelectTake_1 |
| .NET Framework 4.8 |       271.7 ns |      9.76 ns |       271.7 ns |     249.8 ns |       289.8 ns |  1.00 | Faslinq |      SelectTake_1 |
| .NET Framework 4.8 |       507.8 ns |     16.30 ns |       511.6 ns |     472.8 ns |       543.4 ns |  1.87 |    Linq |      SelectTake_1 |
|                    |                |              |                |              |                |       |         |                   |
| .NET Framework 4.8 |   503,847.2 ns |  7,629.82 ns |   502,864.6 ns | 489,011.0 ns |   515,402.9 ns |  1.00 | Faslinq | SelectTake_100000 |
|           .NET 6.0 |   542,148.6 ns |  9,485.02 ns |   542,179.0 ns | 526,626.4 ns |   561,490.1 ns |  1.08 |    Linq | SelectTake_100000 |
|           .NET 6.0 |   585,022.1 ns | 34,843.21 ns |   580,475.4 ns | 516,248.4 ns |   662,796.4 ns |  1.17 | Faslinq | SelectTake_100000 |
| .NET Framework 4.8 | 1,006,796.6 ns | 19,362.45 ns | 1,006,060.4 ns | 978,494.3 ns | 1,037,723.4 ns |  2.00 |    Linq | SelectTake_100000 |
|                    |                |              |                |              |                |       |         |                   |
|           .NET 6.0 |     1,359.8 ns |     27.83 ns |     1,361.3 ns |   1,292.7 ns |     1,397.1 ns |  0.88 | Faslinq |    SelectTake_250 |
|           .NET 6.0 |     1,487.6 ns |     23.71 ns |     1,486.0 ns |   1,450.6 ns |     1,536.3 ns |  0.96 |    Linq |    SelectTake_250 |
| .NET Framework 4.8 |     1,559.4 ns |     48.64 ns |     1,566.8 ns |   1,456.9 ns |     1,659.9 ns |  1.00 | Faslinq |    SelectTake_250 |
| .NET Framework 4.8 |     3,180.6 ns |    107.95 ns |     3,187.8 ns |   2,913.4 ns |     3,379.7 ns |  2.04 |    Linq |    SelectTake_250 |
|                    |                |              |                |              |                |       |         |                   |
|           .NET 6.0 |    20,281.0 ns |    500.94 ns |    20,207.7 ns |  19,132.8 ns |    21,215.7 ns |  0.96 | Faslinq |   SelectTake_5000 |
| .NET Framework 4.8 |    21,180.4 ns |    454.85 ns |    21,127.4 ns |  20,329.9 ns |    22,231.7 ns |  1.00 | Faslinq |   SelectTake_5000 |
|           .NET 6.0 |    22,798.9 ns |    235.90 ns |    22,857.0 ns |  22,366.6 ns |    23,172.4 ns |  1.08 |    Linq |   SelectTake_5000 |
| .NET Framework 4.8 |    46,664.2 ns |  1,171.09 ns |    46,362.0 ns |  44,855.4 ns |    48,583.6 ns |  2.21 |    Linq |   SelectTake_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |           Mean |        StdDev |         Median |            Min |            Max | Ratio |     API | LogicalGroup |
|------------------- |---------------:|--------------:|---------------:|---------------:|---------------:|------:|-------- |------------- |
|           .NET 6.0 |       181.6 ns |       6.05 ns |       183.3 ns |       166.6 ns |       193.9 ns |  0.48 | Faslinq |       Take_1 |
|           .NET 6.0 |       219.3 ns |       7.30 ns |       218.8 ns |       204.1 ns |       234.8 ns |  0.58 |    Linq |       Take_1 |
| .NET Framework 4.8 |       375.2 ns |       6.41 ns |       376.0 ns |       361.7 ns |       386.2 ns |  1.00 | Faslinq |       Take_1 |
| .NET Framework 4.8 |       587.6 ns |      20.17 ns |       592.1 ns |       542.0 ns |       620.2 ns |  1.59 |    Linq |       Take_1 |
|                    |                |               |                |                |                |       |         |              |
|           .NET 6.0 | 2,773,425.8 ns | 128,317.68 ns | 2,800,727.0 ns | 2,474,177.3 ns | 3,018,177.7 ns |  0.82 |    Linq |  Take_100000 |
| .NET Framework 4.8 | 3,361,012.6 ns |  91,705.03 ns | 3,364,454.7 ns | 3,170,282.6 ns | 3,549,172.9 ns |  1.00 | Faslinq |  Take_100000 |
|           .NET 6.0 | 3,527,473.2 ns | 145,253.95 ns | 3,533,443.0 ns | 3,206,957.0 ns | 3,795,818.0 ns |  1.04 | Faslinq |  Take_100000 |
| .NET Framework 4.8 | 3,640,244.1 ns | 151,474.59 ns | 3,652,709.6 ns | 3,239,960.9 ns | 3,935,702.3 ns |  1.08 |    Linq |  Take_100000 |
|                    |                |               |                |                |                |       |         |              |
|           .NET 6.0 |     2,380.9 ns |      61.09 ns |     2,389.1 ns |     2,213.5 ns |     2,464.8 ns |  0.79 | Faslinq |     Take_250 |
|           .NET 6.0 |     2,517.8 ns |      40.79 ns |     2,516.8 ns |     2,451.8 ns |     2,585.0 ns |  0.84 |    Linq |     Take_250 |
| .NET Framework 4.8 |     3,015.8 ns |      82.37 ns |     3,025.8 ns |     2,843.1 ns |     3,148.7 ns |  1.00 | Faslinq |     Take_250 |
| .NET Framework 4.8 |     4,802.2 ns |     149.29 ns |     4,820.5 ns |     4,490.9 ns |     5,140.1 ns |  1.60 |    Linq |     Take_250 |
|                    |                |               |                |                |                |       |         |              |
|           .NET 6.0 |    38,775.1 ns |   1,151.31 ns |    38,802.2 ns |    36,209.8 ns |    40,656.4 ns |  0.81 | Faslinq |    Take_5000 |
|           .NET 6.0 |    41,930.7 ns |   1,259.58 ns |    42,141.5 ns |    39,365.9 ns |    43,835.7 ns |  0.88 |    Linq |    Take_5000 |
| .NET Framework 4.8 |    47,705.5 ns |   1,269.32 ns |    47,887.3 ns |    44,219.1 ns |    49,991.5 ns |  1.00 | Faslinq |    Take_5000 |
| .NET Framework 4.8 |    78,308.0 ns |   1,840.30 ns |    78,153.3 ns |    75,728.3 ns |    82,751.6 ns |  1.64 |    Linq |    Take_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |            Mean |        StdDev |          Median |             Min |             Max | Ratio |     API | LogicalGroup |
|------------------- |----------------:|--------------:|----------------:|----------------:|----------------:|------:|-------- |------------- |
|           .NET 6.0 |        134.4 ns |       3.05 ns |        132.9 ns |        129.2 ns |        139.2 ns |  0.47 | Faslinq |      Where_1 |
|           .NET 6.0 |        218.6 ns |       3.19 ns |        218.6 ns |        213.9 ns |        223.1 ns |  0.76 |    Linq |      Where_1 |
| .NET Framework 4.8 |        287.1 ns |       6.61 ns |        286.0 ns |        274.6 ns |        299.8 ns |  1.00 | Faslinq |      Where_1 |
| .NET Framework 4.8 |        543.2 ns |      19.50 ns |        544.1 ns |        500.6 ns |        575.4 ns |  1.86 |    Linq |      Where_1 |
|                    |                 |               |                 |                 |                 |       |         |              |
|           .NET 6.0 | 15,128,019.7 ns | 460,313.30 ns | 15,110,858.6 ns | 14,467,075.8 ns | 16,169,977.3 ns |  0.89 |    Linq | Where_100000 |
|           .NET 6.0 | 15,699,492.1 ns | 640,685.78 ns | 15,658,591.4 ns | 14,361,446.1 ns | 17,073,907.0 ns |  0.93 | Faslinq | Where_100000 |
| .NET Framework 4.8 | 17,038,836.1 ns | 631,422.81 ns | 16,839,403.1 ns | 15,911,412.5 ns | 18,760,800.0 ns |  1.00 | Faslinq | Where_100000 |
| .NET Framework 4.8 | 17,989,760.8 ns | 509,384.12 ns | 17,930,448.4 ns | 17,021,482.8 ns | 19,046,998.4 ns |  1.06 |    Linq | Where_100000 |
|                    |                 |               |                 |                 |                 |       |         |              |
|           .NET 6.0 |     14,237.7 ns |     369.34 ns |     14,179.3 ns |     13,698.9 ns |     15,010.2 ns |  0.79 |    Linq |    Where_250 |
|           .NET 6.0 |     14,338.1 ns |     368.39 ns |     14,335.6 ns |     13,612.9 ns |     15,004.3 ns |  0.79 | Faslinq |    Where_250 |
| .NET Framework 4.8 |     18,082.6 ns |     653.13 ns |     18,080.3 ns |     17,146.3 ns |     19,383.1 ns |  1.00 | Faslinq |    Where_250 |
| .NET Framework 4.8 |     23,630.1 ns |     720.21 ns |     23,646.6 ns |     21,826.9 ns |     24,927.1 ns |  1.31 |    Linq |    Where_250 |
|                    |                 |               |                 |                 |                 |       |         |              |
|           .NET 6.0 |    403,041.0 ns |   9,816.35 ns |    403,609.8 ns |    386,691.7 ns |    426,418.6 ns |  0.84 |    Linq |   Where_5000 |
|           .NET 6.0 |    414,112.1 ns |   6,729.43 ns |    413,890.2 ns |    398,851.8 ns |    426,341.9 ns |  0.86 | Faslinq |   Where_5000 |
| .NET Framework 4.8 |    480,294.1 ns |  13,027.53 ns |    476,618.2 ns |    461,558.5 ns |    513,612.1 ns |  1.00 | Faslinq |   Where_5000 |
| .NET Framework 4.8 |    575,081.6 ns |  16,979.42 ns |    569,166.5 ns |    545,166.0 ns |    601,826.6 ns |  1.20 |    Linq |   Where_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |           Mean |        StdDev |         Median |            Min |            Max | Ratio |     API |       LogicalGroup |
|------------------- |---------------:|--------------:|---------------:|---------------:|---------------:|------:|-------- |------------------- |
|           .NET 6.0 |       120.5 ns |       4.35 ns |       120.9 ns |       112.1 ns |       130.4 ns |  0.48 | Faslinq |      WhereSelect_1 |
|           .NET 6.0 |       185.9 ns |       4.06 ns |       185.4 ns |       178.1 ns |       192.5 ns |  0.75 |    Linq |      WhereSelect_1 |
| .NET Framework 4.8 |       250.1 ns |       8.12 ns |       251.8 ns |       230.0 ns |       261.0 ns |  1.00 | Faslinq |      WhereSelect_1 |
| .NET Framework 4.8 |       464.5 ns |      18.89 ns |       465.6 ns |       426.1 ns |       498.6 ns |  1.88 |    Linq |      WhereSelect_1 |
|                    |                |               |                |                |                |       |         |                    |
|           .NET 6.0 | 4,344,808.9 ns | 287,443.30 ns | 4,349,472.7 ns | 3,791,607.8 ns | 5,117,978.1 ns |  0.99 |    Linq | WhereSelect_100000 |
| .NET Framework 4.8 | 4,435,351.3 ns |  54,856.82 ns | 4,435,880.5 ns | 4,309,532.8 ns | 4,525,953.1 ns |  1.00 | Faslinq | WhereSelect_100000 |
|           .NET 6.0 | 4,496,768.2 ns | 280,830.89 ns | 4,479,793.0 ns | 3,852,109.4 ns | 5,129,489.8 ns |  1.00 | Faslinq | WhereSelect_100000 |
| .NET Framework 4.8 | 6,043,844.5 ns |  89,180.17 ns | 6,051,599.2 ns | 5,852,796.9 ns | 6,212,370.3 ns |  1.36 |    Linq | WhereSelect_100000 |
|                    |                |               |                |                |                |       |         |                    |
|           .NET 6.0 |     8,913.1 ns |     281.69 ns |     8,937.0 ns |     8,311.1 ns |     9,446.5 ns |  0.82 | Faslinq |    WhereSelect_250 |
|           .NET 6.0 |     9,325.7 ns |     247.39 ns |     9,376.6 ns |     8,775.7 ns |     9,677.9 ns |  0.87 |    Linq |    WhereSelect_250 |
| .NET Framework 4.8 |    10,875.3 ns |     373.71 ns |    10,927.2 ns |    10,064.4 ns |    11,540.0 ns |  1.00 | Faslinq |    WhereSelect_250 |
| .NET Framework 4.8 |    15,295.8 ns |     578.11 ns |    15,168.3 ns |    14,327.9 ns |    16,668.0 ns |  1.41 |    Linq |    WhereSelect_250 |
|                    |                |               |                |                |                |       |         |                    |
|           .NET 6.0 |   173,488.5 ns |   5,500.85 ns |   173,353.6 ns |   163,062.2 ns |   183,849.9 ns |  0.83 | Faslinq |   WhereSelect_5000 |
|           .NET 6.0 |   174,116.2 ns |   1,807.21 ns |   174,195.7 ns |   170,962.8 ns |   177,193.1 ns |  0.84 |    Linq |   WhereSelect_5000 |
| .NET Framework 4.8 |   209,279.5 ns |   5,669.12 ns |   209,248.7 ns |   195,186.3 ns |   219,815.6 ns |  1.00 | Faslinq |   WhereSelect_5000 |
| .NET Framework 4.8 |   298,602.9 ns |   7,311.63 ns |   297,850.6 ns |   284,370.3 ns |   315,766.7 ns |  1.43 |    Linq |   WhereSelect_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |           Mean |       StdDev |         Median |            Min |            Max | Ratio |     API |           LogicalGroup |
|------------------- |---------------:|-------------:|---------------:|---------------:|---------------:|------:|-------- |----------------------- |
|           .NET 6.0 |       139.7 ns |      5.58 ns |       139.9 ns |       129.3 ns |       151.7 ns |  0.46 | Faslinq |      WhereSelectTake_1 |
|           .NET 6.0 |       269.0 ns |     10.94 ns |       269.4 ns |       248.4 ns |       290.8 ns |  0.89 |    Linq |      WhereSelectTake_1 |
| .NET Framework 4.8 |       301.9 ns |     11.25 ns |       303.4 ns |       277.4 ns |       328.8 ns |  1.00 | Faslinq |      WhereSelectTake_1 |
| .NET Framework 4.8 |       557.0 ns |     21.60 ns |       556.6 ns |       520.2 ns |       603.3 ns |  1.85 |    Linq |      WhereSelectTake_1 |
|                    |                |              |                |                |                |       |         |                        |
|           .NET 6.0 |   824,260.3 ns | 15,863.64 ns |   823,127.1 ns |   798,496.2 ns |   853,162.5 ns |  0.82 | Faslinq | WhereSelectTake_100000 |
| .NET Framework 4.8 | 1,000,805.6 ns |  8,502.20 ns | 1,000,977.4 ns |   987,481.2 ns | 1,014,062.8 ns |  1.00 | Faslinq | WhereSelectTake_100000 |
|           .NET 6.0 | 1,023,079.8 ns | 25,069.67 ns | 1,027,327.1 ns |   975,497.1 ns | 1,060,739.3 ns |  1.02 |    Linq | WhereSelectTake_100000 |
| .NET Framework 4.8 | 1,380,903.0 ns | 26,551.02 ns | 1,386,450.6 ns | 1,298,737.1 ns | 1,408,994.7 ns |  1.38 |    Linq | WhereSelectTake_100000 |
|                    |                |              |                |                |                |       |         |                        |
|           .NET 6.0 |     2,145.1 ns |     61.49 ns |     2,149.9 ns |     2,015.2 ns |     2,264.2 ns |  0.83 | Faslinq |    WhereSelectTake_250 |
| .NET Framework 4.8 |     2,585.2 ns |     58.25 ns |     2,581.7 ns |     2,482.7 ns |     2,683.2 ns |  1.00 | Faslinq |    WhereSelectTake_250 |
|           .NET 6.0 |     2,832.4 ns |     91.14 ns |     2,825.6 ns |     2,653.8 ns |     3,038.9 ns |  1.10 |    Linq |    WhereSelectTake_250 |
| .NET Framework 4.8 |     4,203.0 ns |    150.23 ns |     4,176.0 ns |     3,924.1 ns |     4,545.6 ns |  1.62 |    Linq |    WhereSelectTake_250 |
|                    |                |              |                |                |                |       |         |                        |
|           .NET 6.0 |    34,240.7 ns |  1,109.76 ns |    34,247.7 ns |    31,763.2 ns |    36,949.2 ns |  0.81 | Faslinq |   WhereSelectTake_5000 |
| .NET Framework 4.8 |    42,256.1 ns |  1,387.61 ns |    42,246.0 ns |    39,285.5 ns |    44,556.6 ns |  1.00 | Faslinq |   WhereSelectTake_5000 |
|           .NET 6.0 |    43,119.5 ns |  1,307.86 ns |    43,425.7 ns |    40,101.5 ns |    45,836.2 ns |  1.02 |    Linq |   WhereSelectTake_5000 |
| .NET Framework 4.8 |    67,447.3 ns |  2,134.60 ns |    67,501.7 ns |    62,124.4 ns |    71,161.5 ns |  1.60 |    Linq |   WhereSelectTake_5000 |
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TDTUEI : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-KVMNFT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```
|            Runtime |           Mean |        StdDev |         Median |            Min |            Max | Ratio |     API |     LogicalGroup |
|------------------- |---------------:|--------------:|---------------:|---------------:|---------------:|------:|-------- |----------------- |
|           .NET 6.0 |       140.1 ns |       3.21 ns |       139.3 ns |       135.1 ns |       145.7 ns |  0.41 | Faslinq |      WhereTake_1 |
|           .NET 6.0 |       232.7 ns |       4.78 ns |       233.1 ns |       225.4 ns |       239.8 ns |  0.69 |    Linq |      WhereTake_1 |
| .NET Framework 4.8 |       339.4 ns |       8.36 ns |       341.2 ns |       311.7 ns |       350.7 ns |  1.00 | Faslinq |      WhereTake_1 |
| .NET Framework 4.8 |       569.0 ns |      19.51 ns |       565.1 ns |       524.9 ns |       613.4 ns |  1.68 |    Linq |      WhereTake_1 |
|                    |                |               |                |                |                |       |         |                  |
| .NET Framework 4.8 | 3,261,031.9 ns |  86,141.66 ns | 3,263,366.0 ns | 3,119,078.1 ns | 3,410,376.2 ns |  1.00 |    Linq | WhereTake_100000 |
|           .NET 6.0 | 3,566,310.6 ns | 150,094.14 ns | 3,572,185.2 ns | 3,184,306.8 ns | 3,827,325.6 ns |  1.09 |    Linq | WhereTake_100000 |
|           .NET 6.0 | 3,639,877.7 ns | 131,041.86 ns | 3,651,908.6 ns | 3,288,368.8 ns | 3,846,250.8 ns |  1.11 | Faslinq | WhereTake_100000 |
| .NET Framework 4.8 | 3,717,259.3 ns | 145,626.44 ns | 3,720,281.2 ns | 3,448,229.5 ns | 4,067,817.4 ns |  1.15 | Faslinq | WhereTake_100000 |
|                    |                |               |                |                |                |       |         |                  |
|           .NET 6.0 |     2,989.2 ns |      48.74 ns |     2,989.3 ns |     2,889.6 ns |     3,075.1 ns |  0.78 | Faslinq |    WhereTake_250 |
|           .NET 6.0 |     3,734.6 ns |     118.19 ns |     3,730.6 ns |     3,520.0 ns |     4,015.9 ns |  0.97 |    Linq |    WhereTake_250 |
| .NET Framework 4.8 |     3,847.9 ns |      71.59 ns |     3,831.0 ns |     3,761.4 ns |     4,007.2 ns |  1.00 | Faslinq |    WhereTake_250 |
| .NET Framework 4.8 |     6,400.1 ns |     177.92 ns |     6,385.9 ns |     6,030.1 ns |     6,656.9 ns |  1.67 |    Linq |    WhereTake_250 |
|                    |                |               |                |                |                |       |         |                  |
|           .NET 6.0 |    51,638.4 ns |   1,500.23 ns |    51,267.1 ns |    48,708.2 ns |    54,617.0 ns |  0.79 | Faslinq |   WhereTake_5000 |
| .NET Framework 4.8 |    65,350.0 ns |   1,555.92 ns |    65,315.9 ns |    62,966.4 ns |    68,447.8 ns |  1.00 | Faslinq |   WhereTake_5000 |
|           .NET 6.0 |    67,337.1 ns |   2,623.73 ns |    66,972.9 ns |    62,699.0 ns |    73,154.6 ns |  1.04 |    Linq |   WhereTake_5000 |
| .NET Framework 4.8 |   109,641.3 ns |   2,432.65 ns |   109,873.7 ns |   106,313.2 ns |   114,173.7 ns |  1.68 |    Linq |   WhereTake_5000 |
