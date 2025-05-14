using FancyPower3k.Business.Core.Services;
using FancyPower3k.DataAccess.Tests.Extensions;
using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Tests.Tests;

[TestClass, Ignore("TODO use data from Seed")]
public class DashboardServiceTests
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public async Task GetTotalConsumptionAsync_ReturnsTotalConsumption()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var locationService = new LocationService(context);
            var distributionPanelService = new DistributionPanelService(context);
            var dashboardService = new DashboardService(locationService, distributionPanelService);

            var location = new Location
            {
                DistributionPanels = new List<DistributionPanel>
                {
                    new DistributionPanel
                    {
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
            var totalConsumption = await dashboardService.GetTotalConsumptionAsync();

            // Assert
            Assert.AreEqual(500, totalConsumption);
        }
    }

    [TestMethod]
    public async Task GetConsumptionPerEmployeeAsync_ReturnsConsumptionPerEmployee()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var locationService = new LocationService(context);
            var distributionPanelService = new DistributionPanelService(context);
            var dashboardService = new DashboardService(locationService, distributionPanelService);

            var location = new Location
            {
                DistributionPanels = new List<DistributionPanel>
                {
                    new DistributionPanel
                    {
                        Consumers = new List<Consumer>
                        {
                            new Consumer { PowerConsumption = 200 },
                            new Consumer { PowerConsumption = 300 }
                        }
                    }
                },
                Employees = new List<Employee>
                {
                    new Employee(),
                    new Employee()
                }
            };
            context.Locations.Add(location);
            await context.SaveChangesAsync();

            // Act
            var consumptionPerEmployee = await dashboardService.GetConsumptionPerEmployeeAsync(location.Id);

            // Assert
            Assert.AreEqual(250, consumptionPerEmployee);
        }
    }

    [TestMethod]
    public async Task GetWorkloadsAsync_ReturnsWorkloads()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var locationService = new LocationService(context);
            var distributionPanelService = new DistributionPanelService(context);
            var dashboardService = new DashboardService(locationService, distributionPanelService);

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
            var workloads = await dashboardService.GetWorkloadsAsync(location.Id);

            // Assert
            Assert.IsNotNull(workloads);
            Assert.IsTrue(workloads.Any());
            Assert.AreEqual(500, workloads.First().CurrentWorkloadInKW);
            Assert.AreEqual(1000, workloads.First().MaxWorkloadInKW);
        }
    }
}
