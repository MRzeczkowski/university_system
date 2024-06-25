using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models.ProfileViewModels;

public class AdminProfileViewModel
{
    public long UserId { get; set; }
    
    public int StatusId { get; set; }

    public IEnumerable<SelectListItem>? StatusOptions { get; set; }
}