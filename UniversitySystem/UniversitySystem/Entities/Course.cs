namespace UniversitySystem.Entities;

public class Course
{
    public int Id { get; init; }

    public string CourseName { get; init; } = null!;

    public int DepartmentId { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();

    public virtual Department Department { get; init; } = null!;
}
