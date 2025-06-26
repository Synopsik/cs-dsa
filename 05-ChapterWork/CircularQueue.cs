using QueueItem = (System.DateTime StartedAt, System.ConsoleColor Color);
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

    public static async Task CircularCoasterDemo()
    {
        const int rideSeconds = 10;
        Random random = new();
        CircularQueue<QueueItem> queue = new(12);
        ConsoleColor color = ConsoleColor.Black;

        while (true)
        {
            while (queue.Peek() != null)
            {
                QueueItem item = queue.Peek()!.Value;
                TimeSpan elapsed = DateTime.Now - item.StartedAt;
                if (elapsed.TotalSeconds < rideSeconds) {break;}

                queue.Dequeue();
                Log($"> Exits\tTotal: {queue.Count}", item.Color);
            }

            bool isNew = random.Next(3) == 1;
            if (isNew)
            {
                color = color == ConsoleColor.White
                    ? ConsoleColor.DarkBlue
                    : (ConsoleColor)(((int)color) + 1);
                if (queue.Enqueue((DateTime.Now, color)))
                {
                    Log($"< Enters\tTotal: {queue.Count}", color);
                }
                else
                {
                    Log($"! Not allowed\tTotal: {queue.Count}",
                        ConsoleColor.DarkGray);
                }
            }

            await Task.Delay(500);
        }
    }

    private static void Log(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} {text}");
        Console.ResetColor();
    }
}
