using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class slkillsforworkandwor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    DeadlineTime = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    PreviosWorkId = table.Column<int>(nullable: false),
                    NextWorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectWorks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillForProjectWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(nullable: false),
                    ProjectWorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillForProjectWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillForProjectWorks_ProjectWorks_ProjectWorkId",
                        column: x => x.ProjectWorkId,
                        principalTable: "ProjectWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillForProjectWorks_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorks_ProjectId",
                table: "ProjectWorks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillForProjectWorks_ProjectWorkId",
                table: "SkillForProjectWorks",
                column: "ProjectWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillForProjectWorks_SkillId",
                table: "SkillForProjectWorks",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillForProjectWorks");

            migrationBuilder.DropTable(
                name: "ProjectWorks");
        }
    }
}
