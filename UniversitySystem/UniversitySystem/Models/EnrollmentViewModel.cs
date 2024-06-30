using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class EnrollmentViewModel
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public int OfferingId { get; set; }

    public string? CourseName { get; set; }

    public string? Semester { get; set; }

    public int Year { get; set; }

    [Range(0, 100, ErrorMessage = "Points must be between 0 and 100.")]
    public int? Points { get; set; }

    public string? Grade { get; set; }

    public IEnumerable<SelectListItem> GradeOptions { get; set; } = new List<SelectListItem>
    {
        new() { Text = "2.0", Value = "2.0" },
        new() { Text = "3.0", Value = "3.0" },
        new() { Text = "3.5", Value = "3.5" },
        new() { Text = "4.0", Value = "4.0" },
        new() { Text = "4.5", Value = "4.5" },
        new() { Text = "5.0", Value = "5.0" }
    };

    public IEnumerable<SelectListItem>? CourseOfferingOptions { get; set; } = new List<SelectListItem>();
}