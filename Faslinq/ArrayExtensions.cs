using System.Diagnostics;

namespace Faslinq;

#region Any / All
public static partial class ArrayExtensions
{
    public static bool Any<TData>(
        this TData[] source) 
        => source.Length > 0;

    public static bool Any<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) return false;

        foreach (var item in source)
        {
            if (query(item)) return true;
        }

        return false;
    }

    public static bool All<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) return false;

        foreach (var item in source)
        {
            if (!query(item)) return false;
        }

        return true;
    }
}
#endregion Any / All

#region First
public static partial class ArrayExtensions
{
    public static TData First<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) throw new ArgumentException("List does not contain a matching value.");

        var result = source.WhereTake(query, 1);
        return result.Length > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? FirstOrDefault<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) return default;

        return source.WhereTake(query, 1).Length > 0
            ? source[0]
            : default;
    }
}
#endregion First

#region Last
public static partial class ArrayExtensions
{
    public static TData Last<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) throw new ArgumentException("List does not contain a matching value.");

        var result = source.WhereTakeLast(query, 1);
        return result.Length > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? LastOrDefault<TData>(
        this TData[] source,
        Predicate<TData> query)
    {
        if (source.Length == 0) return default;

        return source.WhereTakeLast(query, 1).Length > 0
            ? source[0]
            : default;
    }
}
#endregion Last

#region Where
public static partial class ArrayExtensions
{
    public static TData[] Where<TData>(
        this TData[] source,
        Predicate<TData> query) 
        => source.WhereSelectTake(query, i => i, source.Length);

    public static TData[] WhereTake<TData>(
        this TData[] source,
        Predicate<TData> query,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        var targetLength = Math.Min(source.Length, takeCount);
        for (int i = 0; i < source.Length && result.Count < targetLength; i++)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(source[i]);
            }
        }

        return result.ToArray();
    }


    public static TData[] WhereTakeLast<TData>(
        this TData[] source,
        Predicate<TData> query,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        for (int i = source.Length - 1; i >= 0; --i)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(source[i]);

                if (result.Count == takeCount)
                {
                    return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }
}
#endregion Where

#region Select
public static partial class ArrayExtensions
{
    public static TResult[] Select<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector) 
        => source.SelectTake(selector, source.Length);

    public static TResult[] SelectTake<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        List<TResult> result = new();
        for (int i = 0; i < source.Length; i++)
        {
            result.Add(selector(source[i]));

            if (result.Count == takeCount)
            {
                return result.ToArray();
            }
        }

        return result.ToArray();
    }

    public static TResult[] SelectTakeLast<TData, TResult>(
        this TData[] source,
        Func<TData, TResult>? selector,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        List<TResult> result = new();
        for (int i = source.Length - takeCount; i < source.Length; i++)
        {
            TResult? converted = default(TResult);
            if (source[i] is TResult tResult)
            {
                converted = tResult;
            }

            var toAdd = selector switch
            {
                null => converted,
                _ => selector(source[i])
            };

            result.Add(toAdd!);
        }

        return result.ToArray();
    }
}
#endregion Select

#region WhereSelect
public static partial class ArrayExtensions
{
    public static TResult[] WhereSelect<TData, TResult>(
    this TData[] source,
    Predicate<TData> query,
    Func<TData, TResult> selector)
    {
        return source.WhereSelectTake(query, selector, source.Length);
    }

    public static TResult[] WhereSelectTake<TData, TResult>(
        this TData[] source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        List<TResult> result = new();
        for (int i = 0; i < source.Length; i++)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(selector(source[i]));

                if (result.Count == takeCount)
                {
                    return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }

    public static TResult[] WhereSelectTakeLast<TData, TResult>(
        this TData[] source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        List<TResult> result = new();

        for (int i = source.Length - 1; i >= 0; --i)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(selector(source[i]));

                if (result.Count == takeCount)
                {
                    return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }
}
#endregion WhereSelect

#region Take / TakeLast
public static partial class ArrayExtensions
{
    public static TData[] Take<TData>(
            this TData[] source,
            int takeCount)
            => SelectTake<TData, TData>(source, i => i, takeCount);

    public static TData[] TakeLast<TData>(
        this TData[] source,
        int takeCount)
        => SelectTakeLast<TData, TData>(source, null, takeCount);
}
#endregion Take / TakeLast

#region OrderBy
public static partial class ArrayExtensions
{
    public static TData[] OrderBy<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison)
        => OrderByTake(source, comparison, source.Length);

    public static TData[] OrderByTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if(source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        int[] indices = Enumerable.Range(0, source.Length).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        QuickSort(0, source.Length - 1, comparer, keys, indices);

        List<TData> result = new();

        var limit = Math.Min(indices.Length, takeCount);

        for (int i = 0; i < limit; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result.ToArray();
    }

    public static TData[] OrderByTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        int[] indices = Enumerable.Range(0, source.Length).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        QuickSort(0, source.Length - 1, comparer, keys, indices);

        List<TData> result = new();

        for (int i = source.Length - takeCount; i < source.Length; i++)
        {
            result.Add(source[indices[i]]);
        }

        return result.ToArray();
    }
}
#endregion OrderBy

#region OrderByDescending
public static partial class ArrayExtensions
{
    public static TData[] OrderByDescending<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison)
        => OrderByDescendingTake(source, comparison, source.Length);

