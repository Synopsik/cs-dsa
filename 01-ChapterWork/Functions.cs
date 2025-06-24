namespace Chapter1;
using Statistics = (int Min, int Max, double Avg);

// ------------------------------------------------------------------------------------------------ //
//                                         Functions                                                //
// ------------------------------------------------------------------------------------------------ //
// Must create classes, enums, structs, etc.
// at the bottom of the file, not the top
public static class Functions
{
    public static Statistics Calculate(params int[] numbers)
    {
        if (numbers.Length == 0) {return (0,0,0);}
        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;
        foreach (int number in numbers)
        {
            if (number > max) { max = number; }
            if (number < min) { min = number; }
            sum += number;
        }
        return (min, max, (double) sum / numbers.Length);
    }
}