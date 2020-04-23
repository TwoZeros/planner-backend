using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class fixskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_GroupSkills_GroupSkillId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "GroupSkillId",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_GroupSkills_GroupSkillId",
                table: "Skills",
                column: "GroupSkillId",
                principalTable: "GroupSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_GroupSkills_GroupSkillId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "GroupSkillId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_GroupSkills_GroupSkillId",
                table: "Skills",
                column: "GroupSkillId",
                principalTable: "GroupSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
