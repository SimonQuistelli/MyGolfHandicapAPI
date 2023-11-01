using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGolfHandicapAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GolfCourses",
                columns: table => new
                {
                    GolfCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfCourses", x => x.GolfCourseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tees",
                columns: table => new
                {
                    TeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GolfCourseId = table.Column<int>(type: "int", nullable: false),
                    TeeColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseRating18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SlopeRating18 = table.Column<int>(type: "int", nullable: false),
                    CourseRatingFront9 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SlopeRatingFront9 = table.Column<int>(type: "int", nullable: false),
                    CourseRatingBack9 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SlopeRatingBack9 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tees", x => x.TeeId);
                    table.ForeignKey(
                        name: "FK_Tees_GolfCourses_GolfCourseId",
                        column: x => x.GolfCourseId,
                        principalTable: "GolfCourses",
                        principalColumn: "GolfCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCards",
                columns: table => new
                {
                    ScoreCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeeColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCards", x => x.ScoreCardId);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreDifferentials",
                columns: table => new
                {
                    ScoreDifferentialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoundType = table.Column<int>(type: "int", nullable: false),
                    CourseRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SlopeRating = table.Column<int>(type: "int", nullable: false),
                    GrossAdjustedScore = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreDifferentials", x => x.ScoreDifferentialId);
                    table.ForeignKey(
                        name: "FK_ScoreDifferentials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    HoleInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeeId = table.Column<int>(type: "int", nullable: false),
                    HoleNumber = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    StrokeIndex = table.Column<int>(type: "int", nullable: false),
                    Yards = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.HoleInfoId);
                    table.ForeignKey(
                        name: "FK_Holes_Tees_TeeId",
                        column: x => x.TeeId,
                        principalTable: "Tees",
                        principalColumn: "TeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoleScores",
                columns: table => new
                {
                    HoleScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreCardId = table.Column<int>(type: "int", nullable: false),
                    HoleNumber = table.Column<int>(type: "int", nullable: false),
                    HolePar = table.Column<int>(type: "int", nullable: false),
                    StrokeIndex = table.Column<int>(type: "int", nullable: false),
                    Yards = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleScores", x => x.HoleScoreId);
                    table.ForeignKey(
                        name: "FK_HoleScores_ScoreCards_ScoreCardId",
                        column: x => x.ScoreCardId,
                        principalTable: "ScoreCards",
                        principalColumn: "ScoreCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holes_TeeId",
                table: "Holes",
                column: "TeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScores_ScoreCardId",
                table: "HoleScores",
                column: "ScoreCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_UserId",
                table: "ScoreCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreDifferentials_UserId",
                table: "ScoreDifferentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tees_GolfCourseId",
                table: "Tees",
                column: "GolfCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.DropTable(
                name: "HoleScores");

            migrationBuilder.DropTable(
                name: "ScoreDifferentials");

            migrationBuilder.DropTable(
                name: "Tees");

            migrationBuilder.DropTable(
                name: "ScoreCards");

            migrationBuilder.DropTable(
                name: "GolfCourses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
