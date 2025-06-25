using System.Collections.Generic;
namespace Chapter5;

public class Queue
{
    public static void Demo()
    {
        List<int> items = [2, -4, 1, 8, 5];
        Queue<int> queue = new();
        items.ForEach(queue.Enqueue);
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
            
            
        }
    }
    
    
    
}