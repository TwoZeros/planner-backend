using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchCompanys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchCompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarmaUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BeginCarma = table.Column<int>(nullable: false),
                    EndCarma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarmaUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 256, nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Severity = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 1024, nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsAllowedDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ContryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 256, nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Login", x => x.Login);
                });

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
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupSkillId = table.Column<int>(nullable: false),
                    KnowledgeLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_GroupSkills_GroupSkillId",
                        column: x => x.GroupSkillId,
                        principalTable: "GroupSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_KnowledgeLevel_KnowledgeLevelId",
                        column: x => x.KnowledgeLevelId,
                        principalTable: "KnowledgeLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimeInChedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    isHoliday = table.Column<bool>(nullable: false),
                    HolidayName = table.Column<string>(nullable: true),
                    CountHours = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Karma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    SecondName = table.Column<string>(maxLength: 256, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 256, nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    BranchCompanyId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_BranchCompanys_BranchCompanyId",
                        column: x => x.BranchCompanyId,
                        principalTable: "BranchCompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    StatusOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    KnowledgeLevelId = table.Column<int>(nullable: false),
                    DateOfAppointment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_KnowledgeLevel_KnowledgeLevelId",
                        column: x => x.KnowledgeLevelId,
                        principalTable: "KnowledgeLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectManagerId = table.Column<int>(nullable: false),
                    TotalHour = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LackTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "KnowledgeLevel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Middle" },
                    { 3, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "IsAllowedDelete", "Name" },
                values: new object[,]
                {
                    { 1, false, "Директор" },
                    { 2, false, "Менеджер" },
                    { 3, false, "Курьер" },
                    { 4, false, "Повар" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "Admin", "12345678", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClientId",
                table: "Comments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnWorks_EmployeeId",
                table: "EmployeeOnWorks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnWorks_ProjectId",
                table: "EmployeeOnWorks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchCompanyId",
                table: "Employees",
                column: "BranchCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShedules_EmployeeId",
                table: "EmployeeShedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShedules_SheduleId",
                table: "EmployeeShedules",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_KnowledgeLevelId",
                table: "EmployeeSkills",
                column: "KnowledgeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                table: "EmployeeSkills",
                column: "SkillId");

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
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOrders_OrderId",
                table: "ProductInOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOrders_ProductId",
                table: "ProductInOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Skills_GroupSkillId",
                table: "Skills",
                column: "GroupSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_KnowledgeLevelId",
                table: "Skills",
                column: "KnowledgeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeInChedules_SheduleId",
                table: "WorkTimeInChedules",
                column: "SheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarmaUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "EmployeeOnWorks");

            migrationBuilder.DropTable(
                name: "EmployeeShedules");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "LackTimes");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ProductInOrders");

            migrationBuilder.DropTable(
                name: "SkillForProjectWorks");

            migrationBuilder.DropTable(
                name: "WorkTimeInChedules");

            migrationBuilder.DropTable(
                name: "LackOfEmployees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProjectWorks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "GroupSkills");

            migrationBuilder.DropTable(
                name: "KnowledgeLevel");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "BranchCompanys");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
