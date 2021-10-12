---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Benchmark Run at 10/11/2021 3:06:20 AM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe  --join --filter * --platform X64
```

## Faslinq
