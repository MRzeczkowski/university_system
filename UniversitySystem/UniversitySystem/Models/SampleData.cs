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
            context.Genders.Add(new Gender { Id = 1, Description = "Male" });
            context.Genders.Add(new Gender { Id = 2, Description = "Female" });
            context.Genders.Add(new Gender { Id = 3, Description = "Prefer Not to Say" });
        }

        if (!context.StudentStatuses.Any())
        {
            context.StudentStatuses.Add(new StudentStatus { Id = 1, StatusDescription = "Enrolled" });
            context.StudentStatuses.Add(new StudentStatus { Id = 2, StatusDescription = "Graduated" });
            context.StudentStatuses.Add(new StudentStatus { Id = 3, StatusDescription = "Suspended" });
            context.StudentStatuses.Add(new StudentStatus { Id = 4, StatusDescription = "Withdrawn" });
        }

        if (!context.ProfessorStatuses.Any())
        {
            context.ProfessorStatuses.Add(new ProfessorStatus { Id = 1, StatusDescription = "Active" });
            context.ProfessorStatuses.Add(new ProfessorStatus { Id = 2, StatusDescription = "On Leave" });
            context.ProfessorStatuses.Add(new ProfessorStatus { Id = 3, StatusDescription = "Retired" });
            context.ProfessorStatuses.Add(new ProfessorStatus { Id = 4, StatusDescription = "Emeritus" });
        }

        if (!context.Titles.Any())
        {
            context.Titles.Add(new Title { Id = 1, TitleName = "Professor" });
            context.Titles.Add(new Title { Id = 2, TitleName = "Associate Professor" });
            context.Titles.Add(new Title { Id = 3, TitleName = "Assistant Professor" });
            context.Titles.Add(new Title { Id = 4, TitleName = "Lecturer" });
            context.Titles.Add(new Title { Id = 5, TitleName = "Senior Lecturer" });
        }

        if (!context.Semesters.Any())
        {
            context.Semesters.Add(new Semester { Id = 1, Name = "Winter" });
            context.Semesters.Add(new Semester { Id = 2, Name = "Summer" });
        }

        if (!context.AttendanceStatuses.Any())
        {
            context.AttendanceStatuses.Add(new AttendanceStatus { Id = 1, StatusName = "Absent" });
            context.AttendanceStatuses.Add(new AttendanceStatus { Id = 2, StatusName = "Present" });
            context.AttendanceStatuses.Add(new AttendanceStatus { Id = 3, StatusName = "Excused" });
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
                Id = 1,
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