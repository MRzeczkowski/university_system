namespace UniversitySystem.Entities;

public partial class ClassSession
{
    public int Id { get; set; }

    public int OfferingId { get; set; }

    public DateTime SessionStart { get; set; }

    public DateTime SessionEnd { get; set; }

    public virtual CourseOffering Offering { get; set; } = null!;
}
