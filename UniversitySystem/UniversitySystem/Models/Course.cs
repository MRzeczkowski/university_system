using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual Department Department { get; set; } = null!;
}
