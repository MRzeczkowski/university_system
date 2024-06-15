namespace UniversitySystem.Entities;

public class Classroom
{
    public int Id { get; set; }

    public string Building { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
