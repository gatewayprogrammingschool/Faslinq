#if NETSTANDARD2_0_OR_GREATER || NETCOREAPP
namespace Faslinq;
public record PositionCollection : IList<Range>, IList<Index>
{
    SortedList<int, Range> _ranges = new();
    Range _currentRange = default;
    IEqualityComparer<Index> _indexComparer = IndexComparer.Default;

    public PositionCollection(Index Start, Index End)
    {
        _currentRange = new Range(Start, End);
        AddInternal(_currentRange);
    }

    public Index Start => _currentRange.Start;
    public Index End => _currentRange.End;

    public int Count => _ranges.Count;
    public bool IsReadOnly { get; } = false;

    Index IList<Index>.this[int index]
    {
        get => Flatten()[index];
        set => Add(value);
    }
    public Range this[int index]
    {
        get => _ranges[index];
        set => _ranges[index] = value;
    }

    private Range AddInternal(Range range)
    {
        _ranges.Add(range.Start.Value, range);
        return range;
    }

    public Range Add(int index)
    {
        if (index is <= 0)
        {
            throw new IndexOutOfRangeException("Must be greater than or equal to zero.");
        }

        if (_ranges.Any(index) || _currentRange.Contains(index))
        {
            return _currentRange = _ranges.Find(index);
        }

        if (index == End.Value + 1)
        {
            return _currentRange = AddIndexInternal(Start, new Index(index));
        }
        
        if (index == Start.Value - 1)
        {
            return _currentRange = AddIndexInternal(new Index(index), End);
        }
        
        return _currentRange = AddRangeInternal(index, index);
    }

    Range AddIndexInternal(Index index)
    {
        var range = _ranges.Find(index.Value);

        if (range.Equals(default))
        {
            return AddIndexInternal(index, index);
        }

        return range;
    }
    Range AddIndexInternal(Index start, Index end)
    {
        _ranges.Remove(start.Value);
        return AddRangeInternal(start, end);
    }
    Range AddIndexInternal(Range range)
    {
        if (_ranges.ContainsKey(range.Start.Value))
        {
            _ranges.Remove(range.Start.Value);
        }

        return AddRangeInternal(range);
    }
    Range AddRangeInternal(Index start, Index end)
    {
        _currentRange = new Range(start, end);
        return AddInternal(_currentRange);
    }
    Range AddRangeInternal(Range range)
    {
        _currentRange = range;
        return AddInternal(_currentRange);
    }
    public void Add(Range item)
    {
        AddIndexInternal(item);
    }

    public void Clear()
    {
        _ranges.Clear();
        _currentRange = default;
    }

    public bool Contains(Range item)
    {
        return _ranges.Find(item).Equals(item);
    }

    public void CopyTo(Range[] array, int arrayIndex)
    {
        var ranges = _ranges.ToArray();

        if (arrayIndex + ranges.Length > array.Length)
        {
            throw new OverflowException($"The array is too big to fit in the target starting at {arrayIndex}");
        }

        for (int i = 0; i < ranges.Length; i++)
        {
            array[arrayIndex + i] = ranges[i].Value;
        }
    }

    public bool Remove(Range item)
        => _ranges.Find(item).Equals(item)
            ? _ranges.Remove(item.Start.Value)
            : throw new IndexOutOfRangeException("The specified Range is not in the collection.");

    public IEnumerator<Range> GetEnumerator() => _ranges.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _ranges.Values.GetEnumerator();

    public void Add(Index item)
    {
        Add(item.Value);
    }

    public bool Contains(Index item)
    {
        return _ranges.Any(item.Value);
    }

    private Index[] Flatten()
        => _ranges.SelectMany(r => r.Value.ToArray()).ToArray();


    public void CopyTo(Index[] array, int arrayIndex)
    {
        var values = Flatten();

        if (values.Length + arrayIndex > array.Length)
        {
            throw new OverflowException($"The array is too big to fit in the target starting at {arrayIndex}");
        }

        for (int i = 0; i < values.Length; i++)
        {
            array[arrayIndex + i] = values[i];
        }
    }

    public bool Remove(Index item)
    {
        var result = false;
        var range = _ranges.Find(item.Value);

        if (!range.Equals(default))
        {
            result = true;
            Remove(range);
            var isStart = range.Start.Equals(item);
            var isEnd = range.End.Equals(item);
            if (!isStart && !isEnd)
            {
                AddRangeInternal(range.Start, item.Value - 1);
                AddRangeInternal(item.Value + 1, range.End);
            }
            else if (isStart && isEnd)
            {
                // Remove the range altogether.
            }
            else if (isStart)
            {
                AddRangeInternal(item.Value + 1, range.End);
            }
            else
            {
                AddRangeInternal(range.Start, item.Value - 1);
            }
        }

        return result;
    }

    IEnumerator<Index> IEnumerable<Index>.GetEnumerator()
    {
        return new ArrayEnumerator<Index>(Flatten());
    }

    public void ForEach<TData>(List<TData> source, Action<TData> action)
    {
        var flattened = Flatten();

        for (int i = 0; i < flattened.Length; i++)
        {
            action(source[flattened[i].Value]);
        }
    }
    public IEnumerable<TData> Filter<TData>(TData[] source)
        => Filter(source.ToList());

    public IEnumerable<TData> Filter<TData>(List<TData> source)
    {
        var flattened = Flatten().OrderBy(v => v.Value);

        foreach(var flat in flattened)
        {
            var index = flat.Value;

            if (index < source.Count)
            {
                var data = source[index];

                yield return data;
            }
        }
    }

    public int IndexOf(Range item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, Range item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(Index item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, Index item)
    {
        throw new NotImplementedException();
    }

    private List<TData> GetByPositions<TData>(
    List<TData> source)
    => Filter(source).ToList();
}

#endif