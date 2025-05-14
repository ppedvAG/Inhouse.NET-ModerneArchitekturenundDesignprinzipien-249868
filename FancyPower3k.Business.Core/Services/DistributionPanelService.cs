using FancyPower3k.Business.Core.Contracts;
using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Business.Core.Services;

public class DistributionPanelService : IDistributionPanelService
{
    private readonly FancyPowerDbContext _context;

    public DistributionPanelService(FancyPowerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DistributionPanel>> GetAllDistributionPanelsAsync()
    {
        return await _context.DistributionPanels.Include(dp => dp.Consumers).ToListAsync();
    }

    public async Task<double> CalculateLoadAsync(string distributionPanelId)
    {
        var distributionPanel = await _context.DistributionPanels
            .Include(dp => dp.Consumers)
            .FirstOrDefaultAsync(dp => dp.Id == distributionPanelId);

        if (distributionPanel?.Consumers == null || !distributionPanel.Consumers.Any())
        {
            return 0;
        }

        double totalConsumption = distributionPanel.Consumers.Sum(c => c.PowerConsumption);
        return totalConsumption / distributionPanel.MaxPowerDelivery * 100;
    }
}
