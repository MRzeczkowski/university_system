namespace UniversitySystem.Entities;

public partial class Attendance
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public DateOnly DateOfClass { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual AttendanceStatus Status { get; set; } = null!;
}
