using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGolfHandicapAPI.Migrations
{
    public partial class delete_table_scoredifferential : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDifferentials_Users_UserId",
                table: "ScoreDifferentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDifferentials",
                table: "ScoreDifferentials");

            migrationBuilder.RenameTable(
                name: "ScoreDifferentials",
                newName: "ScoreDifferential");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreDifferentials_UserId",
                table: "ScoreDifferential",
                newName: "IX_ScoreDifferential_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "ScoreDiff",
                table: "ScoreDifferential",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDifferential",
                table: "ScoreDifferential",
                column: "ScoreDifferentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDifferential_Users_UserId",
                table: "ScoreDifferential",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDifferential_Users_UserId",
                table: "ScoreDifferential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDifferential",
                table: "ScoreDifferential");

            migrationBuilder.DropColumn(
                name: "ScoreDiff",
                table: "ScoreDifferential");

            migrationBuilder.RenameTable(
                name: "ScoreDifferential",
                newName: "ScoreDifferentials");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreDifferential_UserId",
                table: "ScoreDifferentials",
                newName: "IX_ScoreDifferentials_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDifferentials",
                table: "ScoreDifferentials",
                column: "ScoreDifferentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDifferentials_Users_UserId",
                table: "ScoreDifferentials",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
