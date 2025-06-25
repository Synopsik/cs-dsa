namespace Chapter4;

public class ListOfPeople
{
    public record Person(string Name, int Age, string Country);
    
    public static void Demo()
    {
        List<Person> people =
        [
            new("Marcin", 35, "PL"),
            new("Sabine", 25, "DE"),
            new("Mark", 31, "PL")
        ];

        var sortedByName = people.OrderBy(p => p.Name).ToList();

        // The container type must be specified for a collection expression
        List<Person> sortedByNameCollectionExpression = [.. people.OrderBy(p => p.Country)];
        
        Console.WriteLine(string.Join("\n", sortedByName));
        Console.WriteLine("\n" + string.Join("\n", sortedByNameCollectionExpression));
        
        // --------------------------------------------------------------------------- //
        //                             LINQ Expressions                                //
        // --------------------------------------------------------------------------- //

        var methodSyntax = people
            .Where(p => p.Age <= 30)
            .OrderBy(p => p.Name)
            .Select(p => p.Name)
            .ToList();

        var querySyntax = (from p in people
                                where p.Age <= 30
                                orderby p.Name
                                select p.Name).ToList();
        
    }
}