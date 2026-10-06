namespace Faslinq;

/// <summary>
/// 
/// </summary>
public record PositionCollection : IList<Range>, IList<Index>
{
    private Range _currentRange;
    private IEqualityComparer<Index> _indexComparer = IndexComparer.Default;
    private readonly SortedList<int, Range> _ranges = new();

    /// <summary>
    /// Creates an empty collection.
    /// </summary>
    public PositionCollection()
    {
    }

    /// <summary>
    /// Creates a collection holding the positions in <paramref name="start"/>..<paramref name="end"/>.
    /// </summary>
    /// <param name="start">First position (inclusive).</param>
    /// <param name="end">End position (exclusive), as with <see cref="Range"/>.</param>
    public PositionCollection(Index start, Index end)
    {
        _currentRange = new Range(start, end);

        if (end.Value > start.Value)
        {
            AddInternal(_currentRange);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Index Start
        => _currentRange.Start;

    /// <summary>
    /// 
    /// </summary>
    public Index End
        => _currentRange.End;

    Index IList<Index>.this[int index]
    {
        get
            => Flatten()[index];
        set
            => Add(value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void Add(Index item)
    {
        Add(item.Value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(Index item)
        => _ranges.Any(item.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    /// <exception cref="OverflowException"></exception>
    public void CopyTo(Index[] array, int arrayIndex)
    {
        var values = Flatten();

        if (values.Length + arrayIndex > array.Length)
        {
            throw new OverflowException($"The array is too big to fit in the target starting at {arrayIndex}");
        }

        for (var i = 0; i < values.Length; i++)
        {
            array[arrayIndex + i] = values[i];
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Remove(Index item)
    {
        var value = item.Value;
        Range? found = null;

        foreach (var range in _ranges.Values)
        {
            if (range.Contains(value))
            {
                found = range;
                break;
            }
        }

        if (found is not { } containing)
        {
            return false;
        }

        // Ranges are end-exclusive: split around the removed position.
        _ranges.Remove(containing.Start.Value);

        if (containing.Start.Value < value)
        {
            AddRangeInternal(containing.Start, value);
        }

        if (value + 1 < containing.End.Value)
        {
            AddRangeInternal(value + 1, containing.End);
        }

        return true;
    }

    IEnumerator<Index> IEnumerable<Index>.GetEnumerator()
        => new ArrayEnumerator<Index>(Flatten());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int IndexOf(Index item)
        => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Insert(int index, Index item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    public int Count
        => _ranges.Count;

    /// <summary>
    /// 
    /// </summary>
    public bool IsReadOnly { get; } = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public Range this[int index]
    {
        get
            => _ranges[index];
        set
            => _ranges[index] = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void Add(Range item)
    {
        AddIndexInternal(item);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        _ranges.Clear();
        _currentRange = default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(Range item)
        => _ranges.Find(item)
            .Equals(item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    /// <exception cref="OverflowException"></exception>
    public void CopyTo(Range[] array, int arrayIndex)
    {
        var ranges = _ranges.ToArray();

        if (arrayIndex + ranges.Length > array.Length)
        {
            throw new OverflowException($"The array is too big to fit in the target starting at {arrayIndex}");
        }

        for (var i = 0; i < ranges.Length; i++)
        {
            array[arrayIndex + i] = ranges[i]
                .Value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public bool Remove(Range item)
        => _ranges.Find(item)
            .Equals(item)
            ? _ranges.Remove(item.Start.Value)
            : throw new IndexOutOfRangeException("The specified Range is not in the collection.");

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<Range> GetEnumerator()
        => _ranges.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _ranges.Values.GetEnumerator();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int IndexOf(Range item)
        => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Insert(int index, Range item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    private Range AddInternal(Range range)
    {
        _ranges.Add(range.Start.Value, range);
        return range;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Range Add(int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Must be greater than or equal to zero.");
        }

        // Ascending adds, as PositionsWhere makes, only touch the last range.
        if (_ranges.Count > 0)
        {
            var last = _ranges.Values[_ranges.Count - 1];

            if (index > last.End.Value)
            {
                return AddRangeInternal(index, index + 1);
            }

            if (index == last.End.Value)
            {
                _ranges.RemoveAt(_ranges.Count - 1);
                return AddRangeInternal(last.Start, index + 1);
            }
        }

        Range? before = null;
        Range? after = null;

        foreach (var range in _ranges.Values)
        {
            if (range.Contains(index))
            {
                return _currentRange = range;
            }

            if (range.End.Value == index)
            {
                before = range;
            }
            else if (range.Start.Value == index + 1)
            {
                after = range;
            }
        }

        var start = index;
        var end = index + 1;

        if (before is { } left)
        {
            _ranges.Remove(left.Start.Value);
            start = left.Start.Value;
        }

        if (after is { } right)
        {
            _ranges.Remove(right.Start.Value);
            end = right.End.Value;
        }

        return AddRangeInternal(start, end);
    }

    private Range AddIndexInternal(Range range)
    {
        if (_ranges.ContainsKey(range.Start.Value))
        {
            _ranges.Remove(range.Start.Value);
        }

        return AddRangeInternal(range);
    }

    private Range AddRangeInternal(Index start, Index end)
    {
        _currentRange = new Range(start, end);
        return AddInternal(_currentRange);
    }

    private Range AddRangeInternal(Range range)
    {
        _currentRange = range;
        return AddInternal(_currentRange);
    }

    private Index[] Flatten()
        => _ranges.SelectMany(r => r.Value.ToArray())
            .ToArray();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="action"></param>
    /// <typeparam name="TData"></typeparam>
    public void ForEach<TData>(List<TData> source, Action<TData> action)
    {
        var flattened = Flatten();

        for (var i = 0; i < flattened.Length; i++)
        {
            action(
                source[flattened[i]
                    .Value]
            );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    public IEnumerable<TData> Filter<TData>(TData[] source)
        => Filter(source.ToList());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    public IEnumerable<TData> Filter<TData>(List<TData> source)
    {
        var flattened = Flatten()
            .OrderBy(v => v.Value);

        foreach (var flat in flattened)
        {
            var index = flat.Value;

            if (index < source.Count)
            {
                var data = source[index];

                yield return data;
            }
        }
    }

    private List<TData> GetByPositions<TData>(List<TData> source)
        => Filter(source)
            .ToList();
}
