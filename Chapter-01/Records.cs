namespace Chapter1;

// ------------------------------------------------------------------------------------------------ //
//                                          Records                                                 //
// ------------------------------------------------------------------------------------------------ //
/*
 * Records have inherited functionality that allows equality-based comparisons
 * They differ from a class, when two records are compared they are only equal
 * if they are references the same data
 * Keywords include: record
 *                   record class
 * 
 */


public record Ant(string Name, string Type, int Height, float Weight, int Age);

public record Robot
{
    public required string Name  { get; set; }
    public required string Job   { get; set; }
    public required int Height   { get; set; }
    public required float Weight { get; set; }
    public required int Lifespan { get; set; }
}


public class Records
{
    public static void RecordsDemo()
    {
        // A primary constructor automatically creates properties for you
        Ant ant = new Ant("Ted", "Fire", 1, 0.1f, 1);
        Console.WriteLine(ant);

        // ant.Name = "Fred"; Causes errors, can't alter record after init
        
        // Robot Record isn't using a primary constructor;
        // therefore, explicit properties were marked with required and must be labeled
        Robot robot = new Robot
        {
            Name     = "C348",
            Job      = "Firehydrant",
            Height   = 2000,
            Weight   = 300.2f,
            Lifespan = 999999
        };
        Console.WriteLine(robot);
        robot.Name = "T999"; // Can change the name of this record
        Console.WriteLine(robot);

        // non-destructive mutation
        Robot paperweight = robot with { Name = "Beep", Height = 9999 };
        Console.WriteLine(paperweight);
        
    }
}