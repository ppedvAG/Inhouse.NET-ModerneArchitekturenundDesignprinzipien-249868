using FancyPower3k.Business.Core.Contracts;
using FancyPower3k.Business.Core.Models;

namespace FancyPower3k.Business.Core.Services;

public class DashboardService : IDashboardService
{
    private readonly ILocationService _locationService;
    private readonly IDistributionPanelService _distributionPanelService;

    public DashboardService(
        ILocationService locationService,
        IDistributionPanelService distributionPanelService)
    {
        _locationService = locationService;
        _distributionPanelService = distributionPanelService;
    }

    public async Task<double> GetTotalConsumptionAsync()
    {
        var locations = await _locationService.GetAllLocationsAsync();
        return locations.Sum(location =>
            location.DistributionPanels.Sum(dp =>
                dp.Consumers.Sum(c => c.PowerConsumption)));
    }

    public async Task<double> GetConsumptionPerEmployeeAsync(string locationId)
    {
        var location = await _locationService.GetAllLocationsAsync();
        var selectedLocation = location.FirstOrDefault(l => l.Id == locationId);

        if (selectedLocation?.Employees == null || selectedLocation.Employees.Count == 0)
        {
            return 0;
        }

        double totalConsumption = selectedLocation.DistributionPanels.Sum(dp => dp.Consumers.Sum(c => c.PowerConsumption));
        return totalConsumption / selectedLocation.Employees.Count;
    }

    public async Task<List<WorkloadDto>> GetWorkloadsAsync(string locationId)
    {
        return await _locationService.GetWorkloadsAsync(locationId);
    }
}