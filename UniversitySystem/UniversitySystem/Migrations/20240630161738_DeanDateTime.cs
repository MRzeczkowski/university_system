using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class DeanDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDate",
                schema: "Administration",
                table: "Deans",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "EffectiveDate",
                schema: "Administration",
                table: "Deans",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
