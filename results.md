# Benchmark Run at 10/6/2021 4:36:06 PM


```powershell
dotnet publish -c Release  -f net6.0 -a x64 --self-contained
```

```powershell
& .\Faslinq.Benchmarks.exe  --join -Select -Where -Take -TakeLast --platform X64
```

## Faslinq

