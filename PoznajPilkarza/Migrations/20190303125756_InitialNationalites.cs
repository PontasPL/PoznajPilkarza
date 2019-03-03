using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPilkarza.Migrations
{
    public partial class InitialNationalites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CodeCountryTwoChars = table.Column<string>(nullable: true),
                    CodeCountryThreeChars = table.Column<string>(nullable: true),
                    TotalPopulation = table.Column<long>(nullable: false),
                    PngImage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WikiLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
