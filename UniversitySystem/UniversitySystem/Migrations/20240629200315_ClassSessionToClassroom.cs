using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class ClassSessionToClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Classrooms_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropIndex(
                name: "IX_CourseOfferings_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                schema: "Academics",
                table: "ClassSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_ClassroomId",
                schema: "Academics",
                table: "ClassSessions",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSessions_Classrooms_ClassroomId",
                schema: "Academics",
                table: "ClassSessions",
                column: "ClassroomId",
                principalSchema: "Academics",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSessions_Classrooms_ClassroomId",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropIndex(
                name: "IX_ClassSessions_ClassroomId",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                schema: "Academics",
                table: "ClassSessions");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Classrooms_ClassroomId",
                schema: "Academics",
                table: "CourseOfferings",
                column: "ClassroomId",
                principalSchema: "Academics",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }
    }
}
