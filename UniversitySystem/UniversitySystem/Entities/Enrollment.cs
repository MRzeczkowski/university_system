namespace UniversitySystem.Entities;

public class Enrollment
{
    public int Id { get; init; }
    
    public int? Points { get; set; }

    public decimal? Grade { get; set; }

    public int StudentId { get; set; }

    public virtual StudentProfile Student { get; init; } = null!;

    public int OfferingId { get; set; }

    public virtual CourseOffering Offering { get; init; } = null!;

    public virtual ICollection<Attendance> Attendances { get; init; } = new List<Attendance>();
}