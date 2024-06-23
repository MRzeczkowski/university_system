using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; init; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; init; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; init; }
    }
}
