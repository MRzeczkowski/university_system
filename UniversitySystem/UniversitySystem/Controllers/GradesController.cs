using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Context;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

public class GradesController : Controller
{
    private readonly UniversityContext _context;

    public GradesController(UniversityContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var grades = _context.Grades
            .Select(g => new StudentGradesViewModel
            {
                StudentName = $"{g.Enrollment.Student.Person.FirstName} {g.Enrollment.Student.Person.LastName}",
                CourseName = g.Enrollment.Offering.Course.CourseName,
                Semester = $"{g.Enrollment.Offering.Year}/{g.Enrollment.Offering.Semester.Name}",
                GradeValue = g.FinalGrade,
                GradeDate = g.GradeDate
            })
            .ToList();

        return View(grades);
    }
}
