using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize]
public class EnrollmentController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EnrollmentController(
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
        {
            return Challenge();
        }

        var userId = user.Id;
        IQueryable<Enrollment> query;

        if (User.IsInRole("Student"))
        {
            query = _context.Enrollments.Where(e => e.Student.UserId == userId);
        }
        else if (User.IsInRole("Professor"))
        {
            query = _context.Enrollments
                .Where(e => e.Offering.Professor.UserId == userId);
        }
        else if (User.IsInRole("AdministrativeEmployee"))
        {
            query = _context.Enrollments;
        }
        else
        {
            return Forbid();
        }

        var enrollments = await query
            .Select(e => new EnrollmentViewModel
            {
                Id = e.Id,
                StudentId = e.StudentId,
                StudentName = $"{e.Student.User.FirstName} {e.Student.User.LastName}",
                CourseName = e.Offering.Course.CourseName,
                Semester = e.Offering.Semester.Name,
                Year = e.Offering.Year,
                Points = e.Points,
                Grade = e.Grade.ToString()
            }).ToListAsync();

        return View(enrollments);
    }

    [Authorize(Roles = "Student")]
    public async Task<IActionResult> Create()
    {
        var model = new EnrollmentViewModel
        {
            CourseOfferingOptions = await GetCourseOfferingOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> Create(EnrollmentViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Challenge();
        }

        var userId = user.Id;
        var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == userId);
        if (student == null)
        {
            return NotFound("Student profile not found.");
        }

        if (ModelState.IsValid)
        {
            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                OfferingId = model.OfferingId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { studentId = model.StudentId });
        }

        model.CourseOfferingOptions = await GetCourseOfferingOptions();

        return View(model);
    }

    [Authorize(Roles = "Professor")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var enrollment = await _context.Enrollments
            .Where(e => e.Id == id && e.Offering.Professor.UserId == user.Id)
            .Select(e => new EnrollmentViewModel
            {
                Id = e.Id,
                StudentId = e.StudentId,
                StudentName = $"{e.Student.User.FirstName} {e.Student.User.LastName}",
                CourseName = e.Offering.Course.CourseName,
                Semester = e.Offering.Semester.Name,
                Year = e.Offering.Year,
                Points = e.Points,
                Grade = e.Grade.ToString()
            })
            .FirstOrDefaultAsync();

        if (enrollment == null) return NotFound();

        return View(enrollment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Professor")]
    public async Task<IActionResult> Edit(EnrollmentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var enrollment = await _context.Enrollments.FindAsync(model.Id);
        if (enrollment == null)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);
        if (enrollment.Offering.Professor.UserId != user!.Id)
        {
            return Forbid();
        }

        enrollment.Points = model.Points;
        if (model.Grade != null)
        {
            enrollment.Grade = decimal.Parse(model.Grade, CultureInfo.InvariantCulture);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Enrollments
            .Select(e => new EnrollmentViewModel
            {
                Id = e.Id,
                CourseName = e.Offering.Course.CourseName,
            })
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

        if (enrollment == null)
        {
            return NotFound();
        }

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { studentId = enrollment.StudentId });
    }

    private async Task<IEnumerable<SelectListItem>> GetCourseOfferingOptions()
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user!.Id;

        var studentId = await _context.Students
            .Where(s => s.UserId == userId)
            .Select(s => s.Id)
            .FirstOrDefaultAsync();

        if (studentId == 0)
        {
            return new List<SelectListItem>();
        }

        var enrolledOfferingIds = await _context.Enrollments
            .Where(e => e.StudentId == studentId)
            .Select(e => e.OfferingId)
            .ToListAsync();

        return await _context.CourseOfferings
            .Where(co => !enrolledOfferingIds.Contains(co.Id))
            .Select(co => new SelectListItem
            {
                Value = co.Id.ToString(),
                Text = $"{co.Course.CourseName} - {co.Semester.Name} {co.Year}"
            })
            .ToListAsync();
    }
}