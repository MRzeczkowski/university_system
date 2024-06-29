using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class ClassSessionController : Controller
{
    private readonly UniversityContext _context;

    public ClassSessionController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var classSessions = await _context.ClassSessions
            .Select(cs => new ClassSessionViewModel
            {
                Id = cs.Id,
                OfferingId = cs.OfferingId,
                SessionStart = cs.SessionStart,
                SessionEnd = cs.SessionEnd
            })
            .ToListAsync();

        return View(classSessions);
    }

    public async Task<IActionResult> Create()
    {
        var model = new ClassSessionViewModel
        {
            SessionStart = DateTime.Now.Date.AddHours(9),
            SessionEnd = DateTime.Now.Date.AddHours(10),
            OfferingOptions = await GetOfferingOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClassSessionViewModel model)
    {
        if (ModelState.IsValid)
        {
            var classSession = new ClassSession
            {
                OfferingId = model.OfferingId,
                SessionStart = model.SessionStart,
                SessionEnd = model.SessionEnd
            };

            var attendances = await _context.Enrollments
                .Where(e => e.OfferingId == model.OfferingId)
                .Select(e => new Attendance
                {
                    EnrollmentId = e.Id,
                    ClassSession = classSession,
                    StatusId = 1 // Absent by default.
                }).ToListAsync();

            _context.Add(classSession);
            _context.AddRange(attendances);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        model.OfferingOptions = await GetOfferingOptions();
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var classSession = await _context.ClassSessions.FindAsync(id);
        if (classSession == null)
        {
            return NotFound();
        }

        var model = new ClassSessionViewModel
        {
            Id = classSession.Id,
            OfferingId = classSession.OfferingId,
            SessionStart = classSession.SessionStart,
            SessionEnd = classSession.SessionEnd,
            OfferingOptions = await GetOfferingOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClassSessionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.OfferingOptions = await GetOfferingOptions();
            return View(model);
        }

        var classSession = await _context.ClassSessions.FindAsync(model.Id);
        if (classSession == null)
        {
            return NotFound();
        }

        classSession.OfferingId = model.OfferingId;
        classSession.SessionStart = model.SessionStart;
        classSession.SessionEnd = model.SessionEnd;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Professor")]
    public async Task<IActionResult> MarkAttendance(int classSessionId)
    {
        var classSession = await _context.ClassSessions.FirstOrDefaultAsync(cs => cs.Id == classSessionId);

        if (classSession == null)
        {
            return NotFound();
        }

        var attendanceViewModels = classSession.Attendances
            .Select(a => new AttendanceViewModel
            {
                AttendanceId = a.Id,
                StudentName = $"{a.Enrollment.Student.User.FirstName} {a.Enrollment.Student.User.LastName}",
                StatusId = a.StatusId
            }).ToList();

        var statusOptions = await _context.AttendanceStatuses
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.StatusName
            }).ToListAsync();

        var model = new AttendancesViewModel
        {
            Attendances = attendanceViewModels,
            StatusOptions = statusOptions
        };

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Professor")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MarkAttendance(AttendancesViewModel model)
    {
        var attendances = await _context.Attendances
            .Where(a => model.Attendances.Select(m => m.AttendanceId).Contains(a.Id))
            .ToListAsync();

        foreach (var attendance in attendances)
        {
            var attendanceViewModel = model.Attendances.FirstOrDefault(m => m.AttendanceId == attendance.Id);
            if (attendanceViewModel != null)
            {
                attendance.StatusId = attendanceViewModel.StatusId;
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classSession = await _context.ClassSessions
            .Select(cs => new ClassSessionViewModel
            {
                Id = cs.Id,
                OfferingId = cs.OfferingId,
                SessionStart = cs.SessionStart,
                SessionEnd = cs.SessionEnd
            })
            .FirstOrDefaultAsync(d => d.Id == id);

        if (classSession == null)
        {
            return NotFound();
        }

        return View(classSession);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var classSession = await _context.ClassSessions.FindAsync(id);
        if (classSession == null)
        {
            return RedirectToAction(nameof(Index));
        }

        _context.ClassSessions.Remove(classSession);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task<IEnumerable<SelectListItem>> GetOfferingOptions() =>
        await _context.CourseOfferings.Select(co => new SelectListItem
        {
            Value = co.Id.ToString(),
            Text = $"{co.Course.CourseName} - {co.Semester.Name} {co.Year}"
        }).ToListAsync();
}