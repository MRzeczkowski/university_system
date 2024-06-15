using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class StudentStatus
{
    public int Id { get; set; }

    public string? StatusDescription { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
