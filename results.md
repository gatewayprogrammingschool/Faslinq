# Benchmark Run at 10/10/2021 3:04:24 PM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe  --join -Select -Where -Take -TakeLast --platform X64
```

## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-DMOUFV : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  Job-KDVSHK : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-TVRNLA : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT
  Job-OKYWUR : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```

|              Runtime |            Mean |         StdDev |          Median |             Min |              Max |      Ratio |                  Use Case |  Count |               LogicalGroup |    Gen 0 |
|--------------------- |----------------:|---------------:|----------------:|----------------:|-----------------:|-----------:|-------------------------- |------- |--------------------------- |---------:|
|             .NET 5.0 |        49.47 ns |       3.107 ns |        48.95 ns |        44.02 ns |         58.57 ns |       0.99 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 6.0 |        50.36 ns |       5.125 ns |        49.92 ns |        42.57 ns |         63.97 ns |       1.00 |              Array:Select |      1 |              Select:000001 |   0.0153 |
| .NET Framework 4.7.2 |       105.70 ns |       5.153 ns |       104.52 ns |        95.88 ns |        117.49 ns |       2.09 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|   .NET Framework 4.8 |       106.63 ns |       4.857 ns |       105.25 ns |        97.77 ns |        117.44 ns |       2.06 |              Array:Select |      1 |              Select:000001 |   0.0153 |
|             .NET 5.0 |       108.10 ns |       4.672 ns |       106.87 ns |       101.88 ns |        119.16 ns |       2.07 |               List:Select |      1 |              Select:000001 |   0.0648 |
|             .NET 6.0 |       109.53 ns |       6.506 ns |       107.59 ns |        99.87 ns |        126.63 ns |       2.19 |               List:Select |      1 |              Select:000001 |   0.0650 |
| .NET Framework 4.7.2 |       152.64 ns |       2.812 ns |       153.40 ns |       147.56 ns |        157.02 ns |       2.87 |               List:Select |      1 |              Select:000001 |   0.0675 |
|   .NET Framework 4.8 |       159.17 ns |       8.945 ns |       156.79 ns |       148.36 ns |        183.95 ns |       3.18 |               List:Select |      1 |              Select:000001 |   0.0675 |
|             .NET 6.0 |     5,134.01 ns |     178.670 ns |     5,111.78 ns |     4,871.60 ns |      5,544.66 ns |      96.79 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|             .NET 5.0 |     5,172.30 ns |     217.532 ns |     5,133.87 ns |     4,835.78 ns |      5,709.80 ns |      99.13 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|   .NET Framework 4.8 |     7,189.15 ns |     186.521 ns |     7,140.94 ns |     6,890.46 ns |      7,703.09 ns |     135.51 |               Linq:Select |      1 |              Select:000001 |   0.0305 |
| .NET Framework 4.7.2 |     7,220.34 ns |      92.173 ns |     7,219.18 ns |     7,086.32 ns |      7,434.03 ns |     135.58 |               Linq:Select |      1 |              Select:000001 |   0.0381 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        42.44 ns |       2.049 ns |        41.78 ns |        39.00 ns |         47.84 ns |       1.00 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 5.0 |        48.29 ns |       1.198 ns |        48.15 ns |        46.70 ns |         50.81 ns |       1.12 |              Array:Select |    250 |              Select:000250 |   0.0153 |
| .NET Framework 4.7.2 |        96.05 ns |       3.670 ns |        94.85 ns |        91.39 ns |        106.22 ns |       2.26 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|   .NET Framework 4.8 |        96.07 ns |       4.339 ns |        94.47 ns |        90.60 ns |        106.54 ns |       2.27 |              Array:Select |    250 |              Select:000250 |   0.0153 |
|             .NET 5.0 |     5,060.55 ns |     203.713 ns |     5,033.13 ns |     4,716.25 ns |      5,508.12 ns |     119.08 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 6.0 |     5,245.07 ns |     130.701 ns |     5,238.33 ns |     5,049.90 ns |      5,536.17 ns |     120.44 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|             .NET 5.0 |     6,807.25 ns |     215.999 ns |     6,726.86 ns |     6,504.39 ns |      7,379.56 ns |     158.29 |               List:Select |    250 |              Select:000250 |   2.0142 |
|             .NET 6.0 |     6,896.54 ns |     235.067 ns |     6,850.77 ns |     6,589.76 ns |      7,407.20 ns |     161.01 |               List:Select |    250 |              Select:000250 |   2.0142 |
| .NET Framework 4.7.2 |     7,235.25 ns |     146.987 ns |     7,189.59 ns |     7,039.84 ns |      7,589.56 ns |     167.62 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
|   .NET Framework 4.8 |     7,320.28 ns |     322.661 ns |     7,204.71 ns |     6,867.13 ns |      8,119.00 ns |     172.76 |               Linq:Select |    250 |              Select:000250 |   0.0381 |
| .NET Framework 4.7.2 |     7,332.92 ns |     178.690 ns |     7,311.51 ns |     7,034.17 ns |      7,771.21 ns |     168.29 |               List:Select |    250 |              Select:000250 |   2.0142 |
|   .NET Framework 4.8 |     7,574.85 ns |     245.129 ns |     7,538.97 ns |     7,129.40 ns |      8,172.56 ns |     176.01 |               List:Select |    250 |              Select:000250 |   2.0142 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        44.04 ns |       0.820 ns |        44.10 ns |        42.71 ns |         45.46 ns |       0.92 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 6.0 |        48.57 ns |       2.176 ns |        48.25 ns |        45.40 ns |         54.45 ns |       1.00 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|   .NET Framework 4.8 |        94.98 ns |       1.980 ns |        95.06 ns |        91.25 ns |         98.69 ns |       1.97 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
| .NET Framework 4.7.2 |        95.06 ns |       1.860 ns |        94.99 ns |        92.47 ns |         99.20 ns |       1.99 |              Array:Select |   5000 |              Select:005000 |   0.0153 |
|             .NET 6.0 |    98,871.11 ns |   2,994.702 ns |    97,951.99 ns |    95,357.41 ns |    104,476.23 ns |   2,043.57 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 5.0 |   104,477.97 ns |   4,213.110 ns |   103,825.46 ns |    97,926.86 ns |    115,256.13 ns |   2,152.13 |               Linq:Select |   5000 |              Select:005000 |        - |
|   .NET Framework 4.8 |   142,078.71 ns |   3,228.296 ns |   142,322.22 ns |   135,660.74 ns |    146,985.28 ns |   2,927.61 |               Linq:Select |   5000 |              Select:005000 |        - |
| .NET Framework 4.7.2 |   143,625.29 ns |   3,729.302 ns |   143,331.03 ns |   136,632.67 ns |    151,875.46 ns |   2,965.84 |               Linq:Select |   5000 |              Select:005000 |        - |
|             .NET 5.0 |   222,503.20 ns |   8,954.709 ns |   221,321.34 ns |   209,875.76 ns |    245,294.02 ns |   4,582.36 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|   .NET Framework 4.8 |   225,516.91 ns |   7,313.954 ns |   223,833.79 ns |   215,704.83 ns |    240,820.83 ns |   4,664.70 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|             .NET 6.0 |   226,369.66 ns |   7,318.066 ns |   228,151.42 ns |   213,607.15 ns |    240,682.40 ns |   4,683.95 |               List:Select |   5000 |              Select:005000 |  90.8203 |
| .NET Framework 4.7.2 |   227,756.96 ns |   4,398.170 ns |   227,942.49 ns |   219,135.64 ns |    235,532.10 ns |   4,764.34 |               List:Select |   5000 |              Select:005000 |  90.8203 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        46.04 ns |       2.562 ns |        45.81 ns |        41.65 ns |         52.42 ns |       0.97 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 6.0 |        46.88 ns |       1.880 ns |        46.81 ns |        43.52 ns |         50.77 ns |       1.00 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
| .NET Framework 4.7.2 |        96.40 ns |       1.592 ns |        96.14 ns |        94.17 ns |         98.79 ns |       2.08 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|   .NET Framework 4.8 |       100.51 ns |       4.192 ns |        98.96 ns |        94.75 ns |        112.66 ns |       2.15 |              Array:Select | 100000 |              Select:100000 |   0.0153 |
|             .NET 6.0 | 2,025,451.09 ns |  69,119.494 ns | 2,017,933.98 ns | 1,929,501.76 ns |  2,207,528.12 ns |  43,323.98 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 2,133,301.69 ns | 107,268.794 ns | 2,108,221.68 ns | 1,977,734.38 ns |  2,431,048.44 ns |  45,950.75 |               Linq:Select | 100000 |              Select:100000 |        - |
| .NET Framework 4.7.2 | 2,810,805.74 ns |  54,574.441 ns | 2,799,402.54 ns | 2,734,396.09 ns |  2,922,160.55 ns |  60,387.80 |               Linq:Select | 100000 |              Select:100000 |        - |
|   .NET Framework 4.8 | 2,837,181.12 ns |  55,093.730 ns | 2,838,489.26 ns | 2,742,923.83 ns |  2,935,327.34 ns |  60,907.69 |               Linq:Select | 100000 |              Select:100000 |        - |
|             .NET 5.0 | 3,084,185.79 ns |  31,460.125 ns | 3,088,318.36 ns | 3,012,519.53 ns |  3,138,855.47 ns |  66,928.11 |               List:Select | 100000 |              Select:100000 | 500.0000 |
| .NET Framework 4.7.2 | 3,254,355.72 ns |  64,143.530 ns | 3,239,048.05 ns | 3,133,851.56 ns |  3,368,314.84 ns |  69,753.37 |               List:Select | 100000 |              Select:100000 | 457.0313 |
|   .NET Framework 4.8 | 3,635,711.83 ns | 221,856.042 ns | 3,537,223.24 ns | 3,366,853.32 ns |  4,236,671.68 ns |  78,295.50 |               List:Select | 100000 |              Select:100000 | 460.9375 |
|             .NET 6.0 | 4,610,160.20 ns | 256,241.241 ns | 4,618,250.00 ns | 4,101,701.17 ns |  5,283,456.25 ns |  98,135.35 |               List:Select | 100000 |              Select:100000 | 500.0000 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.18 ns |       0.451 ns |        43.16 ns |        42.19 ns |         43.77 ns |       1.00 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |        45.98 ns |       1.250 ns |        45.90 ns |        43.66 ns |         48.98 ns |       1.07 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |        80.69 ns |       1.597 ns |        80.89 ns |        78.42 ns |         83.73 ns |       1.87 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
|             .NET 6.0 |        85.08 ns |       5.179 ns |        83.56 ns |        78.39 ns |        100.95 ns |       2.01 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0459 |
|             .NET 6.0 |        90.62 ns |       1.795 ns |        90.49 ns |        87.54 ns |         93.33 ns |       2.10 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
| .NET Framework 4.7.2 |        93.10 ns |       1.400 ns |        93.58 ns |        90.85 ns |         96.23 ns |       2.16 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        96.29 ns |       3.853 ns |        94.96 ns |        90.38 ns |        105.04 ns |       2.19 |          Array:SelectTake |      1 |          SelectTake:000001 |   0.0153 |
|             .NET 5.0 |       101.10 ns |       5.194 ns |        99.03 ns |        94.84 ns |        114.79 ns |       2.47 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0433 |
| .NET Framework 4.7.2 |       157.16 ns |       3.902 ns |       156.70 ns |       151.94 ns |        167.09 ns |       3.66 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
|   .NET Framework 4.8 |       158.84 ns |       2.768 ns |       158.35 ns |       154.35 ns |        163.68 ns |       3.69 |           List:SelectTake |      1 |          SelectTake:000001 |   0.0484 |
| .NET Framework 4.7.2 |       246.61 ns |       4.610 ns |       245.06 ns |       238.55 ns |        254.40 ns |       5.70 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
|   .NET Framework 4.8 |       266.11 ns |      11.258 ns |       267.03 ns |       244.34 ns |        293.46 ns |       6.21 |           Linq:SelectTake |      1 |          SelectTake:000001 |   0.0572 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.06 ns |       0.658 ns |        42.89 ns |        42.23 ns |         44.74 ns |       1.00 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 5.0 |        61.68 ns |       2.760 ns |        61.66 ns |        57.09 ns |         67.75 ns |       1.38 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        95.09 ns |       2.561 ns |        94.75 ns |        90.67 ns |        100.82 ns |       2.20 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        95.52 ns |       2.987 ns |        95.07 ns |        90.91 ns |        103.17 ns |       2.22 |          Array:SelectTake |    250 |          SelectTake:000250 |   0.0153 |
|             .NET 6.0 |     1,171.52 ns |      32.595 ns |     1,164.25 ns |     1,125.10 ns |      1,270.99 ns |      27.18 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,190.24 ns |      28.143 ns |     1,184.21 ns |     1,158.42 ns |      1,264.84 ns |      27.84 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0534 |
|             .NET 5.0 |     1,506.24 ns |      26.963 ns |     1,505.79 ns |     1,456.81 ns |      1,540.88 ns |      35.01 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
|             .NET 6.0 |     1,536.68 ns |      20.482 ns |     1,535.85 ns |     1,487.97 ns |      1,578.99 ns |      35.67 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,755.22 ns |      91.824 ns |     1,727.28 ns |     1,642.99 ns |      2,043.27 ns |      40.59 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,767.78 ns |      32.063 ns |     1,769.78 ns |     1,730.17 ns |      1,839.81 ns |      41.05 |           List:SelectTake |    250 |          SelectTake:000250 |   0.5417 |
| .NET Framework 4.7.2 |     2,517.55 ns |      51.032 ns |     2,517.71 ns |     2,446.26 ns |      2,637.11 ns |      58.58 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
|   .NET Framework 4.8 |     2,625.01 ns |     141.191 ns |     2,597.06 ns |     2,438.50 ns |      3,012.47 ns |      59.20 |           Linq:SelectTake |    250 |          SelectTake:000250 |   0.0572 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        46.47 ns |       2.078 ns |        46.66 ns |        41.25 ns |         50.60 ns |       1.00 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 5.0 |        49.10 ns |       3.454 ns |        48.60 ns |        42.93 ns |         58.20 ns |       1.07 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        94.14 ns |       0.803 ns |        94.05 ns |        92.76 ns |         95.41 ns |       1.98 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        95.55 ns |       4.769 ns |        94.02 ns |        88.73 ns |        107.60 ns |       2.07 |          Array:SelectTake |   5000 |          SelectTake:005000 |   0.0153 |
|             .NET 5.0 |    21,401.57 ns |     734.567 ns |    21,189.56 ns |    20,558.24 ns |     23,299.73 ns |     462.75 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 6.0 |    22,398.22 ns |   1,952.109 ns |    21,930.82 ns |    20,261.24 ns |     27,954.24 ns |     496.89 |           Linq:SelectTake |   5000 |          SelectTake:005000 |   0.0305 |
|             .NET 5.0 |    25,617.60 ns |     346.952 ns |    25,595.14 ns |    24,956.56 ns |     26,313.07 ns |     540.77 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|             .NET 6.0 |    25,934.18 ns |     201.885 ns |    25,955.38 ns |    25,534.89 ns |     26,194.82 ns |     545.14 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
| .NET Framework 4.7.2 |    27,750.92 ns |     316.062 ns |    27,820.51 ns |    27,181.30 ns |     28,099.25 ns |     585.92 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
|   .NET Framework 4.8 |    28,188.06 ns |     535.302 ns |    28,146.38 ns |    27,365.62 ns |     29,113.64 ns |     594.52 |           List:SelectTake |   5000 |          SelectTake:005000 |   7.8735 |
| .NET Framework 4.7.2 |    45,754.82 ns |   1,207.375 ns |    45,275.48 ns |    44,400.67 ns |     48,765.45 ns |     979.32 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
|   .NET Framework 4.8 |    46,581.69 ns |   1,796.245 ns |    45,789.51 ns |    44,210.42 ns |     51,200.90 ns |   1,005.67 |           Linq:SelectTake |   5000 |          SelectTake:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        41.52 ns |       0.585 ns |        41.49 ns |        40.66 ns |         42.85 ns |       1.00 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 5.0 |        42.24 ns |       0.643 ns |        42.10 ns |        41.40 ns |         43.71 ns |       1.02 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        94.82 ns |       1.307 ns |        94.97 ns |        91.23 ns |         97.23 ns |       2.29 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        95.87 ns |       1.355 ns |        95.74 ns |        93.93 ns |         98.20 ns |       2.31 |          Array:SelectTake | 100000 |          SelectTake:100000 |   0.0153 |
|             .NET 6.0 |   418,079.56 ns |   7,868.339 ns |   417,421.22 ns |   407,629.00 ns |    434,654.64 ns |  10,094.83 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 5.0 |   420,526.42 ns |   9,167.171 ns |   420,971.14 ns |   406,205.62 ns |    438,776.42 ns |  10,043.11 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|             .NET 5.0 |   615,911.65 ns |   8,174.265 ns |   615,464.50 ns |   599,935.64 ns |    628,585.45 ns |  14,828.06 |           List:SelectTake | 100000 |          SelectTake:100000 | 153.3203 |
|   .NET Framework 4.8 |   660,196.11 ns |   7,056.075 ns |   659,334.77 ns |   650,605.96 ns |    673,960.06 ns |  15,919.62 |           List:SelectTake | 100000 |          SelectTake:100000 | 166.9922 |
| .NET Framework 4.7.2 |   724,216.37 ns |  21,079.111 ns |   722,205.86 ns |   689,714.06 ns |    769,335.45 ns |  17,775.53 |           List:SelectTake | 100000 |          SelectTake:100000 | 168.9453 |
|             .NET 6.0 |   891,949.83 ns | 105,493.702 ns |   880,158.01 ns |   710,865.82 ns |  1,212,655.86 ns |  21,678.30 |           List:SelectTake | 100000 |          SelectTake:100000 | 164.0625 |
| .NET Framework 4.7.2 |   914,401.36 ns |  34,243.675 ns |   902,092.97 ns |   876,064.84 ns |  1,007,633.69 ns |  22,455.55 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|   .NET Framework 4.8 |   915,234.94 ns |  31,014.302 ns |   904,911.57 ns |   878,944.04 ns |  1,028,020.12 ns |  22,042.47 |           Linq:SelectTake | 100000 |          SelectTake:100000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        39.04 ns |       2.871 ns |        38.69 ns |        35.25 ns |         48.46 ns |       1.00 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        45.54 ns |       2.202 ns |        45.49 ns |        41.93 ns |         51.17 ns |       1.15 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|   .NET Framework 4.8 |        66.69 ns |       1.556 ns |        66.27 ns |        64.72 ns |         69.78 ns |       1.67 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        68.43 ns |       4.014 ns |        67.06 ns |        63.26 ns |         80.41 ns |       1.75 |      Array:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |        80.27 ns |       1.357 ns |        79.99 ns |        78.76 ns |         83.40 ns |       2.05 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 5.0 |        82.66 ns |       5.139 ns |        81.36 ns |        76.23 ns |         96.67 ns |       2.12 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0459 |
|             .NET 6.0 |        93.31 ns |       5.769 ns |        90.77 ns |        86.57 ns |        107.94 ns |       2.40 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
|             .NET 5.0 |       113.18 ns |       5.080 ns |       112.90 ns |       100.56 ns |        125.16 ns |       2.84 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0433 |
| .NET Framework 4.7.2 |       157.33 ns |       2.642 ns |       157.26 ns |       153.49 ns |        163.22 ns |       4.01 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
|   .NET Framework 4.8 |       159.23 ns |       6.071 ns |       157.32 ns |       151.47 ns |        175.98 ns |       3.91 |       List:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0484 |
|   .NET Framework 4.8 |       476.43 ns |      25.992 ns |       473.37 ns |       436.04 ns |        547.97 ns |      12.21 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0963 |
| .NET Framework 4.7.2 |       499.22 ns |      24.165 ns |       500.72 ns |       445.88 ns |        551.62 ns |      12.63 |       Linq:SelectTakeLast |      1 |      SelectTakeLast:000001 |   0.0968 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        37.68 ns |       0.790 ns |        37.64 ns |        36.70 ns |         39.57 ns |       0.98 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 6.0 |        39.94 ns |       1.995 ns |        39.72 ns |        35.24 ns |         44.56 ns |       1.00 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        67.72 ns |       2.220 ns |        67.10 ns |        64.68 ns |         73.25 ns |       1.72 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        70.46 ns |       5.017 ns |        69.15 ns |        63.77 ns |         84.71 ns |       1.80 |      Array:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |     1,266.66 ns |      52.555 ns |     1,270.79 ns |     1,176.70 ns |      1,394.76 ns |      31.76 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0534 |
|             .NET 5.0 |     1,566.14 ns |     111.757 ns |     1,544.55 ns |     1,428.61 ns |      1,838.28 ns |      38.91 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|             .NET 6.0 |     1,586.30 ns |      60.276 ns |     1,570.37 ns |     1,494.76 ns |      1,764.19 ns |      40.05 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,763.08 ns |      92.694 ns |     1,718.55 ns |     1,657.79 ns |      2,007.84 ns |      44.59 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,799.98 ns |      53.746 ns |     1,796.24 ns |     1,706.52 ns |      1,897.76 ns |      45.77 |       List:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,833.64 ns |      29.492 ns |     1,834.65 ns |     1,793.72 ns |      1,881.91 ns |      47.54 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     8,056.31 ns |     244.339 ns |     8,012.41 ns |     7,714.54 ns |      8,601.82 ns |     204.85 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
|   .NET Framework 4.8 |     8,249.85 ns |     253.252 ns |     8,162.06 ns |     7,773.24 ns |      8,882.16 ns |     209.51 |       Linq:SelectTakeLast |    250 |      SelectTakeLast:000250 |   0.5646 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        35.89 ns |       0.754 ns |        35.68 ns |        34.98 ns |         37.71 ns |       1.00 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        47.07 ns |       6.221 ns |        45.93 ns |        38.68 ns |         64.30 ns |       1.35 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        67.93 ns |       2.668 ns |        67.14 ns |        64.45 ns |         74.57 ns |       1.92 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        69.37 ns |       3.365 ns |        68.61 ns |        64.71 ns |         78.10 ns |       1.89 |      Array:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0153 |
|             .NET 5.0 |    22,328.84 ns |   1,311.765 ns |    21,870.98 ns |    20,563.94 ns |     26,290.88 ns |     612.69 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0305 |
|             .NET 5.0 |    25,968.85 ns |   1,380.662 ns |    25,514.91 ns |    24,424.18 ns |     29,644.04 ns |     722.48 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    27,737.11 ns |     435.757 ns |    27,665.29 ns |    27,111.90 ns |     28,743.80 ns |     765.19 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    27,893.15 ns |   1,291.570 ns |    27,751.56 ns |    25,496.50 ns |     30,652.80 ns |     769.39 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    29,728.84 ns |   1,219.853 ns |    29,549.13 ns |    27,416.29 ns |     32,345.92 ns |     839.54 |       List:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8735 |
|             .NET 6.0 |    32,776.37 ns |     733.878 ns |    32,547.86 ns |    31,924.98 ns |     34,222.41 ns |     911.49 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |   149,793.77 ns |   2,299.810 ns |   149,975.00 ns |   145,401.86 ns |    155,291.50 ns |   4,133.25 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
| .NET Framework 4.7.2 |   150,353.71 ns |   1,754.890 ns |   150,322.83 ns |   146,452.32 ns |    153,171.12 ns |   4,151.90 |       Linq:SelectTakeLast |   5000 |      SelectTakeLast:005000 |   7.8125 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        38.97 ns |       2.981 ns |        38.41 ns |        34.43 ns |         46.47 ns |       1.00 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        42.83 ns |       4.058 ns |        42.64 ns |        35.40 ns |         54.27 ns |       1.10 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        66.18 ns |       0.870 ns |        66.04 ns |        64.58 ns |         67.74 ns |       1.66 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        73.73 ns |       4.266 ns |        73.20 ns |        64.39 ns |         83.84 ns |       1.89 |      Array:SelectTakeLast | 100000 |      SelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |   447,743.87 ns |  18,159.415 ns |   444,288.38 ns |   419,827.00 ns |    484,147.80 ns |  11,474.09 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|             .NET 5.0 |   640,161.97 ns |  30,958.974 ns |   632,653.42 ns |   592,771.68 ns |    723,943.46 ns |  16,210.37 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 191.4063 |
|             .NET 6.0 |   690,286.39 ns |  30,498.788 ns |   681,825.98 ns |   641,275.10 ns |    751,676.07 ns |  17,683.21 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 |        - |
|   .NET Framework 4.8 |   725,689.53 ns |  12,324.698 ns |   722,219.53 ns |   709,096.78 ns |    749,673.73 ns |  18,436.31 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 170.8984 |
|             .NET 6.0 |   732,242.27 ns |  60,223.926 ns |   725,912.11 ns |   647,660.64 ns |    878,779.00 ns |  18,839.90 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 181.6406 |
| .NET Framework 4.7.2 |   732,861.73 ns |  24,888.834 ns |   727,980.27 ns |   690,884.96 ns |    802,531.93 ns |  18,692.10 |       List:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 166.9922 |
| .NET Framework 4.7.2 | 2,993,285.83 ns |  28,270.923 ns | 2,987,578.32 ns | 2,962,336.72 ns |  3,067,820.70 ns |  75,657.41 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
|   .NET Framework 4.8 | 3,156,300.12 ns | 127,507.928 ns | 3,140,262.89 ns | 2,952,438.67 ns |  3,491,898.44 ns |  80,905.33 |       Linq:SelectTakeLast | 100000 |      SelectTakeLast:100000 | 207.0313 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        52.68 ns |       1.845 ns |        52.27 ns |        49.22 ns |         57.07 ns |       0.95 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 6.0 |        55.40 ns |       2.262 ns |        55.35 ns |        52.08 ns |         60.23 ns |       1.00 |                Array:Take |      1 |                Take:000001 |   0.0293 |
|             .NET 6.0 |        62.23 ns |       2.073 ns |        61.53 ns |        59.89 ns |         66.74 ns |       1.12 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        71.13 ns |       0.552 ns |        71.13 ns |        70.35 ns |         72.16 ns |       1.29 |                 Linq:Take |      1 |                Take:000001 |   0.0267 |
|             .NET 5.0 |        76.31 ns |       1.293 ns |        75.78 ns |        74.38 ns |         78.91 ns |       1.38 |                 List:Take |      1 |                Take:000001 |   0.0459 |
|             .NET 6.0 |        81.22 ns |       2.145 ns |        80.32 ns |        78.56 ns |         86.44 ns |       1.46 |                 List:Take |      1 |                Take:000001 |   0.0459 |
| .NET Framework 4.7.2 |       145.75 ns |       1.962 ns |       145.42 ns |       142.42 ns |        149.20 ns |       2.64 |                 List:Take |      1 |                Take:000001 |   0.0484 |
|   .NET Framework 4.8 |       147.00 ns |       2.378 ns |       146.07 ns |       143.61 ns |        153.13 ns |       2.67 |                 List:Take |      1 |                Take:000001 |   0.0484 |
|   .NET Framework 4.8 |       207.34 ns |       4.468 ns |       206.33 ns |       200.27 ns |        218.14 ns |       3.74 |                Array:Take |      1 |                Take:000001 |   0.0305 |
|   .NET Framework 4.8 |       213.40 ns |       2.646 ns |       213.14 ns |       209.00 ns |        219.36 ns |       3.86 |                 Linq:Take |      1 |                Take:000001 |   0.0393 |
| .NET Framework 4.7.2 |       214.65 ns |      11.867 ns |       210.90 ns |       199.31 ns |        247.62 ns |       3.95 |                Array:Take |      1 |                Take:000001 |   0.0305 |
| .NET Framework 4.7.2 |       227.20 ns |       4.109 ns |       227.15 ns |       221.75 ns |        235.42 ns |       4.10 |                 Linq:Take |      1 |                Take:000001 |   0.0393 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        51.65 ns |       1.484 ns |        51.31 ns |        49.47 ns |         55.02 ns |       0.97 |                Array:Take |    250 |                Take:000250 |   0.0293 |
|             .NET 6.0 |        53.08 ns |       1.351 ns |        52.95 ns |        51.05 ns |         56.34 ns |       1.00 |                Array:Take |    250 |                Take:000250 |   0.0293 |
| .NET Framework 4.7.2 |       206.54 ns |       1.890 ns |       206.61 ns |       202.74 ns |        209.76 ns |       3.86 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|   .NET Framework 4.8 |       214.32 ns |      10.272 ns |       210.87 ns |       202.18 ns |        247.71 ns |       4.18 |                Array:Take |    250 |                Take:000250 |   0.0305 |
|             .NET 6.0 |       926.85 ns |      21.966 ns |       926.14 ns |       897.07 ns |        982.69 ns |      17.46 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 5.0 |       969.30 ns |      32.571 ns |       965.71 ns |       912.75 ns |      1,032.56 ns |      18.36 |                 Linq:Take |    250 |                Take:000250 |   0.0362 |
|             .NET 6.0 |     1,304.99 ns |      46.934 ns |     1,285.56 ns |     1,253.52 ns |      1,401.64 ns |      24.73 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|             .NET 5.0 |     1,320.25 ns |      49.246 ns |     1,302.90 ns |     1,264.49 ns |      1,416.08 ns |      24.89 |                 List:Take |    250 |                Take:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,442.19 ns |      19.007 ns |     1,432.46 ns |     1,416.80 ns |      1,479.29 ns |      26.86 |                 List:Take |    250 |                Take:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,456.49 ns |      28.233 ns |     1,453.21 ns |     1,418.49 ns |      1,500.59 ns |      27.32 |                 List:Take |    250 |                Take:000250 |   0.5417 |
|   .NET Framework 4.8 |     1,930.64 ns |      30.296 ns |     1,933.45 ns |     1,892.59 ns |      1,990.66 ns |      36.12 |                 Linq:Take |    250 |                Take:000250 |   0.0477 |
| .NET Framework 4.7.2 |     1,938.50 ns |      44.742 ns |     1,924.82 ns |     1,865.37 ns |      2,037.60 ns |      36.53 |                 Linq:Take |    250 |                Take:000250 |   0.0458 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |    16,248.39 ns |     188.487 ns |    16,152.43 ns |    16,026.13 ns |     16,589.76 ns |       0.99 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 6.0 |    16,320.45 ns |     214.039 ns |    16,268.21 ns |    16,027.85 ns |     16,790.21 ns |       1.00 |                 Linq:Take |   5000 |                Take:005000 |   0.0305 |
|             .NET 5.0 |    20,258.87 ns |     641.932 ns |    20,025.87 ns |    19,385.04 ns |     21,659.39 ns |       1.26 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|             .NET 6.0 |    22,279.88 ns |     254.638 ns |    22,232.48 ns |    21,920.47 ns |     22,905.94 ns |       1.36 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
| .NET Framework 4.7.2 |    23,277.06 ns |     117.190 ns |    23,278.42 ns |    23,086.48 ns |     23,446.77 ns |       1.42 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
|   .NET Framework 4.8 |    23,953.01 ns |     763.246 ns |    23,740.57 ns |    23,088.65 ns |     25,626.40 ns |       1.47 |                 List:Take |   5000 |                Take:005000 |   7.8735 |
| .NET Framework 4.7.2 |    31,976.60 ns |     353.499 ns |    31,933.75 ns |    31,491.25 ns |     32,747.88 ns |       1.96 |                 Linq:Take |   5000 |                Take:005000 |        - |
|   .NET Framework 4.8 |    32,255.47 ns |     414.373 ns |    32,254.59 ns |    31,657.05 ns |     33,114.43 ns |       1.97 |                 Linq:Take |   5000 |                Take:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        56.66 ns |       1.812 ns |        56.56 ns |        52.81 ns |         60.36 ns |       1.00 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
|             .NET 5.0 |        61.70 ns |       1.041 ns |        61.66 ns |        59.87 ns |         63.49 ns |       1.07 |                Array:Take |   5000 |                Take:050000 |   0.0293 |
|   .NET Framework 4.8 |       213.46 ns |      10.703 ns |       209.85 ns |       200.27 ns |        246.13 ns |       3.80 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
| .NET Framework 4.7.2 |       219.53 ns |      10.020 ns |       219.09 ns |       202.70 ns |        244.96 ns |       3.80 |                Array:Take |   5000 |                Take:050000 |   0.0305 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        55.81 ns |       0.818 ns |        55.57 ns |        54.68 ns |         57.36 ns |       0.91 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
|             .NET 6.0 |        62.52 ns |       3.383 ns |        62.67 ns |        56.76 ns |         69.71 ns |       1.00 |                Array:Take | 100000 |                Take:100000 |   0.0293 |
| .NET Framework 4.7.2 |       207.52 ns |       3.678 ns |       207.31 ns |       202.09 ns |        213.48 ns |       3.38 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
|   .NET Framework 4.8 |       209.02 ns |       4.032 ns |       208.66 ns |       202.17 ns |        216.90 ns |       3.39 |                Array:Take | 100000 |                Take:100000 |   0.0305 |
|             .NET 5.0 |   322,444.74 ns |  10,638.462 ns |   320,445.92 ns |   309,478.56 ns |    345,445.85 ns |   5,167.02 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 6.0 |   336,123.26 ns |   5,889.108 ns |   336,070.26 ns |   329,391.46 ns |    345,905.47 ns |   5,473.91 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 5.0 |   542,180.98 ns |  10,122.610 ns |   541,545.31 ns |   525,605.57 ns |    562,270.21 ns |   8,735.58 |                 List:Take | 100000 |                Take:100000 | 164.0625 |
| .NET Framework 4.7.2 |   570,642.54 ns |   7,206.518 ns |   571,931.05 ns |   555,354.10 ns |    584,594.34 ns |   9,291.88 |                 List:Take | 100000 |                Take:100000 | 143.5547 |
|   .NET Framework 4.8 |   571,418.39 ns |   7,898.187 ns |   571,475.98 ns |   560,812.11 ns |    584,150.29 ns |   9,306.87 |                 List:Take | 100000 |                Take:100000 | 144.5313 |
| .NET Framework 4.7.2 |   624,619.07 ns |   7,488.287 ns |   626,915.23 ns |   610,392.68 ns |    634,028.52 ns |  10,209.09 |                 Linq:Take | 100000 |                Take:100000 |        - |
|   .NET Framework 4.8 |   630,261.58 ns |   7,978.245 ns |   629,843.51 ns |   617,897.36 ns |    647,087.21 ns |  10,280.76 |                 Linq:Take | 100000 |                Take:100000 |        - |
|             .NET 6.0 |   843,840.92 ns |  66,187.330 ns |   847,962.11 ns |   685,707.52 ns |  1,021,942.77 ns |  13,607.90 |                 List:Take | 100000 |                Take:100000 | 165.0391 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        43.48 ns |       0.671 ns |        43.39 ns |        42.61 ns |         44.62 ns |       0.94 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        47.12 ns |       1.792 ns |        46.93 ns |        43.86 ns |         51.42 ns |       1.00 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
|             .NET 6.0 |        62.21 ns |       1.513 ns |        61.71 ns |        60.00 ns |         66.45 ns |       1.34 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 5.0 |        72.77 ns |       1.480 ns |        73.38 ns |        69.94 ns |         75.42 ns |       1.57 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0267 |
|             .NET 5.0 |        79.95 ns |       2.967 ns |        79.21 ns |        75.16 ns |         87.42 ns |       1.70 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|             .NET 6.0 |        80.11 ns |       2.901 ns |        79.31 ns |        76.62 ns |         87.24 ns |       1.70 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0459 |
|   .NET Framework 4.8 |        91.94 ns |       1.037 ns |        91.96 ns |        90.40 ns |         94.03 ns |       1.99 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |        93.20 ns |       1.432 ns |        93.67 ns |        91.02 ns |         95.13 ns |       2.01 |            Array:TakeLast |      1 |            TakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |       144.39 ns |       2.352 ns |       144.82 ns |       139.98 ns |        148.78 ns |       3.12 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
|   .NET Framework 4.8 |       149.38 ns |       4.940 ns |       148.85 ns |       142.83 ns |        162.05 ns |       3.19 |             List:TakeLast |      1 |            TakeLast:000001 |   0.0484 |
| .NET Framework 4.7.2 |       316.12 ns |       3.399 ns |       315.47 ns |       310.73 ns |        322.01 ns |       6.83 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|   .NET Framework 4.8 |       324.12 ns |      13.553 ns |       321.44 ns |       305.17 ns |        361.59 ns |       6.93 |             Linq:TakeLast |      1 |            TakeLast:000001 |   0.0701 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.03 ns |       1.756 ns |        42.65 ns |        40.47 ns |         46.90 ns |       1.00 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 5.0 |        48.43 ns |       3.200 ns |        48.46 ns |        43.51 ns |         60.31 ns |       1.09 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        94.05 ns |       1.071 ns |        93.87 ns |        92.63 ns |         96.72 ns |       2.13 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        95.40 ns |       3.563 ns |        94.62 ns |        89.84 ns |        106.49 ns |       2.22 |            Array:TakeLast |    250 |            TakeLast:000250 |   0.0153 |
|             .NET 5.0 |       939.11 ns |      19.612 ns |       941.65 ns |       911.62 ns |        988.34 ns |      21.52 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0362 |
|             .NET 5.0 |     1,322.64 ns |      61.011 ns |     1,316.49 ns |     1,227.27 ns |      1,475.48 ns |      30.88 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|             .NET 6.0 |     1,332.38 ns |      21.691 ns |     1,335.29 ns |     1,296.72 ns |      1,373.40 ns |      30.11 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5379 |
|   .NET Framework 4.8 |     1,420.79 ns |      36.795 ns |     1,412.49 ns |     1,372.18 ns |      1,506.35 ns |      32.63 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
| .NET Framework 4.7.2 |     1,502.78 ns |      71.058 ns |     1,483.10 ns |     1,414.94 ns |      1,696.60 ns |      35.23 |             List:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|             .NET 6.0 |     1,520.99 ns |      22.092 ns |     1,515.80 ns |     1,491.36 ns |      1,567.86 ns |      34.22 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.0534 |
| .NET Framework 4.7.2 |     2,217.38 ns |      25.493 ns |     2,216.09 ns |     2,175.30 ns |      2,274.44 ns |      50.12 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|   .NET Framework 4.8 |     2,280.95 ns |      27.312 ns |     2,269.95 ns |     2,244.88 ns |      2,326.99 ns |      51.33 |             Linq:TakeLast |    250 |            TakeLast:000250 |   0.5417 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        46.55 ns |       2.302 ns |        45.58 ns |        43.72 ns |         52.40 ns |       0.97 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 6.0 |        48.59 ns |       1.688 ns |        48.13 ns |        46.28 ns |         52.86 ns |       1.00 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.23 ns |       2.697 ns |        92.69 ns |        89.59 ns |        100.41 ns |       1.92 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.92 ns |       1.605 ns |        93.63 ns |        91.17 ns |         96.72 ns |       1.93 |            Array:TakeLast |   5000 |            TakeLast:005000 |   0.0153 |
|             .NET 5.0 |    15,760.63 ns |     342.137 ns |    15,725.59 ns |    15,356.42 ns |     16,578.31 ns |     324.40 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
|             .NET 6.0 |    21,170.93 ns |     489.077 ns |    21,134.31 ns |    20,493.32 ns |     22,202.32 ns |     434.50 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 5.0 |    22,379.86 ns |   1,348.025 ns |    22,221.83 ns |    19,863.85 ns |     25,704.82 ns |     463.94 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    23,698.32 ns |     438.805 ns |    23,686.27 ns |    23,157.36 ns |     24,662.22 ns |     486.10 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
| .NET Framework 4.7.2 |    24,795.14 ns |   1,676.636 ns |    24,093.17 ns |    23,035.34 ns |     28,914.58 ns |     530.33 |             List:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|             .NET 6.0 |    29,314.06 ns |   2,240.043 ns |    28,549.52 ns |    26,734.11 ns |     35,393.36 ns |     615.15 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   0.0305 |
| .NET Framework 4.7.2 |    36,717.37 ns |     699.007 ns |    36,672.08 ns |    35,633.09 ns |     37,978.40 ns |     754.47 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|   .NET Framework 4.8 |    37,230.41 ns |     801.235 ns |    37,511.60 ns |    35,406.55 ns |     38,605.35 ns |     766.41 |             Linq:TakeLast |   5000 |            TakeLast:005000 |   7.8735 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        45.41 ns |       3.152 ns |        44.79 ns |        41.25 ns |         55.37 ns |       0.92 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 6.0 |        49.58 ns |       3.161 ns |        49.31 ns |        44.76 ns |         59.13 ns |       1.00 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        91.76 ns |       0.800 ns |        91.68 ns |        90.73 ns |         93.02 ns |       1.87 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |       102.07 ns |       1.327 ns |       102.29 ns |       100.16 ns |        103.94 ns |       2.08 |            Array:TakeLast | 100000 |            TakeLast:100000 |   0.0153 |
|             .NET 5.0 |   318,610.11 ns |   7,178.077 ns |   315,968.51 ns |   308,442.09 ns |    331,362.94 ns |   6,538.21 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
|             .NET 5.0 |   543,280.13 ns |   9,562.476 ns |   543,060.45 ns |   527,441.31 ns |    561,566.60 ns |  11,059.30 |             List:TakeLast | 100000 |            TakeLast:100000 | 165.0391 |
|             .NET 6.0 |   558,727.50 ns |  10,684.366 ns |   558,036.77 ns |   539,791.70 ns |    579,856.64 ns |  11,327.49 |             Linq:TakeLast | 100000 |            TakeLast:100000 |        - |
| .NET Framework 4.7.2 |   595,660.42 ns |   9,457.626 ns |   598,780.57 ns |   578,438.48 ns |    607,762.60 ns |  12,121.18 |             List:TakeLast | 100000 |            TakeLast:100000 | 149.4141 |
|   .NET Framework 4.8 |   660,381.62 ns |  12,594.287 ns |   661,044.34 ns |   635,076.76 ns |    684,414.06 ns |  13,430.79 |             List:TakeLast | 100000 |            TakeLast:100000 | 150.3906 |
| .NET Framework 4.7.2 |   821,694.62 ns |  11,684.096 ns |   823,025.83 ns |   799,494.38 ns |    842,360.99 ns |  16,724.34 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 177.7344 |
|   .NET Framework 4.8 |   822,903.15 ns |   8,138.273 ns |   824,726.07 ns |   806,481.54 ns |    836,488.28 ns |  16,753.32 |             Linq:TakeLast | 100000 |            TakeLast:100000 | 175.7813 |
|             .NET 6.0 |   831,284.02 ns |  62,967.621 ns |   831,959.86 ns |   663,856.15 ns |    968,680.76 ns |  16,805.70 |             List:TakeLast | 100000 |            TakeLast:100000 | 162.1094 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        42.54 ns |       1.369 ns |        42.20 ns |        40.68 ns |         45.29 ns |       1.00 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 5.0 |        45.49 ns |       1.311 ns |        45.13 ns |        43.54 ns |         48.02 ns |       1.07 |               Array:Where |      1 |               Where:000001 |   0.0153 |
| .NET Framework 4.7.2 |        93.00 ns |       0.993 ns |        92.75 ns |        91.60 ns |         94.96 ns |       2.18 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|   .NET Framework 4.8 |        93.09 ns |       0.797 ns |        93.20 ns |        92.02 ns |         94.43 ns |       2.18 |               Array:Where |      1 |               Where:000001 |   0.0153 |
|             .NET 5.0 |       114.61 ns |       2.233 ns |       113.99 ns |       112.23 ns |        120.77 ns |       2.68 |                List:Where |      1 |               Where:000001 |   0.0535 |
|             .NET 6.0 |       117.43 ns |       1.719 ns |       117.85 ns |       114.53 ns |        120.16 ns |       2.75 |                List:Where |      1 |               Where:000001 |   0.0534 |
|             .NET 6.0 |       130.79 ns |       5.310 ns |       128.55 ns |       125.05 ns |        143.74 ns |       3.10 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
|             .NET 5.0 |       144.70 ns |       1.338 ns |       144.92 ns |       142.50 ns |        147.18 ns |       3.38 |                Linq:Where |      1 |               Where:000001 |   0.0508 |
| .NET Framework 4.7.2 |       166.04 ns |       2.452 ns |       165.20 ns |       163.10 ns |        171.34 ns |       3.88 |                List:Where |      1 |               Where:000001 |   0.0560 |
|   .NET Framework 4.8 |       167.16 ns |       1.307 ns |       167.08 ns |       164.97 ns |        169.74 ns |       3.90 |                List:Where |      1 |               Where:000001 |   0.0560 |
|   .NET Framework 4.8 |       264.15 ns |       2.138 ns |       264.14 ns |       260.76 ns |        269.04 ns |       6.16 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
| .NET Framework 4.7.2 |       265.53 ns |       3.152 ns |       264.81 ns |       260.96 ns |        271.94 ns |       6.23 |                Linq:Where |      1 |               Where:000001 |   0.0505 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.05 ns |       0.796 ns |        42.85 ns |        42.15 ns |         44.60 ns |       1.00 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 5.0 |        45.32 ns |       0.759 ns |        44.83 ns |        44.44 ns |         46.97 ns |       1.05 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|   .NET Framework 4.8 |        93.50 ns |       1.192 ns |        93.23 ns |        92.04 ns |         95.77 ns |       2.17 |               Array:Where |    250 |               Where:000250 |   0.0153 |
| .NET Framework 4.7.2 |        93.82 ns |       2.875 ns |        92.80 ns |        90.65 ns |         99.60 ns |       2.19 |               Array:Where |    250 |               Where:000250 |   0.0153 |
|             .NET 6.0 |     6,991.52 ns |      70.560 ns |     6,983.88 ns |     6,873.18 ns |      7,102.79 ns |     162.38 |                List:Where |    250 |               Where:000250 |   0.9995 |
|             .NET 5.0 |     7,626.54 ns |     273.997 ns |     7,547.41 ns |     7,301.46 ns |      8,099.33 ns |     177.41 |                List:Where |    250 |               Where:000250 |   0.9995 |
|             .NET 6.0 |     9,409.64 ns |      71.698 ns |     9,395.39 ns |     9,275.63 ns |      9,526.29 ns |     218.19 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|   .NET Framework 4.8 |     9,860.40 ns |     112.069 ns |     9,866.93 ns |     9,710.03 ns |     10,063.52 ns |     228.69 |                List:Where |    250 |               Where:000250 |   1.0071 |
| .NET Framework 4.7.2 |    10,056.34 ns |      85.638 ns |    10,063.48 ns |     9,918.90 ns |     10,245.17 ns |     233.16 |                List:Where |    250 |               Where:000250 |   1.0071 |
|             .NET 5.0 |    10,247.52 ns |     353.602 ns |    10,158.37 ns |     9,828.98 ns |     10,917.40 ns |     240.45 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|   .NET Framework 4.8 |    12,690.45 ns |     275.164 ns |    12,640.43 ns |    12,398.78 ns |     13,379.90 ns |     295.86 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
| .NET Framework 4.7.2 |    12,720.43 ns |     163.484 ns |    12,679.77 ns |    12,518.38 ns |     12,988.10 ns |     294.93 |                Linq:Where |    250 |               Where:000250 |   0.0458 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        41.37 ns |       1.350 ns |        40.91 ns |        39.96 ns |         45.14 ns |       1.00 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 5.0 |        42.75 ns |       0.562 ns |        42.82 ns |        41.44 ns |         43.49 ns |       1.03 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.91 ns |       0.890 ns |        94.11 ns |        92.43 ns |         95.27 ns |       2.25 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
| .NET Framework 4.7.2 |        94.17 ns |       1.200 ns |        94.26 ns |        92.72 ns |         96.48 ns |       2.26 |               Array:Where |   5000 |               Where:005000 |   0.0153 |
|             .NET 6.0 |   159,800.49 ns |   5,276.136 ns |   157,706.24 ns |   153,883.23 ns |    171,274.17 ns |   3,869.71 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 5.0 |   170,065.62 ns |   2,858.106 ns |   169,041.08 ns |   166,220.51 ns |    177,644.29 ns |   4,109.30 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|             .NET 6.0 |   191,013.85 ns |   3,872.409 ns |   189,904.99 ns |   185,202.00 ns |    203,109.59 ns |   4,618.81 |                Linq:Where |   5000 |               Where:005000 |        - |
|             .NET 5.0 |   193,135.67 ns |   1,767.656 ns |   193,289.11 ns |   190,140.45 ns |    195,914.23 ns |   4,627.76 |                Linq:Where |   5000 |               Where:005000 |        - |
| .NET Framework 4.7.2 |   229,729.23 ns |  13,307.003 ns |   229,847.85 ns |   208,322.90 ns |    260,309.35 ns |   5,492.38 |                List:Where |   5000 |               Where:005000 |  36.8652 |
|   .NET Framework 4.8 |   230,059.86 ns |  14,021.871 ns |   229,099.19 ns |   209,343.75 ns |    268,054.15 ns |   5,449.17 |                List:Where |   5000 |               Where:005000 |  36.8652 |
| .NET Framework 4.7.2 |   248,257.12 ns |   2,318.388 ns |   248,291.70 ns |   244,780.32 ns |    252,746.88 ns |   5,928.31 |                Linq:Where |   5000 |               Where:005000 |        - |
|   .NET Framework 4.8 |   248,530.69 ns |   2,159.119 ns |   247,964.01 ns |   245,491.60 ns |    251,390.77 ns |   5,948.23 |                Linq:Where |   5000 |               Where:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.08 ns |       0.848 ns |        42.77 ns |        41.98 ns |         45.03 ns |       1.00 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 |        44.73 ns |       0.832 ns |        44.39 ns |        43.82 ns |         46.36 ns |       1.04 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
| .NET Framework 4.7.2 |        93.59 ns |       0.889 ns |        93.60 ns |        91.89 ns |         95.04 ns |       2.17 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|   .NET Framework 4.8 |        95.64 ns |       1.462 ns |        95.69 ns |        93.61 ns |         98.98 ns |       2.22 |               Array:Where | 100000 |               Where:100000 |   0.0153 |
|             .NET 5.0 | 2,974,647.44 ns | 116,801.541 ns | 2,964,607.62 ns | 2,793,175.98 ns |  3,254,395.12 ns |  70,847.41 |                List:Where | 100000 |               Where:100000 | 324.2188 |
|             .NET 6.0 | 3,125,120.37 ns |  90,089.250 ns | 3,100,916.80 ns | 3,003,588.67 ns |  3,331,014.84 ns |  73,375.69 |                List:Where | 100000 |               Where:100000 | 281.2500 |
|             .NET 6.0 | 3,760,207.95 ns |  34,066.105 ns | 3,757,904.49 ns | 3,700,988.09 ns |  3,810,289.65 ns |  87,217.26 |                Linq:Where | 100000 |               Where:100000 |        - |
|             .NET 5.0 | 3,806,672.89 ns |  60,875.256 ns | 3,813,921.48 ns | 3,706,272.66 ns |  3,919,063.28 ns |  88,190.50 |                Linq:Where | 100000 |               Where:100000 |        - |
|   .NET Framework 4.8 | 3,903,368.86 ns |  68,895.706 ns | 3,878,025.78 ns | 3,819,654.69 ns |  4,011,661.72 ns |  90,549.27 |                List:Where | 100000 |               Where:100000 | 234.3750 |
| .NET Framework 4.7.2 | 4,145,071.37 ns |  68,627.621 ns | 4,137,993.36 ns | 4,037,451.95 ns |  4,276,666.80 ns |  96,136.27 |                List:Where | 100000 |               Where:100000 | 242.1875 |
| .NET Framework 4.7.2 | 4,894,868.85 ns |  43,809.588 ns | 4,882,996.09 ns | 4,835,962.50 ns |  4,975,424.22 ns | 113,608.65 |                Linq:Where | 100000 |               Where:100000 |        - |
|   .NET Framework 4.8 | 4,916,651.77 ns |  40,398.838 ns | 4,917,987.50 ns | 4,840,296.09 ns |  4,978,635.94 ns | 114,199.18 |                Linq:Where | 100000 |               Where:100000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.71 ns |       3.539 ns |        42.82 ns |        39.23 ns |         54.50 ns |       1.00 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 5.0 |        57.01 ns |       9.667 ns |        53.21 ns |        44.31 ns |         84.91 ns |       1.32 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|   .NET Framework 4.8 |        98.13 ns |       4.564 ns |        98.01 ns |        90.87 ns |        108.85 ns |       2.19 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
| .NET Framework 4.7.2 |       102.47 ns |       7.863 ns |       101.58 ns |        87.98 ns |        121.97 ns |       2.36 |         Array:WhereSelect |      1 |         WhereSelect:000001 |   0.0153 |
|             .NET 5.0 |       148.54 ns |       3.753 ns |       147.76 ns |       143.42 ns |        154.97 ns |       3.20 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 6.0 |       150.71 ns |       1.825 ns |       151.52 ns |       146.66 ns |        152.66 ns |       3.23 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0610 |
|             .NET 6.0 |       167.96 ns |       3.512 ns |       168.09 ns |       162.95 ns |        174.87 ns |       3.59 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0751 |
|             .NET 5.0 |       200.93 ns |      16.320 ns |       197.15 ns |       180.24 ns |        240.98 ns |       4.63 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
|   .NET Framework 4.8 |       233.86 ns |       7.596 ns |       231.95 ns |       221.86 ns |        252.70 ns |       5.03 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0634 |
| .NET Framework 4.7.2 |       237.98 ns |      12.750 ns |       239.35 ns |       220.86 ns |        270.25 ns |       5.40 |          List:WhereSelect |      1 |         WhereSelect:000001 |   0.0637 |
|   .NET Framework 4.8 |       327.14 ns |       7.752 ns |       326.47 ns |       312.95 ns |        346.91 ns |       7.07 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
| .NET Framework 4.7.2 |       352.61 ns |      15.484 ns |       352.44 ns |       317.30 ns |        393.45 ns |       7.81 |          Linq:WhereSelect |      1 |         WhereSelect:000001 |   0.0749 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        44.17 ns |       0.772 ns |        44.06 ns |        43.15 ns |         45.42 ns |       0.96 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 6.0 |        47.83 ns |       3.167 ns |        47.67 ns |        43.03 ns |         56.44 ns |       1.00 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|   .NET Framework 4.8 |        94.04 ns |       1.915 ns |        94.20 ns |        90.22 ns |         98.00 ns |       2.04 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
| .NET Framework 4.7.2 |       100.44 ns |       5.494 ns |       100.27 ns |        90.45 ns |        114.89 ns |       2.12 |         Array:WhereSelect |    250 |         WhereSelect:000250 |   0.0153 |
|             .NET 6.0 |     5,741.39 ns |     167.640 ns |     5,720.40 ns |     5,531.16 ns |      6,146.54 ns |     126.33 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 5.0 |     7,290.04 ns |     448.005 ns |     7,167.14 ns |     6,735.53 ns |      8,575.18 ns |     153.30 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0687 |
|             .NET 5.0 |     9,886.87 ns |     171.841 ns |     9,852.19 ns |     9,677.60 ns |     10,250.79 ns |     214.21 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
| .NET Framework 4.7.2 |    10,191.61 ns |     117.413 ns |    10,213.46 ns |     9,941.98 ns |     10,357.56 ns |     220.10 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
|             .NET 6.0 |    10,242.88 ns |     204.919 ns |    10,198.73 ns |     9,927.32 ns |     10,558.73 ns |     221.75 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9531 |
|   .NET Framework 4.8 |    10,653.23 ns |     514.023 ns |    10,439.15 ns |    10,019.61 ns |     12,407.45 ns |     226.31 |          Linq:WhereSelect |    250 |         WhereSelect:000250 |   0.0610 |
| .NET Framework 4.7.2 |    12,123.47 ns |     107.865 ns |    12,094.13 ns |    11,921.29 ns |     12,312.81 ns |     262.65 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|   .NET Framework 4.8 |    12,159.13 ns |     281.246 ns |    12,071.53 ns |    11,856.82 ns |     12,866.40 ns |     265.11 |          List:WhereSelect |    250 |         WhereSelect:000250 |   1.9684 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        42.18 ns |       0.940 ns |        42.13 ns |        40.65 ns |         44.63 ns |       1.00 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 5.0 |        43.59 ns |       0.566 ns |        43.55 ns |        42.80 ns |         44.31 ns |       1.03 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
| .NET Framework 4.7.2 |        92.81 ns |       1.566 ns |        92.78 ns |        90.84 ns |         96.51 ns |       2.20 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|   .NET Framework 4.8 |        95.85 ns |       3.740 ns |        95.78 ns |        89.57 ns |        103.85 ns |       2.35 |         Array:WhereSelect |   5000 |         WhereSelect:005000 |   0.0153 |
|             .NET 6.0 |   123,305.24 ns |   2,462.287 ns |   123,504.65 ns |   119,023.85 ns |    128,663.05 ns |   2,921.36 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 5.0 |   128,968.68 ns |   2,491.483 ns |   128,608.78 ns |   124,923.61 ns |    135,319.07 ns |   3,047.08 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
| .NET Framework 4.7.2 |   197,086.16 ns |   1,131.375 ns |   196,957.47 ns |   194,865.62 ns |    198,609.03 ns |   4,680.63 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|   .NET Framework 4.8 |   205,905.44 ns |   6,952.585 ns |   203,075.17 ns |   196,647.80 ns |    219,926.95 ns |   4,940.51 |          Linq:WhereSelect |   5000 |         WhereSelect:005000 |        - |
|             .NET 6.0 |   238,925.71 ns |   2,668.651 ns |   238,986.11 ns |   235,443.16 ns |    245,111.99 ns |   5,673.93 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.9746 |
|             .NET 5.0 |   251,399.70 ns |  11,467.768 ns |   249,147.73 ns |   237,977.29 ns |    277,291.55 ns |   5,982.55 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.9746 |
|   .NET Framework 4.8 |   275,898.34 ns |   3,157.482 ns |   276,262.79 ns |   271,480.71 ns |    280,573.73 ns |   6,552.09 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
| .NET Framework 4.7.2 |   287,904.29 ns |   9,778.160 ns |   285,981.01 ns |   272,226.81 ns |    311,142.04 ns |   6,954.37 |          List:WhereSelect |   5000 |         WhereSelect:005000 |  73.7305 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.85 ns |       0.734 ns |        43.78 ns |        42.56 ns |         44.99 ns |       1.00 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 5.0 |        46.13 ns |       0.668 ns |        46.12 ns |        44.89 ns |         47.21 ns |       1.05 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|   .NET Framework 4.8 |        93.75 ns |       1.095 ns |        93.25 ns |        92.32 ns |         95.87 ns |       2.14 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
| .NET Framework 4.7.2 |        97.18 ns |       6.246 ns |        96.05 ns |        89.35 ns |        116.13 ns |       2.26 |         Array:WhereSelect | 100000 |         WhereSelect:100000 |   0.0153 |
|             .NET 6.0 | 2,689,767.54 ns | 212,065.821 ns | 2,678,446.48 ns | 2,366,373.05 ns |  3,266,637.89 ns |  58,269.65 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 2,789,275.39 ns |  92,764.523 ns | 2,759,933.20 ns | 2,685,378.52 ns |  2,971,455.86 ns |  64,848.99 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
| .NET Framework 4.7.2 | 3,929,378.85 ns |  72,287.873 ns | 3,917,515.62 ns | 3,820,114.84 ns |  4,063,458.59 ns |  89,635.40 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|   .NET Framework 4.8 | 4,200,159.36 ns | 195,316.106 ns | 4,145,946.48 ns | 3,922,489.84 ns |  4,674,989.84 ns |  95,997.63 |          Linq:WhereSelect | 100000 |         WhereSelect:100000 |        - |
|             .NET 5.0 | 5,103,168.95 ns | 261,697.582 ns | 5,087,266.80 ns | 4,631,615.62 ns |  5,731,336.72 ns | 116,528.90 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 328.1250 |
| .NET Framework 4.7.2 | 5,329,090.08 ns | 202,423.138 ns | 5,286,882.42 ns | 5,057,142.97 ns |  5,861,332.03 ns | 124,125.20 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 296.8750 |
|             .NET 6.0 | 5,468,776.39 ns | 254,535.512 ns | 5,471,586.72 ns | 4,910,625.00 ns |  6,129,318.75 ns | 121,418.53 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 335.9375 |
|   .NET Framework 4.8 | 5,469,687.89 ns | 185,891.698 ns | 5,455,028.12 ns | 5,109,463.28 ns |  5,983,661.72 ns | 126,973.81 |          List:WhereSelect | 100000 |         WhereSelect:100000 | 289.0625 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        44.05 ns |       2.931 ns |        43.98 ns |        39.60 ns |         52.62 ns |       1.00 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 5.0 |        50.04 ns |       2.413 ns |        49.52 ns |        46.41 ns |         55.69 ns |       1.15 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |       100.22 ns |       6.061 ns |        98.74 ns |        90.50 ns |        115.56 ns |       2.29 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|   .NET Framework 4.8 |       105.79 ns |       5.778 ns |       105.52 ns |        92.13 ns |        123.28 ns |       2.41 |     Array:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0153 |
|             .NET 5.0 |       109.68 ns |       1.758 ns |       109.33 ns |       107.19 ns |        113.11 ns |       2.51 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 6.0 |       112.23 ns |       1.698 ns |       111.73 ns |       109.25 ns |        114.75 ns |       2.58 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0637 |
|             .NET 6.0 |       128.39 ns |       4.734 ns |       126.59 ns |       122.03 ns |        137.32 ns |       2.92 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
|             .NET 5.0 |       145.30 ns |       2.185 ns |       146.09 ns |       141.50 ns |        148.64 ns |       3.32 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0751 |
| .NET Framework 4.7.2 |       206.86 ns |       1.092 ns |       206.86 ns |       204.20 ns |        208.53 ns |       4.75 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
|   .NET Framework 4.8 |       208.43 ns |       2.872 ns |       207.43 ns |       205.74 ns |        214.58 ns |       4.78 |      List:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0663 |
| .NET Framework 4.7.2 |       301.18 ns |       5.746 ns |       298.54 ns |       293.42 ns |        314.27 ns |       6.84 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
|   .NET Framework 4.8 |       304.16 ns |       7.489 ns |       302.78 ns |       294.77 ns |        321.78 ns |       6.96 |      Linq:WhereSelectTake |      1 |     WhereSelectTake:000001 |   0.0877 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        43.60 ns |       1.158 ns |        43.16 ns |        41.92 ns |         46.53 ns |       0.88 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 6.0 |        47.88 ns |       4.728 ns |        47.07 ns |        40.52 ns |         61.77 ns |       1.00 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        91.31 ns |       1.246 ns |        91.34 ns |        89.26 ns |         93.26 ns |       1.83 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |       106.36 ns |       7.223 ns |       105.35 ns |        93.02 ns |        125.08 ns |       2.24 |     Array:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0153 |
|             .NET 6.0 |     1,994.42 ns |      50.151 ns |     1,965.35 ns |     1,941.32 ns |      2,138.98 ns |      40.24 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 5.0 |     2,001.59 ns |      74.650 ns |     1,995.25 ns |     1,886.01 ns |      2,171.55 ns |      40.26 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|   .NET Framework 4.8 |     2,186.09 ns |      31.946 ns |     2,182.10 ns |     2,139.78 ns |      2,249.56 ns |      43.82 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
| .NET Framework 4.7.2 |     2,219.08 ns |      25.557 ns |     2,221.51 ns |     2,176.66 ns |      2,260.66 ns |      44.69 |      List:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.4501 |
|             .NET 6.0 |     6,355.13 ns |     103.761 ns |     6,341.62 ns |     6,191.28 ns |      6,524.74 ns |     128.06 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
|             .NET 5.0 |     6,755.60 ns |     142.516 ns |     6,710.67 ns |     6,571.01 ns |      7,033.67 ns |     134.32 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0839 |
| .NET Framework 4.7.2 |    10,418.41 ns |     115.213 ns |    10,392.90 ns |    10,264.19 ns |     10,610.92 ns |     208.50 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
|   .NET Framework 4.8 |    10,502.80 ns |     248.654 ns |    10,434.72 ns |    10,165.02 ns |     11,130.47 ns |     211.89 |      Linq:WhereSelectTake |    250 |     WhereSelectTake:000250 |   0.0763 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.31 ns |       0.737 ns |        43.45 ns |        42.38 ns |         45.07 ns |       1.00 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |        50.23 ns |       0.288 ns |        50.26 ns |        49.78 ns |         50.75 ns |       1.16 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        92.63 ns |       1.076 ns |        92.25 ns |        91.38 ns |         95.23 ns |       2.14 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.09 ns |       1.652 ns |        92.38 ns |        90.90 ns |         96.45 ns |       2.15 |     Array:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   0.0153 |
|             .NET 5.0 |    35,299.17 ns |   1,297.742 ns |    34,889.86 ns |    33,778.70 ns |     38,019.60 ns |     814.87 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |    35,331.06 ns |     577.801 ns |    35,187.19 ns |    34,512.31 ns |     36,847.97 ns |     821.47 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
| .NET Framework 4.7.2 |    38,552.04 ns |     538.042 ns |    38,358.53 ns |    37,988.42 ns |     39,967.41 ns |     889.14 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|   .NET Framework 4.8 |    39,031.25 ns |     918.560 ns |    38,738.98 ns |    37,921.52 ns |     41,440.16 ns |     910.05 |      List:WhereSelectTake |   5000 |     WhereSelectTake:005000 |   7.6904 |
|             .NET 6.0 |   119,817.56 ns |   1,661.452 ns |   119,446.92 ns |   117,097.99 ns |    122,324.63 ns |   2,766.80 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|             .NET 5.0 |   131,441.40 ns |   2,688.238 ns |   131,624.63 ns |   127,742.75 ns |    137,940.72 ns |   3,039.40 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|   .NET Framework 4.8 |   201,396.87 ns |   2,398.595 ns |   201,241.41 ns |   198,209.42 ns |    205,914.50 ns |   4,650.90 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
| .NET Framework 4.7.2 |   207,199.88 ns |   2,518.715 ns |   207,458.15 ns |   202,968.60 ns |    209,995.80 ns |   4,778.77 |      Linq:WhereSelectTake |   5000 |     WhereSelectTake:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        40.66 ns |       0.710 ns |        40.50 ns |        39.77 ns |         41.88 ns |       1.00 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |        43.68 ns |       0.655 ns |        43.71 ns |        42.54 ns |         44.72 ns |       1.07 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        93.08 ns |       0.610 ns |        93.24 ns |        91.51 ns |         93.96 ns |       2.29 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|   .NET Framework 4.8 |        94.03 ns |       1.842 ns |        93.64 ns |        92.00 ns |         97.73 ns |       2.31 |     Array:WhereSelectTake | 100000 |     WhereSelectTake:100000 |   0.0153 |
|             .NET 5.0 |   772,869.95 ns |  11,757.195 ns |   772,320.02 ns |   754,144.82 ns |    790,389.65 ns |  19,005.50 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 151.3672 |
|             .NET 6.0 |   779,898.54 ns |  10,822.454 ns |   781,295.02 ns |   761,080.37 ns |    793,384.96 ns |  19,177.22 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 149.4141 |
| .NET Framework 4.7.2 |   827,802.78 ns |   8,111.930 ns |   824,844.92 ns |   815,646.00 ns |    840,942.58 ns |  20,363.82 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 121.0938 |
|   .NET Framework 4.8 |   862,056.88 ns |  11,348.149 ns |   859,553.32 ns |   843,496.39 ns |    884,591.50 ns |  21,198.49 |      List:WhereSelectTake | 100000 |     WhereSelectTake:100000 | 120.1172 |
|             .NET 6.0 | 2,411,958.72 ns |  26,332.587 ns | 2,404,824.22 ns | 2,381,128.91 ns |  2,456,621.88 ns |  59,308.86 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|             .NET 5.0 | 2,637,869.02 ns |  89,415.189 ns | 2,608,839.45 ns | 2,525,856.25 ns |  2,807,477.34 ns |  65,606.80 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
| .NET Framework 4.7.2 | 3,973,169.20 ns |  69,970.414 ns | 3,952,362.11 ns | 3,887,192.19 ns |  4,105,493.75 ns |  97,738.72 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|   .NET Framework 4.8 | 3,978,305.20 ns |  37,747.212 ns | 3,969,841.80 ns | 3,921,023.05 ns |  4,067,265.23 ns |  97,706.89 |      Linq:WhereSelectTake | 100000 |     WhereSelectTake:100000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.13 ns |       1.396 ns |        42.79 ns |        41.50 ns |         46.86 ns |       1.00 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        48.22 ns |       0.556 ns |        48.08 ns |        47.39 ns |         49.15 ns |       1.11 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        89.33 ns |       1.285 ns |        89.15 ns |        87.09 ns |         92.16 ns |       2.05 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
| .NET Framework 4.7.2 |        92.77 ns |       1.507 ns |        92.34 ns |        90.64 ns |         95.24 ns |       2.14 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |        93.50 ns |       1.224 ns |        93.42 ns |        91.27 ns |         95.63 ns |       2.15 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0598 |
|   .NET Framework 4.8 |        94.95 ns |       2.011 ns |        94.57 ns |        92.81 ns |        100.12 ns |       2.19 | Array:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0153 |
|             .NET 6.0 |       130.90 ns |       5.449 ns |       128.49 ns |       124.70 ns |        143.60 ns |       3.07 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
|             .NET 5.0 |       137.15 ns |       1.639 ns |       137.11 ns |       134.83 ns |        140.30 ns |       3.16 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0751 |
| .NET Framework 4.7.2 |       167.26 ns |       2.099 ns |       168.03 ns |       163.97 ns |        170.42 ns |       3.85 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       167.47 ns |       2.482 ns |       166.21 ns |       164.39 ns |        172.67 ns |       3.85 |  List:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.0625 |
| .NET Framework 4.7.2 |       582.50 ns |       8.873 ns |       581.78 ns |       570.30 ns |        601.27 ns |      13.36 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
|   .NET Framework 4.8 |       585.88 ns |       7.118 ns |       583.83 ns |       575.68 ns |        600.41 ns |      13.51 |  Linq:WhereSelectTakeLast |      1 | WhereSelectTakeLast:000001 |   0.1268 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        42.94 ns |       0.782 ns |        42.73 ns |        41.94 ns |         44.35 ns |       0.96 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 6.0 |        44.88 ns |       0.487 ns |        44.84 ns |        44.14 ns |         45.75 ns |       1.00 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |        92.45 ns |       1.208 ns |        91.89 ns |        91.26 ns |         95.26 ns |       2.06 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |        94.04 ns |       1.262 ns |        93.79 ns |        92.67 ns |         97.44 ns |       2.10 | Array:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0153 |
|             .NET 5.0 |     1,051.65 ns |      43.840 ns |     1,030.04 ns |     1,004.34 ns |      1,142.75 ns |      23.88 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
|             .NET 6.0 |     1,198.17 ns |      15.873 ns |     1,191.81 ns |     1,177.71 ns |      1,225.92 ns |      26.72 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0782 |
|   .NET Framework 4.8 |     1,277.15 ns |      13.053 ns |     1,272.46 ns |     1,265.31 ns |      1,305.00 ns |      28.48 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     1,282.39 ns |      20.920 ns |     1,273.78 ns |     1,260.11 ns |      1,325.81 ns |      28.53 |  List:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     6,193.72 ns |     208.302 ns |     6,122.30 ns |     5,972.28 ns |      6,710.30 ns |     138.55 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1144 |
|             .NET 5.0 |     7,080.44 ns |     234.455 ns |     6,969.71 ns |     6,869.98 ns |      7,592.92 ns |     160.19 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1068 |
| .NET Framework 4.7.2 |    20,219.82 ns |     264.180 ns |    20,117.22 ns |    19,914.83 ns |     20,634.80 ns |     450.96 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|   .NET Framework 4.8 |    20,326.19 ns |     292.358 ns |    20,439.08 ns |    19,906.57 ns |     20,683.23 ns |     452.58 |  Linq:WhereSelectTakeLast |    250 | WhereSelectTakeLast:000250 |   0.1221 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        45.68 ns |       0.563 ns |        45.51 ns |        45.13 ns |         47.04 ns |       0.97 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |        47.81 ns |       1.422 ns |        47.10 ns |        46.26 ns |         51.10 ns |       1.00 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        92.74 ns |       1.396 ns |        92.37 ns |        91.22 ns |         95.94 ns |       1.97 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.38 ns |       1.333 ns |        93.51 ns |        91.76 ns |         95.94 ns |       1.98 | Array:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0153 |
|             .NET 6.0 |    17,634.39 ns |     751.103 ns |    17,243.69 ns |    16,847.92 ns |     19,144.14 ns |     370.24 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 5.0 |    17,991.03 ns |     610.414 ns |    17,838.74 ns |    17,269.12 ns |     19,596.47 ns |     376.44 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    21,514.93 ns |     256.157 ns |    21,430.60 ns |    21,242.51 ns |     22,093.48 ns |     456.11 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    21,846.59 ns |     693.882 ns |    21,503.10 ns |    21,235.00 ns |     23,828.37 ns |     459.21 |  List:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   121,796.62 ns |   1,933.801 ns |   121,047.31 ns |   119,724.17 ns |    126,807.93 ns |   2,581.85 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|             .NET 5.0 |   141,925.70 ns |   1,759.744 ns |   141,882.03 ns |   139,310.57 ns |    144,875.83 ns |   3,004.08 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   393,969.41 ns |   2,828.427 ns |   394,178.71 ns |   388,648.24 ns |    397,718.51 ns |   8,338.42 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|   .NET Framework 4.8 |   401,559.47 ns |  14,723.539 ns |   395,862.21 ns |   383,283.69 ns |    429,578.96 ns |   8,436.54 |  Linq:WhereSelectTakeLast |   5000 | WhereSelectTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        43.34 ns |       1.414 ns |        42.84 ns |        41.76 ns |         46.20 ns |       1.00 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        45.27 ns |       0.714 ns |        44.81 ns |        44.44 ns |         46.85 ns |       1.03 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        93.10 ns |       0.689 ns |        93.01 ns |        91.74 ns |         94.15 ns |       2.12 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        94.86 ns |       1.398 ns |        94.42 ns |        92.72 ns |         97.43 ns |       2.16 | Array:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |   0.0153 |
|             .NET 5.0 |   352,968.61 ns |   4,391.860 ns |   351,457.79 ns |   348,360.45 ns |    362,724.80 ns |   8,068.50 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 6.0 |   357,953.44 ns |   7,096.479 ns |   354,333.54 ns |   351,115.09 ns |    371,490.09 ns |   8,160.67 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 |   423,585.07 ns |   6,981.338 ns |   423,520.70 ns |   413,922.95 ns |    435,379.74 ns |   9,652.35 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   427,948.46 ns |   9,980.059 ns |   422,486.47 ns |   417,683.40 ns |    446,445.90 ns |   9,783.25 |  List:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 6.0 | 2,538,457.37 ns |  98,503.701 ns | 2,490,867.19 ns | 2,414,076.17 ns |  2,681,282.81 ns |  59,092.56 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|             .NET 5.0 | 2,605,726.50 ns |  22,579.892 ns | 2,611,202.34 ns | 2,563,344.53 ns |  2,635,047.27 ns |  59,497.12 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,878,205.17 ns |  60,069.907 ns | 7,861,351.56 ns | 7,822,979.69 ns |  8,015,864.06 ns | 179,887.64 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|   .NET Framework 4.8 | 7,892,160.62 ns |  89,566.809 ns | 7,880,584.38 ns | 7,748,468.75 ns |  8,041,867.19 ns | 179,888.47 |  Linq:WhereSelectTakeLast | 100000 | WhereSelectTakeLast:100000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        41.07 ns |       1.308 ns |        40.50 ns |        39.66 ns |         43.88 ns |       1.00 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 5.0 |        49.77 ns |       0.473 ns |        49.82 ns |        49.09 ns |         50.55 ns |       1.20 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
| .NET Framework 4.7.2 |        93.66 ns |       1.756 ns |        92.83 ns |        91.97 ns |         97.61 ns |       2.27 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|   .NET Framework 4.8 |        94.41 ns |       1.415 ns |        94.54 ns |        91.85 ns |         96.69 ns |       2.28 |           Array:WhereTake |      1 |           WhereTake:000001 |   0.0153 |
|             .NET 5.0 |       102.01 ns |       4.650 ns |       100.86 ns |        95.44 ns |        114.74 ns |       2.51 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 6.0 |       105.32 ns |       8.706 ns |       103.67 ns |        92.55 ns |        127.58 ns |       2.59 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0572 |
|             .NET 6.0 |       105.86 ns |       5.090 ns |       103.55 ns |        99.21 ns |        119.74 ns |       2.61 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0598 |
|             .NET 5.0 |       122.33 ns |       8.830 ns |       121.49 ns |       109.83 ns |        148.42 ns |       2.95 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0573 |
|   .NET Framework 4.8 |       165.01 ns |       2.801 ns |       165.25 ns |       161.21 ns |        170.56 ns |       3.99 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
| .NET Framework 4.7.2 |       171.88 ns |       6.961 ns |       168.75 ns |       163.73 ns |        187.93 ns |       4.21 |            List:WhereTake |      1 |           WhereTake:000001 |   0.0625 |
|   .NET Framework 4.8 |       271.35 ns |      12.276 ns |       269.96 ns |       254.43 ns |        301.60 ns |       6.59 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
| .NET Framework 4.7.2 |       282.35 ns |      19.722 ns |       278.94 ns |       256.54 ns |        343.71 ns |       6.96 |            Linq:WhereTake |      1 |           WhereTake:000001 |   0.0701 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        45.09 ns |       0.580 ns |        44.91 ns |        44.27 ns |         46.21 ns |       0.97 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 6.0 |        46.52 ns |       0.453 ns |        46.49 ns |        45.94 ns |         47.46 ns |       1.00 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
| .NET Framework 4.7.2 |        93.52 ns |       1.487 ns |        93.05 ns |        92.15 ns |         96.85 ns |       2.01 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|   .NET Framework 4.8 |        94.73 ns |       2.433 ns |        94.05 ns |        90.28 ns |        101.02 ns |       2.05 |           Array:WhereTake |    250 |           WhereTake:000250 |   0.0153 |
|             .NET 6.0 |     1,061.01 ns |      17.739 ns |     1,064.02 ns |     1,031.73 ns |      1,086.82 ns |      22.81 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
|             .NET 5.0 |     1,065.69 ns |      22.263 ns |     1,066.57 ns |     1,024.63 ns |      1,094.89 ns |      22.94 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2537 |
|   .NET Framework 4.8 |     1,291.02 ns |      18.201 ns |     1,291.05 ns |     1,268.10 ns |      1,321.32 ns |      27.75 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
| .NET Framework 4.7.2 |     1,314.58 ns |      18.341 ns |     1,320.35 ns |     1,279.58 ns |      1,341.03 ns |      28.28 |            List:WhereTake |    250 |           WhereTake:000250 |   0.2575 |
|             .NET 6.0 |     5,886.63 ns |      73.152 ns |     5,852.77 ns |     5,809.79 ns |      6,053.68 ns |     126.55 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
|             .NET 5.0 |     6,962.08 ns |     156.946 ns |     6,949.77 ns |     6,740.31 ns |      7,325.63 ns |     150.91 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0687 |
|   .NET Framework 4.8 |    10,873.60 ns |     491.774 ns |    10,725.69 ns |    10,181.67 ns |     11,940.21 ns |     246.40 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
| .NET Framework 4.7.2 |    10,918.06 ns |     510.574 ns |    10,745.62 ns |    10,218.77 ns |     12,424.64 ns |     229.55 |            Linq:WhereTake |    250 |           WhereTake:000250 |   0.0610 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        43.55 ns |       1.117 ns |        43.25 ns |        42.26 ns |         46.76 ns |       0.97 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 6.0 |        45.14 ns |       0.644 ns |        45.00 ns |        43.79 ns |         46.49 ns |       1.00 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
| .NET Framework 4.7.2 |        93.36 ns |       1.511 ns |        93.09 ns |        91.54 ns |         96.88 ns |       2.07 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|   .NET Framework 4.8 |        93.74 ns |       1.497 ns |        93.48 ns |        92.19 ns |         96.97 ns |       2.08 |           Array:WhereTake |   5000 |           WhereTake:005000 |   0.0153 |
|             .NET 5.0 |    18,228.64 ns |     249.832 ns |    18,249.06 ns |    17,934.69 ns |     18,743.99 ns |     403.50 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |    18,375.77 ns |     753.894 ns |    18,109.28 ns |    17,475.99 ns |     20,124.90 ns |     415.22 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|   .NET Framework 4.8 |    22,176.84 ns |     412.314 ns |    22,005.48 ns |    21,647.90 ns |     22,910.90 ns |     491.23 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
| .NET Framework 4.7.2 |    22,229.15 ns |     466.750 ns |    22,098.12 ns |    21,678.43 ns |     23,388.36 ns |     491.12 |            List:WhereTake |   5000 |           WhereTake:005000 |   3.8757 |
|             .NET 6.0 |   121,721.36 ns |   5,067.233 ns |   119,594.69 ns |   116,694.87 ns |    137,640.20 ns |   2,763.93 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|             .NET 5.0 |   133,427.25 ns |   3,896.938 ns |   131,902.33 ns |   128,281.84 ns |    142,657.15 ns |   2,939.61 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
| .NET Framework 4.7.2 |   209,742.36 ns |  10,875.666 ns |   205,876.54 ns |   197,046.78 ns |    239,225.73 ns |   4,825.92 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|   .NET Framework 4.8 |   213,842.36 ns |  14,077.444 ns |   208,918.37 ns |   196,865.36 ns |    255,630.18 ns |   4,993.11 |            Linq:WhereTake |   5000 |           WhereTake:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 5.0 |        42.98 ns |       0.894 ns |        43.10 ns |        41.24 ns |         44.24 ns |       0.87 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 6.0 |        48.01 ns |       3.571 ns |        47.97 ns |        41.50 ns |         56.60 ns |       1.00 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
| .NET Framework 4.7.2 |        95.03 ns |       3.903 ns |        93.40 ns |        91.16 ns |        105.31 ns |       2.05 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|   .NET Framework 4.8 |       101.85 ns |       6.663 ns |       101.24 ns |        92.82 ns |        120.06 ns |       2.14 |           Array:WhereTake | 100000 |           WhereTake:100000 |   0.0153 |
|             .NET 6.0 |   383,809.50 ns |   7,265.836 ns |   382,742.11 ns |   372,516.65 ns |    400,567.53 ns |   7,815.16 |            List:WhereTake | 100000 |           WhereTake:100000 |  80.0781 |
|             .NET 5.0 |   397,486.45 ns |   4,382.320 ns |   397,293.53 ns |   390,435.50 ns |    404,417.33 ns |   8,031.15 |            List:WhereTake | 100000 |           WhereTake:100000 |  80.0781 |
|   .NET Framework 4.8 |   467,443.16 ns |   9,027.541 ns |   464,507.52 ns |   452,741.50 ns |    487,420.46 ns |   9,519.92 |            List:WhereTake | 100000 |           WhereTake:100000 |  67.8711 |
| .NET Framework 4.7.2 |   469,479.02 ns |   7,494.408 ns |   468,384.28 ns |   460,703.42 ns |    482,301.56 ns |   9,520.86 |            List:WhereTake | 100000 |           WhereTake:100000 |  66.4063 |
|             .NET 6.0 | 2,364,333.18 ns |  36,307.513 ns | 2,352,418.75 ns | 2,311,740.62 ns |  2,431,113.67 ns |  47,931.52 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|             .NET 5.0 | 2,760,516.42 ns | 123,398.556 ns | 2,764,449.22 ns | 2,571,502.34 ns |  3,120,641.02 ns |  58,725.08 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|   .NET Framework 4.8 | 3,909,081.55 ns |  50,030.538 ns | 3,890,385.94 ns | 3,826,816.41 ns |  3,992,750.00 ns |  79,036.69 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
| .NET Framework 4.7.2 | 4,308,514.30 ns | 254,208.089 ns | 4,290,846.88 ns | 3,853,706.25 ns |  5,086,625.78 ns |  90,601.92 |            Linq:WhereTake | 100000 |           WhereTake:100000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        49.34 ns |       3.278 ns |        48.81 ns |        42.58 ns |         56.34 ns |       1.00 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        50.64 ns |       3.448 ns |        49.83 ns |        45.47 ns |         60.16 ns |       1.03 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |        87.17 ns |       1.043 ns |        87.17 ns |        85.46 ns |         88.74 ns |       1.91 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        90.56 ns |       1.524 ns |        90.33 ns |        88.07 ns |         93.13 ns |       1.96 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0598 |
|             .NET 6.0 |        98.59 ns |       6.572 ns |        96.03 ns |        90.33 ns |        115.42 ns |       2.01 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
|   .NET Framework 4.8 |       107.46 ns |       6.612 ns |       106.54 ns |        95.31 ns |        125.06 ns |       2.19 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
| .NET Framework 4.7.2 |       112.99 ns |      10.513 ns |       112.27 ns |        96.26 ns |        143.80 ns |       2.31 |       Array:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0153 |
|             .NET 5.0 |       113.15 ns |       4.047 ns |       111.42 ns |       108.67 ns |        124.68 ns |       2.35 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0573 |
| .NET Framework 4.7.2 |       170.98 ns |       5.528 ns |       169.62 ns |       163.37 ns |        185.94 ns |       3.56 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       179.13 ns |      15.956 ns |       174.54 ns |       160.69 ns |        225.11 ns |       3.66 |        List:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.0625 |
|   .NET Framework 4.8 |       532.70 ns |      16.363 ns |       528.54 ns |       511.16 ns |        576.31 ns |      11.08 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
| .NET Framework 4.7.2 |       546.06 ns |      28.817 ns |       533.52 ns |       513.89 ns |        620.87 ns |      11.16 |        Linq:WhereTakeLast |      1 |       WhereTakeLast:000001 |   0.1078 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        45.00 ns |       4.877 ns |        43.58 ns |        39.20 ns |         58.21 ns |       1.00 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 5.0 |        52.23 ns |       2.809 ns |        51.92 ns |        48.04 ns |         59.71 ns |       1.20 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
| .NET Framework 4.7.2 |       102.53 ns |       6.386 ns |       102.64 ns |        91.58 ns |        119.32 ns |       2.30 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|   .NET Framework 4.8 |       106.56 ns |       6.814 ns |       105.26 ns |        94.45 ns |        125.24 ns |       2.40 |       Array:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0153 |
|             .NET 6.0 |       986.74 ns |      10.327 ns |       986.69 ns |       968.34 ns |      1,006.98 ns |      23.41 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|             .NET 5.0 |     1,018.68 ns |      21.473 ns |     1,016.55 ns |       986.34 ns |      1,052.44 ns |      24.27 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0782 |
|   .NET Framework 4.8 |     1,265.12 ns |      15.958 ns |     1,268.52 ns |     1,236.06 ns |      1,289.52 ns |      29.98 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
| .NET Framework 4.7.2 |     1,279.85 ns |      21.129 ns |     1,272.47 ns |     1,255.30 ns |      1,332.19 ns |      30.36 |        List:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0801 |
|             .NET 6.0 |     6,445.14 ns |      75.090 ns |     6,429.53 ns |     6,317.83 ns |      6,574.93 ns |     152.89 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0992 |
|             .NET 5.0 |     6,992.88 ns |     310.994 ns |     6,899.34 ns |     6,608.43 ns |      7,942.50 ns |     162.58 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|   .NET Framework 4.8 |    20,936.07 ns |     819.212 ns |    20,553.88 ns |    19,783.75 ns |     22,844.31 ns |     480.04 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
| .NET Framework 4.7.2 |    21,767.66 ns |   1,333.787 ns |    21,536.20 ns |    20,066.83 ns |     25,549.26 ns |     488.92 |        Linq:WhereTakeLast |    250 |       WhereTakeLast:000250 |   0.0916 |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        50.01 ns |       3.735 ns |        49.84 ns |        43.46 ns |         59.93 ns |       1.00 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 5.0 |        50.33 ns |       4.186 ns |        50.00 ns |        44.72 ns |         61.70 ns |       1.01 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|   .NET Framework 4.8 |        99.87 ns |       3.748 ns |        99.06 ns |        92.78 ns |        107.29 ns |       2.08 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
| .NET Framework 4.7.2 |       101.10 ns |       6.073 ns |       100.83 ns |        89.96 ns |        117.99 ns |       2.03 |       Array:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0153 |
|             .NET 6.0 |    17,974.12 ns |     661.811 ns |    17,745.13 ns |    17,043.36 ns |     19,622.02 ns |     373.87 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 5.0 |    18,063.40 ns |     797.049 ns |    17,865.41 ns |    16,875.66 ns |     19,734.52 ns |     368.43 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
| .NET Framework 4.7.2 |    21,030.10 ns |     237.740 ns |    20,998.14 ns |    20,675.84 ns |     21,511.94 ns |     427.90 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|   .NET Framework 4.8 |    21,287.26 ns |     454.909 ns |    21,198.49 ns |    20,686.14 ns |     22,073.89 ns |     437.86 |        List:WhereTakeLast |   5000 |       WhereTakeLast:005000 |   0.0610 |
|             .NET 6.0 |   120,442.40 ns |   6,606.474 ns |   119,049.63 ns |   111,767.97 ns |    140,059.52 ns |   2,427.49 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|             .NET 5.0 |   135,350.92 ns |   6,087.413 ns |   135,014.75 ns |   126,330.88 ns |    148,262.67 ns |   2,751.60 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|   .NET Framework 4.8 |   391,580.95 ns |  11,552.265 ns |   387,390.43 ns |   377,288.92 ns |    425,767.24 ns |   8,313.43 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
| .NET Framework 4.7.2 |   402,259.81 ns |  20,818.669 ns |   395,068.90 ns |   376,640.53 ns |    454,078.08 ns |   8,127.23 |        Linq:WhereTakeLast |   5000 |       WhereTakeLast:005000 |        - |
|                      |                 |                |                 |                 |                  |            |                           |        |                            |          |
|             .NET 6.0 |        46.63 ns |       3.387 ns |        46.20 ns |        40.61 ns |         56.84 ns |       1.00 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 5.0 |        47.93 ns |       2.682 ns |        47.67 ns |        43.85 ns |         53.88 ns |       1.03 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|   .NET Framework 4.8 |        94.93 ns |       3.159 ns |        94.01 ns |        91.17 ns |        103.10 ns |       2.06 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
| .NET Framework 4.7.2 |        95.77 ns |       3.768 ns |        94.55 ns |        91.57 ns |        105.30 ns |       2.08 |       Array:WhereTakeLast | 100000 |       WhereTakeLast:100000 |   0.0153 |
|             .NET 6.0 |   343,119.34 ns |   8,050.440 ns |   342,265.75 ns |   331,850.49 ns |    360,772.51 ns |   7,565.13 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 5.0 |   355,133.85 ns |   6,561.627 ns |   355,175.83 ns |   344,683.59 ns |    366,679.25 ns |   7,687.36 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 |   423,734.14 ns |   9,557.424 ns |   418,993.46 ns |   414,415.92 ns |    449,029.93 ns |   9,373.11 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 |   425,196.04 ns |  12,784.448 ns |   421,196.02 ns |   409,186.57 ns |    457,706.45 ns |   9,293.89 |        List:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 6.0 | 2,497,124.63 ns |  92,341.003 ns | 2,474,016.80 ns | 2,388,153.12 ns |  2,717,443.75 ns |  54,204.35 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|             .NET 5.0 | 2,982,114.42 ns | 143,375.729 ns | 2,976,571.48 ns | 2,695,933.98 ns |  3,239,795.70 ns |  63,087.19 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
| .NET Framework 4.7.2 | 7,863,005.83 ns | 215,975.144 ns | 7,837,032.81 ns | 7,601,748.44 ns |  8,346,531.25 ns | 173,132.68 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
|   .NET Framework 4.8 | 8,790,497.49 ns | 577,900.786 ns | 8,658,064.06 ns | 7,985,176.56 ns | 10,252,192.19 ns | 189,293.21 |        Linq:WhereTakeLast | 100000 |       WhereTakeLast:100000 |        - |
