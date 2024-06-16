using System;
using System.Collections.Generic;

namespace UniversitySystem.Entities;

public partial class CourseOffering
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public int Year { get; set; }

    public int ProfessorId { get; set; }

    public int ClassroomId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Professor Professor { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;
}
