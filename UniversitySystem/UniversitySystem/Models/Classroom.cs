using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string? Building { get; set; }

    public string? RoomNumber { get; set; }

    public int? Capacity { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
