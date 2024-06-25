using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models.ProfileViewModels;

public class ProfessorProfileViewModel
{
    public long UserId { get; set; }

    public int DepartmentId { get; set; }

    public IEnumerable<SelectListItem>? DepartmentOptions { get; set; }

    public int TitleId { get; set; }

    public IEnumerable<SelectListItem>? TitleOptions { get; set; }
    
    public int StatusId { get; set; }

    public IEnumerable<SelectListItem>? StatusOptions { get; set; }
}