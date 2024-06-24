using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models.UserRegistrationViewModels;

public class UserRegistrationViewModel
{
    public long UserId { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public AddressViewModel? Address { get; set; }

    public int? GenderId { get; set; }

    public string? Gender { get; set; }

    public bool IsProfileComplete { get; set; }

    public List<SelectListItem>? GenderOptions { get; set; } = [];
}