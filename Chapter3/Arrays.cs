namespace Chapter3;

public class Arrays
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          1D Arrays                                               //
    // ------------------------------------------------------------------------------------------------ //
    /* Syntax:
     *          type[] name;
     *
     * 
     */
    public static void ArraysDemo()
    {
        
        float[] temps; // Declare array

        var numbers = new int[5];

        numbers[0] = 9;
        numbers[1] = 19;
        numbers[2] = 29;
        numbers[3] = 39;
        numbers[4] = 49;

        // We can also init on a single line
        var numbers2 = new int[] { 9, -11, 6, -12, 1 };
        // Or
        int[] numbers3 = { 9, -11, 6, -12, 1 };
        // Or
        int[] numbers4 = [ 9, -11, 6, -12, 1 ];
        // Since we know the length of our array, we can specify the middle index
        var middle = numbers[2];

        var last1 = numbers[numbers.Length - 1];
        // this can be simplified with an index operator
        var last2 = numbers[^1];
        
        // Rank returns the number of dimensions for an array
        int rank = numbers.Rank;
        
        // We can use the Exists method to check if there are any elements that match a given predicate
        bool anyPositive = Array.Exists(numbers, e => e > 0);
        
        // We can use TrueForAll to check that all elements match a given predicate
        bool noZeros = Array.TrueForAll(numbers, e => e != 0);
        
        // We can use Find to return the first element that matches a given predicate
        // Good for an extra layer of error handling,
        // ex. If a negative number is caught, what number?
        int firstNegative = Array.Find(numbers, e => e < 0);

        // We can use FindAll to return all results that match a given predicate
        int[] negatives = Array.FindAll(numbers, e => e < 0);
        
        // We can use IndexOf if you just want to check whether an array contains a specific element,
        //  without predicate conditions, returns -1 if not found
        int index = Array.IndexOf(numbers, -12);
        
        // We can use ForEach if we want to perform a map operation on an array
        Array.ForEach(numbers, e => Console.WriteLine(Math.Abs(e)));

        // As it's name suggests, Reverse is a static method used to reverse an array
        Array.Reverse(numbers, 0, 3);
        
        // Sort an array from the smallest to the largest
        Array.Sort(numbers);
        
        // We can Fill an array with a specified value
        Array.Fill(numbers, 3);
        
        // We can Clear an array to zero it out
        Array.Clear(numbers);
        
        // We can Copy an array 
        var subarray = new int[3];
        Array.Copy(numbers, 0, subarray, 0, 3);
        
        // Extension methods - Methods that are "added" to an existing type. These can be called in the same way that
        //                     they are defined directly as instance methods.
        
        // We can use Contains to see whether an element belongs to an array
        bool contains = numbers.Contains(6);
        
        // We can use All to check whether all elements match a given predicate
        bool noZeros2 = numbers.All(n => n != 0);

        // We can use Any to check whether there is a single element that matches a given predicate
        bool anyPositive2 = numbers.Any(n => n > 0);
        
        // Math extension methods - Min Max Average Sum

        int min = numbers.Min();
        int max = numbers.Max();
        double avg = numbers.Average();
        int sum = numbers.Sum();

    }
    
    // ------------------------------------------------------------------------------------------------ //
    //                                          2D Arrays                                               //
    // ------------------------------------------------------------------------------------------------ //
    public static void TwoD_Demo()
    {
        // Create a two-dimensional array
        int[,] numbers = new int[10, 5];

        // Find the end index for each dimension
        var dimOneEnd = numbers.GetLength(0) - 1;
        var dimTwoEnd = numbers.GetLength(1) - 1;
        
        numbers[dimOneEnd, dimTwoEnd] = 17;
        
        // We can also combine a declaration with an initialization
        var numbers2 = new int[,]
        {
            { 9, 5, -9 },
            { -11, 4, 0 },
            { 6, 115, 3 },
            { -12, -9, 71 },
            { 1, -6, -1 }
        };

        // We use the same method to access elements from the array

        int element = numbers2[2, 1];
        numbers2[1, 0] = 11;

    }
    
    // ------------------------------------------------------------------------------------------------ //
    //                                       Multi-D Arrays                                             //
    // ------------------------------------------------------------------------------------------------ //

    public static void threeD_Demo()
    {
        // Create 3-dimensional array
        var numbers3 = new int[3, 2, 3];
    }

    public static void fourD_Demo()
    {
        // Create 4-dimensional array
        var numbers4 = new int[5, 4, 3, 2];
    }
    
    // ------------------------------------------------------------------------------------------------ //
    //                                       Jagged Arrays                                              //
    // ------------------------------------------------------------------------------------------------ //
    public static void Jagged_Demo()
    {
        int[][] numbers = new int[4][];
        numbers[0] = new int[] {9,5};
        numbers[1] = new int[] {0,-3,12};
        numbers[3] = new int[] {54};
        
        Console.WriteLine(numbers[0]);
        Console.WriteLine(numbers[1]);
        Console.WriteLine(numbers[2]);
        Console.WriteLine(numbers[3]);
        
        // It's quicker to use collective expressions
        int[][] numbers2 = new int[4][];
        numbers[0] = [9, 5];
        numbers[1] = [0, -3, 12];
        numbers[3] = [54];
        
        // We can also manually initialize when declaring
        int[][] numbers3 =
        {
            new int[] { 9, 5 },
            new int[] { 0, -3, 12 },
            null!,
            new int[] { 54 }
        };
        
        // Like before, we can use collective expressions to shorten code
        int[][] numbers4 =
        [
            [9, 5],
            [0, -3, 12],
            null!,
            [54]
        ];
        
        // We can access an element from the jagged array using
        int getNumber = numbers4[1][2];
        numbers4[1][1] = 50;
        Console.WriteLine(getNumber);
    }   



}
