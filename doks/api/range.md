---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Range Extensions

Extension methods on `System.Range` in `Faslinq.RangeExtensions`. They treat a range the way `System.Range` does: the start is included and the end is excluded, so `2..5` covers 2, 3 and 4.

## Positions in a range

| Method | Returns |
|---|---|
| `Contains(index)` | `true` when `Start <= index < End` |
| `ToArray()` | `Index[]` of every position in the range |
| `ToInt32Array()` | `int[]` of every position in the range |
| `ToSpan()` | `Span<Index>` over a new array of every position. Not available on `netstandard2.0`. |

```cs
(2..5).Contains(4);      // true
(2..5).Contains(5);      // false
(2..5).ToInt32Array();   // [2, 3, 4]
```

These methods need both ends counted from the start. Without a collection length, a from-end index such as `^1` can't be turned into a position, so they throw `ArgumentException` for ranges like `^3..` or `1..^1`. `ToArray`, `ToInt32Array` and `ToSpan` also throw `ArgumentException` for a range that ends before it starts, such as `5..3`. To use a from-end range with a collection, resolve it first with `range.GetOffsetAndLength(length)`.

## Searching a SortedList&lt;int, Range&gt;

These are used by [`PositionCollection`](../position-collection/), which keys each range by its start.

| Method | Returns |
|---|---|
| `Find(index)` | The first range that contains `index`, or `default(Range)` (`0..0`) if none does |
| `Find(range)` | The range equal to `range`, or `default(Range)` if there isn't one |
| `Any(index)` | Whether any range contains `index` |
| `Any(range)` | Whether any range equals `range` |

## IndexComparer

`IndexComparer` is an `IEqualityComparer<Index>` that compares with `Index.Equals`. Use the shared instance, `IndexComparer.Default`.
