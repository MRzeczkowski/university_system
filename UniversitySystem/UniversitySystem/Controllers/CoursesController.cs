using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class CoursesController : Controller
{
    private readonly UniversityContext _context;

    public CoursesController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses
            .Select(c => new CourseViewModel
            {
                Id = c.Id,
                CourseName = c.CourseName,
                DepartmentId = c.DepartmentId,
                DepartmentName = c.Department.Name
            }).ToListAsync();

        return View(courses);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CourseViewModel
        {
            DepartmentOptions = await GetDepartmentOptions()
        };

        return View(model);
    }

    private async Task<List<SelectListItem>> GetDepartmentOptions() =>
        await _context.Departments
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            })
            .ToListAsync();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseViewModel model)
    {
        if (ModelState.IsValid)
        {
            var course = new Course
            {
                CourseName = model.CourseName,
                DepartmentId = model.DepartmentId
            };
            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        var model = new CourseViewModel
        {
            Id = course.Id,
            CourseName = course.CourseName,
            DepartmentId = course.DepartmentId,
            DepartmentName = course.Department.Name,
            DepartmentOptions = await GetDepartmentOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CourseViewModel model)
    {
        if (ModelState.IsValid)
        {
            var course = await _context.Courses.FindAsync(model.Id);
            if (course == null)
            {
                return NotFound();
            }

            course.CourseName = model.CourseName;
            course.DepartmentId = model.DepartmentId;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}