namespace UniversitySystem.Models;

public class StudentGradesViewModel
{
    public string Semester { get; set; }

    public string CourseName { get; set; }

    public decimal GradeValue { get; set; }

    public DateOnly GradeDate { get; set; }
}