// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

using System;
using System.Runtime.CompilerServices;

namespace Faslinq;

#region Any / All

public static partial class ArrayExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TData>(this TData[] source)
        => source.Length > 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TData>(
        this TData[] source,
        Func<TData, int, bool> query
    )
    {
        if (source.Length == 0)
        {
            return false;
        }

        for (var index = 0; index < source.Length; index++)
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
        this TData[] source,
        Func<TData, int, bool> query
    )
    {
        for (var index = 0; index < source.Length; index++)
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

public static partial class ArrayExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData First<TData>(
        this TData[] source,
        Func<TData, int, bool>? query = null
    )
    {
        if (source is null or { Length: 0 })
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (query is null)
        {
            return source[0];
        }

        for (var i = 0; i < source.Length; i++)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element.");
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
        this TData[] source,
        Func<TData, int, bool>? query = null,
        TData? defaultValue = default
    )
    {
        if (source is null or { Length: 0 })
        {
            return defaultValue;
        }

        if (query is null)
        {
            return source is { Length: > 0, }
                ? source[0]
                : defaultValue;
        }

        for (var i = 0; i < source.Length; i++)
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

public static partial class ArrayExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData Last<TData>(
        this TData[] source,
        Func<TData, int, bool>? query = null
    )
    {
        if (source is null or { Length: 0 })
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (query is null)
        {
            return source[^1];
        }

        for (var i = source.Length - 1; i >= 0; --i)
        {
            if (query(source[i], i))
            {
                return source[i];
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element.");
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
        this TData[] source,
        Func<TData, int, bool>? query = null,
        TData? defaultValue = default
    )
    {
        if (source is null or { Length: 0 })
        {
            return defaultValue;
        }

        if (query is null)
        {
            return source is { Length: > 0, }
                ? source[^1]
                : defaultValue;
        }

        for (var i = source.Length - 1; i >= 0; --i)
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

public static partial class ArrayExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData[] Where<TData>(
        this TData[] source,
        Func<TData, int, bool> query
    )
        => source.WhereSelectTake(query, i => i, source.Length);

    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData[] WhereTake<TData>(
        this TData[] source,
        Func<TData, int, bool> query,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var targetLength = Math.Min(source.Length, takeCount);
        var result = new TData[targetLength];
        for (var i = 0; i < source.Length && takeIndex < targetLength; i++)
        {
            if (query(source[i], i))
            {
                result[takeIndex++] = source[i];
            }
        }

        return Slice(result, 0, takeIndex);
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
    public static TData[] WhereTakeLast<TData>(
        this TData[] source,
        Func<TData, int, bool> query,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        // Fill from the end so the result keeps source order.
        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = takeCount;
        var result = new TData[takeCount];
        for (var i = source.Length - 1; i >= 0 && takeIndex > 0; --i)
        {
            if (query(source[i], i))
            {
                result[--takeIndex] = source[i];
            }
        }

        return Slice(result, takeIndex, takeCount - takeIndex);
    }
}

#endregion Where

#region Select

public static partial class ArrayExtensions
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
    public static TResult[] Select<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector
    )
        => source.SelectTake(selector, source.Length);

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
    public static TResult[] SelectTake<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        takeCount = Math.Min(takeCount, source.Length);
        var result = new TResult[takeCount];
        for (var i = 0; i < takeCount; i++)
        {
            result[i] = selector(source[i]);
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
    public static TResult[] SelectTakeLast<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = source.Length - takeCount; i < source.Length; i++)
        {
            result[takeIndex++] = selector(source[i]);
        }

        return result;
    }
}

#endregion Select

#region WhereSelect

public static partial class ArrayExtensions
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
    public static TResult[] WhereSelect<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector
    )
        => source.WhereSelectTake(query, selector, source.Length);    
    
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
    public static TResult[] WhereSelectTake<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0 })
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = 0; i < source.Length && takeIndex < takeCount; i++)
        {
            if (query(source[i], i))
            {
                result[takeIndex++] = selector(source[i]);
            }
        }

#if NETSTANDARD2_0
        TResult[] returnArray = new TResult[takeIndex];
        Array.ConstrainedCopy(result, 0, returnArray, 0, takeIndex);
        return returnArray;
