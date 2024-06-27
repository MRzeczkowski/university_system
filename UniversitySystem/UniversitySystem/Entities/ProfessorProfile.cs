namespace UniversitySystem.Entities;

public class ProfessorProfile
{
    public int Id { get; init; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; init; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; init; } = null!;

    public int TitleId { get; set; }

    public virtual Title Title { get; init; } = null!;

    public int StatusId { get; set; }

    public virtual ProfessorStatus Status { get; init; } = null!;

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();

    public virtual ICollection<Dean> Deans { get; init; } = new List<Dean>();
}