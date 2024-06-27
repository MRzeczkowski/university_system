using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class MovedGradesRelatedStuffToEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades",
                schema: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                schema: "Students",
                table: "Enrollments",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                schema: "Students",
                table: "Enrollments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Points",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EnrollmentDate",
                schema: "Students",
                table: "Enrollments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    FinalGrade = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GradeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalSchema: "Students",
                        principalTable: "Enrollments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EnrollmentId",
                schema: "Students",
                table: "Grades",
                column: "EnrollmentId");
        }
    }
}
