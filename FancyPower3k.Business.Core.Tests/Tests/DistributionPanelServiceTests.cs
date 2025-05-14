using FancyPower3k.Business.Core.Services;
using FancyPower3k.DataAccess.Tests.Extensions;
using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Tests.Tests;

[TestClass]
public class DistributionPanelServiceTests
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public async Task GetAllDistributionPanelsAsync_ReturnsDistributionPanels()
    {
        using (var context = TestContext.CreateDbContext())
        {
            // Arrange
            var service = new DistributionPanelService(context);

            // Act
            var distributionPanels = await service.GetAllDistributionPanelsAsync();

            // Assert
            Assert.IsNotNull(distributionPanels);
            Assert.IsTrue(distributionPanels.Any());
        }
    }

    [TestMethod]
    public async Task CalculateLoadAsync_ReturnsCorrectLoad()
    {
        using (var dbContext = TestContext.CreateDbContext())
        {
            // Arrange
            var accuracy = 1e-3;
            var service = new DistributionPanelService(dbContext);
            var expectedValue = (Seed.Consumer1PowerConsumption + Seed.Consumer2PowerConsumption) 
                / (double)Seed.DistributionPanel2MaxPowerDelivery * 100d;

            // Act
            double load = await service.CalculateLoadAsync(Seed.DistributionPanel2Id);

            // Assert
            Assert.AreEqual(expectedValue, load, accuracy);
        }
    }
}
