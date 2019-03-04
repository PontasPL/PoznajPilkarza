using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPilkarza.Migrations
{
    public partial class AddedMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    RefereeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 80, nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    PngImage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    WikiLink = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.RefereeId);
                    table.ForeignKey(
                        name: "FK_Referees_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchesDetails",
                columns: table => new
                {
                    MatchDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attendance = table.Column<int>(nullable: false),
                    RefereeId = table.Column<int>(nullable: false),
                    HomeTeamShots = table.Column<int>(nullable: false),
                    AwayTeamShots = table.Column<int>(nullable: false),
                    HomeTeamShotsOnTarget = table.Column<int>(nullable: false),
                    AwayTeamShotsOnTarget = table.Column<int>(nullable: false),
                    HomeTeamWoodWork = table.Column<int>(nullable: false),
                    AwayTeamWoodWork = table.Column<int>(nullable: false),
                    HomeTeamCorners = table.Column<int>(nullable: false),
                    AwayTeamCorners = table.Column<int>(nullable: false),
                    HomeTeamFoulsCommitted = table.Column<int>(nullable: false),
                    AwayTeamFoulsCommitted = table.Column<int>(nullable: false),
                    HomeTeamOffsides = table.Column<int>(nullable: false),
                    AwayTeamOffsides = table.Column<int>(nullable: false),
                    HomeYellowCards = table.Column<int>(nullable: false),
                    AwayYellowCards = table.Column<int>(nullable: false),
                    HomeTeamRedCards = table.Column<int>(nullable: false),
                    AwayTeamRedCards = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesDetails", x => x.MatchDetailsId);
                    table.ForeignKey(
                        name: "FK_MatchesDetails_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "RefereeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueId = table.Column<int>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    MatchDay = table.Column<DateTime>(nullable: false),
                    FTHomeGoals = table.Column<int>(nullable: false),
                    FTAwayGoals = table.Column<int>(nullable: false),
                    HTHomeGoals = table.Column<int>(nullable: false),
                    HTAwayGoals = table.Column<int>(nullable: false),
                    MatchDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_MatchesDetails_MatchDetailsId",
                        column: x => x.MatchDetailsId,
                        principalTable: "MatchesDetails",
                        principalColumn: "MatchDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LeagueId",
                table: "Matches",
                column: "LeagueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDetailsId",
                table: "Matches",
                column: "MatchDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchesDetails_RefereeId",
                table: "MatchesDetails",
                column: "RefereeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referees_NationalityId",
                table: "Referees",
                column: "NationalityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchesDetails");

            migrationBuilder.DropTable(
                name: "Referees");
        }
    }
}
