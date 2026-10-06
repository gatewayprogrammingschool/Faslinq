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
        => _index > -1 && _index < _array.Length
            ? _array[_index]
            : default;

    object? IEnumerator.Current
        => Current;

    private int _index;

    /// <summary>
    ///
    /// </summary>
    /// <param name="array"></param>
    public ArrayEnumerator(TType[] array)
    {
        _array = array;
        _index = -1;
    }

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
        if (_index < _array.Length)
        {
            _index++;
        }

        return _index < _array.Length;
    }

    /// <summary>
    ///
    /// </summary>
    public void Reset()
        => _index = -1;
}
