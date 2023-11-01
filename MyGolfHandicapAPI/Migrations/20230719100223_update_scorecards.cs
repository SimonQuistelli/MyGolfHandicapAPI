using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGolfHandicapAPI.Migrations
{
    public partial class update_scorecards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GolfCourseId",
                table: "ScoreCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GolfCourseId",
                table: "ScoreCards");
        }
    }
}
