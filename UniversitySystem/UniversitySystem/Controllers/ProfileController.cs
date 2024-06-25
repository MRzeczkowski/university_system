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
    public async Task<IActionResult> RegisterStudent(long userId)
    {
        var model = new StudentProfileViewModel
        {
            EnrollmentYear = DateTime.UtcNow.Year,
            UserId = userId
        };

        var studentProfile = await _context.Students.FirstOrDefaultAsync(p => p.UserId == userId);
        if (studentProfile != null)
        {
            model.EnrollmentYear = studentProfile.EnrollmentYear;
        }

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> RegisterStudent(StudentProfileViewModel model)
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

        var studentProfile = await _context.Students.FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (studentProfile is null)
        {
            studentProfile = new StudentProfile
            {
                UserId = user.Id,
                EnrollmentYear = model.EnrollmentYear,
                StatusId = model.StatusId
            };

            _context.Students.Add(studentProfile);
        }
        else
        {
            studentProfile.EnrollmentYear = model.EnrollmentYear;
            studentProfile.StatusId = model.StatusId;
        }

        await _userManager.AddToRoleAsync(user, "Student");

        await _context.SaveChangesAsync();

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
            StatusOptions = _context.ProfessorStatuses.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.StatusDescription
            }).ToList(),
            UserId = userId
        };

        var professorProfile = await _context.Professors.FirstOrDefaultAsync(p => p.UserId == userId);
        if (professorProfile == null)
        {
            return View(model);
        }

        model.DepartmentId = professorProfile.DepartmentId;
        model.TitleId = professorProfile.TitleId;
        model.StatusId = professorProfile.StatusId;

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
                TitleId = model.TitleId,
                StatusId = model.StatusId
            };

            _context.Professors.Add(professorProfile);
        }
        else
        {
            professorProfile.DepartmentId = model.DepartmentId;
            professorProfile.TitleId = model.TitleId;
        }
        
        await _userManager.AddToRoleAsync(user, "Professor");

        await _context.SaveChangesAsync();

        return View(model);
    }
    
    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public IActionResult RegisterAdministrator(long userId)
    {
        var model = new AdminProfileViewModel
        {
            UserId = userId
        };

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> RegisterAdministrator(AdminProfileViewModel model)
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

        var adminProfile = await _context.AdministrativeEmployees.FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (adminProfile is null)
        {
            adminProfile = new AdminProfile
            {
                UserId = user.Id
            };

            _context.AdministrativeEmployees.Add(adminProfile);
        }
        else
        {
            adminProfile.ModifiedDate = DateTime.UtcNow;
        }
        
        await _userManager.AddToRoleAsync(user, "AdministrativeEmployee");

        await _context.SaveChangesAsync();

        return View(model);
    }
}