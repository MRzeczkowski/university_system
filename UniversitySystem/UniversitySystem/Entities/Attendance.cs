namespace UniversitySystem.Entities;

public class Attendance
{
    public int Id { get; init; }

    public int EnrollmentId { get; set; }

    public DateOnly DateOfClass { get; set; }

    public int StatusId { get; set; }

    public virtual Enrollment Enrollment { get; init; } = null!;

    public virtual AttendanceStatus Status { get; init; } = null!;
}