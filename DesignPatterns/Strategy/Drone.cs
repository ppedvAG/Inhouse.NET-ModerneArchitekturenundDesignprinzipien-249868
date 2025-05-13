namespace DesignPatterns.Strategy;

public class Drone : IVehicle
{
    public string Name { get; } = "Drone";

    public void Drive()
    {
        Console.WriteLine($"Mit {Name} fliegen lassen");
    }
}