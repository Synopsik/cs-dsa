namespace Chapter1;

public class Objects
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          Objects                                                 //
    // ------------------------------------------------------------------------------------------------ //
    /*
     * Everything in C# derives from Object
     * The Object class is declared in the System namespace
     * This creates a unified type system where all built-in
     * types derive from the Object class
     * A few methods that are available to all objects:
     *  ToString()    - Returns a string representation of the object
     *  GetType()     - Returns a type of the instance
     *  Equals()      - Checks whether the object is equal to a given object
     *  GetHashCode() - Uses the hash function and returns its result
     */
    public static void ObjectsDemo()
    {
        // Created int type variable age
        int age = 28;
        int age2 = 27;
        Console.WriteLine(age);
        
        // Boxing operation i.e. "Boxing" (Casting) an int type into an object type
        object ageBoxing = age;
        Console.WriteLine(ageBoxing);
        
        Console.WriteLine(ageBoxing.ToString());
        Console.WriteLine(ageBoxing.GetType());
        Console.WriteLine(ageBoxing.Equals(age));  // Comparing integer not reference
        Console.WriteLine(ageBoxing.Equals(age2)); // If age2 = 28 this is True
        Console.WriteLine(ageBoxing.GetHashCode());
        
        // Unboxing operation i.e. "Unboxing" (Casting) an object type back to an int type
        int ageUnboxing = (int)ageBoxing;
        Console.WriteLine(ageUnboxing);
        
        
        
        
    }
}