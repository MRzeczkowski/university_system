using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitySystem.Models;

public class AttendancesViewModel
{
    public List<AttendanceViewModel> Attendances { get; set; }

    public IEnumerable<SelectListItem>? StatusOptions { get; set; }
}

public class AttendanceViewModel
{
    public int AttendanceId { get; set; }

    public string StudentName { get; set; }

    public int StatusId { get; set; }
}