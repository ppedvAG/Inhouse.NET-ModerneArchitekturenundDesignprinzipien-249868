namespace FancyPower3k.DomainModel.Entities;

public class Consumer : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double PowerConsumption { get; set; }
    public double MaxConsumption { get; set; }
    public string DistributionPanelId { get; set; }
    public DistributionPanel DistributionPanel { get; set; }
}
