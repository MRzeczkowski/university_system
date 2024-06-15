using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class StudentStatus
{
    public int Id { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
