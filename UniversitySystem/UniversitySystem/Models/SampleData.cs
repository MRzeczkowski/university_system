using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Context;
using UniversitySystem.Entities;

namespace UniversitySystem.Models;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public static class SampleData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<UniversityContext>();

        if (!context.Genders.Any())
        {
            context.Genders.Add(new Gender { Description = "Male" });
            context.Genders.Add(new Gender { Description = "Female" });
            context.Genders.Add(new Gender { Description = "Prefer Not to Say" });
        }

        if (!context.StudentStatuses.Any())
        {
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Enrolled" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Graduated" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Suspended" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Withdrawn" });
        }

        if (!context.ProfessorStatuses.Any())
        {
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Active" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "On Leave" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Retired" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Emeritus" });
        }

        if (!context.Titles.Any())
        {
            context.Titles.Add(new Title { TitleName = "Professor" });
            context.Titles.Add(new Title { TitleName = "Associate Professor" });
            context.Titles.Add(new Title { TitleName = "Assistant Professor" });
            context.Titles.Add(new Title { TitleName = "Lecturer" });
            context.Titles.Add(new Title { TitleName = "Senior Lecturer" });
        }

        if (!context.Semesters.Any())
        {
            context.Semesters.Add(new Semester { Name = "Winter" });
            context.Semesters.Add(new Semester { Name = "Summer" });
        }

        if (!context.AttendanceStatuses.Any())
        {
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Absent" });
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Present" });
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Excused" });
        }

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

        var users = new List<ApplicationUser>();

        const string adminEmail = "admin@uni.com";
        const string adminUserName = "admin";

        var admin = new ApplicationUser
        {
            Email = adminEmail,
            NormalizedEmail = adminEmail.ToUpper(),
            UserName = adminUserName,
            NormalizedUserName = adminUserName.ToUpper(),
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            FirstName = "Mateusz",
            LastName = "Rzeczkowski",
            DateOfBirth = new DateTime(1996, 9, 17),
            GenderId = 1,
            Address = new Address
            {
                Street = "Krucza",
                HouseNumber = 32,
                City = "Ciechanów",
                PostalCode = "06-400",
                Country = "Poland"
            }
        };

        users.Add(admin);

#if DEBUG
        const string test1Email = "test1@test.com";

        var test1 = new ApplicationUser
        {
            Email = test1Email,
            NormalizedEmail = test1Email.ToUpper(),
            UserName = test1Email,
            NormalizedUserName = test1Email.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            LockoutEnd = DateTimeOffset.MaxValue
        };

        users.Add(test1);

        const string test2Email = "test2@test.com";

        var test2 = new ApplicationUser
        {
            Email = test2Email,
            NormalizedEmail = test2Email.ToUpper(),
            UserName = test2Email,
            NormalizedUserName = test2Email.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            LockoutEnd = DateTimeOffset.MaxValue
        };

        users.Add(test2);
#endif

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        foreach (var user in users.Where(user => !context.Users.Any(u => u.UserName == user.UserName)))
        {
            userManager.CreateAsync(user, "P@$$w0rd").GetAwaiter().GetResult();

            if (user.UserName == adminUserName)
            {
                userManager.AddToRolesAsync(admin, roles).GetAwaiter().GetResult();
            }
        }

        context.SaveChanges();
    }
}