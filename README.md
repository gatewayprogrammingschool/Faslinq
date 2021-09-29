# Faslinq

High-Performance Linq-Like extension methods for arrays and List<T> that avoid unnecessary allocations.

This is nowhere near ready for production, but I was recently reading about how Linq does allocations all over the places as well as multiple enumerations and that marshalling List<T> through IEnumerable<T> causes Enumerators that live in the stack to be pushed to the heap and thus cause more garbage collection.  The solution is to use List<T> whenever possible and T[] to avoid unnecessary heap allocations. 

I also was thinking about typical use cases, such as Where().Select()[.Take()] chains that are so common and created new "combo" extension methods like `SelectWhere`, `SelectTake`, `SelectWhereTake`, etc that use a single loop to do all the work.

```csharp

List<TData> data = GetFromSource<TData>();

var result = data.Where(d => d.Prop1 == 1).Select(d => (d.Prop1, d.Prop2)).Take(10).ToList();

// becomes

var result = data.SelectWhereTake(10, d => d.Prop1 == 1, d => (d.Prop1, d.Prop2));
```
