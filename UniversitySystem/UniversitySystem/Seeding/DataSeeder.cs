using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Context;
using UniversitySystem.Entities;

namespace UniversitySystem.Seeding;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public static class DataSeeder
{
    private const string AdminRole = "AdministrativeEmployee";
    private const string ProfessorRole = "Professor";
    private const string StudentRole = "Student";
    private const string Password = "P@$$w0rd";

    public static void SeedRequiredData(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<UniversityContext>();

        SeedGenders(context);
        SeedStudentStatuses(context);
        SeedProfessorStatuses(context);
        SeedAdminStatuses(context);
        SeedTitles(context);
        SeedSemesters(context);
        SeedAttendanceStatuses(context);
        SeedRoles(serviceProvider, context);
        SeedAdmin(serviceProvider, context);

        context.SaveChanges();
    }

    private static void SeedAdmin(IServiceProvider serviceProvider, UniversityContext context)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        const string adminEmail = "admin@uni.com";

        if (userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult() == null)
        {
            var admin = new ApplicationUser
            {
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                EmailConfirmed = true,
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

            var result = userManager.CreateAsync(admin, Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, AdminRole).GetAwaiter().GetResult();

                var adminProfile = new AdminProfile
                {
                    UserId = admin.Id,
                    StatusId = 1
                };

                context.Add(adminProfile);
                context.SaveChanges();
            }
        }
    }

    private static void SeedRoles(IServiceProvider serviceProvider, UniversityContext context)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        if (!context.Roles.Any())
        {
            roleManager.CreateAsync(new ApplicationRole(AdminRole)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new ApplicationRole(ProfessorRole)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new ApplicationRole(StudentRole)).GetAwaiter().GetResult();
        }
    }

    private static void SeedAttendanceStatuses(UniversityContext context)
    {
        if (!context.AttendanceStatuses.Any())
        {
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Absent" });
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Present" });
            context.AttendanceStatuses.Add(new AttendanceStatus { StatusName = "Excused" });
            context.SaveChanges();
        }
    }

    private static void SeedSemesters(UniversityContext context)
    {
        if (!context.Semesters.Any())
        {
            context.Semesters.Add(new Semester { Name = "Winter" });
            context.Semesters.Add(new Semester { Name = "Summer" });
            context.SaveChanges();
        }
    }

    private static void SeedTitles(UniversityContext context)
    {
        if (!context.Titles.Any())
        {
            context.Titles.Add(new Title { TitleName = "Professor" });
            context.Titles.Add(new Title { TitleName = "Associate Professor" });
            context.Titles.Add(new Title { TitleName = "Assistant Professor" });
            context.Titles.Add(new Title { TitleName = "Lecturer" });
            context.Titles.Add(new Title { TitleName = "Senior Lecturer" });
            context.SaveChanges();
        }
    }

    private static void SeedAdminStatuses(UniversityContext context)
    {
        if (!context.AdminStatuses.Any())
        {
            context.AdminStatuses.Add(new AdminStatus { StatusDescription = "Active" });
            context.AdminStatuses.Add(new AdminStatus { StatusDescription = "On Leave" });
            context.AdminStatuses.Add(new AdminStatus { StatusDescription = "Retired" });
            context.SaveChanges();
        }
    }

    private static void SeedProfessorStatuses(UniversityContext context)
    {
        if (!context.ProfessorStatuses.Any())
        {
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Active" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "On Leave" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Retired" });
            context.ProfessorStatuses.Add(new ProfessorStatus { StatusDescription = "Emeritus" });
            context.SaveChanges();
        }
    }

    private static void SeedStudentStatuses(UniversityContext context)
    {
        if (!context.StudentStatuses.Any())
        {
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Enrolled" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Graduated" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Suspended" });
            context.StudentStatuses.Add(new StudentStatus { StatusDescription = "Withdrawn" });
            context.SaveChanges();
        }
    }

    private static void SeedGenders(UniversityContext context)
    {
        if (!context.Genders.Any())
        {
            context.Genders.Add(new Gender { Description = "Male" });
            context.Genders.Add(new Gender { Description = "Female" });
            context.Genders.Add(new Gender { Description = "Prefer Not to Say" });
            context.SaveChanges();
        }
    }

    public static void SeedTestData(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<UniversityContext>();

        SeedDepartments(context);
        SeedCourses(context);

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        SeedPendingUser(userManager, context);
        SeedProfessors(userManager, context);
        SeedCourseOfferings(context);
        SeedClassrooms(context);
        SeedClassSessions(context);
        SeedStudents(userManager, context);
        SeedEnrollments(context);
        SeedAttendances(context);

        context.SaveChanges();
    }

    private static void SeedAttendances(UniversityContext context)
    {
        if (!context.Attendances.Any())
        {
            context.Attendances.Add(new Attendance
            {
                StatusId = 1,
                ClassSessionId = context.ClassSessions.First().Id,
                EnrollmentId = context.Enrollments.First().Id
            });
            context.SaveChanges();
        }
    }

    private static void SeedEnrollments(UniversityContext context)
    {
        if (!context.Enrollments.Any())
        {
            context.Enrollments.Add(new Enrollment
            {
                StudentId = context.Students.First().Id,
                OfferingId = context.CourseOfferings.First().Id
            });
            context.SaveChanges();
        }
    }

    private static void SeedStudents(UserManager<ApplicationUser> userManager, UniversityContext context)
    {
        const string studentEmail = "stud@uni.com";

        if (userManager.FindByEmailAsync(studentEmail).GetAwaiter().GetResult() == null)
        {
            var testStudent = new ApplicationUser
            {
                Email = studentEmail,
                NormalizedEmail = studentEmail.ToUpper(),
                UserName = studentEmail,
                NormalizedUserName = studentEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Joanna",
                LastName = "Nowak",
                DateOfBirth = new DateTime(1999, 6, 25),
                GenderId = 2,
                Address = new Address
                {
                    Street = "Kacza",
                    HouseNumber = 42,
                    City = "Ciechanów",
                    PostalCode = "06-400",
                    Country = "Poland"
                }
            };

            var result = userManager.CreateAsync(testStudent, Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(testStudent, StudentRole).GetAwaiter().GetResult();

                var adminProfile = new StudentProfile
                {
                    UserId = testStudent.Id,
                    StatusId = 1,
                    EnrollmentYear = 2024
                };

                context.Add(adminProfile);
                context.SaveChanges();
            }
        }
    }

    private static void SeedClassSessions(UniversityContext context)
    {
        if (!context.ClassSessions.Any())
        {
            context.ClassSessions.Add(new ClassSession
            {
                SessionStart = new DateTime(2024, 9, 17, 9, 0, 0),
                SessionEnd = new DateTime(2024, 9, 17, 10, 0, 0),
                OfferingId = context.CourseOfferings.First().Id,
                ClassroomId = context.Classrooms.First().Id
            });
            context.SaveChanges();
        }
    }

    private static void SeedCourseOfferings(UniversityContext context)
    {
        if (!context.CourseOfferings.Any())
        {
            context.CourseOfferings.Add(new CourseOffering
            {
                Year = 2024,
                SemesterId = 1,
                CourseId = context.Courses.First().Id,
                ProfessorId = context.Professors.First().Id
            });
            context.SaveChanges();
        }
    }

    private static void SeedClassrooms(UniversityContext context)
    {
        if (!context.Classrooms.Any())
        {
            context.Classrooms.Add(new Classroom
            {
                Building = "Newelska 6",
                RoomNumber = "123a",
                Capacity = 15
            });
            context.SaveChanges();
        }
    }

    private static void SeedProfessors(UserManager<ApplicationUser> userManager, UniversityContext context)
    {
        const string professorEmail = "prof@uni.com";

        if (userManager.FindByEmailAsync(professorEmail).GetAwaiter().GetResult() == null)
        {
            var testProfessor = new ApplicationUser
            {
                Email = professorEmail,
                NormalizedEmail = professorEmail.ToUpper(),
                UserName = professorEmail,
                NormalizedUserName = professorEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Jan",
                LastName = "Kowalski",
                DateOfBirth = new DateTime(1976, 12, 1),
                GenderId = 1,
                Address = new Address
                {
                    Street = "Warszawska",
                    HouseNumber = 12,
                    City = "Ciechanów",
                    PostalCode = "06-400",
                    Country = "Poland"
                }
            };

            var result = userManager.CreateAsync(testProfessor, Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(testProfessor, ProfessorRole).GetAwaiter().GetResult();

                var adminProfile = new ProfessorProfile
                {
                    UserId = testProfessor.Id,
                    StatusId = 1,
                    TitleId = 1,
                    DepartmentId = context.Departments.First().Id
                };

                context.Add(adminProfile);
                context.SaveChanges();
            }
        }
    }
    
    private static void SeedPendingUser(UserManager<ApplicationUser> userManager, UniversityContext context)
    {
        const string pendingEmail = "pending@uni.com";

        if (userManager.FindByEmailAsync(pendingEmail).GetAwaiter().GetResult() == null)
        {
            var testProfessor = new ApplicationUser
            {
                Email = pendingEmail,
                NormalizedEmail = pendingEmail.ToUpper(),
                UserName = pendingEmail,
                NormalizedUserName = pendingEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = true,
                LockoutEnd = DateTimeOffset.MaxValue
            };

            userManager.CreateAsync(testProfessor, Password).GetAwaiter().GetResult();
        }
    }

    private static void SeedCourses(UniversityContext context)
    {
        if (!context.Courses.Any())
        {
            context.Courses.Add(new Course
            {
                CourseName = "Programming",
                DepartmentId = context.Departments.First().Id
            });
            context.SaveChanges();
        }
    }

    private static void SeedDepartments(UniversityContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.Add(new Department
            {
                Name = "Computer science",
                Budget = 1000000
            });
            context.SaveChanges();
        }
    }
}