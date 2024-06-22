namespace UniversitySystem.Entities;

public class AttendanceStatus
{
    public int Id { get; init; }

    public string StatusName { get; init; } = null!;

    public virtual ICollection<Attendance> Attendances { get; init; } = new List<Attendance>();
}
