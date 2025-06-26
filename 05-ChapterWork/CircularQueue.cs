namespace Chapter5;

public class CircularQueue<T>(int size) 
    where T : struct
{
    private readonly T[] _items = new T[size];
    private int _front = -1;
    private int _rear = -1;
    private int _count = 0;
    public int Count => _count;

    
    public bool Enqueue(T item)
    {
        if (_count == _items.Length) { return false; }
        
        if (_front < 0) { _front = _rear = 0; }
        else { _rear = ++_rear % _items.Length;  }

        _items[_rear] = item;
        _count++;
        return true;
    }

    public T? Dequeue()
    {
        if (_count == 0) {return null;}

        T result = _items[_front];
        // If there is only one element (i.e., front == rear), set empty (-1) 
        if (_front == _rear) { _front = _rear = -1; }
        // Else increment the front pointer (set to start if at finish using %)
        else { _front = ++_front % _items.Length; }

        _count--;
        return result;
    }

    public T? Peek()
    {
        if (_count == 0) {return null;}

        return _items[_front];
    }

    public static void CircularDemo()
    {
        CircularQueue<int> queue = new(8);
        queue.Enqueue(2);
        queue.Enqueue(-4);
        queue.Enqueue(1);
        queue.Enqueue(8);
        queue.Enqueue(5);

        while(true)
        {
            if (queue.Count > 0) { Console.WriteLine(queue.Dequeue()); }
            else {return;}
        }
    }

    public static void CircularCoasterDemo()
    {
        
    }
}