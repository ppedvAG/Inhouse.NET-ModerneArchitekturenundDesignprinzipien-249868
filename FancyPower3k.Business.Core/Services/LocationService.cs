using FancyPower3k.Business.Core.Contracts;
using FancyPower3k.Business.Core.Models;
using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Business.Core.Services;

public class LocationService : ILocationService
{
    private readonly FancyPowerDbContext _context;

    public LocationService(FancyPowerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync()
    {
        return await _context.Locations
            .Include(l => l.DistributionPanels)
            .ThenInclude(dp => dp.Consumers)
            .Include(l => l.Employees)
            .ToListAsync();
    }

    public async Task<double> CalculateLoadAsync(string locationId)
    {
        var location = await _context.Locations
            .Include(l => l.DistributionPanels)
            .ThenInclude(dp => dp.Consumers)
            .FirstOrDefaultAsync(l => l.Id == locationId);

        if (location?.DistributionPanels == null || !location.DistributionPanels.Any())
        {
            return 0;
        }

        double totalConsumption = location.DistributionPanels.Sum(dp => dp.Consumers.Sum(c => c.PowerConsumption));
        double totalMaxPowerDelivery = location.DistributionPanels.Sum(dp => dp.MaxPowerDelivery);

        return totalConsumption / totalMaxPowerDelivery * 100;
    }

    public async Task<List<WorkloadDto>> GetWorkloadsAsync(string locationId)
    {
        var location = await _context.Locations
            .Include(l => l.DistributionPanels)
            .ThenInclude(dp => dp.Consumers)
            .FirstOrDefaultAsync(l => l.Id == locationId);

        if (location?.DistributionPanels == null || !location.DistributionPanels.Any())
        {
            return new List<WorkloadDto>();
        }

        return location.DistributionPanels.Select(dp => new WorkloadDto
        {
            Id = dp.Id.ToString(),
            Name = dp.Name,
            CurrentWorkloadInKW = dp.Consumers.Sum(c => c.PowerConsumption),
            MaxWorkloadInKW = dp.MaxPowerDelivery
        }).ToList();
    }
}