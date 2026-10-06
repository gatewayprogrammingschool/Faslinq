// ReSharper disable InvokeAsExtensionMethod
namespace Faslinq.Tests;

/// <summary>
/// One test per defect found in the project review. Each compares against the
/// System.Linq result (in order) or the documented contract.
/// Expected values call <see cref="Enumerable"/> explicitly: the global
/// <c>using Faslinq;</c> would otherwise bind them to Faslinq itself.
/// </summary>
[TestClass()]
public class RegressionTests
{
    private static readonly int[] Source = { 1, 2, 3 };
    private static readonly int[] Unsorted = { 3, 1, 2 };

    private static readonly (int Key, string Name)[] Keyed =
    {
        (1, "a"), (0, "b"), (1, "c"), (0, "d"), (1, "e"), (0, "f"), (1, "g"),
    };

    private static List<int> SourceList => new(Source);
    private static List<int> UnsortedList => new(Unsorted);

    #region Take / TakeLast past the end

    [TestMethod]
    public void Array_Take_MoreThanLength_DoesNotPad()
    {
        ArrayExtensions.Take(Source, 10).Should().Equal(Enumerable.Take(Source, 10));
        ArrayExtensions.SelectTake(Source, i => i * 10, 10).Should().Equal(10, 20, 30);
    }

    [TestMethod]
    public void Array_TakeLast_MoreThanLength_ReturnsAll()
    {
        ArrayExtensions.TakeLast(Source, 10).Should().Equal(Enumerable.TakeLast(Source, 10));
        ArrayExtensions.SelectTakeLast(Source, i => i * 10, 10).Should().Equal(10, 20, 30);
    }

    [TestMethod]
    public void List_TakeLast_MoreThanCount_ReturnsAll()
    {
        ListExtensions.TakeLast(SourceList, 10).Should().Equal(Enumerable.TakeLast(Source, 10));
        ListExtensions.SelectTakeLast(SourceList, i => i * 10, 10).Should().Equal(10, 20, 30);
    }

    #endregion

    #region WhereTake padding

    [TestMethod]
    public void Array_WhereTake_FewerMatchesThanTake_DoesNotPad()
    {
        ArrayExtensions.WhereTake(Source, (x, _) => x > 2, 3).Should().Equal(3);
        ArrayExtensions.WhereTake(Source, (x, _) => x > 1, 5).Should().Equal(2, 3);
    }

    #endregion

    #region WhereTakeLast order

    [TestMethod]
    public void Array_WhereTakeLast_PreservesSourceOrder()
    {
        var expected = Enumerable.TakeLast(Enumerable.Where(Source, x => x > 0), 2).ToArray();

        ArrayExtensions.WhereTakeLast(Source, (x, _) => x > 0, 2).Should().Equal(expected);
        ArrayExtensions.WhereSelectTakeLast(Source, (x, _) => x > 0, x => x, 2).Should().Equal(expected);
    }

#if !NETSTANDARD2_0
    [TestMethod]
    public void Array_WhereSelectTakeLastAsSpan_PreservesSourceOrder()
    {
        ArrayExtensions.WhereSelectTakeLastAsSpan(Source, (x, _) => x > 0, x => x, 2)
            .ToArray()
            .Should()
            .Equal(2, 3);
    }
#endif

    [TestMethod]
    public void List_WhereTakeLast_PreservesSourceOrder()
    {
        var expected = Enumerable.TakeLast(Enumerable.Where(Source, x => x > 0), 2).ToArray();

        ListExtensions.WhereTakeLast(SourceList, (x, _) => x > 0, 2).Should().Equal(expected);
        ListExtensions.WhereSelectTakeLast(SourceList, (x, _) => x > 0, x => x, 2).Should().Equal(expected);
    }

    #endregion

    #region OrderBy

    [TestMethod]
    public void Array_OrderByTake_MoreThanLength_ReturnsAllSorted()
    {
        ArrayExtensions.OrderByTakeLast(Unsorted, x => x, 10).Should().Equal(1, 2, 3);
        ArrayExtensions.OrderByDescendingTake(Unsorted, x => x, 10).Should().Equal(3, 2, 1);
        ArrayExtensions.OrderByDescendingTakeLast(Unsorted, x => x, 10).Should().Equal(3, 2, 1);
    }

    [TestMethod]
    public void List_OrderByTake_MoreThanCount_ReturnsAllSorted()
    {
        ListExtensions.OrderByTakeLast(UnsortedList, x => x, 10).Should().Equal(1, 2, 3);
        ListExtensions.OrderByDescendingTake(UnsortedList, x => x, 10).Should().Equal(3, 2, 1);
        ListExtensions.OrderByDescendingTakeLast(UnsortedList, x => x, 10).Should().Equal(3, 2, 1);
    }

    [TestMethod]
    public void Array_OrderByDescendingTakeLast_ReturnsDescendingOrder()
    {
        var expected = Enumerable.TakeLast(Enumerable.OrderByDescending(Unsorted, x => x), 2).ToArray();

        ArrayExtensions.OrderByDescendingTakeLast(Unsorted, x => x, 2).Should().Equal(expected);
    }

    [TestMethod]
    public void List_OrderByDescendingTakeLast_ReturnsDescendingOrder()
    {
        var expected = Enumerable.TakeLast(Enumerable.OrderByDescending(Unsorted, x => x), 2).ToArray();

        ListExtensions.OrderByDescendingTakeLast(UnsortedList, x => x, 2).Should().Equal(expected);
    }

