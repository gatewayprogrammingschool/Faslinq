namespace Faslinq;

/// <summary>
///
/// </summary>
public class IndexComparer : IEqualityComparer<Index>
{
    private static readonly IndexComparer Instance = new();

    /// <summary>
    ///
    /// </summary>
    public static IEqualityComparer<Index> Default
        => Instance;

    /// <summary>
    ///
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Equals(Index x, Index y)
        => x.Equals(y);

    /// <summary>
    ///
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetHashCode(Index obj)
        => obj.GetHashCode();
}
