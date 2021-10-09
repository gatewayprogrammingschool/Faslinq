namespace Faslinq;

/// <summary>
///
/// </summary>
/// <typeparam name="TType"></typeparam>
public struct ArrayEnumerator<TType> : IEnumerator<TType?>
{
    private readonly TType[] _array;

    /// <summary>
    ///
    /// </summary>
    public TType? Current
        => _index > -1
            ? _array[_index]
            : default;

    object? IEnumerator.Current
        => Current;

    private int _index = -1;

    /// <summary>
    ///
    /// </summary>
    /// <param name="array"></param>
    public ArrayEnumerator(TType[] array)
        => _array = array;

    /// <summary>
    ///
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index"></param>
    public ArrayEnumerator(TType[] array, int index) : this(array)
        => _index = index;

    /// <summary>
    ///
    /// </summary>
    public void Dispose()
    { }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public bool MoveNext()
    {
        _index++;
        if (_index >= _array.Length)
        {
            _index = _array.Length - 1;
            return false;
        }

        return true;
    }

    /// <summary>
    ///
    /// </summary>
    public void Reset()
        => _index = -1;
}
