using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentAttendanceCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                column: "EnrollmentId",
                principalSchema: "Students",
                principalTable: "Enrollments",
                principalColumn: "Id");
        }
    }
}
