using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;
using UniversitySystem.Services;

namespace UniversitySystem.Controllers;

public class RegistrationController : Controller
{
    private readonly UniversityContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly ILogger _logger;

    public RegistrationController(
        UniversityContext context,
        UserManager<ApplicationUser> userManager,
        IEmailSender emailSender,
        ILogger<AccountController> logger)
    {
        _context = context;
        _userManager = userManager;
        _emailSender = emailSender;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> Index()
    {
        var usersToHandle = await _userManager.Users
            .Where(u => u.EmailConfirmed
                        && (u.FirstName == null
                            || u.LastName == null
                            || u.DateOfBirth == null
                            || u.Address == null
                            || u.Gender == null))
            .ToListAsync();

        var userViewModels = usersToHandle
            .Select(ToViewModel)
            .ToList();

        return View(userViewModels);
    }

    private static UserRegistrationViewModel ToViewModel(ApplicationUser u) =>
        new()
        {
            UserId = u.Id.ToString(),
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            DateOfBirth = u.DateOfBirth,
            Address = ToViewModel(u.Address),
            Gender = u.Gender is null
                ? "Unspecified"
                : u.Gender.Description,
            IsProfileComplete = IsProfileComplete(u)
        };

    private static bool IsProfileComplete(ApplicationUser user) =>
        user is
        {
            FirstName: not null,
            LastName: not null,
            DateOfBirth: not null,
            Address: not null,
            Gender: not null
        };

    private static AddressViewModel ToViewModel(Address? address) =>
        address is null
            ? new AddressViewModel()
            : new AddressViewModel
            {
                Country = address.Country,
                City = address.City,
                PostalCode = address.PostalCode,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                FlatNumber = address.FlatNumber
            };

    [HttpGet]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> EditProfile(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var genderList = _context.Genders.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = g.Description
        }).ToList();

        var model = ToViewModel(user);

        model.GenderOptions = genderList;

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "AdministrativeEmployee")]
    public async Task<IActionResult> EditProfile(UserRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.UserId!);
        if (user == null)
        {
            return NotFound();
        }

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.DateOfBirth = model.DateOfBirth;
        user.GenderId = model.GenderId;

        if (model.Address is not null)
        {
            if (user.Address is not null)
            {
                _context.Entry(user.Address).CurrentValues.SetValues(model.Address);
            }
            else
            {
                var address = ToModel(model.Address);
                _context.Addresses.Add(address);
                address.UserId = user.Id;
                await _context.SaveChangesAsync();
                user.AddressId = address.Id;
            }
        }

        if (IsProfileComplete(user))
        {
            user.LockoutEnabled = false;
            user.LockoutEnd = null;
            await _emailSender.SendEmailAsync(
                user.Email!,
                "University account active",
                "Your University account is now active!");
        }

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            await _context.SaveChangesAsync(); // Save changes for the user and address
            return RedirectToAction("Index");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    private static Address ToModel(AddressViewModel address) =>
        new()
        {
            Country = address.Country,
            City = address.City,
            PostalCode = address.PostalCode,
            Street = address.Street,
            HouseNumber = address.HouseNumber,
            FlatNumber = address.FlatNumber
        };
}