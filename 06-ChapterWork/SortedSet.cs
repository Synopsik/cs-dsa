using System.Collections.Generic;
namespace Chapter6;


public class SortedSet
{

    public static void Demo()
    {
        List<string> names =
        [
            "Marcin", "Mary", "James", "Albert", "Lily",
            "Emily", "marcin", "James", "Jane"
        ];

        SortedSet<string> sorted = new(
            names,
            Comparer<string>
                .Create((a, b) =>
                a.ToLower().CompareTo(b.ToLower())));

        foreach (var name in sorted)
        {
            Console.WriteLine(name);
        }
    }   
}
