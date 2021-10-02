namespace Faslinq.Tests;


[TestClass()]
public class ListExtensionsTests
{
    #region Any / All Tests
    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleAnyTest(TestValueTuple? toSelect = null)
    {
        var tuples = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.Any(tuples, a => true).Should().BeTrue();
        ListExtensions.Any(tuples, a => false).Should().BeFalse();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleEmptyAnyTest(TestValueTuple? toSelect = null)
    {
        var tuples = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.Any(tuples).Should().BeTrue();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleAllTest(TestValueTuple? toSelect = null)
    {
        var tuples = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.All(tuples, a => true).Should().BeTrue();
        ListExtensions.All(tuples, a => false).Should().BeFalse();
    }
    #endregion Any / All Tests

    #region First / Last Tests
    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleFirstTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.First(anonymous, a => true)!.Should().Be(toSelect ?? default);

        Action a = () => ListExtensions.First(anonymous, a => false);
        a.Should().Throw<ArgumentException>();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleLastTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.Last(anonymous, a => true)!.Should().Be(toSelect ?? default);

        Action a = () => ListExtensions.Last(anonymous, a => false);
        a.Should().Throw<ArgumentException>();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleFirstOrDefaultTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.FirstOrDefault(anonymous, a => true)!.Should().Be(toSelect ?? default);
        ListExtensions.FirstOrDefault(anonymous, a => false).Should().Be(default);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleLastOrDefaultTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        ListExtensions.LastOrDefault(anonymous, a => true)!.Should().Be(toSelect ?? default);
        ListExtensions.LastOrDefault(anonymous, a => false).Should().Be(default);
    }
    #endregion First / Last Tests

    #region Where Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousWhereTest(object? toSelect = null)
    {
        var anonymous = new List<dynamic?>() { toSelect ?? default };
        var expected = ((dynamic?)toSelect)?.Index;
        object? first = ListExtensions.Where(
                anonymous,
                a => a?.Index == expected)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        object? first = ListExtensions.Where(anonymous, a => a.Item1 == toSelect?.Item1).FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect ?? default);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ListExtensions.Where(list, i => i.Item1 == list[0].Item1);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(1, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.WhereTake(list, i => i.Item1 == list[0].Item1, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
        result[1].Item1.Should().Be(list![0].Item1);
        result[1].Item2.Should().Be(list[0].Item2);
        result[1].Item3.Should().Be(list[0].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();
        var first = list.Count - 2;

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.WhereTakeLast(list, i => i.Item1 == list[first].Item1, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![first].Item1);
        result[0].Item2.Should().Be(list[first].Item2);
        result[0].Item3.Should().Be(list[first].Item3);
        result[1].Item1.Should().Be(list![first].Item1);
        result[1].Item2.Should().Be(list[first].Item2);
        result[1].Item3.Should().Be(list[first].Item3);
    }
    #endregion WhereSelect Tests

    #region Select Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousWhereSelectTest(object? toSelect = null)
    {
        var anonymous = new List<dynamic?>() { toSelect ?? default };
        var expected = ((dynamic?)toSelect)?.Index;
        object? first = ListExtensions.WhereSelect(
                anonymous,
                a => a?.Index == expected,
                i => i)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        Func<TestValueTuple, int> pIndex = a => a.Item1;
        Func<TestValueTuple, string> pParamA = a => a.Item2;
        Func<TestValueTuple, double> pParamB = a => a.Item3;

        int? index = anonymous.Select(pIndex).FirstOrDefault();
        string? str = anonymous.Select(pParamA).FirstOrDefault();
        double? pi = anonymous.Select(pParamB).FirstOrDefault();

        if (toSelect is null) return;

        str.Should().NotBeNullOrWhiteSpace();
        pi.Should().Be(Math.Pow(Math.PI, index ?? 0));
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTuplePositionsWhereTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var expected = list.Select((i, index) => (index, i.Item1 == 1))
                            .Where(t => t.Item2)
                            .Select(t => t.Item1)
                            .ToList();

        var expectedPositions = new PositionCollection(0, 0);

        expected.ForEach(index => expectedPositions.Add(index));

        IEnumerable<Range> finished = expectedPositions;

        IEnumerable<Range> result = ListExtensions.PositionsWhere(list, i => i.Item1 == 1);

        result.Should().BeEquivalentTo(finished);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ListExtensions.Select(list, i => i);

        result.Should().NotBeNull();
        result!.Count.Should().Be(list.Count);
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.SelectTake(list, i => i, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
        result[1].Item1.Should().Be(list![1].Item1);
        result[1].Item2.Should().Be(list[1].Item2);
        result[1].Item3.Should().Be(list[1].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();
        var first = list.Count - 2;
        var last = list.Count - 1;

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.SelectTakeLast(list, i => i, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![first].Item1);
        result[0].Item2.Should().Be(list[first].Item2);
        result[0].Item3.Should().Be(list[first].Item3);
        result[1].Item1.Should().Be(list![last].Item1);
        result[1].Item2.Should().Be(list[last].Item2);
        result[1].Item3.Should().Be(list[last].Item3);
    }
    #endregion WhereSelect Tests

    #region WhereSelect Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousSelectTest(object? toSelect = null)
    {
        var anonymous = new List<dynamic?>() { toSelect ?? default };
        object? first = ListExtensions.Select(
                anonymous,
                i => i)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleSelectTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new List<TestValueTuple>() { toSelect ?? default };

        Func<TestValueTuple, int> pIndex = a => a.Item1;
        Func<TestValueTuple, string> pParamA = a => a.Item2;
        Func<TestValueTuple, double> pParamB = a => a.Item3;

        int? index = anonymous.Select(pIndex).FirstOrDefault();
        string? str = anonymous.Select(pParamA).FirstOrDefault();
        double? pi = anonymous.Select(pParamB).FirstOrDefault();

        if (toSelect is null) return;

        str.Should().NotBeNullOrWhiteSpace();
        pi.Should().Be(Math.Pow(Math.PI, index ?? 0));
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleSelectMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ListExtensions.Select(list, i => i);

        result.Should().NotBeNull();
        result!.Count.Should().Be(list.Count);
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleSelectTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.SelectTake(list, i => i, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
        result[1].Item1.Should().Be(list![1].Item1);
        result[1].Item2.Should().Be(list[1].Item2);
        result[1].Item3.Should().Be(list[1].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleSelectTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();
        var first = list.Count - 2;
        var last = list.Count - 1;

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ListExtensions.SelectTakeLast(list, i => i, 2);

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![first].Item1);
        result[0].Item2.Should().Be(list[first].Item2);
        result[0].Item3.Should().Be(list[first].Item3);
        result[1].Item1.Should().Be(list![last].Item1);
        result[1].Item2.Should().Be(list[last].Item2);
        result[1].Item3.Should().Be(list[last].Item3);
    }
    #endregion WhereSelect Tests

    public ListExtensionsTests()
    {
        Debugger.Break();
    }

    #region Take & TakeLast
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.Take(list, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![0].Item1);
        result[0].Item2.Should().Be(list[0].Item2);
        result[0].Item3.Should().Be(list[0].Item3);
        result[1].Item1.Should().Be(list![1].Item1);
        result[1].Item2.Should().Be(list[1].Item2);
        result[1].Item3.Should().Be(list[1].Item3);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();
        var first = list.Count - 2;
        var last = list.Count - 1;

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.TakeLast(list, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));
        if (result.Count == 0) return;
        result[0].Item1.Should().Be(list![first].Item1);
        result[0].Item2.Should().Be(list[first].Item2);
        result[0].Item3.Should().Be(list[first].Item3);
        result[1].Item1.Should().Be(list![last].Item1);
        result[1].Item2.Should().Be(list[last].Item2);
        result[1].Item3.Should().Be(list[last].Item3);
    }
    #endregion Take & TakeLast

    #region OrderBy Tests
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderBy(list, i => i.Item1)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(list.Count);

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1);
        result.Should().BeEquivalentTo(linqSorted);

        result.FirstOrDefault().Item1.Should().Be(linqSorted!.FirstOrDefault().Item1);
        result.FirstOrDefault().Item2.Should().Be(linqSorted.FirstOrDefault().Item2);
        result.FirstOrDefault().Item3.Should().Be(linqSorted.FirstOrDefault().Item3);
        result.LastOrDefault().Item1.Should().Be(linqSorted!.LastOrDefault().Item1);
        result.LastOrDefault().Item2.Should().Be(linqSorted.LastOrDefault().Item2);
        result.LastOrDefault().Item3.Should().Be(linqSorted.LastOrDefault().Item3);

    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderByTake(list, i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).Take(2);
        result.Should().BeEquivalentTo(linqSorted);

        result.FirstOrDefault().Item1.Should().Be(linqSorted!.FirstOrDefault().Item1);
        result.FirstOrDefault().Item2.Should().Be(linqSorted.FirstOrDefault().Item2);
        result.FirstOrDefault().Item3.Should().Be(linqSorted.FirstOrDefault().Item3);
        result.LastOrDefault().Item1.Should().Be(linqSorted!.LastOrDefault().Item1);
        result.LastOrDefault().Item2.Should().Be(linqSorted.LastOrDefault().Item2);
        result.LastOrDefault().Item3.Should().Be(linqSorted.LastOrDefault().Item3);
    }

#if !NETFRAMEWORK
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderByTakeLast(list, i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).TakeLast(2);
        result.Should().BeEquivalentTo(linqSorted);

        result.FirstOrDefault().Item1.Should().Be(linqSorted!.FirstOrDefault().Item1);
        result.FirstOrDefault().Item2.Should().Be(linqSorted.FirstOrDefault().Item2);
        result.FirstOrDefault().Item3.Should().Be(linqSorted.FirstOrDefault().Item3);
        result.LastOrDefault().Item1.Should().Be(linqSorted!.LastOrDefault().Item1);
        result.LastOrDefault().Item2.Should().Be(linqSorted.LastOrDefault().Item2);
        result.LastOrDefault().Item3.Should().Be(linqSorted.LastOrDefault().Item3);
    }
#endif
    #endregion OrderBy Tests

    #region OrderByDescending
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByDescendingTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderByDescending(list, i => i.Item1)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(list.Count);

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1);
        result.Should().BeEquivalentTo(linqSorted);

