namespace Faslinq;

public static class RangeExtensions
{
    public static bool Contains(this Range range, int index)
        => range.Start.Value <= index && range.End.Value > index;

    public static Range Find(this SortedList<int, Range> ranges, int index)
        => ranges.FirstOrDefault(r => r.Value.Contains(index))
            .Value;

    public static Range Find(this SortedList<int, Range> ranges, Range range)
        => ranges.FirstOrDefault(r => r.Value.Equals(range))
            .Value;

    public static bool Any(this SortedList<int, Range> ranges, int index)
        => !ranges.FirstOrDefault(r => r.Value.Contains(index))
            .Value.Equals(default);

    public static bool Any(this SortedList<int, Range> ranges, Range range)
        => !ranges.FirstOrDefault(r => r.Value.Equals(range))
            .Value.Equals(default);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP
    public static Span<Index> ToSpan(this Range range)
        => new(range.ToArray());
#endif

    public static Index[] ToArray(this Range range)
    {
        var result = new Index[range.End.Value - range.Start.Value];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = new Index(range.Start.Value + i);
        }

        return result;
    }

    public static int[] ToInt32Array(this Range range)
    {
        var result = new int[range.End.Value - range.Start.Value];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = range.Start.Value + i;
        }

        return result;
    }
}
