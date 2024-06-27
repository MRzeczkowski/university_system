using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "Student")]
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
            return Challenge();

        var userId = user.Id;

        var enrollments = await _context.Enrollments
            .Where(e => e.Student.UserId == userId)
            .Select(e => new EnrollmentViewModel
            {
                Id = e.Id,
                StudentId = e.StudentId,
                StudentName = e.Student.User.FirstName + " " + e.Student.User.LastName,
                CourseName = e.Offering.Course.CourseName,
                Semester = e.Offering.Semester.Name,
                Year = e.Offering.Year,
                EnrollmentDate = e.EnrollmentDate
            }).ToListAsync();

        return View(enrollments);
    }

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
    public async Task<IActionResult> Create(EnrollmentViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return Challenge();

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
                OfferingId = model.OfferingId,
                EnrollmentDate = model.EnrollmentDate
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { studentId = model.StudentId });
        }

        model.CourseOfferingOptions = await GetCourseOfferingOptions();

        return View(model);
    }

    [HttpGet]
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

    private async Task<IEnumerable<SelectListItem>> GetCourseOfferingOptions() =>
        await _context.CourseOfferings
            .Select(co => new SelectListItem
            {
                Value = co.Id.ToString(),
                Text = $"{co.Course.CourseName} - {co.Semester.Name} {co.Year}"
            }).ToListAsync();
}