namespace UniversitySystem.Entities;

public class StudentStatus
{
    public int Id { get; init; }

    public string StatusDescription { get; init; } = null!;

    public virtual ICollection<StudentProfile> Students { get; init; } = new List<StudentProfile>();
}
