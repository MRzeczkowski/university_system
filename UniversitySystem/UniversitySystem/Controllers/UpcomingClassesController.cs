using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Context;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

public class UpcomingClassesController : Controller
{
    private readonly UniversityContext _context;

    public UpcomingClassesController(UniversityContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var upcomingClasses = _context.ClassSessions
            .Where(cs => cs.SessionStart > DateTime.UtcNow)
            .Select(cs => new UpcomingClassViewModel
            {
                CourseName = cs.Offering.Course.CourseName,
                SessionStart = cs.SessionStart,
                SessionEnd = cs.SessionEnd,
                ProfessorName = $"{cs.Offering.Professor.User.FirstName} {cs.Offering.Professor.User.LastName}",
                Room = cs.Offering.Classroom.RoomNumber
            })
            .OrderBy(cs => cs.SessionStart)
            .ToList();

        return View(upcomingClasses);
    }
}