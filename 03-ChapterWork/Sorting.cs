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
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();

        Console.WriteLine("\nInsertion Sort");
        sw.Restart();
        InsertionSort(array);
        sw.Stop();
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();
        
        Console.WriteLine("\nBubble Sort");
        sw.Restart();
        BubbleSort(array);
        sw.Stop();
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();
        
        Console.WriteLine("\nMerge Sort");
        sw.Restart();
        MergeSort(array);
        sw.Stop();
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();
        
        Console.WriteLine("\nShell Sort");
        sw.Restart();
        ShellSort(array);
        sw.Stop();
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        
        array = ResetArray();
        
        Console.WriteLine("\nSort Part");
        sw.Restart();
        SortPart(array);
        sw.Stop();
        Console.WriteLine($"{string.Join(" | ", array)}\n" +
                          $"Time Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
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

    public static void MergeSort(int[] a)
    {
        if (a.Length <= 1) {return;}

        int m = a.Length / 2;
        int[] left = GetSubarray(a, 0, m - 1);
        int[] right = GetSubarray(a, m, a.Length - 1);
        MergeSort(left);
        MergeSort(right);

        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j]) { a[k] = left[i++]; }
            else {a[k] = right[j++];}
            k++;
        }
        while ( i < left.Length) {a[k++] = left[i++];}
        while (j < right.Length) {a[k++] = right[j++];}
    }

    public static int[] GetSubarray(int[] sourceArray, int startIndex, int endIndex)
    {
        int[] destinationArray = new int[endIndex - startIndex + 1];
        Array.Copy(sourceArray, startIndex, destinationArray, 0, endIndex - startIndex + 1);
        return destinationArray;
    }


    public static void ShellSort(int[] a)
    {
        for (int h = a.Length / 2; h > 0; h /= 2)
        {
            for (int i = h; i < a.Length; i++)
            {
                int j = i;
                int ai = a[i];

                while (j >= h && a[j - h] > ai)
                {
                    a[j] = a[j - h];
                    j -= h;
                }

                a[j] = ai;
            }
        }
    }

    public static void SortPart(int[] a){PartSort(a, 0, a.Length - 1);}

    public static void PartSort(int[] a, int l, int u)
    {
        if (l >= u) {return;}

        int pivot = a[u];
        int j = l - 1;
        for (int i = l; i < u; i++)
        {
            if (a[i] < pivot)
            {
                j++;
                (a[j], a[i]) = (a[i], a[j]);
            }
        }

        int p = j + 1;
        (a[p], a[u]) = (a[u], a[p]);

        PartSort(a, l, p - 1);
        PartSort(a, p + 1, u);
    }
}