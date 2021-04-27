using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DataAccess.Migrations
{
    public partial class changingEmployeeToUserInTaskAssigment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignment_Employee_EmployeeId",
                table: "TaskAssignment");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssignment_EmployeeId",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TaskAssignment");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TaskAssignment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_ApplicationUserId",
                table: "TaskAssignment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignment_AspNetUsers_ApplicationUserId",
                table: "TaskAssignment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignment_AspNetUsers_ApplicationUserId",
                table: "TaskAssignment");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssignment_ApplicationUserId",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TaskAssignment");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TaskAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_EmployeeId",
                table: "TaskAssignment",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignment_Employee_EmployeeId",
                table: "TaskAssignment",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
