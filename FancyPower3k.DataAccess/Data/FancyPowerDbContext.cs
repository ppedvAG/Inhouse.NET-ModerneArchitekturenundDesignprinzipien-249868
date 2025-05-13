using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.DataAccess.Data;

public class FancyPowerDbContext : DbContext
{
    public DbSet<Consumer> Consumers { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<DistributionPanel> DistributionPanels { get; set; }

    public FancyPowerDbContext(DbContextOptions<FancyPowerDbContext> options)
        : base(options)
    {            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships

        // Location to DistributionPanel: One-to-Many
        modelBuilder.Entity<Location>()
            .HasMany(l => l.DistributionPanels)
            .WithOne(dp => dp.Location)
            .HasForeignKey(dp => dp.LocationId);

        // DistributionPanel to Consumer: One-to-Many
        modelBuilder.Entity<DistributionPanel>()
            .HasMany(dp => dp.Consumers)
            .WithOne(c => c.DistributionPanel)
            .HasForeignKey(c => c.DistributionPanelId);

        // Location to Employee: One-to-Many
        modelBuilder.Entity<Location>()
            .HasMany(l => l.Employees)
            .WithOne(e => e.Location)
            .HasForeignKey(e => e.LocationId);


        Seed.SeedData(modelBuilder);
    }
}
