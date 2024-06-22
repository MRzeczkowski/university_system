using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; init; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; init; }
    }
}
