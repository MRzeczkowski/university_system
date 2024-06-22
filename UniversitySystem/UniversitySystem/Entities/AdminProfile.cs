namespace UniversitySystem.Entities;

public class AdminProfile
{
    public int Id { get; init; }

    public long UserId { get; init; }

    public virtual ApplicationUser User { get; init; } = null!;

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }
}