namespace FancyPower3k.DomainModel.Entities;

public class Location : Entity
{
    public string Address { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public ICollection<DistributionPanel> DistributionPanels { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
