using Microsoft.AspNetCore.Identity;
using UniversitySystem.Context;
using UniversitySystem.Entities;

namespace UniversitySystem.Models;

public static class SampleData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<UniversityContext>();

        var roles = new[]
        {
            "AdministrativeEmployee",
            "Professor",
            "Student"
        };
        
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        foreach (var role in roles)
        {
            if (!context.Roles.Any(r => r.Name == role))
            {
                roleManager.CreateAsync(new ApplicationRole(role)).GetAwaiter().GetResult();
            }
        }
        
        context.SaveChanges();

        var user = new ApplicationUser
        {
            Email = "admin@uni.com",
            NormalizedEmail = "admin@uni.com".ToUpper(),
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (!context.Users.Any(u => u.UserName == user.UserName))
        {
            userManager.CreateAsync(user, "P@$$w0rd").GetAwaiter().GetResult();
            userManager.AddToRolesAsync(user, roles).GetAwaiter().GetResult();
        }

        context.SaveChanges();
    }
}