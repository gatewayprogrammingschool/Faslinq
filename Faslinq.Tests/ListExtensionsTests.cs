namespace Faslinq.Tests;

[TestClass()]
public class ListExtensionsTests
{

    [DataTestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    public void SelectWhereTest(object toSelect)
    {
        List<dynamic> anonymous = new ();

        anonymous.Add(toSelect);

        Func<dynamic, object> pIndex = a => a.Index;
        Func<dynamic, object> pParamA = a => a.ParamA;
        Func<dynamic, object> pParamB = a => a.ParamB;

        int index = anonymous.SelectWhere(a => true, pIndex).Cast<int>().First();
        string str = anonymous.SelectWhere(a => true, pParamA).Cast<string>().First();
        double pi = anonymous.SelectWhere(a => true, pParamB).Cast<double>().First();

        str.Should().NotBeNullOrWhiteSpace();
        pi.Should().Be(Math.Pow(Math.PI, index));
    }


    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ContainsTest(Range[] ranges)
    {
        PositionCollection positions = new (0,0);

        foreach(var r in ranges)
        {
            positions.Add(r);
        }

        positions.Contains(ranges[0]).Should().BeTrue();
        positions.Contains(ranges[0].Start).Should().BeTrue();
        positions.Contains(ranges[0].End.Value-1).Should().BeTrue();
        positions.Contains(ranges[^1]).Should().BeTrue();
        positions.Contains(ranges[^1].Start).Should().BeTrue();
        positions.Contains(ranges[^1].End.Value-1).Should().BeTrue();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void FilterTest(Range[] ranges)
    {
        PositionCollection positions = new(0, 0);

        foreach (var r in ranges)
        {
            positions.Add(r);
        }

        var first = ranges[0];
        var firstArray = first.ToInt32Array().Select(i => $"firstArray={i}");
        var last = ranges[^1];
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
    public void FindTest(Range[] ranges)
    {
        SortedList<int, Range> rangeList = new();

        rangeList.Add(ranges[0].Start.Value, ranges[0]);

        var found = rangeList.Find(ranges[0].End.Value - 1);

        found.Should().BeEquivalentTo(ranges[0]);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void AnyByRangeTest(Range[] ranges)
    {
        SortedList<int, Range> rangeList = new();

        rangeList.Add(ranges[0].Start.Value, ranges[0]);

        var areSame = ranges[0].Start.Equals(ranges[^1].Start) &&
                      ranges[0].End.Equals(ranges[^1].End);

        rangeList.Any(ranges[0]).Should().BeTrue();
        rangeList.Any(ranges[^1]).Should().Be(areSame);
    }
    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void AnyByIndexTest(Range[] ranges)
    {
        SortedList<int, Range> rangeList = new();

        rangeList.Add(ranges[0].Start.Value, ranges[0]);

        rangeList.Any(ranges[0].End.Value - 1).Should().BeTrue();
        rangeList.Any(ranges[0].End.Value).Should().BeFalse();
        rangeList.Any(ranges[0].End.Value + 1).Should().BeFalse();
    }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP
    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ToSpanTest(Range[] ranges)
    {
        foreach(var range in ranges)
        {
            var array = range.ToArray();

            var span = range.ToSpan();

            array.Should().BeEquivalentTo(span.ToArray());
        }
    }
#endif

    [DataTestMethod]
    [DynamicData(nameof(GetRangeData), DynamicDataSourceType.Method)]
    public void ToArrayTest(Range[] ranges)
    {
        foreach (var range in ranges)
        {
            var array = range.ToArray();

            var expectedArray = new Index[range.End.Value - range.Start.Value];
            for(int i = range.Start.Value; i < range.End.Value; i++)
            {
                expectedArray[i - range.Start.Value] = new Index(i);
            }

            array.Should().BeEquivalentTo(expectedArray);
        }
    }

            public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { new { Index = 1, ParamA = "ParamA-1", ParamB = Math.PI } };
        yield return new object[] { new { Index = 2, ParamA = "ParamA-2", ParamB = Math.Pow(Math.PI, 2) } };
        yield return new object[] { new { Index = 3, ParamA = "ParamA-3", ParamB = Math.Pow(Math.PI, 3) } };
    }

    public static IEnumerable<object[]> GetRangeData()
    {
        yield return new object[] { new[] { new Range(0, 5) } };
        yield return new object[] { new[] { new Range(0, 3) } };
        yield return new object[] { new[] { new Range(0, 3), new Range(5, 15) } };
    }
}