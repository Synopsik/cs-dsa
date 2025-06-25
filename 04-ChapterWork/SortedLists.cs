using System.Collections.Generic;
namespace Chapter4;


public class AddressBook
{
    public record Person
    (
        string Name,
        string Street,
        string PostalCode,
        string City,
        string Country
    );
    
    public static void Demo()
    {
        SortedList<string, Person> people = new()
        {
            {
                "Marcin Jamro", 
                new Person(
                "Marcin Jamro", 
                "Polish Street 1/23", 
                "35-001", 
                "Rzeszow", 
                "PL"
                )
            },
            {
                "Martyna Kowalski",
                new Person(
                "Martyna Kowalski",
                "World Street 5",
                "00-123",
                "Warsaw",
                "PL"
                )
            }
        }; // people var

        people.Add(
            "Mark Smith", 
            new Person(
            "Mark Smith",
            "German Street 6",
            "10000",
            "Berlin",
            "DE"
            ));

        foreach ((string k, Person p) in people)
        {
            Console.WriteLine($"{k}: {p.Street}, {p.PostalCode} {p.City}, {p.Country}.");
        }

    } // Demo
} // AddressBook