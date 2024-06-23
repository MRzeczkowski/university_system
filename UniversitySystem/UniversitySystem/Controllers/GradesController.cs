using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

public class GradesController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GradesController(
        UniversityContext context,
        UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return Challenge();

        var userId = user.Id;

        var grades = _context.Grades
            .Where(g => g.Enrollment.Student.UserId == userId)
            .Select(g => new StudentGradesViewModel
            {
                Semester =
                    $"{g.Enrollment.Offering.Year}/{g.Enrollment.Offering.Year + 1} {g.Enrollment.Offering.Semester.Name}",
                CourseName = g.Enrollment.Offering.Course.CourseName,
                GradeValue = g.FinalGrade,
                GradeDate = g.GradeDate
            })
            .ToList();

        return View(grades);
    }
}