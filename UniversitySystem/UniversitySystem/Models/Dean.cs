using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Dean
{
    public int DepartmentId { get; set; }

    public int ProfessorId { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Professor Professor { get; set; } = null!;
}
