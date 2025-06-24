namespace Chapter3;

public class Sorting
{
    public static void Demo()
    {
        Random random = new Random();
        int[] array = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
        SelectionSort(array);
        Console.WriteLine(string.Join(" :: ", array));
    }
    
    
    
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

    
}