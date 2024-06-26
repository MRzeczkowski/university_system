namespace UniversitySystem.Entities;

public class Advisor
{
    public int StudentId { get; set; }

    public int ProfessorId { get; set; }

    public DateOnly AssignmentDate { get; set; }

    public virtual ProfessorProfile Professor { get; init; } = null!;

    public virtual StudentProfile Student { get; init; } = null!;
}