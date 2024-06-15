using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
