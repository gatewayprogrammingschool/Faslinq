
namespace Faslinq.Tests;

public class PositionCollectionTests
{
    private TestContext? testContextInstance;
    public TestContext TestContext
    {
        get { return testContextInstance!; }
        set { testContextInstance = value; }
    }

    [DataTestMethod]
    [DataRow(new int[] { 1 })]
    [DataRow(new int[] { 1, 2 })]
    public void ConstructorIndexTests(int[] value)
    {
        PositionCollection? positions = default;

        var indices = value.Select(i => new Index(i)).ToArray();

        positions = new PositionCollection(indices[0], indices[^1]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);
    }

    [DataTestMethod]
    [DataRow(new int[] { 1 })]
    [DataRow(new int[] { 1, 2 })]
    public void ConstructorIntTests(int[] values)
    {
        PositionCollection? positions = default;

        positions = new PositionCollection(values[0], values[^1]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);
    }

    [DataTestMethod]
    [DataRow(new int[] { 1, 2, 3 })]
    [DataRow(new int[] { 1, 2, 4 })]
    [DataRow(new int[] { 1, 3, 4 })]
    public void AddIntTests(int[] values)
    {
        PositionCollection? positions = default;

        positions = new PositionCollection(values[0], values[1]);

        positions.Add(values[2]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);

        var first = new Index(values[1] + 1);
        var expected = first.Equals(values[2]) ? 1 : 2;

        positions!.Count.Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new int[] { 1, 2, 3 })]
    [DataRow(new int[] { 1, 2, 4 })]
    [DataRow(new int[] { 1, 3, 4 })]
    public void AddIndexTests(int[] values)
    {
        PositionCollection? positions = default;

        var indices = values.Select(i => new Index(i)).ToArray();

        positions = new PositionCollection(indices[0], indices[1]);

        positions.Add(indices[2]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);

        var first = new Index(indices[1].Value + 1);
        var expected = first.Equals(indices[2]) ? 1 : 2;

        positions!.Count.Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new int[] { 1, 2, 1 })]
    [DataRow(new int[] { 1, 2, 2 })]
    [DataRow(new int[] { 1, 3, 2 })]
    public void RemoveIntTests(int[] values)
    {
        PositionCollection? positions = default;

        positions = new PositionCollection(values[0], values[1]);

        positions.Remove(values[2]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);

        var first = values[0];
        var second = values[1];
        var third = values[2];

        var expected = first < third && third < second ? 2 : 1;

        positions!.Count.Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new int[] { 1, 2, 1 })]
    [DataRow(new int[] { 1, 2, 2 })]
    [DataRow(new int[] { 1, 3, 2 })]
    public void RemoveIndexTests(int[] values)
    {
        PositionCollection? positions = default;

        var indices = values.Select(i => new Index(i)).ToArray();

        positions = new PositionCollection(indices[0], indices[1]);

        positions.Remove(indices[2]);

        positions?.Should().NotBeNull();
        positions!.Count.Should().NotBe(0);

        var first = indices[0];
        var second = indices[1];
        var third = indices[2];

        var expected = first.Value < third.Value && third.Value < second.Value ? 2 : 1;

        positions!.Count.Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new int[] { 0, 2, 0 })]
    [DataRow(new int[] { 0, 2, 1 })]
    [DataRow(new int[] { 0, 2, 2 })]
    [DataRow(new int[] { 0, 2, 3 })]
    public void FindIntTests(int[] values)
    {
        PositionCollection? positions = default;

        var indices = values.Select(i => new Index(i)).ToArray();

        positions = new PositionCollection(indices[2], indices[2]);

        Index result = default;

        List<Index> source = new(indices);

        Func<Index> comparison = () =>
        {
            var filtered = positions.Filter(source);

            return filtered.FirstOrDefault();
        };

        result = comparison.Invoke();

        if (values[2] > values[1])
        {
            result.Should().Be(default(Index));
        }
        else
        {
            result.Value.Should().BeGreaterOrEqualTo(values[0]);
            result.Value.Should().BeLessOrEqualTo(values[1]);
        }
    }


    [DataTestMethod]
    [DataRow(new int[] { 0, 2, 0 })]
    [DataRow(new int[] { 0, 2, 1 })]
    [DataRow(new int[] { 0, 2, 2 })]
    [DataRow(new int[] { 0, 2, 3 })]
    public void FindIndexTests(int[] values)
    {
        PositionCollection? positions = default;

        positions = new PositionCollection(values[2], values[2]);

        int result = default;

        List<int> source = new(values);

        Func<int> comparison = () =>
        {
            var filtered = positions.Filter(source);

            return filtered.FirstOrDefault();
        };

        result = comparison.Invoke();

        if (values[2] > values[1])
        {
            result.Should().Be(default);
        }
        else
        {
            result.Should().BeGreaterOrEqualTo(values[0]);
            result.Should().BeLessOrEqualTo(values[1]);
        }
    }

    public IEnumerable<object[]> GetIndicesForTest()
    {
        yield return (new Index[] { 3 }).As<object[]>();
        yield return (new Index[] { 3, 5 }).As<object[]>();
    }
}