        result.FirstOrDefault().Item1.Should().Be(linqSorted!.FirstOrDefault().Item1);
        result.FirstOrDefault().Item2.Should().Be(linqSorted.FirstOrDefault().Item2);
        result.FirstOrDefault().Item3.Should().Be(linqSorted.FirstOrDefault().Item3);
        result.LastOrDefault().Item1.Should().Be(linqSorted!.LastOrDefault().Item1);
        result.LastOrDefault().Item2.Should().Be(linqSorted.LastOrDefault().Item2);
        result.LastOrDefault().Item3.Should().Be(linqSorted.LastOrDefault().Item3);

    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByDescendingTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderByDescendingTake(list, i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).Take(2);
        result.Should().BeEquivalentTo(linqSorted);

        result.FirstOrDefault().Item1.Should().Be(linqSorted!.FirstOrDefault().Item1);
        result.FirstOrDefault().Item2.Should().Be(linqSorted.FirstOrDefault().Item2);
        result.FirstOrDefault().Item3.Should().Be(linqSorted.FirstOrDefault().Item3);
        result.LastOrDefault().Item1.Should().Be(linqSorted!.LastOrDefault().Item1);
        result.LastOrDefault().Item2.Should().Be(linqSorted.LastOrDefault().Item2);
        result.LastOrDefault().Item3.Should().Be(linqSorted.LastOrDefault().Item3);

    }

