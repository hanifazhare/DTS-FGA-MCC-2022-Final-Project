using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagementWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveStatusTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveStatusTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    lastName = table.Column<string>(type: "varchar(255)", nullable: true),
                    genderTypeId = table.Column<int>(nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    departmentTypeId = table.Column<int>(nullable: false),
                    managerId = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_DepartmentTypes_departmentTypeId",
                        column: x => x.departmentTypeId,
                        principalTable: "DepartmentTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_GenderTypes_genderTypeId",
                        column: x => x.genderTypeId,
                        principalTable: "GenderTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_managerId",
                        column: x => x.managerId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    userRoleTypeId = table.Column<int>(nullable: false, defaultValue: 2),
                    availableLeaves = table.Column<int>(nullable: false, defaultValue: 12),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    registeredAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_id",
                        column: x => x.id,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoleTypes_userRoleTypeId",
                        column: x => x.userRoleTypeId,
                        principalTable: "UserRoleTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leaveTypeId = table.Column<int>(nullable: false),
                    leaveStatusTypeId = table.Column<int>(nullable: false, defaultValue: 1),
                    userId = table.Column<int>(nullable: false),
                    requestedDays = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveStatusTypes_leaveStatusTypeId",
                        column: x => x.leaveStatusTypeId,
                        principalTable: "LeaveStatusTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_leaveTypeId",
                        column: x => x.leaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentTypeId",
                table: "Employees",
                column: "departmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_genderTypeId",
                table: "Employees",
                column: "genderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_managerId",
                table: "Employees",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_email_phoneNumber",
                table: "Employees",
                columns: new[] { "email", "phoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_leaveStatusTypeId",
                table: "LeaveRequests",
                column: "leaveStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_leaveTypeId",
                table: "LeaveRequests",
                column: "leaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_userId",
                table: "LeaveRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userRoleTypeId",
                table: "Users",
                column: "userRoleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeaveStatusTypes");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserRoleTypes");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropTable(
                name: "GenderTypes");
        }
    }
}
