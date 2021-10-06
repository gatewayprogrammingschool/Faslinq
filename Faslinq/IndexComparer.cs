namespace Faslinq;

public class IndexComparer : IEqualityComparer<Index>
{
    private static readonly IndexComparer _instance = new();

    public static IEqualityComparer<Index> Default
        => _instance;

    public bool Equals(Index x, Index y)
        => x.Equals(y);

    public int GetHashCode(Index obj)
        => obj.GetHashCode();
}
