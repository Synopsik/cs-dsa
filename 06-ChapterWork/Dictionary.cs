using System.Collections;
using System.Collections.Generic;
namespace Chapter6;

public class Dictionary
{
    public static void Demo()
    {
        Example();
        ProductLocationDemo();
        UserDetailsDemo();
    }

    private static void Example()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "Key #1", "Value #1" },
            { "Key #2", "Value #2" }
        };

        var value = dictionary["Key #1"];

        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        /*
         * Simplified Version
         *
         * foreach ((strink k, string v) in dictionary)
         * {
         *     Console.WriteLine($"{k}: {v}");
         * }
         */   
    }

    public static void ProductLocationDemo()
    {
        Dictionary<string, string> products = new()
        {
            {"423423512512", "A1"},
            {"123235324234", "B5"},
            {"545234512312", "C9"}
        };
        products["545234512313"] = "D7";
        
        // Using the Add method
        var key = "153235324254";
        if (!products.ContainsKey(key))
        {
            products.Add(key, "A3");
        }
        
        // There is also the TryAdd method
        if (!products.TryAdd(key, "B4"))
        {
            Console.WriteLine("Cannot add.");
        }
        
        // Write all Keys and Values to console
        Console.WriteLine("All Products:");
        if (products.Count == 0){Console.WriteLine("Empty.");return;}

        foreach ((string k, string v) in products)
        {
            Console.WriteLine($"{k} -> {v}");
        }
        
        //  Use TryGetValue to check if the element exists first
        Console.Write("\nSearch by barcode: ");
        var barcode = Console.ReadLine() ?? string.Empty;
        if (products.TryGetValue(barcode, out string? location))
        {
            Console.WriteLine($"The product is in: {location}.");
        }
        else
        {
            Console.WriteLine("The product does not exist.");
        }
    }

    public record Employee(string FirstName, string LastName, string PhoneNumber);
    
    public static void UserDetailsDemo()
    {
        Dictionary<int, Employee> employees = new()
        {
            { 100, new Employee("Marcin", "Jamro", "101-202-303") },
            { 210, new Employee("John", "Smith", "202-303-404") },
            { 303, new Employee("Aline", "Weather", "303-404-505") }
        };

        do
        {
            Console.Write("Enter the identifier: ");
            var idString = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(idString, out var id))
            {
                break;
            }

            if (employees.TryGetValue(id, out var employee))
            {
                Console.WriteLine(
                    "Full name: {0} {1}\nPhone number: {2}\n",
                    employee.FirstName,
                    employee.LastName,
                    employee.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Does not exist.\n");
            }
        } while (true);
    }


    public static void SortedDictionaryDemo()
    {
        SortedDictionary<string, string> dictionary = new()
        {
            { "Key #1", "Value #1" },
            { "Key #2", "Value #2" },
        };
        dictionary.Add("Key #3", "Value #3");
        dictionary["Key #4"] = "Value #4";
        var value = dictionary["Key #1"];
        dictionary.TryGetValue("Key #2", out var result);
    }

    public static void EncyclopediaDemo()
    {
        Console.WriteLine("Welcome to you encyclopedia!\n");
        SortedDictionary<string, string> definitions = [];
        do
        {
            Console.WriteLine("\nChoose option ([A]dd, [L]ist): ");
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.A)
            {
                Console.Write("Enter the key: ");
                var key = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter the explanatiton: ");
                string explanation = Console.ReadLine() ?? string.Empty;
                definitions[key] = explanation;
            }
            else if (keyInfo.Key == ConsoleKey.L)
            {
                foreach ((string k, string e) in definitions)
                {
                    Console.WriteLine($"{k}: {e}");
                }
            }
            else
            {
                Console.WriteLine("Do you want to exit? Y or N.");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    break;
                }
            }
        } while (true);
    }
}