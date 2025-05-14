using FancyPower3k.Business.Core.Models;

namespace FancyPower3k.Business.Core.Contracts
{
    public interface IDashboardService
    {
        Task<double> GetConsumptionPerEmployeeAsync(string locationId);
        Task<double> GetTotalConsumptionAsync();
        Task<List<WorkloadDto>> GetWorkloadsAsync(string locationId);
    }
}