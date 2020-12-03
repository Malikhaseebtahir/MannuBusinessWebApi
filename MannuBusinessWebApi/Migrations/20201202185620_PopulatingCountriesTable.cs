using Microsoft.EntityFrameworkCore.Migrations;

namespace MannuBusinessWebApi.Migrations
{
    public partial class PopulatingCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Pakistan')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('India')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('UAE')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('China')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('England')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('America')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Countries WHERE Name IN ('Pakistan', 'India', 'UAE', 'China', 'England', 'America')");
        }
    }
}
