namespace UniversitySystem.Entities;

public class Semester
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();
}
