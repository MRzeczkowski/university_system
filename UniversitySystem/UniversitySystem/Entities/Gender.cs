namespace UniversitySystem.Entities;

public class Gender
{
    public int Id { get; init; }

    public string Description { get; init; } = null!;

    public virtual ICollection<ApplicationUser> Users { get; init; } = new List<ApplicationUser>();
}
