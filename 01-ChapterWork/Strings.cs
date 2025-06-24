namespace Chapter1;

public class Strings
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          Strings                                                 //
    // ------------------------------------------------------------------------------------------------ //
    /*
     * A string can be set to a sequence of characters, a single char, an empty string, and null
     * Concatenation x + y is how you can perform operations on strings, duh!
     * You can access a character in a string using []
     * True will return from comparisons (==) if they contain the same sequence of characters
     */
    
    public static void StringsDemo()
    {
        string firstName = "Syn", lastName = "opsik"; // Same data types can be called on a single line
        int year = 6009;
        string note1 = firstName + " " + lastName.ToUpper() + " was born in " + year;
        string initials = firstName[0] + "." + lastName[0].ToString().ToUpper() + ".";
        
        Console.WriteLine(note1);
        Console.WriteLine(initials);
        
        // A composite format string can be used to construct a string with parameters 
        string formatNote = string.Format("{0}{1} was born in {2}", firstName, lastName, year);
        Console.WriteLine(formatNote);
        
        // An interpolated string can be used to construct a string with variables in the parameter
        string note2 = $"{firstName}{lastName} started programming in {year}";
        Console.WriteLine(note2);
        
        // Init names
        string[] names = ["Wade", "Frank", "Edward"];
        
        // Init dates
        DateTime[] dates = [
            new(1988, 11, 9), 
            new(1995, 4, 25), 
            new(2003, 7, 23)
        ];
        
        // Init temps
        float[] temperatures = [36.6f, 39.1f, 35.9f];
        
        // Using interpolated strings, we also have options for alignment and formatting
        Console.WriteLine($"{"Name", -8} {"Birth date", 10} {"Temp. [C]", 11} -> Result");
        
        // Print results
        for (int i = 0; i < names.Length; i++)
        {
            string line = $"{names[i],-8} " +
                          $"{dates[i],10:dd.MM.yyyy} " +
                          $"{temperatures[i],11:F1} -> " +
                          $"{temperatures[i] switch
                          {
                              > 40.0f => "Very high",
                              > 37.0f => "High",
                              > 36.0f => "Normal",
                              > 35.0f => "Low",
                              _ => "Very Low"
                          }}";
            Console.WriteLine(line);
        }
    }
}