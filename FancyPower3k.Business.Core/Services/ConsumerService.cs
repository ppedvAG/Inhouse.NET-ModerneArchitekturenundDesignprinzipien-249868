using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Business.Core.Services;

public class ConsumerService
{
    private readonly FancyPowerDbContext _context;

    public ConsumerService(FancyPowerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Consumer>> GetAllConsumersAsync()
    {
        return await _context.Consumers.Include(c => c.DistributionPanel).ToListAsync();
    }
}
