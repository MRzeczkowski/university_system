using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class DepartmentsController : Controller
{
    private readonly UniversityContext _context;

    public DepartmentsController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _context.Departments
            .Select(d => new DepartmentViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Budget = d.Budget
            })
            .ToListAsync();

        return View(departments);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DepartmentViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var department = new Department
        {
            Name = viewModel.Name,
            Budget = viewModel.Budget
        };
        _context.Add(department);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments
            .Select(d => new DepartmentViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Budget = d.Budget
            })
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DepartmentViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var department = await _context.Departments.FindAsync(id);
        if (department == null)
        {
            return NotFound();
        }

        department.Name = viewModel.Name;
        department.Budget = viewModel.Budget;

        _context.Update(department);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}