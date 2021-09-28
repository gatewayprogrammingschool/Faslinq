using System.Collections;

namespace Faslinq;

public struct ArrayEnumerator<TType> : IEnumerator<TType?>
{
    private TType[] _array;

    public TType? Current => _index > -1 ? _array[_index] : default(TType); 
    
    object? IEnumerator.Current => Current;

    int _index = -1;
    public ArrayEnumerator(TType[] array) => _array = array;

    public ArrayEnumerator(TType[] array, int index) : this(array)
    {
        _index = index;
    }

    public void Dispose()
    {
    }

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

    public void Reset() => _index = -1;
}
