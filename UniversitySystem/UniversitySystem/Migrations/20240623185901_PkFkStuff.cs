using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class PkFkStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployees_User",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Professor",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Student",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollment",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Status",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSessions_CourseOfferings",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Classroom",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Course",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Professor",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Semester",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Deans_Department",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropForeignKey(
                name: "FK_Deans_Professor",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_CourseOffering",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Student",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Enrollment",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Department",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Status",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Title",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_User",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Status",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_User",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Titles__3214EC079638125A",
                schema: "Academics",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StudentS__3214EC07CA5A0DD8",
                schema: "Students",
                table: "StudentStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Students__3214EC0795BD6843",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Semester__3214EC07E9C72386",
                schema: "Academics",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Professo__3214EC07A8B1CF07",
                schema: "Academics",
                table: "ProfessorStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Professo__3214EC072A95EB5C",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Grades__3214EC07F23C8620",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Genders__3214EC07084817EC",
                schema: "Administration",
                table: "Genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Enrollme__3214EC074F200B81",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Departme__3214EC07F032CAE9",
                schema: "Administration",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Deans__3B07AE79CCBC4B69",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Courses__3214EC07CFA3F6C6",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CourseOf__3214EC073F1823CA",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ClassSes__3214EC07AC2FF6BE",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Classroo__3214EC074E426335",
                schema: "Academics",
                table: "Classrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Attendan__3214EC075ECE1106",
                schema: "Students",
                table: "AttendanceStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Attendan__3214EC0709E1F83F",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Advisors__BBC51E0DCD97A836",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Addresse__3214EC078ECCD8CD",
                schema: "Administration",
                table: "Addresses");

            HandleIdentityColumnMigration(migrationBuilder, "Academics", "Titles");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "StudentStatuses");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "Students");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "Semesters");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "ProfessorStatuses");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "Professors");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "Grades");
            HandleIdentityColumnMigration(migrationBuilder, "Administration", "Genders");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "Enrollments");
            HandleIdentityColumnMigration(migrationBuilder, "Administration", "Departments");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "Courses");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "CourseOfferings");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "ClassSessions");
            HandleIdentityColumnMigration(migrationBuilder, "Academics", "Classrooms");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "AttendanceStatuses");
            HandleIdentityColumnMigration(migrationBuilder, "Students", "Attendance");
            HandleIdentityColumnMigration(migrationBuilder, "Administration", "AdministrativeEmployees");
            HandleIdentityColumnMigration(migrationBuilder, "Administration", "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Titles",
                schema: "Academics",
                table: "Titles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentStatuses",
                schema: "Students",
                table: "StudentStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                schema: "Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                schema: "Academics",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorStatuses",
                schema: "Academics",
                table: "ProfessorStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professors",
                schema: "Academics",
                table: "Professors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                schema: "Students",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                schema: "Administration",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                schema: "Students",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                schema: "Administration",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deans",
                schema: "Administration",
                table: "Deans",
                columns: new[] { "DepartmentId", "ProfessorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                schema: "Academics",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOfferings",
                schema: "Academics",
                table: "CourseOfferings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSessions",
                schema: "Academics",
                table: "ClassSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classrooms",
                schema: "Academics",
                table: "Classrooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceStatuses",
                schema: "Students",
                table: "AttendanceStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                schema: "Students",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advisors",
                schema: "Students",
                table: "Advisors",
                columns: new[] { "StudentId", "ProfessorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdministrativeEmployees",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                schema: "Administration",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp1",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Temp5",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Professors_ProfessorId",
                schema: "Students",
                table: "Advisors",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Students_StudentId",
                schema: "Students",
                table: "Advisors",
                column: "StudentId",
                principalSchema: "Students",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp2",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Administration",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AttendanceStatuses_StatusId",
                schema: "Students",
                table: "Attendance",
                column: "StatusId",
                principalSchema: "Students",
                principalTable: "AttendanceStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSessions_CourseOfferings_OfferingId",
                schema: "Academics",
                table: "ClassSessions",
                column: "OfferingId",
                principalSchema: "Academics",
                principalTable: "CourseOfferings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Classrooms_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ClassroomId",
                principalSchema: "Academics",
                principalTable: "Classrooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Courses_CourseId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "CourseId",
                principalSchema: "Academics",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Professors_ProfessorId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Semesters_SemesterId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "SemesterId",
                principalSchema: "Academics",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                schema: "Academics",
                table: "Courses",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deans_Departments_DepartmentId",
                schema: "Administration",
                table: "Deans",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deans_Professors_ProfessorId",
                schema: "Administration",
                table: "Deans",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_CourseOfferings_OfferingId",
                schema: "Students",
                table: "Enrollments",
                column: "OfferingId",
                principalSchema: "Academics",
                principalTable: "CourseOfferings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                schema: "Students",
                table: "Enrollments",
                column: "StudentId",
                principalSchema: "Students",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Grades",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Departments_DepartmentId",
                schema: "Academics",
                table: "Professors",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_ProfessorStatuses_StatusId",
                schema: "Academics",
                table: "Professors",
                column: "StatusId",
                principalSchema: "Academics",
                principalTable: "ProfessorStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Titles_TitleId",
                schema: "Academics",
                table: "Professors",
                column: "TitleId",
                principalSchema: "Academics",
                principalTable: "Titles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp4",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentStatuses_StatusId",
                schema: "Students",
                table: "Students",
                column: "StatusId",
                principalSchema: "Students",
                principalTable: "StudentStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp3",
                schema: "Students",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        private static void HandleIdentityColumnMigration(MigrationBuilder migrationBuilder, string schema, string table)
        {
            migrationBuilder.AddColumn<int>(
                    name: "TempId",
                    schema: schema,
                    table: table,
                    nullable: false,
                    defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: schema,
                table: table);

            migrationBuilder.RenameColumn(
                name: "TempId",
                schema: schema,
                table: table,
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Temp1",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "Temp5",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Professors_ProfessorId",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Students_StudentId",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "Temp2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AttendanceStatuses_StatusId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSessions_CourseOfferings_OfferingId",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Classrooms_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Courses_CourseId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Professors_ProfessorId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Semesters_SemesterId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Deans_Departments_DepartmentId",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropForeignKey(
                name: "FK_Deans_Professors_ProfessorId",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_CourseOfferings_OfferingId",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Departments_DepartmentId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_ProfessorStatuses_StatusId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Titles_TitleId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "Temp4",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentStatuses_StatusId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "Temp3",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Titles",
                schema: "Academics",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentStatuses",
                schema: "Students",
                table: "StudentStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                schema: "Academics",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorStatuses",
                schema: "Academics",
                table: "ProfessorStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professors",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                schema: "Administration",
                table: "Genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                schema: "Administration",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deans",
                schema: "Administration",
                table: "Deans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOfferings",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSessions",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classrooms",
                schema: "Academics",
                table: "Classrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceStatuses",
                schema: "Students",
                table: "AttendanceStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advisors",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdministrativeEmployees",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "Titles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "StudentStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "Semesters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "ProfessorStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "Professors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Administration",
                table: "Genders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "Enrollments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Administration",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "CourseOfferings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "ClassSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Academics",
                table: "Classrooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "AttendanceStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Students",
                table: "Attendance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Administration",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Titles__3214EC079638125A",
                schema: "Academics",
                table: "Titles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StudentS__3214EC07CA5A0DD8",
                schema: "Students",
                table: "StudentStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Students__3214EC0795BD6843",
                schema: "Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Semester__3214EC07E9C72386",
                schema: "Academics",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Professo__3214EC07A8B1CF07",
                schema: "Academics",
                table: "ProfessorStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Professo__3214EC072A95EB5C",
                schema: "Academics",
                table: "Professors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Grades__3214EC07F23C8620",
                schema: "Students",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Genders__3214EC07084817EC",
                schema: "Administration",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Enrollme__3214EC074F200B81",
                schema: "Students",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Departme__3214EC07F032CAE9",
                schema: "Administration",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Deans__3B07AE79CCBC4B69",
                schema: "Administration",
                table: "Deans",
                columns: new[] { "DepartmentId", "ProfessorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Courses__3214EC07CFA3F6C6",
                schema: "Academics",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CourseOf__3214EC073F1823CA",
                schema: "Academics",
                table: "CourseOfferings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ClassSes__3214EC07AC2FF6BE",
                schema: "Academics",
                table: "ClassSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Classroo__3214EC074E426335",
                schema: "Academics",
                table: "Classrooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Attendan__3214EC075ECE1106",
                schema: "Students",
                table: "AttendanceStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Attendan__3214EC0709E1F83F",
                schema: "Students",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Advisors__BBC51E0DCD97A836",
                schema: "Students",
                table: "Advisors",
                columns: new[] { "StudentId", "ProfessorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Addresse__3214EC078ECCD8CD",
                schema: "Administration",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployees_User",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Professor",
                schema: "Students",
                table: "Advisors",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Student",
                schema: "Students",
                table: "Advisors",
                column: "StudentId",
                principalSchema: "Students",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Administration",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Enrollment",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Status",
                schema: "Students",
                table: "Attendance",
                column: "StatusId",
                principalSchema: "Students",
                principalTable: "AttendanceStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSessions_CourseOfferings",
                schema: "Academics",
                table: "ClassSessions",
                column: "OfferingId",
                principalSchema: "Academics",
                principalTable: "CourseOfferings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Classroom",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ClassroomId",
                principalSchema: "Academics",
                principalTable: "Classrooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Course",
                schema: "Academics",
                table: "CourseOfferings",
                column: "CourseId",
                principalSchema: "Academics",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Professor",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Semester",
                schema: "Academics",
                table: "CourseOfferings",
                column: "SemesterId",
                principalSchema: "Academics",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department",
                schema: "Academics",
                table: "Courses",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deans_Department",
                schema: "Administration",
                table: "Deans",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deans_Professor",
                schema: "Administration",
                table: "Deans",
                column: "ProfessorId",
                principalSchema: "Academics",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_CourseOffering",
                schema: "Students",
                table: "Enrollments",
                column: "OfferingId",
                principalSchema: "Academics",
                principalTable: "CourseOfferings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Student",
                schema: "Students",
                table: "Enrollments",
                column: "StudentId",
                principalSchema: "Students",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Enrollment",
                schema: "Students",
                table: "Grades",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Department",
                schema: "Academics",
                table: "Professors",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Status",
                schema: "Academics",
                table: "Professors",
                column: "StatusId",
                principalSchema: "Academics",
                principalTable: "ProfessorStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Title",
                schema: "Academics",
                table: "Professors",
                column: "TitleId",
                principalSchema: "Academics",
                principalTable: "Titles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_User",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Status",
                schema: "Students",
                table: "Students",
                column: "StatusId",
                principalSchema: "Students",
                principalTable: "StudentStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User",
                schema: "Students",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
