namespace UniversitySystem.Entities;

public class Course
{
    public int Id { get; init; }

    public string CourseName { get; set; } = null!;

    public int DepartmentId { get; set; }
    
    public virtual Department Department { get; init; } = null!;

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();
}