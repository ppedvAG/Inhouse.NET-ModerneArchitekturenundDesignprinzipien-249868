namespace FancyPower3k.DomainModel.Entities;

public abstract class Entity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ChangedDate { get; set; }
}
