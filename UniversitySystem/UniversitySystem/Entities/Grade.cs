namespace UniversitySystem.Entities;

public class Grade
{
    public int Id { get; init; }

    public int EnrollmentId { get; set; }

    public virtual Enrollment Enrollment { get; init; } = null!;

    public int Points { get; set; }

    public decimal FinalGrade { get; set; }

    public DateOnly GradeDate { get; set; }
}