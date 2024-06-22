namespace UniversitySystem.Entities;

public class Department
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    public decimal Budget { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<Course> Courses { get; init; } = new List<Course>();

    public virtual ICollection<Dean> Deans { get; init; } = new List<Dean>();

    public virtual ICollection<ProfessorProfile> Professors { get; init; } = new List<ProfessorProfile>();
}