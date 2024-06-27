using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Entities;

namespace UniversitySystem.Context;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public class UniversityContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; init; } = null!;

    public virtual DbSet<AdminProfile> AdministrativeEmployees { get; init; } = null!;

    public virtual DbSet<AdminStatus> AdminStatuses { get; init; } = null!;

    public virtual DbSet<Attendance> Attendances { get; init; } = null!;

    public virtual DbSet<AttendanceStatus> AttendanceStatuses { get; init; } = null!;

    public virtual DbSet<ClassSession> ClassSessions { get; init; } = null!;

    public virtual DbSet<Classroom> Classrooms { get; init; } = null!;

    public virtual DbSet<Course> Courses { get; init; } = null!;

    public virtual DbSet<CourseOffering> CourseOfferings { get; init; } = null!;

    public virtual DbSet<Dean> Deans { get; init; } = null!;

    public virtual DbSet<Department> Departments { get; init; } = null!;

    public virtual DbSet<Enrollment> Enrollments { get; init; } = null!;

    public virtual DbSet<Gender> Genders { get; init; } = null!;

    public virtual DbSet<ProfessorProfile> Professors { get; init; } = null!;

    public virtual DbSet<ProfessorStatus> ProfessorStatuses { get; init; } = null!;

    public virtual DbSet<Semester> Semesters { get; init; } = null!;

    public virtual DbSet<StudentProfile> Students { get; init; } = null!;

    public virtual DbSet<StudentStatus> StudentStatuses { get; init; } = null!;

    public virtual DbSet<Title> Titles { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Addresses", "Administration");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminProfile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("AdministrativeEmployees", "Administration");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.User).WithOne(p => p.AdminProfile)
                .HasForeignKey<AdminProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Admins)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AdminStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("AdministrativeEmployeeStatuses", "Administration");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Attendance", "Students");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.ClassSession).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.ClassSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AttendanceStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("AttendanceStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StatusName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassSession>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ClassSessions", "Academics");

            entity.HasIndex(e => new { e.OfferingId, e.SessionStart });

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Offering).WithMany(p => p.ClassSessions)
                .HasForeignKey(d => d.OfferingId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Classrooms", "Academics");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Courses", "Academics");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CourseOffering>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("CourseOfferings", "Academics");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Classroom).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Course).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Semester).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Dean>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.ProfessorId });

            entity.ToTable("Deans", "Administration");

            entity.HasIndex(e => e.DepartmentId);

            entity.HasOne(d => d.Department).WithMany(p => p.Deans)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Professor).WithMany(p => p.Deans)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Departments", "Administration");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Enrollments", "Students");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Grade).HasPrecision(2, 1);

            entity.HasOne(d => d.Offering).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.OfferingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Genders", "Administration");

            entity.HasIndex(e => e.Description).IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProfessorProfile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Professors", "Academics");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Department).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithOne(p => p.ProfessorProfile)
                .HasForeignKey<ProfessorProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Professors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Title).WithMany(p => p.Professors)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProfessorStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ProfessorStatuses", "Academics");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Semesters", "Academics");

            entity.HasIndex(e => e.Name).IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Students", "Students");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithOne(p => p.StudentProfile)
                .HasForeignKey<StudentProfile>(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Students)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StudentStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("StudentStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Titles", "Academics");

            entity.HasIndex(e => e.TitleName).IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TitleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            // Primary key is already defined by IdentityUser

            entity.Property(e => e.FirstName)
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .HasMaxLength(50);

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime2");

            entity.HasOne(e => e.Gender)
                .WithMany(g => g.Users)
                .HasForeignKey(e => e.GenderId);

            entity.HasOne(e => e.Address)
                .WithOne(g => g.User)
                .HasForeignKey<Address>(e => e.UserId);

            entity.HasOne(e => e.StudentProfile)
                .WithOne(s => s.User)
                .HasForeignKey<StudentProfile>(s => s.UserId);

            entity.HasOne(e => e.ProfessorProfile)
                .WithOne(p => p.User)
                .HasForeignKey<ProfessorProfile>(p => p.UserId);

            entity.HasOne(e => e.AdminProfile)
                .WithOne(a => a.User)
                .HasForeignKey<AdminProfile>(a => a.UserId);
        });
    }
}