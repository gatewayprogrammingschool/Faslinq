# Faslinq

[Documentation](https://gatewayprogrammingschool.github.io/Faslinq/) · [NuGet](https://www.nuget.org/packages/Faslinq/)

High-performance, LINQ-like extension methods for arrays and `List<T>` that avoid unnecessary allocations.

This is nowhere near ready for production, but I was recently reading about how Linq does allocations all over the places as well as multiple enumerations and that marshalling List<T> through IEnumerable<T> causes Enumerators that live in the stack to be pushed to the heap and thus cause more garbage collection.  The solution is to use List<T> whenever possible and T[] to avoid unnecessary heap allocations.

I also was thinking about typical use cases, such as Where().Select()[.Take()] chains that are so common and created new "combo" extension methods like `WhereSelect`, `SelectTake`, `WhereSelectTake`, etc that use a single loop to do all the work.

```csharp
using Faslinq;

List<Agent> agents = GetAgents();

// System.Linq
List<string> viaLinq = agents
    .Where(agent => agent.Name == "Smith")
    .Select(agent => agent.Location)
    .Take(10)
    .ToList();

// Faslinq: one loop, one result list
List<string> viaFaslinq = agents.WhereSelectTake(
    (agent, _) => agent.Name == "Smith",
    agent => agent.Location,
    10);
```

## Things to know

- **Predicates take the item and its index.** Write `(agent, _) => …`. A one-parameter lambda such as `agent => …` still compiles, but it calls System.Linq instead of Faslinq.
- **Results are computed immediately.** Each call returns a new array or `List<T>`. Nothing is deferred, as it would be with System.Linq.
- **Faslinq uses the same method names as System.Linq** (`Where`, `Select`, `First`, `Take` and so on). With `using Faslinq;`, calls on arrays and lists that match a Faslinq overload bind to Faslinq.
- **Behaviour follows System.Linq:**
  - `First` and `Last` throw `InvalidOperationException` when nothing matches.
  - `All` is `true` for an empty source.
  - `OrderBy` and `OrderByDescending` are stable.
  - Take counts larger than the source return the whole source.
  - `TakeLast` variants keep source order.

The released packages (1.0.0 and 1.0.5) predate several of these fixes, which ship in the next release.

## Supported frameworks

`net6.0`, `net5.0`, `netstandard2.1` and `netstandard2.0`. The package is platform-neutral (AnyCPU). On `netstandard2.0`, Faslinq also provides `IEnumerable<T>.TakeLast`, which that framework lacks.

## Building and testing

```bash
dotnet build Faslinq.sln
dotnet test Faslinq.Tests/Faslinq.Tests.csproj
```

The build runs GitVersion, which needs the full git history; in a shallow clone, run `git fetch --unshallow` first. `Faslinq.Tests` includes `BenchmarkTests`, which check that each benchmark's Faslinq path returns the same results as its System.Linq control. Benchmarks run from `Faslinq.Benchmarks` using `bench.ps1`.
