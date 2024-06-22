namespace UniversitySystem.Entities;

public class StudentProfile
{
    public int Id { get; init; }

    public long UserId { get; init; }

    public virtual ApplicationUser User { get; init; } = null!;

    public int EnrollmentYear { get; init; }

    public int StatusId { get; init; }

    public virtual StudentStatus Status { get; init; } = null!;

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<Advisor> Advisors { get; init; } = new List<Advisor>();

    public virtual ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
}