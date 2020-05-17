using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class eww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextWorkId",
                table: "ProjectWorks");

            migrationBuilder.DropColumn(
                name: "PreviosWorkId",
                table: "ProjectWorks");

            migrationBuilder.DropColumn(
                name: "StartWith",
                table: "EmployeeShedules");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ProjectWorks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectWorkSheduleId",
                table: "ProjectWorks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkTimeInSheduleId",
                table: "ProjectWorks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectWorkShedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(nullable: false),
                    CountHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkShedules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorks_EmployeeId",
                table: "ProjectWorks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorks_ProjectWorkSheduleId",
                table: "ProjectWorks",
                column: "ProjectWorkSheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorks_WorkTimeInSheduleId",
                table: "ProjectWorks",
                column: "WorkTimeInSheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorks_Employees_EmployeeId",
                table: "ProjectWorks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorks_ProjectWorkShedules_ProjectWorkSheduleId",
                table: "ProjectWorks",
                column: "ProjectWorkSheduleId",
                principalTable: "ProjectWorkShedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorks_WorkTimeInChedules_WorkTimeInSheduleId",
                table: "ProjectWorks",
                column: "WorkTimeInSheduleId",
                principalTable: "WorkTimeInChedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorks_Employees_EmployeeId",
                table: "ProjectWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorks_ProjectWorkShedules_ProjectWorkSheduleId",
                table: "ProjectWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorks_WorkTimeInChedules_WorkTimeInSheduleId",
                table: "ProjectWorks");

            migrationBuilder.DropTable(
                name: "ProjectWorkShedules");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorks_EmployeeId",
                table: "ProjectWorks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorks_ProjectWorkSheduleId",
                table: "ProjectWorks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorks_WorkTimeInSheduleId",
                table: "ProjectWorks");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProjectWorks");

            migrationBuilder.DropColumn(
                name: "ProjectWorkSheduleId",
                table: "ProjectWorks");

            migrationBuilder.DropColumn(
                name: "WorkTimeInSheduleId",
                table: "ProjectWorks");

            migrationBuilder.AddColumn<int>(
                name: "NextWorkId",
                table: "ProjectWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviosWorkId",
                table: "ProjectWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartWith",
                table: "EmployeeShedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
