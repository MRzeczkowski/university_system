using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class AttendanceStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
