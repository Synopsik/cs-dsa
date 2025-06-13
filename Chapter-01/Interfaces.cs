namespace Chapter1;

public class Interfaces
{
    public static void InterfacesDemo()
    {
        Classes.FutureDevice demo = new Classes.FutureDevice()
        {
            Id = 24,
            Model = "XYZ22",
            Year = 2025
        };
        Console.WriteLine($"{"ID",-5} {"Model",10} {"Year",11}");
        Console.WriteLine($"{demo.Id,-5} {demo.Model,10} {demo.Year,11}");
    }
}

public interface IDevice
{
    int Id { get; set; }
    string Model { get; set; }
    int Year { get; set; }
    void Configure(Classes.DeviceConfiguration configuration);
    bool Start();
    bool Stop();
}