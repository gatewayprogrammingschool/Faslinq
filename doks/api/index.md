---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Faslinq API

* Current Release Build: [![.NET](https://github.com/gatewayprogrammingschool/Faslinq/actions/workflows/dotnet.yml/badge.svg?event=release)](https://github.com/gatewayprogrammingschool/Faslinq/actions/workflows/dotnet.yml)
* Main Brain Head Build: [![.NET](https://github.com/gatewayprogrammingschool/Faslinq/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gatewayprogrammingschool/Faslinq/actions/workflows/dotnet.yml)

Install with `dotnet add package Faslinq` and add `using Faslinq;`. Faslinq targets `net6.0`, `net5.0`, `netstandard2.1` and `netstandard2.0`, and the package is platform-neutral (AnyCPU).

Versions before 1.1.0 (1.0.0 and 1.0.5) lack several fixes described on these pages, including the `TakeLast`, `OrderBy` and `PositionCollection` behaviour.

## Conventions

These apply to every array and `List<T>` extension:

- **Predicates take the item and its index:** `Func<T, int, bool>`, written `(item, index) => …` or `(item, _) => …`. A one-parameter lambda still compiles but binds to System.Linq instead of Faslinq.
- **Selectors and sort keys take only the item:** `Func<T, TResult>`.
- **Results are computed immediately.** Each method does its work when called and returns an array (for arrays) or a new `List<T>` (for lists). For lists, the result is a new list even when the source is empty.
- **Take counts:** a count of 0 or less returns an empty result. A count larger than the source returns all of it.
- **`TakeLast` variants** take from the end of the source but return items in source order.
- **Sorting is stable.** Keys are compared with `Comparer<TKey>.Default`, and equal keys keep their source order in both `OrderBy` and `OrderByDescending`.
- **`First` and `Last`** throw `InvalidOperationException` when the source is empty or nothing matches. **`All`** returns `true` for an empty source.
- **Passing `null` as the source isn't supported.**

## Extensions

| Source Type | Docs | Code |
|---|---|---|
| `List<T>` | [docs](list) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/ListExtensions.cs) |
| Arrays | [docs](array) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/ArrayExtensions.cs) |
| `Range` | [docs](range) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/RangeExtensions.cs) |

## Collections

| Source Type | Docs | Code |
|---|---|---|
| `PositionCollection` | [docs](position-collection) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/PositionCollection.cs) |
| `ArrayEnumerator<T>` | [docs](array#arrayenumeratort) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/ArrayEnumerator.cs) |
| `IndexComparer` | [docs](range#indexcomparer) | [source](https://github.com/gatewayprogrammingschool/Faslinq/blob/main/Faslinq/IndexComparer.cs) |
