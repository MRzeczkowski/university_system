namespace UniversitySystem.Entities;

public class Department
{
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public decimal Budget { get; set; }

    public virtual ICollection<Course> Courses { get; init; } = new List<Course>();

    public virtual ICollection<Dean> Deans { get; init; } = new List<Dean>();

    public virtual ICollection<ProfessorProfile> Professors { get; init; } = new List<ProfessorProfile>();
}