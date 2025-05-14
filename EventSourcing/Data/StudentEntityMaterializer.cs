using EventSourcing.Events;

namespace EventSourcing.Data;

internal class StudentEntityMaterializer : IMaterializer<StudentEntity>
{
    private readonly StudentEntity _entity = new();

    public StudentEntity Entity => _entity;

    public IMaterializer<StudentEntity> Apply(DomainEvent ev) => ev switch
    {
        StudentRegisteredEvent studentRegisteredEvent => Apply(studentRegisteredEvent),
        StudentEmailUpdatedEvent studentEmailUpdatedEvent => Apply(studentEmailUpdatedEvent),
        StudentEnrolledEvent studentEnrolledEvent => Apply(studentEnrolledEvent),
        StudentDisrolledEvent studentDisrolledEvent => Apply(studentDisrolledEvent),
        _ => this,
    };

    private StudentEntityMaterializer Apply(StudentRegisteredEvent ev)
    {
        _entity.StudentId = ev.StudentId;
        _entity.FullName = ev.FullName;
        _entity.DateOfBirth = ev.DateOfBirth;
        _entity.Email = ev.Email;

        return this;
    }

    private StudentEntityMaterializer Apply(StudentEmailUpdatedEvent ev)
    {
        if (_entity.StudentId != ev.StudentId)
        {
            throw new InvalidOperationException("IDs do not match.");
        }

        _entity.Email = ev.Email;

        return this;
    }

    private StudentEntityMaterializer Apply(StudentEnrolledEvent ev)
    {
        if (_entity.StudentId != ev.StudentId)
        {
            throw new InvalidOperationException("IDs do not match.");
        }

        _entity.EnrolledCourses.Add(ev.CourseName);

        return this;
    }

    private StudentEntityMaterializer Apply(StudentDisrolledEvent ev)
    {
        if (_entity.StudentId != ev.StudentId)
        {
            throw new InvalidOperationException("IDs do not match.");
        }

        _entity.EnrolledCourses.Remove(ev.CourseName);

        return this;
    }

    public static implicit operator StudentEntity(StudentEntityMaterializer creator)
        => creator._entity;
}
