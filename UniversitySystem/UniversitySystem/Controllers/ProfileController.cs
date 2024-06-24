using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models.ProfileViewModels;

namespace UniversitySystem.Controllers;

public class ProfileController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger _logger;

    public ProfileController(
        UniversityContext context,
        UserManager<ApplicationUser> userManager,
        ILogger<AccountController> logger)
    {
        _context = context;
        _userManager = userManager;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<ViewResult> Index()
    {
        // Many queries should be better for the database since RDBMs usually perform better with small queries instead of fetching whole table.
        // I don't have time for pagination but this would be best.
        var usersWithoutProfiles = await _context.Users
            .Where(u => u.AdminProfile == null && u.ProfessorProfile == null && u.StudentProfile == null)
            .OrderBy(u => u.LastName)
            .Select(u => new UserProfileViewModel
            {
                UserId = u.Id,
                Name = u.FirstName!,
                Surname = u.LastName!,
                Email = u.Email!
            })
            .ToListAsync();

        var students = await _context.Students
            .OrderBy(s => s.User.LastName)
            .Select(s => new UserProfileViewModel
            {
                UserId = s.User.Id,
                Name = s.User.FirstName!,
                Surname = s.User.LastName!,
                Email = s.User.Email!
            })
            .ToListAsync();

        var professors = await _context.Professors
            .OrderBy(p => p.User.LastName)
            .Select(p => new UserProfileViewModel
            {
                UserId = p.User.Id,
                Name = p.User.FirstName!,
                Surname = p.User.LastName!,
                Email = p.User.Email!
            }).ToListAsync();

        var administrators = await _context.AdministrativeEmployees
            .OrderBy(a => a.User.LastName)
            .Select(a => new UserProfileViewModel
            {
                UserId = a.User.Id,
                Name = a.User.FirstName!,
                Surname = a.User.LastName!,
                Email = a.User.Email!
            }).ToListAsync();

        var model = new UserProfilesPageViewModel
        {
            NoProfileUsers = usersWithoutProfiles,
            Students = students,
            Professors = professors,
            Administrators = administrators
        };

        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> RegisterProfessor(long userId)
    {
        var model = new ProfessorProfileViewModel
        {
            DepartmentOptions = _context.Departments
                .Where(d => !d.IsDeleted)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList(),
            TitleOptions = _context.Titles.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.TitleName
            }).ToList(),
            UserId = userId
        };

        var professorProfile = await _context.Professors.FirstOrDefaultAsync(p => p.UserId == userId);
        if (professorProfile != null)
        {
            model.DepartmentId = professorProfile.DepartmentId;
            model.TitleId = professorProfile.TitleId;
        }

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> RegisterProfessor(ProfessorProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        if (user == null)
        {
            return NotFound();
        }

        var professorProfile = await _context.Professors.FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (professorProfile is null)
        {
            professorProfile = new ProfessorProfile
            {
                UserId = user.Id,
                DepartmentId = model.DepartmentId,
                TitleId = model.TitleId
            };

            _context.Professors.Add(professorProfile);
        }
        else
        {
            professorProfile.DepartmentId = model.DepartmentId;
            professorProfile.TitleId = model.TitleId;
        }

        await _context.SaveChangesAsync();

        return View(model);
    }
}