#if !NETFRAMEWORK
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleOrderByDescendingTakeLastTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        var result = ListExtensions.OrderByDescendingTakeLast(list, i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Count.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).TakeLast(2);
        result.Should().BeEquivalentTo(linqSorted);
    }
#endif
    #endregion OrderByDescending

    #region Data
    public static IEnumerable<object[]> GetAnonymousTestData()
    {
        yield return new object[] { new { Index = 1, ParamA = "ParamA-1", ParamB = Math.PI } };
        yield return new object[] { new { Index = 2, ParamA = "ParamA-2", ParamB = Math.Pow(Math.PI, 2) } };
        yield return new object[] { new { Index = 3, ParamA = "ParamA-3", ParamB = Math.Pow(Math.PI, 3) } };
    }

    public static IEnumerable<object[]> GetEmptyAnonymousTestData()
    {
        yield return new dynamic[0];
    }

    public static IEnumerable<object[]> GetValueTupleTestData()
    {
        yield return new object[] { (3, "ParamA-3", Math.Pow(Math.PI, 3)) };
        yield return new object[] { (1, "ParamA-1", Math.PI) };
        yield return new object[] { (2, "ParamA-2", Math.Pow(Math.PI, 2)) };
    }

    public static IEnumerable<object[]> GetEmptyValueTupleTestData()
    {
        yield return new dynamic[0];
    }

    public static IEnumerable<object[]> GetTestDataMethodsTestData()
    {
        var array = GetValueTupleTestData()!.SelectMany(i => i!)!.ToArray();
        object[] list = new object[] { (data: array, length: array.Length) };
        return new[] { list };
    }

    public static IEnumerable<object[]> GetEmptyTestDataMethodsTestData()
    {
        var array = new object[0];
        object[] list = new object[] { (data: array, length: array.Length) };
        return new[] { list };
    }
    #endregion Data
}


