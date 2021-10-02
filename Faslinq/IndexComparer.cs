namespace Faslinq;

public class IndexComparer : IEqualityComparer<Index>
{
    private static IndexComparer _instance = new();

    public static IEqualityComparer<Index> Default => _instance;

    public bool Equals(Index x, Index y)
    {
        return x.Equals(y);
    }

    public int GetHashCode(Index obj)
    {
        return obj.GetHashCode();
    }
}
