using FancyPower3k.DataAccess.Data;
using FancyPower3k.DataAccess.Tests.Extensions;
using FancyPower3k.DomainModel.Enums;

namespace FancyPower3k.DataAccess.Tests;

[TestClass]
public class FancyPowerDbContextTests
{
    private FancyPowerDbContext _context;

    /// <summary>
    /// Magic von MSTest welches hier den TestContext hinein injiziert.
    /// Typ und Name muessen exakt so lauten.
    /// </summary>
    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        // This method is called before the first test method in the class
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // This method is called after the last test method in the class
    }

    [TestInitialize]
    public void Setup()
    {
        _context = TestContext.CreateDbContext();
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Clean up the database after each test
        _ = _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [TestMethod]
    public void Test_SeedData_Returns2Locations()
    {
        // Arrange
        var expectedLocationCount = 2;

        // Act
        var locations = _context.Locations.ToList();

        // Assert
        Assert.AreEqual(expectedLocationCount, locations.Count);
    }

    [TestMethod]
    public void Test_SeedData_Returns2DistributionPanels()
    {
        // Arrange
        var expectedPanelCount = 2;

        // Act
        var panels = _context.DistributionPanels.ToList();

        // Assert
        Assert.AreEqual(expectedPanelCount, panels.Count);
    }

    [TestMethod]
    public void Test_SeedData_Returns3Consumers()
    {
        // Arrange
        var expectedConsumerCount = 3;

        // Act
        var consumers = _context.Consumers.ToList();

        // Assert
        Assert.AreEqual(expectedConsumerCount, consumers.Count);
    }

    [TestMethod]
    public void Test_SeedData_Returns50Employees()
    {
        // Arrange
        var expectedEmployeeCount = 50;

        // Act
        var employees = _context.Employees.ToList();

        // Assert
        Assert.AreEqual(expectedEmployeeCount, employees.Count);
    }

    [TestMethod]
    public void Test_SeedData_EmployeePositions()
    {
        // Arrange
        var expectedPositions = Enum.GetNames(typeof(JobPosition)).Length;

        // Act
        var uniquePositions = _context.Employees.Select(e => e.Position).Distinct().Count();

        // Assert
        Assert.AreEqual(expectedPositions, uniquePositions);
    }
}
