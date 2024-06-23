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

    public virtual DbSet<Advisor> Advisors { get; init; } = null!;

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

    public virtual DbSet<Grade> Grades { get; init; } = null!;

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
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC078ECCD8CD");

            entity.ToTable("Addresses", "Administration");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__7AD04F11FCAB43D0");

            entity.ToTable("AdministrativeEmployees", "Administration");

            entity.HasIndex(e => e.UserId, "idx_AdminEmployees_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithOne(p => p.AdminProfile)
                .HasForeignKey<AdminProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminEmployees_User");
        });

        modelBuilder.Entity<Advisor>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ProfessorId }).HasName("PK__Advisors__BBC51E0DCD97A836");

            entity.ToTable("Advisors", "Students");

            entity.HasIndex(e => e.ProfessorId, "idx_Advisors_ProfessorId");

            entity.HasIndex(e => e.StudentId, "idx_Advisors_StudentId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Professor).WithMany(p => p.Advisors)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Advisors_Professor");

            entity.HasOne(d => d.Student).WithMany(p => p.Advisors)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Advisors_Student");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC0709E1F83F");

            entity.ToTable("Attendance", "Students");

            entity.HasIndex(e => e.EnrollmentId, "idx_Attendance_EnrollmentId");

            entity.HasIndex(e => e.StatusId, "idx_Attendance_StatusId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Enrollment");

            entity.HasOne(d => d.Status).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Status");
        });

        modelBuilder.Entity<AttendanceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC075ECE1106");

            entity.ToTable("AttendanceStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassSes__3214EC07AC2FF6BE");

            entity.ToTable("ClassSessions", "Academics");

            entity.HasIndex(e => new { e.OfferingId, e.SessionStart }, "IDX_ClassSessions_OfferingId_SessionStart");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Offering).WithMany(p => p.ClassSessions)
                .HasForeignKey(d => d.OfferingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassSessions_CourseOfferings");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classroo__3214EC074E426335");

            entity.ToTable("Classrooms", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07CFA3F6C6");

            entity.ToTable("Courses", "Academics");

            entity.HasIndex(e => e.DepartmentId, "idx_Courses_DepartmentId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Department");
        });

        modelBuilder.Entity<CourseOffering>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseOf__3214EC073F1823CA");

            entity.ToTable("CourseOfferings", "Academics");

            entity.HasIndex(e => e.ClassroomId, "idx_CourseOfferings_ClassroomId");

            entity.HasIndex(e => e.CourseId, "idx_CourseOfferings_CourseId");

            entity.HasIndex(e => e.ProfessorId, "idx_CourseOfferings_ProfessorId");

            entity.HasIndex(e => e.SemesterId, "idx_CourseOfferings_SemesterId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Classroom).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOfferings_Classroom");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOfferings_Course");

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOfferings_Professor");

            entity.HasOne(d => d.Semester).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOfferings_Semester");
        });

        modelBuilder.Entity<Dean>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.ProfessorId }).HasName("PK__Deans__3B07AE79CCBC4B69");

            entity.ToTable("Deans", "Administration");

            entity.HasIndex(e => e.DepartmentId, "idx_Deans_DepartmentId");

            entity.HasIndex(e => e.ProfessorId, "idx_Deans_ProfessorId");

            entity.HasOne(d => d.Department).WithMany(p => p.Deans)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deans_Department");

            entity.HasOne(d => d.Professor).WithMany(p => p.Deans)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deans_Professor");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07F032CAE9");

            entity.ToTable("Departments", "Administration");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC074F200B81");

            entity.ToTable("Enrollments", "Students");

            entity.HasIndex(e => e.OfferingId, "idx_Enrollments_OfferingId");

            entity.HasIndex(e => e.StudentId, "idx_Enrollments_StudentId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Offering).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.OfferingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_CourseOffering");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Student");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genders__3214EC07084817EC");

            entity.ToTable("Genders", "Administration");

            entity.HasIndex(e => e.Description, "UQ__Genders__4EBBBAC9AD1C6B32").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07F23C8620");

            entity.ToTable("Grades", "Students");

            entity.HasIndex(e => e.EnrollmentId, "idx_Grades_EnrollmentId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FinalGrade).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Enrollment");
        });

        modelBuilder.Entity<ProfessorProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC072A95EB5C");

            entity.ToTable("Professors", "Academics");

            entity.HasIndex(e => e.DepartmentId, "idx_Professors_DepartmentId");

            entity.HasIndex(e => e.UserId, "idx_Professors_UserId");

            entity.HasIndex(e => e.StatusId, "idx_Professors_StatusId");

            entity.HasIndex(e => e.TitleId, "idx_Professors_TitleId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Department).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Professors_Department");

            entity.HasOne(d => d.User).WithOne(p => p.ProfessorProfile)
                .HasForeignKey<ProfessorProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Professors_User");

            entity.HasOne(d => d.Status).WithMany(p => p.Professors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Professors_Status");

            entity.HasOne(d => d.Title).WithMany(p => p.Professors)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Professors_Title");
        });

        modelBuilder.Entity<ProfessorStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC07A8B1CF07");

            entity.ToTable("ProfessorStatuses", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC07E9C72386");

            entity.ToTable("Semesters", "Academics");

            entity.HasIndex(e => e.Name, "UQ__Semester__737584F69C3A9627").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0795BD6843");

            entity.ToTable("Students", "Students");

            entity.HasIndex(e => e.UserId, "idx_Students_UserId");

            entity.HasIndex(e => e.StatusId, "idx_Students_StatusId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithOne(p => p.StudentProfile)
                .HasForeignKey<StudentProfile>(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_User");

            entity.HasOne(d => d.Status).WithMany(p => p.Students)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Status");
        });

        modelBuilder.Entity<StudentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC07CA5A0DD8");

            entity.ToTable("StudentStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Titles__3214EC079638125A");

            entity.ToTable("Titles", "Academics");

            entity.HasIndex(e => e.TitleName, "UQ__Titles__252BE89C58ABA3ED").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
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

            entity.HasOne(e => e.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(e => e.UserId);

            entity.HasOne(e => e.Gender)
                .WithMany(g => g.Users)
                .HasForeignKey(e => e.GenderId);

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