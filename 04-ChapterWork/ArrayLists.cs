using System.Collections;
namespace _04_ChapterWork;

public class ArrayLists
{
    public static void Demo()
    {
        ArrayList arrayList = [5];
        arrayList.Add(6);
        arrayList.AddRange(new int[] {-7, 8});
        arrayList.AddRange(new object[] {"Marcin", "Kate"});
        arrayList.Insert(5, 7.8);

        object first = arrayList[0]!;
        int third = (int)arrayList[2]!;

        // Single-line implementation for printing the list
        Console.WriteLine($"Array List: {string.Join(", ", arrayList.ToArray())}");

        int count = arrayList.Count;
        int capacity = arrayList.Capacity;

        bool containsMarcin = arrayList.Contains("Marcin");
        
        // Another way to determine if a list "contains" something
        bool containsAnn = arrayList.IndexOf("Ann") >= 0;

        int minusIndex = arrayList.IndexOf(-7);

        arrayList.Remove(5);
        arrayList.RemoveAt(1);
        arrayList.RemoveRange(1, 2);
        arrayList.Clear();

        arrayList.Reverse();
        arrayList.ToArray();
        
    }
}