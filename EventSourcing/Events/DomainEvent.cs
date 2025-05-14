namespace EventSourcing.Events;

public abstract class DomainEvent
{
    // Events treten immer zu einem Zeitpunkt auf
    public DateTime CreatedAtUtc { get; set; }

    // Abfolge von Events als Stream eindeutig identifizieren
    public abstract Guid StreamId { get; }
}

public class StudentRegisteredEvent : DomainEvent
{
    public Guid StudentId { get; set; }

    public required string FullName { get; set; }

    public required string Email { get; set; }

    public required DateTime DateOfBirth { get; set; }

    public override Guid StreamId => StudentId;
}

public class StudentEmailUpdatedEvent : DomainEvent
{
    public Guid StudentId { get; set; }

    public required string Email { get; set; }

    public override Guid StreamId => StudentId;
}

public class StudentEnrolledEvent : DomainEvent
{
    public Guid StudentId { get; set; }

    public required string CourseName { get; set; }

    public override Guid StreamId => StudentId;
}

public class StudentDisrolledEvent : DomainEvent
{
    public Guid StudentId { get; set; }

    public required string CourseName { get; set; }

    public override Guid StreamId => StudentId;
}

