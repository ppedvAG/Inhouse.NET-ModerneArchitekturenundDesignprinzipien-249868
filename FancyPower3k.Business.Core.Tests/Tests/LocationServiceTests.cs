using FancyPower3k.Business.Core.Services;
using FancyPower3k.DataAccess.Tests.Extensions;
using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Tests.Tests;

[TestClass]
public class LocationServiceTests
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public async Task GetAllLocationsAsync_ReturnsLocations()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var service = new LocationService(context);

            // Act
            var locations = await service.GetAllLocationsAsync();

            // Assert
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Any());
        }
    }

    [TestMethod, Ignore("TODO use data from Seed")]
    public async Task CalculateLoadAsync_ReturnsCorrectLoad()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var service = new LocationService(context);
            var location = new Location
            {
                DistributionPanels = new List<DistributionPanel>
                {
                    new DistributionPanel
                    {
                        MaxPowerDelivery = 1000,
                        Consumers = new List<Consumer>
                        {
                            new Consumer { PowerConsumption = 200 },
                            new Consumer { PowerConsumption = 300 }
                        }
                    }
                }
            };
            context.Locations.Add(location);
            await context.SaveChangesAsync();

            // Act
            var load = await service.CalculateLoadAsync(location.Id);

            // Assert
            Assert.AreEqual(50, load);
        }
    }

    [TestMethod, Ignore("TODO use data from Seed")]
    public async Task GetWorkloadsAsync_ReturnsWorkloads()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var service = new LocationService(context);
            var location = new Location
            {
                DistributionPanels = new List<DistributionPanel>
                {
                    new DistributionPanel
                    {
                        Name = "Panel 1",
                        MaxPowerDelivery = 1000,
                        Consumers = new List<Consumer>
                        {
                            new Consumer { PowerConsumption = 200 },
                            new Consumer { PowerConsumption = 300 }
                        }
                    }
                }
            };
            context.Locations.Add(location);
            await context.SaveChangesAsync();

            // Act
            var workloads = await service.GetWorkloadsAsync(location.Id);

            // Assert
            Assert.IsNotNull(workloads);
            Assert.IsTrue(workloads.Any());
            Assert.AreEqual(500, workloads.First().CurrentWorkloadInKW);
            Assert.AreEqual(1000, workloads.First().MaxWorkloadInKW);
        }
    }
}