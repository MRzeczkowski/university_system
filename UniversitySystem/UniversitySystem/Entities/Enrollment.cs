using System;
using System.Collections.Generic;

namespace UniversitySystem.Entities;

public partial class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int OfferingId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual CourseOffering Offering { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
