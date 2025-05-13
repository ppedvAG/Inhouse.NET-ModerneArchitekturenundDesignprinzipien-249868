namespace DesignPatterns.Strategy;

public class Car : IVehicle
{
    public string Name { get; } = "Car";

    public void Drive()
    {
        Console.WriteLine($"Mit {Name} ausfahren lassen");
    }
}
