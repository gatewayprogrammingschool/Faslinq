namespace Faslinq.Benchmarks.Collections;

public abstract class CollectionBenchmarkBase : BenchmarkBase
{
    protected abstract IEnumerable<TData> LinqControl<TData>(object item);

    public void Test(object[] item, Tests test)
    {
        var collection = item[0]
            .As<IEnumerable<TestValueTuple>>();

        var first = collection
            .FirstOrDefault()
            .As<object>();

        var linqSource = new object[]
        {
            collection
                .Select(i => i.As<object>())
                .ToArray(),
        };

        if (first is TestValueTuple tuple)
        {
            // Hand ProcessCollection the shape the test names; it skips any other shape.
            IEnumerable<TestValueTuple> source = test switch
            {
                Tests.List => collection.ToList(),
                Tests.Array => collection.ToArray(),
                _ => collection,
            };

            var results = ProcessCollection(
                test,
                new object[] { source, },
                tuple).ToList();

            var expected = LinqControl<TestValueTuple>(linqSource).ToList();

            results.Should()
                .NotBeNull();
            results.Should()
                .BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
        else
        {
            throw new ArgumentException("item is not a collection of TestValueTuple objects.", nameof(collection));
        }
    }
}
