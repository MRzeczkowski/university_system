namespace UniversitySystem.Entities;

public class AdminProfile
{
    public int Id { get; set; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
    
    public int StatusId { get; set; }

    public virtual AdminStatus Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }
}