using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPilkarza.Migrations
{
    public partial class FixRelationshipForPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Nationalities_NationalityId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Referees_Nationalities_NationalityId",
                table: "Referees");

            migrationBuilder.DropForeignKey(
                name: "FK_Stadium_Nationalities_NationalityId",
                table: "Stadium");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Stadium_NationalityId",
                table: "Stadium");

            migrationBuilder.DropIndex(
                name: "IX_Referees_NationalityId",
                table: "Referees");

            migrationBuilder.DropIndex(
                name: "IX_Players_NationalityId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PositionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_NationalityId",
                table: "Leagues");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Stadium_NationalityId",
                table: "Stadium",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Referees_NationalityId",
                table: "Referees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NationalityId",
                table: "Players",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_NationalityId",
                table: "Leagues",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Nationalities_NationalityId",
                table: "Managers",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referees_Nationalities_NationalityId",
                table: "Referees",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stadium_Nationalities_NationalityId",
                table: "Stadium",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Nationalities_NationalityId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Referees_Nationalities_NationalityId",
                table: "Referees");

            migrationBuilder.DropForeignKey(
                name: "FK_Stadium_Nationalities_NationalityId",
                table: "Stadium");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Stadium_NationalityId",
                table: "Stadium");

            migrationBuilder.DropIndex(
                name: "IX_Referees_NationalityId",
                table: "Referees");

            migrationBuilder.DropIndex(
                name: "IX_Players_NationalityId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PositionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_NationalityId",
                table: "Leagues");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stadium_NationalityId",
                table: "Stadium",
                column: "NationalityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referees_NationalityId",
                table: "Referees",
                column: "NationalityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_NationalityId",
                table: "Players",
                column: "NationalityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_NationalityId",
                table: "Leagues",
                column: "NationalityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Nationalities_NationalityId",
                table: "Managers",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referees_Nationalities_NationalityId",
                table: "Referees",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stadium_Nationalities_NationalityId",
                table: "Stadium",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
