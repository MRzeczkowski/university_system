namespace UniversitySystem.Models.ProfileViewModels;

public class UserProfilesPageViewModel
{
    public List<UserProfileViewModel> NoProfileUsers { get; set; } = new();

    public List<UserProfileViewModel> Students { get; set; } = new();

    public List<UserProfileViewModel> Professors { get; set; } = new();

    public List<UserProfileViewModel> Administrators { get; set; } = new();
}