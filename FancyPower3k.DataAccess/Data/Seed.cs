using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.DataAccess.Data;

public static class Seed
{
    internal static void SeedData(ModelBuilder modelBuilder)
    {
        var locations = new List<Location>
        {
            new Location
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Acme Corporation HQ",
                Address = "123 Toon Town Lane",
                Size = 5000,
                DistributionPanels = new List<DistributionPanel>(),
                Employees = new List<Employee>()
            },
            new Location
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Wayne Enterprises",
                Address = "456 Gotham Ave",
                Size = 10000,
                DistributionPanels = new List<DistributionPanel>(),
                Employees = new List<Employee>()
            }
        };

        var distributionPanels = new List<DistributionPanel>
        {
            new DistributionPanel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Main Panel Gotham",
                Description = "Primary distribution panel for Gotham",
                MaxPowerDelivery = 10000,
                LocationId = locations[1].Id,
                Location = locations[1],
                Consumers = new List<Consumer>()
            },
            new DistributionPanel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Backup Panel Toon",
                Description = "Backup distribution panel for Toon Town",
                MaxPowerDelivery = 5000,
                LocationId = locations[0].Id,
                Location = locations[0],
                Consumers = new List<Consumer>()
            }
        };

        locations[0].DistributionPanels.Add(distributionPanels[1]);
        locations[1].DistributionPanels.Add(distributionPanels[0]);

        var consumers = new List<Consumer>
        {
            new Consumer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bugs Bunny Office",
                Description = "Office of Bugs Bunny",
                PowerConsumption = 1500,
                MaxConsumption = 2000,
                DistributionPanelId = distributionPanels[1].Id,
                DistributionPanel = distributionPanels[1]
            },
            new Consumer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Daffy Duck Lab",
                Description = "Lab of Daffy Duck",
                PowerConsumption = 2000,
                MaxConsumption = 2500,
                DistributionPanelId = distributionPanels[1].Id,
                DistributionPanel = distributionPanels[1]
            },
            new Consumer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Batman Cave",
                Description = "Secret cave of Batman",
                PowerConsumption = 5000,
                MaxConsumption = 7000,
                DistributionPanelId = distributionPanels[0].Id,
                DistributionPanel = distributionPanels[0]
            }
        };

        distributionPanels[0].Consumers.Add(consumers[2]);
        distributionPanels[1].Consumers.ToList().AddRange(consumers.Take(2));

        var employees = new List<Employee>
        {
            new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Bugs",
                LastName = "Bunny",
                DateOfBirth = new DateTime(1940, 7, 27),
                JobTitle = "Chief Carrot Officer",
                Salary = 100000,
                LocationId = locations[0].Id,
                Location = locations[0]
            },
            new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Daffy",
                LastName = "Duck",
                DateOfBirth = new DateTime(1937, 4, 17),
                JobTitle = "Head of Chaos",
                Salary = 90000,
                LocationId = locations[0].Id,
                Location = locations[0]
            },
            new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Bruce",
                LastName = "Wayne",
                DateOfBirth = new DateTime(1939, 5, 1),
                JobTitle = "CEO",
                Salary = 200000,
                LocationId = locations[1].Id,
                Location = locations[1]
            }
        };

        locations[0].Employees.ToList().AddRange(employees.Take(2));
        locations[1].Employees.Add(employees[2]);

        modelBuilder.Entity<Location>().HasData(locations);
        modelBuilder.Entity<DistributionPanel>().HasData(distributionPanels);
        modelBuilder.Entity<Consumer>().HasData(consumers);
        modelBuilder.Entity<Employee>().HasData(employees);
    }
}
