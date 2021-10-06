# Benchmark Run at 10/6/2021 10:47:04 AM


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
  Job-XJZUCR : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-CBRBYL : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

Platform=X64  

```

|            Runtime |                Categories |            Mean |         StdDev |          Median |             Min |             Max |     Ratio |   Size |
|------------------- |-------------------------- |----------------:|---------------:|----------------:|----------------:|----------------:|----------:|------- |
|           .NET 6.0 |              Select,Array |        55.26 ns |       2.763 ns |        54.66 ns |        50.66 ns |        60.91 ns |      0.55 |      1 |
| .NET Framework 4.8 |              Select,Array |       103.53 ns |       2.131 ns |       103.79 ns |       100.40 ns |       108.94 ns |      1.00 |      1 |
|           .NET 6.0 |               Select,List |       111.77 ns |       9.550 ns |       109.26 ns |       100.34 ns |       137.97 ns |      1.09 |      1 |
| .NET Framework 4.8 |               Select,List |       156.11 ns |       5.690 ns |       157.30 ns |       147.25 ns |       167.60 ns |      1.52 |      1 |
|           .NET 6.0 |               Select,Linq |     5,017.61 ns |      49.504 ns |     5,014.86 ns |     4,916.99 ns |     5,108.53 ns |     48.43 |      1 |
| .NET Framework 4.8 |               Select,Linq |     7,039.03 ns |     256.094 ns |     6,944.60 ns |     6,768.34 ns |     7,844.71 ns |     67.57 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |              Select,Array |        47.78 ns |       1.722 ns |        47.96 ns |        44.65 ns |        51.12 ns |      0.46 | 100000 |
| .NET Framework 4.8 |              Select,Array |       103.30 ns |       2.955 ns |       102.87 ns |        99.65 ns |       111.17 ns |      1.00 | 100000 |
|           .NET 6.0 |               Select,Linq | 1,944,764.65 ns |  53,317.727 ns | 1,940,442.77 ns | 1,872,140.82 ns | 2,059,768.95 ns | 18,842.87 | 100000 |
| .NET Framework 4.8 |               Select,Linq | 2,649,931.94 ns |  43,682.838 ns | 2,640,446.88 ns | 2,577,298.44 ns | 2,749,858.59 ns | 25,527.17 | 100000 |
| .NET Framework 4.8 |               Select,List | 3,504,838.85 ns | 132,992.800 ns | 3,470,274.61 ns | 3,301,396.88 ns | 3,800,281.25 ns | 34,389.48 | 100000 |
|           .NET 6.0 |               Select,List | 4,422,384.69 ns | 213,160.563 ns | 4,420,176.56 ns | 3,921,299.61 ns | 4,891,828.91 ns | 42,918.36 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |              Select,Array |        43.18 ns |       1.747 ns |        43.10 ns |        40.65 ns |        47.68 ns |      0.40 |    250 |
| .NET Framework 4.8 |              Select,Array |       103.96 ns |       9.268 ns |       104.89 ns |        89.74 ns |       131.06 ns |      1.00 |    250 |
|           .NET 6.0 |               Select,Linq |     5,010.40 ns |     100.865 ns |     5,004.62 ns |     4,868.39 ns |     5,287.87 ns |     46.24 |    250 |
|           .NET 6.0 |               Select,List |     6,766.83 ns |     188.838 ns |     6,766.71 ns |     6,518.74 ns |     7,200.61 ns |     62.40 |    250 |
| .NET Framework 4.8 |               Select,Linq |     6,771.99 ns |     160.242 ns |     6,677.46 ns |     6,601.97 ns |     7,031.04 ns |     62.44 |    250 |
| .NET Framework 4.8 |               Select,List |     7,287.49 ns |     139.750 ns |     7,275.15 ns |     7,061.81 ns |     7,552.50 ns |     67.25 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |              Select,Array |        50.65 ns |       2.703 ns |        49.88 ns |        47.06 ns |        57.81 ns |      0.55 |   5000 |
| .NET Framework 4.8 |              Select,Array |        93.92 ns |       3.416 ns |        93.58 ns |        88.39 ns |       102.57 ns |      1.00 |   5000 |
|           .NET 6.0 |               Select,Linq |    98,042.63 ns |   5,141.302 ns |    95,855.93 ns |    92,601.23 ns |   112,601.75 ns |  1,043.32 |   5000 |
| .NET Framework 4.8 |               Select,Linq |   130,903.49 ns |   1,496.565 ns |   130,392.29 ns |   129,678.30 ns |   135,565.50 ns |  1,402.31 |   5000 |
|           .NET 6.0 |               Select,List |   223,868.74 ns |   7,409.386 ns |   222,698.83 ns |   214,222.63 ns |   255,517.46 ns |  2,385.18 |   5000 |
| .NET Framework 4.8 |               Select,List |   227,528.19 ns |  11,582.305 ns |   222,070.61 ns |   216,961.47 ns |   266,366.02 ns |  2,444.24 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |          SelectTake,Array |        43.15 ns |       3.073 ns |        42.30 ns |        39.57 ns |        52.74 ns |      0.46 |      1 |
|           .NET 6.0 |           SelectTake,Linq |        87.92 ns |       2.227 ns |        87.09 ns |        85.01 ns |        92.89 ns |      0.92 |      1 |
|           .NET 6.0 |           SelectTake,List |        89.16 ns |       9.592 ns |        88.87 ns |        76.10 ns |       116.92 ns |      0.91 |      1 |
| .NET Framework 4.8 |          SelectTake,Array |        95.45 ns |       4.323 ns |        94.86 ns |        89.00 ns |       108.76 ns |      1.00 |      1 |
| .NET Framework 4.8 |           SelectTake,List |       158.14 ns |       5.318 ns |       159.09 ns |       149.66 ns |       170.78 ns |      1.65 |      1 |
| .NET Framework 4.8 |           SelectTake,Linq |       250.97 ns |       7.015 ns |       249.95 ns |       241.28 ns |       267.38 ns |      2.63 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |          SelectTake,Array |        40.93 ns |       1.801 ns |        40.30 ns |        38.82 ns |        46.49 ns |      0.42 | 100000 |
| .NET Framework 4.8 |          SelectTake,Array |        96.44 ns |       4.204 ns |        95.30 ns |        91.83 ns |       108.68 ns |      1.00 | 100000 |
|           .NET 6.0 |           SelectTake,Linq |   408,647.82 ns |   7,582.850 ns |   407,412.84 ns |   396,782.62 ns |   425,985.50 ns |  4,318.64 | 100000 |
| .NET Framework 4.8 |           SelectTake,List |   662,037.43 ns |  30,904.933 ns |   652,997.66 ns |   636,082.37 ns |   763,275.73 ns |  6,873.93 | 100000 |
|           .NET 6.0 |           SelectTake,List |   842,456.30 ns |  86,271.608 ns |   834,269.87 ns |   648,698.39 ns | 1,105,647.31 ns |  8,723.09 | 100000 |
| .NET Framework 4.8 |           SelectTake,Linq |   964,541.34 ns |  48,045.449 ns |   936,516.02 ns |   914,226.17 ns | 1,091,195.80 ns |  9,999.05 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |          SelectTake,Array |        43.76 ns |       2.534 ns |        43.43 ns |        40.11 ns |        50.41 ns |      0.45 |    250 |
| .NET Framework 4.8 |          SelectTake,Array |        97.32 ns |       4.787 ns |        96.26 ns |        90.79 ns |       111.51 ns |      1.00 |    250 |
|           .NET 6.0 |           SelectTake,Linq |     1,215.46 ns |      45.241 ns |     1,199.83 ns |     1,166.19 ns |     1,336.21 ns |     12.52 |    250 |
|           .NET 6.0 |           SelectTake,List |     1,537.17 ns |      49.044 ns |     1,515.35 ns |     1,481.55 ns |     1,666.57 ns |     15.79 |    250 |
| .NET Framework 4.8 |           SelectTake,List |     1,711.73 ns |      32.487 ns |     1,706.37 ns |     1,669.35 ns |     1,791.55 ns |     17.74 |    250 |
| .NET Framework 4.8 |           SelectTake,Linq |     2,597.08 ns |      38.219 ns |     2,600.36 ns |     2,545.04 ns |     2,685.86 ns |     27.07 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |          SelectTake,Array |        51.50 ns |       3.903 ns |        50.80 ns |        47.06 ns |        63.24 ns |      0.59 |   5000 |
| .NET Framework 4.8 |          SelectTake,Array |        93.07 ns |       1.660 ns |        92.62 ns |        89.75 ns |        96.83 ns |      1.00 |   5000 |
|           .NET 6.0 |           SelectTake,Linq |    21,459.69 ns |   1,138.141 ns |    20,886.31 ns |    20,080.67 ns |    23,734.58 ns |    235.33 |   5000 |
|           .NET 6.0 |           SelectTake,List |    25,258.84 ns |     422.213 ns |    25,164.12 ns |    24,710.79 ns |    26,172.89 ns |    270.57 |   5000 |
| .NET Framework 4.8 |           SelectTake,List |    28,024.11 ns |     330.927 ns |    27,954.02 ns |    27,671.48 ns |    28,742.61 ns |    299.90 |   5000 |
| .NET Framework 4.8 |           SelectTake,Linq |    46,965.81 ns |     400.058 ns |    46,895.11 ns |    46,610.72 ns |    48,031.92 ns |    503.32 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |        42.03 ns |       0.725 ns |        42.10 ns |        40.79 ns |        43.40 ns |      0.60 |      1 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        70.30 ns |       2.126 ns |        70.96 ns |        66.77 ns |        75.89 ns |      1.00 |      1 |
|           .NET 6.0 |       SelectTakeLast,List |        79.81 ns |       2.838 ns |        78.53 ns |        76.62 ns |        86.62 ns |      1.14 |      1 |
|           .NET 6.0 |       SelectTakeLast,Linq |        89.27 ns |       4.674 ns |        86.95 ns |        83.76 ns |       101.66 ns |      1.28 |      1 |
| .NET Framework 4.8 |       SelectTakeLast,List |       156.94 ns |       4.683 ns |       154.56 ns |       151.21 ns |       166.51 ns |      2.23 |      1 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |       472.17 ns |      22.440 ns |       472.81 ns |       442.74 ns |       527.55 ns |      6.72 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |        39.15 ns |       0.709 ns |        38.97 ns |        38.08 ns |        40.81 ns |      0.57 | 100000 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        69.45 ns |       3.618 ns |        68.27 ns |        65.04 ns |        79.32 ns |      1.00 | 100000 |
| .NET Framework 4.8 |       SelectTakeLast,List |   644,463.33 ns |   9,231.907 ns |   643,691.02 ns |   631,754.88 ns |   658,518.95 ns |  9,281.57 | 100000 |
|           .NET 6.0 |       SelectTakeLast,Linq |   661,539.10 ns |  31,078.830 ns |   651,758.98 ns |   625,083.20 ns |   741,374.41 ns |  9,503.01 | 100000 |
|           .NET 6.0 |       SelectTakeLast,List |   710,626.73 ns |  40,611.940 ns |   706,967.72 ns |   626,466.11 ns |   813,035.94 ns | 10,306.57 | 100000 |
| .NET Framework 4.8 |       SelectTakeLast,Linq | 3,282,781.19 ns | 161,199.714 ns | 3,225,146.09 ns | 3,104,128.52 ns | 3,749,654.30 ns | 47,352.61 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |        38.62 ns |       0.423 ns |        38.60 ns |        37.81 ns |        39.48 ns |      0.57 |    250 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        68.17 ns |       1.742 ns |        67.33 ns |        66.37 ns |        72.19 ns |      1.00 |    250 |
|           .NET 6.0 |       SelectTakeLast,List |     1,510.09 ns |      43.634 ns |     1,494.56 ns |     1,444.53 ns |     1,625.72 ns |     22.20 |    250 |
| .NET Framework 4.8 |       SelectTakeLast,List |     1,860.39 ns |     172.761 ns |     1,811.86 ns |     1,693.58 ns |     2,467.29 ns |     29.47 |    250 |
|           .NET 6.0 |       SelectTakeLast,Linq |     1,924.86 ns |      54.770 ns |     1,905.61 ns |     1,857.90 ns |     2,069.77 ns |     28.32 |    250 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |     9,373.67 ns |     794.056 ns |     9,307.05 ns |     8,107.68 ns |    11,480.40 ns |    135.32 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |        39.15 ns |       3.429 ns |        38.02 ns |        35.31 ns |        48.72 ns |      0.58 |   5000 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        67.29 ns |       2.348 ns |        66.79 ns |        64.43 ns |        74.67 ns |      1.00 |   5000 |
|           .NET 6.0 |       SelectTakeLast,List |    25,721.16 ns |     548.298 ns |    25,592.65 ns |    25,023.23 ns |    26,622.28 ns |    382.78 |   5000 |
| .NET Framework 4.8 |       SelectTakeLast,List |    28,109.67 ns |     628.715 ns |    27,906.77 ns |    27,390.55 ns |    30,093.33 ns |    414.81 |   5000 |
|           .NET 6.0 |       SelectTakeLast,Linq |    34,327.69 ns |   1,729.788 ns |    33,781.27 ns |    32,262.72 ns |    39,597.47 ns |    520.61 |   5000 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |   153,248.15 ns |   1,029.493 ns |   152,939.64 ns |   151,666.43 ns |   154,811.89 ns |  2,278.11 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |                Take,Array |        53.39 ns |       1.770 ns |        52.59 ns |        51.22 ns |        57.58 ns |      0.33 |      1 |
|           .NET 6.0 |                 Take,Linq |        65.95 ns |       3.770 ns |        65.32 ns |        61.14 ns |        74.81 ns |      0.41 |      1 |
|           .NET 6.0 |                 Take,List |        79.64 ns |       1.199 ns |        79.09 ns |        78.32 ns |        81.86 ns |      0.54 |      1 |
| .NET Framework 4.8 |                 Take,List |       161.56 ns |      21.707 ns |       151.24 ns |       140.79 ns |       224.07 ns |      1.00 |      1 |
| .NET Framework 4.8 |                Take,Array |       216.15 ns |       7.816 ns |       215.28 ns |       205.06 ns |       232.27 ns |      1.31 |      1 |
| .NET Framework 4.8 |                 Take,Linq |       223.44 ns |       7.897 ns |       223.99 ns |       210.03 ns |       243.90 ns |      1.36 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |                Take,Array |        54.45 ns |       1.021 ns |        54.28 ns |        52.94 ns |        56.78 ns |      0.26 | 100000 |
| .NET Framework 4.8 |                Take,Array |       209.97 ns |       5.571 ns |       207.77 ns |       203.76 ns |       224.58 ns |      1.00 | 100000 |
|           .NET 6.0 |                 Take,Linq |   340,049.50 ns |  17,368.104 ns |   337,849.49 ns |   315,353.17 ns |   395,147.36 ns |  1,607.62 | 100000 |
| .NET Framework 4.8 |                 Take,List |   573,696.24 ns |   8,023.920 ns |   572,963.77 ns |   562,641.21 ns |   585,799.90 ns |  2,717.29 | 100000 |
| .NET Framework 4.8 |                 Take,Linq |   617,459.61 ns |  17,905.626 ns |   614,428.91 ns |   588,346.58 ns |   652,550.78 ns |  2,942.65 | 100000 |
|           .NET 6.0 |                 Take,List |   969,557.04 ns |  74,631.632 ns |   956,720.46 ns |   826,046.78 ns | 1,177,784.57 ns |  4,579.44 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |                Take,Array |        51.55 ns |       2.154 ns |        50.88 ns |        48.23 ns |        56.81 ns |      0.25 |    250 |
| .NET Framework 4.8 |                Take,Array |       206.18 ns |       4.613 ns |       204.54 ns |       200.17 ns |       215.42 ns |      1.00 |    250 |
|           .NET 6.0 |                 Take,Linq |       968.21 ns |      36.135 ns |       965.93 ns |       909.15 ns |     1,032.65 ns |      4.70 |    250 |
|           .NET 6.0 |                 Take,List |     1,313.54 ns |      35.488 ns |     1,307.14 ns |     1,265.43 ns |     1,387.83 ns |      6.41 |    250 |
| .NET Framework 4.8 |                 Take,List |     1,450.00 ns |      16.557 ns |     1,444.29 ns |     1,430.90 ns |     1,477.56 ns |      7.02 |    250 |
| .NET Framework 4.8 |                 Take,Linq |     1,867.32 ns |      66.340 ns |     1,839.13 ns |     1,784.66 ns |     2,043.06 ns |      9.16 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |                Take,Array |        52.30 ns |       1.409 ns |        52.04 ns |        50.48 ns |        56.56 ns |      0.24 |   5000 |
| .NET Framework 4.8 |                Take,Array |       215.36 ns |      12.578 ns |       209.82 ns |       201.03 ns |       247.05 ns |      1.00 |   5000 |
|           .NET 6.0 |                 Take,Linq |    16,589.74 ns |     510.464 ns |    16,480.04 ns |    15,830.13 ns |    18,007.83 ns |     76.21 |   5000 |
|           .NET 6.0 |                 Take,List |    22,328.36 ns |     851.940 ns |    22,140.02 ns |    20,910.45 ns |    24,509.23 ns |    101.92 |   5000 |
| .NET Framework 4.8 |                 Take,List |    26,090.61 ns |   1,003.930 ns |    25,964.04 ns |    24,551.01 ns |    28,488.47 ns |    119.25 |   5000 |
| .NET Framework 4.8 |                 Take,Linq |    31,392.62 ns |     720.680 ns |    31,265.91 ns |    30,157.48 ns |    32,853.94 ns |    144.81 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |            TakeLast,Array |        40.83 ns |       1.870 ns |        40.87 ns |        38.19 ns |        46.01 ns |      0.42 |      1 |
|           .NET 6.0 |             TakeLast,Linq |        61.18 ns |       0.500 ns |        61.11 ns |        60.22 ns |        62.22 ns |      0.63 |      1 |
|           .NET 6.0 |             TakeLast,List |        80.31 ns |       4.021 ns |        78.63 ns |        75.57 ns |        91.43 ns |      0.84 |      1 |
| .NET Framework 4.8 |            TakeLast,Array |        97.53 ns |       3.597 ns |        98.03 ns |        92.49 ns |       106.85 ns |      1.00 |      1 |
| .NET Framework 4.8 |             TakeLast,List |       160.17 ns |      12.951 ns |       160.59 ns |       139.42 ns |       199.36 ns |      1.69 |      1 |
| .NET Framework 4.8 |             TakeLast,Linq |       331.03 ns |      15.782 ns |       327.73 ns |       303.59 ns |       369.20 ns |      3.41 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |            TakeLast,Array |        44.03 ns |       2.408 ns |        44.08 ns |        40.37 ns |        49.84 ns |      0.46 | 100000 |
| .NET Framework 4.8 |            TakeLast,Array |        94.88 ns |       3.459 ns |        94.78 ns |        90.27 ns |       103.42 ns |      1.00 | 100000 |
|           .NET 6.0 |             TakeLast,Linq |   528,589.46 ns |   3,536.459 ns |   528,697.80 ns |   524,463.13 ns |   535,900.63 ns |  5,550.02 | 100000 |
| .NET Framework 4.8 |             TakeLast,List |   536,973.64 ns |   6,445.785 ns |   537,066.16 ns |   525,240.23 ns |   547,002.54 ns |  5,634.09 | 100000 |
| .NET Framework 4.8 |             TakeLast,Linq |   792,958.42 ns |  15,588.683 ns |   785,817.19 ns |   773,140.23 ns |   835,992.19 ns |  8,373.67 | 100000 |
|           .NET 6.0 |             TakeLast,List | 1,085,622.79 ns |  75,799.789 ns | 1,089,313.33 ns |   895,784.91 ns | 1,257,822.02 ns | 11,701.96 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |            TakeLast,Array |        43.13 ns |       0.584 ns |        43.07 ns |        42.03 ns |        43.93 ns |      0.46 |    250 |
| .NET Framework 4.8 |            TakeLast,Array |        92.99 ns |       3.182 ns |        91.18 ns |        89.48 ns |        99.37 ns |      1.00 |    250 |
|           .NET 6.0 |             TakeLast,List |     1,253.66 ns |       8.547 ns |     1,255.35 ns |     1,237.82 ns |     1,262.66 ns |     13.37 |    250 |
| .NET Framework 4.8 |             TakeLast,List |     1,411.53 ns |      22.057 ns |     1,406.53 ns |     1,385.48 ns |     1,472.36 ns |     15.19 |    250 |
|           .NET 6.0 |             TakeLast,Linq |     1,562.23 ns |      38.659 ns |     1,553.84 ns |     1,498.34 ns |     1,653.35 ns |     16.90 |    250 |
| .NET Framework 4.8 |             TakeLast,Linq |     2,270.09 ns |      77.496 ns |     2,237.75 ns |     2,159.12 ns |     2,441.47 ns |     24.44 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |            TakeLast,Array |        41.39 ns |       1.715 ns |        40.40 ns |        39.47 ns |        45.60 ns |      0.48 |   5000 |
| .NET Framework 4.8 |            TakeLast,Array |        89.58 ns |       1.348 ns |        89.57 ns |        87.26 ns |        92.55 ns |      1.00 |   5000 |
|           .NET 6.0 |             TakeLast,List |    20,933.49 ns |     463.960 ns |    20,917.60 ns |    20,260.35 ns |    21,546.53 ns |    234.32 |   5000 |
| .NET Framework 4.8 |             TakeLast,List |    23,206.65 ns |     530.222 ns |    22,999.19 ns |    22,492.98 ns |    24,126.70 ns |    258.90 |   5000 |
|           .NET 6.0 |             TakeLast,Linq |    26,736.55 ns |     298.728 ns |    26,673.99 ns |    26,391.23 ns |    27,421.43 ns |    298.39 |   5000 |
| .NET Framework 4.8 |             TakeLast,Linq |    35,028.51 ns |     537.528 ns |    35,048.31 ns |    34,024.38 ns |    36,125.06 ns |    390.75 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |               Where,Array |        41.25 ns |       1.826 ns |        40.58 ns |        39.02 ns |        45.72 ns |      0.43 |      1 |
| .NET Framework 4.8 |               Where,Array |        95.25 ns |       4.370 ns |        95.05 ns |        87.94 ns |       107.77 ns |      1.00 |      1 |
|           .NET 6.0 |                Where,List |       122.49 ns |       2.693 ns |       121.85 ns |       118.07 ns |       127.97 ns |      1.32 |      1 |
|           .NET 6.0 |                Where,Linq |       124.14 ns |       0.943 ns |       124.13 ns |       122.20 ns |       126.13 ns |      1.33 |      1 |
| .NET Framework 4.8 |                Where,List |       177.32 ns |       5.177 ns |       174.73 ns |       170.72 ns |       187.87 ns |      1.91 |      1 |
| .NET Framework 4.8 |                Where,Linq |       263.16 ns |       6.670 ns |       260.22 ns |       255.02 ns |       274.58 ns |      2.82 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |               Where,Array |        45.45 ns |       5.724 ns |        43.65 ns |        38.83 ns |        61.48 ns |      0.44 | 100000 |
| .NET Framework 4.8 |               Where,Array |        94.19 ns |       1.738 ns |        93.52 ns |        92.15 ns |        97.95 ns |      1.00 | 100000 |
|           .NET 6.0 |                Where,List | 3,206,846.21 ns |  51,015.004 ns | 3,217,072.66 ns | 3,110,433.20 ns | 3,301,904.30 ns | 34,101.13 | 100000 |
|           .NET 6.0 |                Where,Linq | 3,711,566.95 ns |  47,590.060 ns | 3,690,703.12 ns | 3,662,495.31 ns | 3,808,406.64 ns | 39,470.77 | 100000 |
| .NET Framework 4.8 |                Where,List | 3,849,602.51 ns |  40,972.351 ns | 3,846,489.06 ns | 3,770,104.69 ns | 3,919,428.91 ns | 40,999.46 | 100000 |
| .NET Framework 4.8 |                Where,Linq | 4,731,131.19 ns |  51,117.251 ns | 4,730,010.16 ns | 4,613,778.12 ns | 4,826,051.56 ns | 50,382.86 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |               Where,Array |        41.47 ns |       1.902 ns |        40.60 ns |        39.52 ns |        46.29 ns |      0.46 |    250 |
| .NET Framework 4.8 |               Where,Array |        93.73 ns |       2.469 ns |        92.73 ns |        89.45 ns |        97.71 ns |      1.00 |    250 |
|           .NET 6.0 |                Where,List |     7,170.08 ns |      85.473 ns |     7,176.14 ns |     6,990.79 ns |     7,296.11 ns |     76.34 |    250 |
|           .NET 6.0 |                Where,Linq |     9,068.41 ns |      70.437 ns |     9,048.65 ns |     8,957.57 ns |     9,178.96 ns |     96.29 |    250 |
| .NET Framework 4.8 |                Where,List |     9,574.33 ns |     293.232 ns |     9,478.36 ns |     9,200.02 ns |    10,312.32 ns |    102.81 |    250 |
| .NET Framework 4.8 |                Where,Linq |    12,517.89 ns |     258.909 ns |    12,399.89 ns |    12,207.21 ns |    12,997.41 ns |    133.41 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |               Where,Array |        42.37 ns |       0.832 ns |        42.17 ns |        41.32 ns |        44.19 ns |      0.45 |   5000 |
| .NET Framework 4.8 |               Where,Array |        93.58 ns |       2.829 ns |        92.58 ns |        89.76 ns |       100.06 ns |      1.00 |   5000 |
|           .NET 6.0 |                Where,List |   169,671.82 ns |   5,223.281 ns |   167,254.17 ns |   164,052.81 ns |   183,218.33 ns |  1,822.44 |   5000 |
|           .NET 6.0 |                Where,Linq |   194,853.28 ns |  15,528.726 ns |   191,258.47 ns |   176,273.93 ns |   245,781.71 ns |  2,040.18 |   5000 |
| .NET Framework 4.8 |                Where,List |   214,343.93 ns |   2,619.001 ns |   213,739.86 ns |   210,888.07 ns |   221,983.09 ns |  2,271.85 |   5000 |
| .NET Framework 4.8 |                Where,Linq |   247,787.25 ns |   6,040.402 ns |   244,291.19 ns |   240,337.94 ns |   259,439.09 ns |  2,637.59 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |         WhereSelect,Array |        49.52 ns |       2.125 ns |        48.67 ns |        46.94 ns |        54.85 ns |      0.51 |      1 |
| .NET Framework 4.8 |         WhereSelect,Array |        96.82 ns |       3.921 ns |        95.74 ns |        91.53 ns |       106.35 ns |      1.00 |      1 |
|           .NET 6.0 |          WhereSelect,List |       124.68 ns |       1.341 ns |       124.70 ns |       121.94 ns |       126.64 ns |      1.28 |      1 |
|           .NET 6.0 |          WhereSelect,Linq |       170.44 ns |       7.023 ns |       168.92 ns |       161.02 ns |       188.90 ns |      1.76 |      1 |
| .NET Framework 4.8 |          WhereSelect,List |       181.00 ns |       3.818 ns |       179.26 ns |       176.00 ns |       187.95 ns |      1.86 |      1 |
| .NET Framework 4.8 |          WhereSelect,Linq |       343.67 ns |      36.087 ns |       330.34 ns |       304.41 ns |       459.65 ns |      3.73 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |         WhereSelect,Array |        46.22 ns |       1.480 ns |        46.10 ns |        43.73 ns |        49.86 ns |      0.49 | 100000 |
| .NET Framework 4.8 |         WhereSelect,Array |        92.63 ns |       3.527 ns |        90.93 ns |        89.39 ns |       103.64 ns |      1.00 | 100000 |
|           .NET 6.0 |          WhereSelect,Linq | 2,205,972.43 ns |  23,335.535 ns | 2,208,289.26 ns | 2,160,173.63 ns | 2,237,467.77 ns | 23,246.07 | 100000 |
|           .NET 6.0 |          WhereSelect,List | 3,193,547.38 ns |  45,830.455 ns | 3,174,587.11 ns | 3,146,207.03 ns | 3,292,137.50 ns | 33,437.92 | 100000 |
| .NET Framework 4.8 |          WhereSelect,Linq | 3,908,518.67 ns |  51,171.795 ns | 3,899,220.31 ns | 3,838,187.89 ns | 4,010,245.31 ns | 40,961.30 | 100000 |
| .NET Framework 4.8 |          WhereSelect,List | 4,336,537.30 ns | 114,507.477 ns | 4,293,937.50 ns | 4,207,769.53 ns | 4,623,189.06 ns | 46,087.65 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |         WhereSelect,Array |        42.49 ns |       3.159 ns |        41.63 ns |        38.66 ns |        50.87 ns |      0.47 |    250 |
| .NET Framework 4.8 |         WhereSelect,Array |        92.07 ns |       1.368 ns |        91.42 ns |        90.70 ns |        95.47 ns |      1.00 |    250 |
|           .NET 6.0 |          WhereSelect,Linq |     5,956.84 ns |      99.041 ns |     5,929.93 ns |     5,827.18 ns |     6,186.35 ns |     64.66 |    250 |
|           .NET 6.0 |          WhereSelect,List |     7,941.32 ns |     276.798 ns |     7,860.85 ns |     7,600.47 ns |     8,575.17 ns |     86.01 |    250 |
| .NET Framework 4.8 |          WhereSelect,Linq |     9,919.65 ns |     239.127 ns |     9,831.49 ns |     9,630.63 ns |    10,405.82 ns |    108.13 |    250 |
| .NET Framework 4.8 |          WhereSelect,List |    10,900.39 ns |     281.852 ns |    10,710.45 ns |    10,478.18 ns |    11,283.14 ns |    117.85 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |         WhereSelect,Array |        41.61 ns |       0.649 ns |        41.57 ns |        40.72 ns |        42.92 ns |      0.42 |   5000 |
| .NET Framework 4.8 |         WhereSelect,Array |        96.78 ns |       5.096 ns |        95.75 ns |        90.62 ns |       109.37 ns |      1.00 |   5000 |
|           .NET 6.0 |          WhereSelect,Linq |   112,638.65 ns |   1,545.240 ns |   111,785.19 ns |   111,264.65 ns |   115,686.00 ns |  1,147.77 |   5000 |
|           .NET 6.0 |          WhereSelect,List |   178,484.00 ns |   1,041.236 ns |   177,897.46 ns |   177,521.78 ns |   180,246.63 ns |  1,807.42 |   5000 |
| .NET Framework 4.8 |          WhereSelect,Linq |   190,524.82 ns |   1,117.593 ns |   190,488.67 ns |   188,320.02 ns |   192,295.92 ns |  1,941.81 |   5000 |
| .NET Framework 4.8 |          WhereSelect,List |   246,843.17 ns |  11,399.482 ns |   246,130.58 ns |   233,665.62 ns |   279,614.50 ns |  2,538.56 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |        42.56 ns |       2.074 ns |        41.99 ns |        39.11 ns |        47.87 ns |      0.46 |      1 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        92.88 ns |       3.531 ns |        92.43 ns |        88.33 ns |       101.82 ns |      1.00 |      1 |
|           .NET 6.0 |      WhereSelectTake,List |       102.60 ns |       8.039 ns |       102.69 ns |        88.66 ns |       123.35 ns |      1.10 |      1 |
|           .NET 6.0 |      WhereSelectTake,Linq |       125.62 ns |       3.353 ns |       125.38 ns |       120.93 ns |       131.25 ns |      1.33 |      1 |
| .NET Framework 4.8 |      WhereSelectTake,List |       181.06 ns |      10.425 ns |       179.53 ns |       165.54 ns |       206.98 ns |      1.93 |      1 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |       296.42 ns |       6.663 ns |       295.30 ns |       287.02 ns |       306.14 ns |      3.13 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |        44.78 ns |       3.103 ns |        44.14 ns |        40.61 ns |        53.03 ns |      0.50 | 100000 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        92.06 ns |       1.392 ns |        91.66 ns |        89.99 ns |        94.19 ns |      1.00 | 100000 |
|           .NET 6.0 |      WhereSelectTake,List |   418,279.95 ns |  31,288.041 ns |   415,590.21 ns |   370,969.60 ns |   496,954.61 ns |  4,294.37 | 100000 |
| .NET Framework 4.8 |      WhereSelectTake,List |   471,509.12 ns |  39,082.486 ns |   462,535.35 ns |   415,765.53 ns |   581,434.57 ns |  5,101.17 | 100000 |
|           .NET 6.0 |      WhereSelectTake,Linq | 2,262,385.08 ns |  60,168.551 ns | 2,240,754.30 ns | 2,161,347.66 ns | 2,397,128.12 ns | 24,823.56 | 100000 |
| .NET Framework 4.8 |      WhereSelectTake,Linq | 4,048,510.23 ns |  95,931.429 ns | 4,008,133.59 ns | 3,955,760.94 ns | 4,352,457.03 ns | 44,223.80 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |        46.79 ns |       2.496 ns |        46.47 ns |        43.57 ns |        54.15 ns |      0.51 |    250 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        93.00 ns |       3.810 ns |        92.93 ns |        88.24 ns |       103.16 ns |      1.00 |    250 |
|           .NET 6.0 |      WhereSelectTake,List |     1,096.45 ns |      43.434 ns |     1,085.79 ns |     1,029.15 ns |     1,204.03 ns |     11.81 |    250 |
| .NET Framework 4.8 |      WhereSelectTake,List |     1,397.07 ns |      69.595 ns |     1,396.20 ns |     1,275.46 ns |     1,562.91 ns |     14.98 |    250 |
|           .NET 6.0 |      WhereSelectTake,Linq |     5,937.69 ns |      60.057 ns |     5,961.72 ns |     5,796.46 ns |     5,993.28 ns |     63.58 |    250 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |    10,270.87 ns |     199.934 ns |    10,233.44 ns |    10,030.70 ns |    10,658.26 ns |    108.53 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |        43.00 ns |       1.449 ns |        42.59 ns |        41.33 ns |        46.89 ns |      0.45 |   5000 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        95.52 ns |       5.198 ns |        94.09 ns |        89.88 ns |       110.48 ns |      1.00 |   5000 |
|           .NET 6.0 |      WhereSelectTake,List |    19,828.57 ns |   1,166.160 ns |    19,704.43 ns |    18,075.30 ns |    23,146.26 ns |    208.55 |   5000 |
| .NET Framework 4.8 |      WhereSelectTake,List |    23,696.66 ns |     864.297 ns |    23,593.22 ns |    22,224.22 ns |    25,459.23 ns |    247.49 |   5000 |
|           .NET 6.0 |      WhereSelectTake,Linq |   125,014.39 ns |   6,231.702 ns |   125,818.12 ns |   113,557.62 ns |   138,940.44 ns |  1,309.68 |   5000 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |   208,295.67 ns |  11,048.310 ns |   205,605.33 ns |   193,090.16 ns |   236,504.17 ns |  2,190.13 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |        45.80 ns |       2.321 ns |        45.29 ns |        42.27 ns |        51.89 ns |      0.47 |      1 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        94.87 ns |       1.787 ns |        95.18 ns |        92.12 ns |        97.78 ns |      1.00 |      1 |
|           .NET 6.0 |  WhereSelectTakeLast,List |       107.21 ns |      19.164 ns |       102.58 ns |        86.29 ns |       151.05 ns |      1.23 |      1 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |       129.69 ns |       4.118 ns |       128.64 ns |       123.42 ns |       140.08 ns |      1.39 |      1 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |       178.21 ns |      20.625 ns |       169.47 ns |       157.45 ns |       240.53 ns |      1.89 |      1 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |       590.12 ns |      18.219 ns |       583.02 ns |       567.75 ns |       623.80 ns |      6.20 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |        48.32 ns |       2.830 ns |        48.28 ns |        43.95 ns |        56.16 ns |      0.52 | 100000 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        94.64 ns |       2.153 ns |        94.25 ns |        90.75 ns |        99.18 ns |      1.00 | 100000 |
|           .NET 6.0 |  WhereSelectTakeLast,List |   334,867.02 ns |   2,604.498 ns |   335,554.69 ns |   327,710.55 ns |   337,329.05 ns |  3,533.12 | 100000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |   422,036.90 ns |   8,365.999 ns |   417,438.57 ns |   414,944.04 ns |   437,884.91 ns |  4,462.63 | 100000 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq | 2,464,842.27 ns | 113,693.927 ns | 2,447,650.00 ns | 2,300,033.59 ns | 2,712,680.47 ns | 26,332.38 | 100000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq | 7,762,720.79 ns |  78,614.976 ns | 7,782,770.31 ns | 7,629,184.38 ns | 7,871,373.44 ns | 82,004.93 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |        43.93 ns |       1.948 ns |        43.88 ns |        40.83 ns |        48.82 ns |      0.47 |    250 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        93.32 ns |       2.395 ns |        93.83 ns |        89.68 ns |        98.78 ns |      1.00 |    250 |
|           .NET 6.0 |  WhereSelectTakeLast,List |       984.58 ns |      14.782 ns |       979.92 ns |       969.73 ns |     1,022.66 ns |     10.47 |    250 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |     1,295.06 ns |      32.461 ns |     1,282.84 ns |     1,254.12 ns |     1,355.55 ns |     13.85 |    250 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |     6,342.25 ns |     272.236 ns |     6,224.75 ns |     5,998.74 ns |     7,039.35 ns |     67.41 |    250 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |    21,095.46 ns |     567.814 ns |    20,828.54 ns |    20,213.75 ns |    22,101.61 ns |    226.12 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |        42.01 ns |       1.414 ns |        41.62 ns |        39.80 ns |        45.80 ns |      0.46 |   5000 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        92.51 ns |       0.719 ns |        92.76 ns |        91.41 ns |        93.32 ns |      1.00 |   5000 |
|           .NET 6.0 |  WhereSelectTakeLast,List |    18,748.95 ns |     628.441 ns |    18,525.54 ns |    18,007.04 ns |    20,785.38 ns |    204.56 |   5000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |    21,291.17 ns |      90.625 ns |    21,281.15 ns |    21,154.18 ns |    21,446.66 ns |    230.34 |   5000 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |   116,135.81 ns |   2,433.089 ns |   115,594.46 ns |   113,171.91 ns |   120,837.92 ns |  1,245.96 |   5000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |   401,594.22 ns |   5,898.032 ns |   398,548.49 ns |   393,621.48 ns |   412,849.37 ns |  4,335.15 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |           WhereTake,Array |        44.61 ns |       2.932 ns |        44.39 ns |        39.30 ns |        51.90 ns |      0.45 |      1 |
|           .NET 6.0 |            WhereTake,List |        85.30 ns |       0.522 ns |        85.45 ns |        84.00 ns |        85.95 ns |      0.83 |      1 |
|           .NET 6.0 |            WhereTake,Linq |        90.47 ns |       2.157 ns |        89.72 ns |        88.08 ns |        95.33 ns |      0.90 |      1 |
| .NET Framework 4.8 |           WhereTake,Array |        99.81 ns |       4.945 ns |        99.91 ns |        89.98 ns |       113.66 ns |      1.00 |      1 |
| .NET Framework 4.8 |            WhereTake,List |       163.43 ns |       4.241 ns |       162.72 ns |       157.58 ns |       174.04 ns |      1.62 |      1 |
| .NET Framework 4.8 |            WhereTake,Linq |       255.90 ns |       7.013 ns |       253.27 ns |       247.05 ns |       273.17 ns |      2.52 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |           WhereTake,Array |        44.02 ns |       2.497 ns |        43.71 ns |        40.07 ns |        49.70 ns |      0.44 | 100000 |
| .NET Framework 4.8 |           WhereTake,Array |        99.81 ns |       4.901 ns |        98.54 ns |        91.64 ns |       110.78 ns |      1.00 | 100000 |
|           .NET 6.0 |            WhereTake,List |   351,682.26 ns |  14,753.362 ns |   344,195.39 ns |   340,338.26 ns |   391,934.11 ns |  3,529.23 | 100000 |
| .NET Framework 4.8 |            WhereTake,List |   409,337.72 ns |   1,879.614 ns |   409,434.79 ns |   404,916.99 ns |   411,926.90 ns |  4,030.91 | 100000 |
|           .NET 6.0 |            WhereTake,Linq | 2,352,750.43 ns |  51,704.611 ns | 2,351,473.44 ns | 2,273,471.88 ns | 2,439,486.72 ns | 23,329.78 | 100000 |
| .NET Framework 4.8 |            WhereTake,Linq | 3,733,029.65 ns |  72,954.884 ns | 3,701,881.45 ns | 3,657,679.49 ns | 3,886,169.73 ns | 36,884.98 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |           WhereTake,Array |        49.37 ns |       1.968 ns |        48.60 ns |        46.98 ns |        54.30 ns |      0.50 |    250 |
| .NET Framework 4.8 |           WhereTake,Array |        97.96 ns |       4.634 ns |        97.42 ns |        91.35 ns |       110.57 ns |      1.00 |    250 |
|           .NET 6.0 |            WhereTake,List |     1,009.99 ns |      25.140 ns |       999.33 ns |       986.88 ns |     1,061.12 ns |     10.26 |    250 |
| .NET Framework 4.8 |            WhereTake,List |     1,235.27 ns |      16.371 ns |     1,229.58 ns |     1,216.57 ns |     1,273.67 ns |     12.33 |    250 |
|           .NET 6.0 |            WhereTake,Linq |     5,818.33 ns |     147.033 ns |     5,761.81 ns |     5,684.54 ns |     6,298.61 ns |     58.66 |    250 |
| .NET Framework 4.8 |            WhereTake,Linq |     9,952.85 ns |      46.854 ns |     9,946.62 ns |     9,892.36 ns |    10,027.65 ns |     99.03 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |           WhereTake,Array |        46.42 ns |       1.855 ns |        46.04 ns |        43.02 ns |        50.85 ns |      0.49 |   5000 |
| .NET Framework 4.8 |           WhereTake,Array |        92.67 ns |       0.781 ns |        92.78 ns |        91.14 ns |        93.82 ns |      1.00 |   5000 |
|           .NET 6.0 |            WhereTake,List |    17,633.75 ns |     656.621 ns |    17,381.96 ns |    16,843.86 ns |    19,551.77 ns |    192.10 |   5000 |
| .NET Framework 4.8 |            WhereTake,List |    20,716.14 ns |     383.511 ns |    20,587.80 ns |    20,323.25 ns |    21,518.21 ns |    224.02 |   5000 |
|           .NET 6.0 |            WhereTake,Linq |   110,273.38 ns |     958.855 ns |   109,946.37 ns |   109,186.35 ns |   112,412.21 ns |  1,188.06 |   5000 |
| .NET Framework 4.8 |            WhereTake,Linq |   192,342.05 ns |   4,430.043 ns |   189,818.68 ns |   187,558.40 ns |   203,406.96 ns |  2,085.32 |   5000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |        46.17 ns |       2.623 ns |        45.88 ns |        41.67 ns |        52.83 ns |      0.48 |      1 |
|           .NET 6.0 |        WhereTakeLast,List |        87.12 ns |       0.754 ns |        87.10 ns |        85.64 ns |        88.51 ns |      0.91 |      1 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        98.34 ns |       4.349 ns |        98.03 ns |        91.32 ns |       110.18 ns |      1.00 |      1 |
|           .NET 6.0 |        WhereTakeLast,Linq |       102.19 ns |       5.385 ns |       101.45 ns |        93.13 ns |       115.74 ns |      1.04 |      1 |
| .NET Framework 4.8 |        WhereTakeLast,List |       163.62 ns |       4.807 ns |       165.20 ns |       156.63 ns |       174.78 ns |      1.70 |      1 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |       564.85 ns |      23.718 ns |       563.49 ns |       520.07 ns |       615.64 ns |      5.76 |      1 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |        49.35 ns |       2.586 ns |        49.08 ns |        45.44 ns |        56.22 ns |      0.51 | 100000 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        97.26 ns |       4.052 ns |        97.49 ns |        90.26 ns |       105.47 ns |      1.00 | 100000 |
|           .NET 6.0 |        WhereTakeLast,List |   342,362.94 ns |  10,519.549 ns |   344,208.74 ns |   326,041.38 ns |   354,405.49 ns |  3,533.35 | 100000 |
| .NET Framework 4.8 |        WhereTakeLast,List |   420,990.97 ns |  10,837.479 ns |   415,947.39 ns |   406,638.13 ns |   441,091.65 ns |  4,366.19 | 100000 |
|           .NET 6.0 |        WhereTakeLast,Linq | 2,444,639.14 ns | 126,675.174 ns | 2,385,336.13 ns | 2,313,889.26 ns | 2,777,747.07 ns | 25,667.78 | 100000 |
| .NET Framework 4.8 |        WhereTakeLast,Linq | 8,010,899.96 ns | 296,598.842 ns | 8,028,817.97 ns | 7,581,084.77 ns | 8,604,983.98 ns | 82,816.77 | 100000 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |        50.66 ns |       3.077 ns |        49.76 ns |        46.61 ns |        57.64 ns |      0.54 |    250 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        94.61 ns |       2.690 ns |        94.72 ns |        88.34 ns |        99.16 ns |      1.00 |    250 |
|           .NET 6.0 |        WhereTakeLast,List |     1,050.25 ns |      43.677 ns |     1,042.92 ns |       981.01 ns |     1,157.49 ns |     11.26 |    250 |
| .NET Framework 4.8 |        WhereTakeLast,List |     1,234.00 ns |      22.205 ns |     1,234.34 ns |     1,207.56 ns |     1,296.59 ns |     13.12 |    250 |
|           .NET 6.0 |        WhereTakeLast,Linq |     6,365.58 ns |     141.074 ns |     6,343.11 ns |     6,210.62 ns |     6,670.18 ns |     67.76 |    250 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |    19,824.67 ns |     359.433 ns |    19,674.74 ns |    19,446.18 ns |    20,607.29 ns |    210.71 |    250 |
|                    |                           |                 |                |                 |                 |                 |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |        45.21 ns |       2.828 ns |        44.56 ns |        41.03 ns |        52.93 ns |      0.47 |   5000 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        98.94 ns |       4.219 ns |        98.66 ns |        92.75 ns |       109.69 ns |      1.00 |   5000 |
|           .NET 6.0 |        WhereTakeLast,List |    17,427.49 ns |     339.850 ns |    17,344.75 ns |    16,982.64 ns |    18,200.59 ns |    173.01 |   5000 |
| .NET Framework 4.8 |        WhereTakeLast,List |    20,856.07 ns |      70.705 ns |    20,868.50 ns |    20,676.95 ns |    20,927.77 ns |    206.07 |   5000 |
|           .NET 6.0 |        WhereTakeLast,Linq |   119,220.81 ns |     905.114 ns |   118,696.85 ns |   118,387.51 ns |   121,035.73 ns |  1,177.90 |   5000 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |   378,634.40 ns |     771.337 ns |   378,664.45 ns |   377,577.15 ns |   379,754.88 ns |  3,740.98 |   5000 |
