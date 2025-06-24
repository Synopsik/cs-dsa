namespace Chapter3;

public class Sorting
{
    public static void Demo()
    {
        Random random = new Random();
        int[] array = ResetArray();
        SelectionSort(array);
        Console.WriteLine(string.Join(" | ", array));
        array = ResetArray();

        InsertionSort(array);
        Console.WriteLine(string.Join(" | ", array));
        array = ResetArray();

    }

    
    public static int[] ResetArray() => new[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
    
    
    public static void SelectionSort(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
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
        
    }
    
}