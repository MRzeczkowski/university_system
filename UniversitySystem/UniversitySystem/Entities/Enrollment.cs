namespace UniversitySystem.Entities;

public class Enrollment
{
    public int Id { get; init; }

    public int StudentId { get; init; }

    public virtual StudentProfile Student { get; init; } = null!;

    public int OfferingId { get; init; }

    public virtual CourseOffering Offering { get; init; } = null!;

    public DateOnly EnrollmentDate { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<Attendance> Attendances { get; init; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; init; } = new List<Grade>();
}