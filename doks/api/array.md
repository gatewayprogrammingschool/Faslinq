---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Array Extensions

Extension methods on `T[]` in `Faslinq.ArrayExtensions`. Each returns a new array (or a `Span<T>` over one) and follows the [conventions](../#conventions) for all Faslinq extensions. In the tables, `predicate` is a `Func<T, int, bool>` that receives the item and its index, and `selector` and `keySelector` are a `Func<T, TResult>` that receive just the item.

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

`First` and `Last` throw `InvalidOperationException` when the array is empty or nothing matches. `FirstOrDefault` and `LastOrDefault` return `defaultValue` in that case, on every target framework.

## Filtering, projecting and taking

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `Where(predicate)` | `T[]` | `Where(...).ToArray()` |
| `Select(selector)` | `TResult[]` | `Select(...).ToArray()` |
| `WhereSelect(predicate, selector)` | `TResult[]` | `Where(...).Select(...).ToArray()` |
| `Take(count)` | `T[]` | `Take(count).ToArray()` |
| `TakeLast(count)` | `T[]` | `TakeLast(count).ToArray()` |
| `WhereTake(predicate, count)` | `T[]` | `Where(...).Take(count).ToArray()` |
| `WhereTakeLast(predicate, count)` | `T[]` | `Where(...).TakeLast(count).ToArray()` |
| `SelectTake(selector, count)` | `TResult[]` | `Select(...).Take(count).ToArray()` |
| `SelectTakeLast(selector, count)` | `TResult[]` | `Select(...).TakeLast(count).ToArray()` |
| `WhereSelectTake(predicate, selector, count)` | `TResult[]` | `Where(...).Select(...).Take(count).ToArray()` |
| `WhereSelectTakeLast(predicate, selector, count)` | `TResult[]` | `Where(...).Select(...).TakeLast(count).ToArray()` |

The `Last` variants search from the end of the array, so they stop as soon as they have `count` items, and they return items in array order.

### Span results

Not available on `netstandard2.0`.

| Method | Returns | Same result as |
|---|---|---|
| `WhereSelectAsSpan(predicate, selector)` | `Span<TResult>` | `WhereSelect` |
| `WhereSelectTakeAsSpan(predicate, selector, count)` | `Span<TResult>` | `WhereSelectTake` |
| `WhereSelectTakeLastAsSpan(predicate, selector, count)` | `Span<TResult>` | `WhereSelectTakeLast` |

The span covers a newly allocated array, so these allocate like their array-returning versions. They only skip the final copy to an exactly sized array.

## Sorting

| Method | Returns | System.Linq equivalent |
|---|---|---|
| `OrderBy(keySelector)` | `T[]` | `OrderBy(...).ToArray()` |
| `OrderByTake(keySelector, count)` | `T[]` | `OrderBy(...).Take(count).ToArray()` |
| `OrderByTakeLast(keySelector, count)` | `T[]` | `OrderBy(...).TakeLast(count).ToArray()` |
| `OrderByDescending(keySelector)` | `T[]` | `OrderByDescending(...).ToArray()` |
| `OrderByDescendingTake(keySelector, count)` | `T[]` | `OrderByDescending(...).Take(count).ToArray()` |
| `OrderByDescendingTakeLast(keySelector, count)` | `T[]` | `OrderByDescending(...).TakeLast(count).ToArray()` |

Sorting is stable, comparing keys with `Comparer<TKey>.Default`.

## Positions

| Method | Returns |
|---|---|
| `PositionsWhere(predicate)` | [`PositionCollection`](../position-collection/) of the indexes where `predicate` is `true` |

## ArrayEnumerator&lt;T&gt;

`ArrayEnumerator<T>` is a struct `IEnumerator<T?>` over an array.

- `new ArrayEnumerator<T>(array)` starts before the first element.
- `new ArrayEnumerator<T>(array, index)` starts on `index`, so `Current` is `array[index]` and the next `MoveNext` moves to `index + 1`.
- `Current` is `default` before the first `MoveNext` and after `MoveNext` returns `false`.
- `Reset` moves back before the first element. `Dispose` does nothing.
