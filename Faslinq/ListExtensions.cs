using System.Runtime.CompilerServices;
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

namespace Faslinq;

#region Any / All

/// <summary>
/// 
/// </summary>
public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TData>(this List<TData> source)
        => source.Count > 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TData>(
        this List<TData> source,
        Func<TData, int, bool> query
    )
    {
        if (source.Count == 0)
        {
            return false;
        }

        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (query(item, index))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TData>(
        this List<TData> source,
        Func<TData, int, bool> query
    )
    {
        if (source.Count == 0)
        {
            return false;
        }

        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (!query(item, index))
            {
                return false;
            }
        }

        return true;
    }
}

#endregion Any / All

#region First

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData First<TData>(
        this List<TData> source,
        Func<TData, int, bool>? query = null
    )
    {
        if (source.Count == 0)
        {
            throw new IndexOutOfRangeException("List does not contain a matching value.");
        }

        if (query is null)
        {
            return source[0];
        }

        for (var i = 0; i < source.Count; i++)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        throw new IndexOutOfRangeException("List does not contain a matching value.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData? FirstOrDefault<TData>(
        this List<TData> source,
        Func<TData, int, bool>? query = null,
        TData? defaultValue = default
    )
    {
        if (source.Count == 0)
        {
            return defaultValue;
        }

        if (query is null)
        {
            return source is { Count: > 0, }
                ? source[0]
                : defaultValue;
        }

        for (var i = 0; i < source.Count; i++)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        return defaultValue;
    }
}
#endregion First

#region Last

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData Last<TData>(
        this List<TData> source,
        Func<TData, int, bool>? query = null
    )
    {
        if (source.Count == 0)
        {
            throw new IndexOutOfRangeException("List does not contain a matching value.");
        }

        if (query is null)
        {
            return source[^1];
        }

        for (var i = source.Count - 1; i >= 0; --i)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        throw new IndexOutOfRangeException("List does not contain a matching value.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData? LastOrDefault<TData>(
        this List<TData> source,
        Func<TData, int, bool>? query = null,
        TData? defaultValue = default
    )
    {
        if (source.Count == 0)
        {
            return defaultValue;
        }

        if (query is null)
        {
            return source is { Count: > 0, }
                ? source[^1]
                : defaultValue;
        }

        for (var i = source.Count - 1; i >= 0; --i)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        return defaultValue;
    }
}

#endregion Last

