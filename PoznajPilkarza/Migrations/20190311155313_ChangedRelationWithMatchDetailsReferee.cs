using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPilkarza.Migrations
{
    public partial class ChangedRelationWithMatchDetailsReferee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MatchesDetails_RefereeId",
                table: "MatchesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesDetails_RefereeId",
                table: "MatchesDetails",
                column: "RefereeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MatchesDetails_RefereeId",
                table: "MatchesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesDetails_RefereeId",
                table: "MatchesDetails",
                column: "RefereeId",
                unique: true);
        }
    }
}
