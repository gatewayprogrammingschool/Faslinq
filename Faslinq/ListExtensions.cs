using System.Diagnostics;

namespace Faslinq;

#region Any / All
public static partial class ListExtensions
{
    public static bool Any<TData>(
        this List<TData> source) 
        => source.Count > 0;

    public static bool Any<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return false;

        foreach (var item in source)
        {
            if (query(item)) return true;
        }

        return false;
    }

    public static bool All<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return false;

        foreach (var item in source)
        {
            if (!query(item)) return false;
        }

        return true;
    }
}
#endregion Any / All

#region First
public static partial class ListExtensions
{
    public static TData First<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) throw new ArgumentException("List does not contain a matching value.");

        var result = source.WhereTake(1, query);
        return result.Count > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? FirstOrDefault<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return default;

        return source.WhereTake(1, query).Count > 0
            ? source[0]
            : default;
    }
}
#endregion First

#region Last
public static partial class ListExtensions
{
    public static TData Last<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) throw new ArgumentException("List does not contain a matching value.");

        var result = source.WhereTakeLast(1, query);
        return result.Count > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? LastOrDefault<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return default;

        return source.WhereTakeLast(1, query).Count > 0
            ? source[0]
            : default;
    }
}
#endregion Last

#region Where
public static partial class ListExtensions
{
    public static List<TData> Where<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return source;

        return source.SelectWhereTake(source.Count, query, i => i);
    }

    public static List<TData> WhereTake<TData>(
        this List<TData> source,
        int takeCount,
        Predicate<TData> query)
    {
        if (source.Count == 0) return source;

        List<TData> result = new();
        var targetLength = Math.Min(source.Count, takeCount);
        for (int i = 0; i < source.Count && result.Count < targetLength; i++)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(source[i]);
            }
        }

        return result;
    }


    public static List<TData> WhereTakeLast<TData>(
        this List<TData> source,
        int takeCount,
        Predicate<TData> query)
    {
        if (source.Count == 0) return source;

        List<TData> result = new();
        for (int i = source.Count - 1; i >= 0; --i)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(source[i]);

                if (result.Count == takeCount)
                {
                    return result;
                }
            }
        }

        return result;
    }
}
#endregion Where

#region Select
public static partial class ListExtensions
{
    public static List<TResult> Select<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        return source.SelectTake(source.Count, selector);
    }

    public static List<TResult> SelectTake<TData, TResult>(
        this List<TData> source,
        int takeCount,
        Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        List<TResult> result = new();
        for (int i = 0; i < source.Count; i++)
        {
            result.Add(selector(source[i]));

            if (result.Count == takeCount)
            {
                return result;
            }
        }

        return result;
    }

    public static List<TResult> SelectTakeLast<TData, TResult>(
        this List<TData> source,
        int takeCount,
        Func<TData, TResult>? selector)
    {
        if (source.Count == 0) return new List<TResult>();

        List<TResult> result = new();
        for (int i = source.Count - takeCount; i < source.Count; i++)
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

        return result;
    }
}
#endregion Select

#region SelectWhere
public static partial class ListExtensions
{
    public static List<TResult> SelectWhere<TData, TResult>(
    this List<TData> source,
    Predicate<TData> query,
    Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        return source.SelectWhereTake(source.Count, query, selector);
    }

    public static List<TResult> SelectWhereTake<TData, TResult>(
        this List<TData> source,
        int takeCount,
        Predicate<TData> query,
        Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        List<TResult> result = new();
        for (int i = 0; i < source.Count; i++)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(selector(source[i]));

                if (result.Count == takeCount)
                {
                    return result;
                }
            }
        }

        return result;
    }

    public static List<TResult> SelectWhereTakeLast<TData, TResult>(
        this List<TData> source,
        int takeCount,
        Predicate<TData> query,
        Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        List<TResult> result = new();

        for (int i = source.Count - 1; i >= 0; --i)
        {
            var found = query(source[i]);

            if (found)
            {
                result.Add(selector(source[i]));

                if (result.Count == takeCount)
                {
                    return result;
                }
            }
        }

        return result;
    }
}
#endregion SelectWhere

#region Take / TakeLast
public static partial class ListExtensions
{
    public static List<TData> Take<TData>(
            this List<TData> source,
            int takeCount)
            => SelectTake<TData, TData>(source, takeCount, i => i);

    public static List<TData> TakeLast<TData>(
        this List<TData> source,
        int takeCount)
        => SelectTakeLast<TData, TData>(source, takeCount, null);
}
#endregion Take / TakeLast

#region OrderBy
public static partial class ListExtensions
{
    public static List<TData> OrderBy<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison)
        => OrderByTake(source, source.Count, comparison);

    public static List<TData> OrderByTake<TData, TKey>(
        this List<TData> source,
        int takeCount,
        Func<TData, TKey> comparison)
    {
        if (source.Count == 0) return source;

        int[] indices = Enumerable.Range(0, source.Count).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        ArrayExtensions.QuickSort(0, source.Count - 1, comparer, keys, indices);

        var result = new List<TData>();

        var limit = Math.Min(indices.Length, takeCount);

        for (int i = 0; i < limit; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }

    public static List<TData> OrderByTakeLast<TData, TKey>(
        this List<TData> source,
        int takeCount,
        Func<TData, TKey> comparison)
    {
        if (source.Count == 0) return source;

        int[] indices = Enumerable.Range(0, source.Count).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        ArrayExtensions.QuickSort(0, source.Count - 1, comparer, keys, indices);

        var result = new List<TData>();

        for (int i = source.Count - takeCount; i < source.Count; i++)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }
}
#endregion OrderBy

#region OrderByDescending
public static partial class ListExtensions
{
    public static List<TData> OrderByDescending<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison)
        => OrderByDescendingTake(source, source.Count, comparison);

    public static List<TData> OrderByDescendingTakeLast<TData, TKey>(
        this List<TData> source,
        int takeCount,
        Func<TData, TKey> comparison)
    {
        if (source.Count == 0) return source;

        int[] indices = Enumerable.Range(0, source.Count).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        ArrayExtensions.QuickSort(0, source.Count - 1, comparer, keys, indices);

        var result = new List<TData>();

        var start = 0;
        var end = takeCount;

        for (int i = start; i < end; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }

    public static List<TData> OrderByDescendingTake<TData, TKey>(
        this List<TData> source,
        int takeCount,
        Func<TData, TKey> comparison)
    {
        if (source.Count == 0) return source;

        int[] indices = Enumerable.Range(0, source.Count).ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison).ToArray();
        ArrayExtensions.QuickSort(0, source.Count - 1, comparer, keys, indices);

        var result = new List<TData>();

        var start = indices.Length - 1;
        var end = indices.Length - takeCount;

        for (int i = start; i >= end; --i)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }
}
#endregion OrderByDescending

#region PositionsWhere
public static partial class ListExtensions
{
    public static PositionCollection PositionsWhere<TData>(
        this List<TData> source,
        Predicate<TData> comparison)
    {
        var positions = new PositionCollection(0, 0);
        
        if (source.Count == 0) return positions;

        for (int i = 0; i < source.Count; ++i)
        {
            if(comparison(source[i]))
            {
                positions.Add(i);
            }
        }

        return positions;
    }
}
#endregion PositionsWhere

