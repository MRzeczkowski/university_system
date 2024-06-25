using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models.ProfileViewModels;

public class StudentProfileViewModel
{
    public long UserId { get; set; }

    public int EnrollmentYear { get; set; }

    public int StatusId { get; set; }

    public IEnumerable<SelectListItem>? StatusOptions { get; set; }
}