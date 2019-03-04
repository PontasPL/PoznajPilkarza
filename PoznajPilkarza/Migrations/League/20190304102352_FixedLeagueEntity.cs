using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPilkarza.Migrations.League
{
    public partial class FixedLeagueEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Nationalities_NationalityID",
                table: "Leagues");

            migrationBuilder.RenameColumn(
                name: "NationalityID",
                table: "Leagues",
                newName: "NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Leagues_NationalityID",
                table: "Leagues",
                newName: "IX_Leagues_NationalityId");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                table: "Leagues",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Nationalities_NationalityId",
                table: "Leagues");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Leagues",
                newName: "NationalityID");

            migrationBuilder.RenameIndex(
                name: "IX_Leagues_NationalityId",
                table: "Leagues",
                newName: "IX_Leagues_NationalityID");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityID",
                table: "Leagues",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Nationalities_NationalityID",
                table: "Leagues",
                column: "NationalityID",
                principalTable: "Nationalities",
                principalColumn: "NationalityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
