using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceToEnrolment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                schema: "Students",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                schema: "Students",
                table: "Attendance");
        }
    }
}
