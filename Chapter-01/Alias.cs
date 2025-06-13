namespace Chapter1;
using Statistics = (int Min, int Max, double Avg);


public static class Alias
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          Alias                                                   //
    // ------------------------------------------------------------------------------------------------ //
    // We can create an alias called Statistics at the beginning of this file ^^
    public static void AliasDemo()
    {
        Statistics result2 = Functions.Calculate(420, 69, 1337);
        Console.WriteLine($"Min = {result2.Min} / Max = {result2.Max} / Avg = {result2.Avg:F2}");
    }
}
