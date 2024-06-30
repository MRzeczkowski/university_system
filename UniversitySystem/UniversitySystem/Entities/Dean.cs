namespace UniversitySystem.Entities;

public class Dean
{
    public int DepartmentId { get; init; }
    
    public virtual Department Department { get; init; } = null!;

    public int ProfessorId { get; init; }
    
    public virtual ProfessorProfile Professor { get; init; } = null!;

    public DateTime EffectiveDate { get; init; }
}
