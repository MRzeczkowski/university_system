namespace UniversitySystem.Entities;

public class Title
{
    public int Id { get; set; }

    public string TitleName { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
