namespace UniversitySystem.Entities;

public class ProfessorProfile
{
    public int Id { get; set; }

    public long UserId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public int TitleId { get; set; }

    public virtual Title Title { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual ProfessorStatus Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual ICollection<Dean> Deans { get; set; } = new List<Dean>();
}