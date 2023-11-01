using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGolfHandicapAPI.Migrations
{
    public partial class update_score_differentials_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreCardId",
                table: "ScoreDifferentials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreCardId",
                table: "ScoreDifferentials");
        }
    }
}
