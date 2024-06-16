using System;
using System.Collections.Generic;

namespace UniversitySystem.Entities;

public partial class ProfessorStatus
{
    public int Id { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
