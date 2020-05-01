using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class fixkatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeOnWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactStart = table.Column<DateTime>(nullable: false),
                    FactEnd = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOnWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeOnWorks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeOnWorks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnWorks_EmployeeId",
                table: "EmployeeOnWorks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnWorks_ProjectId",
                table: "EmployeeOnWorks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOnWorks");
        }
    }
}
