# Benchmark Run at 10/7/2021 9:12:41 PM


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
  Job-POWYZS : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-NOMUDD : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-ACFIHV : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT
  Job-TUGYHN : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```

|              Runtime |            Mean |         StdDev |          Median |             Min |             Max |      Ratio |                  Use Case |  Count |               LogicalGroup |    Gen 0 |
|--------------------- |----------------:|---------------:|----------------:|----------------:|----------------:|-----------:|-------------------------- |------- |--------------------------- |---------:|
|             .NET 5.0 |        44.92 ns |       0.341 ns |        44.91 ns |        44.24 ns |        45.41 ns |       0.95 |                List:First |      1 |               First:000001 |   0.0114 |
|             .NET 5.0 |        45.31 ns |       1.352 ns |        44.46 ns |        43.71 ns |        47.80 ns |       0.97 |                Linq:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        47.48 ns |       0.791 ns |        47.12 ns |        46.51 ns |        48.97 ns |       1.00 |                List:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        50.00 ns |       1.107 ns |        49.52 ns |        48.65 ns |        52.10 ns |       1.06 |                Linq:First |      1 |               First:000001 |   0.0114 |
|             .NET 6.0 |        57.15 ns |       2.928 ns |        56.42 ns |        53.95 ns |        63.21 ns |       1.22 |               Array:First |      1 |               First:000001 |   0.0114 |
|             .NET 5.0 |        57.24 ns |       1.351 ns |        56.75 ns |        55.58 ns |        59.38 ns |       1.21 |               Array:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       126.70 ns |       2.844 ns |       125.68 ns |       122.84 ns |       131.06 ns |       2.67 |                List:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       127.66 ns |       2.901 ns |       127.97 ns |       123.47 ns |       131.96 ns |       2.69 |                List:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       127.95 ns |       3.050 ns |       126.60 ns |       123.90 ns |       134.80 ns |       2.71 |                Linq:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       130.23 ns |       2.990 ns |       131.03 ns |       125.24 ns |       135.54 ns |       2.76 |                Linq:First |      1 |               First:000001 |   0.0114 |
| .NET Framework 4.7.2 |       187.36 ns |       4.848 ns |       184.76 ns |       181.88 ns |       197.10 ns |       3.94 |               Array:First |      1 |               First:000001 |   0.0114 |
|   .NET Framework 4.8 |       191.56 ns |       4.826 ns |       190.99 ns |       185.76 ns |       198.55 ns |       4.04 |               Array:First |      1 |               First:000001 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.48 ns |       1.059 ns |        45.87 ns |        45.18 ns |        48.03 ns |       0.97 |                Linq:First |    250 |               First:000250 |   0.0114 |
|             .NET 5.0 |        47.37 ns |       1.115 ns |        46.73 ns |        46.07 ns |        49.11 ns |       0.99 |                List:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        48.09 ns |       0.877 ns |        47.85 ns |        46.89 ns |        49.62 ns |       1.00 |                List:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        51.00 ns |       1.466 ns |        50.70 ns |        49.12 ns |        54.11 ns |       1.08 |                Linq:First |    250 |               First:000250 |   0.0114 |
|             .NET 5.0 |        54.74 ns |       1.049 ns |        54.38 ns |        53.27 ns |        56.50 ns |       1.14 |               Array:First |    250 |               First:000250 |   0.0114 |
|             .NET 6.0 |        55.52 ns |       1.255 ns |        54.78 ns |        54.45 ns |        58.10 ns |       1.16 |               Array:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       126.03 ns |       3.151 ns |       124.43 ns |       121.64 ns |       131.00 ns |       2.63 |                Linq:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       126.92 ns |       2.997 ns |       125.53 ns |       123.47 ns |       131.67 ns |       2.64 |                List:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       127.08 ns |       2.591 ns |       126.24 ns |       123.91 ns |       131.22 ns |       2.64 |                List:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       128.04 ns |       2.735 ns |       127.23 ns |       124.19 ns |       132.86 ns |       2.67 |                Linq:First |    250 |               First:000250 |   0.0114 |
|   .NET Framework 4.8 |       189.69 ns |       1.717 ns |       188.94 ns |       187.87 ns |       194.02 ns |       3.95 |               Array:First |    250 |               First:000250 |   0.0114 |
| .NET Framework 4.7.2 |       191.55 ns |       4.662 ns |       190.24 ns |       186.86 ns |       204.17 ns |       4.01 |               Array:First |    250 |               First:000250 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.85 ns |       0.178 ns |        44.86 ns |        44.55 ns |        45.27 ns |       0.99 |                List:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        45.42 ns |       0.334 ns |        45.38 ns |        44.78 ns |        45.99 ns |       1.00 |                List:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        45.89 ns |       1.374 ns |        45.19 ns |        44.58 ns |        49.08 ns |       1.03 |                Linq:First |   5000 |               First:005000 |   0.0114 |
|             .NET 5.0 |        48.22 ns |       1.151 ns |        48.33 ns |        46.58 ns |        49.57 ns |       1.06 |                Linq:First |   5000 |               First:005000 |   0.0114 |
|             .NET 5.0 |        58.44 ns |       0.503 ns |        58.43 ns |        57.50 ns |        59.14 ns |       1.29 |               Array:First |   5000 |               First:005000 |   0.0114 |
|             .NET 6.0 |        59.31 ns |       1.860 ns |        58.49 ns |        57.03 ns |        64.31 ns |       1.33 |               Array:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       126.25 ns |       2.970 ns |       124.77 ns |       123.41 ns |       131.70 ns |       2.78 |                List:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       126.96 ns |       2.513 ns |       126.01 ns |       124.91 ns |       132.93 ns |       2.80 |                Linq:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       127.15 ns |       3.538 ns |       125.56 ns |       122.63 ns |       135.08 ns |       2.81 |                List:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       128.58 ns |       2.714 ns |       128.12 ns |       125.06 ns |       133.90 ns |       2.82 |                Linq:First |   5000 |               First:005000 |   0.0114 |
| .NET Framework 4.7.2 |       189.59 ns |       3.468 ns |       188.48 ns |       185.69 ns |       195.80 ns |       4.17 |               Array:First |   5000 |               First:005000 |   0.0114 |
|   .NET Framework 4.8 |       191.50 ns |       3.417 ns |       190.13 ns |       188.00 ns |       197.73 ns |       4.21 |               Array:First |   5000 |               First:005000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.99 ns |       1.047 ns |        44.37 ns |        43.78 ns |        46.42 ns |       0.95 |                List:First | 100000 |               First:100000 |   0.0114 |
|             .NET 5.0 |        45.16 ns |       0.356 ns |        45.04 ns |        44.72 ns |        45.99 ns |       0.95 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        47.85 ns |       1.558 ns |        46.97 ns |        46.22 ns |        51.61 ns |       1.00 |                List:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        48.84 ns |       0.324 ns |        48.84 ns |        48.34 ns |        49.59 ns |       1.03 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|             .NET 5.0 |        55.10 ns |       0.372 ns |        55.12 ns |        54.43 ns |        55.74 ns |       1.16 |               Array:First | 100000 |               First:100000 |   0.0114 |
|             .NET 6.0 |        57.05 ns |       0.702 ns |        57.23 ns |        54.80 ns |        57.46 ns |       1.21 |               Array:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       123.90 ns |       0.935 ns |       123.57 ns |       122.82 ns |       126.33 ns |       2.62 |                List:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       124.89 ns |       1.227 ns |       124.76 ns |       123.37 ns |       128.22 ns |       2.64 |                List:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       125.62 ns |       0.761 ns |       125.62 ns |       124.26 ns |       126.95 ns |       2.65 |                Linq:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       127.41 ns |       2.480 ns |       126.20 ns |       124.66 ns |       132.51 ns |       2.67 |                Linq:First | 100000 |               First:100000 |   0.0114 |
| .NET Framework 4.7.2 |       188.30 ns |       1.341 ns |       188.44 ns |       185.28 ns |       190.41 ns |       3.98 |               Array:First | 100000 |               First:100000 |   0.0114 |
|   .NET Framework 4.8 |       189.79 ns |       3.581 ns |       187.86 ns |       186.37 ns |       196.51 ns |       3.98 |               Array:First | 100000 |               First:100000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        85.76 ns |       4.046 ns |        84.13 ns |        81.43 ns |        94.99 ns |       1.00 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |        88.08 ns |       2.164 ns |        87.08 ns |        85.66 ns |        92.88 ns |       1.01 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 6.0 |        88.80 ns |       1.244 ns |        88.86 ns |        85.44 ns |        90.43 ns |       0.99 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |        89.10 ns |       0.573 ns |        89.04 ns |        88.40 ns |        90.30 ns |       1.00 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 5.0 |        99.63 ns |       2.569 ns |       100.73 ns |        95.58 ns |       103.06 ns |       1.13 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|             .NET 6.0 |       114.92 ns |       0.882 ns |       114.91 ns |       113.57 ns |       116.28 ns |       1.28 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       197.07 ns |       4.197 ns |       195.00 ns |       192.24 ns |       203.36 ns |       2.23 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       197.63 ns |       4.747 ns |       197.51 ns |       191.68 ns |       205.28 ns |       2.26 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       199.39 ns |       3.476 ns |       198.05 ns |       195.14 ns |       204.65 ns |       2.23 |           List:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       200.11 ns |       5.055 ns |       199.64 ns |       192.88 ns |       209.05 ns |       2.28 |           Linq:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|   .NET Framework 4.8 |       258.67 ns |       5.612 ns |       257.48 ns |       251.54 ns |       267.28 ns |       2.93 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
| .NET Framework 4.7.2 |       264.31 ns |       5.568 ns |       266.71 ns |       254.94 ns |       270.77 ns |       2.98 |          Array:FirstWhere |      1 |          FirstWhere:000001 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        80.72 ns |       1.827 ns |        80.57 ns |        78.29 ns |        83.89 ns |       1.00 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 6.0 |        84.10 ns |       0.641 ns |        83.97 ns |        83.08 ns |        85.68 ns |       1.05 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        90.04 ns |       1.293 ns |        89.87 ns |        88.08 ns |        92.11 ns |       1.12 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 6.0 |        90.71 ns |       2.054 ns |        90.06 ns |        88.15 ns |        94.59 ns |       1.12 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        93.51 ns |       3.411 ns |        92.04 ns |        90.20 ns |       102.07 ns |       1.18 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|             .NET 5.0 |        96.53 ns |       1.429 ns |        96.02 ns |        94.92 ns |        99.70 ns |       1.20 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       195.83 ns |       4.293 ns |       193.70 ns |       190.89 ns |       205.45 ns |       2.43 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       196.57 ns |       4.336 ns |       195.87 ns |       190.69 ns |       204.64 ns |       2.44 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       197.53 ns |       3.907 ns |       195.70 ns |       192.94 ns |       204.05 ns |       2.45 |           List:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       199.88 ns |       4.655 ns |       197.59 ns |       194.79 ns |       209.83 ns |       2.48 |           Linq:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|   .NET Framework 4.8 |       260.59 ns |       5.788 ns |       259.40 ns |       253.62 ns |       275.21 ns |       3.23 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
| .NET Framework 4.7.2 |       261.38 ns |       4.416 ns |       262.59 ns |       255.02 ns |       268.55 ns |       3.24 |          Array:FirstWhere |    250 |          FirstWhere:000250 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        82.79 ns |       1.624 ns |        82.19 ns |        80.78 ns |        85.76 ns |       0.93 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 6.0 |        85.95 ns |       4.242 ns |        84.50 ns |        81.00 ns |        98.11 ns |       1.00 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 5.0 |        87.17 ns |       0.585 ns |        87.27 ns |        86.39 ns |        88.53 ns |       0.98 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 6.0 |        90.41 ns |       1.235 ns |        90.04 ns |        89.24 ns |        93.32 ns |       1.01 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 6.0 |        93.71 ns |       1.832 ns |        92.93 ns |        91.80 ns |        97.18 ns |       1.05 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|             .NET 5.0 |        97.64 ns |       1.901 ns |        97.12 ns |        95.40 ns |       101.28 ns |       1.09 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       196.72 ns |       4.206 ns |       195.01 ns |       191.54 ns |       204.57 ns |       2.20 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       196.88 ns |       3.711 ns |       195.41 ns |       193.36 ns |       204.13 ns |       2.21 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       198.99 ns |       1.370 ns |       198.80 ns |       196.85 ns |       201.44 ns |       2.25 |           Linq:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       199.50 ns |       3.014 ns |       199.20 ns |       195.04 ns |       204.82 ns |       2.24 |           List:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
| .NET Framework 4.7.2 |       260.70 ns |       3.786 ns |       259.48 ns |       255.49 ns |       268.13 ns |       2.93 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|   .NET Framework 4.8 |       265.61 ns |       4.556 ns |       264.53 ns |       258.98 ns |       272.29 ns |       2.99 |          Array:FirstWhere |   5000 |          FirstWhere:005000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        86.12 ns |       3.977 ns |        84.31 ns |        82.38 ns |        95.89 ns |       1.00 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|             .NET 5.0 |        87.08 ns |       1.594 ns |        86.47 ns |        85.40 ns |        90.08 ns |       0.98 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|   .NET Framework 4.8 |       193.24 ns |       1.694 ns |       192.90 ns |       191.11 ns |       197.01 ns |       2.16 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
| .NET Framework 4.7.2 |       194.53 ns |       2.188 ns |       193.88 ns |       192.27 ns |       198.97 ns |       2.17 |           Linq:FirstWhere | 100000 |          FirstWhere:010000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        91.61 ns |       2.344 ns |        91.70 ns |        87.71 ns |        94.55 ns |       1.00 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 6.0 |        97.90 ns |       2.286 ns |        98.35 ns |        94.36 ns |       101.06 ns |       1.07 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 5.0 |        97.95 ns |       1.761 ns |        98.59 ns |        95.39 ns |       100.33 ns |       1.06 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|             .NET 5.0 |       102.23 ns |       1.090 ns |       102.01 ns |       101.04 ns |       105.00 ns |       1.11 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|   .NET Framework 4.8 |       194.98 ns |       0.803 ns |       194.96 ns |       193.53 ns |       196.04 ns |       2.10 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
| .NET Framework 4.7.2 |       196.27 ns |       1.058 ns |       196.26 ns |       194.55 ns |       198.06 ns |       2.12 |           List:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|   .NET Framework 4.8 |       259.05 ns |       2.767 ns |       257.75 ns |       256.08 ns |       264.35 ns |       2.80 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
| .NET Framework 4.7.2 |       259.54 ns |       1.530 ns |       259.83 ns |       256.96 ns |       261.67 ns |       2.81 |          Array:FirstWhere | 100000 |          FirstWhere:100000 |   0.0343 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.87 ns |       0.931 ns |        44.43 ns |        43.84 ns |        46.51 ns |       0.97 |                 List:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 5.0 |        44.90 ns |       0.256 ns |        44.90 ns |        44.37 ns |        45.35 ns |       0.96 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        46.01 ns |       1.344 ns |        45.29 ns |        44.63 ns |        50.28 ns |       1.00 |                 List:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        50.36 ns |       1.250 ns |        49.84 ns |        48.98 ns |        52.36 ns |       1.09 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 5.0 |        56.77 ns |       1.587 ns |        56.26 ns |        54.67 ns |        60.27 ns |       1.24 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|             .NET 6.0 |        65.46 ns |       1.282 ns |        65.05 ns |        64.28 ns |        68.74 ns |       1.40 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       126.28 ns |       2.754 ns |       125.99 ns |       121.77 ns |       129.79 ns |       2.72 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       126.94 ns |       2.773 ns |       127.69 ns |       123.04 ns |       131.20 ns |       2.74 |                 List:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       128.44 ns |       3.111 ns |       128.96 ns |       123.70 ns |       132.56 ns |       2.78 |                 Linq:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       128.99 ns |       2.964 ns |       129.97 ns |       125.31 ns |       134.41 ns |       2.79 |                 List:Last |      1 |                Last:000001 |   0.0114 |
| .NET Framework 4.7.2 |       183.92 ns |       0.589 ns |       183.78 ns |       182.86 ns |       185.15 ns |       3.95 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|   .NET Framework 4.8 |       191.10 ns |       4.041 ns |       190.94 ns |       184.93 ns |       199.13 ns |       4.11 |                Array:Last |      1 |                Last:000001 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.26 ns |       1.085 ns |        43.82 ns |        42.99 ns |        46.39 ns |       0.97 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 5.0 |        45.37 ns |       1.206 ns |        45.02 ns |        44.06 ns |        48.15 ns |       0.99 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        45.79 ns |       0.983 ns |        45.45 ns |        44.80 ns |        47.93 ns |       1.00 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        49.41 ns |       1.073 ns |        49.15 ns |        48.14 ns |        51.50 ns |       1.08 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 5.0 |        55.03 ns |       0.973 ns |        54.68 ns |        54.28 ns |        57.37 ns |       1.20 |                Array:Last |    250 |                Last:000250 |   0.0114 |
|             .NET 6.0 |        63.37 ns |       1.257 ns |        63.15 ns |        61.62 ns |        65.74 ns |       1.38 |                Array:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       125.85 ns |       2.483 ns |       124.73 ns |       123.89 ns |       131.19 ns |       2.75 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       126.49 ns |       2.661 ns |       125.20 ns |       123.05 ns |       130.80 ns |       2.76 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       126.54 ns |       2.912 ns |       125.27 ns |       123.67 ns |       132.07 ns |       2.77 |                 Linq:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       129.68 ns |       3.053 ns |       129.63 ns |       125.51 ns |       135.91 ns |       2.84 |                 List:Last |    250 |                Last:000250 |   0.0114 |
|   .NET Framework 4.8 |       186.35 ns |       4.232 ns |       183.92 ns |       182.17 ns |       194.34 ns |       4.07 |                Array:Last |    250 |                Last:000250 |   0.0114 |
| .NET Framework 4.7.2 |       187.34 ns |       5.114 ns |       186.22 ns |       180.52 ns |       200.93 ns |       4.12 |                Array:Last |    250 |                Last:000250 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.00 ns |       1.043 ns |        46.09 ns |        44.69 ns |        48.34 ns |       0.99 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 5.0 |        46.19 ns |       0.288 ns |        46.19 ns |        45.75 ns |        46.67 ns |       0.99 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 6.0 |        46.51 ns |       0.643 ns |        46.31 ns |        45.96 ns |        47.99 ns |       1.00 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 6.0 |        47.26 ns |       0.848 ns |        46.77 ns |        46.15 ns |        48.56 ns |       1.02 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 6.0 |        56.83 ns |       1.130 ns |        56.61 ns |        55.40 ns |        58.66 ns |       1.23 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
|             .NET 5.0 |        58.00 ns |       1.111 ns |        57.87 ns |        56.08 ns |        59.90 ns |       1.25 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       125.85 ns |       0.902 ns |       125.89 ns |       123.82 ns |       127.23 ns |       2.70 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       125.99 ns |       1.986 ns |       125.68 ns |       123.44 ns |       129.81 ns |       2.71 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       126.03 ns |       1.574 ns |       125.51 ns |       124.08 ns |       129.44 ns |       2.71 |                 Linq:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       126.37 ns |       2.836 ns |       125.02 ns |       123.72 ns |       131.69 ns |       2.73 |                 List:Last |   5000 |                Last:005000 |   0.0114 |
|   .NET Framework 4.8 |       187.72 ns |       2.014 ns |       187.32 ns |       184.41 ns |       191.89 ns |       4.04 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
| .NET Framework 4.7.2 |       189.46 ns |       2.757 ns |       188.84 ns |       185.26 ns |       195.35 ns |       4.08 |                Array:Last |   5000 |                Last:005000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.50 ns |       2.304 ns |        45.58 ns |        44.25 ns |        51.21 ns |       0.99 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        46.54 ns |       0.398 ns |        46.63 ns |        45.78 ns |        47.17 ns |       1.00 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 5.0 |        47.33 ns |       1.067 ns |        47.60 ns |        45.27 ns |        49.32 ns |       1.01 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        52.20 ns |       1.049 ns |        52.26 ns |        50.61 ns |        54.74 ns |       1.12 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 5.0 |        59.42 ns |       1.667 ns |        58.60 ns |        57.11 ns |        62.72 ns |       1.27 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|             .NET 6.0 |        61.20 ns |       1.649 ns |        60.36 ns |        59.50 ns |        64.84 ns |       1.34 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       124.18 ns |       1.094 ns |       123.89 ns |       122.32 ns |       126.77 ns |       2.67 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       124.72 ns |       1.098 ns |       125.19 ns |       122.81 ns |       126.20 ns |       2.68 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       126.22 ns |       1.316 ns |       125.71 ns |       124.62 ns |       129.44 ns |       2.72 |                 Linq:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       126.96 ns |       2.064 ns |       126.15 ns |       124.73 ns |       131.27 ns |       2.74 |                 List:Last | 100000 |                Last:100000 |   0.0114 |
|   .NET Framework 4.8 |       189.77 ns |       3.579 ns |       188.17 ns |       186.16 ns |       197.82 ns |       4.08 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
| .NET Framework 4.7.2 |       191.28 ns |       4.820 ns |       189.88 ns |       185.47 ns |       202.35 ns |       4.14 |                Array:Last | 100000 |                Last:100000 |   0.0114 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        73.46 ns |       1.972 ns |        73.20 ns |        70.83 ns |        77.16 ns |       1.00 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 6.0 |        77.12 ns |       1.095 ns |        76.74 ns |        75.85 ns |        80.07 ns |       1.05 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        77.41 ns |       1.988 ns |        76.55 ns |        75.68 ns |        81.98 ns |       1.06 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        80.36 ns |       1.279 ns |        80.03 ns |        78.68 ns |        83.29 ns |       1.09 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 6.0 |        82.46 ns |       0.903 ns |        82.25 ns |        81.44 ns |        85.04 ns |       1.12 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
|             .NET 5.0 |        89.19 ns |       0.617 ns |        88.94 ns |        88.45 ns |        90.38 ns |       1.21 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0254 |
| .NET Framework 4.7.2 |       185.35 ns |       4.153 ns |       183.67 ns |       180.51 ns |       192.48 ns |       2.51 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
| .NET Framework 4.7.2 |       188.40 ns |       3.815 ns |       187.47 ns |       183.57 ns |       193.71 ns |       2.54 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|   .NET Framework 4.8 |       191.54 ns |       3.551 ns |       192.40 ns |       185.54 ns |       197.22 ns |       2.59 |            Linq:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|   .NET Framework 4.8 |       192.02 ns |       6.014 ns |       194.06 ns |       183.81 ns |       206.53 ns |       2.61 |            List:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|   .NET Framework 4.8 |       258.16 ns |       5.390 ns |       256.98 ns |       251.29 ns |       266.36 ns |       3.49 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
| .NET Framework 4.7.2 |       260.14 ns |       5.563 ns |       259.07 ns |       252.91 ns |       267.81 ns |       3.52 |           Array:LastWhere |      1 |           LastWhere:000001 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        71.33 ns |       1.159 ns |        70.95 ns |        69.69 ns |        74.37 ns |       1.00 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        76.35 ns |       1.079 ns |        75.95 ns |        75.02 ns |        78.76 ns |       1.07 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        77.14 ns |       0.719 ns |        77.02 ns |        76.13 ns |        78.70 ns |       1.08 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 6.0 |        80.06 ns |       1.721 ns |        79.00 ns |        77.75 ns |        82.56 ns |       1.12 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 6.0 |        85.98 ns |       1.641 ns |        85.98 ns |        83.88 ns |        88.04 ns |       1.21 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|             .NET 5.0 |        88.06 ns |       2.771 ns |        86.68 ns |        85.33 ns |        96.45 ns |       1.25 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0254 |
|   .NET Framework 4.8 |       189.88 ns |       3.843 ns |       189.22 ns |       184.98 ns |       195.55 ns |       2.66 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
| .NET Framework 4.7.2 |       190.10 ns |       4.362 ns |       188.77 ns |       184.81 ns |       196.24 ns |       2.67 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
| .NET Framework 4.7.2 |       192.53 ns |       4.262 ns |       194.52 ns |       185.33 ns |       199.16 ns |       2.69 |            Linq:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|   .NET Framework 4.8 |       193.77 ns |       3.600 ns |       194.03 ns |       188.49 ns |       198.78 ns |       2.72 |            List:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
| .NET Framework 4.7.2 |       256.13 ns |       7.335 ns |       253.63 ns |       247.53 ns |       277.62 ns |       3.60 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|   .NET Framework 4.8 |       261.38 ns |       7.779 ns |       262.70 ns |       249.52 ns |       278.62 ns |       3.67 |           Array:LastWhere |    250 |           LastWhere:000250 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        76.77 ns |       1.601 ns |        76.66 ns |        74.11 ns |        79.21 ns |       1.00 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        77.24 ns |       0.401 ns |        77.33 ns |        76.65 ns |        78.06 ns |       1.00 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 6.0 |        77.49 ns |       1.738 ns |        77.99 ns |        74.67 ns |        80.32 ns |       1.01 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        83.76 ns |       1.411 ns |        83.10 ns |        82.34 ns |        86.56 ns |       1.09 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 5.0 |        84.19 ns |       1.798 ns |        83.54 ns |        81.82 ns |        87.45 ns |       1.10 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
|             .NET 6.0 |        99.37 ns |       2.306 ns |        98.64 ns |        96.46 ns |       104.15 ns |       1.30 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0254 |
| .NET Framework 4.7.2 |       185.21 ns |       0.765 ns |       185.17 ns |       183.74 ns |       186.22 ns |       2.41 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|   .NET Framework 4.8 |       185.75 ns |       1.542 ns |       185.56 ns |       182.83 ns |       189.38 ns |       2.41 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|   .NET Framework 4.8 |       189.73 ns |       3.611 ns |       188.11 ns |       185.93 ns |       197.14 ns |       2.47 |            Linq:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
| .NET Framework 4.7.2 |       194.16 ns |       4.382 ns |       195.03 ns |       187.49 ns |       200.59 ns |       2.53 |            List:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
| .NET Framework 4.7.2 |       251.43 ns |       2.080 ns |       251.27 ns |       248.79 ns |       256.56 ns |       3.27 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|   .NET Framework 4.8 |       257.32 ns |       2.591 ns |       257.26 ns |       253.22 ns |       261.67 ns |       3.35 |           Array:LastWhere |   5000 |           LastWhere:005000 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        76.63 ns |       2.381 ns |        75.39 ns |        74.33 ns |        82.64 ns |       1.00 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 6.0 |        79.88 ns |       1.788 ns |        78.78 ns |        78.07 ns |        83.03 ns |       1.03 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        82.12 ns |       1.527 ns |        81.34 ns |        80.49 ns |        85.05 ns |       1.06 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        86.89 ns |       2.474 ns |        87.55 ns |        83.72 ns |        91.14 ns |       1.13 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 6.0 |        89.77 ns |       3.037 ns |        89.73 ns |        84.86 ns |        97.75 ns |       1.17 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
|             .NET 5.0 |        90.27 ns |       1.819 ns |        89.74 ns |        88.08 ns |        95.39 ns |       1.17 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0254 |
| .NET Framework 4.7.2 |       188.11 ns |       4.507 ns |       186.82 ns |       182.77 ns |       198.34 ns |       2.44 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
| .NET Framework 4.7.2 |       190.25 ns |       1.132 ns |       189.91 ns |       189.02 ns |       192.31 ns |       2.46 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       191.26 ns |       0.902 ns |       191.21 ns |       189.81 ns |       193.45 ns |       2.46 |            List:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       191.38 ns |       3.812 ns |       190.18 ns |       188.31 ns |       203.04 ns |       2.47 |            Linq:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
| .NET Framework 4.7.2 |       253.31 ns |       1.916 ns |       253.48 ns |       250.07 ns |       256.81 ns |       3.29 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|   .NET Framework 4.8 |       256.34 ns |       5.213 ns |       254.15 ns |       251.20 ns |       266.65 ns |       3.30 |           Array:LastWhere | 100000 |           LastWhere:100000 |   0.0253 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        48.14 ns |       1.432 ns |        47.84 ns |        46.26 ns |        51.57 ns |       0.90 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 6.0 |        54.96 ns |       3.280 ns |        54.53 ns |        50.10 ns |        62.95 ns |       1.00 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|   .NET Framework 4.8 |        94.87 ns |       3.835 ns |        94.49 ns |        89.73 ns |       105.08 ns |       1.74 |              Array:Select |      1 |              Select:000001 |   0.0153 |
| .NET Framework 4.7.2 |        96.24 ns |       2.417 ns |        96.00 ns |        92.17 ns |       100.68 ns |       1.83 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 5.0 |       109.62 ns |       1.618 ns |       110.18 ns |       106.32 ns |       112.32 ns |       2.14 |               List:Select |      1 |              Select:000001 |   0.0650 |
|             .NET 6.0 |       112.49 ns |       7.431 ns |       111.10 ns |       102.07 ns |       134.43 ns |       2.05 |               List:Select |      1 |              Select:000001 |   0.0650 |
|   .NET Framework 4.8 |       158.48 ns |       5.537 ns |       156.36 ns |       150.60 ns |       173.30 ns |       2.94 |               List:Select |      1 |              Select:000001 |   0.0675 |
| .NET Framework 4.7.2 |       160.87 ns |       5.394 ns |       159.23 ns |       153.96 ns |       174.60 ns |       2.99 |               List:Select |      1 |              Select:000001 |   0.0675 |
|             .NET 5.0 |     5,101.07 ns |     198.292 ns |     5,059.15 ns |     4,828.24 ns |     5,648.03 ns |      93.75 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|             .NET 6.0 |     5,471.22 ns |     303.074 ns |     5,458.12 ns |     5,068.02 ns |     6,166.55 ns |      99.99 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|   .NET Framework 4.8 |     7,288.78 ns |     239.622 ns |     7,228.81 ns |     6,954.19 ns |     7,885.39 ns |     135.38 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
| .NET Framework 4.7.2 |     7,409.92 ns |     355.115 ns |     7,388.25 ns |     6,854.41 ns |     8,465.17 ns |     135.32 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        42.86 ns |       0.654 ns |        42.79 ns |        41.79 ns |        43.89 ns |       1.00 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 5.0 |        47.99 ns |       2.626 ns |        47.15 ns |        44.49 ns |        54.48 ns |       1.17 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|   .NET Framework 4.8 |        96.98 ns |       4.382 ns |        96.06 ns |        90.64 ns |       106.85 ns |       2.33 |              Array:Select |    250 |              Select:000250 |   0.0153 |
| .NET Framework 4.7.2 |        98.42 ns |       4.940 ns |        97.02 ns |        92.32 ns |       112.77 ns |       2.30 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 6.0 |     5,337.70 ns |     168.384 ns |     5,320.97 ns |     5,059.76 ns |     5,733.67 ns |     126.42 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 5.0 |     5,356.50 ns |     254.576 ns |     5,297.83 ns |     5,078.83 ns |     6,212.67 ns |     128.66 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 5.0 |     6,892.13 ns |     164.332 ns |     6,892.53 ns |     6,667.04 ns |     7,297.72 ns |     160.39 |               List:Select |    250 |              Select:000250 |   2.0142 |
|             .NET 6.0 |     7,011.27 ns |     182.223 ns |     6,956.98 ns |     6,705.65 ns |     7,305.11 ns |     165.41 |               List:Select |    250 |              Select:000250 |   2.0142 |
| .NET Framework 4.7.2 |     7,115.75 ns |     167.253 ns |     7,064.38 ns |     6,944.25 ns |     7,439.83 ns |     166.85 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|   .NET Framework 4.8 |     7,128.60 ns |     228.684 ns |     7,057.87 ns |     6,851.24 ns |     7,760.10 ns |     168.80 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|   .NET Framework 4.8 |     7,415.91 ns |     157.659 ns |     7,344.56 ns |     7,204.67 ns |     7,744.19 ns |     172.94 |               List:Select |    250 |              Select:000250 |   2.0142 |
| .NET Framework 4.7.2 |     7,555.81 ns |     195.094 ns |     7,493.13 ns |     7,298.01 ns |     8,090.88 ns |     176.60 |               List:Select |    250 |              Select:000250 |   2.0142 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        45.42 ns |       2.346 ns |        44.95 ns |        42.29 ns |        52.12 ns |       1.00 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 5.0 |        47.21 ns |       1.707 ns |        47.74 ns |        44.51 ns |        51.60 ns |       1.03 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.94 ns |       1.793 ns |        93.71 ns |        91.34 ns |        97.90 ns |       2.10 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|   .NET Framework 4.8 |        98.27 ns |       4.658 ns |        97.32 ns |        90.58 ns |       110.66 ns |       2.16 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 5.0 |   104,771.45 ns |   2,417.995 ns |   105,355.38 ns |    98,773.24 ns |   108,252.05 ns |   2,318.78 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 6.0 |   106,661.53 ns |   4,888.942 ns |   106,171.69 ns |    97,096.02 ns |   116,866.41 ns |   2,342.88 |               Linq:Select |   5000 |              Select:005000 |        - |
| .NET Framework 4.7.2 |   140,997.68 ns |   5,541.032 ns |   140,216.72 ns |   134,346.17 ns |   154,963.48 ns |   3,063.34 |               Linq:Select |   5000 |              Select:005000 |        - |
|   .NET Framework 4.8 |   144,174.03 ns |   4,641.883 ns |   142,782.53 ns |   137,124.29 ns |   154,593.16 ns |   3,176.39 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 5.0 |   223,369.36 ns |   3,472.726 ns |   222,382.57 ns |   217,812.48 ns |   231,166.06 ns |   5,057.70 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|   .NET Framework 4.8 |   228,832.75 ns |   3,069.346 ns |   228,119.17 ns |   224,748.10 ns |   235,125.27 ns |   5,183.40 |               List:Select |   5000 |              Select:005000 |  90.8203 |
| .NET Framework 4.7.2 |   237,366.60 ns |  12,971.284 ns |   232,031.51 ns |   221,789.33 ns |   272,938.89 ns |   5,262.36 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|             .NET 6.0 |   239,845.14 ns |  12,354.289 ns |   236,381.01 ns |   223,795.07 ns |   266,251.71 ns |   5,306.81 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        44.72 ns |       2.266 ns |        44.30 ns |        41.64 ns |        51.08 ns |       1.00 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 5.0 |        47.50 ns |       2.367 ns |        47.32 ns |        42.76 ns |        52.41 ns |       1.07 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
| .NET Framework 4.7.2 |        92.82 ns |       1.517 ns |        92.65 ns |        89.98 ns |        96.92 ns |       2.07 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|   .NET Framework 4.8 |        98.03 ns |       4.012 ns |        97.09 ns |        93.53 ns |       108.81 ns |       2.20 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 6.0 | 2,059,672.86 ns | 102,441.751 ns | 2,065,206.64 ns | 1,895,520.31 ns | 2,324,849.22 ns |  46,128.54 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 2,112,862.24 ns |  20,270.128 ns | 2,113,841.60 ns | 2,083,652.93 ns | 2,147,366.60 ns |  47,449.15 |               Linq:Select | 100000 |              Select:100000 |        - |
| .NET Framework 4.7.2 | 2,647,256.05 ns |  24,862.695 ns | 2,650,515.62 ns | 2,585,966.02 ns | 2,677,270.31 ns |  59,132.76 |               Linq:Select | 100000 |              Select:100000 |        - |
|   .NET Framework 4.8 | 2,784,168.39 ns | 132,282.794 ns | 2,735,687.50 ns | 2,596,289.06 ns | 3,043,782.81 ns |  62,491.81 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 3,339,040.47 ns | 147,897.975 ns | 3,288,153.91 ns | 3,141,147.66 ns | 3,772,215.23 ns |  74,497.88 |               List:Select | 100000 |              Select:100000 | 507.8125 |
|   .NET Framework 4.8 | 3,425,324.65 ns |  72,775.892 ns | 3,435,200.78 ns | 3,280,075.39 ns | 3,537,140.62 ns |  77,028.53 |               List:Select | 100000 |              Select:100000 | 464.8438 |
| .NET Framework 4.7.2 | 3,442,030.94 ns |  74,882.206 ns | 3,431,967.19 ns | 3,340,219.14 ns | 3,602,937.50 ns |  77,412.82 |               List:Select | 100000 |              Select:100000 | 464.8438 |
|             .NET 6.0 | 4,375,834.16 ns | 280,496.200 ns | 4,363,675.59 ns | 3,800,667.58 ns | 5,067,292.19 ns |  97,703.99 |               List:Select | 100000 |              Select:100000 | 500.0000 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        48.24 ns |       2.313 ns |        48.02 ns |        44.98 ns |        54.37 ns |       0.95 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 6.0 |        49.96 ns |       2.828 ns |        49.68 ns |        45.49 ns |        56.68 ns |       1.00 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 6.0 |        85.18 ns |       4.795 ns |        84.54 ns |        78.13 ns |        98.23 ns |       1.71 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
|             .NET 5.0 |        85.48 ns |       3.197 ns |        85.48 ns |        79.61 ns |        93.40 ns |       1.67 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
|             .NET 6.0 |        90.55 ns |       1.965 ns |        90.02 ns |        88.20 ns |        95.06 ns |       1.76 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
|   .NET Framework 4.8 |        95.27 ns |       2.178 ns |        94.78 ns |        92.37 ns |        98.66 ns |       1.86 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        97.88 ns |       2.831 ns |        97.16 ns |        93.00 ns |       103.85 ns |       1.90 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |       110.84 ns |       5.615 ns |       109.86 ns |       103.06 ns |       126.20 ns |       2.21 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
|   .NET Framework 4.8 |       165.25 ns |       7.058 ns |       165.28 ns |       152.98 ns |       182.38 ns |       3.27 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
| .NET Framework 4.7.2 |       166.47 ns |       6.676 ns |       167.18 ns |       154.75 ns |       183.15 ns |       3.26 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
|   .NET Framework 4.8 |       250.10 ns |       4.651 ns |       248.64 ns |       243.51 ns |       259.78 ns |       4.87 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
| .NET Framework 4.7.2 |       253.14 ns |       2.175 ns |       252.68 ns |       249.08 ns |       257.13 ns |       4.94 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        46.22 ns |       1.336 ns |        46.39 ns |        44.20 ns |        48.31 ns |       0.92 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 6.0 |        50.24 ns |       1.279 ns |        50.12 ns |        48.45 ns |        52.32 ns |       1.00 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        95.58 ns |       2.416 ns |        94.77 ns |        93.18 ns |       101.35 ns |       1.91 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        99.30 ns |       5.096 ns |        97.86 ns |        92.16 ns |       112.02 ns |       1.99 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 6.0 |     1,214.07 ns |      32.525 ns |     1,205.69 ns |     1,160.10 ns |     1,269.29 ns |      24.22 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,236.28 ns |      14.629 ns |     1,233.62 ns |     1,219.60 ns |     1,273.52 ns |      24.62 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,588.57 ns |      73.910 ns |     1,579.93 ns |     1,484.05 ns |     1,772.39 ns |      31.18 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
|             .NET 6.0 |     1,669.27 ns |      91.934 ns |     1,661.80 ns |     1,502.54 ns |     1,872.17 ns |      34.29 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,785.31 ns |      53.229 ns |     1,774.37 ns |     1,706.66 ns |     1,897.42 ns |      35.70 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,813.40 ns |      93.593 ns |     1,799.01 ns |     1,681.29 ns |     2,077.13 ns |      37.51 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
|   .NET Framework 4.8 |     2,713.45 ns |      78.731 ns |     2,726.85 ns |     2,590.56 ns |     2,889.48 ns |      53.93 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
| .NET Framework 4.7.2 |     2,838.56 ns |     139.973 ns |     2,819.56 ns |     2,624.73 ns |     3,194.70 ns |      58.68 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        49.92 ns |       2.784 ns |        49.69 ns |        46.76 ns |        57.83 ns |       1.00 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 5.0 |        52.88 ns |       1.897 ns |        52.20 ns |        50.45 ns |        59.01 ns |       1.05 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        94.68 ns |       2.231 ns |        93.84 ns |        92.37 ns |        99.08 ns |       1.82 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        95.01 ns |       1.448 ns |        94.66 ns |        92.85 ns |        97.90 ns |       1.76 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 5.0 |    22,329.14 ns |     594.792 ns |    22,557.28 ns |    21,071.93 ns |    23,418.26 ns |     436.28 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 6.0 |    22,705.23 ns |     889.751 ns |    22,871.07 ns |    21,591.01 ns |    25,056.33 ns |     454.55 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 6.0 |    27,197.28 ns |   1,279.004 ns |    26,785.19 ns |    25,508.83 ns |    31,039.58 ns |     547.87 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|             .NET 5.0 |    27,471.58 ns |   1,264.045 ns |    27,199.46 ns |    25,725.73 ns |    30,378.44 ns |     552.06 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|   .NET Framework 4.8 |    29,211.46 ns |   1,052.306 ns |    29,383.54 ns |    27,592.07 ns |    31,348.77 ns |     581.87 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
| .NET Framework 4.7.2 |    30,680.73 ns |   1,757.840 ns |    30,801.18 ns |    27,919.31 ns |    35,595.02 ns |     614.54 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|   .NET Framework 4.8 |    50,813.51 ns |   1,831.704 ns |    50,682.48 ns |    48,067.33 ns |    54,976.89 ns |   1,013.94 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
| .NET Framework 4.7.2 |    51,717.77 ns |   2,721.422 ns |    51,406.38 ns |    47,611.88 ns |    59,626.04 ns |   1,038.53 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        45.37 ns |       2.038 ns |        44.78 ns |        42.53 ns |        50.72 ns |       1.00 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 5.0 |        50.32 ns |       2.513 ns |        49.98 ns |        46.44 ns |        56.79 ns |       1.11 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        95.09 ns |       1.575 ns |        95.00 ns |        92.67 ns |        99.17 ns |       2.09 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        97.19 ns |       2.281 ns |        96.14 ns |        94.90 ns |       101.98 ns |       2.13 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 5.0 |   441,254.53 ns |  13,013.396 ns |   443,171.68 ns |   417,758.01 ns |   473,558.25 ns |   9,664.65 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 6.0 |   447,010.37 ns |  27,540.310 ns |   444,963.72 ns |   409,396.68 ns |   524,463.62 ns |   9,767.51 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 5.0 |   630,462.81 ns |  19,755.722 ns |   627,985.94 ns |   596,571.68 ns |   689,601.17 ns |  13,785.17 |           List:SelectTake | 100000 |          SelectTake:100000 | 185.5469 |
|   .NET Framework 4.8 |   662,684.21 ns |  10,387.347 ns |   662,845.12 ns |   646,312.21 ns |   684,059.08 ns |  14,640.34 |           List:SelectTake | 100000 |          SelectTake:100000 | 166.0156 |
| .NET Framework 4.7.2 |   695,319.15 ns |  10,192.242 ns |   696,404.25 ns |   680,015.92 ns |   712,350.68 ns |  15,383.26 |           List:SelectTake | 100000 |          SelectTake:100000 | 163.0859 |
|             .NET 6.0 |   807,178.27 ns |  77,435.061 ns |   802,109.18 ns |   658,755.08 ns | 1,019,271.39 ns |  17,460.41 |           List:SelectTake | 100000 |          SelectTake:100000 | 175.7813 |
|   .NET Framework 4.8 |   936,324.90 ns |  21,762.153 ns |   928,383.20 ns |   916,729.30 ns | 1,002,724.12 ns |  20,543.69 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
| .NET Framework 4.7.2 |   974,301.08 ns |  33,571.567 ns |   966,476.07 ns |   933,550.88 ns | 1,055,011.04 ns |  21,297.79 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        39.88 ns |       2.012 ns |        39.01 ns |        37.80 ns |        45.03 ns |       0.98 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |        41.00 ns |       2.329 ns |        41.01 ns |        37.15 ns |        46.37 ns |       1.00 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|   .NET Framework 4.8 |        68.15 ns |       0.454 ns |        68.24 ns |        67.55 ns |        68.86 ns |       1.61 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        72.20 ns |       3.683 ns |        71.64 ns |        66.18 ns |        82.37 ns |       1.77 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        78.37 ns |       0.665 ns |        78.35 ns |        77.11 ns |        79.27 ns |       1.86 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 6.0 |        78.79 ns |       1.307 ns |        78.68 ns |        77.29 ns |        81.35 ns |       1.87 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 6.0 |        95.15 ns |       2.370 ns |        94.20 ns |        92.79 ns |       100.12 ns |       2.26 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
|             .NET 5.0 |       100.32 ns |       2.031 ns |        99.44 ns |        98.66 ns |       105.36 ns |       2.38 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
|   .NET Framework 4.8 |       156.92 ns |       3.989 ns |       158.42 ns |       150.67 ns |       163.20 ns |       3.73 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       157.40 ns |       4.342 ns |       157.33 ns |       151.11 ns |       164.65 ns |       3.76 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       454.04 ns |      11.775 ns |       449.78 ns |       439.63 ns |       478.35 ns |      10.80 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0968 |
|   .NET Framework 4.8 |       461.60 ns |      13.773 ns |       453.26 ns |       442.03 ns |       489.82 ns |      11.13 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0963 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        36.91 ns |       0.424 ns |        36.94 ns |        36.15 ns |        37.57 ns |       0.90 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 6.0 |        43.10 ns |       3.214 ns |        42.31 ns |        38.57 ns |        52.90 ns |       1.00 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        68.30 ns |       1.230 ns |        67.88 ns |        66.82 ns |        70.72 ns |       1.67 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        72.33 ns |       3.550 ns |        71.42 ns |        67.30 ns |        80.19 ns |       1.70 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |     1,225.46 ns |      33.303 ns |     1,209.75 ns |     1,186.11 ns |     1,273.97 ns |      29.87 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0534 |
|             .NET 5.0 |     1,480.62 ns |      39.556 ns |     1,459.51 ns |     1,429.73 ns |     1,545.39 ns |      36.10 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|             .NET 6.0 |     1,512.78 ns |      39.809 ns |     1,495.96 ns |     1,466.97 ns |     1,617.88 ns |      36.89 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,762.59 ns |      36.803 ns |     1,766.30 ns |     1,714.98 ns |     1,817.33 ns |      43.15 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,780.67 ns |      29.305 ns |     1,787.56 ns |     1,733.54 ns |     1,820.14 ns |      43.47 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,860.39 ns |      42.808 ns |     1,838.77 ns |     1,811.23 ns |     1,935.72 ns |      45.70 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0820 |
| .NET Framework 4.7.2 |     8,326.21 ns |     188.617 ns |     8,258.62 ns |     8,075.40 ns |     8,660.17 ns |     204.56 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
|   .NET Framework 4.8 |     8,405.92 ns |     193.271 ns |     8,474.98 ns |     8,075.18 ns |     8,619.55 ns |     206.52 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        38.26 ns |       1.073 ns |        37.98 ns |        36.88 ns |        41.42 ns |       0.90 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |        42.13 ns |       1.546 ns |        41.45 ns |        40.68 ns |        47.09 ns |       1.00 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        66.44 ns |       1.534 ns |        65.70 ns |        64.87 ns |        69.47 ns |       1.57 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        66.65 ns |       1.490 ns |        67.31 ns |        64.02 ns |        68.89 ns |       1.57 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |    21,636.39 ns |     498.285 ns |    21,445.77 ns |    21,098.20 ns |    22,511.43 ns |     510.05 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0305 |
|             .NET 5.0 |    25,577.19 ns |     554.917 ns |    25,240.10 ns |    24,961.00 ns |    26,479.62 ns |     602.05 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    26,005.77 ns |     494.306 ns |    25,843.09 ns |    25,347.98 ns |    26,885.94 ns |     612.22 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    27,884.92 ns |     614.947 ns |    27,522.69 ns |    27,230.98 ns |    28,807.18 ns |     656.16 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    28,151.03 ns |     111.636 ns |    28,209.57 ns |    27,946.63 ns |    28,255.85 ns |     658.63 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    33,087.74 ns |   1,064.870 ns |    32,643.52 ns |    32,069.43 ns |    37,338.72 ns |     784.81 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |   152,710.97 ns |   1,238.829 ns |   152,480.77 ns |   150,487.67 ns |   155,343.04 ns |   3,594.54 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
|   .NET Framework 4.8 |   154,294.33 ns |   2,445.680 ns |   153,759.91 ns |   151,391.55 ns |   158,490.70 ns |   3,637.95 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        38.55 ns |       1.071 ns |        39.12 ns |        36.54 ns |        39.86 ns |       1.00 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        44.73 ns |       0.987 ns |        44.47 ns |        43.32 ns |        47.07 ns |       1.16 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        65.42 ns |       0.662 ns |        65.40 ns |        64.30 ns |        66.34 ns |       1.69 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        68.04 ns |       2.470 ns |        67.06 ns |        64.79 ns |        74.90 ns |       1.79 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |   415,193.19 ns |   2,696.241 ns |   415,550.59 ns |   410,262.50 ns |   417,931.30 ns |  10,768.37 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|             .NET 6.0 |   652,091.24 ns |  18,532.232 ns |   641,245.02 ns |   625,781.84 ns |   697,365.43 ns |  16,943.38 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|             .NET 5.0 |   664,645.71 ns |  23,774.201 ns |   655,833.40 ns |   627,638.18 ns |   724,417.68 ns |  17,413.99 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 187.5000 |
|   .NET Framework 4.8 |   712,741.81 ns |  18,003.860 ns |   713,969.29 ns |   679,038.87 ns |   750,912.70 ns |  18,501.49 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 168.9453 |
| .NET Framework 4.7.2 |   723,877.67 ns |   8,879.185 ns |   721,106.93 ns |   711,189.84 ns |   740,180.86 ns |  18,749.76 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 168.9453 |
|             .NET 6.0 |   748,811.43 ns |  52,330.443 ns |   739,477.73 ns |   655,349.22 ns |   881,569.43 ns |  19,074.01 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 177.7344 |
|   .NET Framework 4.8 | 3,126,275.91 ns |  27,735.439 ns | 3,128,202.34 ns | 3,081,875.78 ns | 3,172,780.86 ns |  80,961.50 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
| .NET Framework 4.7.2 | 3,156,954.02 ns |  36,244.022 ns | 3,160,245.51 ns | 3,103,407.81 ns | 3,217,605.86 ns |  81,775.45 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        53.67 ns |       2.736 ns |        52.72 ns |        49.66 ns |        59.74 ns |       1.00 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 5.0 |        58.37 ns |       4.357 ns |        57.67 ns |        51.82 ns |        70.76 ns |       1.10 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 6.0 |        62.68 ns |       2.466 ns |        62.17 ns |        59.32 ns |        70.33 ns |       1.16 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        72.71 ns |       4.577 ns |        71.98 ns |        65.44 ns |        84.44 ns |       1.37 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        81.19 ns |       1.135 ns |        80.91 ns |        79.29 ns |        83.69 ns |       1.46 |                 List:Take |      1 |                Take:000001 |   0.0459 |
|             .NET 6.0 |        87.39 ns |       5.821 ns |        86.10 ns |        79.46 ns |       102.58 ns |       1.61 |                 List:Take |      1 |                Take:000001 |   0.0459 |
| .NET Framework 4.7.2 |       154.82 ns |       6.175 ns |       154.79 ns |       144.85 ns |       168.49 ns |       2.86 |                 List:Take |      1 |                Take:000001 |   0.0484 |
|   .NET Framework 4.8 |       161.88 ns |      10.970 ns |       159.39 ns |       145.51 ns |       192.58 ns |       3.02 |                 List:Take |      1 |                Take:000001 |   0.0484 |
| .NET Framework 4.7.2 |       219.77 ns |       8.493 ns |       221.89 ns |       206.12 ns |       237.36 ns |       4.06 |                Array:Take |      1 |                Take:000001 |   0.0305 |
|   .NET Framework 4.8 |       222.16 ns |      12.517 ns |       218.03 ns |       204.40 ns |       251.28 ns |       4.16 |                Array:Take |      1 |                Take:000001 |   0.0305 |
| .NET Framework 4.7.2 |       225.11 ns |       7.788 ns |       225.15 ns |       213.38 ns |       246.65 ns |       4.15 |                 Linq:Take |      1 |                Take:000001 |   0.0393 |
|   .NET Framework 4.8 |       226.40 ns |       6.532 ns |       226.79 ns |       215.87 ns |       240.81 ns |       4.12 |                 Linq:Take |      1 |                Take:000001 |   0.0393 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        52.98 ns |       2.664 ns |        52.13 ns |        49.35 ns |        61.64 ns |       1.00 |                Array:Take |    250 |                Take:000250 |   0.0293 |
|             .NET 5.0 |        56.71 ns |       3.905 ns |        55.68 ns |        51.75 ns |        66.10 ns |       1.10 |                Array:Take |    250 |                Take:000250 |   0.0293 |
| .NET Framework 4.7.2 |       212.90 ns |       6.405 ns |       209.75 ns |       203.93 ns |       228.60 ns |       3.93 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|   .NET Framework 4.8 |       228.69 ns |      16.685 ns |       225.26 ns |       204.09 ns |       271.56 ns |       4.33 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|             .NET 6.0 |       955.67 ns |      57.158 ns |       949.31 ns |       877.64 ns |     1,124.04 ns |      18.32 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 5.0 |     1,011.16 ns |      17.215 ns |     1,007.86 ns |       990.87 ns |     1,043.30 ns |      18.17 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 5.0 |     1,284.08 ns |      31.357 ns |     1,273.89 ns |     1,248.75 ns |     1,358.22 ns |      23.52 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|             .NET 6.0 |     1,356.55 ns |      51.494 ns |     1,357.00 ns |     1,277.86 ns |     1,505.23 ns |      25.57 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,525.79 ns |      81.145 ns |     1,510.40 ns |     1,411.69 ns |     1,728.92 ns |      28.82 |                 List:Take |    250 |                Take:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,577.87 ns |     122.677 ns |     1,553.37 ns |     1,400.37 ns |     1,921.84 ns |      30.30 |                 List:Take |    250 |                Take:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,862.64 ns |      46.793 ns |     1,845.32 ns |     1,807.68 ns |     1,968.73 ns |      33.93 |                 Linq:Take |    250 |                Take:000250 |   0.0458 |
|   .NET Framework 4.8 |     1,953.41 ns |      65.881 ns |     1,953.45 ns |     1,851.96 ns |     2,109.65 ns |      36.41 |                 Linq:Take |    250 |                Take:000250 |   0.0477 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |    17,103.29 ns |     705.508 ns |    16,861.30 ns |    16,090.10 ns |    19,096.59 ns |       0.94 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 6.0 |    18,089.84 ns |   1,044.277 ns |    17,926.56 ns |    16,570.71 ns |    21,330.33 ns |       1.00 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 5.0 |    21,639.35 ns |     420.570 ns |    21,551.59 ns |    20,963.74 ns |    22,436.38 ns |       1.23 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|             .NET 6.0 |    23,639.98 ns |   1,780.644 ns |    22,915.40 ns |    21,456.14 ns |    28,181.32 ns |       1.31 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
| .NET Framework 4.7.2 |    25,242.31 ns |     929.724 ns |    25,001.96 ns |    23,985.57 ns |    27,990.30 ns |       1.39 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|   .NET Framework 4.8 |    25,447.28 ns |     606.366 ns |    25,255.19 ns |    24,555.08 ns |    26,650.50 ns |       1.45 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|   .NET Framework 4.8 |    32,035.45 ns |     938.618 ns |    31,551.17 ns |    30,881.06 ns |    34,649.66 ns |       1.79 |                 Linq:Take |   5000 |                Take:005000 |        - |
| .NET Framework 4.7.2 |    32,696.09 ns |   1,432.669 ns |    32,230.06 ns |    30,932.84 ns |    36,714.65 ns |       1.79 |                 Linq:Take |   5000 |                Take:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        56.81 ns |       4.485 ns |        55.66 ns |        50.92 ns |        68.19 ns |       0.99 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
|             .NET 6.0 |        57.46 ns |       4.210 ns |        56.96 ns |        50.31 ns |        68.87 ns |       1.00 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
|   .NET Framework 4.8 |       206.99 ns |       3.969 ns |       205.58 ns |       201.36 ns |       214.69 ns |       3.40 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
| .NET Framework 4.7.2 |       224.44 ns |      10.226 ns |       222.17 ns |       209.57 ns |       250.83 ns |       3.93 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        55.75 ns |       3.976 ns |        54.64 ns |        50.47 ns |        67.42 ns |       0.98 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
|             .NET 6.0 |        57.36 ns |       3.245 ns |        56.78 ns |        52.02 ns |        66.02 ns |       1.00 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
| .NET Framework 4.7.2 |       220.45 ns |       7.694 ns |       219.89 ns |       209.38 ns |       236.76 ns |       3.77 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
|   .NET Framework 4.8 |       223.94 ns |      10.885 ns |       223.62 ns |       204.20 ns |       248.56 ns |       3.92 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
|             .NET 6.0 |   335,332.71 ns |   7,748.659 ns |   333,235.01 ns |   327,195.75 ns |   359,470.41 ns |   5,696.67 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 5.0 |   351,287.18 ns |  14,823.599 ns |   352,320.09 ns |   332,554.86 ns |   391,214.87 ns |   6,114.24 |                 Linq:Take | 100000 |                Take:100000 |        - |
| .NET Framework 4.7.2 |   612,398.99 ns |  21,558.116 ns |   609,203.61 ns |   578,905.66 ns |   683,747.56 ns |  10,501.06 |                 List:Take | 100000 |                Take:100000 | 137.6953 |
|   .NET Framework 4.8 |   620,413.65 ns |  11,140.802 ns |   622,349.32 ns |   605,775.78 ns |   636,864.16 ns |  10,371.33 |                 List:Take | 100000 |                Take:100000 | 147.4609 |
|             .NET 5.0 |   630,606.67 ns |  38,397.345 ns |   620,702.00 ns |   571,174.12 ns |   744,751.17 ns |  11,032.22 |                 List:Take | 100000 |                Take:100000 | 157.2266 |
| .NET Framework 4.7.2 |   655,072.97 ns |  36,511.113 ns |   647,145.51 ns |   601,426.86 ns |   748,749.61 ns |  11,452.19 |                 Linq:Take | 100000 |                Take:100000 |        - |
|   .NET Framework 4.8 |   675,903.26 ns |  48,909.501 ns |   664,665.14 ns |   613,989.75 ns |   820,441.11 ns |  11,829.81 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 6.0 | 1,401,229.65 ns |  80,283.173 ns | 1,406,851.66 ns | 1,181,453.61 ns | 1,583,541.31 ns |  24,497.75 |                 List:Take | 100000 |                Take:100000 | 172.8516 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.19 ns |       1.877 ns |        43.55 ns |        41.55 ns |        48.06 ns |       0.96 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        45.54 ns |       2.380 ns |        44.74 ns |        43.19 ns |        52.78 ns |       1.00 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        63.17 ns |       1.654 ns |        62.82 ns |        60.72 ns |        66.83 ns |       1.38 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 5.0 |        75.14 ns |       6.707 ns |        73.93 ns |        66.30 ns |        93.49 ns |       1.69 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 6.0 |        79.51 ns |       2.811 ns |        78.09 ns |        76.11 ns |        88.65 ns |       1.72 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|             .NET 5.0 |        83.46 ns |       4.948 ns |        81.92 ns |        76.87 ns |        96.93 ns |       1.85 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|   .NET Framework 4.8 |        99.02 ns |       5.140 ns |        99.03 ns |        91.53 ns |       112.51 ns |       2.18 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        99.21 ns |       5.677 ns |        97.67 ns |        91.75 ns |       114.33 ns |       2.20 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|   .NET Framework 4.8 |       151.91 ns |       3.460 ns |       152.79 ns |       146.97 ns |       158.50 ns |       3.28 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       158.37 ns |       8.213 ns |       157.11 ns |       144.26 ns |       180.45 ns |       3.49 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       326.49 ns |      10.776 ns |       324.84 ns |       312.50 ns |       352.47 ns |       7.08 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|   .NET Framework 4.8 |       327.92 ns |       8.156 ns |       329.78 ns |       313.19 ns |       341.00 ns |       7.12 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        48.43 ns |       1.332 ns |        48.39 ns |        46.32 ns |        51.18 ns |       0.97 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 6.0 |        50.57 ns |       2.751 ns |        49.90 ns |        46.53 ns |        57.41 ns |       1.00 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        96.55 ns |       2.968 ns |        96.77 ns |        92.34 ns |       102.09 ns |       1.94 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        98.28 ns |       6.654 ns |        96.59 ns |        90.81 ns |       118.57 ns |       1.96 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 5.0 |     1,008.41 ns |      45.976 ns |     1,001.37 ns |       936.81 ns |     1,135.73 ns |      19.87 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0362 |
|             .NET 5.0 |     1,333.82 ns |      61.629 ns |     1,324.08 ns |     1,252.27 ns |     1,486.45 ns |      26.24 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|             .NET 6.0 |     1,410.49 ns |      87.256 ns |     1,404.03 ns |     1,289.19 ns |     1,642.31 ns |      27.83 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,559.67 ns |      78.693 ns |     1,548.88 ns |     1,419.61 ns |     1,759.81 ns |      30.87 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,563.39 ns |      72.527 ns |     1,558.37 ns |     1,454.35 ns |     1,736.94 ns |      30.77 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,629.57 ns |      80.015 ns |     1,621.84 ns |     1,519.25 ns |     1,835.39 ns |      32.10 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0534 |
|   .NET Framework 4.8 |     2,317.48 ns |      81.726 ns |     2,310.06 ns |     2,181.68 ns |     2,456.47 ns |      45.82 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     2,429.12 ns |     212.680 ns |     2,365.40 ns |     2,165.85 ns |     3,007.92 ns |      49.00 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        46.73 ns |       2.668 ns |        46.28 ns |        42.54 ns |        53.56 ns |       1.00 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 5.0 |        50.54 ns |       1.473 ns |        50.61 ns |        47.70 ns |        54.00 ns |       1.08 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        92.52 ns |       2.348 ns |        91.53 ns |        89.63 ns |        96.78 ns |       1.96 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        98.82 ns |       6.199 ns |        98.58 ns |        90.27 ns |       114.97 ns |       2.12 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 5.0 |    17,816.68 ns |     998.447 ns |    17,825.84 ns |    16,198.81 ns |    20,150.15 ns |     382.52 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
|             .NET 5.0 |    21,972.03 ns |   1,349.238 ns |    21,861.56 ns |    20,040.28 ns |    26,602.91 ns |     472.54 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 6.0 |    22,264.21 ns |     973.279 ns |    22,115.30 ns |    20,742.79 ns |    25,045.05 ns |     482.57 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    23,392.50 ns |     430.997 ns |    23,266.77 ns |    22,896.96 ns |    24,234.94 ns |     489.64 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    25,321.41 ns |   1,422.105 ns |    25,282.93 ns |    22,730.69 ns |    28,711.71 ns |     543.99 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 6.0 |    30,066.50 ns |   1,831.295 ns |    29,789.38 ns |    27,298.11 ns |    35,535.35 ns |     642.61 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
|   .NET Framework 4.8 |    37,582.49 ns |   1,540.968 ns |    37,269.42 ns |    35,462.91 ns |    41,447.75 ns |     812.20 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    37,878.35 ns |   1,284.824 ns |    37,544.26 ns |    36,245.07 ns |    41,009.50 ns |     810.85 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.35 ns |       0.561 ns |        41.33 ns |        40.10 ns |        42.15 ns |       1.00 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 5.0 |        46.86 ns |       2.540 ns |        46.72 ns |        42.64 ns |        51.97 ns |       1.14 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        93.78 ns |       1.521 ns |        93.14 ns |        92.16 ns |        96.57 ns |       2.27 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        99.44 ns |       5.528 ns |        98.43 ns |        91.01 ns |       112.21 ns |       2.34 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 5.0 |   318,693.17 ns |   4,883.391 ns |   317,942.46 ns |   311,787.77 ns |   326,721.26 ns |   7,718.32 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
| .NET Framework 4.7.2 |   564,568.26 ns |  11,247.566 ns |   563,990.92 ns |   546,297.75 ns |   587,910.16 ns |  13,670.11 |             List:TakeLast | 100000 |            TakeLast:100000 | 142.5781 |
|             .NET 6.0 |   597,839.58 ns |  20,712.178 ns |   602,389.06 ns |   548,204.88 ns |   645,664.45 ns |  14,372.02 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
|             .NET 5.0 |   615,936.54 ns |  42,426.457 ns |   611,275.59 ns |   553,250.59 ns |   739,164.45 ns |  15,057.78 |             List:TakeLast | 100000 |            TakeLast:100000 | 159.1797 |
|   .NET Framework 4.8 |   626,035.45 ns |  49,885.137 ns |   608,467.38 ns |   554,609.47 ns |   766,427.83 ns |  14,508.87 |             List:TakeLast | 100000 |            TakeLast:100000 | 139.6484 |
| .NET Framework 4.7.2 |   864,828.34 ns |  21,392.245 ns |   861,238.67 ns |   817,128.52 ns |   924,284.96 ns |  20,912.12 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 177.7344 |
|   .NET Framework 4.8 |   890,073.65 ns |  25,934.958 ns |   886,838.48 ns |   850,530.96 ns |   971,630.37 ns |  21,857.78 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 179.6875 |
|             .NET 6.0 | 1,066,936.74 ns |  74,569.290 ns | 1,072,408.11 ns |   905,538.87 ns | 1,269,974.90 ns |  25,604.67 |             List:TakeLast | 100000 |            TakeLast:100000 | 145.5078 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        47.67 ns |       2.474 ns |        47.05 ns |        44.34 ns |        53.19 ns |       1.00 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 5.0 |        47.89 ns |       2.398 ns |        47.50 ns |        44.42 ns |        54.39 ns |       1.01 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|   .NET Framework 4.8 |        93.93 ns |       2.353 ns |        93.41 ns |        90.52 ns |        97.94 ns |       2.00 |               Array:Where |      1 |               Where:000001 |   0.0153 |
| .NET Framework 4.7.2 |        98.56 ns |       4.628 ns |        98.41 ns |        91.32 ns |       110.12 ns |       2.07 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 6.0 |       120.75 ns |       4.760 ns |       120.72 ns |       111.19 ns |       131.47 ns |       2.52 |                List:Where |      1 |               Where:000001 |   0.0535 |
|             .NET 5.0 |       122.10 ns |       7.824 ns |       120.51 ns |       111.05 ns |       141.31 ns |       2.59 |                List:Where |      1 |               Where:000001 |   0.0534 |
|             .NET 6.0 |       131.54 ns |       5.143 ns |       130.32 ns |       124.78 ns |       145.18 ns |       2.75 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
|             .NET 5.0 |       160.70 ns |      11.499 ns |       157.17 ns |       145.32 ns |       192.89 ns |       3.34 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
|   .NET Framework 4.8 |       176.66 ns |       9.166 ns |       173.89 ns |       163.41 ns |       202.76 ns |       3.72 |                List:Where |      1 |               Where:000001 |   0.0560 |
| .NET Framework 4.7.2 |       183.85 ns |      12.162 ns |       183.08 ns |       163.30 ns |       219.75 ns |       3.86 |                List:Where |      1 |               Where:000001 |   0.0560 |
| .NET Framework 4.7.2 |       278.60 ns |      14.041 ns |       276.65 ns |       259.46 ns |       318.10 ns |       5.86 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
|   .NET Framework 4.8 |       289.12 ns |      18.457 ns |       288.27 ns |       257.53 ns |       334.85 ns |       6.03 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        48.25 ns |       1.676 ns |        47.68 ns |        45.95 ns |        53.10 ns |       1.00 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 5.0 |        52.71 ns |       2.157 ns |        52.82 ns |        49.27 ns |        57.88 ns |       1.09 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|   .NET Framework 4.8 |        96.46 ns |       3.753 ns |        95.83 ns |        91.77 ns |       106.45 ns |       2.00 |               Array:Where |    250 |               Where:000250 |   0.0153 |
| .NET Framework 4.7.2 |        99.04 ns |       2.220 ns |        99.60 ns |        95.11 ns |       103.50 ns |       2.05 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 6.0 |     7,096.31 ns |     111.905 ns |     7,073.61 ns |     6,972.75 ns |     7,343.54 ns |     145.81 |                List:Where |    250 |               Where:000250 |   0.9995 |
|             .NET 5.0 |     8,069.91 ns |     390.841 ns |     8,017.21 ns |     7,550.84 ns |     8,948.80 ns |     167.00 |                List:Where |    250 |               Where:000250 |   0.9995 |
|             .NET 6.0 |     9,618.84 ns |     314.783 ns |     9,524.61 ns |     9,246.97 ns |    10,590.15 ns |     200.11 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|             .NET 5.0 |    10,422.99 ns |     559.605 ns |    10,459.98 ns |     9,576.25 ns |    11,840.27 ns |     225.19 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
| .NET Framework 4.7.2 |    10,566.39 ns |     364.196 ns |    10,503.16 ns |    10,016.48 ns |    11,385.48 ns |     219.42 |                List:Where |    250 |               Where:000250 |   1.0071 |
|   .NET Framework 4.8 |    10,732.07 ns |     651.752 ns |    10,596.08 ns |     9,767.33 ns |    12,536.22 ns |     219.60 |                List:Where |    250 |               Where:000250 |   1.0071 |
|   .NET Framework 4.8 |    13,255.52 ns |     561.439 ns |    13,129.10 ns |    12,437.55 ns |    14,463.68 ns |     276.94 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
| .NET Framework 4.7.2 |    13,579.88 ns |     627.776 ns |    13,535.44 ns |    12,655.80 ns |    15,133.58 ns |     280.25 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.45 ns |       1.304 ns |        43.48 ns |        41.25 ns |        45.36 ns |       1.00 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 5.0 |        46.47 ns |       3.437 ns |        45.96 ns |        42.12 ns |        56.37 ns |       1.13 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.81 ns |       1.809 ns |        93.35 ns |        91.88 ns |        98.24 ns |       2.17 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.89 ns |       1.942 ns |        93.40 ns |        91.80 ns |        98.04 ns |       2.17 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 6.0 |   154,979.68 ns |   1,244.464 ns |   154,560.33 ns |   153,482.18 ns |   157,523.75 ns |   3,596.06 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 5.0 |   168,191.56 ns |   3,716.593 ns |   168,615.80 ns |   163,416.92 ns |   174,785.42 ns |   3,869.47 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 6.0 |   196,962.59 ns |   6,909.036 ns |   196,269.07 ns |   184,225.12 ns |   211,290.92 ns |   4,563.41 |                Linq:Where |   5000 |               Where:005000 |        - |
|             .NET 5.0 |   197,383.90 ns |   5,589.393 ns |   195,002.28 ns |   190,264.23 ns |   208,880.81 ns |   4,551.13 |                Linq:Where |   5000 |               Where:005000 |        - |
|   .NET Framework 4.8 |   214,644.92 ns |   1,593.536 ns |   214,242.43 ns |   213,039.38 ns |   218,873.34 ns |   4,980.55 |                List:Where |   5000 |               Where:005000 |  36.8652 |
| .NET Framework 4.7.2 |   224,657.78 ns |  11,904.299 ns |   220,859.67 ns |   209,741.70 ns |   255,739.28 ns |   5,335.77 |                List:Where |   5000 |               Where:005000 |  36.8652 |
| .NET Framework 4.7.2 |   252,595.48 ns |  10,172.049 ns |   250,210.77 ns |   241,656.40 ns |   281,042.19 ns |   5,891.00 |                Linq:Where |   5000 |               Where:005000 |        - |
|   .NET Framework 4.8 |   259,130.47 ns |  11,557.754 ns |   253,284.77 ns |   246,252.20 ns |   287,218.46 ns |   5,932.92 |                Linq:Where |   5000 |               Where:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.53 ns |       0.905 ns |        43.64 ns |        41.71 ns |        44.95 ns |       1.00 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 |        49.94 ns |       2.007 ns |        49.95 ns |        46.49 ns |        54.89 ns |       1.15 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|   .NET Framework 4.8 |        94.92 ns |       1.491 ns |        94.81 ns |        92.79 ns |        98.42 ns |       2.17 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
| .NET Framework 4.7.2 |        96.47 ns |       4.678 ns |        94.55 ns |        90.90 ns |       110.74 ns |       2.35 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 | 2,884,736.22 ns |  46,610.823 ns | 2,887,366.02 ns | 2,786,060.16 ns | 2,951,828.12 ns |  66,249.22 |                List:Where | 100000 |               Where:100000 | 324.2188 |
|             .NET 6.0 | 2,884,978.20 ns |  14,981.700 ns | 2,881,025.98 ns | 2,870,796.68 ns | 2,923,614.26 ns |  66,183.92 |                List:Where | 100000 |               Where:100000 | 281.2500 |
|             .NET 5.0 | 3,918,978.88 ns | 201,454.678 ns | 3,894,464.06 ns | 3,627,354.69 ns | 4,449,642.19 ns |  90,278.13 |                Linq:Where | 100000 |               Where:100000 |        - |
|   .NET Framework 4.8 | 3,940,357.87 ns |  66,606.676 ns | 3,949,250.39 ns | 3,820,528.12 ns | 4,068,071.88 ns |  90,193.91 |                List:Where | 100000 |               Where:100000 | 234.3750 |
| .NET Framework 4.7.2 | 3,947,472.81 ns |  73,760.316 ns | 3,935,753.12 ns | 3,853,960.94 ns | 4,123,004.69 ns |  90,652.34 |                List:Where | 100000 |               Where:100000 | 234.3750 |
|             .NET 6.0 | 4,041,578.18 ns |  61,354.693 ns | 4,049,489.84 ns | 3,851,669.53 ns | 4,109,259.38 ns |  92,830.59 |                Linq:Where | 100000 |               Where:100000 |        - |
| .NET Framework 4.7.2 | 5,095,054.18 ns | 219,706.222 ns | 5,041,208.59 ns | 4,811,810.16 ns | 5,649,566.41 ns | 118,869.36 |                Linq:Where | 100000 |               Where:100000 |        - |
|   .NET Framework 4.8 | 5,379,664.39 ns | 333,821.131 ns | 5,318,389.84 ns | 4,933,032.81 ns | 6,341,232.03 ns | 131,788.55 |                Linq:Where | 100000 |               Where:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        45.68 ns |       1.084 ns |        45.47 ns |        43.97 ns |        48.13 ns |       1.00 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 5.0 |        53.32 ns |       2.182 ns |        53.64 ns |        50.45 ns |        59.14 ns |       1.18 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|   .NET Framework 4.8 |        92.42 ns |       2.580 ns |        91.27 ns |        89.90 ns |        97.29 ns |       2.03 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
| .NET Framework 4.7.2 |        95.12 ns |       3.181 ns |        94.08 ns |        90.77 ns |       101.06 ns |       2.08 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 5.0 |       152.30 ns |       3.281 ns |       150.83 ns |       148.92 ns |       158.72 ns |       3.33 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 6.0 |       152.38 ns |       4.421 ns |       150.26 ns |       146.78 ns |       159.81 ns |       3.34 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 6.0 |       170.58 ns |       6.629 ns |       167.65 ns |       162.16 ns |       189.14 ns |       3.79 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0751 |
|             .NET 5.0 |       189.96 ns |       6.748 ns |       187.87 ns |       181.35 ns |       209.46 ns |       4.13 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0751 |
|   .NET Framework 4.8 |       229.87 ns |       6.406 ns |       226.09 ns |       220.41 ns |       238.98 ns |       5.03 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0637 |
| .NET Framework 4.7.2 |       232.09 ns |       6.381 ns |       231.17 ns |       221.11 ns |       240.13 ns |       5.09 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0637 |
|   .NET Framework 4.8 |       328.56 ns |      10.729 ns |       324.08 ns |       315.91 ns |       362.26 ns |       7.22 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
| .NET Framework 4.7.2 |       330.02 ns |      10.339 ns |       333.00 ns |       313.50 ns |       349.09 ns |       7.23 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.51 ns |       1.310 ns |        42.90 ns |        41.77 ns |        46.16 ns |       0.93 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 6.0 |        47.58 ns |       2.254 ns |        46.92 ns |        43.76 ns |        53.76 ns |       1.00 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
| .NET Framework 4.7.2 |        92.29 ns |       0.876 ns |        92.30 ns |        90.74 ns |        94.42 ns |       1.96 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|   .NET Framework 4.8 |        92.50 ns |       1.433 ns |        92.09 ns |        90.97 ns |        95.56 ns |       1.97 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 6.0 |     5,580.01 ns |      41.472 ns |     5,583.13 ns |     5,488.50 ns |     5,634.71 ns |     118.68 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 5.0 |     7,003.35 ns |     224.401 ns |     6,890.18 ns |     6,781.78 ns |     7,693.52 ns |     147.91 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 6.0 |     9,865.23 ns |      52.009 ns |     9,879.81 ns |     9,761.49 ns |     9,933.62 ns |     208.70 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
| .NET Framework 4.7.2 |     9,952.87 ns |      99.158 ns |     9,958.35 ns |     9,745.13 ns |    10,131.46 ns |     210.58 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
|             .NET 5.0 |    10,059.06 ns |      71.678 ns |    10,062.62 ns |     9,937.22 ns |    10,156.02 ns |     212.85 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
|   .NET Framework 4.8 |    10,061.23 ns |     273.562 ns |     9,914.14 ns |     9,722.61 ns |    10,528.31 ns |     214.86 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
| .NET Framework 4.7.2 |    12,256.98 ns |     271.234 ns |    12,120.83 ns |    11,913.90 ns |    12,691.11 ns |     261.62 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|   .NET Framework 4.8 |    12,308.07 ns |     303.999 ns |    12,186.24 ns |    11,898.35 ns |    12,735.84 ns |     263.91 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        45.53 ns |       0.730 ns |        45.53 ns |        44.35 ns |        46.98 ns |       1.00 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 5.0 |        52.24 ns |       0.550 ns |        52.18 ns |        51.35 ns |        53.56 ns |       1.15 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.19 ns |       0.747 ns |        93.00 ns |        92.56 ns |        94.74 ns |       2.04 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.77 ns |       2.832 ns |        92.52 ns |        90.97 ns |       101.63 ns |       2.08 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 6.0 |   116,956.49 ns |   2,784.355 ns |   115,501.39 ns |   113,012.81 ns |   121,822.30 ns |   2,561.21 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 5.0 |   130,257.09 ns |   4,864.519 ns |   128,002.34 ns |   125,742.02 ns |   146,182.03 ns |   2,918.67 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
| .NET Framework 4.7.2 |   191,766.42 ns |   3,224.045 ns |   190,977.71 ns |   188,485.79 ns |   199,450.29 ns |   4,212.57 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|   .NET Framework 4.8 |   195,205.86 ns |   2,172.129 ns |   194,874.71 ns |   193,239.23 ns |   201,061.25 ns |   4,284.99 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 6.0 |   238,209.17 ns |   3,654.762 ns |   237,466.55 ns |   233,904.44 ns |   246,827.93 ns |   5,222.90 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|             .NET 5.0 |   238,491.58 ns |   5,815.132 ns |   236,355.32 ns |   231,401.07 ns |   251,670.24 ns |   5,242.43 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.9746 |
| .NET Framework 4.7.2 |   274,214.26 ns |   1,637.512 ns |   274,586.89 ns |   269,421.58 ns |   276,727.78 ns |   6,023.53 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|   .NET Framework 4.8 |   280,040.64 ns |   6,772.222 ns |   277,534.96 ns |   272,409.57 ns |   292,627.54 ns |   6,173.23 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.78 ns |       1.642 ns |        41.77 ns |        39.57 ns |        46.52 ns |       1.00 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 5.0 |        48.04 ns |       1.123 ns |        48.39 ns |        45.77 ns |        49.62 ns |       1.14 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
| .NET Framework 4.7.2 |        93.32 ns |       2.108 ns |        92.62 ns |        91.21 ns |        98.10 ns |       2.21 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|   .NET Framework 4.8 |        93.37 ns |       1.407 ns |        92.88 ns |        91.50 ns |        97.20 ns |       2.21 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 6.0 | 2,396,716.87 ns |  12,783.864 ns | 2,396,140.43 ns | 2,377,321.68 ns | 2,425,044.34 ns |  57,288.38 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 2,748,263.60 ns |  44,127.154 ns | 2,753,040.04 ns | 2,636,048.24 ns | 2,802,913.48 ns |  65,678.13 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|   .NET Framework 4.8 | 3,953,183.66 ns |  35,741.341 ns | 3,958,114.06 ns | 3,893,158.59 ns | 4,002,328.12 ns |  95,290.06 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
| .NET Framework 4.7.2 | 4,017,008.63 ns |  88,442.042 ns | 3,968,519.53 ns | 3,931,305.47 ns | 4,190,472.66 ns |  95,126.04 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 4,847,815.96 ns | 197,118.537 ns | 4,842,394.92 ns | 4,492,562.50 ns | 5,429,278.12 ns | 116,071.65 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 351.5625 |
|   .NET Framework 4.8 | 5,162,069.45 ns |  92,740.841 ns | 5,143,014.45 ns | 5,013,262.89 ns | 5,324,835.55 ns | 121,875.61 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 304.6875 |
|             .NET 6.0 | 5,204,657.23 ns | 302,531.361 ns | 5,166,712.50 ns | 4,671,740.62 ns | 6,047,487.50 ns | 125,585.67 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 335.9375 |
| .NET Framework 4.7.2 | 5,549,808.11 ns | 126,509.504 ns | 5,534,230.47 ns | 5,357,766.41 ns | 5,809,171.09 ns | 131,539.21 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 312.5000 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.30 ns |       1.622 ns |        42.73 ns |        41.15 ns |        46.77 ns |       1.00 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 5.0 |        54.24 ns |       3.596 ns |        53.79 ns |        49.03 ns |        64.83 ns |       1.32 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        96.16 ns |       4.029 ns |        96.51 ns |        90.36 ns |       106.39 ns |       2.23 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        98.22 ns |       3.562 ns |        98.70 ns |        92.04 ns |       105.23 ns |       2.27 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 5.0 |       111.05 ns |       2.475 ns |       110.98 ns |       108.07 ns |       114.93 ns |       2.51 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 6.0 |       112.43 ns |       2.247 ns |       111.96 ns |       108.74 ns |       116.09 ns |       2.53 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 6.0 |       121.65 ns |       3.121 ns |       120.11 ns |       118.90 ns |       130.17 ns |       2.78 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
|             .NET 5.0 |       140.03 ns |       1.223 ns |       139.89 ns |       138.52 ns |       143.05 ns |       3.15 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
| .NET Framework 4.7.2 |       202.79 ns |       3.480 ns |       202.62 ns |       198.21 ns |       207.97 ns |       4.59 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
|   .NET Framework 4.8 |       203.82 ns |       3.664 ns |       202.33 ns |       199.91 ns |       209.94 ns |       4.60 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
|   .NET Framework 4.8 |       299.71 ns |       6.177 ns |       300.83 ns |       290.26 ns |       307.72 ns |       6.78 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
| .NET Framework 4.7.2 |       300.40 ns |       6.639 ns |       303.21 ns |       291.33 ns |       312.06 ns |       6.80 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        50.25 ns |       3.362 ns |        49.82 ns |        44.81 ns |        59.66 ns |       1.00 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 5.0 |        54.39 ns |       3.776 ns |        53.81 ns |        49.66 ns |        64.56 ns |       1.09 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        99.74 ns |       5.479 ns |        98.95 ns |        92.06 ns |       113.86 ns |       2.00 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |       100.89 ns |       7.093 ns |        99.33 ns |        91.59 ns |       120.90 ns |       2.02 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 5.0 |     1,839.99 ns |      35.758 ns |     1,822.54 ns |     1,813.33 ns |     1,920.50 ns |      38.52 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 6.0 |     1,946.65 ns |      53.279 ns |     1,937.63 ns |     1,875.97 ns |     2,048.74 ns |      39.39 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|   .NET Framework 4.8 |     2,127.83 ns |      18.781 ns |     2,124.13 ns |     2,105.27 ns |     2,168.28 ns |      44.59 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
| .NET Framework 4.7.2 |     2,169.65 ns |      45.648 ns |     2,155.93 ns |     2,116.56 ns |     2,237.83 ns |      45.47 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 6.0 |     6,092.03 ns |     152.674 ns |     6,000.09 ns |     5,905.08 ns |     6,396.90 ns |     123.86 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
|             .NET 5.0 |     6,390.28 ns |     154.911 ns |     6,304.50 ns |     6,226.49 ns |     6,622.47 ns |     133.32 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
|   .NET Framework 4.8 |    10,108.54 ns |     172.249 ns |    10,036.47 ns |     9,920.18 ns |    10,445.25 ns |     211.62 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
| .NET Framework 4.7.2 |    10,307.14 ns |     222.902 ns |    10,227.97 ns |    10,036.05 ns |    10,627.28 ns |     216.02 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        52.10 ns |       2.299 ns |        52.06 ns |        48.47 ns |        57.83 ns |       1.00 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |        55.03 ns |       2.673 ns |        54.06 ns |        51.52 ns |        62.39 ns |       1.06 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        97.90 ns |       4.873 ns |        97.38 ns |        91.21 ns |       110.07 ns |       1.89 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |       101.57 ns |       4.032 ns |       101.44 ns |        95.36 ns |       111.24 ns |       1.95 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |    34,299.51 ns |   1,095.927 ns |    34,041.33 ns |    32,951.50 ns |    37,326.52 ns |     657.52 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |    35,774.11 ns |     794.694 ns |    35,562.52 ns |    34,849.95 ns |    37,093.55 ns |     697.91 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|   .NET Framework 4.8 |    37,585.02 ns |     303.198 ns |    37,496.82 ns |    37,156.86 ns |    38,235.64 ns |     741.03 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
| .NET Framework 4.7.2 |    37,745.71 ns |     433.225 ns |    37,628.23 ns |    37,243.82 ns |    38,858.35 ns |     744.14 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |   115,818.80 ns |   1,573.795 ns |   115,108.42 ns |   114,161.33 ns |   118,691.82 ns |   2,286.19 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|             .NET 5.0 |   130,977.55 ns |   3,514.988 ns |   129,390.91 ns |   127,678.54 ns |   139,745.29 ns |   2,519.05 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|   .NET Framework 4.8 |   192,108.79 ns |     629.893 ns |   192,142.63 ns |   190,889.92 ns |   193,240.72 ns |   3,787.75 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
| .NET Framework 4.7.2 |   193,813.77 ns |   2,608.908 ns |   193,101.09 ns |   191,133.67 ns |   199,281.08 ns |   3,824.93 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        45.78 ns |       3.398 ns |        45.36 ns |        40.71 ns |        56.66 ns |       1.00 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |        46.80 ns |       2.570 ns |        46.45 ns |        42.65 ns |        53.99 ns |       1.03 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        96.46 ns |       4.078 ns |        95.15 ns |        91.72 ns |       106.30 ns |       2.20 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        97.17 ns |       3.352 ns |        96.16 ns |        92.53 ns |       106.35 ns |       2.18 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |   740,314.36 ns |   8,719.177 ns |   740,138.62 ns |   721,956.40 ns |   755,872.02 ns |  16,538.72 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 146.4844 |
|             .NET 6.0 |   751,974.46 ns |  23,498.918 ns |   749,275.39 ns |   722,343.26 ns |   819,105.66 ns |  16,943.83 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 139.6484 |
| .NET Framework 4.7.2 |   815,441.97 ns |  12,799.727 ns |   815,536.52 ns |   795,327.34 ns |   843,166.89 ns |  18,237.92 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 122.0703 |
|   .NET Framework 4.8 |   854,063.42 ns |  12,694.833 ns |   852,396.68 ns |   824,975.49 ns |   873,795.02 ns |  19,090.57 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 114.2578 |
|             .NET 6.0 | 2,361,688.73 ns |  23,292.172 ns | 2,353,753.12 ns | 2,340,298.44 ns | 2,412,029.30 ns |  52,726.23 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|             .NET 5.0 | 2,471,993.21 ns |  12,216.842 ns | 2,469,926.95 ns | 2,445,976.95 ns | 2,488,246.88 ns |  56,085.64 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
| .NET Framework 4.7.2 | 3,861,656.25 ns |   9,333.749 ns | 3,861,522.66 ns | 3,846,442.19 ns | 3,878,531.25 ns |  87,606.93 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|   .NET Framework 4.8 | 3,879,361.80 ns |  26,131.309 ns | 3,875,846.68 ns | 3,844,673.83 ns | 3,944,101.95 ns |  86,616.13 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        47.81 ns |       2.980 ns |        46.63 ns |        44.28 ns |        55.73 ns |       1.00 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        51.45 ns |       3.621 ns |        50.53 ns |        46.37 ns |        60.83 ns |       1.08 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        87.48 ns |       2.787 ns |        87.68 ns |        83.48 ns |        95.49 ns |       1.85 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        87.90 ns |       2.432 ns |        86.93 ns |        84.91 ns |        93.89 ns |       1.88 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
| .NET Framework 4.7.2 |        97.98 ns |       3.352 ns |        97.24 ns |        93.62 ns |       106.15 ns |       2.05 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|   .NET Framework 4.8 |        98.86 ns |       3.083 ns |        98.36 ns |        95.06 ns |       104.98 ns |       2.10 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |       123.56 ns |       1.455 ns |       123.64 ns |       121.54 ns |       125.98 ns |       2.62 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
|             .NET 5.0 |       140.70 ns |       3.179 ns |       139.37 ns |       137.25 ns |       146.13 ns |       3.01 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
|   .NET Framework 4.8 |       164.26 ns |       3.191 ns |       163.39 ns |       159.66 ns |       168.82 ns |       3.51 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
| .NET Framework 4.7.2 |       164.86 ns |       2.654 ns |       164.14 ns |       161.21 ns |       169.48 ns |       3.50 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       578.62 ns |      12.709 ns |       573.89 ns |       562.72 ns |       599.59 ns |      12.37 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
| .NET Framework 4.7.2 |       598.74 ns |      16.427 ns |       601.85 ns |       573.21 ns |       629.79 ns |      12.83 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        44.33 ns |       0.955 ns |        44.28 ns |        42.99 ns |        46.39 ns |       1.00 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |        49.71 ns |       4.816 ns |        48.14 ns |        43.56 ns |        61.39 ns |       1.23 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        90.15 ns |       0.774 ns |        90.26 ns |        88.67 ns |        91.34 ns |       2.03 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        93.00 ns |       3.102 ns |        91.28 ns |        89.56 ns |       102.18 ns |       2.10 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 6.0 |       981.98 ns |       7.808 ns |       980.95 ns |       968.49 ns |     1,000.15 ns |      22.15 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
|             .NET 5.0 |       997.77 ns |       7.748 ns |       995.52 ns |       984.30 ns |     1,009.02 ns |      22.51 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
| .NET Framework 4.7.2 |     1,270.07 ns |      34.023 ns |     1,252.28 ns |     1,231.12 ns |     1,330.88 ns |      28.74 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
|   .NET Framework 4.8 |     1,278.02 ns |      34.325 ns |     1,266.90 ns |     1,234.05 ns |     1,327.78 ns |      28.87 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     6,007.77 ns |      33.102 ns |     6,007.83 ns |     5,936.80 ns |     6,062.30 ns |     135.54 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1144 |
|             .NET 5.0 |     7,005.22 ns |     271.211 ns |     6,850.77 ns |     6,682.41 ns |     7,756.55 ns |     160.88 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1068 |
| .NET Framework 4.7.2 |    20,457.66 ns |     133.936 ns |    20,453.14 ns |    20,191.03 ns |    20,670.61 ns |     461.51 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|   .NET Framework 4.8 |    20,775.80 ns |     461.537 ns |    20,538.82 ns |    20,226.14 ns |    21,427.37 ns |     468.76 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        45.23 ns |       1.157 ns |        44.77 ns |        43.95 ns |        48.13 ns |       0.94 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |        47.88 ns |       0.911 ns |        47.46 ns |        46.93 ns |        50.07 ns |       1.00 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        89.68 ns |       1.163 ns |        89.60 ns |        87.89 ns |        92.11 ns |       1.87 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        91.08 ns |       2.332 ns |        90.38 ns |        88.28 ns |        95.04 ns |       1.91 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |    16,852.93 ns |     103.056 ns |    16,842.74 ns |    16,725.32 ns |    17,076.78 ns |     350.67 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 5.0 |    17,256.98 ns |     122.172 ns |    17,279.11 ns |    17,052.57 ns |    17,485.37 ns |     359.09 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    21,359.23 ns |     516.991 ns |    21,136.69 ns |    20,705.63 ns |    22,355.34 ns |     446.83 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    21,449.06 ns |     553.126 ns |    21,158.24 ns |    20,844.47 ns |    22,687.42 ns |     449.45 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   115,947.09 ns |     463.060 ns |   115,974.74 ns |   115,241.87 ns |   116,561.77 ns |   2,411.52 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|             .NET 5.0 |   129,384.23 ns |   2,031.017 ns |   128,595.85 ns |   127,046.19 ns |   133,529.35 ns |   2,700.14 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   394,037.90 ns |   3,129.215 ns |   393,540.11 ns |   391,007.13 ns |   402,954.79 ns |   8,195.20 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|   .NET Framework 4.8 |   400,522.38 ns |  10,626.182 ns |   392,820.85 ns |   388,683.20 ns |   413,940.48 ns |   8,380.00 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.27 ns |       1.619 ns |        42.90 ns |        41.40 ns |        47.73 ns |       1.00 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        43.58 ns |       0.917 ns |        43.21 ns |        42.60 ns |        45.42 ns |       1.00 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        90.42 ns |       0.707 ns |        90.36 ns |        89.44 ns |        92.19 ns |       2.07 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        91.20 ns |       2.227 ns |        90.37 ns |        89.46 ns |        96.47 ns |       2.10 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 6.0 |   335,164.06 ns |   6,359.447 ns |   331,524.58 ns |   328,296.09 ns |   347,452.78 ns |   7,710.79 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 5.0 |   340,752.48 ns |   1,405.203 ns |   340,711.21 ns |   338,647.02 ns |   342,539.55 ns |   7,825.35 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   414,899.82 ns |   4,568.554 ns |   412,929.20 ns |   411,326.90 ns |   427,314.99 ns |   9,495.13 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 |   422,757.00 ns |   9,834.670 ns |   416,612.94 ns |   413,144.58 ns |   439,388.96 ns |   9,720.12 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 6.0 | 2,301,823.44 ns |  46,209.862 ns | 2,285,085.94 ns | 2,253,437.50 ns | 2,429,720.70 ns |  52,793.00 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 5.0 | 2,587,490.23 ns |  98,365.249 ns | 2,583,902.15 ns | 2,472,195.90 ns | 2,836,500.59 ns |  59,917.07 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,715,476.17 ns |  80,905.340 ns | 7,712,653.52 ns | 7,618,649.22 ns | 7,907,331.25 ns | 177,195.64 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 | 7,797,150.08 ns | 174,794.753 ns | 7,713,677.34 ns | 7,623,392.19 ns | 8,136,135.16 ns | 178,830.40 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        42.81 ns |       0.263 ns |        42.78 ns |        42.38 ns |        43.26 ns |       1.00 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 5.0 |        46.78 ns |       1.339 ns |        46.38 ns |        45.13 ns |        50.43 ns |       1.09 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        90.56 ns |       2.326 ns |        89.42 ns |        87.76 ns |        94.27 ns |       2.12 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        91.46 ns |       2.360 ns |        91.36 ns |        88.52 ns |        96.38 ns |       2.14 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 6.0 |        94.31 ns |       2.153 ns |        93.78 ns |        91.72 ns |        99.41 ns |       2.21 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0573 |
|             .NET 5.0 |        97.29 ns |       2.555 ns |        97.95 ns |        93.13 ns |       103.61 ns |       2.26 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 6.0 |        99.36 ns |       2.121 ns |        99.27 ns |        96.08 ns |       104.43 ns |       2.32 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 5.0 |       103.37 ns |       0.577 ns |       103.22 ns |       102.82 ns |       104.62 ns |       2.41 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0573 |
| .NET Framework 4.7.2 |       164.55 ns |       2.920 ns |       163.71 ns |       160.79 ns |       168.85 ns |       3.85 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
|   .NET Framework 4.8 |       165.31 ns |       1.873 ns |       165.21 ns |       161.78 ns |       168.13 ns |       3.85 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
|   .NET Framework 4.8 |       256.14 ns |       6.250 ns |       258.30 ns |       245.10 ns |       265.20 ns |       5.99 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
| .NET Framework 4.7.2 |       257.73 ns |       4.147 ns |       259.32 ns |       251.05 ns |       262.92 ns |       6.02 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        42.53 ns |       0.208 ns |        42.52 ns |        42.07 ns |        42.88 ns |       1.00 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 5.0 |        50.06 ns |       1.413 ns |        49.21 ns |        48.47 ns |        53.15 ns |       1.18 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        89.98 ns |       0.492 ns |        89.95 ns |        89.20 ns |        90.99 ns |       2.12 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        91.21 ns |       2.668 ns |        89.93 ns |        88.12 ns |        98.06 ns |       2.16 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 6.0 |     1,019.68 ns |      27.021 ns |     1,004.89 ns |       988.64 ns |     1,068.62 ns |      24.36 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
|             .NET 5.0 |     1,053.74 ns |      28.168 ns |     1,046.66 ns |     1,014.66 ns |     1,101.78 ns |      24.87 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
|   .NET Framework 4.8 |     1,280.06 ns |      15.158 ns |     1,279.03 ns |     1,255.02 ns |     1,309.97 ns |      30.12 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
| .NET Framework 4.7.2 |     1,311.27 ns |      25.925 ns |     1,299.63 ns |     1,284.89 ns |     1,362.73 ns |      30.93 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
|             .NET 6.0 |     6,137.49 ns |     135.080 ns |     6,092.86 ns |     5,937.71 ns |     6,374.25 ns |     143.98 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
|             .NET 5.0 |     6,874.17 ns |     158.331 ns |     6,801.55 ns |     6,624.90 ns |     7,219.30 ns |     161.90 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
|   .NET Framework 4.8 |     9,920.92 ns |     180.256 ns |     9,855.72 ns |     9,756.14 ns |    10,279.46 ns |     233.44 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
| .NET Framework 4.7.2 |     9,947.30 ns |     102.606 ns |     9,917.35 ns |     9,815.94 ns |    10,205.59 ns |     233.88 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.58 ns |       0.804 ns |        44.36 ns |        43.72 ns |        46.21 ns |       0.96 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 6.0 |        46.27 ns |       1.048 ns |        46.33 ns |        44.80 ns |        48.10 ns |       1.00 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        88.71 ns |       0.841 ns |        88.59 ns |        87.62 ns |        90.69 ns |       1.93 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        90.08 ns |       2.046 ns |        89.37 ns |        88.16 ns |        95.73 ns |       1.95 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 5.0 |    18,521.83 ns |     502.483 ns |    18,456.34 ns |    17,910.01 ns |    19,761.20 ns |     400.65 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |    18,738.25 ns |     903.726 ns |    18,265.00 ns |    17,852.04 ns |    20,854.46 ns |     409.15 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|   .NET Framework 4.8 |    21,772.48 ns |     220.557 ns |    21,680.64 ns |    21,547.59 ns |    22,323.40 ns |     472.62 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
| .NET Framework 4.7.2 |    21,907.86 ns |     430.336 ns |    21,774.31 ns |    21,479.49 ns |    22,701.77 ns |     475.11 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |   115,087.36 ns |   1,409.169 ns |   114,937.43 ns |   112,841.26 ns |   117,802.34 ns |   2,494.34 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|             .NET 5.0 |   130,656.97 ns |   2,838.505 ns |   129,248.68 ns |   127,546.51 ns |   135,631.08 ns |   2,831.20 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
| .NET Framework 4.7.2 |   192,164.63 ns |   1,329.465 ns |   192,212.35 ns |   190,369.90 ns |   194,906.71 ns |   4,171.03 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|   .NET Framework 4.8 |   195,166.34 ns |   2,563.852 ns |   195,675.54 ns |   191,524.49 ns |   199,631.91 ns |   4,236.10 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.28 ns |       1.117 ns |        40.94 ns |        40.10 ns |        43.37 ns |       1.00 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 5.0 |        43.81 ns |       1.283 ns |        43.11 ns |        42.36 ns |        47.07 ns |       1.06 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        88.92 ns |       0.363 ns |        88.92 ns |        88.21 ns |        89.44 ns |       2.11 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        89.61 ns |       0.708 ns |        89.53 ns |        88.62 ns |        91.50 ns |       2.13 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 6.0 |   397,870.83 ns |   3,280.359 ns |   398,351.76 ns |   391,565.72 ns |   403,987.99 ns |   9,495.62 |            List:WhereTake | 100000 |           WhereTake:100000 |  78.6133 |
|             .NET 5.0 |   398,748.98 ns |   6,957.610 ns |   400,346.24 ns |   386,560.55 ns |   409,681.05 ns |   9,516.99 |            List:WhereTake | 100000 |           WhereTake:100000 |  83.0078 |
|   .NET Framework 4.8 |   453,913.86 ns |   3,420.252 ns |   453,067.53 ns |   448,855.86 ns |   460,817.87 ns |  10,816.99 |            List:WhereTake | 100000 |           WhereTake:100000 |  68.8477 |
| .NET Framework 4.7.2 |   461,840.48 ns |   8,055.083 ns |   459,873.19 ns |   451,724.02 ns |   474,715.72 ns |  11,026.46 |            List:WhereTake | 100000 |           WhereTake:100000 |  67.3828 |
|             .NET 6.0 | 2,356,817.94 ns |  31,455.995 ns | 2,359,255.47 ns | 2,306,700.78 ns | 2,398,399.22 ns |  56,260.57 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|             .NET 5.0 | 2,577,728.75 ns |  47,579.337 ns | 2,555,392.97 ns | 2,523,175.39 ns | 2,645,889.45 ns |  61,533.25 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
| .NET Framework 4.7.2 | 3,743,039.31 ns |  45,745.037 ns | 3,721,571.68 ns | 3,703,428.52 ns | 3,852,527.34 ns |  89,190.59 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|   .NET Framework 4.8 | 3,890,972.16 ns |  63,405.742 ns | 3,905,261.33 ns | 3,798,125.39 ns | 3,985,474.61 ns |  92,882.85 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        43.04 ns |       0.905 ns |        42.88 ns |        41.72 ns |        44.38 ns |       1.00 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        49.95 ns |       0.709 ns |        49.98 ns |        48.68 ns |        50.89 ns |       1.17 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        86.85 ns |       1.001 ns |        86.85 ns |        85.39 ns |        88.87 ns |       2.03 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        89.38 ns |       1.372 ns |        89.24 ns |        87.55 ns |        91.37 ns |       2.08 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|   .NET Framework 4.8 |        90.64 ns |       1.947 ns |        89.54 ns |        88.41 ns |        94.37 ns |       2.11 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        92.18 ns |       2.238 ns |        91.43 ns |        89.16 ns |        95.06 ns |       2.16 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 6.0 |        94.04 ns |       1.586 ns |        93.88 ns |        91.93 ns |        96.35 ns |       2.18 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
|             .NET 5.0 |       106.48 ns |       3.512 ns |       104.45 ns |       102.94 ns |       117.28 ns |       2.48 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
| .NET Framework 4.7.2 |       162.22 ns |       2.775 ns |       161.50 ns |       158.56 ns |       167.25 ns |       3.77 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       167.83 ns |       2.953 ns |       166.99 ns |       164.58 ns |       173.81 ns |       3.90 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       516.96 ns |       9.447 ns |       513.27 ns |       505.25 ns |       531.80 ns |      12.01 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
| .NET Framework 4.7.2 |       526.53 ns |      11.514 ns |       526.51 ns |       510.29 ns |       550.66 ns |      12.23 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        43.82 ns |       0.464 ns |        43.74 ns |        43.33 ns |        45.07 ns |       0.97 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 6.0 |        45.41 ns |       1.396 ns |        44.80 ns |        43.84 ns |        48.98 ns |       1.00 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        89.91 ns |       2.152 ns |        89.05 ns |        87.03 ns |        92.98 ns |       1.99 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        90.01 ns |       2.096 ns |        90.63 ns |        87.00 ns |        92.79 ns |       1.99 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 6.0 |       966.63 ns |       6.992 ns |       965.20 ns |       954.33 ns |       983.06 ns |      21.48 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|             .NET 5.0 |     1,074.36 ns |      26.095 ns |     1,056.84 ns |     1,047.30 ns |     1,125.64 ns |      23.78 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|   .NET Framework 4.8 |     1,254.19 ns |      33.593 ns |     1,237.62 ns |     1,219.45 ns |     1,354.94 ns |      27.73 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     1,256.41 ns |      30.796 ns |     1,240.51 ns |     1,220.80 ns |     1,327.16 ns |      27.83 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     5,678.09 ns |      56.703 ns |     5,672.83 ns |     5,578.49 ns |     5,771.34 ns |     126.57 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0992 |
|             .NET 5.0 |     6,897.45 ns |     117.497 ns |     6,840.77 ns |     6,811.20 ns |     7,147.08 ns |     152.84 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
| .NET Framework 4.7.2 |    19,463.78 ns |     292.679 ns |    19,391.24 ns |    19,133.99 ns |    20,007.21 ns |     430.44 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|   .NET Framework 4.8 |    19,846.41 ns |     539.752 ns |    19,993.62 ns |    19,008.44 ns |    21,229.04 ns |     438.11 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 6.0 |        41.88 ns |       0.911 ns |        41.91 ns |        40.63 ns |        43.33 ns |       1.00 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        45.81 ns |       1.081 ns |        45.65 ns |        44.45 ns |        47.46 ns |       1.09 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        88.33 ns |       1.005 ns |        88.19 ns |        86.85 ns |        90.59 ns |       2.09 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        90.34 ns |       2.792 ns |        89.49 ns |        86.90 ns |        98.51 ns |       2.16 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 5.0 |    17,236.04 ns |     102.285 ns |    17,245.93 ns |    16,989.66 ns |    17,416.64 ns |     408.61 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 6.0 |    17,395.73 ns |      98.035 ns |    17,361.40 ns |    17,263.33 ns |    17,551.79 ns |     412.40 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    20,764.72 ns |     122.268 ns |    20,725.00 ns |    20,597.08 ns |    20,981.36 ns |     492.28 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    21,026.34 ns |     404.251 ns |    20,836.61 ns |    20,623.58 ns |    21,744.82 ns |     501.22 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   113,320.48 ns |   2,305.713 ns |   114,200.05 ns |   108,677.40 ns |   117,679.57 ns |   2,707.43 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|             .NET 5.0 |   132,543.01 ns |   2,282.802 ns |   132,689.83 ns |   129,265.21 ns |   135,715.16 ns |   3,149.71 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|   .NET Framework 4.8 |   377,035.56 ns |   4,350.283 ns |   376,711.77 ns |   371,443.95 ns |   386,297.61 ns |   8,957.66 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   379,599.96 ns |   6,664.063 ns |   376,938.18 ns |   372,314.75 ns |   390,837.94 ns |   9,031.16 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                 |            |                           |        |                            |          |
|             .NET 5.0 |        44.13 ns |       1.030 ns |        44.05 ns |        42.69 ns |        46.98 ns |       0.98 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 6.0 |        45.08 ns |       0.436 ns |        45.02 ns |        44.52 ns |        46.04 ns |       1.00 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        90.11 ns |       2.048 ns |        89.19 ns |        88.17 ns |        94.41 ns |       2.00 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        90.87 ns |       1.814 ns |        90.07 ns |        89.27 ns |        96.09 ns |       2.02 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 6.0 |   339,376.44 ns |   7,901.736 ns |   339,745.92 ns |   328,966.02 ns |   350,592.04 ns |   7,549.35 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 5.0 |   348,276.21 ns |   7,398.419 ns |   346,323.49 ns |   339,196.68 ns |   358,574.22 ns |   7,769.11 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 |   412,144.18 ns |   1,609.358 ns |   411,829.44 ns |   408,789.45 ns |   415,307.62 ns |   9,144.53 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   420,492.80 ns |   8,669.502 ns |   417,485.57 ns |   409,877.83 ns |   435,771.44 ns |   9,355.31 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 6.0 | 2,247,030.55 ns |  36,443.118 ns | 2,235,905.66 ns | 2,201,819.92 ns | 2,332,679.69 ns |  50,031.55 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 5.0 | 2,538,481.37 ns |  15,445.112 ns | 2,535,057.42 ns | 2,514,987.50 ns | 2,575,073.05 ns |  56,322.98 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,498,738.56 ns |  45,470.659 ns | 7,503,539.45 ns | 7,437,944.53 ns | 7,567,141.41 ns | 166,433.07 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 | 7,704,086.09 ns | 110,649.133 ns | 7,665,421.88 ns | 7,568,489.84 ns | 7,881,039.06 ns | 170,915.11 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
