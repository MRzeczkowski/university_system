using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Student
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? EnrollmentYear { get; set; }

    public int? StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Person? Person { get; set; }

    public virtual StudentStatus? Status { get; set; }
}
