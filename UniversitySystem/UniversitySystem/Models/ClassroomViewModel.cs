namespace UniversitySystem.Models;

public class ClassroomViewModel
{
    public int Id { get; set; }

    public string Building { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }
}