using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class EnrollmentViewModel
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string StudentName { get; set; }

    public int OfferingId { get; set; }

    public string CourseName { get; set; }

    public string Semester { get; set; }

    public int Year { get; set; }

    public int? Points { get; set; }
    
    public decimal? Grade { get; set; }

    public IEnumerable<SelectListItem>? CourseOfferingOptions { get; set; } = new List<SelectListItem>();
}