using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class DeanViewModel
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public int ProfessorId { get; set; }

    public string ProfessorName { get; set; }

    public DateOnly EffectiveDate { get; set; }

    public IEnumerable<SelectListItem> DepartmentOptions { get; set; }

    public IEnumerable<SelectListItem> ProfessorOptions { get; set; }
}