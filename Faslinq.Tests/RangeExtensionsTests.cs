namespace Faslinq.Tests;

[TestClass()]
public class RangeExtensionsTests
{
    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ContainsTest(object[] ranges)
    {
        var first = (Range)ranges[0];
        var last = (Range)ranges[^1];
        PositionCollection positions = new(0, 0);

        foreach (var r in ranges)
        {
            positions.Add((Range)r);
        }

        positions.Contains(first).Should().BeTrue();
        positions.Contains(first.Start).Should().BeTrue();
        positions.Contains(first.End.Value - 1).Should().BeTrue();
        positions.Contains(last).Should().BeTrue();
        positions.Contains(last.Start).Should().BeTrue();
        positions.Contains(last.End.Value - 1).Should().BeTrue();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void FilterTest(object[] ranges)
    {
        var first = (Range)ranges[0];
        var last = (Range)ranges[^1];
        PositionCollection positions = new(0, 0);

        foreach (var r in ranges)
        {
            positions.Add((Range)r);
        }

        var firstArray = first.ToInt32Array().Select(i => $"firstArray={i}");
        var lastArray = last.ToInt32Array().Select(i => $"lastArray={i}");
        //var shouldBeFound = firstEnd >= (lastStart - 1);

        var firstRange = Enumerable.Range(first.Start.Value, (first.End.Value - first.Start.Value))
                          .ToArray();
        var firstFound = positions.Filter(firstRange)
            .Select((i, index) => $"firstArray={i}")
            .ToArray();

        firstFound.Should().BeSubsetOf(firstArray);

        var lastRange = Enumerable.Range(last.Start.Value, (last.End.Value - last.Start.Value))
                          .ToArray();

        var lastFound = positions.Filter(lastRange)
            .Select(i => $"lastArray={i}")
            .ToArray();

        lastFound.Should().BeSubsetOf(lastArray);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void FindTest(object[] ranges)
    {
        var r = (Range)ranges[0];
        SortedList<int, Range> rangeList = new();

        rangeList.Add(r.Start.Value, r);

        var found = rangeList.Find(r.End.Value - 1);

        found.Should().BeEquivalentTo(r);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void AnyByRangeTest(object[] ranges)
    {
        var first = (Range)ranges[0];
        var last = (Range)ranges[^1];
        SortedList<int, Range> rangeList = new();

        rangeList.Add(first.Start.Value, first);

        var areSame = first.Start.Equals(last.Start) &&
                      first.End.Equals(last.End);

        rangeList.Any(first).Should().BeTrue();
        rangeList.Any(last).Should().Be(areSame);
    }

    public RangeExtensionsTests()
    {
        Debugger.Break();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void AnyByIndexTest(object[] ranges)
    {
        SortedList<int, Range> rangeList = new();

        var r = (Range)ranges[0];
        rangeList.Add(r.Start.Value, r);

        rangeList.Any(r.End.Value - 1).Should().BeTrue();
        rangeList.Any(r.End.Value).Should().BeFalse();
        rangeList.Any(r.End.Value + 1).Should().BeFalse();
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP
    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ToSpanTest(object[] ranges)
    {
        foreach (Range range in ranges)
        {
            var array = range.ToArray();

            var span = range.ToSpan();

            array.Should().BeEquivalentTo(span.ToArray());
        }
    }
#endif

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ToArrayTest(object[] ranges)
    {
        foreach (Range range in ranges)
        {
            var array = range.ToArray();

            var expectedArray = new Index[range.End.Value - range.Start.Value];
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                expectedArray[i - range.Start.Value] = new Index(i);
            }

            array.Should().BeEquivalentTo(expectedArray);
        }
    }

    public static IEnumerable<object[]> GetRangeData()
    {
        var r1 = new Range(0, 5); Debug.WriteLine(r1);
        var r2 = new Range(0, 3); Debug.WriteLine(r2);
        var r3 = new Range(5, 15); Debug.WriteLine(r3);

        yield return new object[] { new object[] { r1 } };
        yield return new object[] { new object[] { r2 } };
        yield return new object[] { new object[] { r2, r3 } };
    }
}