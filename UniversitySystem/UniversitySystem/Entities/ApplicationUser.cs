using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public DateTime DateOfBirth { get; init; }

    public int AddressId { get; init; }

    public virtual Address Address { get; init; } = null!;

    public int GenderId { get; init; }

    public virtual Gender Gender { get; init; } = null!;

    public virtual StudentProfile? StudentProfile { get; init; }

    public virtual ProfessorProfile? ProfessorProfile { get; init; }

    public virtual AdminProfile? AdminProfile { get; init; }
}