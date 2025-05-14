using FancyPower3k.DomainModel.Entities;
using FancyPower3k.DomainModel.Enums;
using Microsoft.EntityFrameworkCore;

public static class Seed
{
    #region Predefined GUIDs
    public const string Location1Id = "123e4567-e89b-12d3-a456-426614174000";
    public const string Location2Id = "123e4567-e89b-12d3-a456-426614174001";
    public const string DistributionPanel1Id = "123e4567-e89b-12d3-a456-426614174002";
    public const string DistributionPanel2Id = "123e4567-e89b-12d3-a456-426614174003";
    public const string Consumer1Id = "123e4567-e89b-12d3-a456-426614174004";
    public const string Consumer2Id = "123e4567-e89b-12d3-a456-426614174005";
    public const string Consumer3Id = "123e4567-e89b-12d3-a456-426614174006";
    public const string BaseEmployeeId = "123e4567-e89b-12d3-a456-426614174"; 
    #endregion

    public const int Consumer1PowerConsumption = 1500;
    public const int Consumer2PowerConsumption = 2000;
    public const int Consumer1MaxConsumption = 2000;
    public const int Consumer2MaxConsumption = 2500;
    public const int DistributionPanel2MaxPowerDelivery = 5000;


    private static readonly Random _random = new(42);
    private static readonly string[] _firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Robert", "Jennifer", "William", "Lisa" };
    private static readonly string[] LastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson" };

    public static void SeedData(ModelBuilder modelBuilder)
    {
        var locations = new List<Location>
        {
            new Location
            {
                Id = Location1Id,
                Name = "Acme Corporation HQ",
                Address = "123 Toon Town Lane",
                Size = 5000
            },
            new Location
            {
                Id = Location2Id,
                Name = "Wayne Enterprises",
                Address = "456 Gotham Ave",
                Size = 10000
            }
        };

        var distributionPanels = new List<DistributionPanel>
        {
            new DistributionPanel
            {
                Id = DistributionPanel1Id,
                Name = "Main Panel Gotham",
                Description = "Primary distribution panel for Gotham",
                MaxPowerDelivery = 10000,
                LocationId = locations[1].Id
            },
            new DistributionPanel
            {
                Id = DistributionPanel2Id,
                Name = "Backup Panel Toon",
                Description = "Backup distribution panel for Toon Town",
                MaxPowerDelivery = DistributionPanel2MaxPowerDelivery,
                LocationId = locations[0].Id
            }
        };

        var consumers = new List<Consumer>
        {
            new Consumer
            {
                Id = Consumer1Id,
                Name = "Bugs Bunny Office",
                Description = "Office of Bugs Bunny",
                PowerConsumption = Consumer1PowerConsumption,
                MaxConsumption = Consumer1MaxConsumption,
                DistributionPanelId = distributionPanels[1].Id
            },
            new Consumer
            {
                Id = Consumer2Id,
                Name = "Daffy Duck Lab",
                Description = "Lab of Daffy Duck",
                PowerConsumption = Consumer2PowerConsumption,
                MaxConsumption = Consumer2MaxConsumption,
                DistributionPanelId = distributionPanels[1].Id
            },
            new Consumer
            {
                Id = Consumer3Id,
                Name = "Batman Cave",
                Description = "Secret cave of Batman",
                PowerConsumption = 5000,
                MaxConsumption = 7000,
                DistributionPanelId = distributionPanels[0].Id
            }
        };

        var employees = CreateEmployees(locations);

        modelBuilder.Entity<Location>().HasData(locations);
        modelBuilder.Entity<DistributionPanel>().HasData(distributionPanels);
        modelBuilder.Entity<Consumer>().HasData(consumers);
        modelBuilder.Entity<Employee>().HasData(employees);
    }

    public static IEnumerable<Employee> CreateEmployees(List<Location> locations, int count = 50)
    {
        for (int i = 0; i < count; i++)
        {
            string employeeId = $"{BaseEmployeeId}{i:D3}"; // Increment the last 3 digits
            yield return new Employee
            {
                Id = employeeId,
                FirstName = _firstNames[_random.Next(_firstNames.Length)],
                LastName = LastNames[_random.Next(LastNames.Length)],
                DateOfBirth = new DateTime(_random.Next(1960, 2000), _random.Next(1, 13), _random.Next(1, 29)),
                JobTitle = ((JobPosition)_random.Next(Enum.GetNames(typeof(JobPosition)).Length)).ToString(),
                Position = (JobPosition)_random.Next(Enum.GetNames(typeof(JobPosition)).Length),
                Salary = _random.Next(50, 150) * 1000,
                LocationId = locations[_random.Next(locations.Count)].Id
            };
        }
    }
}
