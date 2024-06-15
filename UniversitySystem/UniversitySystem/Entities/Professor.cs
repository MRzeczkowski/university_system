namespace UniversitySystem.Entities;

public class Professor
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public int TitleId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual ICollection<Dean> Deans { get; set; } = new List<Dean>();

    public virtual Department Department { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ProfessorStatus Status { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
