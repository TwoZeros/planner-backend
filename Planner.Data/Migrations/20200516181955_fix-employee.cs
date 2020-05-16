using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class fixemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BranchCompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BranchCompanyId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BranchCompanys_DepartamentId",
                table: "Employees",
                column: "DepartamentId",
                principalTable: "BranchCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BranchCompanys_DepartamentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "BranchCompanyId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId",
                principalTable: "BranchCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
