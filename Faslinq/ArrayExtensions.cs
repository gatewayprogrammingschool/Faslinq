// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

namespace Faslinq;

#region Any / All

public static partial class ArrayExtensions
{
    public static bool Any<TData>(this TData[] source)
        => source.Length > 0;

    public static bool Any<TData>(
        this TData[] source,
        Predicate<TData> query
    )
    {
        if (source.Length == 0)
        {
            return false;
        }

        for (var index = 0; index < source.Length; index++)
        {
            var item = source[index];
            if (query(item))
            {
                return true;
            }
        }

        return false;
    }

    public static bool All<TData>(
        this TData[] source,
        Predicate<TData> query
    )
    {
        if (source.Length == 0)
        {
            return false;
        }

        for (var index = 0; index < source.Length; index++)
        {
            var item = source[index];
            if (!query(item))
            {
                return false;
            }
        }

        return true;
    }
}

#endregion Any / All

#region First

/// <summary>
/// 
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="query"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public static TData First<TData>(
        this TData[] source,
        Predicate<TData>? query = null
    )
    {
        if (source.Length == 0)
        {
            throw new IndexOutOfRangeException("List does not contain a matching value.");
        }

        if (query is null)
        {
            return source[0];
        }

        for (var i = 0; i < source.Length; i++)
        {
            if (query(source[i]))
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
    public static TData? FirstOrDefault<TData>(
        this TData[] source,
        Predicate<TData>? query = null,
        TData? defaultValue = default
    )
    {
        if (source.Length == 0)
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
            if (query(source[i]))
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
    /// <exception cref="IndexOutOfRangeException"></exception>
    public static TData Last<TData>(
        this TData[] source,
        Predicate<TData>? query = null
    )
    {
        if (source.Length == 0)
        {
            throw new IndexOutOfRangeException("List does not contain a matching value.");
        }

        if (query is null)
        {
            return source[^1];
        }

        for (var i = source.Length - 1; i >= 0; --i)
        {
            if (query(source[i]))
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
    public static TData? LastOrDefault<TData>(
        this TData[] source,
        Predicate<TData>? query = null,
        TData? defaultValue = default
    )
    {
        if (source.Length == 0)
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
            if (query(source[i]))
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
    public static TData[] Where<TData>(
        this TData[] source,
        Predicate<TData> query
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
    public static TData[] WhereTake<TData>(
        this TData[] source,
        Predicate<TData> query,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TData[takeCount];
        var targetLength = Math.Min(source.Length, takeCount);
        for (var i = 0; i < source.Length && takeIndex < targetLength; i++)
        {
            if (query(source[i]))
            {
                result[takeIndex++] = source[i];
            }
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
    public static TData[] WhereTakeLast<TData>(
        this TData[] source,
        Predicate<TData> query,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TData[takeCount];
        for (var i = source.Length - 1; i >= 0 && takeIndex < takeCount; --i)
        {
            if (query(source[i]))
            {
                result[takeIndex++] = source[i];
            }
        }

        return result;
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
    public static TResult[] SelectTake<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = 0; i < source.Length && takeIndex < takeCount; i++)
        {
            result[takeIndex++] = selector(source[i]);
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
    public static TResult[] SelectTakeLast<TData, TResult>(
        this TData[] source,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = source.Length - takeCount; i < source.Length && takeIndex < takeCount; i++)
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
    public static TResult[] WhereSelect<TData, TResult>(
        this TData[] source,
        Predicate<TData> query,
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
    public static TResult[] WhereSelectTake<TData, TResult>(
        this TData[] source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = 0; i < source.Length && takeIndex < takeCount; i++)
        {
            if (query(source[i]))
            {
                result[takeIndex] = selector(source[i]);
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
    public static TResult[] WhereSelectTakeLast<TData, TResult>(
        this TData[] source,
        Predicate<TData> query,
        Func<TData, TResult> selector,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TResult>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var takeIndex = 0;
        var result = new TResult[takeCount];
        for (var i = source.Length - 1; i >= 0 && takeIndex < takeCount; --i)
        {
            if (query(source[i]))
            {
                result[takeIndex++] = selector(source[i]);
            }
        }

        return result;
    }
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
    public static TData[] OrderByTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Length)
            .ToArray();
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        var keys = source.Select(comparison)
            .ToArray();
        QuickSort(
            0,
            source.Length - 1,
            comparer,
            keys,
            indices
        );

        var limit = Math.Min(indices.Length, takeCount);
        var result = new TData[limit];
        var takeIndex = 0;

        for (var i = 0; i < limit; ++i)
        {
            result[takeIndex++] = source[indices[i]];
        }

        return result.ToArray();
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
    public static TData[] OrderByTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Length)
            .ToArray();
        
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        
        var keys = source.Select(comparison)
            .ToArray();
        
        QuickSort(
            0,
            source.Length - 1,
            comparer,
            keys,
            indices
            );

        var result = new TData[takeCount];
        var takeIndex = 0;

        for (var i = source.Length - takeCount; i < source.Length && takeIndex < takeCount; i++)
        {
            result[takeIndex++] = source[indices[i]];
        }

        return result;
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
    public static TData[] OrderByDescendingTakeLast<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Length)
            .ToArray();
        
        IComparer<TKey> comparer = Comparer<TKey>.Default;
        
        var keys = source.Select(comparison)
            .ToArray();

        QuickSort(
            0,
            source.Length - 1,
            comparer,
            keys,
            indices
        );

        var result = new TData[takeCount];
        var takeIndex = 0;

        var start = 0;
        var end = takeCount;

        for (var i = start; i < end && takeIndex < takeCount; ++i)
        {
            result[takeIndex++] = source[indices[i]];
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
    public static TData[] OrderByDescendingTake<TData, TKey>(
        this TData[] source,
        Func<TData, TKey> comparison,
        int takeCount
    )
    {
        if (source.Length == 0)
        {
            return Array.Empty<TData>();
        }

        if (takeCount < 1)
        {
            takeCount = 0;
        }

        var indices = Enumerable.Range(0, source.Length)
            .ToArray();

        IComparer<TKey> comparer = Comparer<TKey>.Default;

        var keys = source.Select(comparison)
            .ToArray();

        QuickSort(
            0,
            source.Length - 1,
            comparer,
            keys,
            indices
        );

        var result = new TData[takeCount];
        var takeIndex = 0;

        var start = indices.Length - 1;
        var end = indices.Length - takeCount;

        for (var i = start; i >= end && takeIndex < takeCount; --i)
        {
            result[takeIndex++] = source[indices[i]];
        }

        return result;
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
        int left,
        int right,
        IComparer<TKey> keyComparer,
        TKey[] keys,
        int[] indices,
        int depth = 0
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

        if (!(left <= right))
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
            var pivotKey = keys[pivot];

            do
            {
                while (keyComparer.Compare(keys[indices[i]], pivotKey) < 0)
                {
                    i++;
                }

                while (keyComparer.Compare(keys[indices[j]], pivotKey) > 0)
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
                        depth + 1
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
                        depth + 1
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
    public static PositionCollection PositionsWhere<TData>(
        this TData[] source,
        Predicate<TData> comparison
    )
    {
        var positions = new PositionCollection(0, 0);

        if (source.Length == 0)
        {
            return positions;
        }

        for (var i = 0; i < source.Length; ++i)
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