#else
        return result[..takeIndex];
#endif
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
    public static TResult[] WhereSelectTakeLast<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0 })
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        // Fill from the end so the result keeps source order.
        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = takeCount;
        var result = new TResult[takeCount];
        for (var i = source.Length - 1; i >= 0 && takeIndex > 0; --i)
        {
            if (query(source[i], i))
            {
                result[--takeIndex] = selector(source[i]);
            }
        }

        return Slice(result, takeIndex, takeCount - takeIndex);
    }

#if !NETSTANDARD2_0
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
    public static Span<TResult> WhereSelectAsSpan<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector
    )
        => source.WhereSelectTakeAsSpan(query, selector, source.Length);

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
    public static Span<TResult> WhereSelectTakeAsSpan<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0 })
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = 0; i < source.Length && takeIndex < takeCount; i++)
        {
            if (query(source[i], i))
            {
                result[takeIndex++] = selector(source[i]);
            }
        }

        return result.AsSpan(..takeIndex);
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
    public static Span<TResult> WhereSelectTakeLastAsSpan<TData, TResult>(
        this TData[] source,
        Func<TData, int, bool> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source is null or { Length: 0 })
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        // Fill from the end so the result keeps source order.
        takeCount = Math.Min(takeCount, source.Length);
        var takeIndex = takeCount;
        var result = new TResult[takeCount];
        for (var i = source.Length - 1; i >= 0 && takeIndex > 0; --i)
        {
            if (query(source[i], i))
            {
                result[--takeIndex] = selector(source[i]);
            }
        }

        return result.AsSpan(takeIndex);
    }
#endif
}

#endregion WhereSelect

#region Take / TakeLast

public static partial class ArrayExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData[] Take<TData>(
        this TData[] source,
        int takeCount
    )
        => SelectTake(source, i => i, takeCount);

    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="takeCount"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TData[] TakeLast<TData>(
        this TData[] source,
        int takeCount
    )
        => SelectTakeLast(source, i => i, takeCount);
}

#endregion Take / TakeLast

#region OrderBy

public static partial class ArrayExtensions
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
    public static TData[] OrderBy<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison
    )
        => OrderByTake(source, comparison, source.Length);

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
    public static TData[] OrderByTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        var indices = SortIndices(source.Select(comparison), false);

        return Pick(source, indices, 0, Math.Min(Math.Max(takeCount, 0), indices.Length));
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
    public static TData[] OrderByTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        var indices = SortIndices(source.Select(comparison), false);
        var count = Math.Min(Math.Max(takeCount, 0), indices.Length);

        return Pick(source, indices, indices.Length - count, count);
    }
}

#endregion OrderBy

#region OrderByDescending

public static partial class ArrayExtensions
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
    public static TData[] OrderByDescending<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison
    )
        => OrderByDescendingTake(source, comparison, source.Length);

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
    public static TData[] OrderByDescendingTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        var indices = SortIndices(source.Select(comparison), true);
        var count = Math.Min(Math.Max(takeCount, 0), indices.Length);

        return Pick(source, indices, indices.Length - count, count);
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
    public static TData[] OrderByDescendingTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source is null or { Length: 0})
        {
            return Array.Empty<TData>();
        }

        var indices = SortIndices(source.Select(comparison), true);

        return Pick(source, indices, 0, Math.Min(Math.Max(takeCount, 0), indices.Length));
    }
}

#endregion OrderByDescending

#region Private

public static partial class ArrayExtensions
{
    /// <summary>
    /// Returns the positions of <paramref name="keys"/> in sorted order. Equal keys keep
    /// their original relative order, as System.Linq's OrderBy and OrderByDescending do.
    /// </summary>
    internal static int[] SortIndices<TKey>(TKey[] keys, bool descending)
    {
        var indices = new int[keys.Length];
        for (var i = 0; i < indices.Length; i++)
        {
            indices[i] = i;
        }

        if (indices.Length > 1)
        {
            QuickSort(0, indices.Length - 1, Comparer<TKey>.Default, keys, indices, descending: descending);
        }

        return indices;
    }

    private static TData[] Pick<TData>(TData[] source, int[] indices, int start, int count)
    {
        var result = new TData[count];
        for (var i = 0; i < count; i++)
        {
            result[i] = source[indices[start + i]];
        }

        return result;
    }

