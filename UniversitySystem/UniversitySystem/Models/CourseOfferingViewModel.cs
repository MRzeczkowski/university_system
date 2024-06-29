using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class CourseOfferingViewModel
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public IEnumerable<SelectListItem>? CourseOptions { get; set; } = new List<SelectListItem>();

    public int SemesterId { get; set; }

    public string? SemesterName { get; set; }

    public IEnumerable<SelectListItem>? SemesterOptions { get; set; } = new List<SelectListItem>();

    public int Year { get; set; }

    public int ProfessorId { get; set; }

    public string? ProfessorName { get; set; }

    public IEnumerable<SelectListItem>? ProfessorOptions { get; set; } = new List<SelectListItem>();
}