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

Linq can also be used on data structures in already in your application's memory space, such as data stored in an array or `List<T>` collection.  When querying these types of structures we typically are using the results right away and so Lazy Loading has little benefit for us.  Microsoft does try to provide some help for improving performance when using Linq with arrays and `List<T>` by providing enumerators implemented with structs.  Unfortunately, using Linq's extension methods marshals the list or array through `IEnumerable<T>` which causes the enumerators to be boxed and moved to the heap, thus eliminating the advantage of using a struct.

Faslinq is a library of Linq-like extension methods for `List<T>` and arrays that speeds up query and filter operations by providing combined overloads of common patterns.

You're mission is to send five Starfleet Captains on a mission to Alpha Centauri from the ships currently in the Earth sector.

```csharp
// Using Linq
var fleet = Starfleet.GetShipRegistry();
List<Captain> captains = fleet.Where(ship => ship.Location.Sector == 0)
                    .Select(ship => ship.Captain)
                    .Take(5)
                    .ToList();

// Using Faslinq
List<Ship> fleet = Starfleet.GetShipRegistryList();
List<Captain> captains = fleet.WhereSelectTake(
                    ship => ship.Location.Sector == 0,
                    ship => ship.Captain,
                    5);
```

Using the composite extension methods in Faslinq we are able to execute a single loop that is at most `O(n)` and as little as `O(5)`.  With Linq, the `Where` executes over the whole set of data before `Select` extracts all the captains from the filtered data into a new collection and then returns back up to five captains in another collection, and finally allocating a new `List<Captain>` collection for the result.

## Resources

* [Optimising LINQ](https://mattwarren.org/2016/09/29/Optimising-LINQ/)
* [LINQ performance FAQ](https://stackoverflow.com/questions/4044400/linq-performance-faq)
* [Preventing unnecessary allocation in .NET collections](https://nede.dev/blog/preventing-unnecessary-allocation-in-net-collections)
