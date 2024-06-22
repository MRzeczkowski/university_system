namespace UniversitySystem.Entities;

public class ProfessorStatus
{
    public int Id { get; init; }

    public string StatusDescription { get; init; } = null!;

    public virtual ICollection<ProfessorProfile> Professors { get; init; } = new List<ProfessorProfile>();
}
