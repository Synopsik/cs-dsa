using System.Collections.Generic;
using Priority_Queue;
namespace Chapter5;

public class Queue
{
    public static async Task Demo()
    {
        Header("Basic Integer Queue");
        List<int> items = [2, -4, 1, 8, 5];
        Queue<int> queue = new();
        items.ForEach(queue.Enqueue);
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
        
        await QueueDemo();
        ConcurrentDemo();
        await PriorityDemo();
    }
    
    public static async Task QueueDemo()
    {
        /*
        / ------------------------------------------------------------ /
        /                            Queue                             /
        / ------------------------------------------------------------ /
        */
        Header("Queue Demo");
        Random random = new();

        CallCenter center = new();
        center.Call(1234, true);
        center.Call(5678, true);
        center.Call(1468, true);
        center.Call(9641, true);

        void Log(string text) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");

        while (center.AreWaitingCalls())
        {
            IncomingCall call = center.Answer("Marcin")!;

            Log($"Call #{call.Id} from client " +
                $"#{call.ClientID} answered by {call.Consultant}.");

            await Task.Delay(random.Next(1000, 10000));

            center.End(call);

            Log($"Call #{call.Id} from client " +
                $"#{call.ClientID} ended by {call.Consultant}");
        }
    }

    public static void ConcurrentDemo()
    {
        /*
        / ------------------------------------------------------------ /
        /                    Concurrent Queue                          /
        / ------------------------------------------------------------ /
        */ 
        Header("Concurrent Queue Demo");
        
        Random random = new();
        CallCenter center = new();
        Parallel.Invoke(
            () => Clients(center),
            () => Consultant(center, "Marcin", ConsoleColor.Red),
            () => Consultant(center, "James", ConsoleColor.Yellow),
            () => Consultant(center, "Olivia", ConsoleColor.Green));
        return;

        void Clients(CallCenter center)
        {
            var callerCount = 0;
            
            while (callerCount < 5)
            {
                var clientId = random.Next(1, 10000);
                IncomingCall call = center.Call(clientId, true);
                Log($"Incoming call #{call.Id} from client #{clientId} ");
                Log($"Waiting calls in the queue: {center.Calls.Count}");
                Thread.Sleep(random.Next(500,2000));
                callerCount++;
            }
        }

        void Consultant(CallCenter center, string name, ConsoleColor color)
        {
            while (true)
            {
                Thread.Sleep(random.Next(500,1000));
                IncomingCall? call = center.Answer(name);
                if (call == null) {break;}

                Log($"Call #{call.Id} from client #{call.ClientID} " +
                    $"answered by {call.Consultant}.", color);
                Thread.Sleep(random.Next(1000, 10000));
            }
        }

        void Log(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fff}] {text}");
            Console.ResetColor();
                
        }
    }
    
    public static async Task PriorityDemo()
    {
        /*
        / ------------------------------------------------------------ /
        /                        Priority Queue                        /
        / ------------------------------------------------------------ /
        / 
        */
        Header("Priority Queue Demo");
        SimplePriorityQueue<string> queue = new();
        queue.Enqueue("Marcin", 1);
        queue.Enqueue("Lily", 1);
        queue.Enqueue("Mary", 2);
        queue.Enqueue("John", 0);
        queue.Enqueue("Emily", 1);
        queue.Enqueue("Sarah", 2);
        queue.Enqueue("Luke", 1);
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
        
        
        /*
        / ------------------------------------------------------------ /
        /                     Priority Call Center                     /
        / ------------------------------------------------------------ /
        /
        */
        Header("Priority Call Center Demo");
        Random random = new();

        CallCenter center = new();
        center.Call(1234, false);
        center.Call(5678, true);
        center.Call(1468, false);
        center.Call(9641, true);

        while (center.AreWaitingCalls())
        {
            var call = center.Answer("Marcin");
            Log($"Call #{call.Id} from client #{call.ClientID} " +
                $"is answered by {call.Consultant}.", 
                call.IsPriority);
            await Task.Delay(random.Next(1000, 10000));
            center.End(call);
            Log($"Call #{call.Id} from client #{call.ClientID} " +
                $"is ended by {call.Consultant}", call.IsPriority);
        }

        void Log(string text, bool isPriority)
        {
            Console.ForegroundColor = isPriority ? 
                ConsoleColor.Red : ConsoleColor.Gray;
            
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
            Console.ResetColor();
        }

        
    }
    static void Header(string title)
    {
        Console.WriteLine("\n--------------------------------------------");
        Console.WriteLine($"{title}:");
        Console.WriteLine("--------------------------------------------");
    }
}

