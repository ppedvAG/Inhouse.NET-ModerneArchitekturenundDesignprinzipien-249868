namespace EventSourcing.Data;

public class StudentEntity
{
    public Guid StudentId { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<string> EnrolledCourses { get; set; } = [];
}

