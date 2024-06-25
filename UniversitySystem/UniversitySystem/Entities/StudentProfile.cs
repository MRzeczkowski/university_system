namespace UniversitySystem.Entities;

public class StudentProfile
{
    public int Id { get; set; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;

    public int EnrollmentYear { get; set; }

    public int StatusId { get; set; }

    public virtual StudentStatus Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}