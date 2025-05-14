using FancyPower3k.Business.Core.Models;
using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Contracts
{
    public interface ILocationService
    {
        Task<double> CalculateLoadAsync(string locationId);
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<List<WorkloadDto>> GetWorkloadsAsync(string locationId);
    }
}