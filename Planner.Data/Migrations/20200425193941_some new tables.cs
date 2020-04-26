using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class somenewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchCompanyId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BranchCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_BranchCompanys_BranchCompanyId",
                        column: x => x.BranchCompanyId,
                        principalTable: "BranchCompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LackOfEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LackOfEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LackOfEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LackTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Mounth = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    LackOfEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LackTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LackTimes_LackOfEmployees_LackOfEmployeeId",
                        column: x => x.LackOfEmployeeId,
                        principalTable: "LackOfEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartWith = table.Column<DateTime>(nullable: false),
                    SheduleId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShedules_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimeInChedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Mounth = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    SheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimeInChedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimeInChedules_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShedules_EmployeeId",
                table: "EmployeeShedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShedules_SheduleId",
                table: "EmployeeShedules",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_BranchCompanyId",
                table: "Holidays",
                column: "BranchCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LackOfEmployees_EmployeeId",
                table: "LackOfEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LackTimes_LackOfEmployeeId",
                table: "LackTimes",
                column: "LackOfEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeInChedules_SheduleId",
                table: "WorkTimeInChedules",
                column: "SheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId",
                principalTable: "BranchCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeShedules");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "LackTimes");

            migrationBuilder.DropTable(
                name: "WorkTimeInChedules");

            migrationBuilder.DropTable(
                name: "LackOfEmployees");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BranchCompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BranchCompanyId",
                table: "Employees");
        }
    }
}
