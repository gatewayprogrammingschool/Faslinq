---
# Page settings
layout: page
keywords: Linq Dotnet
---

# PositionCollection

`PositionCollection` holds a set of positions (zero-based indexes into an array or list), stored as ranges. `PositionsWhere` on [arrays](../array/) and [lists](../list/) returns one, and `Filter` turns it back into the items at those positions.

```cs
PositionCollection smiths = agents.PositionsWhere((agent, _) => agent.Name == "Smith");

foreach (Agent agent in smiths.Filter(agents))
{
    // each agent named Smith, in list order
}
```

Ranges follow the `System.Range` convention: the start is included and the end is excluded. Neighbouring positions are merged, so the positions 0, 1, 2 and 5 are stored as `0..3` and `5..6`.

## Creating

| Constructor | Contents |
|---|---|
| `new PositionCollection()` | Empty |
| `new PositionCollection(start, end)` | The positions from `start` up to, but not including, `end`. Empty when `end <= start`. |

## Adding and removing

| Member | Effect |
|---|---|
| `Add(int index)` / `Add(Index index)` | Adds one position and merges it with neighbouring ranges. `Add(int)` returns the range that now contains it. Throws `ArgumentOutOfRangeException` for a negative position. |
| `Add(Range range)` | Stores `range` as given, replacing any range with the same start. It doesn't merge or check for overlaps, so positions shared by overlapping ranges appear more than once in `Filter`, `ForEach`, `CopyTo(Index[], …)` and position enumeration. |
| `Remove(Index index)` | Removes one position, splitting its range if needed. Returns `false` if the position isn't there. |
| `Remove(Range range)` | Removes a stored range that is exactly `range`. Throws `IndexOutOfRangeException` if there isn't one. |
| `Clear()` | Removes everything. |

## Reading

| Member | Returns |
|---|---|
| `Contains(Index index)` | Whether the position is in the collection |
| `Contains(Range range)` | Whether exactly that range is stored |
| `Count` | The number of **ranges**, not positions |
| `Start`, `End` | The start and end of the range most recently added or changed |
| `this[int start]` | The stored range that begins at `start`. Throws `KeyNotFoundException` if no range begins there. |
| `Filter(T[] source)`, `Filter(List<T> source)` | The items at each position, in ascending order. Positions past the end of `source` are skipped. |
| `ForEach(List<T> source, Action<T> action)` | Runs `action` on the item at each position, range by range. That's ascending order unless ranges overlap. |
| `CopyTo(Range[] array, int arrayIndex)` | Copies the ranges. Throws `OverflowException` if they don't fit. |
| `CopyTo(Index[] array, int arrayIndex)` | Copies every position, range by range. Throws `OverflowException` if they don't fit. |

`foreach` over a `PositionCollection` gives its ranges, in ascending order. The class implements both `IEnumerable<Range>` and `IEnumerable<Index>`, so for LINQ, state which one you want: `((IEnumerable<Range>)positions).Select(...)` gives ranges, and `((IEnumerable<Index>)positions)` gives each position, range by range.

## Limitations

- `IndexOf`, `Insert` and `RemoveAt` throw `NotImplementedException`.
- `PositionCollection` is a `record`, but its generated equality compares the internal storage by reference. Two collections holding the same positions are not `Equal`.
