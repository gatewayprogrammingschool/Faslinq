---
# Page settings
layout: page
keywords: Linq Dotnet
---

# List&lt;T&gt; Extensions

Extension methods on `List<T>` in `Faslinq.ListExtensions`. Each returns a new `List<T>`, even for an empty source, and follows the [conventions](../#conventions) for all Faslinq extensions. In the tables, `predicate` is a `Func<T, int, bool>` that receives the item and its index, and `selector` and `keySelector` are a `Func<T, TResult>` that receive just the item.

## Testing elements

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `Any()` | `bool` | `Any()` |
| `Any(predicate)` | `bool` | `Any(predicate)` |
| `All(predicate)` | `bool` (`true` when empty) | `All(predicate)` |

## Single elements

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `First(predicate = null)` | `T` | `First(...)` |
| `FirstOrDefault(predicate = null, defaultValue = default)` | `T?` | `FirstOrDefault(...)` |
| `Last(predicate = null)` | `T` | `Last(...)` |
| `LastOrDefault(predicate = null, defaultValue = default)` | `T?` | `LastOrDefault(...)` |

`First` and `Last` throw `InvalidOperationException` when the list is empty or nothing matches. `FirstOrDefault` and `LastOrDefault` return `defaultValue` in that case, on every target framework.

## Filtering, projecting and taking

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `Where(predicate)` | `List<T>` | `Where(...).ToList()` |
| `Select(selector)` | `List<TResult>` | `Select(...).ToList()` |
| `WhereSelect(predicate, selector)` | `List<TResult>` | `Where(...).Select(...).ToList()` |
| `Take(count)` | `List<T>` | `Take(count).ToList()` |
| `TakeLast(count)` | `List<T>` | `TakeLast(count).ToList()` |
| `WhereTake(predicate, count)` | `List<T>` | `Where(...).Take(count).ToList()` |
| `WhereTakeLast(predicate, count)` | `List<T>` | `Where(...).TakeLast(count).ToList()` |
| `SelectTake(selector, count)` | `List<TResult>` | `Select(...).Take(count).ToList()` |
| `SelectTakeLast(selector, count)` | `List<TResult>` | `Select(...).TakeLast(count).ToList()` |
| `WhereSelectTake(predicate, selector, count)` | `List<TResult>` | `Where(...).Select(...).Take(count).ToList()` |
| `WhereSelectTakeLast(predicate, selector, count)` | `List<TResult>` | `Where(...).Select(...).TakeLast(count).ToList()` |

The `Last` variants search from the end of the list, so they stop as soon as they have `count` items, and they return items in list order.

## Sorting

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `OrderBy(keySelector)` | `List<T>` | `OrderBy(...).ToList()` |
| `OrderByTake(keySelector, count)` | `List<T>` | `OrderBy(...).Take(count).ToList()` |
| `OrderByTakeLast(keySelector, count)` | `List<T>` | `OrderBy(...).TakeLast(count).ToList()` |
| `OrderByDescending(keySelector)` | `List<T>` | `OrderByDescending(...).ToList()` |
| `OrderByDescendingTake(keySelector, count)` | `List<T>` | `OrderByDescending(...).Take(count).ToList()` |
| `OrderByDescendingTakeLast(keySelector, count)` | `List<T>` | `OrderByDescending(...).TakeLast(count).ToList()` |

Sorting is stable, comparing keys with `Comparer<TKey>.Default`.

## Positions

| Method | Returns |
|---|---|
| `PositionsWhere(predicate)` | [`PositionCollection`](../position-collection/) of the indexes where `predicate` is `true` |

## TakeLast on netstandard2.0

`netstandard2.0` has no `Enumerable.TakeLast`, so on that target `ListExtensions` also defines `TakeLast(this IEnumerable<T> source, int count)`. It enumerates the source once and returns the last `count` items in source order.
