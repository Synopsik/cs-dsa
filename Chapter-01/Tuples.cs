namespace Chapter1;

public class Tuples
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          Tuples                                                  //
    // ------------------------------------------------------------------------------------------------ //
    // If you only set the data type, you can access the Items through result

    public void DemonstrateTuples()
    {

        (int, int, double) result1 = Functions.Calculate(4, 8, 13);
        Console.WriteLine($"Min = {result1.Item1} / Max = {result1.Item2} / Avg = {result1.Item3:F2}");

        // Otherwise you can create multiple new variables
        (int min, int max, double avg) = Functions.Calculate(5, 22, 63);
        Console.WriteLine($"Min = {min} / Max = {max} / Avg = {avg:F2}");
    }
}