    private static T[] Slice<T>(T[] array, int start, int count)
    {
        if (start == 0 && count == array.Length)
        {
            return array;
        }

        var result = new T[count];
        Array.Copy(array, start, result, 0, count);
        return result;
    }

    // Ties are broken by position, which makes the sort stable.
    private static int CompareAt<TKey>(IComparer<TKey> keyComparer, TKey[] keys, int x, int y, bool descending)
    {
        var result = descending
            ? keyComparer.Compare(keys[y], keys[x])
            : keyComparer.Compare(keys[x], keys[y]);

        return result != 0 ? result : x.CompareTo(y);
    }

    // Source: https://github.com/dotnet/runtime/blob/44b44501c76c46bd79ee52b7d9a9d8a4957fc85f/src/libraries/System.Linq.Parallel/src/System/Linq/Parallel/Utils/Sorting.cs#L585
    //---------------------------------------------------------------------------------------
    // Sort algorithm used to sort key/value lists. After this has been called, the indices
    // will have been placed in sorted order based on the keys provided.
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void QuickSort<TKey>(
        int left,
        int right,
        IComparer<TKey> keyComparer,
        TKey[] keys,
        int[] indices,
        int depth = 0,
        bool descending = false
    )
    {
        if (keys == null)
        {
            throw new ApplicationException($"need a non-null keyset (depth: {depth})")
            {
                Data =
                {
                    {
                        "left", left
                    },
                    {
                        "right", right
                    },
                    {
                        "keys", keys
                    },
                    {
                        "indices", indices
                    },
                },
            };
        }

        if (left > right)
        {
            throw new ApplicationException($"left {left} <= right {right} (depth: {depth})")
            {
                Data =
                {
                    {
                        "left", left
                    },
                    {
                        "right", right
                    },
                    {
                        "keys", keys
                    },
                    {
                        "indices", indices
                    },
                },
            };
        }

        if (!(0 <= left && left < keys!.Length))
        {
            throw new ApplicationException(
                $"0 <= left {left} && left {left} < keys!.Length {keys!.Length} (depth: {depth})"
            )
            {
                Data =
                {
                    {
                        "left", left
                    },
                    {
                        "right", right
                    },
                    {
                        "keys", keys
                    },
                    {
                        "indices", indices
                    },
                },
            };
        }

        if (!(0 <= right && right < keys!.Length))
        {
            throw new ApplicationException(
                $"0 <= right {right} && right {right} < keys!.Length {keys!.Length} (depth: {depth})"
            )
            {
                Data =
                {
                    {
                        "left", left
                    },
                    {
                        "right", right
                    },
                    {
                        "keys", keys
                    },
                    {
                        "indices", indices
                    },
                },
            };
        }

        do
        {
            var i = left;
            var j = right;
            var pivot = indices[i + ((j - i) >> 1)];

            do
            {
                while (CompareAt(keyComparer, keys, indices[i], pivot, descending) < 0)
                {
                    i++;
                }

                while (CompareAt(keyComparer, keys, indices[j], pivot, descending) > 0)
                {
                    j--;
                }

                Debug.Assert(i >= left && j <= right, "(i>=left && j<=right) sort failed - bogus IComparer?");

                if (i > j)
                {
                    break;
                }

                if (i < j)
                {
                    // Swap the indices.
                    (indices[i], indices[j]) = (indices[j], indices[i]);
                }

                i++;
                j--;
            }
            while (i <= j);

            if (j - left <= right - i)
            {
                if (left < j)
                {
                    QuickSort(
                        left,
                        j,
                        keyComparer,
                        keys,
                        indices,
                        depth + 1,
                        descending
                    );
                }

                left = i;
            }
            else
            {
                if (i < right)
                {
                    QuickSort(
                        i,
                        right,
                        keyComparer,
                        keys,
                        indices,
                        depth + 1,
                        descending
                    );
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
    /// <summary>
    ///
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparison"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PositionCollection PositionsWhere<TData>(
        this TData[] source,
        Func<TData, int, bool> comparison
    )
    {
        var positions = new PositionCollection();

        if (source is null or { Length: 0})
        {
            return positions;
        }

        for (var i = 0; i < source.Length; ++i)
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
