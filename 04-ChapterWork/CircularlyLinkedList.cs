using System.Collections;
namespace Chapter4;

public class CircularlyLinkedList<T> : LinkedList<T>
{
    public new IEnumerator GetEnumerator() => new CircularEnumerator<T>(this);
}

public class CircularEnumerator<T>(LinkedList<T> list) : IEnumerator<T>
{
    private LinkedListNode<T>? _current = null;
    public T Current => _current != null ? _current.Value : default!;
    object IEnumerator.Current => Current!;
    
    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = list?.First;
            return _current != null;
        }
        else
        {
            _current = _current.Next ?? _current!.List?.First;
            return true;
        }
    }

    public void Reset()
    {
        _current = null;
    }
    
    public void Dispose() {}
}

public static class CircularLinkedListExtensions
{
    public static LinkedListNode<T>? Next<T>(this LinkedListNode<T> n)
    {
        return n != null 
               && 
               n.List != null ? n.Next ?? n.List.First : null;
    }

    public static LinkedListNode<T>? Prev<T>(this LinkedListNode<T> n)
    {
        return n != null 
               && 
               n.List != null ? n.Previous ?? n.List.Last : null;
    }
}