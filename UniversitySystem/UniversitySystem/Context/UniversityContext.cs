using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;

namespace UniversitySystem.Context;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdministrativeEmployee> AdministrativeEmployees { get; set; }

    public virtual DbSet<Advisor> Advisors { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AttendanceStatus> AttendanceStatuses { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseOffering> CourseOfferings { get; set; }

    public virtual DbSet<Dean> Deans { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<ProfessorStatus> ProfessorStatuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentStatus> StudentStatuses { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=University;User Id=sa;Password=Passw@rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdministrativeEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Administ__7AD04F11EFE0C0DB");

            entity.ToTable("AdministrativeEmployees", "Administration");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.AdministrativeEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_AdminEmployees_Department");

            entity.HasOne(d => d.Person).WithMany(p => p.AdministrativeEmployees)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_AdminEmployees_Person");
        });

        modelBuilder.Entity<Advisor>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ProfessorId }).HasName("PK__Advisors__BBC51E0DE1D9B987");

            entity.ToTable("Advisors", "Students");

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
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC073EA82BF8");

            entity.ToTable("Attendance", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Attendance_Enrollment");

            entity.HasOne(d => d.Status).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Attendance_Status");
        });

        modelBuilder.Entity<AttendanceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC070E2F7D03");

            entity.ToTable("AttendanceStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classroo__3214EC07CC2DED5D");

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
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07EB3F4D41");

            entity.ToTable("Courses", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Courses_Department");
        });

        modelBuilder.Entity<CourseOffering>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseOf__3214EC074EB02E2E");

            entity.ToTable("CourseOfferings", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Semester)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Classroom).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_CourseOfferings_Classroom");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CourseOfferings_Course");

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseOfferings)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK_CourseOfferings_Professor");
        });

        modelBuilder.Entity<Dean>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.ProfessorId }).HasName("PK__Deans__3B07AE791CE64B13");

            entity.ToTable("Deans", "Administration");

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
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC074902B404");

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
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC072F769DC4");

            entity.ToTable("Enrollments", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Offering).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.OfferingId)
                .HasConstraintName("FK_Enrollments_CourseOffering");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Enrollments_Student");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genders__3214EC07826F66DE");

            entity.ToTable("Genders", "Administration");

            entity.HasIndex(e => e.Description, "UQ__Genders__4EBBBAC999BF9660").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07CA447891");

            entity.ToTable("Grades", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Grade1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Grade");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Grades_Enrollment");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC0741E09135");

            entity.ToTable("Persons", "Administration");

            entity.HasIndex(e => e.Phone, "UQ__Persons__5C7E359E40B56694").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Persons__A9D105340C41CA65").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Gender).WithMany(p => p.People)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Persons_Gender");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC07A34B36BD");

            entity.ToTable("Professors", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Department).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Professors_Department");

            entity.HasOne(d => d.Person).WithMany(p => p.Professors)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Professors_Person");

            entity.HasOne(d => d.Status).WithMany(p => p.Professors)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Professors_Status");

            entity.HasOne(d => d.Title).WithMany(p => p.Professors)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_Professors_Title");
        });

        modelBuilder.Entity<ProfessorStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC07F98A7FA3");

            entity.ToTable("ProfessorStatuses", "Academics");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07E422CEF3");

            entity.ToTable("Students", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Students_Person");

            entity.HasOne(d => d.Status).WithMany(p => p.Students)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Students_Status");
        });

        modelBuilder.Entity<StudentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC073363ACAC");

            entity.ToTable("StudentStatuses", "Students");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Titles__3214EC0798DDDB47");

            entity.ToTable("Titles", "Academics");

            entity.HasIndex(e => e.TitleName, "UQ__Titles__252BE89CCB2501EF").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TitleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
