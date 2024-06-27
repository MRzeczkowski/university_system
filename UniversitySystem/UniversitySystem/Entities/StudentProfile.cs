namespace UniversitySystem.Entities;

public class StudentProfile
{
    public int Id { get; init; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; init; } = null!;

    public int EnrollmentYear { get; set; }

    public int StatusId { get; set; }

    public virtual StudentStatus Status { get; init; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
}