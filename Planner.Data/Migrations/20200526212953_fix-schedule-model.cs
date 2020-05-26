using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class fixschedulemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Friday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Monday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Saturday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sunday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Thursday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tuesday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wednesday",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Shedules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Friday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                table: "Shedules");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Shedules");
        }
    }
}
