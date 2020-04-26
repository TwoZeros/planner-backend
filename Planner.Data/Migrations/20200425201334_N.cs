using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "BranchCompanyId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId",
                principalTable: "BranchCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "BranchCompanyId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BranchCompanys_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId",
                principalTable: "BranchCompanys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
