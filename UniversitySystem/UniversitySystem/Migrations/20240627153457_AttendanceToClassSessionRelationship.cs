using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceToClassSessionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Enrollments_EnrollmentId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "DateOfClass",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                schema: "Students",
                table: "Attendance",
                newName: "ClassSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_EnrollmentId",
                schema: "Students",
                table: "Attendance",
                newName: "IX_Attendance_ClassSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance",
                column: "ClassSessionId",
                principalSchema: "Academics",
                principalTable: "ClassSessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ClassSessions_ClassSessionId",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "ClassSessionId",
                schema: "Students",
                table: "Attendance",
                newName: "EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ClassSessionId",
                schema: "Students",
                table: "Attendance",
                newName: "IX_Attendance_EnrollmentId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfClass",
                schema: "Students",
                table: "Attendance",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

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
