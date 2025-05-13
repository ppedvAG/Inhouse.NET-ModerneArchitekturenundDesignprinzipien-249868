using FancyPower3k.DomainModel.Enums;

namespace FancyPower3k.DomainModel.Entities;

public class Employee : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string JobTitle { get; set; }
    public JobPosition Position { get; set; }
    public double Salary { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }


}
