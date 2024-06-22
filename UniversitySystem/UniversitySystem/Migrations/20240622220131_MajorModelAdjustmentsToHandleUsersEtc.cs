using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySystem.Migrations
{
    /// <inheritdoc />
    public partial class MajorModelAdjustmentsToHandleUsersEtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployees_Department",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployees_Person",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Persons_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Person",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Person",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "Administration");

            migrationBuilder.DropIndex(
                name: "idx_Students_PersonId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "idx_Professors_PersonId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropIndex(
                name: "idx_AdminEmployees_DepartmentId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropIndex(
                name: "idx_AdminEmployees_PersonId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                newName: "Id");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Students",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Academics",
                table: "Professors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Administration",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_Students_UserId",
                schema: "Students",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "Students",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_Professors_UserId",
                schema: "Academics",
                table: "Professors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserId",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                schema: "Administration",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployees_User",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_User",
                schema: "Academics",
                table: "Professors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User",
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
                name: "FK_AdminEmployees_User",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_User",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_User",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "idx_Students_UserId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "idx_Professors_UserId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Professors_UserId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropIndex(
                name: "idx_AdminEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropIndex(
                name: "IX_AdministrativeEmployees_UserId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Academics",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Administration",
                table: "AdministrativeEmployees");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Administration",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Administration",
                table: "AdministrativeEmployees",
                newName: "PersonId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "Students",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "Academics",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Administ__7AD04F11FCAB43D0",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persons__3214EC07F320E7FC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Address",
                        column: x => x.AddressId,
                        principalSchema: "Administration",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Gender",
                        column: x => x.GenderId,
                        principalSchema: "Administration",
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_Students_PersonId",
                schema: "Students",
                table: "Students",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_Professors_PersonId",
                schema: "Academics",
                table: "Professors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_DepartmentId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_AdminEmployees_PersonId",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "idx_Persons_AddressId",
                schema: "Administration",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "idx_Persons_GenderId",
                schema: "Administration",
                table: "Persons",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployees_Department",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "DepartmentId",
                principalSchema: "Administration",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployees_Person",
                schema: "Administration",
                table: "AdministrativeEmployees",
                column: "PersonId",
                principalSchema: "Administration",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Persons_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalSchema: "Administration",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Person",
                schema: "Academics",
                table: "Professors",
                column: "PersonId",
                principalSchema: "Administration",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Person",
                schema: "Students",
                table: "Students",
                column: "PersonId",
                principalSchema: "Administration",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
