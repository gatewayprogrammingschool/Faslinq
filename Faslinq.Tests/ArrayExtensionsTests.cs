// ReSharper disable InvokeAsExtensionMethod
namespace Faslinq.Tests;

using System;
using System.Collections.Generic;

using TestValueTuple = System.ValueTuple<int, string, double>;

[TestClass()]
public class ArrayExtensionsTests
{
    #region Any / All Tests
    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleAnyTest(TestValueTuple? toSelect = null)
    {
        var tuples = new[] { toSelect ?? default };

        ArrayExtensions.Any(tuples, (a, i) => true).Should().BeTrue();
        ArrayExtensions.Any(tuples, (a, i) => false).Should().BeFalse();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleEmptyAnyTest(TestValueTuple? toSelect = null)
    {
        TestValueTuple[] tuples = new[] { toSelect ?? default };

        ArrayExtensions.Any(tuples).Should().BeTrue();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleAllTest(TestValueTuple? toSelect = null)
    {
        var tuples = new[] { toSelect ?? default };

        ArrayExtensions.All(tuples, (a, i) => true).Should().BeTrue();
        ArrayExtensions.All(tuples, (a, i) => false).Should().BeFalse();
    }
    #endregion Any / All Tests

    #region First / Last Tests
    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleFirstTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new[] { toSelect ?? default };

        ArrayExtensions.First(anonymous, (a, i) => true)!.Should().Be(toSelect ?? default);

        Action a = () => ArrayExtensions.First(anonymous, (a, i) => false);
        a.Should().Throw<IndexOutOfRangeException>();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleLastTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new[] { toSelect };

        ArrayExtensions.Last(anonymous, (a, i) => true)!.Should().Be(toSelect);

        Action a = () => ArrayExtensions.Last(anonymous, (a, i) => false);
        a.Should().Throw<IndexOutOfRangeException>();
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleFirstOrDefaultTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new[] { toSelect };

        ArrayExtensions.FirstOrDefault(anonymous, (a, i) => true)!.Should().Be(toSelect);
        ArrayExtensions.FirstOrDefault(anonymous, (a, i) => false).Should().Be(default);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleLastOrDefaultTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new[] { toSelect };

        ArrayExtensions.LastOrDefault(anonymous, (a, i) => true)!.Should().Be(toSelect);
        ArrayExtensions.LastOrDefault(anonymous, (a, i) => false).Should().Be(default);
    }
    #endregion First / Last Tests

    #region Where Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousWhereTest(object? toSelect = null)
    {
        var anonymous = new[] { toSelect };
        var expected = ((dynamic?)toSelect)?.Index;
        object? first = ArrayExtensions.Where(
                anonymous.Cast<dynamic?>().ToArray(),
                (a, i) => a?.Index == expected)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereTest(TestValueTuple? toSelect = null)
    {
        var anonymous = new[] { toSelect };

        object? first = ArrayExtensions.Where(anonymous, (a, i) => a?.Item1 == toSelect?.Item1).FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ArrayExtensions.Where(
            list.ToArray(), 
            (i, idx) => i.Item1 == list[0].Item1);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => i.Item1 == list[0].Item1)
            .ToArray();

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
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

        var result = ArrayExtensions.WhereTake(
            list.ToArray(), 
            (i, idx) => i.Item1 == list[0].Item1, 
            2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => i.Item1 == list[0].Item1)
            .Take(2)
            .ToArray();

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
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

        var result = ArrayExtensions.WhereTakeLast(
            list.ToArray(), 
            (i, idx) => i.Item1 == list[first].Item1, 
            2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => i.Item1 == list[first].Item1)
            .TakeLast(2)
            .ToArray();

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
    }
    #endregion WhereTake Tests

    #region WhereSelect Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousWhereSelectTest(object? toSelect = null)
    {
        var anonymous = new[] { toSelect };
        var expected = ((dynamic?)toSelect)?.Index;
        object? first = ArrayExtensions.WhereSelect(
                anonymous.Cast<dynamic?>().ToArray(),
                (a, i) => a?.Index == expected,
                i => i)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTest(TestValueTuple? toSelect = null)
    {
        TestValueTuple[] anonymous = new[] { toSelect ?? default };

        Func<TestValueTuple, int> pIndex = a => a.Item1;
        Func<TestValueTuple, string> pParamA = a => a.Item2;
        Func<TestValueTuple, double> pParamB = a => a.Item3;

        var index = anonymous.WhereSelect((i, idx) => Filter(i, 0, anonymous[0]), pIndex);
        var str = anonymous.WhereSelect((i, idx) => Filter(i, 0, anonymous[0]), pParamA);
        var pi = anonymous.WhereSelect((i, idx) => Filter(i, 0, anonymous[0]), pParamB);

        if (toSelect is null) return;

        var indexExpected = anonymous
            .Where((i, idx) => Filter(i, 0, anonymous[0]))
            .Select(pIndex)
            .ToArray();

        var strExpected = anonymous
            .Where((i, idx) => Filter(i, 0, anonymous[0]))
            .Select(pParamA)
            .ToArray();

        var piExpected = anonymous
            .Where((i, idx) => Filter(i, 0, anonymous[0]))
            .Select(pParamB)
            .ToArray();

        index.Should().BeEquivalentTo(indexExpected);
        str.Should().BeEquivalentTo(strExpected);
        pi.Should().BeEquivalentTo(piExpected);
    }

    private bool Filter((int, string, double) i, int _, TestValueTuple item)
        => i.Item1 == item.Item1;

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ArrayExtensions.WhereSelect(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .ToArray();

        result.Should().NotBeNull();
        result!.Should().BeEquivalentTo(linqResult);
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

        var result = ArrayExtensions.WhereSelectTake(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i,
            2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .Take(2)
            .ToArray();

        result.Should().NotBeNull();
        result!.Should().BeEquivalentTo(linqResult);
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

        var result = ArrayExtensions.WhereSelectTakeLast(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i, 2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .TakeLast(2)
            .ToArray();

        result.Should().NotBeNull();
        result!.Should().BeEquivalentTo(linqResult);
    }
    #endregion WhereSelect Tests

#if !NETFRAMEWORK
    #region WhereSelectAsSpan Tests

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectAsSpanMultipleTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        var result = ArrayExtensions.WhereSelectAsSpan(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .ToArray()
            .AsSpan(0..^0);

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTakeAsSpanTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ArrayExtensions.WhereSelectTakeAsSpan(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i,
            2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .Take(2)
            .ToArray()
            .AsSpan();

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
    }

    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleWhereSelectTakeLastAsSpanTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();
        var first = list.Count - 2;
        var last = list.Count - 1;

        list.AddRange(tuple.Item1.Cast<TestValueTuple>());
        list.AddRange(tuple.Item1.Cast<TestValueTuple>());

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2 * 3);

        var result = ArrayExtensions.WhereSelectTakeLastAsSpan(
            list.ToArray(),
            (i, idx) => Filter(i, 0, list.First()),
            i => i, 2);

        IEnumerable<TestValueTuple> linqSource = list.AsEnumerable();

        var linqResult = linqSource
            .Where((i, idx) => Filter(i, 0, list.First()))
            .Select(i => i)
            .TakeLast(2)
            .ToArray()
            .AsSpan();

        result.ToArray().Should().NotBeNull();
        result!.ToArray().Should().BeEquivalentTo(linqResult.ToArray());
    }
    #endregion WhereSelect Tests
#endif

    #region Select Tests
    [DataTestMethod]
    [DynamicData(nameof(GetAnonymousTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyAnonymousTestData), DynamicDataSourceType.Method)]
    public void AnonymousSelectTest(object? toSelect = null)
    {
        var anonymous = new[] { toSelect };
        object? first = ArrayExtensions.Select(
                anonymous.Cast<dynamic?>().ToArray(),
                i => i)?
            .FirstOrDefault();

        first.Should().BeEquivalentTo(toSelect);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetValueTupleTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyValueTupleTestData), DynamicDataSourceType.Method)]
    public void ValueTupleSelectTest(TestValueTuple? toSelect = null)
    {
        TestValueTuple[] anonymous = new[] { toSelect ?? default };

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

        var result = ArrayExtensions.Select(list.ToArray(), i => i);

        result.Should().NotBeNull();
        result!.Length.Should().Be(list.Count);
        if (result.Length == 0) return;
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

        var result = ArrayExtensions.SelectTake(list.ToArray(), i => i, 2);

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));
        if (result.Length == 0) return;
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

