namespace UniversitySystem.Entities;

public class Attendance
{
    public int Id { get; init; }

    public int StatusId { get; set; }

    public virtual AttendanceStatus Status { get; init; } = null!;

    public int ClassSessionId { get; set; }

    public virtual ClassSession ClassSession { get; init; } = null!;

    public int EnrollmentId { get; set; }

    public virtual Enrollment Enrollment { get; init; } = null!;
}