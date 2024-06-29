namespace UniversitySystem.Entities;

public class ClassSession
{
    public int Id { get; init; }

    public DateTime SessionStart { get; set; }

    public DateTime SessionEnd { get; set; }

    public int OfferingId { get; set; }

    public virtual CourseOffering Offering { get; init; } = null!;
    
    public int ClassroomId { get; set; }

    public virtual Classroom Classroom { get; init; } = null!;

    public virtual ICollection<Attendance> Attendances { get; init; } = null!;
}