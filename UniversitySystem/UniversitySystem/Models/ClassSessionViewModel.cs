using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class ClassSessionViewModel
{
    public int Id { get; set; }

    public DateTime SessionStart { get; set; }

    public DateTime SessionEnd { get; set; }

    public int OfferingId { get; set; }
    
    public string? OfferingDescription { get; set; }

    public IEnumerable<SelectListItem>? OfferingOptions { get; set; }
    
    public int ClassroomId { get; set; }

    public string? ClassroomDescription { get; set; }

    public IEnumerable<SelectListItem>? ClassroomOptions { get; set; } = new List<SelectListItem>();
}