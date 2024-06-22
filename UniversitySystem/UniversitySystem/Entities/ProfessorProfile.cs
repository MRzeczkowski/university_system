namespace UniversitySystem.Entities;

public class ProfessorProfile
{
    public int Id { get; init; }

    public long UserId { get; init; }

    public virtual ApplicationUser User { get; init; } = null!;

    public int DepartmentId { get; init; }

    public virtual Department Department { get; init; } = null!;

    public int TitleId { get; init; }

    public virtual Title Title { get; init; } = null!;

    public int StatusId { get; init; }

    public virtual ProfessorStatus Status { get; init; } = null!;

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<Advisor> Advisors { get; init; } = new List<Advisor>();

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();

    public virtual ICollection<Dean> Deans { get; init; } = new List<Dean>();
}