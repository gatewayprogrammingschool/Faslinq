namespace Faslinq;

/// <summary>
/// 
/// </summary>
public static class RangeExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="range"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static bool Contains(this Range range, int index)
        => range.Start.Value <= index && range.End.Value > index;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ranges"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Range Find(this SortedList<int, Range> ranges, int index)
        => ranges.FirstOrDefault(r => r.Value.Contains(index))
            .Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ranges"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    public static Range Find(this SortedList<int, Range> ranges, Range range)
        => ranges.FirstOrDefault(r => r.Value.Equals(range))
            .Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ranges"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static bool Any(this SortedList<int, Range> ranges, int index)
        => !ranges.FirstOrDefault(r => r.Value.Contains(index))
            .Value.Equals(default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ranges"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    public static bool Any(this SortedList<int, Range> ranges, Range range)
        => !ranges.FirstOrDefault(r => r.Value.Equals(range))
            .Value.Equals(default);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP
    /// <summary>
    /// 
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static Span<Index> ToSpan(this Range range)
        => new(range.ToArray());
#endif

    /// <summary>
    /// 
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static Index[] ToArray(this Range range)
    {
        var result = new Index[range.End.Value - range.Start.Value];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = new Index(range.Start.Value + i);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
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
