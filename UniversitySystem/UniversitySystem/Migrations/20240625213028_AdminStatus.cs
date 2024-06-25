using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class AdminStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdministrativeEmployeeStatuses",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeEmployeeStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeEmployees_StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeEmployees_AdministrativeEmployeeStatuses_StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "StatusId",
                principalSchema: "Administration",
                principalTable: "AdministrativeEmployeeStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeEmployees_AdministrativeEmployeeStatuses_StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropTable(
                name: "AdministrativeEmployeeStatuses",
                schema: "Administration");

            migrationBuilder.DropIndex(
                name: "IX_AdministrativeEmployees_StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "Administration",
                table: "AdministrativeEmployees");
        }
    }
}
