namespace FancyPower3k.DomainModel.Entities;

public class DistributionPanel : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }
    public double MaxPowerDelivery { get; set; }
    public ICollection<Consumer> Consumers { get; set; }
}
