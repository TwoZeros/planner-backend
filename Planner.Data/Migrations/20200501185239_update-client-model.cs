using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class updateclientmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Clients",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Clients",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Clients",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
