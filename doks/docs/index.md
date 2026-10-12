---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Documentation

## Before you start

Add `using Faslinq;`. Faslinq's extension methods work on arrays and `List<T>`, and keep System.Linq's method names.

Faslinq predicates receive each item **and its index**, so write `(agent, _) => …`, or use the index: `(agent, index) => index % 2 == 0`. A one-parameter lambda such as `agent => …` still compiles, but it binds to System.Linq instead of Faslinq.

Every call runs immediately and returns a new array or `List<T>`, so there's no `.ToList()` at the end.

The examples use this type:

```cs
record Agent(string Name, string Location, int Rank, bool CanBeatNeo);
```

## Examples

### Select

```cs
// System.Linq
List<string> locations = agents
                    .Select(agent => agent.Location)
                    .ToList();

// Faslinq
List<string> locations = agents
                    .Select(agent => agent.Location);
```

Selectors take only the item, so `Select` looks the same in both.

### Where

```cs
// System.Linq
List<Agent> smiths = agents
                    .Where(agent => agent.Name == "Smith")
                    .ToList();

// Faslinq
List<Agent> smiths = agents
                    .Where((agent, _) => agent.Name == "Smith");
```

### Take / TakeLast

```cs
// System.Linq
List<Agent> bestSquad = rankedAgents.Take(3).ToList();
List<Agent> worstSquad = rankedAgents.TakeLast(3).ToList();

// Faslinq
List<Agent> bestSquad = rankedAgents.Take(3);
List<Agent> worstSquad = rankedAgents.TakeLast(3);
```

Asking for more items than the source has returns the whole source. `TakeLast` keeps the source order. On `netstandard2.0`, which has no `TakeLast`, Faslinq also adds `TakeLast` for any `IEnumerable<T>`.

### Chaining

#### WhereSelect

```cs
// System.Linq
List<string> locations = agents
                    .Where(agent => agent.Name == "Smith")
                    .Select(agent => agent.Location)
                    .ToList();

// Faslinq
List<string> locations = agents
                    .WhereSelect(
                        (agent, _) => agent.Name == "Smith",
                        agent => agent.Location);
```

#### SelectTake

```cs
// System.Linq
List<string> locations = agents
                    .Select(agent => agent.Location)
                    .Take(3)
                    .ToList();

// Faslinq
List<string> locations = agents
                    .SelectTake(
                        agent => agent.Location,
                        3);
```

#### WhereSelectTake

```cs
// System.Linq
List<string> locations = agents
                    .Where(agent => agent.Name == "Smith")
                    .Select(agent => agent.Location)
                    .Take(2)
                    .ToList();

// Faslinq
List<string> locations = agents
                    .WhereSelectTake(
                        (agent, _) => agent.Name == "Smith",
                        agent => agent.Location,
                        2);
```

The `TakeLast` combinations (`WhereTakeLast`, `SelectTakeLast`, `WhereSelectTakeLast`) work the same way, from the end of the source, and return items in source order.

### Sorting

```cs
// System.Linq
List<Agent> byRank = agents.OrderBy(agent => agent.Rank).ToList();
List<Agent> topTwo = agents.OrderByDescending(agent => agent.Rank).Take(2).ToList();

// Faslinq
List<Agent> byRank = agents.OrderBy(agent => agent.Rank);
List<Agent> topTwo = agents.OrderByDescendingTake(agent => agent.Rank, 2);
```

Like System.Linq, Faslinq's sorts are stable: agents with equal keys keep their original order. Keys are compared with `Comparer<TKey>.Default`.

## Scalar Values

### First / FirstOrDefault / Last / LastOrDefault

```cs
// System.Linq
Agent? challenger = agents.FirstOrDefault(agent => agent.CanBeatNeo);

// Faslinq
Agent? challenger = agents.FirstOrDefault((agent, _) => agent.CanBeatNeo);

// Faslinq, with a value to use when nothing matches (on every target framework)
Agent? sacrificialLamb = agents.FirstOrDefault(
                        (agent, _) => agent.CanBeatNeo,
                        agents.Last());
```

`First` and `Last` throw `InvalidOperationException` when the source is empty or nothing matches, as System.Linq does.

## Finding positions

`PositionsWhere` returns the positions of matching items as a [`PositionCollection`](../api/position-collection/). Its `Filter` method gives back the items at those positions:

```cs
PositionCollection positions = agents.PositionsWhere((agent, _) => agent.Name == "Smith");
List<Agent> smiths = positions.Filter(agents).ToList();
```
