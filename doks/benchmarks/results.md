---
# Page settings
layout: page
keywords: Linq Dotnet
---
# Benchmark Run at 10/6/2021 11:22:13 AM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe  --join -Select -Where -Take -TakeLast --platform X64
```

## Faslinq

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2183 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-UXSZKV : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  Job-WJQHHN : .NET Framework 4.8 (4.8.3928.0), X64 RyuJIT

Platform=X64  

```

|            Runtime |                Categories |             Mean |         StdDev |           Median |              Min |              Max |     Ratio |   Size |
|------------------- |-------------------------- |-----------------:|---------------:|-----------------:|-----------------:|-----------------:|----------:|------- |
|           .NET 6.0 |              Select,Array |         87.76 ns |       5.796 ns |         86.20 ns |         77.74 ns |         98.22 ns |      0.52 |      1 |
| .NET Framework 4.8 |              Select,Array |        169.74 ns |      10.534 ns |        171.40 ns |        148.68 ns |        191.78 ns |      1.00 |      1 |
|           .NET 6.0 |               Select,List |        216.44 ns |      20.169 ns |        223.77 ns |        178.35 ns |        247.60 ns |      1.28 |      1 |
| .NET Framework 4.8 |               Select,List |        259.49 ns |       9.806 ns |        258.95 ns |        240.66 ns |        283.47 ns |      1.52 |      1 |
|           .NET 6.0 |               Select,Linq |      9,085.85 ns |     253.867 ns |      9,056.71 ns |      8,620.68 ns |      9,605.79 ns |     51.05 |      1 |
| .NET Framework 4.8 |               Select,Linq |     12,943.37 ns |     639.567 ns |     13,042.04 ns |     11,768.62 ns |     14,036.94 ns |     77.51 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |              Select,Array |         83.49 ns |       5.915 ns |         86.04 ns |         72.20 ns |         94.16 ns |      0.50 | 100000 |
| .NET Framework 4.8 |              Select,Array |        167.55 ns |       9.106 ns |        166.00 ns |        150.97 ns |        185.00 ns |      1.00 | 100000 |
|           .NET 6.0 |               Select,Linq |  3,544,356.50 ns |  82,951.424 ns |  3,534,923.63 ns |  3,412,233.40 ns |  3,697,366.99 ns | 22,072.17 | 100000 |
| .NET Framework 4.8 |               Select,Linq |  5,278,882.03 ns |  81,411.307 ns |  5,286,930.47 ns |  5,166,064.06 ns |  5,423,478.12 ns | 33,361.35 | 100000 |
|           .NET 6.0 |               Select,List |  5,565,585.53 ns | 234,602.482 ns |  5,595,323.83 ns |  5,079,959.38 ns |  5,974,810.16 ns | 32,748.78 | 100000 |
| .NET Framework 4.8 |               Select,List |  6,513,678.71 ns | 309,184.791 ns |  6,569,735.16 ns |  5,899,987.50 ns |  7,195,206.25 ns | 38,598.89 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |              Select,Array |         84.92 ns |       5.836 ns |         84.93 ns |         73.43 ns |         94.83 ns |      0.50 |    250 |
| .NET Framework 4.8 |              Select,Array |        171.61 ns |      10.989 ns |        172.54 ns |        154.27 ns |        191.72 ns |      1.00 |    250 |
|           .NET 6.0 |               Select,Linq |      9,226.43 ns |     261.584 ns |      9,254.51 ns |      8,704.56 ns |      9,730.67 ns |     53.42 |    250 |
|           .NET 6.0 |               Select,List |     12,886.62 ns |     668.136 ns |     12,977.12 ns |     11,522.14 ns |     13,983.79 ns |     76.10 |    250 |
| .NET Framework 4.8 |               Select,Linq |     13,195.12 ns |     532.452 ns |     13,373.22 ns |     11,675.92 ns |     14,007.22 ns |     78.71 |    250 |
| .NET Framework 4.8 |               Select,List |     13,707.01 ns |     858.716 ns |     13,563.09 ns |     12,435.18 ns |     15,382.77 ns |     80.38 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |              Select,Array |         99.44 ns |       1.505 ns |         99.70 ns |         96.82 ns |        101.68 ns |      0.59 |   5000 |
| .NET Framework 4.8 |              Select,Array |        168.91 ns |       9.563 ns |        169.72 ns |        150.06 ns |        184.96 ns |      1.00 |   5000 |
|           .NET 6.0 |               Select,Linq |    178,725.53 ns |   9,171.534 ns |    179,286.04 ns |    163,718.48 ns |    197,922.05 ns |  1,061.46 |   5000 |
| .NET Framework 4.8 |               Select,Linq |    258,485.62 ns |   4,500.338 ns |    258,008.20 ns |    252,139.06 ns |    268,772.66 ns |  1,532.44 |   5000 |
|           .NET 6.0 |               Select,List |    358,841.44 ns |  12,703.954 ns |    356,171.24 ns |    338,030.62 ns |    391,422.85 ns |  2,055.26 |   5000 |
| .NET Framework 4.8 |               Select,List |    387,487.09 ns |  17,147.963 ns |    392,780.08 ns |    350,270.21 ns |    414,400.54 ns |  2,274.92 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |          SelectTake,Array |         93.91 ns |       1.864 ns |         93.46 ns |         90.93 ns |         97.75 ns |      0.58 |      1 |
| .NET Framework 4.8 |          SelectTake,Array |        167.21 ns |       9.362 ns |        167.61 ns |        149.31 ns |        186.22 ns |      1.00 |      1 |
|           .NET 6.0 |           SelectTake,Linq |        176.06 ns |       9.831 ns |        175.71 ns |        157.97 ns |        194.15 ns |      1.06 |      1 |
|           .NET 6.0 |           SelectTake,List |        180.63 ns |       4.833 ns |        179.73 ns |        173.22 ns |        188.67 ns |      1.13 |      1 |
| .NET Framework 4.8 |           SelectTake,List |        259.86 ns |      11.691 ns |        258.46 ns |        240.93 ns |        291.53 ns |      1.59 |      1 |
| .NET Framework 4.8 |           SelectTake,Linq |        427.28 ns |      29.610 ns |        438.50 ns |        368.69 ns |        472.29 ns |      2.55 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |          SelectTake,Array |         84.90 ns |       5.411 ns |         85.31 ns |         74.41 ns |         93.74 ns |      0.46 | 100000 |
| .NET Framework 4.8 |          SelectTake,Array |        177.14 ns |       5.581 ns |        177.98 ns |        161.27 ns |        184.41 ns |      1.00 | 100000 |
|           .NET 6.0 |           SelectTake,Linq |    757,772.86 ns |  29,059.574 ns |    753,954.69 ns |    709,312.21 ns |    822,507.32 ns |  4,274.38 | 100000 |
|           .NET 6.0 |           SelectTake,List |  1,092,306.77 ns |  67,249.165 ns |  1,091,757.13 ns |    956,689.84 ns |  1,268,326.95 ns |  5,909.93 | 100000 |
| .NET Framework 4.8 |           SelectTake,List |  1,248,154.25 ns |  79,195.268 ns |  1,257,644.14 ns |  1,116,868.36 ns |  1,412,153.52 ns |  6,694.45 | 100000 |
| .NET Framework 4.8 |           SelectTake,Linq |  1,621,164.45 ns |  42,647.154 ns |  1,627,486.13 ns |  1,533,285.74 ns |  1,685,111.91 ns |  9,201.01 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |          SelectTake,Array |         90.27 ns |       2.854 ns |         89.96 ns |         86.02 ns |         95.81 ns |      0.50 |    250 |
| .NET Framework 4.8 |          SelectTake,Array |        183.60 ns |       3.874 ns |        184.27 ns |        176.15 ns |        191.35 ns |      1.00 |    250 |
|           .NET 6.0 |           SelectTake,Linq |      2,251.02 ns |      22.251 ns |      2,256.83 ns |      2,211.90 ns |      2,290.33 ns |     12.30 |    250 |
|           .NET 6.0 |           SelectTake,List |      3,158.06 ns |      90.213 ns |      3,179.85 ns |      2,815.10 ns |      3,263.48 ns |     17.15 |    250 |
| .NET Framework 4.8 |           SelectTake,List |      3,453.43 ns |     168.112 ns |      3,467.39 ns |      3,093.70 ns |      3,791.28 ns |     17.95 |    250 |
| .NET Framework 4.8 |           SelectTake,Linq |      4,781.61 ns |      67.751 ns |      4,760.65 ns |      4,706.23 ns |      4,934.85 ns |     26.08 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |          SelectTake,Array |         87.51 ns |       4.295 ns |         88.38 ns |         73.05 ns |         94.30 ns |      0.53 |   5000 |
| .NET Framework 4.8 |          SelectTake,Array |        169.09 ns |      10.661 ns |        171.79 ns |        144.63 ns |        193.61 ns |      1.00 |   5000 |
|           .NET 6.0 |           SelectTake,Linq |     40,882.90 ns |   1,205.659 ns |     41,010.57 ns |     37,978.38 ns |     43,342.56 ns |    247.28 |   5000 |
|           .NET 6.0 |           SelectTake,List |     50,010.81 ns |   3,637.729 ns |     50,683.15 ns |     42,427.79 ns |     55,816.82 ns |    297.67 |   5000 |
| .NET Framework 4.8 |           SelectTake,List |     54,369.13 ns |   2,694.035 ns |     53,850.32 ns |     49,664.76 ns |     59,237.11 ns |    326.81 |   5000 |
| .NET Framework 4.8 |           SelectTake,Linq |     82,478.82 ns |   1,678.242 ns |     82,091.31 ns |     79,930.98 ns |     85,220.54 ns |    479.84 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |         72.29 ns |       5.348 ns |         72.14 ns |         62.76 ns |         82.97 ns |      0.62 |      1 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        116.50 ns |       7.912 ns |        118.62 ns |        100.40 ns |        131.01 ns |      1.00 |      1 |
|           .NET 6.0 |       SelectTakeLast,List |        160.52 ns |      13.524 ns |        157.37 ns |        135.25 ns |        188.36 ns |      1.38 |      1 |
|           .NET 6.0 |       SelectTakeLast,Linq |        178.30 ns |      12.774 ns |        176.95 ns |        152.05 ns |        202.81 ns |      1.54 |      1 |
| .NET Framework 4.8 |       SelectTakeLast,List |        269.45 ns |      12.549 ns |        270.50 ns |        242.03 ns |        291.48 ns |      2.31 |      1 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |        852.21 ns |      14.610 ns |        855.48 ns |        821.83 ns |        873.08 ns |      7.43 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |         74.07 ns |       5.654 ns |         76.03 ns |         62.95 ns |         83.68 ns |      0.64 | 100000 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        116.58 ns |       8.290 ns |        118.24 ns |        103.33 ns |        130.72 ns |      1.00 | 100000 |
|           .NET 6.0 |       SelectTakeLast,Linq |  1,139,431.97 ns |  25,152.928 ns |  1,135,070.12 ns |  1,100,795.31 ns |  1,194,694.73 ns |  9,576.07 | 100000 |
|           .NET 6.0 |       SelectTakeLast,List |  1,159,411.19 ns |  78,076.188 ns |  1,171,501.17 ns |  1,024,550.59 ns |  1,361,856.05 ns |  9,989.44 | 100000 |
| .NET Framework 4.8 |       SelectTakeLast,List |  1,223,029.49 ns |  92,228.399 ns |  1,215,401.37 ns |  1,077,063.87 ns |  1,410,823.24 ns | 10,568.95 | 100000 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |  6,025,083.02 ns | 216,667.095 ns |  6,098,789.45 ns |  5,458,028.12 ns |  6,363,497.66 ns | 51,181.06 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |         75.30 ns |       5.213 ns |         75.92 ns |         63.63 ns |         84.17 ns |      0.64 |    250 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        118.44 ns |       6.745 ns |        120.67 ns |        102.60 ns |        129.31 ns |      1.00 |    250 |
|           .NET 6.0 |       SelectTakeLast,List |      3,068.86 ns |     160.672 ns |      3,066.57 ns |      2,622.87 ns |      3,363.97 ns |     26.15 |    250 |
|           .NET 6.0 |       SelectTakeLast,Linq |      3,325.73 ns |     144.677 ns |      3,386.60 ns |      2,986.73 ns |      3,540.04 ns |     28.50 |    250 |
| .NET Framework 4.8 |       SelectTakeLast,List |      3,409.49 ns |     292.432 ns |      3,433.68 ns |      2,959.36 ns |      4,152.64 ns |     28.98 |    250 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |     15,432.22 ns |     269.144 ns |     15,483.26 ns |     14,847.95 ns |     15,760.58 ns |    132.68 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |      SelectTakeLast,Array |         71.77 ns |       5.004 ns |         72.16 ns |         61.71 ns |         79.88 ns |      0.62 |   5000 |
| .NET Framework 4.8 |      SelectTakeLast,Array |        116.60 ns |       8.117 ns |        117.56 ns |        102.61 ns |        131.47 ns |      1.00 |   5000 |
|           .NET 6.0 |       SelectTakeLast,List |     46,691.07 ns |   1,268.450 ns |     46,876.53 ns |     42,874.81 ns |     48,874.55 ns |    390.81 |   5000 |
| .NET Framework 4.8 |       SelectTakeLast,List |     57,450.08 ns |     933.650 ns |     57,455.39 ns |     55,840.89 ns |     59,351.08 ns |    492.75 |   5000 |
|           .NET 6.0 |       SelectTakeLast,Linq |     60,755.66 ns |     678.203 ns |     60,694.16 ns |     59,721.21 ns |     61,875.45 ns |    521.05 |   5000 |
| .NET Framework 4.8 |       SelectTakeLast,Linq |    274,206.34 ns |  12,178.353 ns |    271,767.48 ns |    256,739.01 ns |    304,613.13 ns |  2,400.23 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |                Take,Array |        105.86 ns |       9.249 ns |        102.98 ns |         92.09 ns |        123.40 ns |      0.37 |      1 |
|           .NET 6.0 |                 Take,Linq |        117.51 ns |       9.660 ns |        116.15 ns |        102.26 ns |        134.25 ns |      0.42 |      1 |
|           .NET 6.0 |                 Take,List |        182.12 ns |      12.277 ns |        184.14 ns |        158.66 ns |        204.86 ns |      0.69 |      1 |
| .NET Framework 4.8 |                 Take,List |        270.96 ns |       6.245 ns |        270.40 ns |        258.89 ns |        284.99 ns |      1.00 |      1 |
| .NET Framework 4.8 |                 Take,Linq |        365.37 ns |      23.235 ns |        361.95 ns |        323.59 ns |        409.41 ns |      1.34 |      1 |
| .NET Framework 4.8 |                Take,Array |        369.87 ns |      18.619 ns |        370.82 ns |        333.91 ns |        408.82 ns |      1.35 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |                Take,Array |        110.49 ns |       9.023 ns |        110.55 ns |         93.80 ns |        125.95 ns |      0.28 | 100000 |
| .NET Framework 4.8 |                Take,Array |        386.03 ns |       6.628 ns |        385.80 ns |        372.59 ns |        397.59 ns |      1.00 | 100000 |
|           .NET 6.0 |                 Take,Linq |    585,800.21 ns |  31,746.644 ns |    597,195.31 ns |    521,683.50 ns |    633,650.00 ns |  1,413.95 | 100000 |
|           .NET 6.0 |                 Take,List |    968,547.09 ns |  71,883.123 ns |    962,992.87 ns |    844,990.92 ns |  1,146,950.68 ns |  2,395.58 | 100000 |
| .NET Framework 4.8 |                 Take,Linq |  1,122,641.99 ns |  58,872.978 ns |  1,139,808.01 ns |    980,944.53 ns |  1,201,951.37 ns |  2,864.39 | 100000 |
| .NET Framework 4.8 |                 Take,List |  1,171,926.15 ns |  72,163.173 ns |  1,174,062.11 ns |  1,028,429.30 ns |  1,368,510.74 ns |  3,219.01 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |                Take,Array |        109.16 ns |       8.893 ns |        106.79 ns |         95.63 ns |        124.05 ns |      0.30 |    250 |
| .NET Framework 4.8 |                Take,Array |        367.97 ns |      20.884 ns |        372.29 ns |        328.52 ns |        403.48 ns |      1.00 |    250 |
|           .NET 6.0 |                 Take,Linq |      1,653.90 ns |      80.857 ns |      1,677.92 ns |      1,503.96 ns |      1,778.70 ns |      4.57 |    250 |
|           .NET 6.0 |                 Take,List |      2,633.61 ns |     195.165 ns |      2,645.08 ns |      2,263.51 ns |      2,969.55 ns |      7.22 |    250 |
| .NET Framework 4.8 |                 Take,List |      2,861.85 ns |     185.619 ns |      2,914.61 ns |      2,494.33 ns |      3,306.95 ns |      7.83 |    250 |
| .NET Framework 4.8 |                 Take,Linq |      3,333.72 ns |     142.147 ns |      3,371.60 ns |      2,976.16 ns |      3,554.64 ns |      9.35 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |                Take,Array |        112.22 ns |       8.151 ns |        113.59 ns |         96.49 ns |        126.13 ns |      0.30 |   5000 |
| .NET Framework 4.8 |                Take,Array |        371.36 ns |      21.792 ns |        375.67 ns |        321.92 ns |        411.90 ns |      1.00 |   5000 |
|           .NET 6.0 |                 Take,Linq |     29,662.74 ns |   1,539.220 ns |     29,628.88 ns |     26,555.12 ns |     32,647.86 ns |     80.56 |   5000 |
|           .NET 6.0 |                 Take,List |     42,257.48 ns |   2,828.274 ns |     42,592.71 ns |     36,909.34 ns |     46,684.81 ns |    114.02 |   5000 |
| .NET Framework 4.8 |                 Take,List |     47,798.09 ns |     823.690 ns |     47,660.20 ns |     46,591.49 ns |     49,239.48 ns |    129.39 |   5000 |
| .NET Framework 4.8 |                 Take,Linq |     56,442.89 ns |   2,757.140 ns |     57,384.31 ns |     51,133.75 ns |     60,232.50 ns |    153.63 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |            TakeLast,Array |         85.53 ns |       5.137 ns |         85.29 ns |         75.38 ns |         98.07 ns |      0.52 |      1 |
|           .NET 6.0 |             TakeLast,Linq |        135.04 ns |       2.883 ns |        135.25 ns |        127.98 ns |        139.41 ns |      0.81 |      1 |
| .NET Framework 4.8 |            TakeLast,Array |        166.59 ns |      10.970 ns |        165.16 ns |        147.00 ns |        188.20 ns |      1.00 |      1 |
|           .NET 6.0 |             TakeLast,List |        174.11 ns |      14.279 ns |        174.84 ns |        148.68 ns |        199.61 ns |      1.05 |      1 |
| .NET Framework 4.8 |             TakeLast,List |        264.78 ns |       7.999 ns |        265.36 ns |        245.32 ns |        281.26 ns |      1.55 |      1 |
| .NET Framework 4.8 |             TakeLast,Linq |        563.72 ns |      10.933 ns |        566.89 ns |        541.49 ns |        578.50 ns |      3.40 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |            TakeLast,Array |         83.58 ns |       4.955 ns |         84.88 ns |         72.50 ns |         92.65 ns |      0.50 | 100000 |
| .NET Framework 4.8 |            TakeLast,Array |        171.06 ns |       4.129 ns |        170.18 ns |        164.00 ns |        179.29 ns |      1.00 | 100000 |
|           .NET 6.0 |             TakeLast,Linq |    983,550.67 ns |  29,951.843 ns |    982,776.76 ns |    932,952.34 ns |  1,043,041.80 ns |  5,755.75 | 100000 |
|           .NET 6.0 |             TakeLast,List |  1,003,829.97 ns |  54,908.388 ns |  1,012,562.21 ns |    885,625.98 ns |  1,130,571.88 ns |  5,898.26 | 100000 |
| .NET Framework 4.8 |             TakeLast,List |  1,169,896.44 ns |  46,653.960 ns |  1,171,779.30 ns |  1,072,310.55 ns |  1,279,093.75 ns |  6,735.55 | 100000 |
| .NET Framework 4.8 |             TakeLast,Linq |  1,591,564.25 ns |  35,336.240 ns |  1,592,267.38 ns |  1,536,420.31 ns |  1,655,667.38 ns |  9,300.28 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |            TakeLast,Array |         91.75 ns |       2.580 ns |         91.92 ns |         83.94 ns |         95.13 ns |      0.54 |    250 |
| .NET Framework 4.8 |            TakeLast,Array |        171.10 ns |       2.761 ns |        170.65 ns |        166.91 ns |        176.60 ns |      1.00 |    250 |
|           .NET 6.0 |             TakeLast,List |      2,570.23 ns |     179.876 ns |      2,577.03 ns |      2,191.51 ns |      2,881.81 ns |     13.98 |    250 |
|           .NET 6.0 |             TakeLast,Linq |      2,748.65 ns |     107.209 ns |      2,772.71 ns |      2,539.00 ns |      2,942.38 ns |     15.86 |    250 |
| .NET Framework 4.8 |             TakeLast,List |      2,843.31 ns |     186.347 ns |      2,810.26 ns |      2,455.52 ns |      3,187.85 ns |     16.17 |    250 |
| .NET Framework 4.8 |             TakeLast,Linq |      4,473.91 ns |      69.513 ns |      4,473.22 ns |      4,317.10 ns |      4,565.25 ns |     26.15 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |            TakeLast,Array |         86.02 ns |       4.303 ns |         86.59 ns |         74.89 ns |         94.87 ns |      0.51 |   5000 |
| .NET Framework 4.8 |            TakeLast,Array |        168.72 ns |       9.349 ns |        169.35 ns |        150.39 ns |        186.45 ns |      1.00 |   5000 |
|           .NET 6.0 |             TakeLast,List |     44,843.36 ns |     918.329 ns |     44,745.22 ns |     42,870.54 ns |     46,086.12 ns |    270.66 |   5000 |
| .NET Framework 4.8 |             TakeLast,List |     45,630.63 ns |   2,077.973 ns |     45,957.27 ns |     41,616.53 ns |     49,107.40 ns |    268.96 |   5000 |
|           .NET 6.0 |             TakeLast,Linq |     50,378.72 ns |   1,452.156 ns |     50,858.25 ns |     47,355.48 ns |     52,785.00 ns |    301.23 |   5000 |
| .NET Framework 4.8 |             TakeLast,Linq |     71,622.84 ns |   1,138.629 ns |     71,619.42 ns |     69,221.78 ns |     73,741.27 ns |    431.84 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |               Where,Array |         87.03 ns |       4.070 ns |         88.25 ns |         76.99 ns |         95.01 ns |      0.51 |      1 |
| .NET Framework 4.8 |               Where,Array |        169.74 ns |       9.411 ns |        169.10 ns |        150.25 ns |        187.82 ns |      1.00 |      1 |
|           .NET 6.0 |                Where,Linq |        251.18 ns |      15.034 ns |        254.00 ns |        205.17 ns |        278.22 ns |      1.48 |      1 |
|           .NET 6.0 |                Where,List |        256.82 ns |      21.537 ns |        262.82 ns |        213.47 ns |        290.84 ns |      1.52 |      1 |
| .NET Framework 4.8 |                Where,List |        320.44 ns |      15.265 ns |        324.56 ns |        291.63 ns |        348.85 ns |      1.87 |      1 |
| .NET Framework 4.8 |                Where,Linq |        450.40 ns |      27.739 ns |        448.54 ns |        396.01 ns |        506.54 ns |      2.64 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |               Where,Array |         86.67 ns |       4.952 ns |         86.24 ns |         76.17 ns |         95.07 ns |      0.48 | 100000 |
| .NET Framework 4.8 |               Where,Array |        177.30 ns |       3.697 ns |        177.99 ns |        170.35 ns |        183.20 ns |      1.00 | 100000 |
|           .NET 6.0 |                Where,List |  5,542,635.50 ns | 153,964.042 ns |  5,533,906.25 ns |  5,302,647.66 ns |  5,870,249.22 ns | 31,476.50 | 100000 |
|           .NET 6.0 |                Where,Linq |  6,650,553.54 ns | 333,010.247 ns |  6,715,025.00 ns |  6,040,177.34 ns |  7,297,657.81 ns | 37,182.02 | 100000 |
| .NET Framework 4.8 |                Where,List |  6,804,152.73 ns | 143,216.666 ns |  6,821,870.70 ns |  6,548,463.67 ns |  7,027,773.83 ns | 38,390.00 | 100000 |
| .NET Framework 4.8 |                Where,Linq |  8,151,489.14 ns | 295,942.358 ns |  8,153,882.81 ns |  7,630,467.19 ns |  8,752,614.06 ns | 45,348.14 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |               Where,Array |         81.68 ns |       2.202 ns |         81.28 ns |         77.95 ns |         85.71 ns |      0.48 |    250 |
| .NET Framework 4.8 |               Where,Array |        166.10 ns |       9.864 ns |        167.23 ns |        147.23 ns |        186.31 ns |      1.00 |    250 |
|           .NET 6.0 |                Where,List |     13,207.39 ns |     654.246 ns |     13,297.65 ns |     12,047.42 ns |     14,153.38 ns |     79.72 |    250 |
|           .NET 6.0 |                Where,Linq |     16,925.56 ns |     434.945 ns |     16,929.10 ns |     15,949.14 ns |     17,609.89 ns |    100.48 |    250 |
| .NET Framework 4.8 |                Where,List |     17,813.85 ns |   1,011.800 ns |     18,109.32 ns |     15,509.25 ns |     19,443.58 ns |    107.58 |    250 |
| .NET Framework 4.8 |                Where,Linq |     21,557.61 ns |     674.516 ns |     21,518.73 ns |     19,973.23 ns |     22,806.18 ns |    126.66 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |               Where,Array |         92.98 ns |       2.073 ns |         93.51 ns |         89.20 ns |         95.84 ns |      0.58 |   5000 |
| .NET Framework 4.8 |               Where,Array |        168.38 ns |       8.495 ns |        169.47 ns |        146.78 ns |        182.93 ns |      1.00 |   5000 |
|           .NET 6.0 |                Where,List |    313,359.16 ns |   8,757.222 ns |    312,143.75 ns |    289,035.45 ns |    332,689.21 ns |  1,960.61 |   5000 |
|           .NET 6.0 |                Where,Linq |    329,090.53 ns |  14,583.106 ns |    333,102.83 ns |    293,746.63 ns |    348,020.46 ns |  1,974.51 |   5000 |
| .NET Framework 4.8 |                Where,List |    377,095.63 ns |  20,579.531 ns |    375,757.08 ns |    338,047.02 ns |    414,315.48 ns |  2,256.50 |   5000 |
| .NET Framework 4.8 |                Where,Linq |    428,675.99 ns |  18,615.921 ns |    435,619.38 ns |    388,918.75 ns |    460,850.05 ns |  2,574.10 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |         WhereSelect,Array |         83.07 ns |       6.015 ns |         85.28 ns |         71.36 ns |         92.38 ns |      0.50 |      1 |
| .NET Framework 4.8 |         WhereSelect,Array |        167.72 ns |       9.700 ns |        166.13 ns |        149.48 ns |        192.47 ns |      1.00 |      1 |
|           .NET 6.0 |          WhereSelect,List |        265.84 ns |      20.972 ns |        266.56 ns |        226.54 ns |        300.30 ns |      1.59 |      1 |
|           .NET 6.0 |          WhereSelect,Linq |        317.49 ns |      23.372 ns |        323.11 ns |        271.86 ns |        356.22 ns |      1.91 |      1 |
| .NET Framework 4.8 |          WhereSelect,List |        329.63 ns |      17.745 ns |        333.29 ns |        290.64 ns |        363.91 ns |      1.97 |      1 |
| .NET Framework 4.8 |          WhereSelect,Linq |        547.43 ns |      35.058 ns |        542.46 ns |        481.98 ns |        620.91 ns |      3.27 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |         WhereSelect,Array |         90.95 ns |       1.154 ns |         90.96 ns |         88.22 ns |         92.84 ns |      0.55 | 100000 |
| .NET Framework 4.8 |         WhereSelect,Array |        168.41 ns |      10.364 ns |        167.85 ns |        151.69 ns |        186.74 ns |      1.00 | 100000 |
|           .NET 6.0 |          WhereSelect,Linq |  4,563,523.23 ns |  67,275.867 ns |  4,576,853.12 ns |  4,434,588.28 ns |  4,670,867.97 ns | 27,552.57 | 100000 |
|           .NET 6.0 |          WhereSelect,List |  5,919,565.00 ns | 238,786.528 ns |  5,981,410.16 ns |  5,301,011.72 ns |  6,282,586.72 ns | 36,121.84 | 100000 |
| .NET Framework 4.8 |          WhereSelect,Linq |  6,601,425.52 ns | 120,211.441 ns |  6,635,269.53 ns |  6,460,481.25 ns |  6,838,603.12 ns | 39,860.95 | 100000 |
| .NET Framework 4.8 |          WhereSelect,List |  7,582,867.42 ns | 362,549.292 ns |  7,573,546.88 ns |  6,785,151.56 ns |  8,283,414.06 ns | 45,604.43 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |         WhereSelect,Array |         91.35 ns |       4.949 ns |         90.78 ns |         80.70 ns |        100.55 ns |      0.53 |    250 |
| .NET Framework 4.8 |         WhereSelect,Array |        174.69 ns |       7.756 ns |        176.30 ns |        151.06 ns |        185.30 ns |      1.00 |    250 |
|           .NET 6.0 |          WhereSelect,Linq |     10,984.56 ns |     162.536 ns |     11,014.46 ns |     10,625.30 ns |     11,197.61 ns |     64.34 |    250 |
|           .NET 6.0 |          WhereSelect,List |     14,096.26 ns |     664.966 ns |     14,091.42 ns |     12,529.85 ns |     15,140.96 ns |     81.16 |    250 |
| .NET Framework 4.8 |          WhereSelect,Linq |     17,521.39 ns |     246.240 ns |     17,481.28 ns |     17,161.25 ns |     17,992.99 ns |    102.63 |    250 |
| .NET Framework 4.8 |          WhereSelect,List |     18,724.04 ns |   1,079.215 ns |     18,684.95 ns |     16,647.59 ns |     20,597.94 ns |    109.90 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |         WhereSelect,Array |         85.09 ns |       4.728 ns |         85.23 ns |         73.75 ns |         94.14 ns |      0.48 |   5000 |
| .NET Framework 4.8 |         WhereSelect,Array |        179.34 ns |       3.131 ns |        179.60 ns |        174.03 ns |        185.21 ns |      1.00 |   5000 |
|           .NET 6.0 |          WhereSelect,Linq |    220,536.71 ns |   3,419.177 ns |    221,367.92 ns |    212,467.99 ns |    225,558.96 ns |  1,229.91 |   5000 |
|           .NET 6.0 |          WhereSelect,List |    334,412.08 ns |   6,239.238 ns |    335,973.54 ns |    324,077.39 ns |    343,477.25 ns |  1,865.04 |   5000 |
| .NET Framework 4.8 |          WhereSelect,Linq |    343,102.78 ns |   4,579.037 ns |    343,157.91 ns |    336,404.15 ns |    350,407.67 ns |  1,913.70 |   5000 |
| .NET Framework 4.8 |          WhereSelect,List |    408,027.20 ns |  22,059.140 ns |    411,811.40 ns |    363,130.88 ns |    447,347.00 ns |  2,253.79 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |         86.69 ns |       4.503 ns |         87.79 ns |         77.15 ns |         93.34 ns |      0.52 |      1 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        165.09 ns |      11.122 ns |        163.93 ns |        143.72 ns |        189.61 ns |      1.00 |      1 |
|           .NET 6.0 |      WhereSelectTake,List |        217.14 ns |       4.258 ns |        218.63 ns |        206.91 ns |        221.86 ns |      1.36 |      1 |
|           .NET 6.0 |      WhereSelectTake,Linq |        254.15 ns |      18.840 ns |        257.33 ns |        211.88 ns |        285.18 ns |      1.55 |      1 |
| .NET Framework 4.8 |      WhereSelectTake,List |        272.27 ns |      10.286 ns |        272.29 ns |        252.59 ns |        296.95 ns |      1.62 |      1 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |        499.63 ns |      21.299 ns |        494.82 ns |        454.66 ns |        558.46 ns |      2.96 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |         90.76 ns |       1.848 ns |         90.40 ns |         87.75 ns |         94.12 ns |      0.55 | 100000 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        168.61 ns |      10.176 ns |        170.27 ns |        148.43 ns |        184.30 ns |      1.00 | 100000 |
|           .NET 6.0 |      WhereSelectTake,List |    646,846.38 ns |  17,904.508 ns |    650,313.92 ns |    602,517.82 ns |    676,556.10 ns |  3,876.00 | 100000 |
| .NET Framework 4.8 |      WhereSelectTake,List |    657,394.21 ns |  23,756.558 ns |    655,546.14 ns |    606,025.39 ns |    714,467.19 ns |  4,026.48 | 100000 |
|           .NET 6.0 |      WhereSelectTake,Linq |  4,206,559.45 ns | 212,040.480 ns |  4,212,114.84 ns |  3,805,607.03 ns |  4,534,044.53 ns | 24,954.85 | 100000 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |  6,962,028.56 ns | 227,523.804 ns |  6,999,503.12 ns |  6,207,389.84 ns |  7,245,992.19 ns | 42,372.49 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |         84.38 ns |       5.248 ns |         85.20 ns |         72.70 ns |         94.01 ns |      0.43 |    250 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        180.76 ns |       3.284 ns |        180.73 ns |        175.88 ns |        186.69 ns |      1.00 |    250 |
|           .NET 6.0 |      WhereSelectTake,List |      1,906.16 ns |      25.384 ns |      1,907.02 ns |      1,858.61 ns |      1,954.11 ns |     10.55 |    250 |
| .NET Framework 4.8 |      WhereSelectTake,List |      2,295.06 ns |      91.863 ns |      2,285.22 ns |      2,110.59 ns |      2,492.97 ns |     13.08 |    250 |
|           .NET 6.0 |      WhereSelectTake,Linq |     10,355.99 ns |     214.324 ns |     10,341.47 ns |      9,954.70 ns |     10,783.14 ns |     57.25 |    250 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |     17,479.06 ns |     461.346 ns |     17,431.09 ns |     16,608.92 ns |     18,413.48 ns |     97.81 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |     WhereSelectTake,Array |         83.24 ns |       2.908 ns |         83.17 ns |         77.21 ns |         90.01 ns |      0.47 |   5000 |
| .NET Framework 4.8 |     WhereSelectTake,Array |        180.66 ns |       3.123 ns |        181.15 ns |        175.62 ns |        185.62 ns |      1.00 |   5000 |
|           .NET 6.0 |      WhereSelectTake,List |     34,139.52 ns |     538.962 ns |     34,063.18 ns |     33,305.67 ns |     35,280.26 ns |    189.02 |   5000 |
| .NET Framework 4.8 |      WhereSelectTake,List |     39,089.45 ns |   1,340.396 ns |     39,313.04 ns |     35,479.53 ns |     41,472.07 ns |    220.24 |   5000 |
|           .NET 6.0 |      WhereSelectTake,Linq |    207,422.31 ns |   7,158.168 ns |    208,043.63 ns |    192,269.73 ns |    221,880.00 ns |  1,163.51 |   5000 |
| .NET Framework 4.8 |      WhereSelectTake,Linq |    348,612.14 ns |   5,841.888 ns |    347,741.80 ns |    339,193.80 ns |    359,642.97 ns |  1,929.98 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |         91.61 ns |       3.348 ns |         91.96 ns |         84.48 ns |         96.89 ns |      0.53 |      1 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        172.15 ns |       4.520 ns |        172.34 ns |        158.03 ns |        179.16 ns |      1.00 |      1 |
|           .NET 6.0 |  WhereSelectTakeLast,List |        199.22 ns |      16.095 ns |        198.10 ns |        165.23 ns |        228.47 ns |      1.16 |      1 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |        243.81 ns |      21.370 ns |        240.84 ns |        200.51 ns |        284.38 ns |      1.32 |      1 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |        297.66 ns |      17.398 ns |        301.44 ns |        249.43 ns |        331.26 ns |      1.61 |      1 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |        990.39 ns |      58.123 ns |        995.27 ns |        868.33 ns |      1,142.25 ns |      5.72 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |         85.65 ns |       4.737 ns |         86.39 ns |         72.69 ns |         93.85 ns |      0.51 | 100000 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        167.92 ns |      10.652 ns |        167.58 ns |        148.67 ns |        186.80 ns |      1.00 | 100000 |
|           .NET 6.0 |  WhereSelectTakeLast,List |    627,418.66 ns |  19,836.427 ns |    631,612.21 ns |    577,876.46 ns |    662,761.62 ns |  3,899.28 | 100000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |    696,343.49 ns |  22,544.464 ns |    698,039.16 ns |    649,133.50 ns |    741,972.95 ns |  4,328.56 | 100000 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |  4,455,890.35 ns | 110,650.052 ns |  4,450,745.31 ns |  4,289,595.31 ns |  4,710,018.75 ns | 27,310.35 | 100000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq | 12,865,082.07 ns | 429,748.145 ns | 12,859,111.72 ns | 12,028,014.84 ns | 13,734,157.03 ns | 80,201.02 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |         92.65 ns |       5.581 ns |         92.47 ns |         80.92 ns |        101.82 ns |      0.49 |    250 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        184.27 ns |       2.431 ns |        184.45 ns |        180.69 ns |        189.51 ns |      1.00 |    250 |
|           .NET 6.0 |  WhereSelectTakeLast,List |      1,987.32 ns |      68.486 ns |      1,997.97 ns |      1,830.31 ns |      2,092.84 ns |     10.45 |    250 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |      2,206.27 ns |      28.554 ns |      2,204.99 ns |      2,166.54 ns |      2,249.89 ns |     11.98 |    250 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |     11,807.15 ns |     372.537 ns |     11,914.84 ns |     11,026.68 ns |     12,430.77 ns |     62.60 |    250 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |     32,128.42 ns |   1,077.942 ns |     32,055.15 ns |     30,004.92 ns |     34,600.78 ns |    174.07 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 | WhereSelectTakeLast,Array |         91.74 ns |       5.899 ns |         91.89 ns |         79.51 ns |        100.34 ns |      0.54 |   5000 |
| .NET Framework 4.8 | WhereSelectTakeLast,Array |        169.59 ns |      10.315 ns |        169.57 ns |        149.82 ns |        190.51 ns |      1.00 |   5000 |
|           .NET 6.0 |  WhereSelectTakeLast,List |     29,998.50 ns |     939.641 ns |     29,864.99 ns |     28,387.79 ns |     31,977.41 ns |    172.64 |   5000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,List |     35,720.81 ns |     983.062 ns |     35,772.40 ns |     33,062.00 ns |     37,379.03 ns |    207.44 |   5000 |
|           .NET 6.0 |  WhereSelectTakeLast,Linq |    215,802.89 ns |   4,698.728 ns |    216,666.36 ns |    206,353.71 ns |    221,464.26 ns |  1,284.98 |   5000 |
| .NET Framework 4.8 |  WhereSelectTakeLast,Linq |    658,131.98 ns |  16,455.316 ns |    655,814.55 ns |    634,271.58 ns |    687,031.54 ns |  3,864.48 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |           WhereTake,Array |         85.01 ns |       4.620 ns |         85.22 ns |         72.22 ns |         96.19 ns |      0.48 |      1 |
| .NET Framework 4.8 |           WhereTake,Array |        175.53 ns |       5.205 ns |        175.32 ns |        162.23 ns |        185.25 ns |      1.00 |      1 |
|           .NET 6.0 |            WhereTake,Linq |        185.05 ns |      16.719 ns |        180.69 ns |        155.67 ns |        215.53 ns |      0.98 |      1 |
|           .NET 6.0 |            WhereTake,List |        198.02 ns |      17.923 ns |        195.12 ns |        168.20 ns |        234.29 ns |      1.10 |      1 |
| .NET Framework 4.8 |            WhereTake,List |        283.90 ns |      17.613 ns |        286.74 ns |        253.32 ns |        324.64 ns |      1.69 |      1 |
| .NET Framework 4.8 |            WhereTake,Linq |        440.78 ns |      26.426 ns |        442.02 ns |        393.20 ns |        491.74 ns |      2.56 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |           WhereTake,Array |         87.63 ns |       4.816 ns |         88.27 ns |         76.52 ns |         95.36 ns |      0.54 | 100000 |
| .NET Framework 4.8 |           WhereTake,Array |        153.12 ns |       2.439 ns |        153.08 ns |        148.29 ns |        157.90 ns |      1.00 | 100000 |
|           .NET 6.0 |            WhereTake,List |    709,926.72 ns |  13,872.000 ns |    714,444.34 ns |    690,371.14 ns |    736,189.11 ns |  4,644.16 | 100000 |
| .NET Framework 4.8 |            WhereTake,List |    764,939.09 ns |  20,367.185 ns |    765,054.59 ns |    736,030.08 ns |    813,666.11 ns |  4,983.10 | 100000 |
|           .NET 6.0 |            WhereTake,Linq |  4,267,396.22 ns |  90,697.794 ns |  4,292,039.84 ns |  4,079,053.91 ns |  4,449,296.88 ns | 27,806.08 | 100000 |
| .NET Framework 4.8 |            WhereTake,Linq |  6,838,919.43 ns |  79,030.386 ns |  6,813,498.44 ns |  6,740,882.81 ns |  6,981,326.56 ns | 44,675.53 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |           WhereTake,Array |         92.02 ns |       1.468 ns |         92.03 ns |         89.75 ns |         95.10 ns |      0.56 |    250 |
| .NET Framework 4.8 |           WhereTake,Array |        168.41 ns |       9.999 ns |        170.33 ns |        148.31 ns |        188.25 ns |      1.00 |    250 |
|           .NET 6.0 |            WhereTake,List |      1,874.25 ns |      54.338 ns |      1,888.70 ns |      1,741.72 ns |      1,944.56 ns |     11.35 |    250 |
| .NET Framework 4.8 |            WhereTake,List |      2,127.60 ns |      46.890 ns |      2,128.18 ns |      2,050.99 ns |      2,220.63 ns |     12.76 |    250 |
|           .NET 6.0 |            WhereTake,Linq |     10,722.46 ns |     375.172 ns |     10,644.30 ns |     10,066.84 ns |     11,482.04 ns |     65.57 |    250 |
| .NET Framework 4.8 |            WhereTake,Linq |     17,581.10 ns |     313.813 ns |     17,628.99 ns |     17,051.68 ns |     18,161.62 ns |    106.71 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |           WhereTake,Array |         93.59 ns |       6.391 ns |         93.61 ns |         81.75 ns |        106.20 ns |      0.56 |   5000 |
| .NET Framework 4.8 |           WhereTake,Array |        167.17 ns |      11.110 ns |        168.38 ns |        145.27 ns |        183.99 ns |      1.00 |   5000 |
|           .NET 6.0 |            WhereTake,List |     30,550.43 ns |     552.230 ns |     30,477.92 ns |     29,836.71 ns |     31,890.96 ns |    174.32 |   5000 |
| .NET Framework 4.8 |            WhereTake,List |     36,381.83 ns |     714.183 ns |     36,493.11 ns |     34,953.81 ns |     37,523.38 ns |    207.12 |   5000 |
|           .NET 6.0 |            WhereTake,Linq |    208,893.00 ns |   6,230.943 ns |    209,309.18 ns |    198,509.08 ns |    221,073.14 ns |  1,230.74 |   5000 |
| .NET Framework 4.8 |            WhereTake,Linq |    341,040.11 ns |   9,007.793 ns |    342,184.67 ns |    307,548.02 ns |    350,095.39 ns |  1,985.66 |   5000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |         85.11 ns |       5.726 ns |         86.28 ns |         72.98 ns |         95.34 ns |      0.52 |      1 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        165.82 ns |      10.260 ns |        164.22 ns |        147.02 ns |        185.33 ns |      1.00 |      1 |
|           .NET 6.0 |        WhereTakeLast,List |        206.58 ns |      17.792 ns |        210.34 ns |        173.06 ns |        234.85 ns |      1.25 |      1 |
|           .NET 6.0 |        WhereTakeLast,Linq |        209.26 ns |       6.902 ns |        209.88 ns |        196.68 ns |        222.10 ns |      1.31 |      1 |
| .NET Framework 4.8 |        WhereTakeLast,List |        288.82 ns |      16.541 ns |        286.41 ns |        257.95 ns |        329.93 ns |      1.74 |      1 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |      1,017.24 ns |      50.648 ns |      1,022.24 ns |        911.87 ns |      1,122.84 ns |      6.10 |      1 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |         86.50 ns |       5.152 ns |         85.76 ns |         74.84 ns |         98.18 ns |      0.45 | 100000 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        176.74 ns |       3.799 ns |        176.80 ns |        171.49 ns |        183.30 ns |      1.00 | 100000 |
| .NET Framework 4.8 |        WhereTakeLast,List |    687,457.93 ns |  19,718.427 ns |    689,337.55 ns |    647,513.28 ns |    736,502.54 ns |  3,871.23 | 100000 |
|           .NET 6.0 |        WhereTakeLast,List |    720,056.66 ns |  17,468.776 ns |    724,659.23 ns |    693,875.34 ns |    757,754.54 ns |  4,079.08 | 100000 |
|           .NET 6.0 |        WhereTakeLast,Linq |  4,298,241.34 ns | 148,778.389 ns |  4,275,416.02 ns |  4,075,301.17 ns |  4,608,326.95 ns | 24,154.02 | 100000 |
| .NET Framework 4.8 |        WhereTakeLast,Linq | 13,864,349.58 ns | 257,735.645 ns | 13,843,510.94 ns | 13,391,185.94 ns | 14,339,281.25 ns | 78,573.60 | 100000 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |         84.65 ns |       3.257 ns |         84.15 ns |         78.62 ns |         90.99 ns |      0.46 |    250 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        182.07 ns |       4.760 ns |        182.88 ns |        172.29 ns |        190.25 ns |      1.00 |    250 |
|           .NET 6.0 |        WhereTakeLast,List |      2,046.47 ns |      92.218 ns |      2,067.23 ns |      1,827.68 ns |      2,200.49 ns |     10.81 |    250 |
| .NET Framework 4.8 |        WhereTakeLast,List |      2,167.52 ns |      61.724 ns |      2,176.57 ns |      2,029.31 ns |      2,286.22 ns |     11.88 |    250 |
|           .NET 6.0 |        WhereTakeLast,Linq |     10,411.59 ns |     201.875 ns |     10,504.12 ns |      9,945.38 ns |     10,685.13 ns |     57.64 |    250 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |     35,076.76 ns |   1,406.347 ns |     35,505.44 ns |     30,737.02 ns |     37,366.30 ns |    189.56 |    250 |
|                    |                           |                  |                |                  |                  |                  |           |        |
|           .NET 6.0 |       WhereTakeLast,Array |         88.05 ns |       5.070 ns |         89.38 ns |         76.63 ns |         96.82 ns |      0.48 |   5000 |
| .NET Framework 4.8 |       WhereTakeLast,Array |        176.75 ns |       3.442 ns |        176.40 ns |        170.99 ns |        183.06 ns |      1.00 |   5000 |
| .NET Framework 4.8 |        WhereTakeLast,List |     33,823.90 ns |   1,054.987 ns |     33,785.73 ns |     32,056.08 ns |     36,202.50 ns |    190.86 |   5000 |
|           .NET 6.0 |        WhereTakeLast,List |     35,280.43 ns |   1,557.014 ns |     35,504.46 ns |     31,173.28 ns |     37,682.80 ns |    194.46 |   5000 |
|           .NET 6.0 |        WhereTakeLast,Linq |    217,237.28 ns |   4,087.014 ns |    216,344.02 ns |    211,888.75 ns |    223,899.66 ns |  1,229.39 |   5000 |
| .NET Framework 4.8 |        WhereTakeLast,Linq |    691,368.44 ns |  29,367.461 ns |    692,948.34 ns |    612,058.15 ns |    742,007.47 ns |  3,729.04 |   5000 |

> Benchmarked Version: 1.1.0 (2a9b8c08b0422c119392c1b97d441a13a5b4d653)
