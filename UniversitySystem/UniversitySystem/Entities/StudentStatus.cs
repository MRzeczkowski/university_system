namespace UniversitySystem.Entities;

public class StudentStatus
{
    public int Id { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
