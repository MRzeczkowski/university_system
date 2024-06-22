namespace UniversitySystem.Entities;

public class Advisor
{
    public int StudentId { get; init; }

    public int ProfessorId { get; init; }

    public DateOnly AssignmentDate { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ProfessorProfile Professor { get; init; } = null!;

    public virtual StudentProfile Student { get; init; } = null!;
}
