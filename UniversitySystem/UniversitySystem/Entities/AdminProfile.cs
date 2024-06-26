namespace UniversitySystem.Entities;

public class AdminProfile
{
    public int Id { get; init; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; init; } = null!;

    public int StatusId { get; set; }

    public virtual AdminStatus Status { get; init; } = null!;
}