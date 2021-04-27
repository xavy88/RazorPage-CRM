using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DataAccess.Migrations
{
    public partial class AddTaskAssignmentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskAssignment_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_AccountId",
                table: "TaskAssignment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_DepartmentId",
                table: "TaskAssignment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_EmployeeId",
                table: "TaskAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_TaskId",
                table: "TaskAssignment",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskAssignment");
        }
    }
}
