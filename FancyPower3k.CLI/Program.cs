using FancyPower3k.Business.Core.Services;
using FancyPower3k.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        const string ConnectionString = "Server=(localdb)\\SWArch250513;Database=FancyPower3k;Trusted_Connection=True;Encrypt=False;";

        var options = new DbContextOptionsBuilder<FancyPowerDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        using (var context = new FancyPowerDbContext(options))
        {
            var locationService = new LocationService(context);
            var distributionPanelService = new DistributionPanelService(context);
            var dashboardService = new DashboardService(locationService, distributionPanelService);

            var totalConsumption = await dashboardService.GetTotalConsumptionAsync();
            var consumptionPerEmployee = await dashboardService.GetConsumptionPerEmployeeAsync(Seed.Location1Id);
            var workloads = await dashboardService.GetWorkloadsAsync(Seed.Location1Id);

            Console.WriteLine($"Gesamtverbrauch: {totalConsumption}");
            Console.WriteLine($"Verbrauch pro Mitarbeiter: {consumptionPerEmployee}");

            foreach (var workload in workloads)
            {
                Console.WriteLine($"Workload ID: {workload.Id}, Name: {workload.Name}, Current Workload: {workload.CurrentWorkloadInKW} kW, Max Workload: {workload.MaxWorkloadInKW} kW");
            }
        }
    }
}