//namespace Faslinq.Tests;

//using System.Collections.Generic;

//using TestValueTuple = System.ValueTuple<int, string, double>;

//[TestClass()]
//public class ListExtensionsTests
//{
//    #region Any / All Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleAnyTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> tuples = new();
//        tuples.Add(toSelect);

//        ListExtensions.Any(tuples, a => true).Should().BeTrue();
//        ListExtensions.Any(tuples, a => false).Should().BeFalse();
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleEmptyAnyTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> tuples = new();
//        tuples.Add(toSelect);

//        ListExtensions.Any(tuples).Should().BeTrue();
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleAllTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> tuples = new();
//        tuples.Add(toSelect);

//        ListExtensions.All(tuples, a => true).Should().BeTrue();
//        ListExtensions.All(tuples, a => false).Should().BeFalse();
//    }
//    #endregion Any / All Tests

//    #region First / Last Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleFirstTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();
//        anonymous.Add(toSelect);

//        ListExtensions.First(anonymous, a => true)!.Should().Be(toSelect ?? default);

//        Action a = () => ListExtensions.First(anonymous, a => false);
//        a.Should().Throw<ArgumentException>();
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleLastTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();
//        anonymous.Add(toSelect);

//        ListExtensions.Last(anonymous, a => true)!.Should().Be(toSelect ?? default);

//        Action a = () => ListExtensions.Last(anonymous, a => false);
//        a.Should().Throw<ArgumentException>();
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleFirstOrDefaultTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();
//        anonymous.Add(toSelect);

//        ListExtensions.FirstOrDefault(anonymous, a => true)!.Should().Be(toSelect ?? default);
//        ListExtensions.FirstOrDefault(anonymous, a => false).Should().Be(default);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleLastOrDefaultTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();
//        anonymous.Add(toSelect);

//        ListExtensions.LastOrDefault(anonymous, a => true)!.Should().Be(toSelect ?? default);
//        ListExtensions.LastOrDefault(anonymous, a => false).Should().Be(default);
//    }
//    #endregion First / Last Tests

