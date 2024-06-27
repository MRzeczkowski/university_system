using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class DeansController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DeansController(UniversityContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var deans = await _context.Deans
            .Select(d => new DeanViewModel
            {
                DepartmentName = d.Department.Name,
                ProfessorName = $"{d.Professor.User.FirstName} {d.Professor.User.LastName}",
                EffectiveDate = d.EffectiveDate
            })
            .ToListAsync();

        return View(deans);
    }

    public async Task<IActionResult> Create()
    {
        var model = new DeanViewModel
        {
            DepartmentOptions = await GetDepartmentOptions(),
            ProfessorOptions = await GetProfessorOptions()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DeanViewModel model)
    {
        if (ModelState.IsValid)
        {
            var dean = new Dean
            {
                DepartmentId = model.DepartmentId,
                ProfessorId = model.ProfessorId,
                EffectiveDate = model.EffectiveDate
            };

            _context.Deans.Add(dean);

            // Find the professor's user account and add to the AdministrativeEmployee role if not already added
            var professor = await _context.Professors
                .FirstOrDefaultAsync(p => p.Id == model.ProfessorId);

            if (professor != null)
            {
                var user = await _userManager.FindByIdAsync(professor.UserId.ToString());
                if (user != null && !await _userManager.IsInRoleAsync(user, "AdministrativeEmployee"))
                {
                    await _userManager.AddToRoleAsync(user, "AdministrativeEmployee");
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        model.DepartmentOptions = await GetDepartmentOptions();
        model.ProfessorOptions = await GetProfessorOptions();

        return View(model);
    }

    public async Task<IActionResult> Delete(int departmentId, int professorId)
    {
        var dean = await _context.Deans.FirstOrDefaultAsync(d => d.DepartmentId == departmentId && d.ProfessorId == professorId);
        if (dean == null)
        {
            return NotFound();
        }

        var model = new DeanViewModel
        {
            DepartmentName = dean.Department.Name,
            ProfessorName = $"{dean.Professor.User.FirstName} {dean.Professor.User.LastName}",
            EffectiveDate = dean.EffectiveDate
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int departmentId, int professorId)
    {
        var dean = await _context.Deans
            .FirstOrDefaultAsync(d => d.DepartmentId == departmentId && d.ProfessorId == professorId);

        if (dean != null)
        {
            _context.Deans.Remove(dean);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<IEnumerable<SelectListItem>> GetDepartmentOptions() =>
        await _context.Departments.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.Name
        }).ToListAsync();

    private async Task<IEnumerable<SelectListItem>> GetProfessorOptions() =>
        await _context.Professors.Include(p => p.User).Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = $"{p.User.FirstName} {p.User.LastName}"
        }).ToListAsync();
}