using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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

        var result = source.WhereTake(query, 1);
        return result.Count > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? FirstOrDefault<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return default;

        var results = source.WhereTake(query, 1);
        return results.Count > 0
            ? results[0]
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

        var result = source.WhereTakeLast(query, 1);
        return result.Count > 0
            ? result[0]
            : throw new ArgumentException("List does not contain a matching value.");
    }

    public static TData? LastOrDefault<TData>(
        this List<TData> source,
        Predicate<TData> query)
    {
        if (source.Count == 0) return default;

        var results = source.WhereTakeLast(query, 1);
        return results.Count > 0
            ? results[0]
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

        return source.WhereSelectTake(query, i => i, source.Count);
    }

    public static List<TData> WhereTake<TData>(
        this List<TData> source,
        Predicate<TData> query,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        var targetLength = Math.Min(takeCount, source.Count);
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
        Predicate<TData> query,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

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
    //private static ConcurrentDictionary<object, bool> _selectors = new();

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //private static bool SelectsSelf<TData, TResult>(Func<TData, TResult> selector, TData data)
    //{
    //    if (selector is null)
    //    {
    //        return false;
    //    }

    //    if(_selectors.TryGetValue(selector, out var value))
    //    {
    //        return value;
    //    }

    //    var result = selector(data)?.Equals(data) ?? false;

    //    _selectors.AddOrUpdate(selector, result, (_, _) => result);

    //    return result;
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> Select<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        //if(SelectsSelf(selector, source[0]))
        //{
        //    return (List<TResult>)(object)source;
        //}

        List<TResult> result = new();
        for (int i = 0; i < source.Count; i++)
        {
            result.Add(selector(source[i]));
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> SelectTake<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Count == 0) return new List<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        //if (SelectsSelf(selector, source[0]))
        //{
        //    if (source.Count == takeCount)
        //    {
        //        return (List<TResult>)(object)source;
        //    }

        //    return (List<TResult>)(object)source.Take(takeCount);
        //}

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> SelectTakeLast<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult>? selector,
        int takeCount)
    {
        if (source.Count == 0) return new List<TResult>();

        if (takeCount < 1) { takeCount = 0; }

        //if (selector is not null && SelectsSelf(selector, source[0]))
        //{
        //    return (List<TResult>)(object)source.TakeLast(takeCount);
        //}

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

#region WhereSelect
public static partial class ListExtensions
{
    public static List<TResult> WhereSelect<TData, TResult>(
    this List<TData> source,
    Predicate<TData> query,
    Func<TData, TResult> selector)
    {
        if (source.Count == 0) return new List<TResult>();

        return source.WhereSelectTake(query, selector, source.Count);
    }

    public static List<TResult> WhereSelectTake<TData, TResult>(
        this List<TData> source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Count == 0) return new List<TResult>();

        if (takeCount < 1) { takeCount = 0; }

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

    public static List<TResult> WhereSelectTakeLast<TData, TResult>(
        this List<TData> source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount)
    {
        if (source.Count == 0) return new List<TResult>();

        if (takeCount < 1) { takeCount = 0; }

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
#endregion WhereSelect

#region Take / TakeLast
public static partial class ListExtensions
{
    public static List<TData> Take<TData>(
            this List<TData> source,
            int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        for (int i = 0; i < Math.Min(source.Count, takeCount); i++)
        {
            result.Add(source[i]);
        }

        return result;
    }

    public static List<TData> TakeLast<TData>(
        this List<TData> source,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        for (int i = source.Count - takeCount; i < source.Count; i++)
        {
            result.Add(source[i]);
        }

        return result;
    }
}
#endregion Take / TakeLast

#region OrderBy
public static partial class ListExtensions
{
    public static List<TData> OrderBy<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison)
        => OrderByTake(source, comparison, source.Count);

    public static List<TData> OrderByTake<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

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
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

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
        => OrderByDescendingTake(source, comparison, source.Count);

    public static List<TData> OrderByDescendingTakeLast<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison, 
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

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
        Func<TData, TKey> comparison,
        int takeCount)
    {
        if (source.Count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

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

