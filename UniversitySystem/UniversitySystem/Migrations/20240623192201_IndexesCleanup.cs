using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class IndexesCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_Students_UserId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "idx_Professors_UserId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "idx_AdminEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.RenameIndex(
                name: "UQ__Titles__252BE89C58ABA3ED",
                schema: "Academics",
                table: "Titles",
                newName: "IX_Titles_TitleName");

            migrationBuilder.RenameIndex(
                name: "idx_Students_StatusId",
                schema: "Students",
                table: "Students",
                newName: "IX_Students_StatusId");

            migrationBuilder.RenameIndex(
                name: "UQ__Semester__737584F69C3A9627",
                schema: "Academics",
                table: "Semesters",
                newName: "IX_Semesters_Name");

            migrationBuilder.RenameIndex(
                name: "idx_Professors_TitleId",
                schema: "Academics",
                table: "Professors",
                newName: "IX_Professors_TitleId");

            migrationBuilder.RenameIndex(
                name: "idx_Professors_StatusId",
                schema: "Academics",
                table: "Professors",
                newName: "IX_Professors_StatusId");

            migrationBuilder.RenameIndex(
                name: "idx_Professors_DepartmentId",
                schema: "Academics",
                table: "Professors",
                newName: "IX_Professors_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "idx_Grades_EnrollmentId",
                schema: "Students",
                table: "Grades",
                newName: "IX_Grades_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "UQ__Genders__4EBBBAC9AD1C6B32",
                schema: "Administration",
                table: "Genders",
                newName: "IX_Genders_Description");

            migrationBuilder.RenameIndex(
                name: "idx_Enrollments_StudentId",
                schema: "Students",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "idx_Enrollments_OfferingId",
                schema: "Students",
                table: "Enrollments",
                newName: "IX_Enrollments_OfferingId");

            migrationBuilder.RenameIndex(
                name: "idx_Deans_ProfessorId",
                schema: "Administration",
                table: "Deans",
                newName: "IX_Deans_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "idx_Deans_DepartmentId",
                schema: "Administration",
                table: "Deans",
                newName: "IX_Deans_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "idx_Courses_DepartmentId",
                schema: "Academics",
                table: "Courses",
                newName: "IX_Courses_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "idx_CourseOfferings_SemesterId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_SemesterId");

            migrationBuilder.RenameIndex(
                name: "idx_CourseOfferings_ProfessorId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "idx_CourseOfferings_CourseId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_CourseId");

            migrationBuilder.RenameIndex(
                name: "idx_CourseOfferings_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IDX_ClassSessions_OfferingId_SessionStart",
                schema: "Academics",
                table: "ClassSessions",
                newName: "IX_ClassSessions_OfferingId_SessionStart");

            migrationBuilder.RenameIndex(
                name: "idx_Attendance_StatusId",
                schema: "Students",
                table: "Attendance",
                newName: "IX_Attendance_StatusId");

            migrationBuilder.RenameIndex(
                name: "idx_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                newName: "IX_Attendance_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "idx_Advisors_StudentId",
                schema: "Students",
                table: "Advisors",
                newName: "IX_Advisors_StudentId");

            migrationBuilder.RenameIndex(
                name: "idx_Advisors_ProfessorId",
                schema: "Students",
                table: "Advisors",
                newName: "IX_Advisors_ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Titles_TitleName",
                schema: "Academics",
                table: "Titles",
                newName: "UQ__Titles__252BE89C58ABA3ED");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StatusId",
                schema: "Students",
                table: "Students",
                newName: "idx_Students_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_Name",
                schema: "Academics",
                table: "Semesters",
                newName: "UQ__Semester__737584F69C3A9627");

            migrationBuilder.RenameIndex(
                name: "IX_Professors_TitleId",
                schema: "Academics",
                table: "Professors",
                newName: "idx_Professors_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Professors_StatusId",
                schema: "Academics",
                table: "Professors",
                newName: "idx_Professors_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Professors_DepartmentId",
                schema: "Academics",
                table: "Professors",
                newName: "idx_Professors_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_EnrollmentId",
                schema: "Students",
                table: "Grades",
                newName: "idx_Grades_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Genders_Description",
                schema: "Administration",
                table: "Genders",
                newName: "UQ__Genders__4EBBBAC9AD1C6B32");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                schema: "Students",
                table: "Enrollments",
                newName: "idx_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_OfferingId",
                schema: "Students",
                table: "Enrollments",
                newName: "idx_Enrollments_OfferingId");

            migrationBuilder.RenameIndex(
                name: "IX_Deans_ProfessorId",
                schema: "Administration",
                table: "Deans",
                newName: "idx_Deans_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Deans_DepartmentId",
                schema: "Administration",
                table: "Deans",
                newName: "idx_Deans_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DepartmentId",
                schema: "Academics",
                table: "Courses",
                newName: "idx_Courses_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_SemesterId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "idx_CourseOfferings_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_ProfessorId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "idx_CourseOfferings_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_CourseId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "idx_CourseOfferings_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                newName: "idx_CourseOfferings_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSessions_OfferingId_SessionStart",
                schema: "Academics",
                table: "ClassSessions",
                newName: "IDX_ClassSessions_OfferingId_SessionStart");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StatusId",
                schema: "Students",
                table: "Attendance",
                newName: "idx_Attendance_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                newName: "idx_Attendance_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Advisors_StudentId",
                schema: "Students",
                table: "Advisors",
                newName: "idx_Advisors_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Advisors_ProfessorId",
                schema: "Students",
                table: "Advisors",
                newName: "idx_Advisors_ProfessorId");

            migrationBuilder.CreateIndex(
                name: "idx_Students_UserId",
                schema: "Students",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_Professors_UserId",
                schema: "Academics",
                table: "Professors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId");
        }
    }
}
