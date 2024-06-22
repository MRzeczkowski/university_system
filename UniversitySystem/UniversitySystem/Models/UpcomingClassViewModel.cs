namespace UniversitySystem.Models;

public class UpcomingClassViewModel
{
    public string CourseName { get; init; } = null!;

    public DateTime SessionStart { get; init; }

    public DateTime SessionEnd { get; init; }

    public string ProfessorName { get; init; } = null!;

    public string Room { get; init; } = null!;
}