//    #region Where Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
//    public void AnonymousWhereTest(object toSelect)
//    {
//        List<dynamic> anonymous = new();
//        anonymous.Add(toSelect);

//        object first = ListExtensions.Where(anonymous, a => a.Index == ((dynamic)toSelect).Index)[0];

//        first.Should().BeEquivalentTo(toSelect);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();

//        anonymous.Add(toSelect);

//        object first = ListExtensions.Where(anonymous, a => a.Item1 == toSelect.Item1).First();

//        first.Should().BeEquivalentTo(toSelect);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereMultipleTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        var result = ListExtensions.Where(list, i => i.Item1 == list[0].Item1);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(1);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.WhereTake(list, 2, i => i.Item1 == list[0].Item1);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//        result[1].Item1.Should().Be(list![0].Item1);
//        result[1].Item2.Should().Be(list[0].Item2);
//        result[1].Item3.Should().Be(list[0].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();
//        var first = list.Count - 2;

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.WhereTakeLast(list, 2, i => i.Item1 == list[first].Item1);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![first].Item1);
//        result[0].Item2.Should().Be(list[first].Item2);
//        result[0].Item3.Should().Be(list[first].Item3);
//        result[1].Item1.Should().Be(list![first].Item1);
//        result[1].Item2.Should().Be(list[first].Item2);
//        result[1].Item3.Should().Be(list[first].Item3);
//    }
//    #endregion WhereSelect Tests

//    #region Select Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
//    public void AnonymousWhereSelectTest(object toSelect)
//    {
//        List<dynamic> anonymous = new();

//        anonymous.Add(toSelect);

//        Func<dynamic, object> pIndex = a => a.Index;
//        Func<dynamic, object> pParamA = a => a.ParamA;
//        Func<dynamic, object> pParamB = a => a.ParamB;

//        int index = anonymous.Select(pIndex).Cast<int>().First();
//        string str = anonymous.Select(pParamA).Cast<string>().First();
//        double pi = anonymous.Select(pParamB).Cast<double>().First();

//        str.Should().NotBeNullOrWhiteSpace();
//        pi.Should().Be(Math.Pow(Math.PI, index));
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereSelectTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();

//        anonymous.Add(toSelect);

//        Func<TestValueTuple, int> pIndex = a => a.Item1;
//        Func<TestValueTuple, string> pParamA = a => a.Item2;
//        Func<TestValueTuple, double> pParamB = a => a.Item3;

//        int index = anonymous.Select(pIndex).First();
//        string str = anonymous.Select(pParamA).First();
//        double pi = anonymous.Select(pParamB).First();

