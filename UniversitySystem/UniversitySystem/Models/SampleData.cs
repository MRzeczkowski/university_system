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

        var user = new ApplicationUser
        {
            Email = "admin@uni.com",
            NormalizedEmail = "admin@uni.com".ToUpper(),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
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

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (!context.Users.Any(u => u.UserName == user.UserName))
        {
            userManager.CreateAsync(user, "P@$$w0rd").GetAwaiter().GetResult();
            userManager.AddToRolesAsync(user, roles).GetAwaiter().GetResult();
        }

        context.SaveChanges();
    }
}