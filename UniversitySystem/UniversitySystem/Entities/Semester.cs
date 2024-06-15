namespace UniversitySystem.Entities;

public class Semester
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
