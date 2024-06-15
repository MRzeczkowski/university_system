using System;
using System.Collections.Generic;

namespace UniversitySystem.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public int? GenderId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AdministrativeEmployee> AdministrativeEmployees { get; set; } = new List<AdministrativeEmployee>();

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
