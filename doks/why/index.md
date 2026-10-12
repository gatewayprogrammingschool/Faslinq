---
# Page settings
layout: page
keywords: Linq Dotnet

# Hero section
title: Faslinq
description: Faster. Linq.
---

# Why Faslinq?

> Answer: Because not all use cases for Linq are lazy.

Linq is a great part of the Dotnet ecosystem and enables many scenarios to be implemented with common patterns.  When used as the door way to data on remote systems it becomes extremely valuable for being able to delay query execution and build up context to create better queries against the data source, then executing those queries at the last second.  This delayed execution is also known as Lazy Loading.

Linq can also be used on data structures already in your application's memory space, such as data stored in an array or `List<T>` collection.  When querying these types of structures we typically are using the results right away and so Lazy Loading has little benefit for us.  Microsoft does try to provide some help for improving performance when using Linq with arrays and `List<T>` by providing enumerators implemented with structs.  Unfortunately, using Linq's extension methods marshals the list or array through `IEnumerable<T>` which causes the enumerators to be boxed and moved to the heap, thus eliminating the advantage of using a struct.

Faslinq is a library of Linq-like extension methods for `List<T>` and arrays that speeds up query and filter operations by providing combined overloads of common patterns.

## An Out of This World Example

Your orders are to send up to five Starfleet Captains on a mission to Alpha Centauri from the ships currently in the Earth sector.

```csharp
// Using Linq
List<Ship> fleet = Starfleet.GetShipRegistry();
List<Captain> viaLinq = fleet.Where(ship => ship.Location.Sector == 0)
                    .Select(ship => ship.Captain)
                    .Take(5)
                    .ToList();

// Using Faslinq
List<Captain> viaFaslinq = fleet.WhereSelectTake(
                    (ship, _) => ship.Location.Sector == 0,
                    ship => ship.Captain,
                    5);
```

Faslinq's predicates receive each item and its index, so the Faslinq version writes `(ship, _) =>`. A one-parameter lambda such as `ship => …` would compile too, but it would call Linq's `Where` instead.

Both versions stop once they have five captains. Linq streams each ship through a chain of iterators: `Where`, then `Select`, then `Take`, then `ToList`. Each stage is a separate object that calls the next through `IEnumerable<T>`, and `ToList` grows its list as items arrive. `WhereSelectTake` does the same work in one loop over the list, with no iterator objects, and writes into a single result list.

## Resources

* [Optimising LINQ](https://mattwarren.org/2016/09/29/Optimising-LINQ/)
* [LINQ performance FAQ](https://stackoverflow.com/questions/4044400/linq-performance-faq)
* [Preventing unnecessary allocation in .NET collections](https://nede.dev/blog/preventing-unnecessary-allocation-in-net-collections)
