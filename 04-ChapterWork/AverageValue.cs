namespace Chapter4;

public class AverageValue
{
    public static void Demo()
    {
        List<double> num = [];
        do
        {
            Console.Write("Enter the number: ");
            string numStr = Console.ReadLine() ?? string.Empty;
            if(!double.TryParse(numStr, out double n)) {break;}
            num.Add(n);
            Console.WriteLine($"Average value: {num.Average()}");            
        } while (true);
    }
}