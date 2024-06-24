﻿namespace UniversitySystem.Entities;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Budget { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Dean> Deans { get; set; } = new List<Dean>();

    public virtual ICollection<ProfessorProfile> Professors { get; set; } = new List<ProfessorProfile>();
}