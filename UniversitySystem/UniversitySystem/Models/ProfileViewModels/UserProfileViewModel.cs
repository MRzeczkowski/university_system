namespace UniversitySystem.Models.ProfileViewModels;

public class UserProfileViewModel
{
    public long UserId { get; set; }
    
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;
}