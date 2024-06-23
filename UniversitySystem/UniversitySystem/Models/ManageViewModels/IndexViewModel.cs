using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models.ManageViewModels;

public class IndexViewModel
{
    public string? Username { get; init; }

    public bool IsEmailConfirmed { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; } = null!;

    [Phone]
    [Display(Name = "Phone number")]
    public string? PhoneNumber { get; init; }

    public string? StatusMessage { get; init; }
}