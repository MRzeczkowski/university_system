namespace UniversitySystem.Entities;

public class Title
{
    public int Id { get; init; }

    public string TitleName { get; init; } = null!;

    public virtual ICollection<ProfessorProfile> Professors { get; init; } = new List<ProfessorProfile>();
}
