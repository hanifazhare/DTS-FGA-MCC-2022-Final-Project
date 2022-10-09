using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagementWebAPI.Migrations
{
    public partial class CreateManagerIdInEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "managerId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_managerId",
                table: "Employees",
                column: "managerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_managerId",
                table: "Employees",
                column: "managerId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_managerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_managerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "managerId",
                table: "Employees");
        }
    }
}
