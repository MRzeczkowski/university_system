using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class ClassSessionAttendanceCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance",
                column: "ClassSessionId",
                principalSchema: "Academics",
                principalTable: "ClassSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance",
                column: "ClassSessionId",
                principalSchema: "Academics",
                principalTable: "ClassSessions",
                principalColumn: "Id");
        }
    }
}
