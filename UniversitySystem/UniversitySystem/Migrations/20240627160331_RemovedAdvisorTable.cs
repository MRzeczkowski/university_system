using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAdvisorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisors",
                schema: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                schema: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => new { x.StudentId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_Advisors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "Academics",
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advisors_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Students",
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_ProfessorId",
                schema: "Students",
                table: "Advisors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_StudentId",
                schema: "Students",
                table: "Advisors",
                column: "StudentId");
        }
    }
}
