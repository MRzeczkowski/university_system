using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; init; } = null!;
    }
}