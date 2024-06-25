namespace UniversitySystem.Entities;

public class AdminStatus
{
    public int Id { get; init; }

    public string StatusDescription { get; init; } = null!;

    public virtual ICollection<AdminProfile> Admins { get; init; } = new List<AdminProfile>();
}