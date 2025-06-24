using System.Diagnostics;
namespace Chapter3;

public abstract class AbstractSort
{
    public abstract void Sort(int[] a);
}

public class SelectionSort : AbstractSort
{
    public override void Sort(int[] a)
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
}


public class InsertionSort : AbstractSort
{
    public override void Sort(int[] a)
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
}

public class BubbleSort : AbstractSort
{
    public override void Sort(int[] a)
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

            if (!isAnyChange)
            {
                break;
            }
        }
    }
}

public class MergeSort : AbstractSort
{
    public override void Sort(int[] a)
    {
        if (a.Length <= 1)
        {
            return;
        }

        int m = a.Length / 2;
        int[] left = GetSubarray(a, 0, m - 1);
        int[] right = GetSubarray(a, m, a.Length - 1);
        Sort(right);
        Sort(left);

        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                a[k] = left[i++];
            }
            else
            {
                a[k] = right[j++];
            }

            k++;
        }

        while (i < left.Length)
        {
            a[k++] = left[i++];
        }

        while (j < right.Length)
        {
            a[k++] = right[j++];
        }
    }

    public static int[] GetSubarray(int[] sourceArray, int startIndex, int endIndex)
    {
        int[] destinationArray = new int[endIndex - startIndex + 1];
        Array.Copy(sourceArray, startIndex, destinationArray, 0, endIndex - startIndex + 1);
        return destinationArray;
    }
}

public class ShellSort : AbstractSort
{
    public override void Sort(int[] a)
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
}

public class QuickSort : AbstractSort
{
    public override void Sort(int[] a)
    {
        _QuickSort(a, 0, a.Length - 1);
    }

    public static void _QuickSort(int[] array, int lowerIndex, int upperIndex)
    {
        if (lowerIndex >= upperIndex)
        {
            return;
        }

        int pivot = array[upperIndex];
        int j = lowerIndex - 1;
        for (int i = lowerIndex; i < upperIndex; i++)
        {
            if (array[i] < pivot)
            {
                j++;
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        int pivotIndex = j + 1;
        (array[pivotIndex], array[upperIndex]) = (array[upperIndex], array[pivotIndex]);

        _QuickSort(array, lowerIndex, pivotIndex - 1);
        _QuickSort(array, pivotIndex + 1, upperIndex);
    }
}

public class HeapSort : AbstractSort
{
    public override void Sort(int[] array)
    {
        for (int i = array.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(array, array.Length, i);
        }

        for (int i = array.Length - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0);
        }
    }

    public static void Heapify(int[] a, int n, int i)
    {
        int max = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        max = l < n && a[l] > a[max] ? l : max;
        max = r < n && a[r] > a[max] ? r : max;

        if (max == i) return;

        (a[i], a[max]) = (a[max], a[i]);
        Heapify(a, n, max);
    }
}