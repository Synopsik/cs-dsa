namespace Chapter1;

public class Classes
{
    // ------------------------------------------------------------------------------------------------ //
    //                                          Classes                                                 //
    // ------------------------------------------------------------------------------------------------ //
    /*
     * C# is an object-oriented language that supports declaring classes with various members like,
     * constructors, finalizers, constants, fields, properties, indexers, events, methods, operators, and delegates
     *
     * Classes in C# also support inheritance and implementing interfaces
     * static, abstract, sealed, and virtual members are also available
     * access modifiers include public, protected, internal, private, and file
     *
     * Accessors: get to return the property value
     *            set to assign a new value for the property
     *            init to set a value during object construction and prevent modifications
     *
     * By combining accessor we can create permissions categories:
     *           Read-only with the get accessor and without the set accessor
     *           Write-only with the set accessor and without the get accessor
     *           Read-write with both get and set accessors
     */
    public static void ClassesDemo()
    {
        Person person = new("Test") { Age = 30 };
        person.Relocate("123");
        var distance = person.GetDistance("200");
        if (distance > 0) {Console.WriteLine(distance);}

        PersonShorthand shortPerson = new("Short Test") { Age = 60 };
        shortPerson.Relocate("234a");
        var shortDistance = shortPerson.GetDistance("300");
        if (shortDistance > 0) {Console.WriteLine(shortDistance);}
    }
    
    
    
    public class Person
    {
        private string _location = string.Empty;
        
        public string Name { get; set; } // getter & setter setup Name & Age
        public required int Age { get; set; } // required if this should be set on init

        // Default for if no name is provided?
        public Person() => Name = "---"; // expression body definition

        // Constructor
        public Person(string name)
        {
            Name = name;
        }

        // Public method for updating Persons private _location
        public void Relocate(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                _location = location;
            }
        }

        // Single line method, lambda can return float
        public float GetDistance(string location) => DistanceHelper.GetDistance(_location, location);
    }

    public class PersonShorthand(string name)
    {
        // Our Person class can be condensed to 5 simple lines
        private string _location = string.Empty;
        public string Name { get; set; } = name;
        public required int Age { get; set; }
        public void Relocate(string? location) => _location = location ?? _location;
        public float GetDistance(string location) => DistanceHelper.GetDistance(_location, location);
    }
    

    public static class DistanceHelper
    {
        /*
         * DistanceHelpers class is static so that we don't have to instantiate the class to use its members
         * the Same with all the methods, they need to be static, so we can call without creating DistanceHelper objects
         */
        public static float GetDistance(string a, string b)
        {
            try
            {    // We try and convert strings a and b to a float type
                var loc1 = float.Parse(a);
                var loc2 = float.Parse(b);
                // Then return the difference of the two
                return loc2 - loc1;
            }
            catch {Console.WriteLine("Error: Please enter a valid integer."); return 0;}
        }   
    }

    public class DeviceConfiguration
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public DeviceConfiguration(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
    }

    public class FutureDevice : IDevice
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void Configure(Classes.DeviceConfiguration configuration)
        {
            Console.WriteLine($"Configuring device {Id} with model {Model}");
            ArgumentNullException.ThrowIfNull(configuration);
            Console.WriteLine(configuration);
            
        }

        public bool Start() {return false;}
        public bool Stop() {return false;}
    }
    
    
    
}