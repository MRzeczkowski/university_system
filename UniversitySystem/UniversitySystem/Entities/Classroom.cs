namespace UniversitySystem.Entities;

public class Classroom
{
    public int Id { get; init; }

    public string Building { get; init; } = null!;

    public string RoomNumber { get; init; } = null!;

    public int Capacity { get; init; }

    public DateTime CreatedDate { get; init; }

    public DateTime? ModifiedDate { get; init; }

    public bool IsDeleted { get; init; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();
}
