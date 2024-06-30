using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class DeanViewModel
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int ProfessorId { get; set; }

    public string ProfessorName { get; set; } = null!;

    public DateTime EffectiveDate { get; set; }

    public IEnumerable<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();

    public IEnumerable<SelectListItem> ProfessorOptions { get; set; } = new List<SelectListItem>();
}