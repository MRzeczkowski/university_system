namespace UniversitySystem.Entities;

public class ClassSession
{
    public int Id { get; init; }

    public int OfferingId { get; init; }

    public DateTime SessionStart { get; init; }

    public DateTime SessionEnd { get; init; }

    public virtual CourseOffering Offering { get; init; } = null!;
}
