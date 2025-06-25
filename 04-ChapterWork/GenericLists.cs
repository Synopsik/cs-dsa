using System.Collections.Generic;
namespace Chapter4;

public class GenericLists
{
    public static void Demo()
    {
        List<int> list = [6, 90, -20, 0, 4, 1, 8, -20, 41];
        var min = list.Min();
        var max = list.Max();
        var sum = list.Sum();
        var avg = list.Average();
        
        // All results as shown in the book: -20, 90, 110, and 12.22
        Console.WriteLine($"\n\nMin: {min}\nMax: {max}\nSum: {sum}\nAvg: {avg:F2}");

        var allPositive = list.All(x => x > 0);
        var anyZero = list.Any(x => x == 0);
        
        Console.WriteLine($"\n\nAll Positive: {allPositive}\n" +
                          $"Any Zero: {anyZero}");

        var existingElement = list.ElementAtOrDefault(5);
        var nonExistingElement = list.ElementAtOrDefault(100);

        Console.WriteLine($"\n\nExisting: {existingElement}\n" +
                          $"Non Existing: {nonExistingElement}");

        var unique = list.Distinct().ToList();
        var ordered = list.OrderBy(x => x).ToList();
        var skipped = list.Skip(4).ToList();
        var taken = list.Take(3).ToList();

        Console.WriteLine($"\n\nUnique List: {string.Join(", ", unique)}\n" +
                          $"Ordered List: {string.Join(", ", ordered)}\n" +
                          $"Skip first 4 elems: {string.Join(", ", skipped)}\n" +
                          $"Take first 3 elems: {string.Join(", ", taken)}");
        
        /* Pagination technique, non-functional example
        var page = 1; // can choose 1 through x number of pages
        var size = 10; // page offset size

        List<int> items = list
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
        */
    }
}