//        str.Should().NotBeNullOrWhiteSpace();
//        pi.Should().Be(Math.Pow(Math.PI, index));
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereSelectMultipleTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        var result = ListExtensions.Select(list, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(list.Count);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereSelectTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.SelectTake(list, 2, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//        result[1].Item1.Should().Be(list![1].Item1);
//        result[1].Item2.Should().Be(list[1].Item2);
//        result[1].Item3.Should().Be(list[1].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleWhereSelectTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();
//        var first = list.Count - 2;
//        var last = list.Count - 1;

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.SelectTakeLast(list, 2, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![first].Item1);
//        result[0].Item2.Should().Be(list[first].Item2);
//        result[0].Item3.Should().Be(list[first].Item3);
//        result[1].Item1.Should().Be(list![last].Item1);
//        result[1].Item2.Should().Be(list[last].Item2);
//        result[1].Item3.Should().Be(list[last].Item3);
//    }
//    #endregion WhereSelect Tests

//    #region WhereSelect Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
//    public void AnonymousSelectTest(object toSelect)
//    {
//        List<dynamic> anonymous = new();

//        anonymous.Add(toSelect);

//        Func<dynamic, object> pIndex = a => a.Index;
//        Func<dynamic, object> pParamA = a => a.ParamA;
//        Func<dynamic, object> pParamB = a => a.ParamB;

//        int index = anonymous.Select(pIndex).Cast<int>().First();
//        string str = anonymous.Select(pParamA).Cast<string>().First();
//        double pi = anonymous.Select(pParamB).Cast<double>().First();

//        str.Should().NotBeNullOrWhiteSpace();
//        pi.Should().Be(Math.Pow(Math.PI, index));
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleSelectTest(TestValueTuple toSelect)
//    {
//        List<TestValueTuple> anonymous = new();

//        anonymous.Add(toSelect);

//        Func<TestValueTuple, int> pIndex = a => a.Item1;
//        Func<TestValueTuple, string> pParamA = a => a.Item2;
//        Func<TestValueTuple, double> pParamB = a => a.Item3;

//        int index = anonymous.Select(pIndex).First();
//        string str = anonymous.Select(pParamA).First();
//        double pi = anonymous.Select(pParamB).First();

//        str.Should().NotBeNullOrWhiteSpace();
//        pi.Should().Be(Math.Pow(Math.PI, index));
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleSelectMultipleTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        var result = ListExtensions.Select(list, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(list.Count);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleSelectTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.SelectTake(list, 2, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//        result[1].Item1.Should().Be(list![1].Item1);
//        result[1].Item2.Should().Be(list[1].Item2);
//        result[1].Item3.Should().Be(list[1].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleSelectTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();
//        var first = list.Count - 2;
//        var last = list.Count - 1;

//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
//        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2 * 3);

//        var result = ListExtensions.SelectTakeLast(list, 2, i => i);

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![first].Item1);
//        result[0].Item2.Should().Be(list[first].Item2);
//        result[0].Item3.Should().Be(list[first].Item3);
//        result[1].Item1.Should().Be(list![last].Item1);
//        result[1].Item2.Should().Be(list[last].Item2);
//        result[1].Item3.Should().Be(list[last].Item3);
//    }
//    #endregion WhereSelect Tests

//    #region Take & TakeLast
//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.Take(list, 2)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![0].Item1);
//        result[0].Item2.Should().Be(list[0].Item2);
//        result[0].Item3.Should().Be(list[0].Item3);
//        result[1].Item1.Should().Be(list![1].Item1);
//        result[1].Item2.Should().Be(list[1].Item2);
//        result[1].Item3.Should().Be(list[1].Item3);
//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();
//        var first = list.Count - 2;
//        var last = list.Count - 1;

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.TakeLast(list, 2)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);
//        result[0].Item1.Should().Be(list![first].Item1);
//        result[0].Item2.Should().Be(list[first].Item2);
//        result[0].Item3.Should().Be(list[first].Item3);
//        result[1].Item1.Should().Be(list![last].Item1);
//        result[1].Item2.Should().Be(list[last].Item2);
//        result[1].Item3.Should().Be(list[last].Item3);
//    }
//    #endregion Take & TakeLast

//    #region OrderBy Tests
//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderBy(list, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(list.Count);

//        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1);
//        result.Should().BeEquivalentTo(linqSorted);

//        result.First().Item1.Should().Be(linqSorted!.First().Item1);
//        result.First().Item2.Should().Be(linqSorted.First().Item2);
//        result.First().Item3.Should().Be(linqSorted.First().Item3);
//        result.Last().Item1.Should().Be(linqSorted!.Last().Item1);
//        result.Last().Item2.Should().Be(linqSorted.Last().Item2);
//        result.Last().Item3.Should().Be(linqSorted.Last().Item3);

//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderByTake(list, 2, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);

//        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).Take(2);
//        result.Should().BeEquivalentTo(linqSorted);

//        result.First().Item1.Should().Be(linqSorted!.First().Item1);
//        result.First().Item2.Should().Be(linqSorted.First().Item2);
//        result.First().Item3.Should().Be(linqSorted.First().Item3);
//        result.Last().Item1.Should().Be(linqSorted!.Last().Item1);
//        result.Last().Item2.Should().Be(linqSorted.Last().Item2);
//        result.Last().Item3.Should().Be(linqSorted.Last().Item3);
//    }

//#if !NETFRAMEWORK
//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderByTakeLast(list, 2, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);

//        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).TakeLast(2);
//        result.Should().BeEquivalentTo(linqSorted);

//        result.First().Item1.Should().Be(linqSorted!.First().Item1);
//        result.First().Item2.Should().Be(linqSorted.First().Item2);
//        result.First().Item3.Should().Be(linqSorted.First().Item3);
//        result.Last().Item1.Should().Be(linqSorted!.Last().Item1);
//        result.Last().Item2.Should().Be(linqSorted.Last().Item2);
//        result.Last().Item3.Should().Be(linqSorted.Last().Item3);
//    }
//#endif
//    #endregion OrderBy Tests

//    #region OrderByDescending
//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByDescendingTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderByDescending(list, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(list.Count);

//        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1);
//        result.Should().BeEquivalentTo(linqSorted);

//        result.First().Item1.Should().Be(linqSorted!.First().Item1);
//        result.First().Item2.Should().Be(linqSorted.First().Item2);
//        result.First().Item3.Should().Be(linqSorted.First().Item3);
//        result.Last().Item1.Should().Be(linqSorted!.Last().Item1);
//        result.Last().Item2.Should().Be(linqSorted.Last().Item2);
//        result.Last().Item3.Should().Be(linqSorted.Last().Item3);

//    }

//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByDescendingTakeTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderByDescendingTake(list, 2, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);

//        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).Take(2);
//        result.Should().BeEquivalentTo(linqSorted);

//        result.First().Item1.Should().Be(linqSorted!.First().Item1);
//        result.First().Item2.Should().Be(linqSorted.First().Item2);
//        result.First().Item3.Should().Be(linqSorted.First().Item3);
//        result.Last().Item1.Should().Be(linqSorted!.Last().Item1);
//        result.Last().Item2.Should().Be(linqSorted.Last().Item2);
//        result.Last().Item3.Should().Be(linqSorted.Last().Item3);

//    }

//#if !NETFRAMEWORK
//    [DataTestMethod]
//    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
//    public void ValueTupleOrderByDescendingTakeLastTest(ValueTuple<object[], int> tuple)
//    {
//        List<TestValueTuple> list = tuple.Item1.Cast<TestValueTuple>().ToList();

//        list.Should().NotBeNullOrEmpty();
//        list.Should().HaveCount(tuple.Item2);

//        List<TestValueTuple> result = ListExtensions.OrderByDescendingTakeLast(list, 2, i => i.Item1)!;

//        result.Should().NotBeNullOrEmpty();
//        result!.Count.Should().Be(2);

//        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).TakeLast(2);
//        result.Should().BeEquivalentTo(linqSorted);
//    }
//#endif
//    #endregion OrderByDescending

//    #region Data
//    public static IEnumerable<object[]> GetAnonymousTestData()
//    {
//        yield return new object[] { new { Index = 1, ParamA = "ParamA-1", ParamB = Math.PI } };
//        yield return new object[] { new { Index = 2, ParamA = "ParamA-2", ParamB = Math.Pow(Math.PI, 2) } };
//        yield return new object[] { new { Index = 3, ParamA = "ParamA-3", ParamB = Math.Pow(Math.PI, 3) } };
//    }

//    public static IEnumerable<object[]> GetValueTupleTestData()
//    {
//        yield return new object[] { (3, "ParamA-3", Math.Pow(Math.PI, 3)) };
//        yield return new object[] { (1, "ParamA-1", Math.PI) };
//        yield return new object[] { (2, "ParamA-2", Math.Pow(Math.PI, 2)) };
//    }

//    public static IEnumerable<object[]> GetTestDataMethodsTestData()
//    {
//        var array = GetValueTupleTestData()!.SelectMany(i => i!)!;
//        object[] list = new object[] { (data: array, length: array.Count) };
//        return new[] { list };
//    }
//    #endregion Data
//}
