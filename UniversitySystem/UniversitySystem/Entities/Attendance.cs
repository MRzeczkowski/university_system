namespace UniversitySystem.Entities;

public class Attendance
{
    public int Id { get; init; }

    public int EnrollmentId { get; init; }

    public DateOnly DateOfClass { get; init; }

    public int StatusId { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual Enrollment Enrollment { get; init; } = null!;

    public virtual AttendanceStatus Status { get; init; } = null!;
}
