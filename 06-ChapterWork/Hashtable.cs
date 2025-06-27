using System.Collections;
namespace Chapter6;

public class HashtableExample
{
    public static void Demo()
    {
        Hashtable hashtable = new()
        {
            {"Key #1", "Value #1"},
            {"Key #2", "Value #2"}
        };

        hashtable.Add("Key #3", "Value #3");
        hashtable["Key #4"] = "Value #4";
        
        // Hash tables are non-generic, so you need to cast to extract the value
        var value = (string?)hashtable["Key #1"];
        Console.WriteLine(value+"\n\n");
        
        // Loop to access all elements
        foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

public class PhoneBook
{

    public static void PhoneBookDemo()
    {
        Hashtable phoneBook = new()
        {
            {"Marcin", "101-202-303"},
            {"John", "202-303-404"}
        };
        phoneBook["Aline"] = "303-404-505";
        
        Console.WriteLine("Phone numbers:");
        if (phoneBook.Count == 0)
        {
            Console.WriteLine("Empty list.");
        }

        foreach (DictionaryEntry entry in phoneBook)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        
        Console.Write("\nSearch by name: ");
        var name = Console.ReadLine() ?? string.Empty;
        if (phoneBook.ContainsKey(name))
        {
            string number = (string)phoneBook[name]!;
            Console.WriteLine($"Phone number: {number}");
        }
        else
        {
            Console.WriteLine("Does not exist.");
        }
    }
    
    
}