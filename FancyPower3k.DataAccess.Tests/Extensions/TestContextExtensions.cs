using FancyPower3k.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.DataAccess.Tests.Extensions;

public static class TestContextExtensions
{
    private const string ConnectionString = "Data Source=(localdb)\\SWArch250513;Initial Catalog=UnitTests_{0};Trusted_Connection=True;MultipleActiveResultSets=true";


    public static FancyPowerDbContext CreateDbContext(this TestContext testContext)
    {
        string last4PositionsOfGuid = Guid.NewGuid().ToString()[^4..];

        // Configure the context to use SQL LocalDB
        var options = new DbContextOptionsBuilder<FancyPowerDbContext>()
            .UseSqlServer(string.Format(ConnectionString, last4PositionsOfGuid))
            .Options;

        // Create the database and apply migrations
        var context = new FancyPowerDbContext(options);

        // Migrate fuehrt EnsureCreated und Migrate aus
        //_context.Database.EnsureCreated();

        context.Database.Migrate();

        return context;
    }
}
