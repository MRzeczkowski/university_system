namespace UniversitySystem.Entities;

public class Enrollment
{
    public int Id { get; init; }

    public int StudentId { get; set; }

    public virtual StudentProfile Student { get; init; } = null!;

    public int OfferingId { get; set; }

    public virtual CourseOffering Offering { get; init; } = null!;

    public DateOnly EnrollmentDate { get; set; }

    public virtual ICollection<Grade> Grades { get; init; } = new List<Grade>();
}