using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Entities;

public class ApplicationRole : IdentityRole<long>
{
    public ApplicationRole()
    {
    }

    public ApplicationRole(string roleName) : base(roleName)
    {
    }
}