using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGolfHandicapAPI.Migrations
{
    public partial class update_scorecard_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "ScoreCards",
                newName: "SlopeRating");

            migrationBuilder.AddColumn<decimal>(
                name: "CourseRating",
                table: "ScoreCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GrossScore",
                table: "ScoreCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "HandicapIndex",
                table: "ScoreCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ScoreDiff",
                table: "ScoreCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseRating",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "GrossScore",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "HandicapIndex",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "ScoreDiff",
                table: "ScoreCards");

            migrationBuilder.RenameColumn(
                name: "SlopeRating",
                table: "ScoreCards",
                newName: "Total");
        }
    }
}
