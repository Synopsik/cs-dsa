namespace Chapter2;

public class MeanCalcAlg
{
    public static void MeanDemo()
    {
        double sum = 0;
        Console.Write("Number Count = ");
        int.TryParse(Console.ReadLine(), out var n);
        if (n == 0) {Console.WriteLine("No result.");}

        var i = 0;
        do
        {
            Console.Write("Number = ");
            double.TryParse(Console.ReadLine(), out var a);
            sum += a;
            i++;
        } while (i != n);

        var result = sum / n;
        Console.WriteLine($"Result: {result:F2}");
    }
}