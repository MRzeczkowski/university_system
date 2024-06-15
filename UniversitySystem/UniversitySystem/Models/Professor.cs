using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Professor
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? DepartmentId { get; set; }

    public int? TitleId { get; set; }

    public int? StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

    public virtual ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public virtual ICollection<Dean> Deans { get; set; } = new List<Dean>();

    public virtual Department? Department { get; set; }

    public virtual Person? Person { get; set; }

    public virtual ProfessorStatus? Status { get; set; }

    public virtual Title? Title { get; set; }
}
