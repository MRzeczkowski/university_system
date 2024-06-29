namespace UniversitySystem.Entities;

public class CourseOffering
{
    public int Id { get; init; }

    public int CourseId { get; set; }

    public virtual Course Course { get; init; } = null!;

    public int SemesterId { get; set; }

    public virtual Semester Semester { get; init; } = null!;

    public int Year { get; set; }

    public int ProfessorId { get; set; }

    public virtual ProfessorProfile Professor { get; init; } = null!;

    public virtual ICollection<ClassSession> ClassSessions { get; init; } = new List<ClassSession>();

    public virtual ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
}