using System.Diagnostics;

namespace Chapter3;

public class PerformanceAnalysis
{
    public static void Demo()
    {
        List<AbstractSort> algorithms = new()
        {
            new SelectionSort(),
            new InsertionSort(),
            new BubbleSort(),
            new MergeSort(),
            new ShellSort(),
            new QuickSort(),
            new HeapSort()
        };

        for (int n = 0; n <= 100000; n += 10000)
        {
            Console.WriteLine($"\nRunning tests for n = {n}:");
            List<(Type type, long Ms)> milliseconds = [];
            for (int i = 0; i < 5; i++)
            {
                int[] array = GetRandomArray(n);
                int[] input = new int[n];
                foreach (AbstractSort algorithm in algorithms)
                {
                    array.CopyTo(input, 0);
                    
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    algorithm.Sort(input);
                    stopwatch.Stop();

                    Type type = algorithm.GetType();
                    long ms = stopwatch.ElapsedMilliseconds;
                    milliseconds.Add((type, ms));

                }
            }

            List<(Type, double)> results = milliseconds
                .GroupBy(r => r.type)
                .Select(r =>
                    (r.Key, r.Average(t => t.Ms))).ToList();
            foreach ((Type type, double avg) in results)
            {
                Console.WriteLine($"{type.Name}: {avg} ms");
            }
        }
    }

    static int[] GetRandomArray(long length)
    {
        Random random = new();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(-100000, 100000);
        }

        return array;
    }
}