    [TestMethod]
    public void Array_OrderBy_IsStable()
    {
        ArrayExtensions.OrderBy(Keyed, p => p.Key)
            .Should()
            .Equal(Enumerable.OrderBy(Keyed, p => p.Key));

        ArrayExtensions.OrderByDescending(Keyed, p => p.Key)
            .Should()
            .Equal(Enumerable.OrderByDescending(Keyed, p => p.Key));
    }

    [TestMethod]
    public void List_OrderBy_IsStable()
    {
        var keyed = Keyed.ToList();

        ListExtensions.OrderBy(keyed, p => p.Key)
            .Should()
            .Equal(Enumerable.OrderBy(Keyed, p => p.Key));

        ListExtensions.OrderByDescending(keyed, p => p.Key)
            .Should()
            .Equal(Enumerable.OrderByDescending(Keyed, p => p.Key));
    }

    #endregion

    #region All / First / Last

    [TestMethod]
    public void All_OnEmpty_IsTrue()
    {
        ArrayExtensions.All(Array.Empty<int>(), (_, _) => false).Should().BeTrue();
        ListExtensions.All(new List<int>(), (_, _) => false).Should().BeTrue();
    }

    [TestMethod]
    public void Array_FirstLast_OnEmpty_ThrowInvalidOperation()
    {
        Action first = () => ArrayExtensions.First(Array.Empty<int>());
        Action last = () => ArrayExtensions.Last(Array.Empty<int>());

        first.Should().Throw<InvalidOperationException>();
        last.Should().Throw<InvalidOperationException>();
    }

    [TestMethod]
    public void List_FirstLast_OnEmpty_ThrowInvalidOperation()
    {
        Action first = () => ListExtensions.First(new List<int>());
        Action last = () => ListExtensions.Last(new List<int>());

        first.Should().Throw<InvalidOperationException>();
        last.Should().Throw<InvalidOperationException>();
    }

    #endregion

    #region Empty List results

    [TestMethod]
    public void List_EmptySource_ReturnsNewList()
    {
        var empty = new List<int>();

        ListExtensions.Where(empty, (_, _) => true).Should().NotBeSameAs(empty);
        ListExtensions.WhereTake(empty, (_, _) => true, 1).Should().NotBeSameAs(empty);
        ListExtensions.WhereTakeLast(empty, (_, _) => true, 1).Should().NotBeSameAs(empty);
        ListExtensions.Take(empty, 1).Should().NotBeSameAs(empty);
        ListExtensions.TakeLast(empty, 1).Should().NotBeSameAs(empty);
        ListExtensions.OrderBy(empty, x => x).Should().NotBeSameAs(empty);
        ListExtensions.OrderByTakeLast(empty, x => x, 1).Should().NotBeSameAs(empty);
        ListExtensions.OrderByDescending(empty, x => x).Should().NotBeSameAs(empty);
        ListExtensions.OrderByDescendingTakeLast(empty, x => x, 1).Should().NotBeSameAs(empty);
    }

    #endregion

    #region PositionsWhere

    [DataTestMethod]
    [DataRow(new int[0])]
    [DataRow(new[] { 0 })]
    [DataRow(new[] { 1 })]
    [DataRow(new[] { 1, 5 })]
    [DataRow(new[] { 0, 1, 2, 7, 9 })]
    public void Array_PositionsWhere_FindsExactlyTheMatchingPositions(int[] matches)
    {
        var source = Enumerable.Range(100, 10).ToArray();

        var positions = ArrayExtensions.PositionsWhere(source, (_, i) => matches.Contains(i));

        positions.Filter(source).Should().Equal(Enumerable.Select(matches, i => source[i]));
    }

    [DataTestMethod]
    [DataRow(new int[0])]
    [DataRow(new[] { 0 })]
    [DataRow(new[] { 1 })]
    [DataRow(new[] { 1, 5 })]
    [DataRow(new[] { 0, 1, 2, 7, 9 })]
    public void List_PositionsWhere_FindsExactlyTheMatchingPositions(int[] matches)
    {
        var source = Enumerable.Range(100, 10).ToList();

        var positions = ListExtensions.PositionsWhere(source, (_, i) => matches.Contains(i));

        positions.Filter(source).Should().Equal(Enumerable.Select(matches, i => source[i]));
    }

    #endregion

    #region ArrayEnumerator

    [TestMethod]
    public void ArrayEnumerator_Current_AfterEnd_IsDefault()
    {
        var enumerator = new ArrayEnumerator<int>(Source);

        while (enumerator.MoveNext())
        {
        }

        enumerator.MoveNext().Should().BeFalse();
        enumerator.Current.Should().Be(default(int));
    }

    #endregion

    #region RangeExtensions

    [TestMethod]
    public void Range_FromEndOrReversed_ThrowsArgumentException()
    {
        Action fromEndStart = () => (^3..).ToArray();
        Action fromEndEnd = () => (1..^1).ToInt32Array();
        Action reversed = () => (5..3).ToArray();
        Action contains = () => (^3..).Contains(1);

        fromEndStart.Should().Throw<ArgumentException>();
        fromEndEnd.Should().Throw<ArgumentException>();
        reversed.Should().Throw<ArgumentException>();
        contains.Should().Throw<ArgumentException>();
    }

    #endregion
}
