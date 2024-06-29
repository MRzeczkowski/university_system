using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Context;
using UniversitySystem.Models;
using UniversitySystem.Entities;

namespace UniversitySystem.Controllers;

public class UpcomingClassesController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UpcomingClassesController(
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

        var upcomingClasses = _context.ClassSessions
            .Where(cs => cs.SessionStart > DateTime.UtcNow && cs.Offering.Enrollments.Any(e => e.Student.UserId == userId))
            .Select(cs => new UpcomingClassViewModel
            {
                CourseName = cs.Offering.Course.CourseName,
                SessionStart = cs.SessionStart,
                SessionEnd = cs.SessionEnd,
                ProfessorName = $"{cs.Offering.Professor.User.FirstName} {cs.Offering.Professor.User.LastName}",
                Room = cs.Classroom.RoomNumber
            })
            .OrderBy(cs => cs.SessionStart)
            .ToList();

        return View(upcomingClasses);
    }
}