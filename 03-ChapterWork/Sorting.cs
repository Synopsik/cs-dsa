using System.Diagnostics;

namespace Chapter3;

public class Sorting
{
    public static void Demo()
    {
        Console.WriteLine("\n\n");
        Random random = new Random();
        int[] array = ResetArray();
        var sw = Stopwatch.StartNew();
        sw.Stop();
        
        Console.WriteLine("Selection Sort");
        sw.Restart();
        SelectionSort(array);
        sw.Stop();
        Console.WriteLine($"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();

        Console.WriteLine("\nInsertion Sort");
        sw.Restart();
        InsertionSort(array);
        sw.Stop();
        Console.WriteLine($"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();
        
        Console.WriteLine("\nBubble Sort");
        sw.Restart();
        BubbleSort(array);
        sw.Stop();
        Console.WriteLine($"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
    }

    
    public static int[] ResetArray() => new[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
    
    
    public static void SelectionSort(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            // Console.WriteLine(string.Join(" | ", a));
            int minIndex = i;
            int minValue = a[i];
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j] < minValue)
                {
                    minIndex = j;
                    minValue = a[j];
                }
            }

            (a[i], a[minIndex]) = (a[minIndex], a[i]);
        }
    }

    public static void InsertionSort(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            // Console.WriteLine(string.Join(" | ", a));
            int j = i;
            while (j > 0 && a[j] < a[j - 1])
            {
                (a[j], a[j - 1]) = (a[j - 1], a[j]);
                j--;
            }
        }
    }

    public static void BubbleSort(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            bool isAnyChange = false;
            for (int j = 0; j < a.Length - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    isAnyChange = true;
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                }
            }
            if (!isAnyChange){break;}
        }
    }
    
}