        var result = ArrayExtensions.SelectTakeLast(list.ToArray(), i => i, 2);

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));
        if (result.Length == 0) return;
        result[0].Item1.Should().Be(list![first].Item1);
        result[0].Item2.Should().Be(list[first].Item2);
        result[0].Item3.Should().Be(list[first].Item3);
        result[1].Item1.Should().Be(list![last].Item1);
        result[1].Item2.Should().Be(list[last].Item2);
        result[1].Item3.Should().Be(list[last].Item3);
    }
    #endregion WhereSelect Tests

    #region Take & TakeLast
    [DataTestMethod]
    [DynamicData(nameof(GetTestDataMethodsTestData), DynamicDataSourceType.Method)]
    [DynamicData(nameof(GetEmptyTestDataMethodsTestData), DynamicDataSourceType.Method)]
    public void ValueTupleTakeTest(ValueTuple<object[], int> tuple)
    {
        var list = tuple.Item1.Cast<TestValueTuple>().ToList();

        list.Should().NotBeNull();
        list.Should().HaveCount(tuple.Item2);

        TestValueTuple[] result = ArrayExtensions.Take(list.ToArray(), 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));
        if (result.Length == 0) return;
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

        TestValueTuple[] result = ArrayExtensions.TakeLast(list.ToArray(), 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));
        if (result.Length == 0) return;
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

        TestValueTuple[] result = ArrayExtensions.OrderBy(list.ToArray(), i => i.Item1)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(list.Count);

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).ToArray();
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

        TestValueTuple[] result = ArrayExtensions.OrderByTake(list.ToArray(), i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).Take(2).ToArray();
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

        TestValueTuple[] result = ArrayExtensions.OrderByTakeLast(list.ToArray(), i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderBy(list!, i => i.Item1).TakeLast(2).ToArray();
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

        TestValueTuple[] result = ArrayExtensions.OrderByDescending(list.ToArray(), i => i.Item1)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(list.Count);

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).ToArray();
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

        TestValueTuple[] result = ArrayExtensions.OrderByDescendingTake(list.ToArray(), i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).Take(2).ToArray();
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

        TestValueTuple[] result = ArrayExtensions.OrderByDescendingTakeLast(list.ToArray(), i => i.Item1, 2)!;

        result.Should().NotBeNull();
        result!.Length.Should().Be(Math.Min(2, list.Count));

        var linqSorted = Enumerable.OrderByDescending(list!, i => i.Item1).TakeLast(2).ToArray();
        result.Should().BeEquivalentTo(linqSorted);
    }
#endif
    #endregion OrderByDescending

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

        IEnumerable<Range> result = ListExtensions.PositionsWhere(list, (i, _) => i.Item1 == 1);

        result.Should().BeEquivalentTo(finished);
    }

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
        yield return Array.Empty<TestValueTuple>().Cast<object>().ToArray();
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