#region Where

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> Where<TData>(
        this List<TData> source,
        Func<TData, int, bool> query
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        return source.WhereTake(query, source.Count);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> WhereTake<TData>(
        this List<TData> source,
        Func<TData, int, bool> query,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var targetLength = Math.Min(source.Count, takeCount);
        var result = new List<TData>(targetLength);
        for (var i = 0; i < source.Count && takeIndex < targetLength; i++)
        {
            if (!query(source[i], i))
            {
                continue;
            }

            result.Add(source[i]);
            takeIndex++;
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> WhereTakeLast<TData>(
        this List<TData> source,
        Func<TData, int, bool> query,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TData> result = new();
        for (var i = source.Count - 1; i >= 0 && result.Count < takeCount; --i)
        {
            if (query(source[i], i))
            {
                result.Add(source[i]);
            }
        }

        return result;
    }
}
#endregion Where

#region Select

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> Select<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector
    )
    {
        if (source.Count == 0)
        {
            return new List<TResult>();
        }

        List<TResult> result = new();
        for (var i = 0; i < source.Count; i++)
        {
            result.Add(selector(source[i]));
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> SelectTake<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return new List<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TResult> result = new();
        for (var i = 0; i < source.Count && result.Count < takeCount; i++)
        {
            result.Add(selector(source[i]));
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> SelectTakeLast<TData, TResult>(
        this List<TData> source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return new List<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TResult> result = new();
        for (var i = source.Count - takeCount; i < source.Count; i++)
        {
            result.Add(selector(source[i]));
        }

        return result;
    }
}

#endregion Select

#region WhereSelect

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> WhereSelect<TData, TResult>(
        this List<TData> source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector
    )
    {
        return source.WhereSelectTake(query, selector, source.Count);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="selector"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> WhereSelectTake<TData, TResult>(
        this List<TData> source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return new List<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        takeCount = Math.Min(takeCount, source.Count);
        var result = new List<TResult>();
        for (var i = 0; i < source.Count && result.Count < takeCount; i++)
        {
            if (query(source[i], i))
            {
                result.Add(selector(source[i]));
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="selector"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TResult> WhereSelectTakeLast<TData, TResult>(
        this List<TData> source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return new List<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TResult> result = new();

        for (var i = source.Count - 1; i >= 0 && result.Count < takeCount; --i)
        {
            if (query(source[i], i))
            {
                result.Add(selector(source[i]));
            }
        }

        return result;
    }
}

#endregion WhereSelect

#region Take / TakeLast

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> Take<TData>(
        this List<TData> source,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TData> result = new();
        for (var i = 0; i < Math.Min(source.Count, takeCount); i++)
        {
            result.Add(source[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> TakeLast<TData>(
        this List<TData> source,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        List<TData> result = new();
        for (var i = source.Count - takeCount; i < source.Count; i++)
        {
            result.Add(source[i]);
        }

        return result;
    }

#if NETSTANDARD2_0
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TData> TakeLast<TData>(
        this IEnumerable<TData> source,
        int takeCount)
    {
        var count = source.Count();
        if (count == 0) return source;

        if (takeCount < 1) { takeCount = 0; }

        List<TData> result = new();
        foreach (var item in source)
        {
            result.Add(item);
            if(result.Count >= takeCount)
            {
                break;
            }
        }

        return result;
    }
#endif
}

#endregion Take / TakeLast

#region OrderBy

public static partial class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderBy<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison
    )
        => OrderByTake(source, comparison, source.Count);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderByTake<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Count)
            .ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison)
            .ToArray();
        ArrayExtensions.QuickSort(
            0,
            source.Count - 1,
            comparer,
            keys,
            indices
        );

        var result = new List<TData>();

        var limit = Math.Min(indices.Length, takeCount);

        for (var i = 0; i < limit; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderByTakeLast<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Count)
            .ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison)
            .ToArray();
        ArrayExtensions.QuickSort(
            0,
            source.Count - 1,
            comparer,
            keys,
            indices
        );

        var result = new List<TData>();

        for (var i = source.Count - takeCount; i < source.Count; i++)
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderByDescending<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison
    )
        => OrderByDescendingTake(source, comparison, source.Count);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderByDescendingTakeLast<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Count)
            .ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison)
            .ToArray();
        ArrayExtensions.QuickSort(
            0,
            source.Count - 1,
            comparer,
            keys,
            indices
        );

        var result = new List<TData>();

        var start = 0;
        var end = takeCount;

        for (var i = start; i < end; ++i)
        {
            result.Add(source[indices[i]]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<TData> OrderByDescendingTake<TData, TKey>(
        this List<TData> source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Count == 0)
        {
            return source;
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Count)
            .ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison)
            .ToArray();
        ArrayExtensions.QuickSort(
            0,
            source.Count - 1,
            comparer,
            keys,
            indices
        );

        var result = new List<TData>();

        var start = indices.Length - 1;
        var end = indices.Length - takeCount;

        for (var i = start; i >= end; --i)
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PositionCollection PositionsWhere<TData>(
        this List<TData> source,
        Func<TData, int, bool> comparison
    )
    {
        var positions = new PositionCollection(0, 0);

        if (source.Count == 0)
        {
            return positions;
        }

        for (var i = 0; i < source.Count; ++i)
        {
            if (comparison(source[i], i))
            {
                positions.Add(i);
            }
        }

        return positions;
    }
}

#endregion PositionsWhere
