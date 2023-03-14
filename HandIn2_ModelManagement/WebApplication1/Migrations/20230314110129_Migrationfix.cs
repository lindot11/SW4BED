using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelManagement.Migrations
{
    public partial class Migrationfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Job_JobId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Models_ModelId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModel_Job_JobsJobId",
                table: "JobModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ModelId",
                table: "Expenses",
                newName: "IX_Expenses_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_JobId",
                table: "Expenses",
                newName: "IX_Expenses_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Jobs_JobId",
                table: "Expenses",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Models_ModelId",
                table: "Expenses",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobModel_Jobs_JobsJobId",
                table: "JobModel",
                column: "JobsJobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Jobs_JobId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Models_ModelId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModel_Jobs_JobsJobId",
                table: "JobModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ModelId",
                table: "Expense",
                newName: "IX_Expense_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_JobId",
                table: "Expense",
                newName: "IX_Expense_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Job_JobId",
                table: "Expense",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Models_ModelId",
                table: "Expense",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobModel_Job_JobsJobId",
                table: "JobModel",
                column: "JobsJobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
