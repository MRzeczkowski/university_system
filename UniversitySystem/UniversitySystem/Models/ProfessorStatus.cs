using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class ProfessorStatus
{
    public int Id { get; set; }

    public string? StatusDescription { get; set; }

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
