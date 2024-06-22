namespace UniversitySystem.Entities;

public class Grade
{
    public int Id { get; init; }

    public int EnrollmentId { get; init; }

    public virtual Enrollment Enrollment { get; init; } = null!;

    public int Points { get; init; }

    public decimal FinalGrade { get; init; }

    public DateOnly GradeDate { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }
}