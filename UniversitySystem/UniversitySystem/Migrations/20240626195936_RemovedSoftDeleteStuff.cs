using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSoftDeleteStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Students",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Students",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Administration",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Administration",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Academics",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Academics",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Academics",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Students",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Students",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "Administration",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Students",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Students",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Students",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Academics",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Academics",
                table: "Professors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Professors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Students",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Students",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Students",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Students",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Students",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Students",
                table: "Enrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Administration",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Administration",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Academics",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Academics",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Academics",
                table: "CourseOfferings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Academics",
                table: "CourseOfferings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Academics",
                table: "CourseOfferings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Academics",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Academics",
                table: "Classrooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Academics",
                table: "Classrooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Students",
                table: "Attendance",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Students",
                table: "Attendance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Students",
                table: "Attendance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Students",
                table: "Advisors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Students",
                table: "Advisors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Students",
                table: "Advisors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Administration",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "Administration",
                table: "Addresses",
                type: "datetime2",
                nullable: true);
        }
    }
}
