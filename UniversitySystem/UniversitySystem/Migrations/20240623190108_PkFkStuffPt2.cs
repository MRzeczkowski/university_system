using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class PkFkStuffPt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Temp1",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "Temp5",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "Temp2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "Temp4",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "Temp3",
                schema: "Students",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeEmployees_AspNetUsers_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Administration",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_AspNetUsers_UserId",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                schema: "Students",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeEmployees_AspNetUsers_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_AspNetUsers_UserId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                schema: "Students",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "Temp1",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Temp5",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp2",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Administration",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp4",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Temp3",
                schema: "Students",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
