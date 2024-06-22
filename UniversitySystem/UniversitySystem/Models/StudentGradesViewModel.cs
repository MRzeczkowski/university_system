namespace UniversitySystem.Models;

public class StudentGradesViewModel
{
    public string Semester { get; init; } = null!;

    public string CourseName { get; init; } = null!;

    public decimal GradeValue { get; init; }

    public DateOnly GradeDate { get; init; }
}