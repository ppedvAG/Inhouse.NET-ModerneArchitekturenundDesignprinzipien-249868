using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Contracts
{
    public interface IDistributionPanelService
    {
        Task<double> CalculateLoadAsync(string distributionPanelId);
        Task<IEnumerable<DistributionPanel>> GetAllDistributionPanelsAsync();
    }
}