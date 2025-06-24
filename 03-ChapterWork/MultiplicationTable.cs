namespace Chapter3;

public class MultiplicationTable
{
    public static void Demo()
    {
        var results = new int[10, 10];

        for (var i = 0; i < results.GetLength(0); i++)
        {
            for (var j = 0; j < results.GetLength(1); j++)
            {
                results[i, j] = (i + 1) * (j + 1);
                Console.Write($"{results[i,j], 4}");
            }
            Console.WriteLine();
        }
    }
}