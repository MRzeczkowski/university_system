using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class CourseOfferingController : Controller
{
    private readonly UniversityContext _context;

    public CourseOfferingController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courseOfferings = await _context.CourseOfferings
            .Select(co => new CourseOfferingViewModel
            {
                Id = co.Id,
                CourseName = co.Course.CourseName,
                SemesterName = co.Semester.Name,
                Year = co.Year,
                ProfessorName = $"{co.Professor.User.FirstName} {co.Professor.User.LastName}"
            })
            .ToListAsync();

        return View(courseOfferings);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CourseOfferingViewModel
        {
            Year = DateTime.UtcNow.Year,
            CourseOptions = await GetCourseOptions(),
            SemesterOptions = await GetSemesterOptions(),
            ProfessorOptions = await GetProfessorOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseOfferingViewModel model)
    {
        if (ModelState.IsValid)
        {
            var courseOffering = new CourseOffering
            {
                CourseId = model.CourseId,
                SemesterId = model.SemesterId,
                Year = model.Year,
                ProfessorId = model.ProfessorId
            };

            _context.CourseOfferings.Add(courseOffering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        model.CourseOptions = await GetCourseOptions();
        model.SemesterOptions = await GetSemesterOptions();
        model.ProfessorOptions = await GetProfessorOptions();

        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var courseOffering = await _context.CourseOfferings.FindAsync(id);
        if (courseOffering == null)
        {
            return NotFound();
        }

        var model = new CourseOfferingViewModel
        {
            Id = courseOffering.Id,
            CourseId = courseOffering.CourseId,
            CourseOptions = await GetCourseOptions(),
            SemesterId = courseOffering.SemesterId,
            SemesterOptions = await GetSemesterOptions(),
            Year = courseOffering.Year,
            ProfessorId = courseOffering.ProfessorId,
            ProfessorOptions = await GetProfessorOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CourseOfferingViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.CourseOptions = await GetCourseOptions();
            model.SemesterOptions = await GetSemesterOptions();
            model.ProfessorOptions = await GetProfessorOptions();
            return View(model);
        }

        var courseOffering = await _context.CourseOfferings.FindAsync(model.Id);
        if (courseOffering == null)
        {
            return NotFound();
        }

        courseOffering.CourseId = model.CourseId;
        courseOffering.SemesterId = model.SemesterId;
        courseOffering.Year = model.Year;
        courseOffering.ProfessorId = model.ProfessorId;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var courseOffering = await _context.CourseOfferings.FirstOrDefaultAsync(m => m.Id == id);

        if (courseOffering == null)
        {
            return NotFound();
        }

        var model = new CourseOfferingViewModel
        {
            Id = courseOffering.Id,
            CourseName = courseOffering.Course.CourseName,
            SemesterName = courseOffering.Semester.Name,
            Year = courseOffering.Year,
            ProfessorName = $"{courseOffering.Professor.User.FirstName} {courseOffering.Professor.User.LastName}"
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var courseOffering = await _context.CourseOfferings.FindAsync(id);
        if (courseOffering != null)
        {
            _context.CourseOfferings.Remove(courseOffering);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<IEnumerable<SelectListItem>> GetCourseOptions() =>
        await _context.Courses.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.CourseName
        }).ToListAsync();

    private async Task<IEnumerable<SelectListItem>> GetSemesterOptions() =>
        await _context.Semesters.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToListAsync();

    private async Task<IEnumerable<SelectListItem>> GetProfessorOptions() =>
        await _context.Professors.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = $"{p.User.FirstName} {p.User.LastName}"
        }).ToListAsync();
}