    public static TData[] OrderByDescendingTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        int[] indices = Enumerable.Range(0, source.Length).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        QuickSort(0, source.Length - 1, comparer, keys, indices);

        List<TData> result = new();

        var start = 0;
        var end = takeCount;

        for (int i = start; i < end; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result.ToArray();
    }

    public static TData[] OrderByDescendingTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Length == 0) return Array.Empty<TData>();

        if (takeCount < 1) { takeCount = 0; }

        int[] indices = Enumerable.Range(0, source.Length).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        QuickSort(0, source.Length - 1, comparer, keys, indices);

        List<TData> result = new();

        var start = indices.Length - 1;
        var end = indices.Length - takeCount;

        for (int i = start; i >= end; --i)
        {
            result.Add(source[indices[i]]);
        }

        return result.ToArray();
    }
}
#endregion OrderByDescending

#region Private
public static partial class ArrayExtensions
{
    // Source: https://github.com/dotnet/runtime/blob/44b44501c76c46bd79ee52b7d9a9d8a4957fc85f/src/libraries/System.Linq.Parallel/src/System/Linq/Parallel/Utils/Sorting.cs#L585
    //---------------------------------------------------------------------------------------
    // Sort algorithm used to sort key/value lists. After this has been called, the indices
    // will have been placed in sorted order based on the keys provided.
    //
    internal static void QuickSort<TKey>(
        int left, int right,
        IComparer<TKey> keyComparer,
        TKey[] keys,
        int[] indices,
        int depth = 0)
    {
        if(!(keys != null)) throw new ApplicationException($"need a non-null keyset (depth: {depth})") { Data = { { "left", left }, { "right", right }, { "keys", keys }, { "indices", indices } }};
        if (!(left <= right)) throw new ApplicationException($"left {left} <= right {right} (depth: {depth})") { Data = { { "left", left }, { "right", right }, { "keys", keys }, { "indices", indices } } };
        if (!(0 <= left && left < keys!.Length)) throw new ApplicationException($"0 <= left {left} && left {left} < keys!.Length {keys!.Length} (depth: {depth})") { Data = { { "left", left }, { "right", right }, { "keys", keys }, { "indices", indices } } };
        if (!(0 <= right && right < keys!.Length)) throw new ApplicationException($"0 <= right {right} && right {right} < keys!.Length {keys!.Length} (depth: {depth})") { Data = { { "left", left }, { "right", right }, { "keys", keys }, { "indices", indices } } };

        do
        {
            int i = left;
            int j = right;
            int pivot = indices[i + ((j - i) >> 1)];
            TKey pivotKey = keys[pivot];

            do
            {
                while (keyComparer.Compare(keys[indices[i]], pivotKey) < 0) i++;
                while (keyComparer.Compare(keys[indices[j]], pivotKey) > 0) j--;

                Debug.Assert(i >= left && j <= right, "(i>=left && j<=right) sort failed - bogus IComparer?");

                if (i > j)
                {
                    break;
                }

                if (i < j)
                {
                    // Swap the indices.
                    int tmp = indices[i];
                    indices[i] = indices[j];
                    indices[j] = tmp;
                }

                i++;
                j--;
            }
            while (i <= j);

            if (j - left <= right - i)
            {
                if (left < j)
                {
                    QuickSort(left, j, keyComparer, keys, indices, depth + 1);
                }
                left = i;
            }
            else
            {
                if (i < right)
                {
                    QuickSort(i, right, keyComparer, keys, indices, depth + 1);
                }
                right = j;
            }
        }
        while (left < right);
    }
}
#endregion Private

#region PositionsWhere
public static partial class ArrayExtensions
{
    public static PositionCollection PositionsWhere<TData>(
        this TData[] source,
        Predicate<TData> comparison)
    {
        var positions = new PositionCollection(0, 0);

        if (source.Length == 0) return positions;

        for (int i = 0; i < source.Length; ++i)
        {
            if (comparison(source[i]))
            {
                positions.Add(i);
            }
        }

        return positions;
    }
}
#endregion PositionsWhere