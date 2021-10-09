# Benchmark Run at 10/9/2021 2:13:12 AM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe  --join --filter * --platform X64
```

## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-QNHSJO : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-QHCBXU : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-LYNRPI : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT
  Job-CQLHWB : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```

|              Runtime |            Mean |         StdDev |          Median |             Min |             Max |      Ratio |                  Use Case |  Count |               LogicalGroup |    Gen 0 |
|--------------------- |----------------:|---------------:|----------------:|----------------:|----------------:|-----------:|-------------------------- |------- |--------------------------- |---------:|
|             .NET 5.0 |        43.63 ns |       0.642 ns |        43.34 ns |        42.93 ns |        44.66 ns |       0.94 |                Linq:First |      1 |               First:000001 |   0.0114 |
|             .NET 5.0 |        43.72 ns |       0.228 ns |        43.66 ns |        43.32 ns |        44.10 ns |       0.94 |                List:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        46.46 ns |       0.511 ns |        46.31 ns |        45.81 ns |        47.72 ns |       1.00 |                Linq:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        47.72 ns |       0.180 ns |        47.68 ns |        47.45 ns |        48.13 ns |       1.03 |                List:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        54.91 ns |       0.660 ns |        54.78 ns |        54.17 ns |        56.09 ns |       1.18 |               Array:First |      1 |               First:000001 |   0.0114 |
|             .NET 5.0 |        55.69 ns |       0.335 ns |        55.55 ns |        55.29 ns |        56.38 ns |       1.20 |               Array:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       121.96 ns |       0.664 ns |       121.90 ns |       120.86 ns |       123.04 ns |       2.62 |                Linq:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       123.87 ns |       1.906 ns |       125.04 ns |       121.08 ns |       125.99 ns |       2.67 |                Linq:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       124.28 ns |       2.092 ns |       123.39 ns |       121.75 ns |       127.85 ns |       2.68 |                List:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       125.79 ns |       2.339 ns |       125.85 ns |       122.82 ns |       131.58 ns |       2.71 |                List:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       183.99 ns |       2.847 ns |       182.69 ns |       180.97 ns |       189.72 ns |       3.95 |               Array:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       185.44 ns |       2.206 ns |       185.71 ns |       181.48 ns |       188.37 ns |       4.00 |               Array:First |      1 |               First:000001 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.96 ns |       1.146 ns |        43.60 ns |        42.69 ns |        46.85 ns |       0.99 |                Linq:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        44.73 ns |       0.539 ns |        44.61 ns |        44.10 ns |        45.78 ns |       1.00 |                Linq:First |    250 |               First:000250 |   0.0114 |
|             .NET 5.0 |        45.37 ns |       0.651 ns |        45.68 ns |        44.45 ns |        46.06 ns |       1.02 |                List:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        47.08 ns |       0.940 ns |        46.70 ns |        46.13 ns |        49.90 ns |       1.06 |                List:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        54.89 ns |       1.100 ns |        54.83 ns |        53.47 ns |        57.40 ns |       1.23 |               Array:First |    250 |               First:000250 |   0.0114 |
|             .NET 5.0 |        55.99 ns |       0.507 ns |        55.94 ns |        55.25 ns |        56.82 ns |       1.25 |               Array:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       122.92 ns |       1.848 ns |       122.35 ns |       120.77 ns |       126.59 ns |       2.75 |                Linq:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       124.47 ns |       2.005 ns |       123.39 ns |       121.97 ns |       127.06 ns |       2.79 |                List:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       124.50 ns |       1.554 ns |       123.99 ns |       122.93 ns |       127.33 ns |       2.78 |                List:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       124.86 ns |       1.501 ns |       124.37 ns |       122.94 ns |       128.58 ns |       2.79 |                Linq:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       185.16 ns |       2.015 ns |       186.14 ns |       182.62 ns |       187.93 ns |       4.14 |               Array:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       186.23 ns |       1.541 ns |       186.24 ns |       183.74 ns |       189.18 ns |       4.17 |               Array:First |    250 |               First:000250 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.23 ns |       0.299 ns |        43.22 ns |        42.79 ns |        43.91 ns |       0.97 |                List:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        44.36 ns |       0.859 ns |        44.11 ns |        43.36 ns |        45.79 ns |       1.00 |                Linq:First |   5000 |               First:005000 |   0.0114 |
|             .NET 5.0 |        45.75 ns |       0.296 ns |        45.74 ns |        45.32 ns |        46.29 ns |       1.03 |                Linq:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        46.21 ns |       0.721 ns |        46.15 ns |        44.91 ns |        47.41 ns |       1.04 |                List:First |   5000 |               First:005000 |   0.0114 |
|             .NET 5.0 |        53.61 ns |       0.847 ns |        53.47 ns |        52.48 ns |        55.00 ns |       1.21 |               Array:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        54.56 ns |       0.484 ns |        54.44 ns |        53.98 ns |        55.85 ns |       1.23 |               Array:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       122.84 ns |       1.049 ns |       122.78 ns |       121.23 ns |       125.34 ns |       2.77 |                Linq:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       123.21 ns |       0.543 ns |       123.14 ns |       122.63 ns |       124.47 ns |       2.78 |                Linq:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       123.87 ns |       0.992 ns |       123.55 ns |       122.61 ns |       126.48 ns |       2.79 |                List:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       124.19 ns |       0.552 ns |       124.25 ns |       123.04 ns |       124.89 ns |       2.80 |                List:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       182.72 ns |       2.317 ns |       182.22 ns |       179.89 ns |       187.47 ns |       4.11 |               Array:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       183.27 ns |       2.279 ns |       182.23 ns |       179.91 ns |       187.02 ns |       4.13 |               Array:First |   5000 |               First:005000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        45.81 ns |       0.526 ns |        45.68 ns |        45.13 ns |        46.87 ns |       1.00 |                List:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        45.86 ns |       0.593 ns |        45.99 ns |        44.83 ns |        46.63 ns |       1.00 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|             .NET 5.0 |        47.26 ns |       0.930 ns |        47.57 ns |        45.99 ns |        48.78 ns |       1.03 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        48.22 ns |       0.890 ns |        48.14 ns |        46.69 ns |        49.52 ns |       1.05 |                List:First | 100000 |               First:100000 |   0.0114 |
|             .NET 5.0 |        54.35 ns |       0.589 ns |        54.45 ns |        52.54 ns |        55.63 ns |       1.19 |               Array:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        55.12 ns |       0.973 ns |        55.33 ns |        53.39 ns |        57.17 ns |       1.20 |               Array:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       121.80 ns |       0.713 ns |       121.70 ns |       120.65 ns |       123.28 ns |       2.65 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       122.95 ns |       1.045 ns |       122.57 ns |       121.58 ns |       125.39 ns |       2.68 |                Linq:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       123.49 ns |       1.085 ns |       123.20 ns |       121.96 ns |       125.73 ns |       2.69 |                List:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       123.93 ns |       0.877 ns |       123.58 ns |       123.05 ns |       125.69 ns |       2.70 |                List:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       183.63 ns |       1.561 ns |       183.30 ns |       181.34 ns |       186.48 ns |       4.00 |               Array:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       183.73 ns |       0.974 ns |       183.50 ns |       182.40 ns |       185.60 ns |       4.01 |               Array:First | 100000 |               First:100000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        82.37 ns |       1.244 ns |        81.91 ns |        81.07 ns |        84.89 ns |       1.00 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 6.0 |        83.98 ns |       1.332 ns |        83.46 ns |        82.55 ns |        86.76 ns |       1.02 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |        87.15 ns |       1.252 ns |        86.48 ns |        85.59 ns |        88.98 ns |       1.06 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |        87.86 ns |       1.092 ns |        87.78 ns |        86.33 ns |        89.19 ns |       1.07 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 6.0 |        97.60 ns |       1.481 ns |        97.89 ns |        94.68 ns |        99.58 ns |       1.18 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |       100.65 ns |       1.028 ns |       100.48 ns |        99.60 ns |       103.52 ns |       1.22 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       189.94 ns |       2.782 ns |       188.93 ns |       186.77 ns |       194.04 ns |       2.30 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       193.65 ns |       2.354 ns |       192.58 ns |       190.93 ns |       198.62 ns |       2.35 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       193.86 ns |       2.251 ns |       193.03 ns |       191.63 ns |       199.03 ns |       2.35 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       194.72 ns |       2.632 ns |       194.01 ns |       191.55 ns |       199.91 ns |       2.36 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       255.88 ns |       3.615 ns |       256.17 ns |       249.60 ns |       262.81 ns |       3.11 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       261.66 ns |       4.115 ns |       263.72 ns |       254.89 ns |       266.66 ns |       3.18 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        82.60 ns |       1.540 ns |        82.13 ns |        80.42 ns |        86.74 ns |       1.00 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 6.0 |        84.06 ns |       1.437 ns |        83.66 ns |        82.56 ns |        87.27 ns |       1.02 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        85.94 ns |       0.491 ns |        86.07 ns |        85.05 ns |        86.76 ns |       1.04 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        93.19 ns |       1.445 ns |        92.59 ns |        91.66 ns |        96.90 ns |       1.13 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 6.0 |        94.72 ns |       1.174 ns |        94.31 ns |        93.20 ns |        96.97 ns |       1.15 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        97.89 ns |       0.486 ns |        97.97 ns |        96.63 ns |        98.49 ns |       1.19 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       191.21 ns |       2.037 ns |       191.43 ns |       188.45 ns |       194.65 ns |       2.32 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       191.78 ns |       2.762 ns |       190.58 ns |       188.53 ns |       196.85 ns |       2.32 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       192.54 ns |       1.390 ns |       192.11 ns |       191.18 ns |       195.91 ns |       2.33 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       196.76 ns |       1.716 ns |       195.97 ns |       194.69 ns |       199.57 ns |       2.38 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       256.54 ns |       3.157 ns |       255.59 ns |       251.70 ns |       263.35 ns |       3.11 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       259.46 ns |       2.810 ns |       259.02 ns |       253.76 ns |       263.78 ns |       3.14 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        83.84 ns |       0.983 ns |        83.82 ns |        82.63 ns |        86.03 ns |       1.00 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 6.0 |        84.32 ns |       1.155 ns |        84.80 ns |        81.43 ns |        85.13 ns |       1.00 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 5.0 |        86.54 ns |       0.711 ns |        86.35 ns |        85.55 ns |        88.05 ns |       1.03 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 5.0 |        87.15 ns |       0.898 ns |        86.93 ns |        85.90 ns |        88.75 ns |       1.04 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 6.0 |        94.21 ns |       0.964 ns |        94.40 ns |        92.61 ns |        95.59 ns |       1.12 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 5.0 |       100.81 ns |       1.158 ns |       100.54 ns |        99.52 ns |       103.55 ns |       1.20 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       189.42 ns |       0.962 ns |       189.42 ns |       187.90 ns |       190.67 ns |       2.25 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       191.06 ns |       1.823 ns |       190.96 ns |       188.03 ns |       194.11 ns |       2.28 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       192.27 ns |       1.208 ns |       192.37 ns |       189.88 ns |       194.15 ns |       2.29 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       193.52 ns |       1.156 ns |       193.08 ns |       191.61 ns |       195.48 ns |       2.31 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       259.69 ns |       3.226 ns |       258.25 ns |       255.54 ns |       265.35 ns |       3.10 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       259.70 ns |       3.264 ns |       261.06 ns |       255.14 ns |       264.71 ns |       3.10 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        79.64 ns |       0.565 ns |        79.55 ns |        78.84 ns |        80.68 ns |       1.00 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|             .NET 5.0 |        94.06 ns |       1.008 ns |        93.84 ns |        92.33 ns |        96.32 ns |       1.18 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
| .NET Framework 4.7.2 |       191.07 ns |       1.931 ns |       190.74 ns |       188.69 ns |       195.06 ns |       2.40 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|   .NET Framework 4.8 |       194.64 ns |       3.651 ns |       193.42 ns |       191.69 ns |       204.08 ns |       2.45 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        80.67 ns |       1.673 ns |        80.13 ns |        78.28 ns |        85.59 ns |       1.00 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 5.0 |        89.62 ns |       0.881 ns |        89.68 ns |        87.06 ns |        90.57 ns |       1.10 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 5.0 |        99.43 ns |       1.075 ns |        99.28 ns |        97.80 ns |       101.55 ns |       1.22 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 6.0 |       100.60 ns |       2.437 ns |        99.88 ns |        97.00 ns |       106.49 ns |       1.25 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
| .NET Framework 4.7.2 |       189.50 ns |       2.468 ns |       188.62 ns |       186.24 ns |       195.14 ns |       2.33 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|   .NET Framework 4.8 |       193.18 ns |       1.035 ns |       192.90 ns |       191.47 ns |       194.90 ns |       2.38 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|   .NET Framework 4.8 |       254.09 ns |       2.938 ns |       253.41 ns |       250.79 ns |       260.80 ns |       3.12 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
| .NET Framework 4.7.2 |       259.78 ns |       1.818 ns |       259.21 ns |       257.40 ns |       263.42 ns |       3.20 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.49 ns |       0.633 ns |        43.24 ns |        42.55 ns |        44.59 ns |       0.94 |                 List:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 5.0 |        43.79 ns |       0.448 ns |        43.66 ns |        43.11 ns |        44.94 ns |       0.95 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        46.21 ns |       0.426 ns |        46.22 ns |        45.51 ns |        46.97 ns |       1.00 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        48.19 ns |       0.469 ns |        48.03 ns |        47.69 ns |        49.08 ns |       1.04 |                 List:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        54.75 ns |       0.370 ns |        54.61 ns |        54.38 ns |        55.49 ns |       1.19 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 5.0 |        54.79 ns |       0.331 ns |        54.88 ns |        54.19 ns |        55.30 ns |       1.19 |                Array:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       123.67 ns |       1.454 ns |       123.54 ns |       120.81 ns |       125.62 ns |       2.68 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       124.66 ns |       1.816 ns |       124.20 ns |       121.97 ns |       127.36 ns |       2.70 |                 List:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       124.79 ns |       1.370 ns |       124.53 ns |       122.79 ns |       126.89 ns |       2.70 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       124.97 ns |       1.420 ns |       124.45 ns |       123.26 ns |       127.28 ns |       2.70 |                 List:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       183.91 ns |       1.106 ns |       183.89 ns |       182.19 ns |       186.46 ns |       3.98 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       185.67 ns |       2.328 ns |       184.99 ns |       182.15 ns |       189.50 ns |       4.02 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        42.98 ns |       0.153 ns |        42.96 ns |        42.74 ns |        43.27 ns |       0.93 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 5.0 |        44.74 ns |       0.246 ns |        44.73 ns |        44.42 ns |        45.24 ns |       0.96 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        46.43 ns |       0.238 ns |        46.45 ns |        46.06 ns |        46.85 ns |       1.00 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        47.26 ns |       0.618 ns |        47.39 ns |        46.38 ns |        48.12 ns |       1.02 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        54.86 ns |       0.895 ns |        54.58 ns |        53.68 ns |        56.94 ns |       1.18 |                Array:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 5.0 |        64.25 ns |       0.593 ns |        64.02 ns |        63.60 ns |        65.86 ns |       1.38 |                Array:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       123.52 ns |       1.729 ns |       123.28 ns |       120.97 ns |       128.30 ns |       2.66 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       124.83 ns |       1.684 ns |       124.26 ns |       122.57 ns |       127.86 ns |       2.69 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       125.09 ns |       1.637 ns |       124.93 ns |       121.88 ns |       127.70 ns |       2.69 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       125.57 ns |       1.933 ns |       125.60 ns |       122.33 ns |       128.60 ns |       2.71 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       181.92 ns |       2.678 ns |       181.42 ns |       178.89 ns |       187.80 ns |       3.91 |                Array:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       185.60 ns |       3.069 ns |       185.54 ns |       180.54 ns |       190.42 ns |       4.01 |                Array:Last |    250 |                Last:000250 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        44.59 ns |       0.317 ns |        44.51 ns |        44.02 ns |        45.30 ns |       1.00 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 5.0 |        45.05 ns |       1.008 ns |        44.53 ns |        44.05 ns |        47.31 ns |       1.01 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 6.0 |        45.96 ns |       0.456 ns |        46.14 ns |        45.12 ns |        46.45 ns |       1.03 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 5.0 |        46.03 ns |       0.785 ns |        45.78 ns |        45.00 ns |        47.85 ns |       1.03 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 5.0 |        53.34 ns |       0.849 ns |        53.49 ns |        52.14 ns |        55.24 ns |       1.20 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 6.0 |        63.27 ns |       0.794 ns |        63.11 ns |        62.16 ns |        64.67 ns |       1.42 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       122.96 ns |       0.696 ns |       123.19 ns |       121.36 ns |       123.96 ns |       2.76 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       124.10 ns |       1.324 ns |       123.73 ns |       122.56 ns |       126.47 ns |       2.78 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       124.22 ns |       0.654 ns |       124.27 ns |       122.90 ns |       125.34 ns |       2.78 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       124.62 ns |       2.256 ns |       124.06 ns |       121.63 ns |       129.49 ns |       2.79 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       183.30 ns |       1.374 ns |       183.25 ns |       180.29 ns |       185.20 ns |       4.11 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       184.10 ns |       2.043 ns |       183.49 ns |       181.85 ns |       187.55 ns |       4.13 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.36 ns |       0.480 ns |        44.30 ns |        43.19 ns |        45.07 ns |       0.95 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        46.55 ns |       1.021 ns |        46.07 ns |        45.76 ns |        49.66 ns |       1.00 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 5.0 |        48.39 ns |       0.766 ns |        48.64 ns |        47.02 ns |        49.56 ns |       1.04 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        49.18 ns |       0.632 ns |        49.47 ns |        47.92 ns |        49.96 ns |       1.05 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        54.03 ns |       0.718 ns |        53.64 ns |        53.06 ns |        54.94 ns |       1.16 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 5.0 |        54.47 ns |       2.432 ns |        52.91 ns |        52.12 ns |        58.67 ns |       1.20 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       122.82 ns |       0.608 ns |       122.92 ns |       121.89 ns |       123.95 ns |       2.63 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       123.09 ns |       1.128 ns |       123.00 ns |       121.25 ns |       124.90 ns |       2.64 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       123.62 ns |       1.227 ns |       123.94 ns |       121.67 ns |       125.39 ns |       2.64 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       124.49 ns |       0.717 ns |       124.75 ns |       122.71 ns |       125.49 ns |       2.66 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       182.92 ns |       0.891 ns |       182.90 ns |       181.60 ns |       184.62 ns |       3.91 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       185.80 ns |       2.176 ns |       185.31 ns |       183.53 ns |       190.28 ns |       3.98 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        72.73 ns |       1.143 ns |        72.60 ns |        70.93 ns |        74.62 ns |       1.00 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 6.0 |        73.46 ns |       1.371 ns |        73.59 ns |        71.73 ns |        75.49 ns |       1.01 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        75.29 ns |       0.503 ns |        75.15 ns |        74.47 ns |        76.53 ns |       1.04 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        76.91 ns |       0.976 ns |        76.63 ns |        75.53 ns |        78.38 ns |       1.06 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        82.82 ns |       0.485 ns |        82.67 ns |        82.10 ns |        83.72 ns |       1.14 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 6.0 |        94.57 ns |       1.522 ns |        94.74 ns |        92.27 ns |        97.40 ns |       1.30 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|   .NET Framework 4.8 |       181.56 ns |       2.264 ns |       181.73 ns |       177.65 ns |       184.75 ns |       2.50 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|   .NET Framework 4.8 |       182.88 ns |       2.705 ns |       184.10 ns |       178.11 ns |       186.10 ns |       2.51 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
| .NET Framework 4.7.2 |       183.78 ns |       2.911 ns |       184.20 ns |       179.62 ns |       188.23 ns |       2.53 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
| .NET Framework 4.7.2 |       184.00 ns |       2.646 ns |       183.95 ns |       178.66 ns |       188.08 ns |       2.53 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
| .NET Framework 4.7.2 |       244.29 ns |       4.672 ns |       242.30 ns |       238.38 ns |       251.80 ns |       3.37 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|   .NET Framework 4.8 |       249.20 ns |       5.559 ns |       249.75 ns |       241.21 ns |       264.19 ns |       3.44 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        72.14 ns |       1.069 ns |        72.19 ns |        70.80 ns |        73.61 ns |       1.00 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 6.0 |        72.85 ns |       3.636 ns |        70.98 ns |        69.49 ns |        83.08 ns |       1.04 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        74.38 ns |       0.588 ns |        74.25 ns |        73.70 ns |        75.96 ns |       1.03 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        78.80 ns |       0.757 ns |        78.58 ns |        77.63 ns |        79.92 ns |       1.09 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 6.0 |        85.00 ns |       1.098 ns |        84.54 ns |        83.66 ns |        87.26 ns |       1.18 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        89.71 ns |       1.405 ns |        89.53 ns |        87.75 ns |        91.54 ns |       1.24 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
| .NET Framework 4.7.2 |       181.18 ns |       1.575 ns |       180.94 ns |       178.94 ns |       185.06 ns |       2.51 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|   .NET Framework 4.8 |       182.88 ns |       2.162 ns |       182.59 ns |       179.76 ns |       185.71 ns |       2.54 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|   .NET Framework 4.8 |       183.56 ns |       2.337 ns |       183.15 ns |       179.79 ns |       187.77 ns |       2.55 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
| .NET Framework 4.7.2 |       185.54 ns |       2.495 ns |       184.68 ns |       182.60 ns |       190.37 ns |       2.57 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
| .NET Framework 4.7.2 |       243.89 ns |       3.096 ns |       244.96 ns |       237.29 ns |       247.14 ns |       3.38 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|   .NET Framework 4.8 |       249.65 ns |       3.148 ns |       249.68 ns |       244.57 ns |       256.17 ns |       3.46 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        69.92 ns |       1.234 ns |        69.29 ns |        68.52 ns |        72.08 ns |       1.00 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 6.0 |        71.78 ns |       0.383 ns |        71.83 ns |        71.28 ns |        72.38 ns |       1.03 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        79.35 ns |       1.163 ns |        78.95 ns |        78.07 ns |        81.39 ns |       1.13 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        79.59 ns |       0.398 ns |        79.57 ns |        78.88 ns |        80.19 ns |       1.14 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        81.46 ns |       0.584 ns |        81.42 ns |        80.74 ns |        82.86 ns |       1.17 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 6.0 |        83.94 ns |       1.497 ns |        84.90 ns |        81.60 ns |        85.75 ns |       1.20 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|   .NET Framework 4.8 |       182.27 ns |       1.794 ns |       182.15 ns |       179.07 ns |       185.75 ns |       2.61 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
| .NET Framework 4.7.2 |       186.28 ns |       1.352 ns |       186.51 ns |       182.75 ns |       188.22 ns |       2.67 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
| .NET Framework 4.7.2 |       186.51 ns |       2.314 ns |       185.33 ns |       184.06 ns |       190.47 ns |       2.67 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|   .NET Framework 4.8 |       186.74 ns |       1.748 ns |       186.41 ns |       184.22 ns |       190.13 ns |       2.68 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|   .NET Framework 4.8 |       248.10 ns |       2.158 ns |       247.73 ns |       244.02 ns |       252.09 ns |       3.56 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
| .NET Framework 4.7.2 |       248.83 ns |       3.475 ns |       247.51 ns |       243.86 ns |       254.65 ns |       3.56 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        73.86 ns |       1.193 ns |        73.61 ns |        72.21 ns |        75.73 ns |       1.00 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 6.0 |        76.49 ns |       0.991 ns |        76.89 ns |        74.98 ns |        78.11 ns |       1.04 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        83.75 ns |       1.029 ns |        83.72 ns |        82.58 ns |        85.70 ns |       1.14 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        85.37 ns |       1.539 ns |        85.36 ns |        83.48 ns |        89.45 ns |       1.16 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        91.17 ns |       2.435 ns |        91.17 ns |        87.69 ns |        97.05 ns |       1.25 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 6.0 |        92.00 ns |       1.364 ns |        91.94 ns |        89.71 ns |        94.90 ns |       1.25 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
| .NET Framework 4.7.2 |       183.99 ns |       0.762 ns |       184.04 ns |       182.48 ns |       185.02 ns |       2.49 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       184.95 ns |       1.104 ns |       185.09 ns |       182.84 ns |       187.31 ns |       2.50 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       185.33 ns |       3.211 ns |       184.84 ns |       181.04 ns |       190.25 ns |       2.52 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
| .NET Framework 4.7.2 |       186.50 ns |       1.233 ns |       186.29 ns |       184.85 ns |       189.19 ns |       2.53 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       248.26 ns |       2.043 ns |       248.76 ns |       243.91 ns |       251.60 ns |       3.36 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
| .NET Framework 4.7.2 |       248.77 ns |       1.223 ns |       248.70 ns |       246.80 ns |       251.01 ns |       3.37 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.60 ns |       0.678 ns |        41.48 ns |        40.82 ns |        43.04 ns |       1.00 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 5.0 |        47.32 ns |       1.833 ns |        46.57 ns |        45.10 ns |        52.46 ns |       1.14 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|   .NET Framework 4.8 |        90.41 ns |       0.845 ns |        90.29 ns |        89.12 ns |        91.76 ns |       2.17 |              Array:Select |      1 |              Select:000001 |   0.0153 |
| .NET Framework 4.7.2 |        94.69 ns |       3.059 ns |        94.32 ns |        90.54 ns |       103.13 ns |       2.30 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 5.0 |       109.07 ns |       3.176 ns |       107.74 ns |       105.02 ns |       114.96 ns |       2.63 |               List:Select |      1 |              Select:000001 |   0.0648 |
|             .NET 6.0 |       109.79 ns |       3.850 ns |       108.49 ns |       105.12 ns |       119.68 ns |       2.71 |               List:Select |      1 |              Select:000001 |   0.0648 |
| .NET Framework 4.7.2 |       154.98 ns |       2.203 ns |       154.09 ns |       152.96 ns |       160.92 ns |       3.73 |               List:Select |      1 |              Select:000001 |   0.0675 |
|   .NET Framework 4.8 |       160.22 ns |       5.542 ns |       161.37 ns |       150.30 ns |       172.29 ns |       3.89 |               List:Select |      1 |              Select:000001 |   0.0675 |
|             .NET 5.0 |     5,093.11 ns |     101.146 ns |     5,054.23 ns |     4,956.15 ns |     5,322.29 ns |     122.94 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|             .NET 6.0 |     5,226.57 ns |     123.810 ns |     5,193.26 ns |     5,089.34 ns |     5,494.55 ns |     125.71 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
| .NET Framework 4.7.2 |     7,185.17 ns |     107.157 ns |     7,168.40 ns |     7,085.47 ns |     7,469.69 ns |     172.93 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|   .NET Framework 4.8 |     7,279.06 ns |     213.627 ns |     7,198.65 ns |     7,057.18 ns |     7,873.02 ns |     175.54 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.66 ns |       0.841 ns |        43.60 ns |        42.57 ns |        45.64 ns |       0.99 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 6.0 |        43.83 ns |       1.868 ns |        43.27 ns |        41.48 ns |        48.42 ns |       1.00 |              Array:Select |    250 |              Select:000250 |   0.0153 |
| .NET Framework 4.7.2 |        91.82 ns |       1.922 ns |        90.94 ns |        89.85 ns |        96.02 ns |       2.09 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|   .NET Framework 4.8 |        93.23 ns |       2.276 ns |        91.96 ns |        90.86 ns |        97.33 ns |       2.12 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 5.0 |     5,293.70 ns |     151.551 ns |     5,261.49 ns |     5,108.30 ns |     5,625.22 ns |     120.73 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 6.0 |     5,320.09 ns |     183.508 ns |     5,254.86 ns |     5,102.04 ns |     5,893.82 ns |     121.80 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 5.0 |     6,662.88 ns |     213.126 ns |     6,646.22 ns |     6,405.78 ns |     7,286.22 ns |     152.05 |               List:Select |    250 |              Select:000250 |   2.0142 |
|             .NET 6.0 |     7,111.69 ns |     484.040 ns |     6,990.49 ns |     6,462.24 ns |     8,504.25 ns |     166.13 |               List:Select |    250 |              Select:000250 |   2.0142 |
| .NET Framework 4.7.2 |     7,292.18 ns |     143.034 ns |     7,227.52 ns |     7,141.81 ns |     7,543.95 ns |     164.91 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|   .NET Framework 4.8 |     7,304.07 ns |     205.896 ns |     7,222.03 ns |     7,076.41 ns |     7,697.11 ns |     166.56 |               List:Select |    250 |              Select:000250 |   2.0142 |
|   .NET Framework 4.8 |     7,344.44 ns |     167.843 ns |     7,294.28 ns |     7,091.67 ns |     7,602.07 ns |     166.54 |               Linq:Select |    250 |              Select:000250 |   0.0305 |
| .NET Framework 4.7.2 |     7,521.19 ns |     265.429 ns |     7,412.90 ns |     7,190.62 ns |     8,212.62 ns |     171.92 |               List:Select |    250 |              Select:000250 |   2.0142 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        47.04 ns |       2.344 ns |        46.92 ns |        44.00 ns |        53.15 ns |       1.00 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 5.0 |        49.63 ns |       1.100 ns |        49.28 ns |        48.19 ns |        52.11 ns |       1.07 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.42 ns |       2.161 ns |        93.36 ns |        90.43 ns |        98.71 ns |       2.02 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|   .NET Framework 4.8 |        94.71 ns |       2.703 ns |        94.33 ns |        90.79 ns |       102.03 ns |       2.05 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 6.0 |    97,982.04 ns |   3,308.373 ns |    96,541.56 ns |    93,512.51 ns |   109,195.64 ns |   2,110.71 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 5.0 |    99,953.78 ns |   2,108.875 ns |    99,125.85 ns |    97,660.46 ns |   104,165.42 ns |   2,160.74 |               Linq:Select |   5000 |              Select:005000 |        - |
|   .NET Framework 4.8 |   139,539.08 ns |   2,410.210 ns |   138,628.89 ns |   136,793.90 ns |   145,825.93 ns |   3,032.59 |               Linq:Select |   5000 |              Select:005000 |        - |
| .NET Framework 4.7.2 |   146,881.44 ns |   7,782.441 ns |   146,127.15 ns |   137,641.48 ns |   167,521.95 ns |   3,142.51 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 5.0 |   214,686.09 ns |   7,102.999 ns |   213,773.72 ns |   205,110.11 ns |   232,336.43 ns |   4,615.74 |               List:Select |   5000 |              Select:005000 |  90.8203 |
| .NET Framework 4.7.2 |   221,625.63 ns |   4,722.902 ns |   222,063.87 ns |   212,634.47 ns |   228,838.77 ns |   4,805.62 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|             .NET 6.0 |   228,198.29 ns |   3,901.835 ns |   229,975.93 ns |   220,879.15 ns |   232,760.50 ns |   4,946.68 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|   .NET Framework 4.8 |   232,710.80 ns |  20,582.269 ns |   223,890.16 ns |   211,515.19 ns |   289,436.38 ns |   5,064.50 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.45 ns |       1.212 ns |        43.97 ns |        42.83 ns |        46.50 ns |       0.96 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 6.0 |        46.18 ns |       2.329 ns |        45.71 ns |        42.75 ns |        50.99 ns |       1.00 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|   .NET Framework 4.8 |        93.49 ns |       2.399 ns |        92.56 ns |        90.65 ns |        99.62 ns |       2.01 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
| .NET Framework 4.7.2 |        93.75 ns |       0.500 ns |        94.00 ns |        92.91 ns |        94.49 ns |       2.07 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 6.0 | 1,979,094.40 ns |  45,898.486 ns | 1,957,245.70 ns | 1,936,674.80 ns | 2,086,740.43 ns |  42,650.80 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 2,026,749.86 ns |  66,398.417 ns | 2,048,915.04 ns | 1,916,343.75 ns | 2,132,701.95 ns |  43,962.34 |               Linq:Select | 100000 |              Select:100000 |        - |
|   .NET Framework 4.8 | 2,753,520.61 ns |  11,901.314 ns | 2,750,226.37 ns | 2,741,876.95 ns | 2,781,752.34 ns |  60,696.67 |               Linq:Select | 100000 |              Select:100000 |        - |
| .NET Framework 4.7.2 | 2,896,681.78 ns |  90,926.826 ns | 2,858,596.48 ns | 2,746,072.27 ns | 3,115,681.64 ns |  62,844.79 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 3,145,823.86 ns |  25,853.630 ns | 3,146,340.62 ns | 3,097,628.52 ns | 3,191,721.88 ns |  69,412.03 |               List:Select | 100000 |              Select:100000 | 503.9063 |
|   .NET Framework 4.8 | 3,152,672.36 ns |  81,034.503 ns | 3,133,958.98 ns | 3,039,529.69 ns | 3,346,867.58 ns |  67,912.90 |               List:Select | 100000 |              Select:100000 | 460.9375 |
| .NET Framework 4.7.2 | 3,314,625.69 ns |  83,219.419 ns | 3,296,392.19 ns | 3,199,617.19 ns | 3,486,957.03 ns |  71,845.60 |               List:Select | 100000 |              Select:100000 | 457.0313 |
|             .NET 6.0 | 4,579,185.12 ns | 261,190.717 ns | 4,573,965.82 ns | 4,040,421.09 ns | 5,175,831.64 ns |  99,104.13 |               List:Select | 100000 |              Select:100000 | 503.9063 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        44.12 ns |       2.162 ns |        43.45 ns |        41.44 ns |        49.56 ns |       1.00 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |        44.28 ns |       1.516 ns |        43.51 ns |        42.72 ns |        48.08 ns |       1.01 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |        81.49 ns |       3.279 ns |        80.65 ns |        77.69 ns |        92.22 ns |       1.85 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
|             .NET 6.0 |        85.54 ns |       5.791 ns |        84.39 ns |        78.26 ns |        99.02 ns |       1.98 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
| .NET Framework 4.7.2 |        97.21 ns |       3.628 ns |        96.48 ns |        92.48 ns |       107.06 ns |       2.20 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        98.34 ns |       4.118 ns |        98.81 ns |        91.29 ns |       108.92 ns |       2.22 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |        98.98 ns |       1.224 ns |        98.77 ns |        97.06 ns |       100.84 ns |       2.19 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
|             .NET 6.0 |       103.48 ns |       6.952 ns |       101.69 ns |        94.71 ns |       123.22 ns |       2.36 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
|   .NET Framework 4.8 |       156.53 ns |       4.293 ns |       156.11 ns |       150.01 ns |       166.01 ns |       3.54 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
| .NET Framework 4.7.2 |       159.97 ns |       4.020 ns |       160.79 ns |       153.26 ns |       166.70 ns |       3.62 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
|   .NET Framework 4.8 |       257.16 ns |       9.480 ns |       259.73 ns |       243.00 ns |       280.58 ns |       5.81 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
| .NET Framework 4.7.2 |       260.24 ns |      14.463 ns |       256.30 ns |       239.67 ns |       301.39 ns |       5.97 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        45.66 ns |       2.532 ns |        44.89 ns |        42.31 ns |        51.60 ns |       1.00 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 6.0 |        46.23 ns |       3.332 ns |        45.56 ns |        42.16 ns |        56.12 ns |       1.00 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        92.81 ns |       1.622 ns |        92.25 ns |        91.29 ns |        97.60 ns |       2.01 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        95.17 ns |       2.373 ns |        93.96 ns |        92.52 ns |        99.72 ns |       2.09 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 6.0 |     1,221.86 ns |      18.874 ns |     1,223.41 ns |     1,192.76 ns |     1,265.44 ns |      26.48 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,256.94 ns |      26.753 ns |     1,258.53 ns |     1,213.51 ns |     1,309.16 ns |      27.57 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,508.78 ns |      24.823 ns |     1,503.05 ns |     1,465.19 ns |     1,558.37 ns |      32.69 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
|             .NET 6.0 |     1,554.64 ns |      40.410 ns |     1,543.51 ns |     1,491.29 ns |     1,624.25 ns |      33.72 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
| .NET Framework 4.7.2 |     1,777.57 ns |      54.058 ns |     1,783.25 ns |     1,686.43 ns |     1,879.39 ns |      38.50 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
|   .NET Framework 4.8 |     1,788.18 ns |      77.715 ns |     1,754.03 ns |     1,703.74 ns |     1,996.68 ns |      39.30 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
| .NET Framework 4.7.2 |     2,575.08 ns |      25.056 ns |     2,572.66 ns |     2,544.69 ns |     2,631.50 ns |      55.84 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
|   .NET Framework 4.8 |     2,603.01 ns |      82.573 ns |     2,550.16 ns |     2,524.41 ns |     2,785.07 ns |      56.29 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        50.79 ns |       0.548 ns |        50.72 ns |        49.99 ns |        51.93 ns |       1.00 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 6.0 |        50.99 ns |       0.758 ns |        50.90 ns |        49.58 ns |        52.13 ns |       1.00 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        95.16 ns |       3.558 ns |        94.19 ns |        91.00 ns |       105.04 ns |       1.90 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        95.26 ns |       2.225 ns |        94.46 ns |        92.53 ns |        99.87 ns |       1.88 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 6.0 |    21,574.02 ns |     174.322 ns |    21,549.31 ns |    21,291.71 ns |    21,974.14 ns |     423.99 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 5.0 |    21,613.98 ns |     164.278 ns |    21,644.65 ns |    21,232.85 ns |    21,843.27 ns |     424.00 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 5.0 |    25,817.60 ns |     581.608 ns |    25,728.95 ns |    24,895.10 ns |    26,644.63 ns |     506.43 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|             .NET 6.0 |    26,452.02 ns |   1,029.883 ns |    26,562.88 ns |    24,825.81 ns |    29,119.53 ns |     525.27 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|   .NET Framework 4.8 |    28,019.88 ns |     352.719 ns |    27,937.33 ns |    27,630.62 ns |    28,998.36 ns |     549.99 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
| .NET Framework 4.7.2 |    29,057.77 ns |   1,438.586 ns |    28,659.72 ns |    27,429.96 ns |    32,758.26 ns |     573.77 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|   .NET Framework 4.8 |    45,963.62 ns |     632.484 ns |    45,795.67 ns |    44,884.97 ns |    47,394.29 ns |     900.25 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
| .NET Framework 4.7.2 |    47,139.72 ns |   1,518.549 ns |    46,365.14 ns |    45,457.03 ns |    51,116.68 ns |     923.96 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        45.63 ns |       2.499 ns |        45.31 ns |        41.75 ns |        51.88 ns |       1.01 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 6.0 |        45.71 ns |       1.143 ns |        45.29 ns |        44.04 ns |        48.06 ns |       1.00 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        94.66 ns |       2.110 ns |        94.49 ns |        91.28 ns |        97.79 ns |       2.07 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        97.62 ns |       1.395 ns |        96.93 ns |        95.85 ns |       100.44 ns |       2.12 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 6.0 |   403,992.04 ns |   5,743.966 ns |   402,941.14 ns |   397,455.08 ns |   415,588.38 ns |   8,790.05 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 5.0 |   428,318.49 ns |  14,831.032 ns |   424,307.23 ns |   406,040.33 ns |   457,076.03 ns |   9,453.28 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 5.0 |   625,526.46 ns |  11,944.191 ns |   622,522.85 ns |   604,927.73 ns |   648,107.62 ns |  13,692.20 |           List:SelectTake | 100000 |          SelectTake:100000 | 188.4766 |
|   .NET Framework 4.8 |   664,444.20 ns |   7,356.970 ns |   663,490.14 ns |   653,664.26 ns |   675,747.46 ns |  14,428.21 |           List:SelectTake | 100000 |          SelectTake:100000 | 166.9922 |
| .NET Framework 4.7.2 |   674,092.78 ns |  17,263.357 ns |   669,631.93 ns |   640,689.94 ns |   712,149.41 ns |  14,762.49 |           List:SelectTake | 100000 |          SelectTake:100000 | 167.9688 |
|             .NET 6.0 |   753,113.20 ns |  64,080.169 ns |   741,194.78 ns |   630,091.70 ns |   929,536.23 ns |  16,462.86 |           List:SelectTake | 100000 |          SelectTake:100000 | 183.5938 |
| .NET Framework 4.7.2 |   895,766.39 ns |  13,221.252 ns |   893,130.13 ns |   879,619.53 ns |   934,963.96 ns |  19,492.89 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|   .NET Framework 4.8 |   898,292.64 ns |  18,416.731 ns |   890,702.05 ns |   883,361.52 ns |   950,407.71 ns |  19,600.09 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        39.75 ns |       2.245 ns |        39.49 ns |        36.69 ns |        44.71 ns |       1.00 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        44.08 ns |       2.772 ns |        43.32 ns |        40.62 ns |        52.12 ns |       1.11 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        68.35 ns |       2.027 ns |        68.97 ns |        65.07 ns |        72.15 ns |       1.66 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|   .NET Framework 4.8 |        70.62 ns |       3.531 ns |        70.12 ns |        65.26 ns |        79.19 ns |       1.78 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        83.52 ns |       5.170 ns |        82.20 ns |        75.65 ns |        99.44 ns |       2.12 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 6.0 |        86.05 ns |       8.735 ns |        82.01 ns |        77.52 ns |       109.93 ns |       2.19 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 6.0 |        95.90 ns |       5.812 ns |        95.23 ns |        88.02 ns |       109.78 ns |       2.43 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
|             .NET 5.0 |       104.85 ns |       3.241 ns |       103.51 ns |       100.27 ns |       113.51 ns |       2.58 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
|   .NET Framework 4.8 |       162.67 ns |       5.377 ns |       162.16 ns |       153.96 ns |       177.97 ns |       4.00 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       163.61 ns |       8.438 ns |       162.86 ns |       151.25 ns |       185.79 ns |       4.12 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       473.15 ns |      10.219 ns |       470.23 ns |       456.75 ns |       495.48 ns |      11.39 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0963 |
|   .NET Framework 4.8 |       478.07 ns |      17.489 ns |       477.55 ns |       452.62 ns |       522.72 ns |      11.75 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0963 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.43 ns |       0.748 ns |        40.21 ns |        39.62 ns |        42.18 ns |       1.00 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |        41.57 ns |       2.074 ns |        40.70 ns |        39.18 ns |        47.28 ns |       1.03 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        66.98 ns |       1.843 ns |        66.35 ns |        64.59 ns |        70.99 ns |       1.67 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        68.43 ns |       2.416 ns |        67.52 ns |        65.13 ns |        75.67 ns |       1.70 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |     1,303.64 ns |      69.573 ns |     1,272.80 ns |     1,220.69 ns |     1,484.76 ns |      33.12 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0534 |
|             .NET 6.0 |     1,556.82 ns |      44.889 ns |     1,551.22 ns |     1,499.90 ns |     1,668.70 ns |      38.69 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|             .NET 5.0 |     1,620.67 ns |      91.125 ns |     1,584.99 ns |     1,509.39 ns |     1,867.36 ns |      38.84 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,797.35 ns |      63.480 ns |     1,773.95 ns |     1,722.48 ns |     1,983.47 ns |      44.49 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,839.37 ns |      78.810 ns |     1,829.28 ns |     1,746.00 ns |     2,073.24 ns |      46.23 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,942.57 ns |      67.038 ns |     1,920.65 ns |     1,857.53 ns |     2,168.12 ns |      48.26 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0820 |
|   .NET Framework 4.8 |     8,086.02 ns |      53.759 ns |     8,079.45 ns |     7,968.75 ns |     8,186.91 ns |     200.28 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
| .NET Framework 4.7.2 |     8,679.50 ns |     227.453 ns |     8,555.83 ns |     8,435.00 ns |     9,110.42 ns |     216.98 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        36.35 ns |       1.487 ns |        35.81 ns |        34.32 ns |        40.71 ns |       1.00 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        41.34 ns |       1.299 ns |        40.76 ns |        39.82 ns |        44.21 ns |       1.13 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        67.29 ns |       2.689 ns |        65.96 ns |        64.22 ns |        74.70 ns |       1.85 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        67.50 ns |       1.778 ns |        67.56 ns |        64.85 ns |        70.52 ns |       1.84 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |    22,422.97 ns |     810.690 ns |    22,064.00 ns |    21,417.39 ns |    24,843.71 ns |     616.12 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0305 |
|             .NET 5.0 |    26,613.98 ns |   1,309.361 ns |    26,091.95 ns |    25,239.83 ns |    30,240.58 ns |     735.60 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    26,698.17 ns |     820.190 ns |    26,601.65 ns |    25,518.18 ns |    29,205.10 ns |     730.69 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    28,327.05 ns |     821.195 ns |    27,966.42 ns |    27,398.44 ns |    30,310.70 ns |     770.34 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    29,777.75 ns |   1,374.582 ns |    29,595.93 ns |    27,917.32 ns |    33,578.78 ns |     822.76 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    35,520.94 ns |   1,763.757 ns |    35,624.79 ns |    32,000.19 ns |    39,701.92 ns |     981.69 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |   150,586.69 ns |   2,993.234 ns |   149,272.36 ns |   147,526.39 ns |   157,665.19 ns |   4,081.19 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
|   .NET Framework 4.8 |   151,807.93 ns |   3,328.878 ns |   150,495.48 ns |   148,636.79 ns |   158,791.46 ns |   4,119.25 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.97 ns |       3.195 ns |        38.05 ns |        34.70 ns |        48.26 ns |       1.00 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        45.16 ns |       0.935 ns |        45.47 ns |        43.48 ns |        46.68 ns |       1.19 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        68.09 ns |       2.667 ns |        66.85 ns |        65.46 ns |        75.82 ns |       1.77 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        70.50 ns |       5.226 ns |        69.43 ns |        64.95 ns |        84.02 ns |       1.82 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |   429,827.93 ns |  11,853.946 ns |   429,783.74 ns |   408,365.72 ns |   448,929.20 ns |  11,460.22 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|             .NET 5.0 |   621,182.98 ns |  13,489.250 ns |   620,795.02 ns |   597,375.39 ns |   647,774.41 ns |  16,438.30 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 187.5000 |
|             .NET 6.0 |   668,654.57 ns |  10,834.109 ns |   668,192.29 ns |   648,665.53 ns |   686,318.95 ns |  17,961.87 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|   .NET Framework 4.8 |   676,551.68 ns |  12,437.914 ns |   677,436.33 ns |   645,872.66 ns |   696,989.16 ns |  18,296.03 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 167.9688 |
| .NET Framework 4.7.2 |   735,788.10 ns |  16,372.320 ns |   730,019.04 ns |   705,205.66 ns |   777,524.71 ns |  19,473.52 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 171.8750 |
|             .NET 6.0 |   750,808.56 ns |  49,790.899 ns |   751,305.76 ns |   655,763.67 ns |   879,302.73 ns |  19,364.33 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 176.7578 |
|   .NET Framework 4.8 | 3,081,563.14 ns |  85,353.653 ns | 3,049,705.66 ns | 2,978,877.15 ns | 3,280,174.41 ns |  82,188.22 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
| .NET Framework 4.7.2 | 3,119,543.18 ns |  45,237.868 ns | 3,115,839.84 ns | 3,053,083.20 ns | 3,216,356.25 ns |  83,770.44 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        50.68 ns |       1.124 ns |        50.56 ns |        49.52 ns |        54.03 ns |       1.00 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 5.0 |        58.87 ns |       4.079 ns |        58.00 ns |        53.81 ns |        70.20 ns |       1.17 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 6.0 |        64.01 ns |       1.920 ns |        64.14 ns |        60.58 ns |        68.18 ns |       1.27 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        71.39 ns |       3.038 ns |        71.23 ns |        66.59 ns |        78.97 ns |       1.40 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        76.38 ns |       1.172 ns |        75.89 ns |        74.83 ns |        79.09 ns |       1.51 |                 List:Take |      1 |                Take:000001 |   0.0459 |
|             .NET 6.0 |        78.85 ns |       1.348 ns |        78.42 ns |        77.70 ns |        82.91 ns |       1.55 |                 List:Take |      1 |                Take:000001 |   0.0459 |
| .NET Framework 4.7.2 |       147.55 ns |       4.340 ns |       147.93 ns |       141.62 ns |       158.59 ns |       2.91 |                 List:Take |      1 |                Take:000001 |   0.0484 |
|   .NET Framework 4.8 |       151.13 ns |       5.217 ns |       151.00 ns |       142.10 ns |       164.59 ns |       2.98 |                 List:Take |      1 |                Take:000001 |   0.0484 |
| .NET Framework 4.7.2 |       214.86 ns |       6.765 ns |       212.22 ns |       205.91 ns |       228.19 ns |       4.24 |                Array:Take |      1 |                Take:000001 |   0.0305 |
|   .NET Framework 4.8 |       215.90 ns |       8.325 ns |       216.74 ns |       204.79 ns |       233.39 ns |       4.25 |                Array:Take |      1 |                Take:000001 |   0.0305 |
|   .NET Framework 4.8 |       218.21 ns |       6.330 ns |       215.84 ns |       209.05 ns |       229.06 ns |       4.28 |                 Linq:Take |      1 |                Take:000001 |   0.0391 |
| .NET Framework 4.7.2 |       222.21 ns |       9.659 ns |       219.25 ns |       209.62 ns |       246.34 ns |       4.41 |                 Linq:Take |      1 |                Take:000001 |   0.0393 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        52.78 ns |       1.456 ns |        52.34 ns |        51.06 ns |        57.25 ns |       0.95 |                Array:Take |    250 |                Take:000250 |   0.0293 |
|             .NET 6.0 |        54.87 ns |       3.787 ns |        53.40 ns |        50.27 ns |        65.20 ns |       1.00 |                Array:Take |    250 |                Take:000250 |   0.0293 |
| .NET Framework 4.7.2 |       208.23 ns |       1.187 ns |       208.21 ns |       205.67 ns |       210.23 ns |       3.82 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|   .NET Framework 4.8 |       211.47 ns |       3.997 ns |       210.02 ns |       207.39 ns |       223.01 ns |       3.91 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|             .NET 6.0 |       906.88 ns |       6.091 ns |       907.30 ns |       897.19 ns |       917.50 ns |      16.71 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 5.0 |       980.32 ns |      65.631 ns |       968.78 ns |       901.74 ns |     1,134.35 ns |      17.91 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 6.0 |     1,298.07 ns |      26.631 ns |     1,298.26 ns |     1,255.05 ns |     1,354.38 ns |      23.69 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|             .NET 5.0 |     1,326.73 ns |      51.259 ns |     1,303.23 ns |     1,255.03 ns |     1,472.75 ns |      23.83 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,463.14 ns |      17.251 ns |     1,464.80 ns |     1,427.76 ns |     1,486.41 ns |      27.06 |                 List:Take |    250 |                Take:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,469.03 ns |      33.396 ns |     1,462.25 ns |     1,430.90 ns |     1,553.90 ns |      26.87 |                 List:Take |    250 |                Take:000250 |   0.5417 |
|   .NET Framework 4.8 |     1,892.88 ns |      68.339 ns |     1,861.60 ns |     1,826.91 ns |     2,070.94 ns |      34.08 |                 Linq:Take |    250 |                Take:000250 |   0.0477 |
| .NET Framework 4.7.2 |     1,922.85 ns |      72.429 ns |     1,898.11 ns |     1,824.02 ns |     2,135.01 ns |      34.50 |                 Linq:Take |    250 |                Take:000250 |   0.0477 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |    16,217.27 ns |     265.252 ns |    16,167.75 ns |    15,784.24 ns |    16,829.72 ns |       1.00 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 5.0 |    16,448.01 ns |     207.515 ns |    16,428.63 ns |    16,165.74 ns |    16,921.19 ns |       1.01 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 5.0 |    21,057.64 ns |     902.502 ns |    20,658.26 ns |    20,089.15 ns |    23,581.38 ns |       1.31 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|             .NET 6.0 |    21,528.20 ns |     919.032 ns |    21,169.41 ns |    20,519.30 ns |    24,174.95 ns |       1.38 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
| .NET Framework 4.7.2 |    23,628.84 ns |     673.362 ns |    23,305.57 ns |    22,551.20 ns |    25,291.20 ns |       1.45 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|   .NET Framework 4.8 |    23,821.55 ns |     772.106 ns |    23,457.10 ns |    22,829.59 ns |    25,297.54 ns |       1.49 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
| .NET Framework 4.7.2 |    32,425.35 ns |     793.244 ns |    32,139.76 ns |    31,567.97 ns |    34,116.89 ns |       2.01 |                 Linq:Take |   5000 |                Take:005000 |        - |
|   .NET Framework 4.8 |    32,744.91 ns |     934.559 ns |    32,331.07 ns |    31,690.53 ns |    34,723.31 ns |       2.04 |                 Linq:Take |   5000 |                Take:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        54.65 ns |       2.467 ns |        53.63 ns |        51.35 ns |        61.75 ns |       1.00 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
|             .NET 5.0 |        55.48 ns |       3.294 ns |        54.47 ns |        51.43 ns |        65.01 ns |       1.03 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
| .NET Framework 4.7.2 |       213.30 ns |       3.512 ns |       213.67 ns |       208.31 ns |       222.49 ns |       3.89 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
|   .NET Framework 4.8 |       215.21 ns |       5.500 ns |       213.99 ns |       208.83 ns |       228.87 ns |       3.89 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        52.88 ns |       0.695 ns |        52.84 ns |        51.52 ns |        54.09 ns |       1.00 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
|             .NET 5.0 |        53.59 ns |       2.676 ns |        52.63 ns |        50.11 ns |        61.00 ns |       1.06 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
|   .NET Framework 4.8 |       211.32 ns |       2.812 ns |       210.90 ns |       207.36 ns |       217.06 ns |       3.99 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
| .NET Framework 4.7.2 |       212.57 ns |       3.403 ns |       212.41 ns |       205.40 ns |       217.47 ns |       4.02 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
|             .NET 5.0 |   322,590.89 ns |  13,242.692 ns |   321,200.12 ns |   302,560.64 ns |   358,108.54 ns |   6,156.07 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 6.0 |   325,047.58 ns |  13,707.024 ns |   320,681.27 ns |   305,835.35 ns |   361,919.82 ns |   6,305.82 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 5.0 |   546,838.37 ns |   5,074.886 ns |   546,838.23 ns |   537,236.43 ns |   553,415.33 ns |  10,320.41 |                 List:Take | 100000 |                Take:100000 | 156.2500 |
|   .NET Framework 4.8 |   579,683.71 ns |   7,872.443 ns |   579,545.41 ns |   565,849.61 ns |   590,700.00 ns |  10,934.93 |                 List:Take | 100000 |                Take:100000 | 148.4375 |
|   .NET Framework 4.8 |   619,409.59 ns |   6,090.376 ns |   619,111.04 ns |   607,103.22 ns |   630,963.48 ns |  11,715.69 |                 Linq:Take | 100000 |                Take:100000 |        - |
| .NET Framework 4.7.2 |   623,451.95 ns |   4,186.166 ns |   623,566.02 ns |   614,075.78 ns |   630,145.70 ns |  11,792.55 |                 Linq:Take | 100000 |                Take:100000 |        - |
| .NET Framework 4.7.2 |   644,299.58 ns |  14,472.705 ns |   647,865.04 ns |   592,284.38 ns |   664,870.12 ns |  12,184.61 |                 List:Take | 100000 |                Take:100000 | 147.4609 |
|             .NET 6.0 |   963,594.55 ns |  65,847.951 ns |   969,574.22 ns |   807,165.62 ns | 1,122,151.27 ns |  17,974.48 |                 List:Take | 100000 |                Take:100000 | 162.1094 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.62 ns |       2.512 ns |        45.66 ns |        43.68 ns |        52.56 ns |       0.96 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        48.34 ns |       2.988 ns |        47.20 ns |        44.85 ns |        55.85 ns |       1.00 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        66.53 ns |       1.611 ns |        66.44 ns |        64.15 ns |        69.39 ns |       1.36 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 5.0 |        73.37 ns |       2.253 ns |        72.55 ns |        69.64 ns |        80.01 ns |       1.48 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 6.0 |        85.14 ns |       5.707 ns |        83.88 ns |        74.61 ns |       101.43 ns |       1.77 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|             .NET 5.0 |        88.21 ns |       6.474 ns |        87.95 ns |        77.46 ns |       107.08 ns |       1.83 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|   .NET Framework 4.8 |        96.23 ns |       3.051 ns |        96.04 ns |        91.68 ns |       103.78 ns |       1.95 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        96.32 ns |       3.129 ns |        94.70 ns |        92.57 ns |       102.57 ns |       1.95 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |       150.97 ns |       4.243 ns |       151.10 ns |       142.03 ns |       159.39 ns |       3.06 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
|   .NET Framework 4.8 |       155.93 ns |       8.825 ns |       153.43 ns |       140.99 ns |       176.38 ns |       3.23 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       321.89 ns |      11.543 ns |       324.08 ns |       304.14 ns |       352.13 ns |       6.55 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|   .NET Framework 4.8 |       324.45 ns |       9.467 ns |       325.73 ns |       309.26 ns |       343.13 ns |       6.54 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.23 ns |       2.285 ns |        45.77 ns |        43.30 ns |        52.32 ns |       0.97 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 6.0 |        47.56 ns |       2.711 ns |        46.68 ns |        44.56 ns |        54.58 ns |       1.00 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        94.60 ns |       1.307 ns |        94.58 ns |        92.64 ns |        97.46 ns |       1.98 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        97.35 ns |       3.170 ns |        96.47 ns |        92.65 ns |       104.92 ns |       2.02 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 5.0 |       958.01 ns |      17.982 ns |       955.17 ns |       936.71 ns |     1,001.58 ns |      20.07 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0362 |
|             .NET 6.0 |     1,285.69 ns |      40.756 ns |     1,277.43 ns |     1,227.13 ns |     1,368.09 ns |      26.80 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|             .NET 5.0 |     1,335.96 ns |      96.061 ns |     1,289.29 ns |     1,222.14 ns |     1,595.62 ns |      28.23 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,471.71 ns |      27.537 ns |     1,475.96 ns |     1,430.03 ns |     1,511.58 ns |      30.75 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,495.92 ns |      26.731 ns |     1,486.85 ns |     1,467.46 ns |     1,563.82 ns |      31.37 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,578.91 ns |      77.327 ns |     1,544.85 ns |     1,493.21 ns |     1,796.49 ns |      33.18 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0534 |
| .NET Framework 4.7.2 |     2,270.53 ns |      26.184 ns |     2,274.15 ns |     2,220.94 ns |     2,322.25 ns |      47.21 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|   .NET Framework 4.8 |     2,310.71 ns |      87.386 ns |     2,276.81 ns |     2,201.06 ns |     2,551.79 ns |      47.79 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        49.86 ns |       1.468 ns |        49.38 ns |        47.47 ns |        52.65 ns |       0.96 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 6.0 |        51.44 ns |       2.718 ns |        51.02 ns |        48.00 ns |        58.27 ns |       1.00 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.84 ns |       1.063 ns |        93.59 ns |        91.79 ns |        95.76 ns |       1.78 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        96.25 ns |       3.200 ns |        94.99 ns |        92.22 ns |       104.88 ns |       1.87 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 5.0 |    16,530.51 ns |     460.944 ns |    16,254.54 ns |    15,900.71 ns |    17,388.73 ns |     319.61 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
|             .NET 5.0 |    20,851.73 ns |     828.763 ns |    20,759.60 ns |    19,645.23 ns |    23,128.65 ns |     402.15 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 6.0 |    21,296.40 ns |     321.181 ns |    21,309.72 ns |    20,923.26 ns |    22,030.56 ns |     403.86 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    24,817.68 ns |     894.315 ns |    24,472.49 ns |    23,469.89 ns |    27,024.13 ns |     480.02 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    24,979.67 ns |   1,232.051 ns |    24,451.09 ns |    23,638.64 ns |    28,276.81 ns |     486.83 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 6.0 |    27,787.37 ns |     571.390 ns |    27,515.32 ns |    27,297.46 ns |    29,358.01 ns |     532.79 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
|   .NET Framework 4.8 |    35,776.35 ns |     244.752 ns |    35,823.46 ns |    35,237.52 ns |    36,138.46 ns |     682.02 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    36,596.64 ns |     643.688 ns |    36,377.80 ns |    35,944.76 ns |    38,110.82 ns |     693.59 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        42.96 ns |       0.843 ns |        42.88 ns |        41.84 ns |        44.87 ns |       1.00 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 5.0 |        46.77 ns |       1.210 ns |        46.90 ns |        43.83 ns |        49.54 ns |       1.09 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        94.01 ns |       2.133 ns |        94.12 ns |        90.59 ns |        99.22 ns |       2.19 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |       100.42 ns |       1.792 ns |        99.51 ns |        98.62 ns |       103.72 ns |       2.33 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 5.0 |   383,999.16 ns |  52,366.225 ns |   375,725.24 ns |   309,312.40 ns |   517,439.84 ns |   8,531.65 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
|             .NET 5.0 |   576,166.77 ns |  20,959.404 ns |   570,200.05 ns |   551,813.77 ns |   626,071.00 ns |  13,451.79 |             List:TakeLast | 100000 |            TakeLast:100000 | 164.0625 |
| .NET Framework 4.7.2 |   582,078.50 ns |  14,883.552 ns |   579,537.11 ns |   559,826.56 ns |   617,938.87 ns |  13,463.71 |             List:TakeLast | 100000 |            TakeLast:100000 | 149.4141 |
|             .NET 6.0 |   619,647.31 ns |  11,577.150 ns |   618,786.91 ns |   594,275.29 ns |   643,755.86 ns |  14,390.95 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
|   .NET Framework 4.8 |   680,904.92 ns |  15,166.268 ns |   675,217.92 ns |   655,439.70 ns |   710,446.73 ns |  15,880.39 |             List:TakeLast | 100000 |            TakeLast:100000 | 148.4375 |
|   .NET Framework 4.8 |   813,980.69 ns |  12,367.892 ns |   814,543.85 ns |   799,776.27 ns |   838,525.49 ns |  18,824.75 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 177.7344 |
| .NET Framework 4.7.2 |   845,479.15 ns |  39,864.607 ns |   837,089.01 ns |   791,649.32 ns |   958,500.49 ns |  19,488.38 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 169.9219 |
|             .NET 6.0 | 1,015,448.42 ns |  83,846.387 ns | 1,013,696.73 ns |   849,255.27 ns | 1,218,124.12 ns |  23,617.15 |             List:TakeLast | 100000 |            TakeLast:100000 | 158.2031 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.40 ns |       2.096 ns |        40.26 ns |        39.34 ns |        46.97 ns |       1.00 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 5.0 |        45.96 ns |       0.411 ns |        45.84 ns |        45.58 ns |        46.98 ns |       1.07 |               Array:Where |      1 |               Where:000001 |   0.0153 |
| .NET Framework 4.7.2 |        89.74 ns |       1.854 ns |        88.52 ns |        88.08 ns |        92.72 ns |       2.13 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|   .NET Framework 4.8 |        90.11 ns |       1.669 ns |        89.48 ns |        88.00 ns |        93.10 ns |       2.11 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 6.0 |       104.93 ns |       1.157 ns |       104.87 ns |       103.07 ns |       107.66 ns |       2.44 |                List:Where |      1 |               Where:000001 |   0.0534 |
|             .NET 5.0 |       110.87 ns |       1.442 ns |       111.67 ns |       108.55 ns |       112.61 ns |       2.60 |                List:Where |      1 |               Where:000001 |   0.0535 |
|             .NET 6.0 |       129.72 ns |       1.639 ns |       130.62 ns |       126.87 ns |       131.11 ns |       3.04 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
|             .NET 5.0 |       134.52 ns |       0.427 ns |       134.56 ns |       133.63 ns |       135.06 ns |       3.13 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
|   .NET Framework 4.8 |       160.02 ns |       2.941 ns |       160.95 ns |       155.64 ns |       164.43 ns |       3.75 |                List:Where |      1 |               Where:000001 |   0.0560 |
| .NET Framework 4.7.2 |       161.78 ns |       3.081 ns |       161.15 ns |       157.35 ns |       168.21 ns |       3.81 |                List:Where |      1 |               Where:000001 |   0.0560 |
| .NET Framework 4.7.2 |       255.04 ns |       4.576 ns |       255.89 ns |       249.61 ns |       261.51 ns |       5.98 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
|   .NET Framework 4.8 |       258.88 ns |       5.146 ns |       260.40 ns |       250.99 ns |       269.74 ns |       6.18 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        42.30 ns |       0.904 ns |        41.81 ns |        41.36 ns |        43.71 ns |       0.96 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 6.0 |        44.16 ns |       0.808 ns |        43.81 ns |        43.40 ns |        46.41 ns |       1.00 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|   .NET Framework 4.8 |        89.04 ns |       1.479 ns |        88.70 ns |        87.00 ns |        91.71 ns |       2.02 |               Array:Where |    250 |               Where:000250 |   0.0153 |
| .NET Framework 4.7.2 |        90.46 ns |       1.924 ns |        89.13 ns |        88.64 ns |        93.41 ns |       2.05 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 6.0 |     6,877.47 ns |     111.795 ns |     6,916.22 ns |     6,732.78 ns |     7,022.58 ns |     156.05 |                List:Where |    250 |               Where:000250 |   0.9995 |
|             .NET 5.0 |     7,283.68 ns |      74.211 ns |     7,289.46 ns |     7,165.16 ns |     7,454.28 ns |     164.98 |                List:Where |    250 |               Where:000250 |   0.9918 |
|             .NET 6.0 |     9,118.27 ns |      51.960 ns |     9,106.58 ns |     9,043.79 ns |     9,227.88 ns |     206.88 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|   .NET Framework 4.8 |     9,408.07 ns |     124.721 ns |     9,401.62 ns |     9,244.87 ns |     9,639.44 ns |     213.10 |                List:Where |    250 |               Where:000250 |   1.0071 |
|             .NET 5.0 |     9,513.05 ns |     170.439 ns |     9,573.10 ns |     9,184.96 ns |     9,750.16 ns |     215.47 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
| .NET Framework 4.7.2 |     9,577.29 ns |     118.419 ns |     9,559.00 ns |     9,402.07 ns |     9,803.97 ns |     216.93 |                List:Where |    250 |               Where:000250 |   1.0071 |
|   .NET Framework 4.8 |    12,179.20 ns |     244.453 ns |    12,114.19 ns |    11,848.97 ns |    12,701.43 ns |     275.58 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
| .NET Framework 4.7.2 |    12,266.54 ns |     204.598 ns |    12,161.54 ns |    12,036.10 ns |    12,774.40 ns |     277.86 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.37 ns |       0.441 ns |        41.22 ns |        40.99 ns |        42.62 ns |       1.00 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 5.0 |        46.85 ns |       0.267 ns |        46.81 ns |        46.43 ns |        47.34 ns |       1.13 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
| .NET Framework 4.7.2 |        89.24 ns |       0.583 ns |        89.16 ns |        88.48 ns |        90.58 ns |       2.16 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|   .NET Framework 4.8 |        90.39 ns |       0.648 ns |        90.15 ns |        89.59 ns |        91.71 ns |       2.18 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 6.0 |   150,529.68 ns |   1,481.895 ns |   150,040.77 ns |   148,560.86 ns |   153,262.18 ns |   3,635.34 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 5.0 |   158,145.72 ns |   2,549.370 ns |   157,161.68 ns |   156,041.65 ns |   165,415.33 ns |   3,822.73 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 6.0 |   179,614.04 ns |   2,480.448 ns |   178,653.42 ns |   176,769.36 ns |   183,865.09 ns |   4,343.30 |                Linq:Where |   5000 |               Where:005000 |        - |
|             .NET 5.0 |   181,884.53 ns |   2,377.262 ns |   180,819.09 ns |   179,680.86 ns |   187,616.99 ns |   4,396.57 |                Linq:Where |   5000 |               Where:005000 |        - |
|   .NET Framework 4.8 |   203,472.31 ns |     933.333 ns |   203,253.03 ns |   202,368.38 ns |   205,039.26 ns |   4,918.21 |                List:Where |   5000 |               Where:005000 |  36.8652 |
| .NET Framework 4.7.2 |   204,628.94 ns |   2,046.984 ns |   203,714.45 ns |   202,689.43 ns |   208,098.68 ns |   4,948.98 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|   .NET Framework 4.8 |   239,512.42 ns |   4,774.591 ns |   236,966.87 ns |   235,133.11 ns |   250,265.50 ns |   5,798.27 |                Linq:Where |   5000 |               Where:005000 |        - |
| .NET Framework 4.7.2 |   240,400.98 ns |   4,734.439 ns |   238,764.58 ns |   235,402.93 ns |   249,580.47 ns |   5,814.55 |                Linq:Where |   5000 |               Where:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        39.62 ns |       0.760 ns |        39.88 ns |        38.21 ns |        40.84 ns |       1.00 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 |        40.87 ns |       0.625 ns |        40.67 ns |        40.11 ns |        41.70 ns |       1.03 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|   .NET Framework 4.8 |        89.86 ns |       0.564 ns |        89.78 ns |        88.97 ns |        91.15 ns |       2.27 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
| .NET Framework 4.7.2 |        90.66 ns |       1.579 ns |        90.11 ns |        89.03 ns |        93.85 ns |       2.29 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 | 2,904,342.80 ns |  21,472.442 ns | 2,904,068.16 ns | 2,875,982.03 ns | 2,948,756.25 ns |  73,296.80 |                List:Where | 100000 |               Where:100000 | 324.2188 |
|             .NET 6.0 | 2,938,638.83 ns |  18,714.941 ns | 2,930,574.61 ns | 2,906,696.48 ns | 2,976,518.75 ns |  74,198.62 |                List:Where | 100000 |               Where:100000 | 281.2500 |
|             .NET 6.0 | 3,539,767.27 ns |  24,146.999 ns | 3,544,900.78 ns | 3,500,258.20 ns | 3,572,793.75 ns |  89,326.10 |                Linq:Where | 100000 |               Where:100000 |        - |
|             .NET 5.0 | 3,601,159.38 ns |  39,750.968 ns | 3,615,477.54 ns | 3,528,175.78 ns | 3,646,994.53 ns |  90,910.72 |                Linq:Where | 100000 |               Where:100000 |        - |
| .NET Framework 4.7.2 | 3,769,033.47 ns |  42,666.089 ns | 3,782,192.97 ns | 3,697,263.28 ns | 3,848,691.02 ns |  95,186.64 |                List:Where | 100000 |               Where:100000 | 242.1875 |
|   .NET Framework 4.8 | 3,778,538.78 ns |  28,855.375 ns | 3,776,179.88 ns | 3,728,601.56 ns | 3,825,097.27 ns |  95,358.47 |                List:Where | 100000 |               Where:100000 | 242.1875 |
|   .NET Framework 4.8 | 4,773,904.17 ns |  72,051.916 ns | 4,772,707.81 ns | 4,682,689.06 ns | 4,932,197.66 ns | 120,530.71 |                Linq:Where | 100000 |               Where:100000 |        - |
| .NET Framework 4.7.2 | 4,780,709.11 ns |  42,247.940 ns | 4,764,952.73 ns | 4,738,122.66 ns | 4,866,549.22 ns | 120,677.14 |                Linq:Where | 100000 |               Where:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.27 ns |       0.158 ns |        40.28 ns |        40.02 ns |        40.55 ns |       1.00 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 5.0 |        42.91 ns |       0.507 ns |        42.82 ns |        41.95 ns |        43.63 ns |       1.06 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
| .NET Framework 4.7.2 |        89.31 ns |       1.237 ns |        89.54 ns |        87.01 ns |        91.33 ns |       2.22 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|   .NET Framework 4.8 |        91.51 ns |       0.988 ns |        91.21 ns |        89.93 ns |        93.21 ns |       2.27 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 6.0 |       141.38 ns |       1.616 ns |       140.97 ns |       139.20 ns |       144.70 ns |       3.51 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 5.0 |       142.72 ns |       2.395 ns |       141.82 ns |       140.23 ns |       147.75 ns |       3.55 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 6.0 |       160.28 ns |       1.185 ns |       160.31 ns |       158.27 ns |       162.23 ns |       3.98 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0751 |
|             .NET 5.0 |       173.08 ns |       0.485 ns |       173.04 ns |       172.25 ns |       174.09 ns |       4.30 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0751 |
| .NET Framework 4.7.2 |       213.72 ns |       1.286 ns |       213.48 ns |       211.93 ns |       216.46 ns |       5.31 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0637 |
|   .NET Framework 4.8 |       215.32 ns |       3.469 ns |       217.25 ns |       210.90 ns |       219.12 ns |       5.35 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0637 |
|   .NET Framework 4.8 |       308.67 ns |       3.603 ns |       307.33 ns |       303.71 ns |       315.63 ns |       7.66 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
| .NET Framework 4.7.2 |       311.15 ns |       5.411 ns |       309.31 ns |       303.99 ns |       318.39 ns |       7.73 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.99 ns |       0.657 ns |        41.02 ns |        39.59 ns |        42.01 ns |       1.00 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 5.0 |        44.51 ns |       0.613 ns |        44.29 ns |        43.68 ns |        45.69 ns |       1.09 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
| .NET Framework 4.7.2 |        88.42 ns |       1.055 ns |        88.21 ns |        87.09 ns |        90.45 ns |       2.15 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|   .NET Framework 4.8 |        90.01 ns |       1.291 ns |        90.08 ns |        87.98 ns |        91.74 ns |       2.20 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 6.0 |     5,542.75 ns |     116.820 ns |     5,558.45 ns |     5,399.41 ns |     5,699.40 ns |     136.23 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 5.0 |     6,605.06 ns |      77.059 ns |     6,586.94 ns |     6,524.66 ns |     6,765.98 ns |     161.22 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 5.0 |     9,311.66 ns |      66.037 ns |     9,293.03 ns |     9,198.80 ns |     9,444.81 ns |     227.36 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
|             .NET 6.0 |     9,470.17 ns |     124.000 ns |     9,418.91 ns |     9,337.13 ns |     9,676.98 ns |     231.71 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
|   .NET Framework 4.8 |     9,800.81 ns |     120.976 ns |     9,816.33 ns |     9,595.71 ns |    10,043.33 ns |     239.82 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
| .NET Framework 4.7.2 |     9,883.98 ns |     174.123 ns |     9,806.18 ns |     9,642.47 ns |    10,272.53 ns |     241.10 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
| .NET Framework 4.7.2 |    11,632.78 ns |     128.326 ns |    11,678.07 ns |    11,430.51 ns |    11,830.14 ns |     284.00 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|   .NET Framework 4.8 |    11,634.70 ns |     173.753 ns |    11,590.90 ns |    11,385.51 ns |    11,944.63 ns |     284.56 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        42.25 ns |       0.661 ns |        42.03 ns |        41.25 ns |        44.40 ns |       0.92 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 6.0 |        46.36 ns |       0.725 ns |        46.09 ns |        45.70 ns |        48.08 ns |       1.00 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|   .NET Framework 4.8 |        88.62 ns |       0.403 ns |        88.62 ns |        88.08 ns |        89.60 ns |       1.91 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
| .NET Framework 4.7.2 |        90.53 ns |       1.029 ns |        90.29 ns |        89.18 ns |        92.61 ns |       1.95 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 6.0 |   109,539.40 ns |   1,426.693 ns |   108,662.76 ns |   108,168.24 ns |   111,721.35 ns |   2,360.11 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 5.0 |   121,724.98 ns |     475.094 ns |   121,834.50 ns |   120,735.77 ns |   122,444.56 ns |   2,626.36 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|   .NET Framework 4.8 |   189,137.47 ns |   1,592.077 ns |   188,513.40 ns |   187,383.81 ns |   192,860.18 ns |   4,082.46 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
| .NET Framework 4.7.2 |   190,346.63 ns |   3,091.386 ns |   189,456.81 ns |   186,648.10 ns |   198,346.22 ns |   4,108.07 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 6.0 |   224,736.43 ns |     967.318 ns |   224,561.72 ns |   223,426.54 ns |   226,795.75 ns |   4,850.62 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.9746 |
|             .NET 5.0 |   230,627.29 ns |   1,988.664 ns |   230,320.34 ns |   227,869.41 ns |   234,216.53 ns |   4,978.44 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.9746 |
| .NET Framework 4.7.2 |   262,531.48 ns |   2,729.488 ns |   261,559.91 ns |   258,859.72 ns |   267,557.52 ns |   5,661.03 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|   .NET Framework 4.8 |   263,264.27 ns |   2,796.103 ns |   262,746.39 ns |   259,925.15 ns |   268,333.54 ns |   5,689.43 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.16 ns |       0.110 ns |        38.18 ns |        37.97 ns |        38.38 ns |       1.00 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 5.0 |        41.10 ns |       0.443 ns |        41.24 ns |        39.99 ns |        41.75 ns |       1.08 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|   .NET Framework 4.8 |        89.59 ns |       0.486 ns |        89.57 ns |        88.22 ns |        90.22 ns |       2.35 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
| .NET Framework 4.7.2 |        92.32 ns |       3.249 ns |        90.95 ns |        88.60 ns |       100.84 ns |       2.43 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 6.0 | 2,333,503.16 ns |  18,026.392 ns | 2,339,010.74 ns | 2,307,171.68 ns | 2,361,947.85 ns |  61,184.12 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 2,496,286.64 ns |  28,629.375 ns | 2,488,786.91 ns | 2,457,574.80 ns | 2,544,817.38 ns |  65,451.63 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
| .NET Framework 4.7.2 | 3,771,033.47 ns |  33,604.201 ns | 3,755,202.34 ns | 3,729,313.67 ns | 3,832,259.77 ns |  98,806.41 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|   .NET Framework 4.8 | 3,895,991.18 ns |  33,259.534 ns | 3,892,552.34 ns | 3,855,892.77 ns | 3,963,409.96 ns | 101,970.51 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 4,755,252.36 ns | 191,240.413 ns | 4,765,770.70 ns | 4,401,641.41 ns | 5,119,077.34 ns | 122,964.55 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 320.3125 |
|   .NET Framework 4.8 | 5,108,468.09 ns |  64,097.216 ns | 5,126,290.62 ns | 4,992,817.97 ns | 5,177,989.06 ns | 133,764.20 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 289.0625 |
|             .NET 6.0 | 5,158,376.32 ns | 293,224.672 ns | 5,197,853.91 ns | 4,476,755.47 ns | 5,871,281.25 ns | 138,263.46 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 296.8750 |
| .NET Framework 4.7.2 | 5,192,922.39 ns | 150,987.669 ns | 5,175,700.78 ns | 4,964,392.97 ns | 5,476,545.31 ns | 136,315.95 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 304.6875 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.63 ns |       0.689 ns |        40.72 ns |        39.54 ns |        41.69 ns |       1.00 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 5.0 |        41.72 ns |       0.398 ns |        41.59 ns |        41.31 ns |        42.47 ns |       1.03 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        88.56 ns |       1.417 ns |        87.97 ns |        86.62 ns |        90.80 ns |       2.18 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        92.27 ns |       1.218 ns |        92.29 ns |        90.66 ns |        94.63 ns |       2.27 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 6.0 |       107.97 ns |       0.966 ns |       107.95 ns |       106.42 ns |       110.10 ns |       2.66 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 5.0 |       108.37 ns |       1.635 ns |       108.12 ns |       106.07 ns |       111.28 ns |       2.67 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 6.0 |       125.77 ns |       1.799 ns |       126.10 ns |       123.62 ns |       128.70 ns |       3.10 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
|             .NET 5.0 |       133.18 ns |       1.046 ns |       133.09 ns |       131.90 ns |       135.62 ns |       3.29 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
|   .NET Framework 4.8 |       196.93 ns |       1.639 ns |       196.43 ns |       195.22 ns |       200.14 ns |       4.85 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
| .NET Framework 4.7.2 |       198.20 ns |       2.522 ns |       198.30 ns |       194.87 ns |       202.76 ns |       4.88 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
|   .NET Framework 4.8 |       289.35 ns |       2.917 ns |       290.85 ns |       285.45 ns |       292.29 ns |       7.13 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
| .NET Framework 4.7.2 |       290.80 ns |       3.940 ns |       289.79 ns |       286.26 ns |       298.15 ns |       7.16 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        41.98 ns |       0.880 ns |        41.69 ns |        40.74 ns |        43.71 ns |       0.93 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 6.0 |        45.26 ns |       0.384 ns |        45.19 ns |        44.59 ns |        45.94 ns |       1.00 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        88.42 ns |       1.229 ns |        88.31 ns |        86.57 ns |        90.54 ns |       1.95 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        89.61 ns |       1.032 ns |        89.48 ns |        87.87 ns |        91.47 ns |       1.98 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 6.0 |     1,813.36 ns |       5.285 ns |     1,814.30 ns |     1,804.49 ns |     1,819.81 ns |      40.01 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 5.0 |     1,852.53 ns |      10.265 ns |     1,853.14 ns |     1,839.26 ns |     1,874.45 ns |      40.89 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|   .NET Framework 4.8 |     2,096.53 ns |      34.598 ns |     2,085.80 ns |     2,043.34 ns |     2,159.03 ns |      46.32 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
| .NET Framework 4.7.2 |     2,097.11 ns |      27.929 ns |     2,090.08 ns |     2,051.76 ns |     2,147.86 ns |      46.29 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 6.0 |     5,617.26 ns |     187.391 ns |     5,519.65 ns |     5,457.42 ns |     6,148.37 ns |     125.43 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
|             .NET 5.0 |     6,644.29 ns |      83.650 ns |     6,609.61 ns |     6,558.02 ns |     6,766.20 ns |     146.59 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
|   .NET Framework 4.8 |     9,599.79 ns |      94.436 ns |     9,587.98 ns |     9,483.86 ns |     9,743.98 ns |     211.98 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
| .NET Framework 4.7.2 |     9,970.99 ns |     121.322 ns |     9,930.30 ns |     9,832.88 ns |    10,233.57 ns |     220.29 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        44.92 ns |       0.746 ns |        45.30 ns |        43.80 ns |        45.99 ns |       1.00 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |        48.78 ns |       0.288 ns |        48.81 ns |        48.36 ns |        49.43 ns |       1.09 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        87.90 ns |       0.691 ns |        87.72 ns |        86.98 ns |        89.16 ns |       1.96 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        89.00 ns |       1.144 ns |        88.77 ns |        87.29 ns |        90.51 ns |       1.98 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |    32,500.99 ns |     422.077 ns |    32,354.24 ns |    32,097.02 ns |    33,310.28 ns |     723.71 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |    35,490.92 ns |     456.102 ns |    35,412.53 ns |    34,699.04 ns |    36,478.13 ns |     791.57 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|   .NET Framework 4.8 |    36,674.50 ns |     286.127 ns |    36,728.02 ns |    36,105.27 ns |    37,039.69 ns |     817.13 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
| .NET Framework 4.7.2 |    36,734.02 ns |     194.890 ns |    36,730.69 ns |    36,409.17 ns |    37,083.26 ns |     819.37 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |   115,074.92 ns |   1,048.024 ns |   114,978.10 ns |   113,847.51 ns |   116,481.67 ns |   2,562.41 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|             .NET 5.0 |   125,907.75 ns |   1,478.379 ns |   124,993.26 ns |   124,239.28 ns |   128,087.77 ns |   2,808.33 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|   .NET Framework 4.8 |   189,792.57 ns |     686.521 ns |   189,891.85 ns |   188,138.33 ns |   190,928.66 ns |   4,226.20 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
| .NET Framework 4.7.2 |   190,944.53 ns |     901.389 ns |   191,087.54 ns |   189,420.63 ns |   192,233.89 ns |   4,254.42 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.70 ns |       1.023 ns |        40.22 ns |        39.61 ns |        42.86 ns |       1.00 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |        41.56 ns |       0.327 ns |        41.58 ns |        41.05 ns |        42.11 ns |       1.01 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        89.82 ns |       1.271 ns |        89.73 ns |        87.99 ns |        92.15 ns |       2.19 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        91.06 ns |       1.273 ns |        90.78 ns |        89.67 ns |        93.44 ns |       2.22 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |   722,583.02 ns |  10,030.066 ns |   720,184.18 ns |   708,574.12 ns |   741,073.73 ns |  17,612.62 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 144.5313 |
|             .NET 6.0 |   749,146.93 ns |  11,226.181 ns |   751,165.43 ns |   730,182.91 ns |   764,989.75 ns |  18,256.47 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 142.5781 |
| .NET Framework 4.7.2 |   794,785.55 ns |   8,956.207 ns |   792,712.40 ns |   779,509.38 ns |   806,832.81 ns |  19,371.37 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 121.0938 |
|   .NET Framework 4.8 |   799,513.07 ns |  10,554.274 ns |   799,982.42 ns |   781,289.55 ns |   822,022.27 ns |  19,486.80 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 118.1641 |
|             .NET 6.0 | 2,298,127.27 ns |  20,128.963 ns | 2,294,187.50 ns | 2,268,547.66 ns | 2,349,564.06 ns |  56,092.09 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|             .NET 5.0 | 2,480,194.09 ns |  22,025.279 ns | 2,467,241.41 ns | 2,456,174.61 ns | 2,522,084.77 ns |  60,440.23 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
| .NET Framework 4.7.2 | 3,825,826.17 ns |  32,825.989 ns | 3,810,378.91 ns | 3,793,418.75 ns | 3,890,068.75 ns |  93,021.02 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|   .NET Framework 4.8 | 3,839,288.59 ns |  15,665.098 ns | 3,842,194.14 ns | 3,812,365.62 ns | 3,863,158.59 ns |  93,565.62 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        40.12 ns |       0.465 ns |        40.05 ns |        39.41 ns |        40.85 ns |       1.00 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        42.78 ns |       0.306 ns |        42.75 ns |        42.37 ns |        43.35 ns |       1.07 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        86.20 ns |       2.264 ns |        86.39 ns |        83.63 ns |        93.55 ns |       2.15 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        88.34 ns |       1.154 ns |        88.38 ns |        87.02 ns |        91.17 ns |       2.20 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
|   .NET Framework 4.8 |        90.71 ns |       1.071 ns |        90.61 ns |        89.28 ns |        92.54 ns |       2.26 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        90.86 ns |       1.101 ns |        91.39 ns |        89.09 ns |        92.14 ns |       2.27 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |       124.75 ns |       1.305 ns |       124.76 ns |       122.02 ns |       126.70 ns |       3.11 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
|             .NET 5.0 |       136.94 ns |       0.505 ns |       137.10 ns |       135.89 ns |       137.55 ns |       3.42 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
|   .NET Framework 4.8 |       157.12 ns |       2.058 ns |       156.48 ns |       154.93 ns |       160.97 ns |       3.92 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
| .NET Framework 4.7.2 |       158.15 ns |       1.230 ns |       158.26 ns |       155.75 ns |       159.73 ns |       3.94 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
| .NET Framework 4.7.2 |       563.21 ns |       5.780 ns |       563.78 ns |       550.18 ns |       571.66 ns |      14.04 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
|   .NET Framework 4.8 |       567.85 ns |       7.490 ns |       570.99 ns |       554.19 ns |       578.05 ns |      14.16 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.90 ns |       0.686 ns |        38.98 ns |        37.68 ns |        40.11 ns |       1.00 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |        42.35 ns |       0.532 ns |        42.27 ns |        41.58 ns |        43.39 ns |       1.09 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        90.21 ns |       1.466 ns |        90.64 ns |        87.80 ns |        92.90 ns |       2.32 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        91.54 ns |       1.032 ns |        91.18 ns |        90.31 ns |        93.24 ns |       2.35 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 6.0 |       974.06 ns |       5.096 ns |       975.88 ns |       963.78 ns |       979.36 ns |      25.06 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
|             .NET 5.0 |       991.96 ns |      18.975 ns |       986.26 ns |       968.46 ns |     1,015.03 ns |      25.54 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
|   .NET Framework 4.8 |     1,226.38 ns |      16.881 ns |     1,215.52 ns |     1,208.35 ns |     1,254.02 ns |      31.53 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     1,232.01 ns |      19.880 ns |     1,228.77 ns |     1,208.40 ns |     1,257.11 ns |      31.64 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     6,197.06 ns |     107.372 ns |     6,175.24 ns |     6,074.97 ns |     6,413.12 ns |     159.55 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1144 |
|             .NET 5.0 |     6,526.59 ns |     132.034 ns |     6,575.00 ns |     6,349.04 ns |     6,870.82 ns |     167.96 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1068 |
| .NET Framework 4.7.2 |    19,140.61 ns |     113.586 ns |    19,121.64 ns |    18,948.93 ns |    19,397.99 ns |     492.13 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|   .NET Framework 4.8 |    19,444.78 ns |     199.565 ns |    19,477.68 ns |    19,144.50 ns |    19,836.35 ns |     499.90 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.64 ns |       0.864 ns |        43.38 ns |        42.32 ns |        45.63 ns |       1.00 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        47.98 ns |       0.441 ns |        47.77 ns |        47.65 ns |        48.95 ns |       1.10 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        88.60 ns |       0.709 ns |        88.54 ns |        86.95 ns |        89.73 ns |       2.03 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        91.18 ns |       1.091 ns |        90.95 ns |        89.83 ns |        92.70 ns |       2.09 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |    16,285.64 ns |     207.513 ns |    16,217.76 ns |    16,099.95 ns |    16,864.85 ns |     372.67 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 5.0 |    16,690.97 ns |      67.645 ns |    16,682.93 ns |    16,547.88 ns |    16,809.78 ns |     381.93 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    20,637.28 ns |     217.186 ns |    20,555.42 ns |    20,345.37 ns |    21,097.81 ns |     473.66 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    20,658.68 ns |     280.296 ns |    20,571.65 ns |    20,335.05 ns |    21,167.80 ns |     473.87 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   114,325.61 ns |     916.185 ns |   114,100.61 ns |   112,989.76 ns |   116,259.13 ns |   2,623.97 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|             .NET 5.0 |   122,698.29 ns |   1,345.961 ns |   122,673.80 ns |   121,169.36 ns |   125,011.77 ns |   2,814.42 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|   .NET Framework 4.8 |   377,698.88 ns |   2,344.994 ns |   378,715.43 ns |   371,942.43 ns |   380,286.47 ns |   8,664.36 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   379,763.90 ns |   4,723.975 ns |   378,826.03 ns |   371,204.88 ns |   388,457.91 ns |   8,709.41 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        40.39 ns |       0.629 ns |        40.38 ns |        39.33 ns |        41.29 ns |       0.94 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 6.0 |        42.83 ns |       0.732 ns |        43.24 ns |        41.72 ns |        43.94 ns |       1.00 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        87.62 ns |       0.825 ns |        87.30 ns |        86.45 ns |        89.38 ns |       2.05 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        89.83 ns |       1.671 ns |        89.36 ns |        87.75 ns |        94.36 ns |       2.10 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 6.0 |   337,282.16 ns |  13,150.638 ns |   333,733.89 ns |   323,540.14 ns |   365,392.77 ns |   8,001.39 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 5.0 |   340,231.15 ns |   4,979.784 ns |   342,169.82 ns |   331,244.87 ns |   345,409.62 ns |   7,956.53 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   401,432.76 ns |   1,890.523 ns |   401,394.53 ns |   398,813.18 ns |   404,766.65 ns |   9,370.94 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 |   403,945.08 ns |   4,874.338 ns |   402,548.90 ns |   394,124.71 ns |   411,870.41 ns |   9,435.11 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 6.0 | 2,381,844.48 ns |  16,992.076 ns | 2,388,261.91 ns | 2,332,431.25 ns | 2,398,066.41 ns |  55,633.46 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 5.0 | 2,446,873.26 ns |  10,318.667 ns | 2,446,725.39 ns | 2,428,528.52 ns | 2,466,680.08 ns |  57,073.14 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 | 7,565,887.74 ns |  47,541.748 ns | 7,564,646.09 ns | 7,486,244.53 ns | 7,680,219.53 ns | 176,476.46 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,611,580.94 ns |  61,199.964 ns | 7,587,351.56 ns | 7,546,665.62 ns | 7,741,546.88 ns | 177,628.70 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        39.20 ns |       0.627 ns |        39.21 ns |        38.27 ns |        40.52 ns |       1.00 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 5.0 |        42.30 ns |       0.195 ns |        42.25 ns |        41.94 ns |        42.57 ns |       1.08 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        89.73 ns |       1.256 ns |        89.35 ns |        87.77 ns |        91.45 ns |       2.29 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        90.32 ns |       1.148 ns |        89.86 ns |        89.18 ns |        92.42 ns |       2.30 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 5.0 |        92.68 ns |       1.321 ns |        92.41 ns |        90.83 ns |        95.13 ns |       2.36 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 6.0 |        93.52 ns |       1.192 ns |        93.05 ns |        91.87 ns |        96.37 ns |       2.38 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0573 |
|             .NET 6.0 |        95.53 ns |       2.050 ns |        95.59 ns |        92.96 ns |       100.31 ns |       2.43 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 5.0 |       102.44 ns |       0.837 ns |       102.41 ns |       101.24 ns |       104.51 ns |       2.61 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0573 |
| .NET Framework 4.7.2 |       158.08 ns |       1.916 ns |       158.45 ns |       155.78 ns |       161.56 ns |       4.03 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
|   .NET Framework 4.8 |       160.40 ns |       1.962 ns |       160.84 ns |       157.68 ns |       164.01 ns |       4.09 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
| .NET Framework 4.7.2 |       248.76 ns |       3.927 ns |       248.75 ns |       243.42 ns |       255.31 ns |       6.35 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
|   .NET Framework 4.8 |       249.78 ns |       2.760 ns |       249.47 ns |       245.73 ns |       253.70 ns |       6.37 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        39.70 ns |       0.515 ns |        39.56 ns |        39.07 ns |        40.49 ns |       1.00 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 5.0 |        43.19 ns |       1.812 ns |        42.54 ns |        41.50 ns |        47.08 ns |       1.14 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        89.31 ns |       1.308 ns |        89.54 ns |        87.20 ns |        90.92 ns |       2.25 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        90.92 ns |       1.212 ns |        90.27 ns |        89.52 ns |        93.01 ns |       2.29 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 6.0 |       983.52 ns |      15.828 ns |       975.33 ns |       965.27 ns |     1,006.93 ns |      24.77 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
|             .NET 5.0 |     1,192.25 ns |      16.374 ns |     1,186.80 ns |     1,159.87 ns |     1,213.24 ns |      30.03 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
| .NET Framework 4.7.2 |     1,245.03 ns |       5.121 ns |     1,243.57 ns |     1,237.84 ns |     1,255.31 ns |      31.32 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
|   .NET Framework 4.8 |     1,260.55 ns |      17.012 ns |     1,257.75 ns |     1,234.04 ns |     1,295.03 ns |      31.76 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
|             .NET 6.0 |     5,906.55 ns |      71.986 ns |     5,889.31 ns |     5,823.12 ns |     6,038.38 ns |     148.58 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
|             .NET 5.0 |     6,518.69 ns |      50.433 ns |     6,520.45 ns |     6,435.39 ns |     6,630.29 ns |     164.00 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
| .NET Framework 4.7.2 |    10,071.52 ns |     104.867 ns |    10,085.50 ns |     9,940.84 ns |    10,312.83 ns |     253.63 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
|   .NET Framework 4.8 |    10,088.24 ns |     126.899 ns |    10,084.32 ns |     9,925.58 ns |    10,314.68 ns |     254.40 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        40.97 ns |       0.372 ns |        40.84 ns |        40.51 ns |        42.11 ns |       0.89 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 6.0 |        45.86 ns |       0.305 ns |        45.84 ns |        45.37 ns |        46.42 ns |       1.00 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        89.22 ns |       0.288 ns |        89.21 ns |        88.76 ns |        89.77 ns |       1.95 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        89.83 ns |       0.713 ns |        89.53 ns |        89.18 ns |        91.31 ns |       1.96 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 5.0 |    17,835.32 ns |     384.316 ns |    17,900.58 ns |    17,374.10 ns |    18,408.16 ns |     387.46 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |    18,098.88 ns |     408.240 ns |    17,948.02 ns |    17,585.78 ns |    19,129.18 ns |     394.84 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|   .NET Framework 4.8 |    21,332.08 ns |     305.891 ns |    21,214.31 ns |    21,012.66 ns |    21,941.79 ns |     465.55 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
| .NET Framework 4.7.2 |    21,392.04 ns |     360.994 ns |    21,212.45 ns |    20,995.96 ns |    22,236.99 ns |     466.88 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |   111,940.37 ns |     978.001 ns |   112,055.11 ns |   109,903.76 ns |   113,230.09 ns |   2,444.86 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|             .NET 5.0 |   125,630.71 ns |     990.301 ns |   125,435.24 ns |   124,361.91 ns |   127,804.30 ns |   2,744.30 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
| .NET Framework 4.7.2 |   190,634.68 ns |   2,554.278 ns |   190,550.37 ns |   187,678.32 ns |   196,408.91 ns |   4,163.50 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|   .NET Framework 4.8 |   193,702.34 ns |   1,335.853 ns |   194,006.23 ns |   191,345.43 ns |   195,211.52 ns |   4,231.31 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.86 ns |       0.209 ns |        38.89 ns |        38.52 ns |        39.26 ns |       1.00 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 5.0 |        41.18 ns |       0.606 ns |        41.54 ns |        40.25 ns |        41.80 ns |       1.06 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        88.08 ns |       1.966 ns |        87.47 ns |        85.80 ns |        92.45 ns |       2.28 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        93.04 ns |       1.038 ns |        92.68 ns |        91.83 ns |        95.06 ns |       2.40 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 6.0 |   381,417.48 ns |   3,384.696 ns |   380,944.97 ns |   376,204.20 ns |   388,903.32 ns |   9,814.40 |            List:WhereTake | 100000 |           WhereTake:100000 |  80.5664 |
|             .NET 5.0 |   384,184.02 ns |   7,153.899 ns |   382,656.59 ns |   372,966.94 ns |   395,144.73 ns |   9,884.14 |            List:WhereTake | 100000 |           WhereTake:100000 |  83.0078 |
| .NET Framework 4.7.2 |   445,885.91 ns |   3,872.163 ns |   446,211.96 ns |   436,990.48 ns |   451,999.95 ns |  11,473.32 |            List:WhereTake | 100000 |           WhereTake:100000 |  69.3359 |
|   .NET Framework 4.8 |   448,085.18 ns |   7,271.400 ns |   446,739.79 ns |   439,325.68 ns |   462,814.70 ns |  11,514.81 |            List:WhereTake | 100000 |           WhereTake:100000 |  69.3359 |
|             .NET 6.0 | 2,182,237.29 ns |  20,052.147 ns | 2,187,395.70 ns | 2,116,683.20 ns | 2,193,726.17 ns |  56,161.19 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|             .NET 5.0 | 2,497,430.46 ns |  33,468.450 ns | 2,494,741.21 ns | 2,457,180.66 ns | 2,554,146.29 ns |  64,156.47 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|   .NET Framework 4.8 | 3,845,325.47 ns |  35,896.564 ns | 3,831,103.91 ns | 3,798,153.12 ns | 3,915,163.28 ns |  98,945.12 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
| .NET Framework 4.7.2 | 4,221,761.87 ns |  24,121.417 ns | 4,217,942.58 ns | 4,181,768.36 ns | 4,278,009.77 ns | 108,651.35 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.06 ns |       0.442 ns |        37.82 ns |        37.60 ns |        38.81 ns |       1.00 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        42.36 ns |       0.565 ns |        42.34 ns |        41.57 ns |        43.32 ns |       1.11 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        81.96 ns |       0.838 ns |        81.82 ns |        80.64 ns |        83.14 ns |       2.15 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        85.80 ns |       0.525 ns |        85.82 ns |        85.11 ns |        87.09 ns |       2.25 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        88.54 ns |       0.976 ns |        88.43 ns |        87.43 ns |        90.69 ns |       2.32 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
|   .NET Framework 4.8 |        89.13 ns |       0.860 ns |        88.73 ns |        88.23 ns |        91.11 ns |       2.34 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        89.61 ns |       1.191 ns |        89.25 ns |        87.54 ns |        92.13 ns |       2.35 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |       104.65 ns |       1.433 ns |       105.15 ns |       102.77 ns |       107.48 ns |       2.75 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
|   .NET Framework 4.8 |       158.67 ns |       2.363 ns |       158.40 ns |       155.69 ns |       164.01 ns |       4.17 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
| .NET Framework 4.7.2 |       159.61 ns |       2.097 ns |       160.20 ns |       156.72 ns |       163.09 ns |       4.19 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       504.81 ns |       7.469 ns |       503.86 ns |       497.41 ns |       523.02 ns |      13.26 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
| .NET Framework 4.7.2 |       508.41 ns |       7.411 ns |       508.64 ns |       497.79 ns |       522.77 ns |      13.35 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        41.70 ns |       0.637 ns |        41.50 ns |        40.86 ns |        42.95 ns |       0.93 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 6.0 |        44.79 ns |       0.321 ns |        44.64 ns |        44.42 ns |        45.56 ns |       1.00 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        88.30 ns |       0.949 ns |        88.08 ns |        87.16 ns |        90.15 ns |       1.97 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        89.02 ns |       0.850 ns |        89.20 ns |        87.94 ns |        90.84 ns |       1.99 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 5.0 |       979.00 ns |      27.107 ns |       969.93 ns |       951.00 ns |     1,049.36 ns |      21.97 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|             .NET 6.0 |     1,006.38 ns |      17.341 ns |     1,003.64 ns |       980.15 ns |     1,030.14 ns |      22.50 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|   .NET Framework 4.8 |     1,223.96 ns |      22.616 ns |     1,209.34 ns |     1,198.85 ns |     1,253.06 ns |      27.24 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     1,227.06 ns |      18.515 ns |     1,220.54 ns |     1,198.59 ns |     1,252.14 ns |      27.47 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     6,140.43 ns |     113.858 ns |     6,103.17 ns |     6,029.30 ns |     6,431.25 ns |     137.33 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0992 |
|             .NET 5.0 |     6,736.79 ns |      73.247 ns |     6,733.51 ns |     6,643.45 ns |     6,868.26 ns |     150.42 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
| .NET Framework 4.7.2 |    19,027.16 ns |     166.456 ns |    19,020.83 ns |    18,780.17 ns |    19,383.23 ns |     424.99 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|   .NET Framework 4.8 |    21,390.33 ns |     994.339 ns |    21,620.80 ns |    19,390.69 ns |    23,774.60 ns |     475.46 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        39.92 ns |       0.531 ns |        39.90 ns |        39.29 ns |        40.82 ns |       1.00 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        51.70 ns |       0.954 ns |        51.90 ns |        50.51 ns |        53.45 ns |       1.30 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        88.94 ns |       1.272 ns |        88.55 ns |        86.85 ns |        91.25 ns |       2.23 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        89.79 ns |       1.401 ns |        90.11 ns |        87.63 ns |        92.50 ns |       2.25 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 6.0 |    16,819.99 ns |     131.872 ns |    16,808.44 ns |    16,649.45 ns |    17,114.61 ns |     421.39 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 5.0 |    16,852.29 ns |     355.050 ns |    16,654.22 ns |    16,533.11 ns |    17,515.23 ns |     424.49 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    20,350.67 ns |     136.707 ns |    20,365.19 ns |    19,990.55 ns |    20,596.79 ns |     509.21 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    20,440.12 ns |     198.337 ns |    20,370.62 ns |    20,224.30 ns |    20,897.28 ns |     511.19 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   112,942.24 ns |   4,742.839 ns |   110,615.36 ns |   108,428.52 ns |   120,905.07 ns |   2,877.44 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|             .NET 5.0 |   122,665.99 ns |     679.651 ns |   122,529.39 ns |   121,772.63 ns |   124,029.86 ns |   3,069.25 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|   .NET Framework 4.8 |   369,607.45 ns |   5,233.547 ns |   366,918.12 ns |   363,797.56 ns |   376,776.86 ns |   9,275.29 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   370,681.15 ns |   4,962.991 ns |   369,392.24 ns |   365,101.27 ns |   380,968.02 ns |   9,303.16 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        40.06 ns |       0.364 ns |        40.00 ns |        39.48 ns |        40.99 ns |       1.00 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 6.0 |        40.14 ns |       0.911 ns |        40.14 ns |        38.71 ns |        42.63 ns |       1.00 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        89.54 ns |       0.301 ns |        89.56 ns |        89.10 ns |        90.12 ns |       2.24 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        89.80 ns |       0.529 ns |        89.80 ns |        89.13 ns |        91.02 ns |       2.24 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 5.0 |   334,507.54 ns |   2,281.962 ns |   333,753.08 ns |   332,297.51 ns |   340,347.66 ns |   8,359.89 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 6.0 |   342,733.81 ns |   4,399.287 ns |   341,715.92 ns |   334,482.76 ns |   351,811.87 ns |   8,564.16 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   403,600.91 ns |   2,251.865 ns |   403,787.38 ns |   399,998.54 ns |   407,783.11 ns |  10,086.07 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 |   404,756.48 ns |   6,394.859 ns |   401,975.05 ns |   399,011.18 ns |   417,502.00 ns |  10,105.42 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 6.0 | 2,313,048.38 ns |  55,757.301 ns | 2,294,218.36 ns | 2,269,726.95 ns | 2,493,421.48 ns |  57,848.24 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 5.0 | 2,493,062.59 ns |  24,892.810 ns | 2,485,050.00 ns | 2,465,754.30 ns | 2,553,668.75 ns |  62,299.11 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,295,365.93 ns |  33,096.594 ns | 7,299,718.75 ns | 7,238,435.94 ns | 7,357,910.94 ns | 182,302.93 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 | 7,305,808.48 ns |  39,060.720 ns | 7,294,449.22 ns | 7,259,298.44 ns | 7,398,768.75 ns | 182,579.96 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
