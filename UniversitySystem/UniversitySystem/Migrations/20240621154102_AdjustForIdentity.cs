using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class AdjustForIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Administration");

            migrationBuilder.EnsureSchema(
                name: "Students");

            migrationBuilder.EnsureSchema(
                name: "Academics");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Addresse__3214EC078ECCD8CD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceStatuses",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__3214EC075ECE1106", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoomNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classroo__3214EC074E426335", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__3214EC07F032CAE9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genders__3214EC07084817EC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorStatuses",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__3214EC07A8B1CF07", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Semester__3214EC07E9C72386", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatuses",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__3214EC07CA5A0DD8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TitleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Titles__3214EC079638125A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__3214EC07CFA3F6C6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "Administration",
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persons__3214EC07F320E7FC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Address",
                        column: x => x.AddressId,
                        principalSchema: "Administration",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Gender",
                        column: x => x.GenderId,
                        principalSchema: "Administration",
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeEmployees",
                schema: "Administration",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__7AD04F11FCAB43D0", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_AdminEmployees_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "Administration",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminEmployees_Person",
                        column: x => x.PersonId,
                        principalSchema: "Administration",
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__3214EC072A95EB5C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "Administration",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Professors_Person",
                        column: x => x.PersonId,
                        principalSchema: "Administration",
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Professors_Status",
                        column: x => x.StatusId,
                        principalSchema: "Academics",
                        principalTable: "ProfessorStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Professors_Title",
                        column: x => x.TitleId,
                        principalSchema: "Academics",
                        principalTable: "Titles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentYear = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__3214EC0795BD6843", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Person",
                        column: x => x.PersonId,
                        principalSchema: "Administration",
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Status",
                        column: x => x.StatusId,
                        principalSchema: "Students",
                        principalTable: "StudentStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseOf__3214EC073F1823CA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Classroom",
                        column: x => x.ClassroomId,
                        principalSchema: "Academics",
                        principalTable: "Classrooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Course",
                        column: x => x.CourseId,
                        principalSchema: "Academics",
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Professor",
                        column: x => x.ProfessorId,
                        principalSchema: "Academics",
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Semester",
                        column: x => x.SemesterId,
                        principalSchema: "Academics",
                        principalTable: "Semesters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deans",
                schema: "Administration",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Deans__3B07AE79CCBC4B69", x => new { x.DepartmentId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_Deans_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "Administration",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deans_Professor",
                        column: x => x.ProfessorId,
                        principalSchema: "Academics",
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Advisors",
                schema: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Advisors__BBC51E0DCD97A836", x => new { x.StudentId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_Advisors_Professor",
                        column: x => x.ProfessorId,
                        principalSchema: "Academics",
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advisors_Student",
                        column: x => x.StudentId,
                        principalSchema: "Students",
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassSessions",
                schema: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OfferingId = table.Column<int>(type: "int", nullable: false),
                    SessionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClassSes__3214EC07AC2FF6BE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSessions_CourseOfferings",
                        column: x => x.OfferingId,
                        principalSchema: "Academics",
                        principalTable: "CourseOfferings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OfferingId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__3214EC074F200B81", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_CourseOffering",
                        column: x => x.OfferingId,
                        principalSchema: "Academics",
                        principalTable: "CourseOfferings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_Student",
                        column: x => x.StudentId,
                        principalSchema: "Students",
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    DateOfClass = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__3214EC0709E1F83F", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Enrollment",
                        column: x => x.EnrollmentId,
                        principalSchema: "Students",
                        principalTable: "Enrollments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attendance_Status",
                        column: x => x.StatusId,
                        principalSchema: "Students",
                        principalTable: "AttendanceStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    FinalGrade = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GradeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grades__3214EC07F23C8620", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollment",
                        column: x => x.EnrollmentId,
                        principalSchema: "Students",
                        principalTable: "Enrollments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_DepartmentId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_PersonId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_Advisors_ProfessorId",
                schema: "Students",
                table: "Advisors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "idx_Advisors_StudentId",
                schema: "Students",
                table: "Advisors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "idx_Attendance_StatusId",
                schema: "Students",
                table: "Attendance",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IDX_ClassSessions_OfferingId_SessionStart",
                schema: "Academics",
                table: "ClassSessions",
                columns: new[] { "OfferingId", "SessionStart" });

            migrationBuilder.CreateIndex(
                name: "idx_CourseOfferings_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "idx_CourseOfferings_CourseId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "idx_CourseOfferings_ProfessorId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "idx_CourseOfferings_SemesterId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "idx_Courses_DepartmentId",
                schema: "Academics",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_Deans_DepartmentId",
                schema: "Administration",
                table: "Deans",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_Deans_ProfessorId",
                schema: "Administration",
                table: "Deans",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "idx_Enrollments_OfferingId",
                schema: "Students",
                table: "Enrollments",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "idx_Enrollments_StudentId",
                schema: "Students",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "UQ__Genders__4EBBBAC9AD1C6B32",
                schema: "Administration",
                table: "Genders",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_Grades_EnrollmentId",
                schema: "Students",
                table: "Grades",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "idx_Persons_AddressId",
                schema: "Administration",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "idx_Persons_GenderId",
                schema: "Administration",
                table: "Persons",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UQ__Persons__5C7E359ED5D78A15",
                schema: "Administration",
                table: "Persons",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Persons__A9D10534C66CDE75",
                schema: "Administration",
                table: "Persons",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_Professors_DepartmentId",
                schema: "Academics",
                table: "Professors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_Professors_PersonId",
                schema: "Academics",
                table: "Professors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_Professors_StatusId",
                schema: "Academics",
                table: "Professors",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "idx_Professors_TitleId",
                schema: "Academics",
                table: "Professors",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "UQ__Semester__737584F69C3A9627",
                schema: "Academics",
                table: "Semesters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_Students_PersonId",
                schema: "Students",
                table: "Students",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_Students_StatusId",
                schema: "Students",
                table: "Students",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "UQ__Titles__252BE89C58ABA3ED",
                schema: "Academics",
                table: "Titles",
                column: "TitleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrativeEmployees",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Advisors",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "ClassSessions",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Deans",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AttendanceStatuses",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "CourseOfferings",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Professors",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Semesters",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "StudentStatuses",
                schema: "Students");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "ProfessorStatuses",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Titles",
                schema: "Academics");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Administration");
        }
    }
}
