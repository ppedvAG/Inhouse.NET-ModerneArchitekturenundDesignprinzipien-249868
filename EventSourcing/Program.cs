using EventSourcing.Data;
using EventSourcing.Events;

internal class Program
{
    const string StudentId = "D3F162BF-A0CB-4CEE-AA2E-689EEB789B89";

    static readonly InMemoryEventStore<StudentEntity, StudentEntityMaterializer> _store = new();

    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    
        var studentId = Guid.Parse(StudentId);

        // 1. Events persistieren
        PersistSomeStudentEvents(studentId);

        // 2. Student materialisieren
        var student = _store.GetEntity(studentId);
        Console.WriteLine($"Student: {student.FullName} wurde vollstaendig materialisiert.");
        Console.WriteLine("Folgende Kurse: " + string.Join(", ", student.EnrolledCourses));

        // 3. Student aus projezierter View
        student = _store.GetEntityProjection(studentId);
        Console.WriteLine($"Student: {student.FullName} aus projezierter View.");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static void PersistSomeStudentEvents(Guid studentId)
    {
        var registredEvent = new StudentRegisteredEvent
        {
            StudentId = studentId,
            FullName = "Max Mustermann",
            Email = "max@example.com",
            DateOfBirth = new DateTime(2000, 1, 1)
        };
        _store.Append(registredEvent);
        Console.WriteLine($"Student registred: {registredEvent.FullName}");

        var enrolledEvent = new StudentEnrolledEvent
        {
            StudentId = studentId,
            CourseName = "Moderne Architekturen in C# und .NET"
        };
        _store.Append(enrolledEvent);
        Console.WriteLine($"Student enrolled: {enrolledEvent.CourseName}");

        var emailUpdatedEvent = new StudentEmailUpdatedEvent
        {
            StudentId = studentId,
            Email = "m.mustermann@example.com"
        };
        _store.Append(emailUpdatedEvent);
        Console.WriteLine($"Student email updated: {emailUpdatedEvent.Email}");
    }
}