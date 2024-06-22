namespace UniversitySystem.Entities;

public class CourseOffering
{
    public int Id { get; init; }

    public int CourseId { get; init; }

    public virtual Course Course { get; init; } = null!;

    public int SemesterId { get; init; }

    public virtual Semester Semester { get; init; } = null!;

    public int Year { get; init; }

    public int ProfessorId { get; init; }

    public virtual ProfessorProfile Professor { get; init; } = null!;

    public int ClassroomId { get; init; }

    public virtual Classroom Classroom { get; init; } = null!;

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<ClassSession> ClassSessions { get; init; } = new List<ClassSession>();

    public virtual ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
}