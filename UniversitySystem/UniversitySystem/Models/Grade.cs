using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int? EnrollmentId { get; set; }

    public decimal? Grade1 { get; set; }

    public DateOnly? GradeDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
