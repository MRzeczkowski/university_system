using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? GenderId { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Address? Address { get; set; }

    public virtual StudentProfile? StudentProfile { get; set; }

    public virtual ProfessorProfile? ProfessorProfile { get; set; }

    public virtual AdminProfile? AdminProfile { get; set; }
}