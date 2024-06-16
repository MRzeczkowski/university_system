namespace UniversitySystem.Models;

public class StudentGradesViewModel
{
    public string StudentName { get; set; }
    
    public string Deparment { get; set; }
    
    public string CourseName { get; set; }
    
    public string Semester  { get; set; }
    
    public decimal GradeValue { get; set; }
    
    public DateOnly GradeDate { get; set; }
}
