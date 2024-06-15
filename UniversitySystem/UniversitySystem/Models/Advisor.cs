using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Advisor
{
    public int StudentId { get; set; }

    public int ProfessorId { get; set; }

    public DateOnly AssignmentDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Professor Professor { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
