using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class CourseViewModel
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public int DepartmentId { get; set; }
    
    public string? DepartmentName { get; set; }

    public IEnumerable<SelectListItem>? DepartmentOptions { get; set; } = new List<SelectListItem>();
}
