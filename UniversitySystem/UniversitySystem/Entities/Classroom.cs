namespace UniversitySystem.Entities;

public class Classroom
{
    public int Id { get; init; }

    public string Building { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; init; } = new List<CourseOffering>();
}